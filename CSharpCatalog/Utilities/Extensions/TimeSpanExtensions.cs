
namespace CSharpCatalog.Utilities.Extensions;

public static class TimeSpanExtensions
{
    extension(TimeSpan timeSpan)
    {
        public TimeSpan TruncateToSeconds()
        {
            return TimeSpan.FromTicks(timeSpan.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);
        }
    }
}
