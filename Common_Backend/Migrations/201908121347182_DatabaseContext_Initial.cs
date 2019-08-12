namespace Common_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItemEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubItemEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MenuItemEntity_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuItemEntities", t => t.MenuItemEntity_ID)
                .Index(t => t.MenuItemEntity_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubItemEntities", "MenuItemEntity_ID", "dbo.MenuItemEntities");
            DropIndex("dbo.SubItemEntities", new[] { "MenuItemEntity_ID" });
            DropTable("dbo.SubItemEntities");
            DropTable("dbo.MenuItemEntities");
        }
    }
}
