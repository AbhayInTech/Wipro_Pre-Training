using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvanceRoutingDemo.Constraints;

public class GuidConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out var value) && value != null)
        {
            var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
            return Guid.TryParse(stringValue, out _);
        }
        return false;
    }
}
