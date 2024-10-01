namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class money : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Copper", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Silver", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Gold", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Gold");
            DropColumn("dbo.Characters", "Silver");
            DropColumn("dbo.Characters", "Copper");
        }
    }
}
