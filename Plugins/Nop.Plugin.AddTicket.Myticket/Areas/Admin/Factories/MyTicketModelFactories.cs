using DocumentFormat.OpenXml.Wordprocessing;
using Nop.Core.Domain.Messages;
using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;
using Nop.Plugin.AddTicket.Myticket.Services;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.AddTicket.Myticket.Areas.Admin.Factories;
public class MyTicketModelFactories : IMyTicketModelFactories
{
    private readonly IMyTicketService _myTicketService;
    public MyTicketModelFactories(IMyTicketService myTicketService)
    {
        _myTicketService = myTicketService;
    }

    public async Task<MyTicketListModel> PrepareMyTicketListModelAsync(MyTicketSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(nameof(searchModel));

        var ticket = await _myTicketService.SearchMyTicketAsync(searchModel.Name,
            pageIndex: searchModel.Page - 1,
            pageSize: searchModel.PageSize);

        //prepare list model
        var model = await new MyTicketListModel().PrepareToGridAsync(searchModel, ticket, () =>
        {
            return ticket.SelectAwait(async ticket =>
            {
                return await PrepareMyTicketModelAsync(null, ticket, true);
            });
        });

        return model;
    }

    public async Task<MyTicketModel> PrepareMyTicketModelAsync(MyTicketModel model,
        MyTicketRecord employee, bool excludeProperties = false)
    {
        if (employee != null)
        {
            if (model == null)
            {
                //fill in model values from the entity
                model = new MyTicketModel()
                {
                    Name = employee.Name,
                    Id = employee.Id,
                    Email = employee.Email,
                    Body = employee.Body
                };
            }
        }
        return model;
    }

    public async Task<MyTicketSearchModel> PrepareMyTicketSearchModelAsync(MyTicketSearchModel searchmodel)
    {
        ArgumentNullException.ThrowIfNull(searchmodel);


        searchmodel.SetGridPageSize();

        return searchmodel;
    }

}
