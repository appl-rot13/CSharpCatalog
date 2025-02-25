
namespace CSharpCatalog.Utilities.Extensions;

public static class TimeSpanExtensions
{
    public static TimeSpan TruncateToSeconds(this TimeSpan timeSpan)
    {
        return TimeSpan.FromTicks(timeSpan.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);
    }
}
