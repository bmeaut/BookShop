using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: true),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SumRating = table.Column<int>(type: "int", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "About", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, null, "Lam Kam Chuen Mester", null },
                    { 2, null, "Susanne Schumacher", null },
                    { 3, null, "Ernest J.Eitel", null },
                    { 4, null, "Simon Brown", null },
                    { 5, null, "François Villon", null },
                    { 6, null, "Sándor László, Pocsai Katalin", null },
                    { 7, null, "Raymond Lo", null },
                    { 8, null, "Jes T.Y.Lim", null },
                    { 9, null, "Fekete Zoltán, Zalay Miklós", null },
                    { 10, null, "Gill Hale, Mark Evans", null },
                    { 11, null, "Szilvásy Judit", null },
                    { 12, null, "Stanislav Grof, Christina Grof", null },
                    { 13, null, "Judy Allen", null },
                    { 14, null, "Jhampa Shaneman, Jan V.Angel", null },
                    { 15, null, "Horváth Andrea", null },
                    { 16, null, "Claus Reimann", null },
                    { 17, null, "Tomasz Lem", null },
                    { 18, null, "Tai San", null },
                    { 19, null, "Robert Powell", null },
                    { 20, null, "Bakos Attila", null },
                    { 21, null, "Julia Parker, Derek Parker", null },
                    { 22, null, "Kalo Jenő", null },
                    { 23, null, "Buji Ferenc", null },
                    { 24, null, "Késmárki László", null },
                    { 25, null, "Koffi Kwahulé", null },
                    { 26, null, "Madách Imre", null },
                    { 27, null, "Spiró György", null },
                    { 28, null, "Isa Schneider", null },
                    { 29, null, "Solara", null },
                    { 30, null, "Alfred Jarry", null },
                    { 31, null, "Faludy György", null },
                    { 32, null, "Paulinyi Tamás", null },
                    { 33, null, "Brian Haughton", null },
                    { 34, null, "Ronald H.Hulnick, Mary R.Hulnick", null },
                    { 35, null, "José ifj.Silva, Ed ifj.Bernd", null },
                    { 36, null, "Lou Aronica, Ken, Sir Robinson", null },
                    { 37, null, "Charles T.Tart", null },
                    { 38, null, "Lisa Rogak", null },
                    { 39, null, "Kornis Mihály", null },
                    { 40, null, "Börcsök László", null },
                    { 41, null, "Veszprémi Tamás", null },
                    { 42, null, "Pierre Merle", null },
                    { 43, null, "Komáromi Gabriella", null },
                    { 44, null, "Ingmar Bergman", null },
                    { 45, null, "Oliver Sacks", null },
                    { 46, null, "Ámosz Oz", null },
                    { 47, null, "Alexander Brody", null },
                    { 48, null, "Cecilie Loveid", null },
                    { 49, null, "Jon Fosse", null },
                    { 50, null, "Alighieri Dante", null },
                    { 51, null, "Arthur Miller", null },
                    { 52, null, "dr.Popper Péter", null },
                    { 53, null, "Tom Bryan", null },
                    { 54, null, "Röhrig Géza", null },
                    { 55, null, "William Shakespeare", null },
                    { 56, null, "Dsida Jenő", null },
                    { 57, null, "Arany János", null },
                    { 58, null, "Andrási Tiborné, Czeglédy István, dr.Czeglédy Istvánné", null },
                    { 59, null, "Berkes Klára", null },
                    { 60, null, "Tony Crilly", null },
                    { 61, null, "Stuart Clark", null },
                    { 62, null, "Katona Gyula Y., Recski András, Szabó Csaba", null },
                    { 63, null, "Obádovics J.Gyula", null },
                    { 64, null, "Halász Ágnes", null },
                    { 65, null, "Theodore Gray", null },
                    { 66, null, "Lente Gábor, Kovács Lajos, Gunda Tamás, Csupor Dezső", null },
                    { 67, null, "Kremmer Tibor, Torkos Kornél", null },
                    { 68, null, "Adam Smith", null },
                    { 69, null, "Zugorné Rácz Éva", null },
                    { 70, null, "Stefan Kassay", null },
                    { 71, null, "Kornai János", null },
                    { 72, null, "Galbács Péter", null },
                    { 73, null, "Simon Bishop, Mike Walker", null },
                    { 74, null, "Csáki György", null },
                    { 75, null, "N.Gregory Mankiw", null },
                    { 76, null, "Kopátsy Sándor", null },
                    { 77, null, "Csurgó Sándor", null },
                    { 78, null, "Dóry Béla", null },
                    { 79, null, "Enzo Gallori", null },
                    { 80, null, "Tóth Gábor", null },
                    { 81, null, "Vajta Gábor", null },
                    { 82, null, "I.N.Smeretle", null },
                    { 83, null, "Monika Offenberger", null },
                    { 84, null, "Sarah, dr.Brewer", null },
                    { 85, null, "Róbert Ceman", null },
                    { 86, null, "Ljudmila Ulickaja", null },
                    { 87, null, "Fábián Janka", null },
                    { 88, null, "Jonathan Safran Foer", null },
                    { 89, null, "Elif Shafak", null },
                    { 90, null, "Singer Arje Iván", null },
                    { 91, null, "Büky Anna", null },
                    { 92, null, "Vlagyimir Szorokin", null },
                    { 93, null, "Steven Erikson", null },
                    { 94, null, "J.R.R.Tolkien", null },
                    { 95, null, "Raymond E.Feist, Steve Stirling", null },
                    { 96, null, "George R.R.Martin", null },
                    { 97, null, "Kövesi Péter", null },
                    { 98, null, "R.A.Salvatore", null },
                    { 99, null, "Raymond E.Feist", null },
                    { 100, null, "Szappanos Gábor", null },
                    { 101, null, "Király - Acampora Anikó", null },
                    { 102, null, "Egon Erwin Kisch", null },
                    { 103, null, "Szendrődy Szonja", null },
                    { 104, null, "Kresley Cole", null },
                    { 105, null, "Bertrice Small", null },
                    { 106, null, "Julius J.Coach", null },
                    { 107, null, "Pedro Almodóvar", null },
                    { 108, null, "Cathryn Cooper", null },
                    { 109, null, "Carlos Ruiz Zafón", null },
                    { 110, null, "Stieg Larsson", null },
                    { 111, null, "Szalai Vivien", null },
                    { 112, null, "George P.Pelecanos", null },
                    { 113, null, "Joanne Fluke", null },
                    { 114, null, "Gerritsen Tess", null },
                    { 115, null, "Arthur Bernéde", null },
                    { 116, null, "Ross Macdonald", null },
                    { 117, null, "Bernard Knight", null },
                    { 118, null, "Agatha Christie", null },
                    { 119, null, "Linda Castillo", null },
                    { 120, null, "Martin Delrio", null },
                    { 121, null, "Philip K.Dick", null },
                    { 122, null, "Alan E.Nourse, William S.Burroughs", null },
                    { 123, null, "Robert Charles Wilson", null },
                    { 124, null, "Arkagyij Sztrugackij, Borisz Sztrugackij", null },
                    { 125, null, "Arthur C.Clarke, Stephen Baxter", null },
                    { 126, null, "Szergej Lukjanyenko", null },
                    { 127, null, "Frank Herbert", null },
                    { 128, null, "Nathan Archer", null },
                    { 129, null, "Lisa Jackson", null },
                    { 130, null, "Jónás Zsolt", null },
                    { 131, null, "Joe Hill", null },
                    { 132, null, "Bíró Szabolcs", null },
                    { 133, null, "Kathy Reichs", null },
                    { 134, null, "Steve Berry", null },
                    { 135, null, "Zima Szabolcs", null },
                    { 136, null, "Frei Tamás", null },
                    { 137, null, "Árpa Attila", null },
                    { 138, null, "Sam Barone", null },
                    { 139, null, "Andrew Sanders", null },
                    { 140, null, "Tracy Chevalier", null },
                    { 141, null, "Christian Jacq", null },
                    { 142, null, "André Castelot", null },
                    { 143, null, "J.M.G.Le Clézio", null },
                    { 144, null, "Roberta Rich", null },
                    { 145, null, "C.W.Gortner", null },
                    { 146, null, "Oliver Bowden", null },
                    { 147, null, "Juli Zeh", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Order", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Ezoterika", "00", null },
                    { 5, "Irodalom", "01", null },
                    { 9, "Tankönyvek", "02", null },
                    { 14, "Regény", "03", null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bioenergetic Kiadó" },
                    { 2, "Terc Kiadó" },
                    { 3, "Csengőkert Könyvkiadó" },
                    { 4, "Hajja és Fiai Könyvkiadó" },
                    { 5, "Sziget Könyvkiadó" },
                    { 6, "Első Magyar Feng Shui Centrum" },
                    { 7, "Lunarimpex Kiadó" },
                    { 8, "Műszaki Könyvkiadó" },
                    { 9, "Kossuth Kiadó" },
                    { 10, "Animus Kiadó" },
                    { 11, "Partvonal Könyvkiadó" },
                    { 12, "Alexandra Kiadó" },
                    { 13, "Szaktudás Kiadó Ház" },
                    { 14, "Typotex Kiadó" },
                    { 15, "STB Könyvek Könyvkiadó" },
                    { 16, "Regulus Art Kft." },
                    { 17, "Officina '96 Kiadó" },
                    { 18, "Danvantara Kiadó" },
                    { 19, "Gabo Könyvkiadó, Gulliver Könyvkiadó" },
                    { 20, "Kairosz Kiadó" },
                    { 21, "Ankh Kiadó" },
                    { 22, "L'Harmattan Kiadó" },
                    { 23, "Akadémiai Kiadó" },
                    { 24, "Scolar Kiadó" },
                    { 25, "K.u.K.Kiadó" },
                    { 26, "Édesvíz Kiadó" },
                    { 27, "Cartaphilus Könyvkiadó" },
                    { 28, "Villon Books Kiadó" },
                    { 29, "Tarandus Kiadó" },
                    { 30, "Gabo Könyvkiadó" },
                    { 31, "HVG Kiadó" },
                    { 32, "Ursus Libris Kiadó" },
                    { 33, "Európa Könyvkiadó" },
                    { 34, "Kalligram Könyv - és Lapkiadó" },
                    { 35, "Szukits Könyvkiadó" },
                    { 36, "Osiris Kiadó" },
                    { 37, "Park Könyvkiadó" },
                    { 38, "Napkút Kiadó" },
                    { 39, "QLT Műfordító Bt." },
                    { 40, "Saxum Kiadó" },
                    { 41, "Magyar Napló Kiadó" },
                    { 42, "Helikon Kiadó" },
                    { 43, "Múlt és Jövő Kiadó" },
                    { 44, "Nemzeti Tankönyvkiadó" },
                    { 45, "Geographia Kiadó" },
                    { 46, "Littera Nova Kiadó" },
                    { 47, "Napvilág Kiadó" },
                    { 48, "Képzőművészeti Kiadó" },
                    { 49, "Gondolat Kiadó" },
                    { 50, "Gazdasági Versenyhivatal Versenykultúra Központ" },
                    { 51, "Mezőgazda Kiadó" },
                    { 52, "Pilis - Vet Kiadó" },
                    { 53, "Noran Kiadó" },
                    { 54, "Delta Vision Kiadó" },
                    { 55, "BBS - INFO Kft." },
                    { 56, "Dialóg Campus Kiadó" },
                    { 57, "Slovart Kiadó" },
                    { 58, "Magvető Könyvkiadó" },
                    { 59, "Ulpius - ház Könyvkiadó" },
                    { 60, "I.A.T.Kiadó" },
                    { 61, "Beholder Kiadó" },
                    { 62, "Art Nouveau Kiadó" },
                    { 63, "JLX Kiadó" },
                    { 64, "Illia & Co.Kiadó" },
                    { 65, "Kalandor Könyvkiadó" },
                    { 66, "Agave Könyvek" },
                    { 67, "Metropolis Media" },
                    { 68, "Kelly Kiadó" },
                    { 69, "Athenaeum 2000 Kiadó" },
                    { 70, "I.P.C.Könyvek" },
                    { 71, "PolgART Lap - és Könyvkiadó" },
                    { 72, "Geopen Könyvkiadó" },
                    { 73, "Tericum Kiadó" },
                    { 74, "Fumax" },
                    { 75, "Goodinvest Kft." },
                    { 76, "General Press Kiadó" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Order", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Feng shui", "00.01", 1 },
                    { 3, "Horoszkóp, asztrológia", "00.02", 1 },
                    { 4, "Parapszichológia", "00.03", 1 },
                    { 6, "Életrajz", "01.01", 5 },
                    { 7, "Dráma, színmű", "01.02", 5 },
                    { 8, "Vers, eposz", "01.03", 5 },
                    { 10, "Matematika", "02.01", 9 },
                    { 11, "Kémia", "02.02", 9 },
                    { 12, "Közgazdaságtudomány", "02.03", 9 },
                    { 13, "Biológia", "02.04", 9 },
                    { 15, "Családregény", "03.01", 14 },
                    { 16, "Fantasy", "03.02", 14 },
                    { 17, "Erotikus", "03.03", 14 },
                    { 18, "Krimi", "03.04", 14 },
                    { 19, "Sci-fi", "03.05", 14 },
                    { 20, "Thriller", "03.06", 14 },
                    { 21, "Történelmi", "03.07", 14 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DiscountedPrice", "PageNumber", "Price", "PublishYear", "PublisherId", "RatingCount", "ShortDescription", "Subtitle", "SumRating", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 168, 3200, 2004, 1, 0, "Személyes feng shui tanácsadó elmagyarázza a feng shui alapelveit, ugyanakkor új dimenziókat tár fel az érdeklődők számára.Megmutatja, miként befolyásolják egyéni jellemvonásaink a környezetünkhöz való viszonyunkat.A kínai zodiákust tanulmányozva nagyobb önismeretre tehetünk szert, jobban megérthetjük belső erősségeinket.Tudásunkat a \"nyolc körre\" és a nyolc báguára alkalmazva harmóniában élhetünk környezetünkkel, elősegíthetjük személyes fejlődésünket.[br] A könnyen érthető, ábrákkal és fotókkal gazdagon illusztrált könyv segítségével megismerhetjük és elsajátíthatjuk a feng shuit, egészen az alapoktól; ellenőrizhetjük, hogy otthonunk energiamezői harmóniában állnak - e saját energiamintáinkkal; fokozhatjuk hatékonyságunkat munkánk során; bátran használhatjuk a kínai zodiákust baráti, családi és munkakapcsolataink jobb megértéséhez.", "Hogyan éljünk egészségesen és harmonikusan", 0, "Személyes feng shui tanácsadó" },
                    { 2, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 128, 4900, 2008, 2, 0, "Képzelje azt, hogy kertje egy ruhadarab.A kertnek a ruhadarabhoz hasonlóan \"jól kell állnia\" tulajdonosának.Nézzen egy kicsit más szemmel kertjére, erkélyére vagy teraszára. Minden a helyén van? Tükrözi - e a kert a személyiségét?[br] A kötet segít elmélyedni a feng shui nyújtotta lehetőségekben.Ne gondoljon azonnal teljes átalakításra, éppen az óvatos, kisebb javítások a feng shui erősségei. Varázsolja kertjét oázissá, engedje szabadon szárnyalni képzeletét, váljon eggyé a természettel.Tanuljon mások tapasztalatából, olyan emberekéből, akik már rátaláltak a feng shuira, a harmónia és életöröm forrására.", "Ötletek kertekhez, teraszokhoz, erkélyekhez ", 0, "Az én feng shui-kertem" },
                    { 3, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 80, 699, 2012, 3, 0, "Az ember, az ember által létrehozott környezet, valamint a természet összhangjának több évezredes kínai tudománya már a 19.század közepe óta ismert a nyugati világban. Odaadó hívei a szabályrendszer szigorú betartásával alakítják életüket, lakókörnyezetüket, de még bírálói is kénytelenek elismerni, a megállapítások mélyén bonyolult összefüggések rejlenek.[br] [br] A feng shui nem csupán a lakberendezés ügyes tudománya: jelen van benne az animizmus, a taoizmus, a konfucianizmus és a buddhizmus jónéhány eszméje. Rávilágít a látszólag egymástól távol álló dolgok közötti összefüggésekre, fellebbenti a fátylat a misztikus összefüggésekről, rendszerbe foglalva állítja elénk a hajdanvolt bölcsek megfigyeléseit, a geomanciával, numerológiával és asztrológiával foglalkozó tudósok megállapításait.", "A természet és az egyensúly kínai tudományával kapcsolatos alapvető tudnivalók", 0, "Feng Shui" },
                    { 4, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 160, 3990, 2009, 4, 0, "Fengsuj a gyakorlatban[br]- Olyan ősi filozófiát mutat be, melynek követésével irányíthatjuk a pozitív és a negatív energiákat, és ezzel megváltoztathatjuk életünket és sorsunkat.[br]- Praktikus tanácsokkal lát el otthonunk helyiségeinek elhelyezését és berendezését illetően, melyek segíthetnek céljaink megvalósításában, vágyaink kiteljesítésében.[br]- Bemutatja, hogyan tehetjük kellemesebbé otthonunkat és hogyan javíthatunk általános közérzetünkön a megfelelő színek, anyagok és más díszítőelemek kiválasztásával.[br]- A lakás ideális berendezésére vonatkozó javaslatokkal hozzásegít a jó kapcsolatok, a jól menő üzlet kiépítéséhez, a kielégítő szexuális élethez, a jó egészséghez.", null, 0, "Fengsuj a gyakorlatban" },
                    { 5, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 176, 1650, 1999, 5, 0, "François Villon válogatott versei.", null, 0, "François Villon versei" },
                    { 6, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 152, 2100, 2006, 1, 0, "Az elmúlt évezredek során Kelet nagy bölcsei számos tanítással és igazsággal gazdagították az emberiséget. Azt tartották, hogy fejlődésünk célja a tökéletes emberi állapot, a megvilágosodás elérése. A jó energiatérrel, élő és éltető energiákkal rendelkező építmények, helyiségek nagymértékben elősegítik ezt a folyamatot.[br] A feng-shui, ami alapjában véve annyit jelent, hogy az ember összhangban él az őt körülvevő világgal, ennek megvalósításához nyújt aktív és tudatos segítséget.[br] A könyv két szerzője feng - shui mester, szakértő.Munkájukkal egy, az ősi tudásra épülő, de a nyugati életvitel számára is elfogadható új sorozat első kötetét alkották meg.Céljuk, hogy mindazok kezébe és otthonába elkerülhessenek ezek a tanítások, akik szeretnek tanulni, és szívesen tökéletesítik önmagukat, környezetüket valamint kíváncsiak a \"miértekre\".", "Első kötet -Alapfogalmak I.", 0, "A nyugati környezetben is használható Feng - Shui" },
                    { 7, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 228, 2780, 2005, 6, 0, "Könyvem első részében a Négyoszlopos Sorsmeghatározás különleges módszerét mutatom be, ami újdonság a Kínán kívül élők számára. A Négyoszlopos Sorsmeghatározás klasszikus sorselemzési eljárás, pontos, időpontok szerint behatárolható képet ad az ember képességeiről, lehetőségeiről, élete szerencsés és balszerencsés időszakairól.A technikát néhány híresség és befolyásos politikus sorsának elemzéseivel illusztrálom. Közlöm előzetes jóslataimat az amerikai - iraki összecsapások kimeneteléről az 1990 - 91 - es Öbölháborúban, megtudhatják mekkora szerepe volt az események végeredményére id. Bush elnök és Saddam Hussein sorsának és szerencséjének. Kiderül, milyen végzetes okok vezettek Marilyn Monroe halálához.S amint Karen Carpenter és John Lennon fiatalon elhunyt művészek tragikus sorsának okai, úgy Margaret Thatcher és Mihail Gorbacsov politikai karrierjének alakulása is kikövetkeztethető Sorsuk Négyoszlopából, valamint Szerencseoszlopaikból.[br] A könyv második részében a Feng Shui rejtett szépségeivel foglalkozom, s igyekszem bemutatni a tan kevéssé ismert összefüggéseit és módszereit.Hongkong híres épületeinek Feng Shui elemzésén túl, számos érdekes példán mutatom be, mi mindenre jó a Feng Shui. Szeretném, ha Olvasóim e különleges technika ismeretében boldogabban élhetnének. (Raymond Lo)", "A Repülő csillagok és a kínai sorselemzés művészete", 0, "A Feng shui és a siker titka térben és időben" },
                    { 8, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 140, 3580, 2004, 7, 0, "A távol-keleti kertépítés mind a hobbi-, mind a profi kertész számára olyan elmélyült, mégis egyszerű alapelvekkel szolgál, amelyek segítségével szívvel-lélekkel belevethetjük magunkat az érzékeket gyönyörködtető és üdítő légkörű kert megteremtésébe.[br] Szinte az egész világot beutaztam fengshui - és energetikai szakértőként, és szomorúan kellett tapasztalnom, hogy elveszett az a fő cél, amiért az épületeket, illetve a kerteket építjük - tudniillik, hogy olyan energiával és élettel teli helyet hozzunk létre, ahol feltöltődünk és visszanyerjük életkedvünket. (...) A könyvemben bemutatott ázsiai kertkialakítási és fengshui - alapelveket bármelyik kertben alkalmazhatjuk típustól és nagyságtól függetlenül, legyen az egy virágos láda az ablakunkban vagy egy park.Különös hangsúlyt helyeztem a kövek kiválasztására és elhelyezésére, ahogy azt a taoisták és a zen követői alkalmazták.A \"Beszélgessünk a növényekkel\" című fejezetben leírtak elolvasása után pedig úgy tekintünk majd a növényekre, ahogy eddig még soha.", "A taoizmus és a zen a kertművelésben", 0, "Feng Shui és kert" },
                    { 9, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 360, 2050, 2006, 8, 0, null, "Példatár", 0, "Többváltozós függvények analízise - Bolyai - könyvek" },
                    { 10, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 120440, 2588, 2002, 7, 0, "E könyvben az üzleti Feng Shui gyakorlati művelésének különböző szempontjait és irányelveit igyekszem érthetően felvázolni, hogy a kedves Olvasó az eddig talán kevésbé ismert szempontokról is áttekintést szerezhessen. Ezáltal elkerülheti a hibákat és adott esetben orvosolhatja a bajt, amelyek miatt szembekerülhetett munkatársaival. Még abban az esetben is, ha elbizonytalanodna, mert üzlete nem megy olyan jól, mint ahogy mehetne, az üzleti Feng Shui kínálta kiváló ötletek kimozdítják az energiát pangó helyzetéből, és a kívánt folyásirányba terelik.", null, 0, "Feng Shui az irodában és az üzleti életben" },
                    { 11, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 512, 7990, 2009, 9, 0, "Az egészség és a jó közérzet ismereteinek tárháza.[br] - Irányítsd ősi technikákkal és évszázadok bölcsességével tested, lelked és otthonod különleges erőit és tulajdonságait.[br] - Részletes útmutatások a feng shui ősi kínai művészetéhez, gyakorlati tanácsok az elvek alkalmazásához a nyugalmas terek és lelkileg tápláló környezet megteremtése érdekében.[br] - Tisztítsd meg a teret, ahol élsz vagy dolgozol.A tömjén és más füstölők, a víz és a hang erejének egyszerű eszközeivel megmozgathatod a stagnáló energiákat, és otthonodban tavaszi nagytakarítást végezhetsz.[br] - Mindaz, amit tudnod kell ahhoz, hogy otthonodat nyugalommal és kiegyensúlyozott energiával telt, pozitív térré változtasd.", "1800 képpel illusztrált gyakorlati útmutató", 0, "A feng shui nagykönyve" },
                    { 12, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 152, 1990, 2008, 6, 0, "Ebben a könyvben különleges tematikával mutatom be a Feng Shui egy kis szeletét. Mint látható, a könyv két részből áll. Az egyik fele a nőknek, a másik a férfiaknak szól. Természetesen a nőknek is hasznos - sőt ajánlott - a férfiaknak írt oldalakat elolvasni, hiszen nem ugyanazt a témát magyarázom el kétféleképpen. A témaválasztás is más és más. Nagyon szeretném, ha mind a nők, mind a férfiak - akik eddig kétkedve fogadták a Feng Shuit - kicsit jobban belelátnának e filozófia működésébe.(a Szerző)", null, 0, "Feng Shui nőknek - Feng Shui férfiaknak" },
                    { 13, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 256, 2890, 2010, 10, 0, "A könyv a holotróp légzéstechnika elméletét és gyakorlatát összegzi.A pszichoterápia és az önmegismerés ezen új módszere magába foglalja a mélylélektan különféle irányzatainak elemeit, emellett merít a modern tudatkutatásból, a kulturális antropológiából és a keleti spirituális gyakorlatokból is.[br] A technikát kidolgozó szerzők esetleírásokkal is alátámasztják a holotróp légzés sokrétű terápiás, valamint az önmegismerést, belső fejlődést elősegítő hatását.", "Holotróp légzéstechnika - az öngyógyítás új útja", 0, "Transzlégzés" },
                    { 14, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 144, 4990, 2007, 11, 0, null, "Különös jelenségek, furcsa babonák és ősi rejtélyek", 0, "Megmagyarázhatatlan jelenségek enciklopédiája" },
                    { 15, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 360, 2799, 2010, 12, 0, null, "Horoszkópelemzés buddhista megközelítésben", 0, "Buddhizmus és asztrológia" },
                    { 16, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 88, 1750, 2003, 13, 0, null, null, 0, "Asztrológiaiskola II.Tarot és kínai jóstanfolyamok" },
                    { 17, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 276, 2800, 2004, 1, 0, null, null, 0, "Mély forrás A pszichológiai asztrológia tizenkét archetípusa" },
                    { 18, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 256, 2500, 2010, 14, 0, null, null, 0, "Földközeli kalandok" },
                    { 19, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 296, 499, 2009, 15, 0, null, null, 0, "Kínai örökhoroszkóp Tervezze meg jövőjét!" },
                    { 20, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 228, 3590, 2011, 16, 0, null, null, 0, "A zodiákus története" },
                    { 21, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 144, 4990, 2010, 17, 0, null, null, 0, "Sütő András világa" },
                    { 22, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 2850, 2011, 18, 0, null, "A Dzsotir Vidjá az ősi indiai asztrológia tanítása", 0, "Asztro pszichológia" },
                    { 23, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 496, 9900, 2011, 19, 0, null, "Hiteles és átfogó útmutató az asztrológia tudományához", 0, "Parker Asztrológia" },
                    { 24, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 240, 2600, 2011, 1, 0, null, "Az orvosi asztrológia kézikönyve II.kötet", 0, "A gyógyulás szelencéje" },
                    { 25, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 354, 3900, 2012, 20, 0, null, "Az asztrológia belső rendje", 0, "Harmonia Universalis" },
                    { 26, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 290, 4800, 2012, 21, 0, null, null, 0, "Ájurvédikus asztrológia és marmapunktúra" },
                    { 27, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 222, 2500, 2012, 22, 0, null, "Drámák", 0, "Big Shoot" },
                    { 28, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 320, 4990, 2011, 23, 0, null, null, 0, "Az ember tragédiája Jankovics Marcell animációs filmváltozatának képeivel" },
                    { 29, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 320, 3750, 2012, 24, 0, null, null, 0, "Drámák V.Az Árpád - ház - A békecsászár - Príma környék" },
                    { 30, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 2200, 2011, 25, 0, null, "... egy orvosnő szemével", 0, "Kísértetek, rejtelmek, átkok" },
                    { 31, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 286, 2990, 2006, 26, 0, null, "Útlevél az új világba", 0, "Belépési pont" },
                    { 32, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 144, 1990, 2011, 27, 0, null, "Schall Eszter rajzaival", 0, "Két ÜBÜ - dráma" },
                    { 33, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 272, 2980, 2003, 28, 0, null, null, 0, "Európai költők antológiája" },
                    { 34, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 228, 3450, 2012, 29, 0, null, "Pszi - akták", 0, "Az igazság odaát van" },
                    { 35, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 3500, 2011, 30, 0, null, null, 0, "Paranormális erők kézikönyve" },
                    { 36, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 260, 3290, 2012, 26, 0, null, "A spirituális pszichológia lényege", 0, "Lelkedhez hűen" },
                    { 37, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 272, 2499, 2010, 12, 0, null, "Használjuk mentális erőnket, hogy sikeresek legyünk az élet minden területén!", 0, "Érzékeken túli észlelés José Silva módszerével" },
                    { 38, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 336, 3900, 2010, 31, 0, null, "Fedezd fel, mire születtél, és minden megváltozik", 0, "Az alkotó elem" },
                    { 39, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 384, 4300, 2010, 32, 0, null, "A tudomány és a spiritualitás találkozása a paranormális jelenségek bizonyítékainak fényében", 0, "A materializmus vége" },
                    { 40, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 408, 3500, 2010, 33, 0, null, "Stephen King élete", 0, "Kísértetszív" },
                    { 41, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 264, 2900, 2007, 34, 0, null, "Képeskönyv", 0, "Egy csecsemő emlékiratai(CD - ROM melléklettel)" },
                    { 42, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 214, 1190, 2002, 35, 0, null, null, 0, "Érettségi, felvételi feladatok: Matematika" },
                    { 43, 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 520, 9950, 2008, 23, 0, null, null, 0, "Általános kémia" },
                    { 44, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 356, 3500, 2012, 33, 0, null, "Egy szenvedélyes élet", 0, "Robert Merle" },
                    { 45, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 392, 2980, 2011, 36, 0, null, null, 0, "Lázár Ervin élete és munkássága" },
                    { 46, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 480, 3500, 2011, 33, 0, null, null, 0, "Laterna magica" },
                    { 47, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 300, 2500, 2006, 37, 0, null, null, 0, "Fél lábbal a földön" },
                    { 48, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 864, 3500, 2010, 33, 0, null, null, 0, "Szeretetről, sötétségről" },
                    { 49, 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 320, 2900, 2011, 34, 0, null, "Hunyady Sándor arcképe", 0, "A bolygó fénye" },
                    { 50, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 564, 3700, 2010, 33, 0, null, "Mai francia drámák", 0, "Művészet" },
                    { 51, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 88, 1490, 2012, 38, 0, null, "Színdarab 4 részben, 35 jelenetben", 0, "Maria Quisling" },
                    { 52, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 416, 3900, 2012, 39, 0, null, "Hat színmű", 0, "Valaki jön majd" },
                    { 53, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 280, 3990, 2012, 29, 0, null, null, 0, "Pokol" },
                    { 54, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 144, 1950, 2011, 24, 0, null, null, 0, "Üvegcserepek" },
                    { 55, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 288, 2800, 2011, 40, 0, null, "Színes pokol - Útvesztő - Isten komédiásai", 0, "A pokol színei" },
                    { 56, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 88, 1260, 2010, 41, 0, null, null, 0, "A csörgőkígyó útja" },
                    { 57, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 264, 3990, 2010, 42, 0, null, "Kínai, indiai, görög, latin, angol, francia, német, olasz, spanyol, román, dél - amerikai...", 0, "Száz vers" },
                    { 58, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 112, 1900, 2010, 43, 0, null, null, 0, "Honvágy" },
                    { 59, 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 232, 1980, 2005, 5, 0, null, null, 0, "Goethe Hölderlin Heine versei" },
                    { 60, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 240, 1980, 2003, 5, 0, null, null, 0, "Dalok és szonettek" },
                    { 61, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 264, 2380, 2003, 5, 0, null, null, 0, "Dsida Jenő versei" },
                    { 62, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 160, 1650, 2002, 5, 0, null, null, 0, "Arany János balladái" },
                    { 63, 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 1480, 1999, 5, 0, null, null, 0, "Kínai és japán költők" },
                    { 64, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 304, 2020, 2008, 8, 0, null, null, 0, "Matematika 6.tankönyv, bővített változat" },
                    { 65, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 216, 1470, 2004, 8, 0, null, null, 0, "Matematika 4.Tankönyv, I.kötet" },
                    { 66, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 56, 890, 2008, 44, 0, null, null, 0, "Szöveges ki(s)számoló feladatok 3.osztályosoknak" },
                    { 67, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 3500, 2011, 45, 0, null, null, 0, "Nagy kérdések: Matematika" },
                    { 68, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 3500, 2011, 45, 0, null, null, 0, "Nagy kérdések: Világegyetem" },
                    { 69, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 192, 2900, 2006, 14, 0, null, null, 0, "A számítástudomány alapjai" },
                    { 70, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 336, 2990, 2009, 24, 0, null, null, 0, "Valószínűségszámítás és matematikai statisztika" },
                    { 71, 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 180, 6800, 2012, 46, 0, null, "A rózsaablakok titkai", 0, "A szépség geometriája, a geometria szépsége" },
                    { 72, 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 240, 5999, 2011, 17, 0, null, "Kalandozás a Világegyetem atomjai között", 0, "Kémiai elemek" },
                    { 73, 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 596, 4200, 2011, 23, 0, null, "Tévhitek, félreértések, magyarázatok", 0, "Száz kémiai mítosz" },
                    { 74, 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 280, 5200, 2010, 23, 0, null, null, 0, "Elválasztástechnikai módszerek elmélete és gyakorlata" },
                    { 75, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1196, 5800, 2011, 47, 0, null, "Az eredeti, teljes szöveg új kiadása", 0, "Vizsgálódás a nemzetek jólétének természetéről és okairól I - II." },
                    { 76, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 168, 2910, 2003, 48, 0, null, null, 0, "Gazdasági kislexikon és képletgyűjtemény" },
                    { 77, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 706, 8000, 2012, 49, 0, null, "Vállalkozói környezet - A tulajdonszerkezet változása a gazdasági átmenet időszakában", 0, "Vállalat és vállalkozás" },
                    { 78, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 672, 4990, 2012, 34, 0, null, null, 0, "A szocialista rendszer" },
                    { 79, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 420, 4600, 2012, 23, 0, null, null, 0, "Aktív szabályozás vagy gazdaságpolitikai nihilizmus?" },
                    { 80, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 804, 6000, 2011, 50, 0, null, "Alapfogalmak, alkalmazások és mérési módszerek", 0, "Az európai közösségi versenyjog közgazdaságtana" },
                    { 81, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 400, 4200, 2011, 47, 0, null, null, 0, "A nemzetközi és a világgazdaságtan alapjai" },
                    { 82, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 640, 5980, 2011, 36, 0, null, null, 0, "A közgazdaságtan alapjai" },
                    { 83, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 360, 3990, 2011, 23, 0, null, "A minőség társadalma", 0, "Új közgazdaságtan" },
                    { 84, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 172, 2200, 2001, 51, 0, null, null, 0, "Gyógynövény embernek, állatnak, növénynek" },
                    { 85, 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 112, 1800, 2010, 20, 0, null, null, 0, "Szivárványkönyv Közjótan és magyar nemzetgazdaság" },
                    { 86, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 206, 4200, 2010, 51, 0, null, null, 0, "Vadbiológiai olvasókönyv" },
                    { 87, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 240, 3500, 2010, 51, 0, null, null, 0, "Emlős ragadozók Magyarországon" },
                    { 88, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 232, 5990, 2010, 9, 0, null, "Az élet kémiai alapjai, az evolúció törvényei, a jövő nagy reményei és aggodalmai", 0, "Genetika - Képes enciklopédia" },
                    { 89, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 160, 1450, 2004, 52, 0, null, "A genetikailag módosított élelmiszerek kockázatai", 0, "Génháború" },
                    { 90, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 304, 2800, 2004, 53, 0, null, "A klónozást bemutató CD - filmmelléklettel", 0, "Egy klónozó vallomásai" },
                    { 91, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 344, 2490, 2004, 54, 0, null, "Sötételf - trilógia II.könyv", 0, "Száműzött" },
                    { 92, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 210, 1970, 2012, 55, 0, null, "Gén, ember, társadalom", 0, "Az élet alapkérdései" },
                    { 93, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 128, 1980, 2006, 56, 0, null, null, 0, "Nautilus és Sapiens Bevezetés az evolúcióelméletbe" },
                    { 94, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 6990, 2011, 30, 0, null, "Bevezetés az emberi anatómiába", 0, "Az emberi test" },
                    { 95, 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 186, 2999, 2006, 57, 0, null, "Földrajzi enciklopédia", 0, "Élő természet: Állatvilág" },
                    { 96, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 504, 3490, 2006, 58, 0, null, null, 0, "Kukockij esetei" },
                    { 97, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 512, 3499, 2011, 59, 0, null, null, 0, "Emma lánya" },
                    { 98, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 388, 2990, 2009, 27, 0, null, "A 2 Oscar - díjra jelölt film alapjául szolgáló regény", 0, "Rém hangosan és irtó közel" },
                    { 99, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 384, 3499, 2011, 59, 0, null, null, 0, "Az angyalos ház" },
                    { 100, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 384, 3499, 2011, 59, 0, null, null, 0, "Emma fiai" },
                    { 101, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 408, 3499, 2011, 59, 0, null, null, 0, "Emma szerelme" },
                    { 102, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 472, 3600, 2009, 33, 0, null, null, 0, "Az isztambuli fattyú" },
                    { 103, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 272, 2699, 2012, 12, 0, null, null, 0, "Igazgató úr A Kispesti Textilgyár igazgatójának igaz története" },
                    { 104, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 212, 2990, 2012, 60, 0, null, null, 0, "Éjszaka történt" },
                    { 105, 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 316, 2480, 2007, 49, 0, null, null, 0, "Bro útja" },
                    { 106, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1256, 3999, 2011, 12, 0, null, null, 0, "A Kaszás vihara A Malazai Bukottak Könyvének regéje VII." },
                    { 107, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 316, 2900, 2012, 33, 0, null, "vagy: Oda - vissza", 0, "A Hobbit" },
                    { 108, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 368, 1998, 2004, 61, 0, null, "A Résháború legendája sorozat", 0, "Sebes Jimmy" },
                    { 109, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 672, 2999, 2004, 12, 0, null, "A Malazai Bukottak Könyvének regéje II.", 0, "Tremorlor kapuja" },
                    { 110, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1216, 3499, 2012, 12, 0, null, "A tűz és jég dala III.", 0, "Kardok vihara" },
                    { 111, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 276, 3450, 2011, 29, 0, null, null, 0, "A Pilis - összeesküvés" },
                    { 112, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 504, 2490, 2007, 54, 0, null, null, 0, "Vérkőföldek királya Zsoldosok sorozat III.kötete" },
                    { 113, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 528, 2998, 2007, 61, 0, null, null, 0, "Törött korona" },
                    { 114, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 192, 2990, 2011, 29, 0, null, "Erotikus történelmi kalandregény", 0, "A királynő mélyén" },
                    { 115, 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 896, 2999, 2012, 12, 0, null, null, 0, "Varjak lakomája A tűz és jég dala IV." },
                    { 116, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 2999, 2010, 60, 0, null, "XXI.századi dekameron", 0, "Pasipanoptikum" },
                    { 117, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 160, 1790, 2012, 38, 0, null, "Regény", 0, "A leánycsősz" },
                    { 118, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 288, 2499, 2011, 62, 0, null, null, 0, "A vadászó préda Mit ér a nő a húspiacon?" },
                    { 119, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 448, 3499, 2011, 59, 0, null, null, 0, "Vámpírzóna  Halhatatlanok alkonyat után sorozat 5." },
                    { 120, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 310, 2990, 2011, 11, 0, null, null, 0, "Szenvedélyes örömök Erotika és bujaság" },
                    { 121, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 432, 2950, 2012, 24, 0, null, null, 0, "Nonstop szerelem" },
                    { 122, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 1900, 2011, 27, 0, null, "Egy pornósztár vallomásai", 0, "Patty Diphusa" },
                    { 123, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 336, 2790, 2011, 63, 0, null, null, 0, "Pajkos mesék 4.Erotikus történetek" },
                    { 124, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 668, 3999, 2010, 59, 0, null, null, 0, "Angyali játszma" },
                    { 125, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 624, 3290, 2012, 10, 0, null, null, 0, "A tetovált lány A nemzetközi bestseller Millennium - trilógia első kötete" },
                    { 126, 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 2699, 2011, 62, 0, null, "Egy magyar luxusprostituált és egy budai milliárdos története", 0, "Drága kéj" },
                    { 127, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 360, 2699, 2010, 12, 0, null, null, 0, "A pokol tornácán" },
                    { 128, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 304, 2590, 2010, 64, 0, null, null, 0, "Szemérmes barack és gyilkosság  Hannah Swensen titokzatos esetei 7." },
                    { 129, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 480, 3499, 2011, 59, 0, null, null, 0, "A bűnös" },
                    { 130, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 260, 2000, 2012, 25, 0, null, "A Louvre fantomja", 0, "Belphegor" },
                    { 131, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 440, 2600, 2012, 33, 0, null, null, 0, "A másik férfi" },
                    { 132, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 320, 1890, 2004, 65, 0, null, "John koroner nyomoz", 0, "Nincs menedék" },
                    { 133, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 320, 2200, 2010, 33, 0, null, null, 0, "Halál a felhők között" },
                    { 134, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 304, 2800, 2012, 76, 0, null, null, 0, "Megtört csend" },
                    { 135, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 2490, 2004, 54, 0, null, null, 0, "A holtak szolgálata Northwind trilógia III.kötet" },
                    { 136, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 224, 2880, 2012, 66, 0, null, null, 0, "A Frolix - 8 küldötte" },
                    { 137, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 288, 2990, 2010, 67, 0, null, "Az igazi Blade Runner", 0, "Pengefutár" },
                    { 138, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 288, 2990, 2011, 67, 0, null, null, 0, "Örvény" },
                    { 139, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 368, 2990, 2011, 67, 0, null, null, 0, "Nyugtalanság" },
                    { 140, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 400, 3490, 2011, 67, 0, null, null, 0, "Régmúlt napok fénye" },
                    { 141, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 432, 2990, 2007, 67, 0, null, null, 0, "Pörgés" },
                    { 142, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 444, 2990, 2007, 67, 0, null, "Az őrség - tetralógia első kötete", 0, "Éjszakai őrség" },
                    { 143, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 330, 3600, 2004, 35, 0, null, "4.kötet", 0, "A Dűne istencsászára" },
                    { 144, 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 260, 2890, 2011, 35, 0, null, null, 0, "Predator: Betondzsungel" },
                    { 145, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 464, 2980, 2012, 68, 0, null, null, 0, "A gonosz csábítása" },
                    { 146, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 368, 2490, 2007, 54, 0, null, null, 0, "Túlpart" },
                    { 147, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 504, 3200, 2012, 33, 0, null, null, 0, "Szarvak" },
                    { 148, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 336, 3499, 2012, 59, 0, null, null, 0, "Sub Rosa" },
                    { 149, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 560, 3499, 2012, 59, 0, null, null, 0, "Csont és bőr" },
                    { 150, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 344, 2490, 2004, 69, 0, null, null, 0, "Sasok és angyalok" },
                    { 151, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 656, 3999, 2010, 59, 0, null, null, 0, "A velencei árulás" },
                    { 152, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 302, 3499, 2012, 59, 0, null, null, 0, "A makedón összeesküvés" },
                    { 153, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 624, 3499, 2011, 59, 0, null, null, 0, "A Bankár" },
                    { 154, 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 400, 3499, 2012, 59, 0, null, null, 0, "Holtomiglan" },
                    { 155, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 624, 3498, 2010, 70, 0, null, null, 0, "A birodalom hajnala" },
                    { 156, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 296, 2900, 2004, 71, 0, null, "Zsidó és római levelek a II.századból", 0, "Férjem, Bár Kochbá" },
                    { 157, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 296, 2990, 2009, 72, 0, null, null, 0, "A hölgy és az egyszarvú" },
                    { 158, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 208, 2600, 2007, 33, 0, null, "Legújabb egyiptomi elbeszélések", 0, "Milyen édes az élet a pálmafák árnyékában" },
                    { 159, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 524, 3600, 2008, 33, 0, null, "Habsburg pár Mexikó trónján", 0, "Miksa és Sarolta" },
                    { 160, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 568, 2800, 2008, 33, 0, null, null, 0, "Körforgás" },
                    { 161, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 280, 3570, 2011, 73, 0, null, null, 0, "A velencei bába" },
                    { 162, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 552, 3970, 2011, 73, 0, null, null, 0, "Medici Katalin vallomásai" },
                    { 163, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 474, 3790, 2011, 74, 0, null, null, 0, "Assassin's Creed: Testvériség" },
                    { 164, 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 480, 3790, 2011, 75, 0, null, null, 0, "Assassin's Creed: Reneszánsz" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 8, 10 },
                    { 10, 11 },
                    { 11, 12 },
                    { 12, 13 },
                    { 13, 14 },
                    { 14, 15 },
                    { 15, 16 },
                    { 16, 17 },
                    { 17, 18 },
                    { 18, 19 },
                    { 19, 20 },
                    { 20, 22 },
                    { 21, 23 },
                    { 22, 24 },
                    { 23, 25 },
                    { 24, 26 },
                    { 25, 27 },
                    { 26, 28 },
                    { 27, 29 },
                    { 28, 30 },
                    { 29, 31 },
                    { 30, 32 },
                    { 31, 33 },
                    { 32, 34 },
                    { 33, 35 },
                    { 34, 36 },
                    { 35, 37 },
                    { 36, 38 },
                    { 37, 39 },
                    { 42, 40 },
                    { 39, 41 },
                    { 40, 42 },
                    { 41, 43 },
                    { 42, 44 },
                    { 43, 45 },
                    { 44, 46 },
                    { 45, 47 },
                    { 46, 48 },
                    { 47, 49 },
                    { 48, 51 },
                    { 49, 52 },
                    { 50, 53 },
                    { 51, 54 },
                    { 52, 55 },
                    { 53, 56 },
                    { 54, 58 },
                    { 55, 60 },
                    { 56, 61 },
                    { 57, 62 },
                    { 58, 64 },
                    { 59, 66 },
                    { 60, 67 },
                    { 61, 68 },
                    { 62, 69 },
                    { 63, 70 },
                    { 64, 71 },
                    { 65, 72 },
                    { 66, 73 },
                    { 67, 74 },
                    { 68, 75 },
                    { 69, 76 },
                    { 70, 77 },
                    { 71, 78 },
                    { 72, 79 },
                    { 73, 80 },
                    { 74, 81 },
                    { 75, 82 },
                    { 76, 83 },
                    { 77, 84 },
                    { 78, 85 },
                    { 79, 88 },
                    { 80, 89 },
                    { 81, 90 },
                    { 98, 91 },
                    { 82, 92 },
                    { 83, 93 },
                    { 84, 94 },
                    { 85, 95 },
                    { 86, 95 },
                    { 87, 97 },
                    { 88, 98 },
                    { 87, 99 },
                    { 87, 100 },
                    { 87, 101 },
                    { 89, 102 },
                    { 90, 103 },
                    { 91, 104 },
                    { 92, 105 },
                    { 93, 106 },
                    { 94, 107 },
                    { 95, 108 },
                    { 93, 109 },
                    { 96, 110 },
                    { 97, 111 },
                    { 98, 112 },
                    { 99, 113 },
                    { 100, 114 },
                    { 96, 115 },
                    { 101, 116 },
                    { 102, 117 },
                    { 103, 118 },
                    { 104, 119 },
                    { 105, 120 },
                    { 106, 121 },
                    { 107, 122 },
                    { 108, 123 },
                    { 109, 124 },
                    { 110, 125 },
                    { 111, 126 },
                    { 112, 127 },
                    { 113, 128 },
                    { 114, 129 },
                    { 115, 130 },
                    { 116, 131 },
                    { 117, 132 },
                    { 118, 133 },
                    { 119, 134 },
                    { 120, 135 },
                    { 121, 136 },
                    { 122, 137 },
                    { 123, 138 },
                    { 124, 139 },
                    { 125, 140 },
                    { 123, 141 },
                    { 126, 142 },
                    { 127, 143 },
                    { 128, 144 },
                    { 129, 145 },
                    { 130, 146 },
                    { 131, 147 },
                    { 132, 148 },
                    { 133, 149 },
                    { 147, 150 },
                    { 134, 151 },
                    { 135, 152 },
                    { 136, 153 },
                    { 137, 154 },
                    { 138, 155 },
                    { 139, 156 },
                    { 140, 157 },
                    { 141, 158 },
                    { 142, 159 },
                    { 143, 160 },
                    { 144, 161 },
                    { 145, 162 },
                    { 146, 163 },
                    { 146, 164 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressId",
                table: "UserAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
