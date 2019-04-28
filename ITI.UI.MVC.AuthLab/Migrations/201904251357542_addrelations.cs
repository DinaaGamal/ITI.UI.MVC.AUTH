namespace ITI.UI.MVC.AuthLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empolyee", "FK_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empolyee", "FK_DepartmentId");
            AddForeignKey("dbo.Empolyee", "FK_DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empolyee", "FK_DepartmentId", "dbo.Department");
            DropIndex("dbo.Empolyee", new[] { "FK_DepartmentId" });
            DropColumn("dbo.Empolyee", "FK_DepartmentId");
        }
    }
}
