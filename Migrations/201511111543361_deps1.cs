namespace Ejercicio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deps1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleadoes", "cdDep", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleadoes", "cdDep");
        }
    }
}
