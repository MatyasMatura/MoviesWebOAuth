﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWebProjectOAuth.Data;

#nullable disable

namespace MoviesWebProjectOAuth.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220110183503_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541",
                            Email = "Josef.Pepik@pslib.cz",
                            Name = "Josef Pepík"
                        });
                });

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7f828843-819c-4369-8da8-e0e79d7777e8"),
                            Description = "Mafia",
                            Director = "Coppola",
                            Name = "GodFather",
                            Score = 96,
                            Year = 1972
                        },
                        new
                        {
                            Id = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            Description = "Mafia",
                            Director = "Coppola",
                            Name = "GodFather 2",
                            Score = 95,
                            Year = 1974
                        },
                        new
                        {
                            Id = new Guid("8016e254-973e-41f3-81d1-6648104272f8"),
                            Description = "Mafia",
                            Director = "Coppola",
                            Name = "GodFather 3",
                            Score = 80,
                            Year = 1990
                        },
                        new
                        {
                            Id = new Guid("891c93d7-8120-485b-80a7-f31691613a88"),
                            Description = "A movie about space and family. Beautiful soundtrack by Hans Zimmer",
                            Director = "Christopher Nolan",
                            Name = "Interstellar",
                            Score = 87,
                            Year = 2014
                        },
                        new
                        {
                            Id = new Guid("0c097024-f0b5-4dcf-8199-5363eb521898"),
                            Description = "Batman goes againts the joker",
                            Director = "Christopher Nolan",
                            Name = "The Dark Knight",
                            Score = 90,
                            Year = 2008
                        },
                        new
                        {
                            Id = new Guid("65025017-4b35-4ba1-be38-a7345a767ff6"),
                            Description = "film podle serialu",
                            Director = "Malinka",
                            Name = "Ulice",
                            Score = 17,
                            Year = 2025
                        },
                        new
                        {
                            Id = new Guid("09e31662-8924-4a4c-acea-d9bf28bd9a28"),
                            Description = "The Italian stallion goes boxing",
                            Director = "Sylvester Stallone",
                            Name = "Rocky",
                            Score = 87,
                            Year = 1976
                        },
                        new
                        {
                            Id = new Guid("29ca347f-cee5-4e2e-83b4-7c85935b21d2"),
                            Description = "Creepy priest",
                            Director = "Antonio Campos",
                            Name = "The Devil All the Time",
                            Score = 77,
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("c40774a0-e033-4971-8fae-d2550a251f50"),
                            Description = "Life in prison",
                            Director = "Frank Darabont",
                            Name = "The Shawshank Redemption",
                            Score = 97,
                            Year = 1994
                        },
                        new
                        {
                            Id = new Guid("335172cc-cd76-469a-aa93-48626b90b8fc"),
                            Description = "Mafia",
                            Director = "Martin Scorsese",
                            Name = "The Irishman",
                            Score = 75,
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("786f1c69-1377-46fa-8024-d013b47bc620"),
                            Description = "Comedy about scientists and people not believing them",
                            Director = "Adam McKay",
                            Name = "Dont look up",
                            Score = 76,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Liked")
                        .HasColumnType("bit");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5097415e-6486-46ba-a484-bffde5d02ae0"),
                            Author = "Josef Pepík",
                            Content = "Great Movie",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("760510bb-2398-4c23-8534-72efdebdad7c"),
                            Author = "Josef Pepík",
                            Content = "One of the best i have ever seen",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("14f4d436-96ba-4c51-80cd-b418eafa8074"),
                            Author = "Josef Pepík",
                            Content = "Not bad",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("0534bd02-9b58-4288-8e73-7ff90e9c8151"),
                            Author = "Josef Pepík",
                            Content = "Not my cup of tea",
                            Liked = false,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("f4116aeb-831b-466d-9c3b-e34366723dab"),
                            Author = "Josef Pepík",
                            Content = "Timeless classic!",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("bd438d69-1ce6-48e9-a58f-efcbefc3b969"),
                            Author = "Josef Pepík",
                            Content = "Enjoyed, but could have been way better. Too much death! Think of the children!!",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("9aaadae0-b3f3-4a55-ac53-348b1f809083"),
                            Author = "Josef Pepík",
                            Content = "Crazy good!!!",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("aa4af015-fa23-4698-9d61-ecc9ae90d7d4"),
                            Author = "Josef Pepík",
                            Content = "Amazing",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("92e598c2-028c-4884-8c69-e5060719cdaf"),
                            Author = "Josef Pepík",
                            Content = "WOW",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("b4028308-67ab-4b41-bd02-911f8e0c5fa7"),
                            Author = "Josef Pepík",
                            Content = "Really good",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("147e25d1-a6f5-4128-baa7-2e75a81ceeb9"),
                            Author = "Josef Pepík",
                            Content = "Enjoyed!",
                            Liked = true,
                            MovieId = new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        },
                        new
                        {
                            Id = new Guid("1a31f306-82e3-41de-b964-8558fbff9b13"),
                            Author = "Josef Pepík",
                            Content = "Enjoyed!",
                            Liked = true,
                            MovieId = new Guid("891c93d7-8120-485b-80a7-f31691613a88"),
                            UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541"
                        });
                });

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.Review", b =>
                {
                    b.HasOne("MoviesWebProjectOAuth.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebProjectOAuth.Models.AppUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.AppUser", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MoviesWebProjectOAuth.Models.Movie", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
