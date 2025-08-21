// here we will define the EvenConstraint class

using Microsoft.AspNetCore.Routing;

using Microsoft.AspNetCore.Http;

public class OddConstraint : IRouteConstraint

{

    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)

    {

        if (httpContext == null || route == null || values == null)

        {

            return false; // Ensure that the parameters are not null

        }

        // if (values.TryGetValue(routeKey, out var value) && value is int intValue)

        // {

        //     return intValue % 2 == 0;

        //     

        // }

        if (int.TryParse(values[routeKey]?.ToString(), out var intValue))

        {

            return intValue % 2 != 0;

        }

        return false;

        //here we are checking for even numbers in the route values

        //     //real life example could be filtering a list of products by even IDs and returning them

    }

}