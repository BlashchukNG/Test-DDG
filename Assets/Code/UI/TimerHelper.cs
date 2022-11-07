namespace Code.UI
{
    public static class TimerHelper
    {
        public static string GetTimeString(int time)
        {
            var total = time % (24 * 3600);
            var h = total / 3600;
            total %= 3600;
            var m = total / 60;
            var s = total % 60;
            return $"{h:00}:{m:00}:{s:00}";
        }
    }
}