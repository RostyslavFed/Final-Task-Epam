namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_log_data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Login", c => c.String());
            AddColumn("dbo.Logs", "Ip", c => c.String());
            AddColumn("dbo.Logs", "Url", c => c.String());
            DropColumn("dbo.Logs", "ExceptionMessage");
            DropColumn("dbo.Logs", "StackTrace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "StackTrace", c => c.String());
            AddColumn("dbo.Logs", "ExceptionMessage", c => c.String());
            DropColumn("dbo.Logs", "Url");
            DropColumn("dbo.Logs", "Ip");
            DropColumn("dbo.Logs", "Login");
        }
    }
}
