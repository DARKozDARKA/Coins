using System;

namespace CodeBase.Tools
{
    public static class TimeConverter
    {
        public static string FromSecondsToTime(int time)
        {
            TimeSpan result = TimeSpan.FromSeconds(time);
            return result.ToString("mm':'ss");
        }
    }
}