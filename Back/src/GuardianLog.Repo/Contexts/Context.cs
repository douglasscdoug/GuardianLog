using GuardianLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{  
   public DbSet<Cidade> Cidades { get; set; }
   public DbSet<Contato> Contatos { get; set; }
   public DbSet<Cor> Cores { get; set; }
   public DbSet<Empresa> Empresas { get; set; }
   public DbSet<Endereco> Enderecos { get; set; }
   public DbSet<Estado> Estados { get; set; }
   public DbSet<MarcaVeiculo> MarcasVeiculos { get; set; }
   public DbSet<ModeloVeiculo> ModelosVeiculos { get; set; }
   public DbSet<Motorista> Motoristas { get; set; }
   public DbSet<OrgaoEmissor> OrgaosEmissores { get; set; }
   public DbSet<Pais> Paises { get; set; }
   public DbSet<PessoaFisica> PessoasFisicas { get; set; }
   public DbSet<TecnologiaRastreamento> TecnologiasRastreamento { get; set; }
   public DbSet<TipoCarreta> TiposCarreta { get; set; }
   public DbSet<TipoVeiculo> TiposVeiculo { get; set; }
   public DbSet<Veiculo> Veiculos { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Cidade>(
         cidade =>
         {
            cidade.HasOne(c => c.Estado)
            .WithMany(e => e.Cidades)
            .HasForeignKey(c => c.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);

            cidade.HasIndex(c => c.CodCidadeIBGE)
            .IsUnique();
         }
      );

      modelBuilder.Entity<Contato>(
         contato =>
         {
            contato.HasOne(c => c.Empresa)
            .WithOne(e => e.Contato)
            .HasForeignKey<Contato>(c => c.IdEmpresa);

            contato.HasOne(c => c.PessoaFisica)
            .WithOne(p => p.Contato)
            .HasForeignKey<Contato>(c => c.IdPessoaFisica)
            .OnDelete(DeleteBehavior.Restrict);
         }
      );

      modelBuilder.Entity<Cor>(
         cor =>
         {
            cor.HasData(
               new Cor { Id = 1, Nome = "Amarelo" },
               new Cor { Id = 2, Nome = "Azul" },
               new Cor { Id = 3, Nome = "Branco" },
               new Cor { Id = 4, Nome = "Cinza" },
               new Cor { Id = 5, Nome = "Dourado" },
               new Cor { Id = 6, Nome = "Laranja" },
               new Cor { Id = 7, Nome = "Marrom" },
               new Cor { Id = 8, Nome = "Prata" },
               new Cor { Id = 9, Nome = "Preto" },
               new Cor { Id = 10, Nome = "Verde" },
               new Cor { Id = 11, Nome = "Vermelho" },
               new Cor { Id = 12, Nome = "Não informado" }
            );
         }
      );

      modelBuilder.Entity<Empresa>(
         empresa =>
         {
            empresa.HasOne(e => e.Endereco)
            .WithOne(e => e.Empresa)
            .HasForeignKey<Endereco>(e => e.IdEmpresa);

            empresa.HasOne(e => e.Contato)
            .WithOne(c => c.Empresa)
            .HasForeignKey<Contato>(c => c.IdEmpresa);
         }
      );

      modelBuilder.Entity<Endereco>(
         endereco =>
         {
            endereco.HasOne(e => e.Cidade)
            .WithMany(c => c.Enderecos)
            .HasForeignKey(e => e.IdCidade)
            .OnDelete(DeleteBehavior.Restrict);

            endereco.HasOne(e => e.Empresa)
            .WithOne(e => e.Endereco)
            .HasForeignKey<Endereco>(e => e.IdEmpresa)
            .OnDelete(DeleteBehavior.Restrict);

            endereco.HasOne(e => e.PessoaFisica)
            .WithOne(p => p.Endereco)
            .HasForeignKey<Endereco>(e => e.IdPessoaFisica)
            .OnDelete(DeleteBehavior.Restrict);
         }
      );

      modelBuilder.Entity<Estado>(
         estado =>
         {
            estado.HasOne(e => e.Pais)
            .WithMany(p => p.Estados)
            .HasForeignKey(e => e.IdPais)
            .OnDelete(DeleteBehavior.Restrict);
         }
      );

      modelBuilder.Entity<MarcaVeiculo>(
         marca =>
         {
            marca.HasData(
               new MarcaVeiculo { Id = 1, Nome = "Scania" },
               new MarcaVeiculo { Id = 2, Nome = "Volvo" },
               new MarcaVeiculo { Id = 3, Nome = "DAF" },
               new MarcaVeiculo { Id = 4, Nome = "MAN" },
               new MarcaVeiculo { Id = 5, Nome = "Renault" },
               new MarcaVeiculo { Id = 6, Nome = "Volkswagen" },
               new MarcaVeiculo { Id = 7, Nome = "Ford" },
               new MarcaVeiculo { Id = 8, Nome = "Iveco" },
               new MarcaVeiculo { Id = 9, Nome = "Mercedes-Benz" }
            );
         }
      );

      modelBuilder.Entity<ModeloVeiculo>(
         modelo =>
         {
            modelo.HasOne(m => m.MarcaVeiculo)
            .WithMany(m => m.Modelos)
            .HasForeignKey(m => m.IdMarcaVeiculo)
            .OnDelete(DeleteBehavior.Restrict);
         }
      );

      modelBuilder.Entity<Motorista>(
         motorista =>
         {
            motorista.ToTable("Motoristas");
         }
      );

      modelBuilder.Entity<Pais>(
         pais =>
         {
            pais.HasData(
               new Pais { Id = 1, Nome = "Brasil", Nacionalidade = "Brasileiro" },
               new Pais { Id = 2, Nome = "Argentina", Nacionalidade = "Argentino" },
               new Pais { Id = 3, Nome = "Chile", Nacionalidade = "Chileno" },
               new Pais { Id = 4, Nome = "Uruguai", Nacionalidade = "Uruguaio" }
            );
         }
      );

      modelBuilder.Entity<PessoaFisica>(
         pessoaFisica =>
         {
            pessoaFisica.HasOne(p => p.OrgaoEmissor)
            .WithMany(o => o.PessoasFisicas)
            .HasForeignKey(p => p.IdOrgaoEmissor)
            .OnDelete(DeleteBehavior.Restrict);

            pessoaFisica.HasOne(p => p.Contato)
            .WithOne(c => c.PessoaFisica);

            pessoaFisica.HasOne(p => p.Estado)
            .WithMany(e => e.PessoasFisicas)
            .HasForeignKey(p => p.IdEstadoRG)
            .OnDelete(DeleteBehavior.Restrict);

            pessoaFisica.ToTable("PessoasFisicas");
         }
      );

      modelBuilder.Entity<TipoCarreta>(
         carreta =>
         {
            carreta.HasData(
               new TipoCarreta { Id = 1, Nome = "Baú" },
               new TipoCarreta { Id = 2, Nome = "Baú Refrigerado" },
               new TipoCarreta { Id = 3, Nome = "Sider" },
               new TipoCarreta { Id = 4, Nome = "Tanque" },
               new TipoCarreta { Id = 5, Nome = "Graneleiro" },
               new TipoCarreta { Id = 6, Nome = "Prancha" },
               new TipoCarreta { Id = 7, Nome = "Bitrem" },
               new TipoCarreta { Id = 8, Nome = "Cegonha" }
            );
         }
      );

      modelBuilder.Entity<TipoVeiculo>(
         tpVeiculo =>
         {
            tpVeiculo.HasData(
               new TipoVeiculo { Id = 1, Nome = "Cavalo" },
               new TipoVeiculo { Id = 2, Nome = "Carreta" },
               new TipoVeiculo { Id = 3, Nome = "Truck" },
               new TipoVeiculo { Id = 4, Nome = "Toco" },
               new TipoVeiculo { Id = 5, Nome = "VUC" },
               new TipoVeiculo { Id = 6, Nome = "Automovel" },
               new TipoVeiculo { Id = 7, Nome = "Onibus" },
               new TipoVeiculo { Id = 8, Nome = "Utilitário" }
            );
         }
      );

      modelBuilder.Entity<Veiculo>(
         veiculo =>
         {
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