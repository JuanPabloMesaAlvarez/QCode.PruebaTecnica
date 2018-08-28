namespace QCode.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QCode_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculoes", "Imagen", c => c.Binary());
            AddColumn("dbo.Vehiculoes", "FechaInsercion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehiculoes", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehiculoes", "Activo");
            DropColumn("dbo.Vehiculoes", "FechaInsercion");
            DropColumn("dbo.Vehiculoes", "Imagen");
        }
    }
}
