namespace Movies.Helpers
{
    public class DateExtractor
    {
        public static int ExtractYear(DateTime date)
        {
            return date.Year;
        }

        public static string FormatConverter(DateTime dateTime)
        {
            TimeSpan elapsedTime = DateTime.UtcNow - dateTime;
            string timeAgoString;

            if (elapsedTime.TotalSeconds < 60)
            {
                //timeAgoString = string.Format("{0} second{1} ago", (int)elapsedTime.TotalSeconds, (int)elapsedTime.TotalSeconds == 1 ? "" : "s");
                return "Just now";
            }
            else if (elapsedTime.TotalMinutes < 60)
            {
                timeAgoString = string.Format("{0} minute{1} ago", (int)elapsedTime.TotalMinutes, (int)elapsedTime.TotalMinutes == 1 ? "" : "s");
            }
            else if (elapsedTime.TotalHours < 24)
            {
                timeAgoString = string.Format("{0} hour{1} ago", (int)elapsedTime.TotalHours, (int)elapsedTime.TotalHours == 1 ? "" : "s");
            }
            else if (elapsedTime.TotalDays < 7)
            {
                timeAgoString = string.Format("{0} day{1} ago", (int)elapsedTime.TotalDays, (int)elapsedTime.TotalDays == 1 ? "" : "s");
            }
            else if (elapsedTime.TotalDays < 30)
            {
                timeAgoString = string.Format("{0} day{1} ago", (int)elapsedTime.TotalDays, (int)elapsedTime.TotalDays == 1 ? "" : "s");
            }
            else if (elapsedTime.TotalDays < 365)
            {
                int months = (int)Math.Floor(elapsedTime.TotalDays / 30);
                timeAgoString = string.Format("{0} month{1} ago", months, months == 1 ? "" : "s");
            }
            else
            {
                int years = (int)Math.Floor(elapsedTime.TotalDays / 365);
                timeAgoString = string.Format("{0} year{1} ago", years, years == 1 ? "" : "s");
            }
            return timeAgoString;
        }
    }
}
