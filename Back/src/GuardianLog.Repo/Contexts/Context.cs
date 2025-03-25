using GuardianLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
   public DbSet<Cidade> Cidades { get; set; }
   public DbSet<Cor> Cores { get; set; }
   public DbSet<Estado> Estados { get; set; }
   public DbSet<MarcaVeiculo> MarcasVeiculos { get; set; }
   public DbSet<ModeloVeiculo> ModelosVeiculos { get; set; }
   public DbSet<Pais> Paises { get; set; }
   public DbSet<TecnologiaRastreamento> TecnologiasRastreamento { get; set; }
   public DbSet<TipoCarreta> TiposCarreta { get; set; }
   public DbSet<TipoVeiculo> TiposVeiculo { get; set; }
   public DbSet<Veiculo> Veiculos { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
        modelBuilder.Entity<Cidade>(
         cidade => {
            cidade.HasOne(c => c.Estado)
            .WithMany(e => e.Cidades)
            .HasForeignKey(c => c.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);
         }
        );

        modelBuilder.Entity<Cor>(
         cor => {
            cor.HasData(
               new Cor{Id = 1, Nome = "Amarelo"},
               new Cor{Id = 2, Nome = "Azul"},
               new Cor{Id = 3, Nome = "Branco"},
               new Cor{Id = 4, Nome = "Cinza"},
               new Cor{Id = 5, Nome = "Dourado"},
               new Cor{Id = 6, Nome = "Laranja"},
               new Cor{Id = 7, Nome = "Marrom"},
               new Cor{Id = 8, Nome = "Prata"},
               new Cor{Id = 9, Nome = "Preto"},
               new Cor{Id = 10, Nome = "Verde"},
               new Cor{Id = 11, Nome = "Vermelho"},
               new Cor{Id = 12, Nome = "Não informado"}
            );
         }
        );

        modelBuilder.Entity<Estado>(
         estado => {
            estado.HasOne(e => e.Pais)
            .WithMany(p => p.Estados)
            .HasForeignKey(e => e.IdPais)
            .OnDelete(DeleteBehavior.Restrict);
         }
        );

        modelBuilder.Entity<MarcaVeiculo>(
         marca => {
            marca.HasData(
               new MarcaVeiculo{Id = 1, Nome = "Scania", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 2, Nome = "Volvo", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 3, Nome = "DAF", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 4, Nome = "MAN", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 5, Nome = "Renault", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 6, Nome = "Volkswagen", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 7, Nome = "Ford", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 8, Nome = "Iveco", DataCadastro = DateTime.Now},
               new MarcaVeiculo{Id = 9, Nome = "Mercedes-Benz", DataCadastro = DateTime.Now}
            );
         }
        );

        modelBuilder.Entity<ModeloVeiculo>(
         modelo => {
            modelo.HasOne(m => m.MarcaVeiculo)
            .WithMany(m => m.Modelos)
            .HasForeignKey(m => m.IdMarcaVeiculo )
            .OnDelete(DeleteBehavior.Restrict);
         }
        );

        modelBuilder.Entity<Pais>(
         pais => {
            pais.HasData(
               new Pais{Id = 1, Nome = "Brasil"},
               new Pais{Id = 2, Nome = "Argentina"},
               new Pais{Id = 3, Nome = "Chile"},
               new Pais{Id = 4, Nome = "Uruguai"}
            );
         }
        );

        modelBuilder.Entity<TipoCarreta>(
         carreta => {
            carreta.HasData(
               new TipoCarreta{Id = 1, Nome = "Baú", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 2, Nome = "Baú Refrigerado", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 3, Nome = "Sider", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 4, Nome = "Tanque", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 5, Nome = "Graneleiro", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 6, Nome = "Prancha", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 7, Nome = "Bitrem", DataCadastro = DateTime.Now},
               new TipoCarreta{Id = 8, Nome = "Cegonha", DataCadastro = DateTime.Now}
            );
         }
        );

        modelBuilder.Entity<TipoVeiculo>(
         tpVeiculo => {
            tpVeiculo.HasData(
               new TipoVeiculo{Id = 1, Nome = "Cavalo", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 2, Nome = "Carreta", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 3, Nome = "Truck", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 4, Nome = "Toco", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 5, Nome = "VUC", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 6, Nome = "Automovel", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 7, Nome = "Onibus", DataCadastro = DateTime.Now},
               new TipoVeiculo{Id = 8, Nome = "Utilitário", DataCadastro = DateTime.Now}
            );
         }
        );

        modelBuilder.Entity<Veiculo>(
         veiculo => {
            veiculo.HasOne(v => v.TipoVeiculo)
            .WithMany(tv => tv.Veiculos)
            .HasForeignKey(v => v.IdTipoVeiculo)
            .OnDelete(DeleteBehavior.Restrict);

            veiculo.HasOne(v => v.TipoCarreta)
            .WithMany(tc => tc.Veiculos)
            .HasForeignKey(v => v.IdTipoCarreta)
            .OnDelete(DeleteBehavior.Restrict);

            veiculo.HasOne(v => v.ModeloVeiculo)
            .WithMany(mv => mv.Veiculos)
            .HasForeignKey(v => v.IdModeloVeiculo)
            .OnDelete(DeleteBehavior.Restrict);

            veiculo.HasOne(v => v.Cor)
            .WithMany(c => c.Veiculos)
            .HasForeignKey(v => v.IdCor)
            .OnDelete(DeleteBehavior.Restrict);

            veiculo.HasOne(v => v.Cidade)
            .WithMany(c => c.Veiculos)
            .HasForeignKey(v => v.IdCidade)
            .OnDelete(DeleteBehavior.Restrict);

            veiculo.HasOne(v => v.Tecnologia)
            .WithMany(t => t.Veiculos)
            .HasForeignKey(v => v.IdTecnologia)
            .OnDelete(DeleteBehavior.Restrict);
         }
        );
   }
}
