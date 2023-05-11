using Microsoft.EntityFrameworkCore;
using wa_api_ta_azure_02.Models;

namespace wa_api_ta_azure_02.Data
{
     public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}