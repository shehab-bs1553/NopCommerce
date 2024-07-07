using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.AddTicket.Myticket.Areas.Admin.Models
{
    public record MyTicketModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Name")]
        public string Name { get; set; }
        [NopResourceDisplayName("Email")]
        public string Email { get; set; }
        [NopResourceDisplayName("Body")]
        public string Body { get; set; }
    }
}
