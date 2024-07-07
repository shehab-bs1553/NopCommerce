using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.AddTicket.Myticket.Domain;

namespace Nop.Plugin.AddTicket.Myticket.Data
{
    public class MyTicketRecordBuilder : NopEntityBuilder<MyTicketRecord>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(MyTicketRecord.Id)).AsInt32().PrimaryKey().Identity()
                .WithColumn(nameof(MyTicketRecord.Name)).AsString(40).NotNullable()
                .WithColumn(nameof(MyTicketRecord.Email)).AsString(40).NotNullable()
                .WithColumn(nameof(MyTicketRecord.Body)).AsString(800).NotNullable();
        }
    }
}
