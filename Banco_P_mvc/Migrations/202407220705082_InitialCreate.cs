namespace Banco_P_mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Dni_Cli = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        Nom_Cli = c.String(maxLength: 30, unicode: false),
                        Ape_Pat_Cli = c.String(maxLength: 20, unicode: false),
                        Ape_Mat_Cli = c.String(maxLength: 20, unicode: false),
                        Tel_Cli = c.String(maxLength: 9, fixedLength: true, unicode: false),
                        Cor_cli = c.String(maxLength: 70, unicode: false),
                        Dir_cli = c.String(maxLength: 40, unicode: false),
                        Dis_cli = c.String(maxLength: 15, unicode: false),
                        Fec_Ing_Cli = c.DateTime(nullable: false),
                        Fec_Nac_Cli = c.DateTime(nullable: false),
                        Cod_Emp = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Dni_Cli)
                .ForeignKey("dbo.Empleado", t => t.Cod_Emp)
                .Index(t => t.Cod_Emp);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Cod_Emp = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        DNI_Emp = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        Nom_Emp = c.String(maxLength: 30, unicode: false),
                        Ape_Pat_Emp = c.String(maxLength: 20, unicode: false),
                        Ape_Mat_Emp = c.String(maxLength: 20, unicode: false),
                        Tel_Emp = c.String(maxLength: 9, fixedLength: true, unicode: false),
                        Cor_Emp = c.String(maxLength: 70, unicode: false),
                        Dir_Emp = c.String(maxLength: 40, unicode: false),
                        Dis_Emp = c.String(maxLength: 15, unicode: false),
                        Fec_ing_Emp = c.DateTime(nullable: false),
                        Car_Emp = c.String(maxLength: 20, unicode: false),
                        Cod_Suc = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        UsuarioEmpleado = c.String(nullable: false, maxLength: 30),
                        ClaveEmpleado = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Cod_Emp)
                .ForeignKey("dbo.Sucursal", t => t.Cod_Suc)
                .Index(t => t.Cod_Suc);
            
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        Cod_Suc = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Nom_Suc = c.String(maxLength: 30, unicode: false),
                        Afo_Suc = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        Dis_Suc = c.String(maxLength: 25, unicode: false),
                        Pro_Suc = c.String(maxLength: 15, unicode: false),
                        Dep_Suc = c.String(maxLength: 15, unicode: false),
                        Dir_Suc = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.Cod_Suc);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        Num_Cue = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                        Sal_Cue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ruc_Cli = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        Mon_Ape = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cue_aho = c.Boolean(nullable: false),
                        Cue_Cor = c.Boolean(nullable: false),
                        Cod_Suc = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Num_Cue)
                .ForeignKey("dbo.Sucursal", t => t.Cod_Suc)
                .Index(t => t.Cod_Suc);
            
            CreateTable(
                "dbo.DetalleAdquisicion",
                c => new
                    {
                        Id_Det_Adq = c.Int(nullable: false, identity: true),
                        Dni_Cli = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        Cod_Seg = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        Fec_adq = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Det_Adq)
                .ForeignKey("dbo.Cliente", t => t.Dni_Cli)
                .ForeignKey("dbo.Seguro", t => t.Cod_Seg)
                .Index(t => t.Dni_Cli)
                .Index(t => t.Cod_Seg);
            
            CreateTable(
                "dbo.Seguro",
                c => new
                    {
                        Cod_Seg = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Cos_Men_Seg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fec_Nac = c.DateTime(nullable: false),
                        Num_Tar = c.String(maxLength: 16, unicode: false),
                        Seg_Onc = c.Boolean(nullable: false),
                        Seg_Tar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cod_Seg);
            
            CreateTable(
                "dbo.DetalleApertura",
                c => new
                    {
                        Id_Ape = c.Int(nullable: false, identity: true),
                        Dni_Cli = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        Num_Cue = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        Fec_Ape = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Ape)
                .ForeignKey("dbo.Cliente", t => t.Dni_Cli)
                .ForeignKey("dbo.Cuenta", t => t.Num_Cue)
                .Index(t => t.Dni_Cli)
                .Index(t => t.Num_Cue);
            
            CreateTable(
                "dbo.DetalleSolicitud",
                c => new
                    {
                        Id_Solicitud = c.Int(nullable: false, identity: true),
                        Dni_Cli = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        Cod_Pre = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        Fec_Sol = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Solicitud)
                .ForeignKey("dbo.Cliente", t => t.Dni_Cli)
                .ForeignKey("dbo.Prestamo", t => t.Cod_Pre)
                .Index(t => t.Dni_Cli)
                .Index(t => t.Cod_Pre);
            
            CreateTable(
                "dbo.Prestamo",
                c => new
                    {
                        Cod_Pre = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Mon_Pre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pre_Est = c.Boolean(nullable: false),
                        Com_Deu = c.Boolean(nullable: false),
                        Cod_Suc = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Cod_Pre)
                .ForeignKey("dbo.Sucursal", t => t.Cod_Suc)
                .Index(t => t.Cod_Suc);
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        Cod_Pgo = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Num_Cuo_Pgo = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        Fec_Pro_Pgo = c.DateTime(nullable: false),
                        Mon_Pgo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fec_Rea_Pgo = c.DateTime(nullable: false),
                        Cod_Pre = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Cod_Pgo)
                .ForeignKey("dbo.Prestamo", t => t.Cod_Pre)
                .Index(t => t.Cod_Pre);
            
            CreateTable(
                "dbo.Transferencia",
                c => new
                    {
                        Cod_Tra = c.String(nullable: false, maxLength: 7, fixedLength: true, unicode: false),
                        Mon_Tra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cue_Tra = c.String(maxLength: 20, unicode: false),
                        Fec_Tra = c.DateTime(nullable: false),
                        Tra_Int = c.Boolean(nullable: false),
                        Num_Cue = c.String(maxLength: 11, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Cod_Tra)
                .ForeignKey("dbo.Cuenta", t => t.Num_Cue)
                .Index(t => t.Num_Cue);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transferencia", "Num_Cue", "dbo.Cuenta");
            DropForeignKey("dbo.Pago", "Cod_Pre", "dbo.Prestamo");
            DropForeignKey("dbo.DetalleSolicitud", "Cod_Pre", "dbo.Prestamo");
            DropForeignKey("dbo.Prestamo", "Cod_Suc", "dbo.Sucursal");
            DropForeignKey("dbo.DetalleSolicitud", "Dni_Cli", "dbo.Cliente");
            DropForeignKey("dbo.DetalleApertura", "Num_Cue", "dbo.Cuenta");
            DropForeignKey("dbo.DetalleApertura", "Dni_Cli", "dbo.Cliente");
            DropForeignKey("dbo.DetalleAdquisicion", "Cod_Seg", "dbo.Seguro");
            DropForeignKey("dbo.DetalleAdquisicion", "Dni_Cli", "dbo.Cliente");
            DropForeignKey("dbo.Cuenta", "Cod_Suc", "dbo.Sucursal");
            DropForeignKey("dbo.Cliente", "Cod_Emp", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "Cod_Suc", "dbo.Sucursal");
            DropIndex("dbo.Transferencia", new[] { "Num_Cue" });
            DropIndex("dbo.Pago", new[] { "Cod_Pre" });
            DropIndex("dbo.Prestamo", new[] { "Cod_Suc" });
            DropIndex("dbo.DetalleSolicitud", new[] { "Cod_Pre" });
            DropIndex("dbo.DetalleSolicitud", new[] { "Dni_Cli" });
            DropIndex("dbo.DetalleApertura", new[] { "Num_Cue" });
            DropIndex("dbo.DetalleApertura", new[] { "Dni_Cli" });
            DropIndex("dbo.DetalleAdquisicion", new[] { "Cod_Seg" });
            DropIndex("dbo.DetalleAdquisicion", new[] { "Dni_Cli" });
            DropIndex("dbo.Cuenta", new[] { "Cod_Suc" });
            DropIndex("dbo.Empleado", new[] { "Cod_Suc" });
            DropIndex("dbo.Cliente", new[] { "Cod_Emp" });
            DropTable("dbo.Transferencia");
            DropTable("dbo.Pago");
            DropTable("dbo.Prestamo");
            DropTable("dbo.DetalleSolicitud");
            DropTable("dbo.DetalleApertura");
            DropTable("dbo.Seguro");
            DropTable("dbo.DetalleAdquisicion");
            DropTable("dbo.Cuenta");
            DropTable("dbo.Sucursal");
            DropTable("dbo.Empleado");
            DropTable("dbo.Cliente");
        }
    }
}
