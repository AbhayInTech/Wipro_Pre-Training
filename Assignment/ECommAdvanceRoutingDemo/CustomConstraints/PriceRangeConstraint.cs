using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace ECommAdvanceRoutingDemo.CustomConstraints
{
    public class PriceRangeConstraint : IRouteConstraint
    {
        private static readonly Regex _priceRangeRegex = new Regex(@"^\d+-\d+$");

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value))
            {
                return false;
            }

            var stringValue = Convert.ToString(value);
            if (string.IsNullOrEmpty(stringValue))
            {
                return false;
            }

            return _priceRangeRegex.IsMatch(stringValue);
        }
    }
}
