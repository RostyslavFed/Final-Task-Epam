namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.EmployeeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DiagnoseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnoses", t => t.DiagnoseId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DiagnoseId);
            
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Class = c.String(),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        MedicationForm = c.String(nullable: false, maxLength: 20),
                        Use = c.String(),
                        Schedule = c.String(),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                        InstructionForPreparation = c.String(),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Schedule = c.String(),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MedicineExaminations",
                c => new
                    {
                        Medicine_Id = c.Int(nullable: false),
                        Examination_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medicine_Id, t.Examination_Id })
                .ForeignKey("dbo.Medicines", t => t.Medicine_Id, cascadeDelete: true)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id, cascadeDelete: true)
                .Index(t => t.Medicine_Id)
                .Index(t => t.Examination_Id);
            
            CreateTable(
                "dbo.OperationExaminations",
                c => new
                    {
                        Operation_Id = c.Int(nullable: false),
                        Examination_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Operation_Id, t.Examination_Id })
                .ForeignKey("dbo.Operations", t => t.Operation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id, cascadeDelete: true)
                .Index(t => t.Operation_Id)
                .Index(t => t.Examination_Id);
            
            CreateTable(
                "dbo.ProcedureExaminations",
                c => new
                    {
                        Procedure_Id = c.Int(nullable: false),
                        Examination_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Procedure_Id, t.Examination_Id })
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id, cascadeDelete: true)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id, cascadeDelete: true)
                .Index(t => t.Procedure_Id)
                .Index(t => t.Examination_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProcedureExaminations", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.ProcedureExaminations", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.Examinations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.OperationExaminations", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.OperationExaminations", "Operation_Id", "dbo.Operations");
            DropForeignKey("dbo.MedicineExaminations", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.MedicineExaminations", "Medicine_Id", "dbo.Medicines");
            DropForeignKey("dbo.Examinations", "DiagnoseId", "dbo.Diagnoses");
            DropForeignKey("dbo.Patients", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProcedureExaminations", new[] { "Examination_Id" });
            DropIndex("dbo.ProcedureExaminations", new[] { "Procedure_Id" });
            DropIndex("dbo.OperationExaminations", new[] { "Examination_Id" });
            DropIndex("dbo.OperationExaminations", new[] { "Operation_Id" });
            DropIndex("dbo.MedicineExaminations", new[] { "Examination_Id" });
            DropIndex("dbo.MedicineExaminations", new[] { "Medicine_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Examinations", new[] { "DiagnoseId" });
            DropIndex("dbo.Examinations", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "User_Id" });
            DropIndex("dbo.Patients", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "CategoryId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.ProcedureExaminations");
            DropTable("dbo.OperationExaminations");
            DropTable("dbo.MedicineExaminations");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Procedures");
            DropTable("dbo.Operations");
            DropTable("dbo.Medicines");
            DropTable("dbo.Diagnoses");
            DropTable("dbo.Examinations");
            DropTable("dbo.Patients");
            DropTable("dbo.Employees");
            DropTable("dbo.Categories");
        }
    }
}
