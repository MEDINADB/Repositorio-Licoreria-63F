namespace LiqourStore.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedores", "NumeroTelefono", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proveedores", "NumeroTelefono");
        }
    }
}
