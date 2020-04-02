namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        ExceptionMessage = c.String(),
                        StackTrace = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
