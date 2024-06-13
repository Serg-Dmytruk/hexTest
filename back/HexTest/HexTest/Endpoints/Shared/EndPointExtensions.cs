namespace HexTest.Endpoints.Shared;

public static class EndPointExtensions
{
    public static void UseEndPoints<TMarker>(this IApplicationBuilder app)
    {
        UseEndPoints(app, typeof(TMarker));
    }

    private static void UseEndPoints(this IApplicationBuilder app, Type typeMarker)
    {
        var endPointTypes =
            typeMarker.Assembly.DefinedTypes.Where(x =>
                x is { IsAbstract: false, IsInterface: false } && typeof(IEndpoints).IsAssignableFrom(x));

        foreach (var endPointType in endPointTypes)
        {
            endPointType.GetMethod(nameof(IEndpoints.DefineEndPoints))!.Invoke(null, [app]);
        }
    }
}