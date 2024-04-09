using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebProjectOAuth.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Name", "Score", "Year" },
                values: new object[,]
                {
                    { new Guid("09e31662-8924-4a4c-acea-d9bf28bd9a28"), "The Italian stallion goes boxing", "Sylvester Stallone", "Rocky", 87, 1976 },
                    { new Guid("0c097024-f0b5-4dcf-8199-5363eb521898"), "Batman goes againts the joker", "Christopher Nolan", "The Dark Knight", 90, 2008 },
                    { new Guid("29ca347f-cee5-4e2e-83b4-7c85935b21d2"), "Creepy priest", "Antonio Campos", "The Devil All the Time", 77, 2020 },
                    { new Guid("335172cc-cd76-469a-aa93-48626b90b8fc"), "Mafia", "Martin Scorsese", "The Irishman", 75, 2019 },
                    { new Guid("65025017-4b35-4ba1-be38-a7345a767ff6"), "film podle serialu", "Malinka", "Ulice", 17, 2025 },
                    { new Guid("786f1c69-1377-46fa-8024-d013b47bc620"), "Comedy about scientists and people not believing them", "Adam McKay", "Dont look up", 76, 2021 },
                    { new Guid("7f828843-819c-4369-8da8-e0e79d7777e8"), "Mafia", "Coppola", "GodFather", 96, 1972 },
                    { new Guid("8016e254-973e-41f3-81d1-6648104272f8"), "Mafia", "Coppola", "GodFather 3", 80, 1990 },
                    { new Guid("891c93d7-8120-485b-80a7-f31691613a88"), "A movie about space and family. Beautiful soundtrack by Hans Zimmer", "Christopher Nolan", "Interstellar", 87, 2014 },
                    { new Guid("c40774a0-e033-4971-8fae-d2550a251f50"), "Life in prison", "Frank Darabont", "The Shawshank Redemption", 97, 1994 },
                    { new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "Mafia", "Coppola", "GodFather 2", 95, 1974 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", "Josef.Pepik@pslib.cz", "Josef Pepík" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Author", "Content", "Liked", "MovieId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0534bd02-9b58-4288-8e73-7ff90e9c8151"), "Josef Pepík", "Not my cup of tea", false, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("147e25d1-a6f5-4128-baa7-2e75a81ceeb9"), "Josef Pepík", "Enjoyed!", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("14f4d436-96ba-4c51-80cd-b418eafa8074"), "Josef Pepík", "Not bad", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("1a31f306-82e3-41de-b964-8558fbff9b13"), "Josef Pepík", "Enjoyed!", true, new Guid("891c93d7-8120-485b-80a7-f31691613a88"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("5097415e-6486-46ba-a484-bffde5d02ae0"), "Josef Pepík", "Great Movie", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("760510bb-2398-4c23-8534-72efdebdad7c"), "Josef Pepík", "One of the best i have ever seen", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("92e598c2-028c-4884-8c69-e5060719cdaf"), "Josef Pepík", "WOW", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("9aaadae0-b3f3-4a55-ac53-348b1f809083"), "Josef Pepík", "Crazy good!!!", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("aa4af015-fa23-4698-9d61-ecc9ae90d7d4"), "Josef Pepík", "Amazing", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("b4028308-67ab-4b41-bd02-911f8e0c5fa7"), "Josef Pepík", "Really good", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("bd438d69-1ce6-48e9-a58f-efcbefc3b969"), "Josef Pepík", "Enjoyed, but could have been way better. Too much death! Think of the children!!", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" },
                    { new Guid("f4116aeb-831b-466d-9c3b-e34366723dab"), "Josef Pepík", "Timeless classic!", true, new Guid("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), "b4f3317a-2d1a-4c0e-9f58-5359d9a74541" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
