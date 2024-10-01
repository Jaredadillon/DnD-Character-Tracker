namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class background : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Background", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Background");
        }
    }
}
