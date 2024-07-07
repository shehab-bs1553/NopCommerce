using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.AddTicket.Myticket.Services;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.AddTicket.Myticket.Components;

public class MyTicketViewComponent : NopViewComponent
{
    private readonly IMyTicketService _myTicketService;
    public MyTicketViewComponent(IMyTicketService myTicketService)
    {
        _myTicketService = myTicketService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        var tickets = await _myTicketService.SearchMyTicketAsync("", 0, 10);
        return View("~/Plugins/AddTicket.Myticket/Views/Default.cshtml");
    }
}