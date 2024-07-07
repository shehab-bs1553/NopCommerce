using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;

namespace Nop.Plugin.AddTicket.Myticket.Factories
{
    public interface IViewTicketModelFactories
    {
        IList<MyTicketModel> PrepareTicketListModel(IList<MyTicketRecord> tickets);
        MyTicketModel PrepareTicketModelAsync(MyTicketRecord ticket);
    }
}
