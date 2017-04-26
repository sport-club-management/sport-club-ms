namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_data : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "ExpenseCategory_Id", "dbo.ExpenseCategories");
            DropIndex("dbo.Expenses", new[] { "ExpenseCategory_Id" });
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Expenses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name_French = c.String(),
                        Name_English = c.String(),
                        Name_Arab = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Reference = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        ExpenseCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name_French = c.String(),
                        Name_English = c.String(),
                        Name_Arab = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Reference = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Expenses", "ExpenseCategory_Id");
            AddForeignKey("dbo.Expenses", "ExpenseCategory_Id", "dbo.ExpenseCategories", "Id");
        }
    }
}
