﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inlock_codeFirst.Context;

#nullable disable

namespace inlock_codeFirst.Migrations
{
    [DbContext(typeof(InLockContext))]
    partial class InLockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("inlock_codeFirst.Domains.EstudioDomain", b =>
                {
                    b.Property<Guid>("IdEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("IdEstudio");

                    b.ToTable("Estudio");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.JogoDomain", b =>
                {
                    b.Property<Guid>("IdJogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEstudio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("Decimal(4,2)");

                    b.HasKey("IdJogo");

                    b.HasIndex("IdEstudio");

                    b.ToTable("Jogo");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.TipoUsuarioDomain", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(170)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.UsuarioDomain", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.JogoDomain", b =>
                {
                    b.HasOne("inlock_codeFirst.Domains.EstudioDomain", "Estudio")
                        .WithMany("Jogo")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudio");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.UsuarioDomain", b =>
                {
                    b.HasOne("inlock_codeFirst.Domains.TipoUsuarioDomain", "TipoUsuario")
                        .WithMany("Usuario")
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.EstudioDomain", b =>
                {
                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("inlock_codeFirst.Domains.TipoUsuarioDomain", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
