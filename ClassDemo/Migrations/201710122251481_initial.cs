namespace ClassDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.trackeritem",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ItemSummary = c.String(),
                        ItemCreatedDate = c.String(),
                        AssignedDate = c.String(),
                        ItemEndDate = c.String(),
                        WorkCompleted = c.String(),
                        CreatedBy = c.String(),
                        Owner = c.String(),
                        Impact = c.String(),
                        Resolution = c.String(),
                        ResolvedDate = c.String(),
                        AttachmentPath = c.String(),
                        ParentId = c.Int(nullable: false),
                        AssignedTo = c.String(),
                        Subjet = c.String(),
                        ItemProjectId = c.Int(nullable: false),
                        ItemCategoryId = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        ItemPriorityId = c.Int(nullable: false),
                        ItemStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ItemPriority", t => t.ItemPriorityId, cascadeDelete: true)
                .ForeignKey("dbo.itemStatus", t => t.ItemStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ItemType", t => t.ItemTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ItemProjectId, cascadeDelete: true)
                .Index(t => t.ItemProjectId)
                .Index(t => t.ItemCategoryId)
                .Index(t => t.ItemTypeId)
                .Index(t => t.ItemPriorityId)
                .Index(t => t.ItemStatusId);
            
            CreateTable(
                "dbo.ItemPriority",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        PriorityName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PriorityId);
            
            CreateTable(
                "dbo.itemStatus",
                c => new
                    {
                        ItemStatusId = c.Int(nullable: false, identity: true),
                        ItemStatusName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ItemStatusId);
            
            CreateTable(
                "dbo.ItemType",
                c => new
                    {
                        ItemTypeId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Registration",
                c => new
                    {
                        RegId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(),
                        SurName = c.String(),
                        Gender = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                        EmailId = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registration", "RoleId", "dbo.Role");
            DropForeignKey("dbo.trackeritem", "ItemProjectId", "dbo.Project");
            DropForeignKey("dbo.trackeritem", "ItemTypeId", "dbo.ItemType");
            DropForeignKey("dbo.trackeritem", "ItemStatusId", "dbo.itemStatus");
            DropForeignKey("dbo.trackeritem", "ItemPriorityId", "dbo.ItemPriority");
            DropForeignKey("dbo.trackeritem", "ItemCategoryId", "dbo.ItemCategory");
            DropIndex("dbo.Registration", new[] { "RoleId" });
            DropIndex("dbo.trackeritem", new[] { "ItemStatusId" });
            DropIndex("dbo.trackeritem", new[] { "ItemPriorityId" });
            DropIndex("dbo.trackeritem", new[] { "ItemTypeId" });
            DropIndex("dbo.trackeritem", new[] { "ItemCategoryId" });
            DropIndex("dbo.trackeritem", new[] { "ItemProjectId" });
            DropTable("dbo.Role");
            DropTable("dbo.Registration");
            DropTable("dbo.Project");
            DropTable("dbo.ItemType");
            DropTable("dbo.itemStatus");
            DropTable("dbo.ItemPriority");
            DropTable("dbo.trackeritem");
            DropTable("dbo.ItemCategory");
        }
    }
}
