namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(nullable: false, maxLength: 50),
                        PlayerName = c.String(nullable: false, maxLength: 50),
                        Strength = c.Byte(nullable: false),
                        Dexterity = c.Byte(nullable: false),
                        Constitution = c.Byte(nullable: false),
                        Intelligence = c.Byte(nullable: false),
                        Wisdom = c.Byte(nullable: false),
                        Charisma = c.Byte(nullable: false),
                        PlayerClassId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayerClasses", t => t.PlayerClassId, cascadeDelete: true)
                .Index(t => t.PlayerClassId);
            
            CreateTable(
                "dbo.PlayerClasses",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "PlayerClassId", "dbo.PlayerClasses");
            DropIndex("dbo.Characters", new[] { "PlayerClassId" });
            DropTable("dbo.PlayerClasses");
            DropTable("dbo.Characters");
        }
    }
}
