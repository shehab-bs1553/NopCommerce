using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;

namespace Nop.Plugin.AddTicket.Myticket.Areas.Admin.Factories;

public interface IMyTicketModelFactories
{
    Task<MyTicketSearchModel> PrepareMyTicketSearchModelAsync(MyTicketSearchModel searchModel);

    Task<MyTicketListModel> PrepareMyTicketListModelAsync(MyTicketSearchModel searchModel);

    Task<MyTicketModel> PrepareMyTicketModelAsync(MyTicketModel model, MyTicketRecord employee, bool excludeProperties = false);
}