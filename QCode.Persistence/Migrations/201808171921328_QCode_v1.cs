namespace QCode.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QCode_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReparacionOrdens",
                c => new
                    {
                        ReparacionOrdenId = c.Int(nullable: false, identity: true),
                        Placa = c.String(maxLength: 128),
                        Fecha = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ReparacionOrdenId)
                .ForeignKey("dbo.Vehiculoes", t => t.Placa)
                .Index(t => t.Placa);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        Placa = c.String(nullable: false, maxLength: 128),
                        Modelo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Placa);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        Contrasena = c.String(),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReparacionOrdens", "Placa", "dbo.Vehiculoes");
            DropIndex("dbo.ReparacionOrdens", new[] { "Placa" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.ReparacionOrdens");
        }
    }
}
