namespace EindwerkCarParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locatie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locaties", "Nr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locaties", "Nr");
        }
    }
}
