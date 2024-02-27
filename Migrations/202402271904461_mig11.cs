namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "CategoryId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Categories", "CategoryId");
        }
    }
}
