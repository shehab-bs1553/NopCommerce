using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.AddTicket.Myticket.Infrastructure;
public class RouteProvider : BaseRouteProvider, IRouteProvider
{
    public int Priority => 0;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var pattern = GetLanguageRoutePattern();

        endpointRouteBuilder.MapControllerRoute("MyTicketView.Index", $"{pattern}/MyTicketView/Index",
            new { controller = "MyTicketView", action = "Index" });

        endpointRouteBuilder.MapControllerRoute("MyTicketView.Create", $"{pattern}/MyTicketView/Create",
            new { controller = "MyTicketView", action = "Create" });

        endpointRouteBuilder.MapControllerRoute("MyTicketView.Edit", $"{pattern}/MyTicketView/Edit",
           new { controller = "MyTicketView", action = "Edit" });

        endpointRouteBuilder.MapControllerRoute("MyTicketView.Delete", $"{pattern}/MyTicketView/Delete",
        new { controller = "MyTicketView", action = "Delete" });
    }
}
