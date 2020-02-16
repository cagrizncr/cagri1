using System.Data.Entity;

namespace SigortamNetProject.Context
{
    public class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

        }
    }
}