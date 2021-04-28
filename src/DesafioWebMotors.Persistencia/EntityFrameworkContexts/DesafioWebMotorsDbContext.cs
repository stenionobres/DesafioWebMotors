using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DesafioWebMotors.Persistence.DataTransferObjects;

namespace DesafioWebMotors.Persistence.EntityFrameworkContexts
{
    public class DesafioWebMotorsDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.0.13,22331;Database=teste_webmotors;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        public static readonly ILoggerFactory LoggerFactoryToConsole = LoggerFactory.Create(builder => builder.AddConsole());

        public DbSet<AnuncioWebMotors> AnuncioWebMotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.UseLoggerFactory(LoggerFactoryToConsole);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuncioWebMotors>(entity =>
            {
                entity.ToTable("tb_AnuncioWebmotors");
                entity.Property(e => e.Id).HasColumnName("ID").IsRequired();
                entity.Property(e => e.Marca).HasColumnName("marca").HasMaxLength(45).IsRequired();
                entity.Property(e => e.Modelo).HasColumnName("modelo").HasMaxLength(45).IsRequired();
                entity.Property(e => e.Versao).HasColumnName("versao").HasMaxLength(45).IsRequired();
                entity.Property(e => e.Ano).HasColumnName("ano").IsRequired();
                entity.Property(e => e.Quilometragem).HasColumnName("quilometragem").IsRequired();
                entity.Property(e => e.Observacao).HasColumnName("observacao").IsRequired();
            });
        }
    }
}
