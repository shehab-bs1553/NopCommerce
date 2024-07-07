using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Factories;
using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;
using Nop.Plugin.AddTicket.Myticket.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.AddTicket.Myticket.Areas.Admin.Controllers;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class MyTicketController : BasePluginController
{
    private readonly IMyTicketService _myTicketService;
    private readonly IMyTicketModelFactories _myTicketModelFactories;
    public MyTicketController(IMyTicketService myTicketService,
        IMyTicketModelFactories myTicketModelFactories)
    {
        _myTicketService = myTicketService;
        _myTicketModelFactories = myTicketModelFactories;
    }

    public async Task<IActionResult> List()
    {
        var model = await _myTicketModelFactories.PrepareMyTicketSearchModelAsync(new MyTicketSearchModel());
        return View("~/Plugins/AddTicket.Myticket/Areas/Admin/Views/List.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> List(MyTicketSearchModel searchModel)
    {
        var model = await _myTicketModelFactories.PrepareMyTicketListModelAsync(searchModel);
        return Json(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _myTicketModelFactories.PrepareMyTicketModelAsync(new MyTicketModel(), null);
        return View("~/Plugins/AddTicket.Myticket/Areas/Admin/Views/Create.cshtml", model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(MyTicketModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var ticket = new MyTicketRecord
            {
                Name = model.Name,
                Email = model.Email,
                Body = model.Body
            };

            await _myTicketService.InsertTicketAsync(ticket);

            return continueEditing ? RedirectToAction("Edit", new { id = ticket.Id }) : RedirectToAction("List");
        }

        model = await _myTicketModelFactories.PrepareMyTicketModelAsync(model, null);
        return View("~/Plugins/AddTicket.Myticket/Areas/Admin/Views/Create.cshtml", model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(id);
        if (ticket == null)
            return RedirectToAction("List");

        var model = await _myTicketModelFactories.PrepareMyTicketModelAsync(null, ticket);
        return View("~/Plugins/AddTicket.Myticket/Areas/Admin/Views/Edit.cshtml", model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(MyTicketModel model, bool continueEditing)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(model.Id);
        if (ticket == null)
            return RedirectToAction("List");

        if (ModelState.IsValid)
        {
            ticket.Name = model.Name;
            ticket.Email = model.Email;
            ticket.Body = model.Body;

            await _myTicketService.UpdateTicketAsync(ticket);

            return continueEditing ? RedirectToAction("Edit", new { id = ticket.Id }) : RedirectToAction("List");
        }

        model = await _myTicketModelFactories.PrepareMyTicketModelAsync(model, ticket);
        return View("~/Plugins/AddTicket.Myticket/Areas/Admin/Views/Edit.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(MyTicketModel model)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(model.Id);
        if (ticket == null)
            return RedirectToAction("List");

        await _myTicketService.DeleteTicketAsync(ticket);
        return RedirectToAction("List");
    }
}
