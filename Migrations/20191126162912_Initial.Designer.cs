﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Models;

namespace Sample.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191126162912_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sample.Models.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.Property<string>("BookTitle")
                        .IsRequired();

                    b.Property<int>("ISBN");

                    b.Property<int>("Quantity");

                    b.Property<string>("Review");

                    b.HasKey("bookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Sample.Models.CartItem", b =>
                {
                    b.Property<int>("cartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<string>("AuthorName");

                    b.Property<string>("BookTitle");

                    b.Property<int>("ISBN");

                    b.Property<int>("Quantity");

                    b.Property<int>("bookId");

                    b.HasKey("cartItemId");

                    b.ToTable("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}