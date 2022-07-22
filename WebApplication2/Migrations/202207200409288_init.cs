namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HR.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "HR.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmplyeeName = c.String(maxLength: 100, unicode: false),
                        ImageUser = c.String(maxLength: 100, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        HiringDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NationalID = c.String(nullable: false, maxLength: 14, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("HR.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Employees", "DepartmentId", "HR.Departments");
            DropIndex("HR.Employees", new[] { "DepartmentId" });
            DropTable("HR.Employees");
            DropTable("HR.Departments");
        }
    }
}
