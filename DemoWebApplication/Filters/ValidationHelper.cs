namespace DemoWebApplication.Filters;

public class ValidationHelper
{
    internal static async ValueTask<object?> ValidateRegionCode(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var regionCode = context.GetArgument<string>(0);
        if (string.IsNullOrEmpty(regionCode) || regionCode !="qa")
        {
            return Results.ValidationProblem(
                new Dictionary<string, string[]>
                {
                    { "regionCode", new[] { "Invalid format. region code must not be empty and should be either qa or uae" } }
                });
        }

        return await next(context);

    }
}
