using FluentMigrator;

namespace Order.Infraestructure.Data.Migrations
{
    [Migration(20230429, "Create_Order_OrderItem")]
    public class Create_Order_OrderItem : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsAnsiString().NotNullable().Identity().PrimaryKey()
                .WithColumn("CreatAt").AsDate().NotNullable()
                .WithColumn("UpdateAt").AsDate().Nullable()
                .WithColumn("PersonEntityId").AsAnsiString()
                .WithColumn("AmountTotal").AsDecimal()
                .WithColumn("TotalOrderValue").AsDecimal()
                .WithColumn("TotalDiscount").AsDecimal();

            Create.Table("OrderItem")
                .WithColumn("Id").AsAnsiString().NotNullable().Identity().PrimaryKey()
                .WithColumn("CreatAt").AsDate().NotNullable()
                .WithColumn("UpdateAt").AsDate().Nullable()
                .WithColumn("OrderId").AsAnsiString().NotNullable().ForeignKey()
                .WithColumn("ProductDescription").AsAnsiString()
                .WithColumn("ProductId").AsAnsiString()
                .WithColumn("Item").AsInt32()
                .WithColumn("Amount").AsDecimal()
                .WithColumn("TotalPrice").AsDecimal()
                .WithColumn("UnitPrice").AsDecimal()
                .WithColumn("TotalDiscount").AsDecimal()
                .WithColumn("Discount").AsDecimal();

            Create.Index("IX_Order_OrderItem")
                .OnTable("Order")
        }
    }
}
