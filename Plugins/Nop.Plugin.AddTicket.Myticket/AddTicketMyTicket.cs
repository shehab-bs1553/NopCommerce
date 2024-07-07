using Microsoft.AspNetCore.Routing;
using Nop.Plugin.AddTicket.Myticket.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.AddTicket.Myticket;
public class AddTicketMyTicket : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
{
    public bool HideInWidgetList => false;

    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(MyTicketViewComponent);
       // throw new NotImplementedException();
    }

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.AccountNavigationAfter });
        //throw new NotImplementedException();

    }

    public override async Task InstallAsync()
    {
        await base.InstallAsync();
    }

    public Task ManageSiteMapAsync(SiteMapNode rootNode)
    {
        var menuItem = new SiteMapNode()
        {
            SystemName = "Ticket",
            Title = "Manage Ticket",
            ControllerName = "MyTicket",
            ActionName = "List",
            IconClass = "far fa-dot-circle",
            Visible = true,
            RouteValues = new RouteValueDictionary() { { "area", AreaNames.ADMIN } },
        };

        var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
        if (pluginNode != null)
            pluginNode.ChildNodes.Add(menuItem);
        else
            rootNode.ChildNodes.Add(menuItem);

        return Task.CompletedTask;
    }

    public override async Task UninstallAsync()
    {
        await base.UninstallAsync();
    }

}
