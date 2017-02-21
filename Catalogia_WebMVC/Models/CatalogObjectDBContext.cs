
using System.Data.Entity;


namespace Catalogia_WebMVC.Models
{
    public class CatalogObjectDBContext : DbContext
    {
        public DbSet<CatalogObject> CatalogObjects { get; set; }
    }
}