using FluentMigrator;
using Microsoft.OpenApi.Services;

namespace Market_Web.Data.Migrations
{
    [Migration(16012025)]
    public class CreateSchema : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();

        }
        public override void Up()
        {
            Create.Table("market")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(120).NotNullable()
                .WithColumn("Employee").AsInt32().NotNullable()
                .WithColumn("Inauguration").AsDate().NotNullable()
                .WithColumn("SalesPerMonth").AsDouble().NotNullable();





        }





    }




}