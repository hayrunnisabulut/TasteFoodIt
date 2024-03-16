namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderInfoes",
                c => new
                    {
                        SliderInfoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.SliderInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SliderInfoes");
        }
    }
}
