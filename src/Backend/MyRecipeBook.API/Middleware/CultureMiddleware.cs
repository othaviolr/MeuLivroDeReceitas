using System.Globalization;
using System.Runtime.CompilerServices;
using MyRecipeBook.Domain.Extensions;

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
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureinfo = new CultureInfo("en");

        if (requestedCulture.NotEmpty()
            && supportedLanguages.Exists(c => c.Name.Equals(requestedCulture)))
        {
            cultureinfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureinfo;
        CultureInfo.CurrentUICulture = cultureinfo;

        await _next(context);
    }
}

