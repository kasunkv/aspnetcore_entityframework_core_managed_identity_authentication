// <auto-generated />
using AspNetCore.CRUD.Example.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCore.CRUD.Example.Data.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    [Migration("20230103201308_AddedAuthor")]
    partial class AddedAuthor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspNetCore.CRUD.Example.Models.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "DevOps",
                            Name = "Gean Kim"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Frontend",
                            Name = "Cory House"
                        });
                });

            modelBuilder.Entity("AspNetCore.CRUD.Example.Models.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Gean Kim",
                            ISBN = "0988262592",
                            Title = "The Phoenix Project"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Gean Kim",
                            ISBN = "1942788762",
                            Title = "The Unicorn Project"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Gean Kim",
                            ISBN = "1942788002",
                            Title = "The DevOps Handbook"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
