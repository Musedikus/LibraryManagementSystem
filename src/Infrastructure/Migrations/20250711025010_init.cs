using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedAt", "CreatedById", "ISBN", "PublishedDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, "William Blackstone", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6481), "1", "9780198720527", new DateTime(1765, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Commentaries on the Laws of England", null },
                    { 4, "Oliver Wendell Holmes Jr.", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6483), "1", "9780486450060", new DateTime(1881, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Common Law", null },
                    { 5, "Nicholas J. McBride", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6484), "1", "9781292086907", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letters to a Law Student", null },
                    { 6, "Joshua Dressler", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6485), "1", "9781531016185", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding Criminal Law", null },
                    { 7, "Bryan A. Garner", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6486), "1", "9780226283937", new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legal Writing in Plain English", null },
                    { 8, "Erwin Chemerinsky", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6487), "1", "9781543813074", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Constitutional Law: Principles and Policies", null },
                    { 9, "Benjamin N. Cardozo", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6488), "1", "9780486443864", new DateTime(1921, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Nature of the Judicial Process", null },
                    { 10, "Jay M. Feinman", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6489), "1", "9780199341691", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Law 101: Everything You Need to Know About American Law", null },
                    { 11, "Ewan McKendrick", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6490), "1", "9780198855298", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contract Law: Text, Cases, and Materials", null },
                    { 12, "Tom Bingham", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6491), "1", "9780141034539", new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Rule of Law", null },
                    { 13, "Harper Lee", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6492), "1", "9780061120084", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird", null },
                    { 14, "John Rawls", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6504), "1", "9780674000780", new DateTime(1971, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Theory of Justice", null },
                    { 15, "H.L.A. Hart", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6505), "1", "9780199644709", new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Concept of Law", null },
                    { 16, "Deborah L. Rhode", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6506), "1", "9780195328719", new DateTime(2007, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethics in the Practice of Law", null },
                    { 17, "Antonin Scalia & Bryan A. Garner", new DateTime(2025, 7, 11, 2, 50, 10, 351, DateTimeKind.Utc).AddTicks(6507), "1", "9780314184719", new DateTime(2008, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Making Your Case: The Art of Persuading Judges", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "TokenVersion", "UpdatedAt" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testuser@example.com", "TestUser", "Test", "$2a$11$Xlf01hU5eeVdXz0AqVZLFeJ06ZBjGD4GOzrwf7alCweHRhJj1r04m", "2a3bc995-658a-477f-b08e-372cf9718962", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
