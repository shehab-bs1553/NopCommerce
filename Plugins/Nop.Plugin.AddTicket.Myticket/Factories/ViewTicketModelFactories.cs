using Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
using Nop.Plugin.AddTicket.Myticket.Domain;
namespace Nop.Plugin.AddTicket.Myticket.Factories;

public class ViewTicketModelFactories : IViewTicketModelFactories
{
    public IList<MyTicketModel> PrepareTicketListModel(IList<MyTicketRecord> tickets)
    {
        var model = new List<MyTicketModel>();

        foreach (var ticket in tickets)
            model.Add(PrepareTicketModelAsync(ticket));

        return model;
    }

    public MyTicketModel PrepareTicketModelAsync(MyTicketRecord ticket)
    {
        return new MyTicketModel()
        {
            Id = ticket.Id,
            Name = ticket.Name,
            Email = ticket.Email,
            Body = ticket.Body 
        };
    }
}
