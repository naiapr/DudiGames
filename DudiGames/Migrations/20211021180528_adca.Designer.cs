﻿// <auto-generated />
using System;
using DudiGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DudiGames.Migrations
{
    [DbContext(typeof(DudiGamesContext))]
    [Migration("20211021180528_adca")]
    partial class adca
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DudiGames.Models.Capital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CapitaldeGiro")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Capital");
                });

            modelBuilder.Entity("DudiGames.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DudiGames.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CapitalGiro")
                        .HasColumnType("double");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("SaldoCapital")
                        .HasColumnType("double");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("double");

                    b.Property<int?>("capitalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("capitalId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("DudiGames.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("DudiGames.Models.Financeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CapitalGiro")
                        .HasColumnType("int");

                    b.Property<int>("CapitalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double");

                    b.Property<double>("PrecoVenda")
                        .HasColumnType("double");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CapitalId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("DudiGames.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("DudiGames.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("DudiGames.Models.Compra", b =>
                {
                    b.HasOne("DudiGames.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DudiGames.Models.Capital", "capital")
                        .WithMany()
                        .HasForeignKey("capitalId");
                });

            modelBuilder.Entity("DudiGames.Models.Estoque", b =>
                {
                    b.HasOne("DudiGames.Models.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId");

                    b.HasOne("DudiGames.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DudiGames.Models.Financeiro", b =>
                {
                    b.HasOne("DudiGames.Models.Capital", "caital")
                        .WithMany()
                        .HasForeignKey("CapitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DudiGames.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DudiGames.Models.Pedido", b =>
                {
                    b.HasOne("DudiGames.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DudiGames.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
