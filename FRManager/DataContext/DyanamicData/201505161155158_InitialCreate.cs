namespace FRManager.DataContext.DyanamicData
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DyanamicDataModels",
                c => new
                    {
                        mac = c.Int(nullable: false, identity: true),
                        user_name = c.String(nullable: false),
                        cpu_usage = c.Int(nullable: false),
                        memory_usage = c.Int(nullable: false),
                        disk_free_space = c.Int(nullable: false),
                        record_date = c.DateTime(nullable: false),
                        ip_address = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.mac);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DyanamicDataModels");
        }
    }
}
