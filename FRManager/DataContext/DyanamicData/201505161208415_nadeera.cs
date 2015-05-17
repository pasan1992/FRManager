namespace FRManager.DataContext.DyanamicData
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nadeera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DyanamicDataModels", "iq_address", c => c.String(maxLength: 15));
            DropColumn("dbo.DyanamicDataModels", "ip_address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DyanamicDataModels", "ip_address", c => c.String(maxLength: 15));
            DropColumn("dbo.DyanamicDataModels", "iq_address");
        }
    }
}
