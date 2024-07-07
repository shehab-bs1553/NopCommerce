using Nop.Core;
using Nop.Plugin.AddTicket.Myticket.Domain;

namespace Nop.Plugin.AddTicket.Myticket.Services;

public interface IMyTicketService
{
    Task InsertTicketAsync(MyTicketRecord ticket);

    Task UpdateTicketAsync(MyTicketRecord ticket);

    Task DeleteTicketAsync(MyTicketRecord ticket);

    Task<MyTicketRecord> GetMyTicketByIdAsync(int ticketId);

    Task<IPagedList<MyTicketRecord>> SearchMyTicketAsync(string name,
            int pageIndex = 0, int pageSize = int.MaxValue);
}