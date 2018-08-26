namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountHolders",
                c => new
                    {
                        AccountHolderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountType = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                        BonsuPoint = c.Int(nullable: false),
                        AccountHolder_AccountHolderId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolder_AccountHolderId)
                .Index(t => t.AccountHolder_AccountHolderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountHolder_AccountHolderId", "dbo.AccountHolders");
            DropIndex("dbo.Accounts", new[] { "AccountHolder_AccountHolderId" });
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountHolders");
        }
    }
}
