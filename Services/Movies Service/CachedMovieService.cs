using Movies.DTOs.ActorsDTOs;
using Movies.Services.Cache_Service;

namespace Movies.Services.Movies_Service
{
    public class CachedMovieService : IMovieService
    {
        private readonly IMovieService _inner;
        private readonly ICacheService _cache;

        private static readonly TimeSpan DefaultTtl = TimeSpan.FromMinutes(5);
        private static readonly TimeSpan ShortTtl = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan NullTtl = TimeSpan.FromSeconds(30);

        public CachedMovieService(IMovieService inner, ICacheService cache)
        {
            _inner = inner;
            _cache = cache;
        }

        #region ===== Helpers =====

        private async Task<ServiceResponse<T>> GetOrSetAsync<T>(
            string key,
            Func<Task<ServiceResponse<T>>> factory,
            TimeSpan? ttl = null)
        {
            var cached = await _cache.GetAsync<ServiceResponse<T>>(key);
            if (cached != null)
                return cached;

            var result = await factory();

            var effectiveTtl = result.Data == null ? NullTtl : ttl ?? DefaultTtl;
            await _cache.SetAsync(key, result, effectiveTtl);

            return result;
        }

        private async Task<string> GetVersionedKeyAsync(
            string baseKey,
            string versionKey)
        {
            var version = await _cache.GetVersionAsync(versionKey);
            return $"{baseKey}:v{version}";
        }

        #endregion

        #region ===== Single Movie (No Versioning) =====

        public Task<ServiceResponse<FullMovieDTO>> GetMovieById(int movieId)
            => GetOrSetAsync(
                key: $"movie:{movieId}",
                factory: () => _inner.GetMovieById(movieId));

        public Task<ServiceResponse<ShortMovieDTO>> GetShortMovieById(int movieId)
            => GetOrSetAsync(
                key: $"short_movie:{movieId}",
                factory: () => _inner.GetShortMovieById(movieId));

        public Task<ServiceResponse<MovieWithoutReviewsDTO>> GetMovieWithoutReviews(int movieId)
            => GetOrSetAsync(
                key: $"movie_no_reviews:{movieId}",
                factory: () => _inner.GetMovieWithoutReviews(movieId));

        #endregion

        #region ===== All Movies (Versioned List) =====

