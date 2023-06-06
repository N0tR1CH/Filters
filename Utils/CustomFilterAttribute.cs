using Filters.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Filters.Utils
{
    public class CustomFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            IGeoService geoService = context.HttpContext.RequestServices.GetService<IGeoService>();
            var ipAddress = context.HttpContext.Request.Host.ToString();
            var countryCode = await geoService.GetCountry(ipAddress);
            var result = (PageResult)context.Result;
            result.ViewData["CountryCode"] = countryCode;
            await next.Invoke();
        }
    }
}
