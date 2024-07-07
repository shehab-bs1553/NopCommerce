using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;
using Nop.Plugin.AddTicket.Myticket.Factories;
using Nop.Plugin.AddTicket.Myticket.Services;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.AddTicket.Myticket.Controller;
public class MyTicketViewController : BasePluginController

{
    private readonly IMyTicketService _myTicketService;
    private readonly IViewTicketModelFactories _viewTicketModelFactories;

    public MyTicketViewController(IMyTicketService myTicketService, IViewTicketModelFactories viewTicketModelFactories)
    {
        _myTicketService = myTicketService;
        _viewTicketModelFactories = viewTicketModelFactories;
    }

    public async Task<IActionResult> Index()
    {
        var tickets = await _myTicketService.SearchMyTicketAsync("", 0, 10);
        return View("~/Plugins/AddTicket.Myticket/Views/Index.cshtml", tickets);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("~/Plugins/AddTicket.Myticket/Views/Create.cshtml");
    }

   // [HttpPost]
    //public async Task<IActionResult> Create(MyTicketRecord model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        await _myTicketService.InsertTicketAsync(model);
    //        return RedirectToAction("Index");
    //    }
    //    return View("~/Plugins/AddTicket.Myticket/Views/Create.cshtml", model);
    //}
    [HttpPost]
    public async Task<IActionResult> Create(MyTicketModel model)
    {
        var ticket = new MyTicketRecord();
        if (ModelState.IsValid)
        {
            ticket = new MyTicketRecord
            {
                Name = model.Name,
                Email = model.Email,
                Body = model.Body
            };

            await _myTicketService.InsertTicketAsync(ticket);
            return RedirectToAction("Index");
        }
        return View("~/Plugins/AddTicket.Myticket/Views/Create.cshtml", ticket);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(id);
        if (ticket == null)
            return RedirectToAction("Index");

        var model = _viewTicketModelFactories.PrepareTicketModelAsync(ticket);

        return View("~/Plugins/AddTicket.Myticket/Views/Edit.cshtml", model);
    }

    //[HttpPost]
    //public async Task<IActionResult> Edit(MyTicketRecord model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        await _myTicketService.UpdateTicketAsync(model);
    //        return RedirectToAction("Index");
    //    }
    //    return View("~/Plugins/AddTicket.Myticket/Views/Edit.cshtml", model);
    //}


    [HttpPost]
    public async Task<IActionResult> Edit(MyTicketModel model)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(model.Id);
        if (ticket == null)
            return RedirectToAction("Index");

        if (ModelState.IsValid)
        {
            ticket.Name = model.Name;
            ticket.Email = model.Email;
            ticket.Body = model.Body;

            await _myTicketService.UpdateTicketAsync(ticket);
            return RedirectToAction("Index");
        }
        return View("~/Plugins/AddTicket.Myticket/Views/Edit.cshtml", ticket);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _myTicketService.GetMyTicketByIdAsync(id);
        if (ticket != null)
        {
            await _myTicketService.DeleteTicketAsync(ticket);
        }
        return RedirectToAction("Index");
    }
}
