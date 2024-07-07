using System.ComponentModel;
using Nop.Core;

namespace Nop.Plugin.AddTicket.Myticket.Domain;
public class MyTicketRecord : BaseEntity
{
    [DisplayName("Ticket Name :")]
    public string Name { get; set; }

    [DisplayName("Email :")]
    public string Email { get; set; }

    [DisplayName("Details :")]
    public string Body { get; set; }
}
