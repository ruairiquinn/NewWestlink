using System.Web.Mvc;

namespace NewWestlink.Infrastructure.Extensions
{
    public static class ControllerContextExtensions
    {
        public static bool IsRazorView(this ControllerContext executingContext)
        {
#if MVC3
            var razorViewToken = executingContext.RouteData.DataTokens[Areas.Razor.RazorAreaRegistration.RazorViewToken];
            return razorViewToken != null && razorViewToken.Equals(true);
#else
            return false;
#endif
        }
    }
}