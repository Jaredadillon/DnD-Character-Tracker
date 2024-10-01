namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class armor2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Armors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Armors", "Strength", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Armors", "Strength", c => c.Int(nullable: false));
            AlterColumn("dbo.Armors", "Name", c => c.String());
        }
    }
}
