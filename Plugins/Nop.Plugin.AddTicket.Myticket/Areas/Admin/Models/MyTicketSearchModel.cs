using Nop.Web.Framework.Models;

namespace Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models;
public record MyTicketSearchModel : BaseSearchModel
{
    public string Name { get; internal set; }
}
