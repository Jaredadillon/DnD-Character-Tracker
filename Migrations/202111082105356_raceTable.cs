namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerRaces",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "PlayerRaceId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Characters", "PlayerRaceId");
            AddForeignKey("dbo.Characters", "PlayerRaceId", "dbo.PlayerRaces", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "PlayerRaceId", "dbo.PlayerRaces");
            DropIndex("dbo.Characters", new[] { "PlayerRaceId" });
            DropColumn("dbo.Characters", "PlayerRaceId");
            DropTable("dbo.PlayerRaces");
        }
    }
}
