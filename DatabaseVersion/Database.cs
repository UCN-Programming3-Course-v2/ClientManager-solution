using DbUp;
using System.Reflection;

namespace DatabaseVersion
{
    public static class Database
    {
        public static void Upgrade(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrade = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetAssembly(typeof(Database)))
                .Build();

            upgrade.PerformUpgrade();
        }

        public static void Drop(string connectionString)
        {
            DropDatabase.For.SqlDatabase(connectionString);
        }
    }
}
