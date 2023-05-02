﻿using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context;

public class AppDbContext : DbContext
{
    /*Esta classe de context é lido pelo EFCore no momento do migrations para criar o banco de dados, tabelas, mapeamento
     * 
     * OnModelCreating: No momento da criação das tabelas preencher tabelas com informações com o HasData
     * HasData: Permite alimentar com dados no momento da migração se a tabelas estiver vazia
    */
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //Definicao o mapeamento das entidades utilizando DbSet e o Name das Tabelas
    public DbSet<Cart>? Carts { get; set; }
    public DbSet<CartItem>? CartItems { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<User>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Products
        //Beleza Category
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Glossier - Beleza Kit",
            Description = "Um kit fornecido pela Natura, contendo Products para cuidados com a pele",
            ImageUrl = "/Imagens/Beleza/Beleza1.png",
            Price = 100,
            Qtd = 100,
            CategoryId = 1

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "Curology - Kit para Pele",
            Description = "Um kit fornecido pela Curology, contendo Products para cuidados com a pele",
            ImageUrl = "/Imagens/Beleza/Beleza2.png",
            Price = 50,
            Qtd = 45,
            CategoryId = 1

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "Óleo de Coco Orgânico",
            Description = "Um kit fornecido pela Glossier, contendo Products para cuidados com a pele",
            ImageUrl = "/Imagens/Beleza/Beleza3.png",
            Price = 20,
            Qtd = 30,
            CategoryId = 1

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "Schwarzkopf - Kit de cuidados com a pele e cabelo",
            Description = "Um kit fornecido pela Curology, contendo Products para cuidados com a pele",
            ImageUrl = "/Imagens/Beleza/Beleza4.png",
            Price = 50,
            Qtd = 60,
            CategoryId = 1

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 5,
            Name = "Kit de cuidados com a pele",
            Description = "Kit de cuidados com a pele, contendo Products para cuidados com a pele e cabelos",
            ImageUrl = "/Imagens/Beleza/Beleza5.png",
            Price = 30,
            Qtd = 85,
            CategoryId = 1

        });
        //eletronico Category
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 6,
            Name = "Fones de ouvidos",
            Description = "Air Pods - fones de ouvido sem fio intra-auriculares",
            ImageUrl = "/Imagens/Eletronicos/eletronico1.png",
            Price = 100,
            Qtd = 120,
            CategoryId = 3

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 7,
            Name = "Fones de ouvido dourados",
            Description = "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio",
            ImageUrl = "/Imagens/Eletronicos/eletronico2.png",
            Price = 40,
            Qtd = 200,
            CategoryId = 3

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 8,
            Name = "Fones de ouvido pretos",
            Description = "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio",
            ImageUrl = "/Imagens/Eletronicos/eletronico3.png",
            Price = 40,
            Qtd = 300,
            CategoryId = 3

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 9,
            Name = "Câmera digital Sennheiser com tripé",
            Description = "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé",
            ImageUrl = "/Imagens/Eletronicos/eletronico4.png",
            Price = 600,
            Qtd = 20,
            CategoryId = 3

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 10,
            Name = "Câmera Digital Canon",
            Description = "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon",
            ImageUrl = "/Imagens/Eletronicos/eletronico5.png",
            Price = 500,
            Qtd = 15,
            CategoryId = 3

        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 11,
            Name = "Nintendo Gameboy",
            Description = "Gameboy - Fornecido por Nintendo",
            ImageUrl = "/Imagens/Eletronicos/tecnologia6.png",
            Price = 100,
            Qtd = 60,
            CategoryId = 3
        });
        //Moveis Category
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 12,
            Name = "Cadeira de escritório de couro preto",
            Description = "Cadeira de escritório em couro preto muito confortável",
            ImageUrl = "/Imagens/Moveis/moveis1.png",
            Price = 50,
            Qtd = 212,
            CategoryId = 2
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 13,
            Name = "Cadeira de escritório de couro rosa",
            Description = "Cadeira de escritório em couro rosa muito confortável",
            ImageUrl = "/Imagens/Moveis/moveis2.png",
            Price = 50,
            Qtd = 112,
            CategoryId = 2
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 14,
            Name = "Espreguiçadeira",
            Description = "Poltrona muito confortável",
            ImageUrl = "/Imagens/Moveis/moveis3.png",
            Price = 70,
            Qtd = 90,
            CategoryId = 2
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 15,
            Name = "Silver Lounge Chair",
            Description = "Poltrona prateada muito confortável",
            ImageUrl = "/Imagens/Moveis/moveis4.png",
            Price = 120,
            Qtd = 95,
            CategoryId = 2
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 16,
            Name = "Luminária de mesa de porcelana",
            Description = "Abajur de mesa de porcelana branco e azul",
            ImageUrl = "/Imagens/Moveis/moveis6.png",
            Price = 15,
            Qtd = 100,
            CategoryId = 2
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 17,
            Name = "Office Table Lamp",
            Description = "Abajur de mesa de escritório",
            ImageUrl = "/Imagens/Moveis/moveis7.png",
            Price = 20,
            Qtd = 73,
            CategoryId = 2
        });
        //Calcados Category
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 18,
            Name = "Tênis Puma",
            Description = "Tênis Puma confortáveis na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado1.png",
            Price = 100,
            Qtd = 50,
            CategoryId = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 19,
            Name = "Tênis Colodiros",
            Description = "Tênis coloridos - disponíveis na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado2.png",
            Price = 150,
            Qtd = 60,
            CategoryId = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 20,
            Name = "Tênis Nike Azul",
            Description = "Tênis Nike azul - disponível na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado3.png",
            Price = 200,
            Qtd = 70,
            CategoryId = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 21,
            Name = "Tênis Hummel Coloridos",
            Description = "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado4.png",
            Price = 120,
            Qtd = 120,
            CategoryId = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 22,
            Name = "Tênis Nike Vermelho",
            Description = "Tênis Nike vermelho - disponível na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado5.png",
            Price = 200,
            Qtd = 100,
            CategoryId = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 23,
            Name = "Sandálidas Birkenstock",
            Description = "Sandálias Birkenstock - disponíveis na maioria dos tamanhos",
            ImageUrl = "/Imagens/Calcados/calcado6.png",
            Price = 50,
            Qtd = 150,
            CategoryId = 4
        });

        //Add users
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            UserName = "Igo"

        });
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 2,
            UserName = "Fulano"

        });

        //Create Shopping Cart for Users
        modelBuilder.Entity<Cart>().HasData(new Cart
        {
            Id = 1,
            UserId = 1

        });
        modelBuilder.Entity<Cart>().HasData(new Cart
        {
            Id = 2,
            UserId = 2

        });
        //Add Product Categories
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            Name = "Beleza",
            IconCSS = "fas fa-spa"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            Name = "Moveis",
            IconCSS = "fas fa-couch"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 3,
            Name = "Eletronicos",
            IconCSS = "fas fa-headphones"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 4,
            Name = "Calcados",
            IconCSS = "fas fa-shoe-prints"
        });
    }

}