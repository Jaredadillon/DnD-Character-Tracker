namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class level : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Level", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Level");
        }
    }
}
