using Filters.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Filters.Pages
{
    [CustomFilter]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            int i = 0;
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            int i = 1;
        }
    }
}