using Microsoft.EntityFrameworkCore;
using PostgresGpt.ApiService.Models;

namespace PostgresGpt.ApiService.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("vector");

            //modelBuilder.Entity<Item>()
            //    .HasIndex(i => i.Embedding)
            //    .HasMethod("hnsw")
            //    .HasOperators("vector_l2_ops")
            //    .HasStorageParameter("m", 16)
            //    .HasStorageParameter("ef_construction", 64);

            modelBuilder.Entity<CacheItem>()
                .HasIndex(i => i.Embeddings)
                .HasMethod("hnsw")
                .HasOperators("vector_l2_ops")
                .HasStorageParameter("m", 16)
                .HasStorageParameter("ef_construction", 64);
        }

        //public DbSet<Item> Items { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CacheItem> Cache { get; set; }
    }
}
