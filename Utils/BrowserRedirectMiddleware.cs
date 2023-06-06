using Microsoft.Net.Http.Headers;
using UAParser;

namespace Filters.Utils
{
    public class BrowserRedirectMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userAgent = context.Request.Headers[HeaderNames.UserAgent].ToString();
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);
            var browserName = clientInfo.UA.Family;

            if (browserName == "Edge" || browserName == "EdgeChromium" || browserName == "IE")
            {
                context.Response.Redirect("https://www.mozilla.org/en-US/firefox/new/");
            }
            else
            {
                await next(context);
            }
        }
    }
}
