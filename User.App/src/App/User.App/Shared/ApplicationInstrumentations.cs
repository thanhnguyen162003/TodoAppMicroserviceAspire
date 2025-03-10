using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace User.App.Shared;

public class ApplicationInstrumentation
{
    public static Meter Meter = new Meter("User.App", "1.0.0");
    public static ActivitySource ActivitySource = new ActivitySource("User.App", "1.0.0");
}