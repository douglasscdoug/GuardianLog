﻿// <auto-generated />
using System;
using GuardianLog.Repo.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250406193755_AjusteIdCepEndereco")]
    partial class AjusteIdCepEndereco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GuardianLog.Domain.CEP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCidade")
                        .HasColumnType("int");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.ToTable("CEPs");
                });

            modelBuilder.Entity("GuardianLog.Domain.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CodCidadeIBGE")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("NomeCidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodCidadeIBGE")
                        .IsUnique();

                    b.HasIndex("IdEstado");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("GuardianLog.Domain.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<int?>("IdPessoaFisica")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("GuardianLog.Domain.Cor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Amarelo"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Azul"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Branco"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Cinza"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Dourado"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Laranja"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Marrom"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Prata"
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Preto"
                        },
                        new
                        {
                            Id = 10,
                            Nome = "Verde"
                        },
                        new
                        {
                            Id = 11,
                            Nome = "Vermelho"
                        },
                        new
                        {
                            Id = 12,
                            Nome = "Não informado"
                        });
                });

            modelBuilder.Entity("GuardianLog.Domain.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EhCliente")
                        .HasColumnType("bit");

                    b.Property<int>("IdContato")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoEmpresa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContato")
                        .IsUnique();

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("GuardianLog.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCep")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<int?>("IdPessoaFisica")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCep");

                    b.HasIndex("IdEmpresa")
                        .IsUnique()
                        .HasFilter("[IdEmpresa] IS NOT NULL");

                    b.HasIndex("IdPessoaFisica")
                        .IsUnique()
                        .HasFilter("[IdPessoaFisica] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GuardianLog.Domain.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodUFIBGE")
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("NomeEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("GuardianLog.Domain.MarcaVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MarcasVeiculos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Scania"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Volvo"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "DAF"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "MAN"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Renault"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Volkswagen"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Ford"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Iveco"
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("GuardianLog.Domain.ModeloVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdMarcaVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("NomeModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdMarcaVeiculo");

                    b.ToTable("ModelosVeiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.OrgaoEmissor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeInstituicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoOrgao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OrgaosEmissores");
                });

            modelBuilder.Entity("GuardianLog.Domain.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nacionalidade = "Brasileiro",
                            Nome = "Brasil"
                        },
                        new
                        {
                            Id = 2,
                            Nacionalidade = "Argentino",
                            Nome = "Argentina"
                        },
                        new
                        {
                            Id = 3,
                            Nacionalidade = "Chileno",
                            Nome = "Chile"
                        },
                        new
                        {
                            Id = 4,
                            Nacionalidade = "Uruguaio",
                            Nome = "Uruguai"
                        });
                });

            modelBuilder.Entity("GuardianLog.Domain.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEmissaoRG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("IdContato")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoRG")
                        .HasColumnType("int");

                    b.Property<int>("IdOrgaoEmissor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("IdContato")
                        .IsUnique();

                    b.HasIndex("IdOrgaoEmissor");

                    b.ToTable("PessoasFisicas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PessoaFisica");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GuardianLog.Domain.TecnologiaRastreamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TecnologiasRastreamento");
                });

            modelBuilder.Entity("GuardianLog.Domain.TipoCarreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposCarreta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Baú"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Baú Refrigerado"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Sider"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Tanque"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Graneleiro"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Prancha"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Bitrem"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Cegonha"
                        });
                });

            modelBuilder.Entity("GuardianLog.Domain.TipoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposVeiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Cavalo"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Carreta"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Truck"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Toco"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "VUC"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Automovel"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Onibus"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Utilitário"
                        });
                });

            modelBuilder.Entity("GuardianLog.Domain.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCidade")
                        .HasColumnType("int");

                    b.Property<int>("IdCor")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("int");

                    b.Property<int>("IdModeloVeiculo")
                        .HasColumnType("int");

                    b.Property<int>("IdTecnologia")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoCarreta")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoVinculo")
                        .HasColumnType("int");

                    b.Property<bool>("VeiculoInternacional")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdCor");

                    b.HasIndex("IdModeloVeiculo");

                    b.HasIndex("IdTecnologia");

                    b.HasIndex("IdTipoCarreta");

                    b.HasIndex("IdTipoVeiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.Motorista", b =>
                {
                    b.HasBaseType("GuardianLog.Domain.PessoaFisica");

                    b.Property<int>("CategoriaCNH")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEmissaoCNH")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimentoCNH")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroCNH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRegistroCNH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoVinculo")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Motorista");
                });

            modelBuilder.Entity("GuardianLog.Domain.CEP", b =>
                {
                    b.HasOne("GuardianLog.Domain.Cidade", "Cidade")
                        .WithMany("CEPs")
                        .HasForeignKey("IdCidade")
                        .HasPrincipalKey("CodCidadeIBGE")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("GuardianLog.Domain.Cidade", b =>
                {
                    b.HasOne("GuardianLog.Domain.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("GuardianLog.Domain.Empresa", b =>
                {
                    b.HasOne("GuardianLog.Domain.Contato", "Contato")
                        .WithOne("Empresa")
                        .HasForeignKey("GuardianLog.Domain.Empresa", "IdContato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("GuardianLog.Domain.Endereco", b =>
                {
                    b.HasOne("GuardianLog.Domain.CEP", "Cep")
                        .WithMany()
                        .HasForeignKey("IdCep")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.Empresa", "Empresa")
                        .WithOne("Endereco")
                        .HasForeignKey("GuardianLog.Domain.Endereco", "IdEmpresa");

                    b.HasOne("GuardianLog.Domain.PessoaFisica", "PessoaFisica")
                        .WithOne("Endereco")
                        .HasForeignKey("GuardianLog.Domain.Endereco", "IdPessoaFisica");

                    b.Navigation("Cep");

                    b.Navigation("Empresa");

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("GuardianLog.Domain.Estado", b =>
                {
                    b.HasOne("GuardianLog.Domain.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("GuardianLog.Domain.ModeloVeiculo", b =>
                {
                    b.HasOne("GuardianLog.Domain.MarcaVeiculo", "MarcaVeiculo")
                        .WithMany("Modelos")
                        .HasForeignKey("IdMarcaVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MarcaVeiculo");
                });

            modelBuilder.Entity("GuardianLog.Domain.PessoaFisica", b =>
                {
                    b.HasOne("GuardianLog.Domain.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.Contato", "Contato")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("GuardianLog.Domain.PessoaFisica", "IdContato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.OrgaoEmissor", "OrgaoEmissor")
                        .WithMany("PessoasFisicas")
                        .HasForeignKey("IdOrgaoEmissor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Estado");

                    b.Navigation("OrgaoEmissor");
                });

            modelBuilder.Entity("GuardianLog.Domain.Veiculo", b =>
                {
                    b.HasOne("GuardianLog.Domain.Cidade", "Cidade")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.Cor", "Cor")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdCor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.ModeloVeiculo", "ModeloVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdModeloVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.TecnologiaRastreamento", "Tecnologia")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdTecnologia")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GuardianLog.Domain.TipoCarreta", "TipoCarreta")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdTipoCarreta")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GuardianLog.Domain.TipoVeiculo", "TipoVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdTipoVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Cor");

                    b.Navigation("ModeloVeiculo");

                    b.Navigation("Tecnologia");

                    b.Navigation("TipoCarreta");

                    b.Navigation("TipoVeiculo");
                });

            modelBuilder.Entity("GuardianLog.Domain.Cidade", b =>
                {
                    b.Navigation("CEPs");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.Contato", b =>
                {
                    b.Navigation("Empresa");

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("GuardianLog.Domain.Cor", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.Empresa", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("GuardianLog.Domain.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("GuardianLog.Domain.MarcaVeiculo", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("GuardianLog.Domain.ModeloVeiculo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.OrgaoEmissor", b =>
                {
                    b.Navigation("PessoasFisicas");
                });

            modelBuilder.Entity("GuardianLog.Domain.Pais", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("GuardianLog.Domain.PessoaFisica", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("GuardianLog.Domain.TecnologiaRastreamento", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.TipoCarreta", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuardianLog.Domain.TipoVeiculo", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
