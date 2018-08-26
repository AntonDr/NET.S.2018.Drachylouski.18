namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Accounts", name: "AccountHolder_AccountHolderId", newName: "AccountHolderId");
            RenameIndex(table: "dbo.Accounts", name: "IX_AccountHolder_AccountHolderId", newName: "IX_AccountHolderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Accounts", name: "IX_AccountHolderId", newName: "IX_AccountHolder_AccountHolderId");
            RenameColumn(table: "dbo.Accounts", name: "AccountHolderId", newName: "AccountHolder_AccountHolderId");
        }
    }
}
