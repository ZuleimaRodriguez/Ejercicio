namespace Ejercicio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "Departamento_id" });
            RenameColumn(table: "dbo.Empleadoes", name: "Departamento_id", newName: "DepartamentoId");
            AlterColumn("dbo.Empleadoes", "DepartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleadoes", "DepartamentoId");
            AddForeignKey("dbo.Empleadoes", "DepartamentoId", "dbo.Departamentoes", "Id", cascadeDelete: true);
            DropColumn("dbo.Empleadoes", "cdDep");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleadoes", "cdDep", c => c.Int(nullable: false));
            DropForeignKey("dbo.Empleadoes", "DepartamentoId", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "DepartamentoId" });
            AlterColumn("dbo.Empleadoes", "DepartamentoId", c => c.Int());
            RenameColumn(table: "dbo.Empleadoes", name: "DepartamentoId", newName: "Departamento_id");
            CreateIndex("dbo.Empleadoes", "Departamento_id");
            AddForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes", "id");
        }
    }
}
