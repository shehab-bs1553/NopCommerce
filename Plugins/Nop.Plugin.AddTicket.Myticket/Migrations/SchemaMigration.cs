using FluentMigrator;
using Nop.Plugin.AddTicket.Myticket.Domain;
using Nop.Data.Extensions;
using Nop.Data.Migrations;

namespace Nop.Plugin.AddTicket.Myticket.Migrations;


[NopSchemaMigration("2024/02/07 11:40:55:1687541", "Nop.Plugins.AddTicket.MyTicket", MigrationProcessType.Installation)]

public class SchemaMigration : Migration
{
    public override void Up()
    {
        Create.TableFor<MyTicketRecord>();
    }

    public override void Down()
    {
        Delete.Table(nameof(MyTicketRecord));
    }
}
