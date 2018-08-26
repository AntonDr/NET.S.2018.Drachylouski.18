namespace ORM.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ORM.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ORM.EntityContext";
        }

        protected override void Seed(ORM.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.AccountHolders.AddOrUpdate(ah => new { ah.Email, ah.FirstName, ah.LastName, ah.Accounts });
            context.Accounts.AddOrUpdate(a => new {a.AccountID,a.AccountStatus,a.AccountType,a.Balance,a.BonsuPoint});

        }
    }
}
