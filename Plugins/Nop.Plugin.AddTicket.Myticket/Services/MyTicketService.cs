using Nop.Core;
using Nop.Data;
using Nop.Plugin.AddTicket.Myticket.Domain;

namespace Nop.Plugin.AddTicket.Myticket.Services;
public class MyTicketService : IMyTicketService
{
    private readonly IRepository<MyTicketRecord> _myticketRepository;

    public MyTicketService(IRepository<MyTicketRecord> myticketRepository)
    {
        _myticketRepository = myticketRepository;
    }

    public virtual async Task InsertTicketAsync(MyTicketRecord ticket)
    {
        await _myticketRepository.InsertAsync(ticket);
    }

    public virtual async Task UpdateTicketAsync(MyTicketRecord ticket)
    {
        await _myticketRepository.UpdateAsync(ticket);
    }

    public virtual async Task DeleteTicketAsync(MyTicketRecord ticket)
    {
        await _myticketRepository.DeleteAsync(ticket);
    }

    public virtual async Task<MyTicketRecord> GetMyTicketByIdAsync(int ticketId)
    {
        return await _myticketRepository.GetByIdAsync(ticketId);
    }

    public virtual async Task<IPagedList<MyTicketRecord>> SearchMyTicketAsync(string name,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from e in _myticketRepository.Table
                    select e;

        //if (!string.IsNullOrEmpty(name))
        //    query = query.Where(e => e.Name.Contains(name));


        query = query.OrderBy(e => e.Name);

        return await query.ToPagedListAsync(pageIndex, pageSize);
    }
}