        public async Task<ServiceResponse<MoviesListDTO>> GetAllMovies(int page, int pageSize)
        {
            var versionedKey = await GetVersionedKeyAsync(
                baseKey: $"movies:all:{page}:{pageSize}",
                versionKey: "movies:all:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetAllMovies(page, pageSize));
        }

        public async Task<ServiceResponse<List<MovieNameDTO>>> GetAllMoviesWithoutPagination()
        {
            var versionedKey = await GetVersionedKeyAsync(
                baseKey: "movies:all:nopage",
                versionKey: "movies:all:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetAllMoviesWithoutPagination());
        }

        #endregion

        #region ===== Genre (Versioned per Genre) =====

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesByGenreId(
            int genreId, int page, int pageSize)
        {
            var versionKey = $"movies:genre:{genreId}:version";

            var versionedKey = await GetVersionedKeyAsync(
                baseKey: $"movies:genre:{genreId}:{page}:{pageSize}",
                versionKey: versionKey);

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetMoviesByGenreId(genreId, page, pageSize));
        }

        #endregion

        #region ===== Search (Versioned Global) =====

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesBySearchName(
            string searchInput, int page, int pageSize)
        {
            var normalized = searchInput.Trim().ToLowerInvariant();

            var versionedKey = await GetVersionedKeyAsync(
                baseKey: $"movies:search:{normalized}:{page}:{pageSize}",
                versionKey: "movies:search:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetMoviesBySearchName(searchInput, page, pageSize),
                ttl: ShortTtl);
        }

        public async Task<ServiceResponse<List<MovieNameDTO>>> GetMoviesSuggestions(
            string searchInput)
        {
            var normalized = searchInput.Trim().ToLowerInvariant();

            var versionedKey = await GetVersionedKeyAsync(
                baseKey: $"movies:suggestions:{normalized}",
                versionKey: "movies:search:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetMoviesSuggestions(searchInput),
                ttl: TimeSpan.FromMinutes(1));
        }

        #endregion

        #region ===== Reviews =====

        public Task<ServiceResponse<MovieReviewsDTO>> GetReviewsByMovieId(
            int movieId, int pageNumber, int pageSize, int skipNumber)
        {
            return _inner.GetReviewsByMovieId(movieId, pageNumber, pageSize, skipNumber);
        }

        #endregion

        #region ===== Actors =====

        public Task<ServiceResponse<List<ShortActorDTO>>> GetActorsByMovieId(int movieId)
            => GetOrSetAsync(
                key: $"movie_actors:{movieId}",
                factory: () => _inner.GetActorsByMovieId(movieId));

        public async Task<ServiceResponse<List<ActorNamesDTO>>> GetActorNames()
        {
            var versionedKey = await GetVersionedKeyAsync(
                baseKey: "actors:names",
                versionKey: "actors:names:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetActorNames());
        }

        #endregion

        #region ===== Genres =====

        public async Task<ServiceResponse<List<GenreNameDTO>>> GetGenreNames()
        {
            var versionedKey = await GetVersionedKeyAsync(
                baseKey: "genres:names",
                versionKey: "genres:names:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetGenreNames());
        }

        public async Task<ServiceResponse<GetHomepageMoviesDTO>> GetHomepageMovies()
        {
            var versionedKey = await GetVersionedKeyAsync(
                baseKey: "movies:homepage",
                versionKey: "movies:homepage:version");

            return await GetOrSetAsync(
                key: versionedKey,
                factory: () => _inner.GetHomepageMovies(),
                ttl: ShortTtl);
        }

        #endregion

        #region ===== Write Operations (No Caching, Only Invalidate) =====

        public async Task<ServiceResponse<int>> AddMovieByAdmin(AddMovieDTO dto)
        {
            var result = await _inner.AddMovieByAdmin(dto);

            if (result.Success)
            {
                await _cache.IncrementVersionAsync("movies:all:version");
                await _cache.IncrementVersionAsync("movies:search:version");
                await _cache.IncrementVersionAsync("movies:homepage:version");
            }

            return result;
        }

        public async Task<ServiceResponse<int>> EditMovieByAdmin(EditMovieDTO dto)
        {
            var result = await _inner.EditMovieByAdmin(dto);

            if (result.Success)
            {
                await _cache.RemoveAsync($"movie:{dto.Id}");
                await _cache.RemoveAsync($"short_movie:{dto.Id}");
                await _cache.RemoveAsync($"movie_actors:{dto.Id}");
                await _cache.RemoveAsync($"movie_no_reviews:{dto.Id}");

                await _cache.IncrementVersionAsync("movies:all:version");
                await _cache.IncrementVersionAsync("movies:search:version");
                await _cache.IncrementVersionAsync("movies:homepage:version");
            }

            return result;
        }

        public async Task<ServiceResponseWithoutData> DeleteMovieByAdmin(int movieId)
        {
            var result = await _inner.DeleteMovieByAdmin(movieId);

            if (result.Success)
            {
                await _cache.RemoveAsync($"movie:{movieId}");
                await _cache.RemoveAsync($"short_movie:{movieId}");
                await _cache.RemoveAsync($"movie_actors:{movieId}");
                await _cache.RemoveAsync($"movie_no_reviews:{movieId}");

                await _cache.IncrementVersionAsync("movies:all:version");
                await _cache.IncrementVersionAsync("movies:search:version");
                await _cache.IncrementVersionAsync("movies:homepage:version");
            }

            return result;
        }

        #endregion
    }
}
