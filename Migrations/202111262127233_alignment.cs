namespace dnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alignments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "AlignmentId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Characters", "AlignmentId");
            AddForeignKey("dbo.Characters", "AlignmentId", "dbo.Alignments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "AlignmentId", "dbo.Alignments");
            DropIndex("dbo.Characters", new[] { "AlignmentId" });
            DropColumn("dbo.Characters", "AlignmentId");
            DropTable("dbo.Alignments");
        }
    }
}
