using Market_Web.Object;
using FluentMigrator;

namespace Market_Web.Data.Migrations
{
    [Migration(16112025)]
    public class TestMigrate:Migration
    {

        public override void Down()
        {
            throw new NotImplementedException();
        }
        public override void Up()
        {
            Execute.Script(@"Data/scripts/data.sql");


        }




    }
}
