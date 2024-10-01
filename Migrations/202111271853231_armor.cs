namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class armor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        AC = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        DisStealth = c.Boolean(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "ArmorId", c => c.Byte(nullable: false));
            AddColumn("dbo.Characters", "Shield", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Characters", "ArmorId");
            AddForeignKey("dbo.Characters", "ArmorId", "dbo.Armors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ArmorId", "dbo.Armors");
            DropIndex("dbo.Characters", new[] { "ArmorId" });
            DropColumn("dbo.Characters", "Shield");
            DropColumn("dbo.Characters", "ArmorId");
            DropTable("dbo.Armors");
        }
    }
}
