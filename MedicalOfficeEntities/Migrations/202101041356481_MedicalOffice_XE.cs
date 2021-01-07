namespace MedicalOfficeEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicalOffice_XE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Record = c.String(),
                        PatientId = c.Int(nullable: false),
                        AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.AppointmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Visits", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "AppointmentId" });
            DropIndex("dbo.Visits", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Visits");
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
        }
    }
}
