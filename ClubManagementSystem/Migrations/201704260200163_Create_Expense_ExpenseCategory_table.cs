namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Expense_ExpenseCategory_table : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategory_Id)
                .Index(t => t.ExpenseCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ExpenseCategory_Id", "dbo.ExpenseCategories");
            DropIndex("dbo.Expenses", new[] { "ExpenseCategory_Id" });
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
