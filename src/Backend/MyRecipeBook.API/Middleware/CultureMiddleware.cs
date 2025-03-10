using System.Globalization;
using System.Runtime.CompilerServices;

namespace MyRecipeBook.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureinfo = new CultureInfo("en");

        if (string.IsNullOrWhiteSpace(requestedCulture) == false 
            && supportedLanguages.Any(c => c.Name.Equals(requestedCulture)))
        {
            cultureinfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureinfo;
        CultureInfo.CurrentUICulture = cultureinfo;

        await _next(context);
    }
}

