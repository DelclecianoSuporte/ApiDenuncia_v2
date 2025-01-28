﻿// <auto-generated />
using System;
using ApiDenuncia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiDenuncia.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250127143348_AdicionarImagens")]
    partial class AdicionarImagens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiDenuncia.Models.Denuncia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataHora_Resposta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Protocolo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<long>("Numero_Protocolo")
                        .HasColumnType("bigint");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("ApiDenuncia.Models.Imagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("DenunciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DenunciaId");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("ApiDenuncia.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ApiDenuncia.Models.Imagem", b =>
                {
                    b.HasOne("ApiDenuncia.Models.Denuncia", "Denuncia")
                        .WithMany("Imagens")
                        .HasForeignKey("DenunciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Denuncia");
                });

            modelBuilder.Entity("ApiDenuncia.Models.Denuncia", b =>
                {
                    b.Navigation("Imagens");
                });
#pragma warning restore 612, 618
        }
    }
}
