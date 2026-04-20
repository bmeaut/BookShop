using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title).HasMaxLength(200);
        builder.Property(e => e.Subtitle).HasMaxLength(200);
        builder.Property(e => e.ShortDescription).HasMaxLength(2000);

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public static void SeedData(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
        new Book
        {
            Id = 1,
            Title = "Személyes feng shui tanácsadó",
            Subtitle = "Hogyan éljünk egészségesen és harmonikusan",
            ShortDescription = @"Személyes feng shui tanácsadó elmagyarázza a feng shui alapelveit, ugyanakkor új dimenziókat tár fel az érdeklődők számára.Megmutatja, miként befolyásolják egyéni jellemvonásaink a környezetünkhöz való viszonyunkat.A kínai zodiákust tanulmányozva nagyobb önismeretre tehetünk szert, jobban megérthetjük belső erősségeinket.Tudásunkat a ""nyolc körre"" és a nyolc báguára alkalmazva harmóniában élhetünk környezetünkkel, elősegíthetjük személyes fejlődésünket.[br] A könnyen érthető, ábrákkal és fotókkal gazdagon illusztrált könyv segítségével megismerhetjük és elsajátíthatjuk a feng shuit, egészen az alapoktól; ellenőrizhetjük, hogy otthonunk energiamezői harmóniában állnak - e saját energiamintáinkkal; fokozhatjuk hatékonyságunkat munkánk során; bátran használhatjuk a kínai zodiákust baráti, családi és munkakapcsolataink jobb megértéséhez.",
            Price = 3200,
            DiscountedPrice = 2560,
            PublishYear = 2004,
            PageNumber = 168,
            PublisherId = 1,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 1, AuthorId = 1 } },
        },

        new Book
        {
            Id = 2,
            Title = "Az én feng shui-kertem",
            Subtitle = "Ötletek kertekhez, teraszokhoz, erkélyekhez ",
            ShortDescription = @"Képzelje azt, hogy kertje egy ruhadarab.A kertnek a ruhadarabhoz hasonlóan ""jól kell állnia"" tulajdonosának.Nézzen egy kicsit más szemmel kertjére, erkélyére vagy teraszára. Minden a helyén van? Tükrözi - e a kert a személyiségét?[br] A kötet segít elmélyedni a feng shui nyújtotta lehetőségekben.Ne gondoljon azonnal teljes átalakításra, éppen az óvatos, kisebb javítások a feng shui erősségei. Varázsolja kertjét oázissá, engedje szabadon szárnyalni képzeletét, váljon eggyé a természettel.Tanuljon mások tapasztalatából, olyan emberekéből, akik már rátaláltak a feng shuira, a harmónia és életöröm forrására.",
            Price = 4900,
            DiscountedPrice = 3920,
            PublishYear = 2008,
            PageNumber = 128,
            PublisherId = 2,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 2, AuthorId = 2 } }
        },
        new Book
        {
            Id = 3,
            Title = "Feng Shui",
            Subtitle = "A természet és az egyensúly kínai tudományával kapcsolatos alapvető tudnivalók",
            ShortDescription = @"Az ember, az ember által létrehozott környezet, valamint a természet összhangjának több évezredes kínai tudománya már a 19.század közepe óta ismert a nyugati világban. Odaadó hívei a szabályrendszer szigorú betartásával alakítják életüket, lakókörnyezetüket, de még bírálói is kénytelenek elismerni, a megállapítások mélyén bonyolult összefüggések rejlenek.[br] [br] A feng shui nem csupán a lakberendezés ügyes tudománya: jelen van benne az animizmus, a taoizmus, a konfucianizmus és a buddhizmus jónéhány eszméje. Rávilágít a látszólag egymástól távol álló dolgok közötti összefüggésekre, fellebbenti a fátylat a misztikus összefüggésekről, rendszerbe foglalva állítja elénk a hajdanvolt bölcsek megfigyeléseit, a geomanciával, numerológiával és asztrológiával foglalkozó tudósok megállapításait.",
            Price = 699,
            PublishYear = 2012,
            PageNumber = 80,
            PublisherId = 3,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 3, AuthorId = 3 } }
        },
        new Book
        {
            Id = 4,
            Title = "Fengsuj a gyakorlatban",
            ShortDescription = @"Fengsuj a gyakorlatban[br]- Olyan ősi filozófiát mutat be, melynek követésével irányíthatjuk a pozitív és a negatív energiákat, és ezzel megváltoztathatjuk életünket és sorsunkat.[br]- Praktikus tanácsokkal lát el otthonunk helyiségeinek elhelyezését és berendezését illetően, melyek segíthetnek céljaink megvalósításában, vágyaink kiteljesítésében.[br]- Bemutatja, hogyan tehetjük kellemesebbé otthonunkat és hogyan javíthatunk általános közérzetünkön a megfelelő színek, anyagok és más díszítőelemek kiválasztásával.[br]- A lakás ideális berendezésére vonatkozó javaslatokkal hozzásegít a jó kapcsolatok, a jól menő üzlet kiépítéséhez, a kielégítő szexuális élethez, a jó egészséghez.",
            Price = 3990,
            PublishYear = 2009,
            PageNumber = 160,
            PublisherId = 4,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 4, AuthorId = 4 } }
        },
        new Book
        {
            Id = 5,
            Title = "François Villon versei",
            ShortDescription = "François Villon válogatott versei.",
            Price = 1650,
            PublishYear = 1999,
            PageNumber = 176,
            PublisherId = 5,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 5, AuthorId = 5 } }
        },
        new Book
        {
            Id = 6,
            Title = "A nyugati környezetben is használható Feng - Shui",
            Subtitle = "Első kötet -Alapfogalmak I.",
            ShortDescription = @"Az elmúlt évezredek során Kelet nagy bölcsei számos tanítással és igazsággal gazdagították az emberiséget. Azt tartották, hogy fejlődésünk célja a tökéletes emberi állapot, a megvilágosodás elérése. A jó energiatérrel, élő és éltető energiákkal rendelkező építmények, helyiségek nagymértékben elősegítik ezt a folyamatot.[br] A feng-shui, ami alapjában véve annyit jelent, hogy az ember összhangban él az őt körülvevő világgal, ennek megvalósításához nyújt aktív és tudatos segítséget.[br] A könyv két szerzője feng - shui mester, szakértő.Munkájukkal egy, az ősi tudásra épülő, de a nyugati életvitel számára is elfogadható új sorozat első kötetét alkották meg.Céljuk, hogy mindazok kezébe és otthonába elkerülhessenek ezek a tanítások, akik szeretnek tanulni, és szívesen tökéletesítik önmagukat, környezetüket valamint kíváncsiak a ""miértekre"".",
            Price = 2100,
            DiscountedPrice = 1680,
            PublishYear = 2006,
            PageNumber = 152,
            PublisherId = 1,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 6, AuthorId = 6 } }
        },
        new Book
        {
            Id = 7,
            Title = "A Feng shui és a siker titka térben és időben",
            Subtitle = "A Repülő csillagok és a kínai sorselemzés művészete",
            ShortDescription = @"Könyvem első részében a Négyoszlopos Sorsmeghatározás különleges módszerét mutatom be, ami újdonság a Kínán kívül élők számára. A Négyoszlopos Sorsmeghatározás klasszikus sorselemzési eljárás, pontos, időpontok szerint behatárolható képet ad az ember képességeiről, lehetőségeiről, élete szerencsés és balszerencsés időszakairól.A technikát néhány híresség és befolyásos politikus sorsának elemzéseivel illusztrálom. Közlöm előzetes jóslataimat az amerikai - iraki összecsapások kimeneteléről az 1990 - 91 - es Öbölháborúban, megtudhatják mekkora szerepe volt az események végeredményére id. Bush elnök és Saddam Hussein sorsának és szerencséjének. Kiderül, milyen végzetes okok vezettek Marilyn Monroe halálához.S amint Karen Carpenter és John Lennon fiatalon elhunyt művészek tragikus sorsának okai, úgy Margaret Thatcher és Mihail Gorbacsov politikai karrierjének alakulása is kikövetkeztethető Sorsuk Négyoszlopából, valamint Szerencseoszlopaikból.[br] A könyv második részében a Feng Shui rejtett szépségeivel foglalkozom, s igyekszem bemutatni a tan kevéssé ismert összefüggéseit és módszereit.Hongkong híres épületeinek Feng Shui elemzésén túl, számos érdekes példán mutatom be, mi mindenre jó a Feng Shui. Szeretném, ha Olvasóim e különleges technika ismeretében boldogabban élhetnének. (Raymond Lo)",
            Price = 2780,
            PublishYear = 2005,
            PageNumber = 228,
            PublisherId = 6,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 7, AuthorId = 7 } }
        },
        new Book
        {
            Id = 8,
            Title = "Feng Shui és kert",
            Subtitle = "A taoizmus és a zen a kertművelésben",
            ShortDescription = @"A távol-keleti kertépítés mind a hobbi-, mind a profi kertész számára olyan elmélyült, mégis egyszerű alapelvekkel szolgál, amelyek segítségével szívvel-lélekkel belevethetjük magunkat az érzékeket gyönyörködtető és üdítő légkörű kert megteremtésébe.[br] Szinte az egész világot beutaztam fengshui - és energetikai szakértőként, és szomorúan kellett tapasztalnom, hogy elveszett az a fő cél, amiért az épületeket, illetve a kerteket építjük - tudniillik, hogy olyan energiával és élettel teli helyet hozzunk létre, ahol feltöltődünk és visszanyerjük életkedvünket. (...) A könyvemben bemutatott ázsiai kertkialakítási és fengshui - alapelveket bármelyik kertben alkalmazhatjuk típustól és nagyságtól függetlenül, legyen az egy virágos láda az ablakunkban vagy egy park.Különös hangsúlyt helyeztem a kövek kiválasztására és elhelyezésére, ahogy azt a taoisták és a zen követői alkalmazták.A ""Beszélgessünk a növényekkel"" című fejezetben leírtak elolvasása után pedig úgy tekintünk majd a növényekre, ahogy eddig még soha.",
            Price = 3580,
            PublishYear = 2004,
            PageNumber = 140,
            PublisherId = 7,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 8, AuthorId = 8 } }
        },
        new Book
        {
            Id = 9,
            Title = "Többváltozós függvények analízise - Bolyai - könyvek",
            Subtitle = "Példatár",
            Price = 2050,
            PublishYear = 2006,
            PageNumber = 360,
            PublisherId = 8,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 9, AuthorId = 9 } }
        },
        new Book
        {
            Id = 10,
            Title = "Feng Shui az irodában és az üzleti életben",
            ShortDescription = @"E könyvben az üzleti Feng Shui gyakorlati művelésének különböző szempontjait és irányelveit igyekszem érthetően felvázolni, hogy a kedves Olvasó az eddig talán kevésbé ismert szempontokról is áttekintést szerezhessen. Ezáltal elkerülheti a hibákat és adott esetben orvosolhatja a bajt, amelyek miatt szembekerülhetett munkatársaival. Még abban az esetben is, ha elbizonytalanodna, mert üzlete nem megy olyan jól, mint ahogy mehetne, az üzleti Feng Shui kínálta kiváló ötletek kimozdítják az energiát pangó helyzetéből, és a kívánt folyásirányba terelik.",
            Price = 2588,
            PublishYear = 2002,
            PageNumber = 120440,
            PublisherId = 7,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 10, AuthorId = 8 } }
        },
        new Book
        {
            Id = 11,
            Title = "A feng shui nagykönyve",
            Subtitle = "1800 képpel illusztrált gyakorlati útmutató",
            ShortDescription = @"Az egészség és a jó közérzet ismereteinek tárháza.[br] - Irányítsd ősi technikákkal és évszázadok bölcsességével tested, lelked és otthonod különleges erőit és tulajdonságait.[br] - Részletes útmutatások a feng shui ősi kínai művészetéhez, gyakorlati tanácsok az elvek alkalmazásához a nyugalmas terek és lelkileg tápláló környezet megteremtése érdekében.[br] - Tisztítsd meg a teret, ahol élsz vagy dolgozol.A tömjén és más füstölők, a víz és a hang erejének egyszerű eszközeivel megmozgathatod a stagnáló energiákat, és otthonodban tavaszi nagytakarítást végezhetsz.[br] - Mindaz, amit tudnod kell ahhoz, hogy otthonodat nyugalommal és kiegyensúlyozott energiával telt, pozitív térré változtasd.",
            Price = 7990,
            PublishYear = 2009,
            PageNumber = 512,
            PublisherId = 9,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 11, AuthorId = 10 } }
        },
        new Book
        {
            Id = 12,
            Title = "Feng Shui nőknek - Feng Shui férfiaknak",
            ShortDescription = @"Ebben a könyvben különleges tematikával mutatom be a Feng Shui egy kis szeletét. Mint látható, a könyv két részből áll. Az egyik fele a nőknek, a másik a férfiaknak szól. Természetesen a nőknek is hasznos - sőt ajánlott - a férfiaknak írt oldalakat elolvasni, hiszen nem ugyanazt a témát magyarázom el kétféleképpen. A témaválasztás is más és más. Nagyon szeretném, ha mind a nők, mind a férfiak - akik eddig kétkedve fogadták a Feng Shuit - kicsit jobban belelátnának e filozófia működésébe.(a Szerző)",
            Price = 1990,
            PublishYear = 2008,
            PageNumber = 152,
            PublisherId = 6,
            CategoryId = 2,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 12, AuthorId = 11 } }
        },
        new Book
        {
            Id = 13,
            Title = "Transzlégzés",
            Subtitle = "Holotróp légzéstechnika - az öngyógyítás új útja",
            ShortDescription = @"A könyv a holotróp légzéstechnika elméletét és gyakorlatát összegzi.A pszichoterápia és az önmegismerés ezen új módszere magába foglalja a mélylélektan különféle irányzatainak elemeit, emellett merít a modern tudatkutatásból, a kulturális antropológiából és a keleti spirituális gyakorlatokból is.[br] A technikát kidolgozó szerzők esetleírásokkal is alátámasztják a holotróp légzés sokrétű terápiás, valamint az önmegismerést, belső fejlődést elősegítő hatását.",
            Price = 2890,
            DiscountedPrice = 2312,
            PublishYear = 2010,
            PageNumber = 256,
            PublisherId = 10,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 13, AuthorId = 12 } }
        },
        new Book
        {
            Id = 14,
            Title = "Megmagyarázhatatlan jelenségek enciklopédiája",
            Subtitle = "Különös jelenségek, furcsa babonák és ősi rejtélyek",
            Price = 4990,
            PublishYear = 2007,
            PageNumber = 144,
            PublisherId = 11,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 14, AuthorId = 13 } }
        },
        new Book
        {
            Id = 15,
            Title = "Buddhizmus és asztrológia",
            Subtitle = "Horoszkópelemzés buddhista megközelítésben",
            Price = 2799,
            PublishYear = 2010,
            PageNumber = 360,
            PublisherId = 12,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 15, AuthorId = 14 } }
        },
        new Book
        {
            Id = 16,
            Title = "Asztrológiaiskola II.Tarot és kínai jóstanfolyamok",
            Price = 1750,
            PublishYear = 2003,
            PageNumber = 88,
            PublisherId = 13,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 16, AuthorId = 15 } }
        },
        new Book
        {
            Id = 17,
            Title = "Mély forrás A pszichológiai asztrológia tizenkét archetípusa",
            Price = 2800,
            PublishYear = 2004,
            PageNumber = 276,
            PublisherId = 1,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 17, AuthorId = 16 } }
        },
        new Book
        {
            Id = 18,
            Title = "Földközeli kalandok",
            Price = 2500,
            DiscountedPrice = 2000,
            PublishYear = 2010,
            PageNumber = 256,
            PublisherId = 14,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 18, AuthorId = 17 } }
        },
        new Book
        {
            Id = 19,
            Title = "Kínai örökhoroszkóp Tervezze meg jövőjét!",
            Price = 499,
            PublishYear = 2009,
            PageNumber = 296,
            PublisherId = 15,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 19, AuthorId = 18 } }
        },
        new Book
        {
            Id = 20,
            Title = "A zodiákus története",
            Price = 3590,
            PublishYear = 2011,
            PageNumber = 228,
            PublisherId = 16,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 20, AuthorId = 19 } }
        },
        new Book
        {
            Id = 21,
            Title = "Sütő András világa",
            Price = 4990,
            PublishYear = 2010,
            PageNumber = 144,
            PublisherId = 17,
            CategoryId = 6
        },
        new Book
        {
            Id = 22,
            Title = "Asztro pszichológia",
            Subtitle = "A Dzsotir Vidjá az ősi indiai asztrológia tanítása",
            Price = 2850,
            PublishYear = 2011,
            PageNumber = 208,
            PublisherId = 18,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 22, AuthorId = 20 } }
        },
        new Book
        {
            Id = 23,
            Title = "Parker Asztrológia",
            Subtitle = "Hiteles és átfogó útmutató az asztrológia tudományához",
            Price = 9900,
            PublishYear = 2011,
            PageNumber = 496,
            PublisherId = 19,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 23, AuthorId = 21 } }
        },
        new Book
        {
            Id = 24,
            Title = "A gyógyulás szelencéje",
            Subtitle = "Az orvosi asztrológia kézikönyve II.kötet",
            Price = 2600,
            PublishYear = 2011,
            PageNumber = 240,
            PublisherId = 1,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 24, AuthorId = 22 } }
        },
        new Book
        {
            Id = 25,
            Title = "Harmonia Universalis",
            Subtitle = "Az asztrológia belső rendje",
            Price = 3900,
            PublishYear = 2012,
            PageNumber = 354,
            PublisherId = 20,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 25, AuthorId = 23 } }
        },
        new Book
        {
            Id = 26,
            Title = "Ájurvédikus asztrológia és marmapunktúra",
            Price = 4800,
            PublishYear = 2012,
            PageNumber = 290,
            PublisherId = 21,
            CategoryId = 3,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 26, AuthorId = 24 } }
        },
        new Book
        {
            Id = 27,
            Title = "Big Shoot",
            Subtitle = "Drámák",
            Price = 2500,
            PublishYear = 2012,
            PageNumber = 222,
            PublisherId = 22,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 27, AuthorId = 25 } }
        },
        new Book
        {
            Id = 28,
            Title = "Az ember tragédiája Jankovics Marcell animációs filmváltozatának képeivel",
            Price = 4990,
            PublishYear = 2011,
            PageNumber = 320,
            PublisherId = 23,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 28, AuthorId = 26 } }
        },
        new Book
        {
            Id = 29,
            Title = "Drámák V.Az Árpád - ház - A békecsászár - Príma környék",
            Price = 3750,
            PublishYear = 2012,
            PageNumber = 320,
            PublisherId = 24,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 29, AuthorId = 27 } }
        },
        new Book
        {
            Id = 30,
            Title = "Kísértetek, rejtelmek, átkok",
            Subtitle = "... egy orvosnő szemével",
            Price = 2200,
            DiscountedPrice = 1760,
            PublishYear = 2011,
            PageNumber = 224,
            PublisherId = 25,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 30, AuthorId = 28 } }
        },
        new Book
        {
            Id = 31,
            Title = "Belépési pont",
            Subtitle = "Útlevél az új világba",
            Price = 2990,
            PublishYear = 2006,
            PageNumber = 286,
            PublisherId = 26,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 31, AuthorId = 29 } }
        },
        new Book
        {
            Id = 32,
            Title = "Két ÜBÜ - dráma",
            Subtitle = "Schall Eszter rajzaival",
            Price = 1990,
            PublishYear = 2011,
            PageNumber = 144,
            PublisherId = 27,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 32, AuthorId = 30 } }
        },
        new Book
        {
            Id = 33,
            Title = "Európai költők antológiája",
            Price = 2980,
            PublishYear = 2003,
            PageNumber = 272,
            PublisherId = 28,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 33, AuthorId = 31 } }
        },
        new Book
        {
            Id = 34,
            Title = "Az igazság odaát van",
            Subtitle = "Pszi - akták",
            Price = 3450,
            PublishYear = 2012,
            PageNumber = 228,
            PublisherId = 29,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 34, AuthorId = 32 } }
        },
        new Book
        {
            Id = 35,
            Title = "Paranormális erők kézikönyve",
            Price = 3500,
            PublishYear = 2011,
            PageNumber = 224,
            PublisherId = 30,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 35, AuthorId = 33 } }
        },
        new Book
        {
            Id = 36,
            Title = "Lelkedhez hűen",
            Subtitle = "A spirituális pszichológia lényege",
            Price = 3290,
            PublishYear = 2012,
            PageNumber = 260,
            PublisherId = 26,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 36, AuthorId = 34 } }
        },
        new Book
        {
            Id = 37,
            Title = "Érzékeken túli észlelés José Silva módszerével",
            Subtitle = "Használjuk mentális erőnket, hogy sikeresek legyünk az élet minden területén!",
            Price = 2499,
            PublishYear = 2010,
            PageNumber = 272,
            PublisherId = 12,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 37, AuthorId = 35 } }
        },
        new Book
        {
            Id = 38,
            Title = "Az alkotó elem",
            Subtitle = "Fedezd fel, mire születtél, és minden megváltozik",
            Price = 3900,
            PublishYear = 2010,
            PageNumber = 336,
            PublisherId = 31,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 38, AuthorId = 36 } }
        },
        new Book
        {
            Id = 39,
            Title = "A materializmus vége",
            Subtitle = "A tudomány és a spiritualitás találkozása a paranormális jelenségek bizonyítékainak fényében",
            Price = 4300,
            PublishYear = 2010,
            PageNumber = 384,
            PublisherId = 32,
            CategoryId = 4,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 39, AuthorId = 37 } }
        },
        new Book
        {
            Id = 40,
            Title = "Kísértetszív",
            Subtitle = "Stephen King élete",
            Price = 3500,
            PublishYear = 2010,
            PageNumber = 408,
            PublisherId = 33,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 40, AuthorId = 42 } }
        },
        new Book
        {
            Id = 41,
            Title = "Egy csecsemő emlékiratai(CD - ROM melléklettel)",
            Subtitle = "Képeskönyv",
            Price = 2900,
            DiscountedPrice = 2320,
            PublishYear = 2007,
            PageNumber = 264,
            PublisherId = 34,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 41, AuthorId = 39 } }
        },
        new Book
        {
            Id = 42,
            Title = "Érettségi, felvételi feladatok: Matematika",
            Price = 1190,
            PublishYear = 2002,
            PageNumber = 214,
            PublisherId = 35,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 42, AuthorId = 40 } }
        },
        new Book
        {
            Id = 43,
            Title = "Általános kémia",
            Price = 9950,
            PublishYear = 2008,
            PageNumber = 520,
            PublisherId = 23,
            CategoryId = 11,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 43, AuthorId = 41 } }
        },
        new Book
        {
            Id = 44,
            Title = "Robert Merle",
            Subtitle = "Egy szenvedélyes élet",
            Price = 3500,
            PublishYear = 2012,
            PageNumber = 356,
            PublisherId = 33,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 44, AuthorId = 42 } }
        },
        new Book
        {
            Id = 45,
            Title = "Lázár Ervin élete és munkássága",
            Price = 2980,
            PublishYear = 2011,
            PageNumber = 392,
            PublisherId = 36,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 45, AuthorId = 43 } }
        },
        new Book
        {
            Id = 46,
            Title = "Laterna magica",
            Price = 3500,
            PublishYear = 2011,
            PageNumber = 480,
            PublisherId = 33,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 46, AuthorId = 44 } }
        },
        new Book
        {
            Id = 47,
            Title = "Fél lábbal a földön",
            Price = 2500,
            PublishYear = 2006,
            PageNumber = 300,
            PublisherId = 37,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 47, AuthorId = 45 } }
        },
        new Book
        {
            Id = 48,
            Title = "Szeretetről, sötétségről",
            Price = 3500,
            PublishYear = 2010,
            PageNumber = 864,
            PublisherId = 33,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 48, AuthorId = 46 } }
        },
        new Book
        {
            Id = 49,
            Title = "A bolygó fénye",
            Subtitle = "Hunyady Sándor arcképe",
            Price = 2900,
            PublishYear = 2011,
            PageNumber = 320,
            PublisherId = 34,
            CategoryId = 6,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 49, AuthorId = 47 } }
        },
        new Book
        {
            Id = 50,
            Title = "Művészet",
            Subtitle = "Mai francia drámák",
            Price = 3700,
            PublishYear = 2010,
            PageNumber = 564,
            PublisherId = 33,
            CategoryId = 7
        },
        new Book
        {
            Id = 51,
            Title = "Maria Quisling",
            Subtitle = "Színdarab 4 részben, 35 jelenetben",
            Price = 1490,
            PublishYear = 2012,
            PageNumber = 88,
            PublisherId = 38,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 51, AuthorId = 48 } }
        },
        new Book
        {
            Id = 52,
            Title = "Valaki jön majd",
            Subtitle = "Hat színmű",
            Price = 3900,
            PublishYear = 2012,
            PageNumber = 416,
            PublisherId = 39,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 52, AuthorId = 49 } }
        },
        new Book
        {
            Id = 53,
            Title = "Pokol",
            Price = 3990,
            PublishYear = 2012,
            PageNumber = 280,
            PublisherId = 29,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 53, AuthorId = 50 } }
        },
        new Book
        {
            Id = 54,
            Title = "Üvegcserepek",
            Price = 1950,
            PublishYear = 2011,
            PageNumber = 144,
            PublisherId = 24,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 54, AuthorId = 51 } }
        },
        new Book
        {
            Id = 55,
            Title = "A pokol színei",
            Subtitle = "Színes pokol - Útvesztő - Isten komédiásai",
            Price = 2800,
            PublishYear = 2011,
            PageNumber = 288,
            PublisherId = 40,
            CategoryId = 7,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 55, AuthorId = 52 } }
        },
        new Book
        {
            Id = 56,
            Title = "A csörgőkígyó útja",
            Price = 1260,
            PublishYear = 2010,
            PageNumber = 88,
            PublisherId = 41,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 56, AuthorId = 53 } }
        },
        new Book
        {
            Id = 57,
            Title = "Száz vers",
            Subtitle = "Kínai, indiai, görög, latin, angol, francia, német, olasz, spanyol, román, dél - amerikai...",
            Price = 3990,
            PublishYear = 2010,
            PageNumber = 264,
            PublisherId = 42,
            CategoryId = 8
        },
        new Book
        {
            Id = 58,
            Title = "Honvágy",
            Price = 1900,
            PublishYear = 2010,
            PageNumber = 112,
            PublisherId = 43,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 58, AuthorId = 54 } }
        },
        new Book
        {
            Id = 59,
            Title = "Goethe Hölderlin Heine versei",
            Price = 1980,
            PublishYear = 2005,
            PageNumber = 232,
            PublisherId = 5,
            CategoryId = 7
        },
        new Book
        {
            Id = 60,
            Title = "Dalok és szonettek",
            Price = 1980,
            PublishYear = 2003,
            PageNumber = 240,
            PublisherId = 5,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 60, AuthorId = 55 } }
        },
        new Book
        {
            Id = 61,
            Title = "Dsida Jenő versei",
            Price = 2380,
            PublishYear = 2003,
            PageNumber = 264,
            PublisherId = 5,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 61, AuthorId = 56 } }
        },
        new Book
        {
            Id = 62,
            Title = "Arany János balladái",
            Price = 1650,
            PublishYear = 2002,
            PageNumber = 160,
            PublisherId = 5,
            CategoryId = 8,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 62, AuthorId = 57 } }
        },
        new Book
        {
            Id = 63,
            Title = "Kínai és japán költők",
            Price = 1480,
            PublishYear = 1999,
            PageNumber = 208,
            PublisherId = 5,
            CategoryId = 8
        },
        new Book
        {
            Id = 64,
            Title = "Matematika 6.tankönyv, bővített változat",
            Price = 2020,
            PublishYear = 2008,
            PageNumber = 304,
            PublisherId = 8,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 64, AuthorId = 58 } }
        },
        new Book
        {
            Id = 65,
            Title = "Matematika 4.Tankönyv, I.kötet",
            Price = 1470,
            PublishYear = 2004,
            PageNumber = 216,
            PublisherId = 8,
            CategoryId = 10,
        },
        new Book
        {
            Id = 66,
            Title = "Szöveges ki(s)számoló feladatok 3.osztályosoknak",
            Price = 890,
            PublishYear = 2008,
            PageNumber = 56,
            PublisherId = 44,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 66, AuthorId = 59 } }
        },
        new Book
        {
            Id = 67,
            Title = "Nagy kérdések: Matematika",
            Price = 3500,
            PublishYear = 2011,
            PageNumber = 208,
            PublisherId = 45,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 67, AuthorId = 60 } }
        },
        new Book
        {
            Id = 68,
            Title = "Nagy kérdések: Világegyetem",
            Price = 3500,
            PublishYear = 2011,
            PageNumber = 208,
            PublisherId = 45,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 68, AuthorId = 61 } }
        },
        new Book
        {
            Id = 69,
            Title = "A számítástudomány alapjai",
            Price = 2900,
            PublishYear = 2006,
            PageNumber = 192,
            PublisherId = 14,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 69, AuthorId = 62 } }
        },
        new Book
        {
            Id = 70,
            Title = "Valószínűségszámítás és matematikai statisztika",
            Price = 2990,
            PublishYear = 2009,
            PageNumber = 336,
            PublisherId = 24,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 70, AuthorId = 63 } }
        },
        new Book
        {
            Id = 71,
            Title = "A szépség geometriája, a geometria szépsége",
            Subtitle = "A rózsaablakok titkai",
            Price = 6800,
            PublishYear = 2012,
            PageNumber = 180,
            PublisherId = 46,
            CategoryId = 10,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 71, AuthorId = 64 } }
        },
        new Book
        {
            Id = 72,
            Title = "Kémiai elemek",
            Subtitle = "Kalandozás a Világegyetem atomjai között",
            Price = 5999,
            PublishYear = 2011,
            PageNumber = 240,
            PublisherId = 17,
            CategoryId = 11,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 72, AuthorId = 65 } }
        },
        new Book
        {
            Id = 73,
            Title = "Száz kémiai mítosz",
            Subtitle = "Tévhitek, félreértések, magyarázatok",
            Price = 4200,
            PublishYear = 2011,
            PageNumber = 596,
            PublisherId = 23,
            CategoryId = 11,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 73, AuthorId = 66 } }
        },
        new Book
        {
            Id = 74,
            Title = "Elválasztástechnikai módszerek elmélete és gyakorlata",
            Price = 5200,
            PublishYear = 2010,
            PageNumber = 280,
            PublisherId = 23,
            CategoryId = 11,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 74, AuthorId = 67 } }
        },
        new Book
        {
            Id = 75,
            Title = "Vizsgálódás a nemzetek jólétének természetéről és okairól I - II.",
            Subtitle = "Az eredeti, teljes szöveg új kiadása",
            Price = 5800,
            PublishYear = 2011,
            PageNumber = 1196,
            PublisherId = 47,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 75, AuthorId = 68 } }
        },
        new Book
        {
            Id = 76,
            Title = "Gazdasági kislexikon és képletgyűjtemény",
            Price = 2910,
            PublishYear = 2003,
            PageNumber = 168,
            PublisherId = 48,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 76, AuthorId = 69 } }
        },
        new Book
        {
            Id = 77,
            Title = "Vállalat és vállalkozás",
            Subtitle = "Vállalkozói környezet - A tulajdonszerkezet változása a gazdasági átmenet időszakában",
            Price = 8000,
            PublishYear = 2012,
            PageNumber = 706,
            PublisherId = 49,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 77, AuthorId = 70 } }
        },
        new Book
        {
            Id = 78,
            Title = "A szocialista rendszer",
            Price = 4990,
            PublishYear = 2012,
            PageNumber = 672,
            PublisherId = 34,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 78, AuthorId = 71 } }
        },
        new Book
        {
            Id = 79,
            Title = "Aktív szabályozás vagy gazdaságpolitikai nihilizmus?",
            Price = 4600,
            PublishYear = 2012,
            PageNumber = 420,
            PublisherId = 23,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 79, AuthorId = 72 } }
        },
        new Book
        {
            Id = 80,
            Title = "Az európai közösségi versenyjog közgazdaságtana",
            Subtitle = "Alapfogalmak, alkalmazások és mérési módszerek",
            Price = 6000,
            PublishYear = 2011,
            PageNumber = 804,
            PublisherId = 50,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 80, AuthorId = 73 } }
        },
        new Book
        {
            Id = 81,
            Title = "A nemzetközi és a világgazdaságtan alapjai",
            Price = 4200,
            PublishYear = 2011,
            PageNumber = 400,
            PublisherId = 47,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 81, AuthorId = 74 } }
        },
        new Book
        {
            Id = 82,
            Title = "A közgazdaságtan alapjai",
            Price = 5980,
            PublishYear = 2011,
            PageNumber = 640,
            PublisherId = 36,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 82, AuthorId = 75 } }
        },
        new Book
        {
            Id = 83,
            Title = "Új közgazdaságtan",
            Subtitle = "A minőség társadalma",
            Price = 3990,
            PublishYear = 2011,
            PageNumber = 360,
            PublisherId = 23,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 83, AuthorId = 76 } }
        },
        new Book
        {
            Id = 84,
            Title = "Gyógynövény embernek, állatnak, növénynek",
            Price = 2200,
            PublishYear = 2001,
            PageNumber = 172,
            PublisherId = 51,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 84, AuthorId = 77 } }
        },
        new Book
        {
            Id = 85,
            Title = "Szivárványkönyv Közjótan és magyar nemzetgazdaság",
            Price = 1800,
            PublishYear = 2010,
            PageNumber = 112,
            PublisherId = 20,
            CategoryId = 12,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 85, AuthorId = 78 } }
        },
        new Book
        {
            Id = 86,
            Title = "Vadbiológiai olvasókönyv",
            Price = 4200,
            PublishYear = 2010,
            PageNumber = 206,
            PublisherId = 51,
            CategoryId = 13,
        },
        new Book
        {
            Id = 87,
            Title = "Emlős ragadozók Magyarországon",
            Price = 3500,
            PublishYear = 2010,
            PageNumber = 240,
            PublisherId = 51,
            CategoryId = 13,
        },
        new Book
        {
            Id = 88,
            Title = "Genetika - Képes enciklopédia",
            Subtitle = "Az élet kémiai alapjai, az evolúció törvényei, a jövő nagy reményei és aggodalmai",
            Price = 5990,
            PublishYear = 2010,
            PageNumber = 232,
            PublisherId = 9,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 88, AuthorId = 79 } }
        },
        new Book
        {
            Id = 89,
            Title = "Génháború",
            Subtitle = "A genetikailag módosított élelmiszerek kockázatai",
            Price = 1450,
            PublishYear = 2004,
            PageNumber = 160,
            PublisherId = 52,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 89, AuthorId = 80 } }
        },
        new Book
        {
            Id = 90,
            Title = "Egy klónozó vallomásai",
            Subtitle = "A klónozást bemutató CD - filmmelléklettel",
            Price = 2800,
            PublishYear = 2004,
            PageNumber = 304,
            PublisherId = 53,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 90, AuthorId = 81 } }
        },
        new Book
        {
            Id = 91,
            Title = "Száműzött",
            Subtitle = "Sötételf - trilógia II.könyv",
            Price = 2490,
            PublishYear = 2004,
            PageNumber = 344,
            PublisherId = 54,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 91, AuthorId = 98 } }
        },
        new Book
        {
            Id = 92,
            Title = "Az élet alapkérdései",
            Subtitle = "Gén, ember, társadalom",
            Price = 1970,
            PublishYear = 2012,
            PageNumber = 210,
            PublisherId = 55,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 92, AuthorId = 82 } }
        },
        new Book
        {
            Id = 93,
            Title = "Nautilus és Sapiens Bevezetés az evolúcióelméletbe",
            Price = 1980,
            PublishYear = 2006,
            PageNumber = 128,
            PublisherId = 56,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 93, AuthorId = 83 } }
        },
        new Book
        {
            Id = 94,
            Title = "Az emberi test",
            Subtitle = "Bevezetés az emberi anatómiába",
            Price = 6990,
            PublishYear = 2011,
            PageNumber = 224,
            PublisherId = 30,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 94, AuthorId = 84 } }
        },
        new Book
        {
            Id = 95,
            Title = "Élő természet: Állatvilág",
            Subtitle = "Földrajzi enciklopédia",
            Price = 2999,
            PublishYear = 2006,
            PageNumber = 186,
            PublisherId = 57,
            CategoryId = 13,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 95, AuthorId = 85 } }
        },
        new Book
        {
            Id = 96,
            Title = "Kukockij esetei",
            Price = 3490,
            PublishYear = 2006,
            PageNumber = 504,
            PublisherId = 58,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 95, AuthorId = 86 } }
        },
        new Book
        {
            Id = 97,
            Title = "Emma lánya",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 512,
            PublisherId = 59,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 97, AuthorId = 87 } }
        },
        new Book
        {
            Id = 98,
            Title = "Rém hangosan és irtó közel",
            Subtitle = "A 2 Oscar - díjra jelölt film alapjául szolgáló regény",
            Price = 2990,
            PublishYear = 2009,
            PageNumber = 388,
            PublisherId = 27,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 98, AuthorId = 88 } }
        },
        new Book
        {
            Id = 99,
            Title = "Az angyalos ház",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 384,
            PublisherId = 59,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 99, AuthorId = 87 } }
        },
        new Book
        {
            Id = 100,
            Title = "Emma fiai",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 384,
            PublisherId = 59,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 100, AuthorId = 87 } }
        },
        new Book
        {
            Id = 101,
            Title = "Emma szerelme",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 408,
            PublisherId = 59,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 101, AuthorId = 87 } }
        },
        new Book
        {
            Id = 102,
            Title = "Az isztambuli fattyú",
            Price = 3600,
            PublishYear = 2009,
            PageNumber = 472,
            PublisherId = 33,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 102, AuthorId = 89 } }
        },
        new Book
        {
            Id = 103,
            Title = "Igazgató úr A Kispesti Textilgyár igazgatójának igaz története",
            Price = 2699,
            PublishYear = 2012,
            PageNumber = 272,
            PublisherId = 12,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 103, AuthorId = 90 } }
        },
        new Book
        {
            Id = 104,
            Title = "Éjszaka történt",
            Price = 2990,
            PublishYear = 2012,
            PageNumber = 212,
            PublisherId = 60,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 104, AuthorId = 91 } }
        },
        new Book
        {
            Id = 105,
            Title = "Bro útja",
            Price = 2480,
            PublishYear = 2007,
            PageNumber = 316,
            PublisherId = 49,
            CategoryId = 15,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 105, AuthorId = 92 } }
        },
        new Book
        {
            Id = 106,
            Title = "A Kaszás vihara A Malazai Bukottak Könyvének regéje VII.",
            Price = 3999,
            PublishYear = 2011,
            PageNumber = 1256,
            PublisherId = 12,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 106, AuthorId = 93 } }
        },
        new Book
        {
            Id = 107,
            Title = "A Hobbit",
            Subtitle = "vagy: Oda - vissza",
            Price = 2900,
            PublishYear = 2012,
            PageNumber = 316,
            PublisherId = 33,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 107, AuthorId = 94 } }
        },
        new Book
        {
            Id = 108,
            Title = "Sebes Jimmy",
            Subtitle = "A Résháború legendája sorozat",
            Price = 1998,
            PublishYear = 2004,
            PageNumber = 368,
            PublisherId = 61,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 108, AuthorId = 95 } }
        },
        new Book
        {
            Id = 109,
            Title = "Tremorlor kapuja",
            Subtitle = "A Malazai Bukottak Könyvének regéje II.",
            Price = 2999,
            PublishYear = 2004,
            PageNumber = 672,
            PublisherId = 12,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 109, AuthorId = 93 } }
        },
        new Book
        {
            Id = 110,
            Title = "Kardok vihara",
            Subtitle = "A tűz és jég dala III.",
            Price = 3499,
            PublishYear = 2012,
            PageNumber = 1216,
            PublisherId = 12,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 110, AuthorId = 96 } }
        },
        new Book
        {
            Id = 111,
            Title = "A Pilis - összeesküvés",
            Price = 3450,
            PublishYear = 2011,
            PageNumber = 276,
            PublisherId = 29,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 111, AuthorId = 97 } }
        },
        new Book
        {
            Id = 112,
            Title = "Vérkőföldek királya Zsoldosok sorozat III.kötete",
            Price = 2490,
            PublishYear = 2007,
            PageNumber = 504,
            PublisherId = 54,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 112, AuthorId = 98 } }
        },
        new Book
        {
            Id = 113,
            Title = "Törött korona",
            Price = 2998,
            PublishYear = 2007,
            PageNumber = 528,
            PublisherId = 61,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 113, AuthorId = 99 } }
        },
        new Book
        {
            Id = 114,
            Title = "A királynő mélyén",
            Subtitle = "Erotikus történelmi kalandregény",
            Price = 2990,
            PublishYear = 2011,
            PageNumber = 192,
            PublisherId = 29,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 114, AuthorId = 100 } }
        },
        new Book
        {
            Id = 115,
            Title = "Varjak lakomája A tűz és jég dala IV.",
            Price = 2999,
            PublishYear = 2012,
            PageNumber = 896,
            PublisherId = 12,
            CategoryId = 16,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 115, AuthorId = 96 } }
        },
        new Book
        {
            Id = 116,
            Title = "Pasipanoptikum",
            Subtitle = "XXI.századi dekameron",
            Price = 2999,
            PublishYear = 2010,
            PageNumber = 224,
            PublisherId = 60,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 116, AuthorId = 101 } }
        },
        new Book
        {
            Id = 117,
            Title = "A leánycsősz",
            Subtitle = "Regény",
            Price = 1790,
            PublishYear = 2012,
            PageNumber = 160,
            PublisherId = 38,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 117, AuthorId = 102 } }
        },
        new Book
        {
            Id = 118,
            Title = "A vadászó préda Mit ér a nő a húspiacon?",
            Price = 2499,
            PublishYear = 2011,
            PageNumber = 288,
            PublisherId = 62,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 118, AuthorId = 103 } }
        },
        new Book
        {
            Id = 119,
            Title = "Vámpírzóna  Halhatatlanok alkonyat után sorozat 5.",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 448,
            PublisherId = 59,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 119, AuthorId = 104 } }
        },
        new Book
        {
            Id = 120,
            Title = "Szenvedélyes örömök Erotika és bujaság",
            Price = 2990,
            PublishYear = 2011,
            PageNumber = 310,
            PublisherId = 11,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 120, AuthorId = 105 } }
        },
        new Book
        {
            Id = 121,
            Title = "Nonstop szerelem",
            Price = 2950,
            PublishYear = 2012,
            PageNumber = 432,
            PublisherId = 24,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 121, AuthorId = 106 } }
        },
        new Book
        {
            Id = 122,
            Title = "Patty Diphusa",
            Subtitle = "Egy pornósztár vallomásai",
            Price = 1900,
            PublishYear = 2011,
            PageNumber = 208,
            PublisherId = 27,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 122, AuthorId = 107 } }
        },
        new Book
        {
            Id = 123,
            Title = "Pajkos mesék 4.Erotikus történetek",
            Price = 2790,
            PublishYear = 2011,
            PageNumber = 336,
            PublisherId = 63,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 123, AuthorId = 108 } }
        },
        new Book
        {
            Id = 124,
            Title = "Angyali játszma",
            Price = 3999,
            PublishYear = 2010,
            PageNumber = 668,
            PublisherId = 59,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 124, AuthorId = 109 } }
        },
        new Book
        {
            Id = 125,
            Title = "A tetovált lány A nemzetközi bestseller Millennium - trilógia első kötete",
            Price = 3290,
            PublishYear = 2012,
            PageNumber = 624,
            PublisherId = 10,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 125, AuthorId = 110 } }
        },
        new Book
        {
            Id = 126,
            Title = "Drága kéj",
            Subtitle = "Egy magyar luxusprostituált és egy budai milliárdos története",
            Price = 2699,
            PublishYear = 2011,
            PageNumber = 224,
            PublisherId = 62,
            CategoryId = 17,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 126, AuthorId = 111 } }
        },
        new Book
        {
            Id = 127,
            Title = "A pokol tornácán",
            Price = 2699,
            PublishYear = 2010,
            PageNumber = 360,
            PublisherId = 12,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 127, AuthorId = 112 } }
        },
        new Book
        {
            Id = 128,
            Title = "Szemérmes barack és gyilkosság  Hannah Swensen titokzatos esetei 7.",
            Price = 2590,
            PublishYear = 2010,
            PageNumber = 304,
            PublisherId = 64,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 128, AuthorId = 113 } }
        },
        new Book
        {
            Id = 129,
            Title = "A bűnös",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 480,
            PublisherId = 59,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 129, AuthorId = 114 } }
        },
        new Book
        {
            Id = 130,
            Title = "Belphegor",
            Subtitle = "A Louvre fantomja",
            Price = 2000,
            PublishYear = 2012,
            PageNumber = 260,
            PublisherId = 25,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 130, AuthorId = 115 } }
        },
        new Book
        {
            Id = 131,
            Title = "A másik férfi",
            Price = 2600,
            PublishYear = 2012,
            PageNumber = 440,
            PublisherId = 33,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 131, AuthorId = 116 } }
        },
        new Book
        {
            Id = 132,
            Title = "Nincs menedék",
            Subtitle = "John koroner nyomoz",
            Price = 1890,
            PublishYear = 2004,
            PageNumber = 320,
            PublisherId = 65,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 132, AuthorId = 117 } }
        },
        new Book
        {
            Id = 133,
            Title = "Halál a felhők között",
            Price = 2200,
            PublishYear = 2010,
            PageNumber = 320,
            PublisherId = 33,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 133, AuthorId = 118 } }
        },
        new Book
        {
            Id = 134,
            Title = "Megtört csend",
            Price = 2800,
            PublishYear = 2012,
            PageNumber = 304,
            PublisherId = 76,
            CategoryId = 18,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 134, AuthorId = 119 } }
        },
        new Book
        {
            Id = 135,
            Title = "A holtak szolgálata Northwind trilógia III.kötet",
            Price = 2490,
            PublishYear = 2004,
            PageNumber = 224,
            PublisherId = 54,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 135, AuthorId = 120 } }
        },
        new Book
        {
            Id = 136,
            Title = "A Frolix - 8 küldötte",
            Price = 2880,
            PublishYear = 2012,
            PageNumber = 224,
            PublisherId = 66,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 136, AuthorId = 121 } }
        },
        new Book
        {
            Id = 137,
            Title = "Pengefutár",
            Subtitle = "Az igazi Blade Runner",
            Price = 2990,
            PublishYear = 2010,
            PageNumber = 288,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 137, AuthorId = 122 } }
        },
        new Book
        {
            Id = 138,
            Title = "Örvény",
            Price = 2990,
            PublishYear = 2011,
            PageNumber = 288,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 138, AuthorId = 123 } }
        },
        new Book
        {
            Id = 139,
            Title = "Nyugtalanság",
            Price = 2990,
            PublishYear = 2011,
            PageNumber = 368,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 139, AuthorId = 124 } }
        },
        new Book
        {
            Id = 140,
            Title = "Régmúlt napok fénye",
            Price = 3490,
            PublishYear = 2011,
            PageNumber = 400,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 140, AuthorId = 125 } }
        },
        new Book
        {
            Id = 141,
            Title = "Pörgés",
            Price = 2990,
            PublishYear = 2007,
            PageNumber = 432,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 141, AuthorId = 123 } }
        },
        new Book
        {
            Id = 142,
            Title = "Éjszakai őrség",
            Subtitle = "Az őrség - tetralógia első kötete",
            Price = 2990,
            PublishYear = 2007,
            PageNumber = 444,
            PublisherId = 67,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 142, AuthorId = 126 } }
        },
        new Book
        {
            Id = 143,
            Title = "A Dűne istencsászára",
            Subtitle = "4.kötet",
            Price = 3600,
            PublishYear = 2004,
            PageNumber = 330,
            PublisherId = 35,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 143, AuthorId = 127 } }
        },
        new Book
        {
            Id = 144,
            Title = "Predator: Betondzsungel",
            Price = 2890,
            PublishYear = 2011,
            PageNumber = 260,
            PublisherId = 35,
            CategoryId = 19,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 144, AuthorId = 128 } }
        },
        new Book
        {
            Id = 145,
            Title = "A gonosz csábítása",
            Price = 2980,
            PublishYear = 2012,
            PageNumber = 464,
            PublisherId = 68,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 145, AuthorId = 129 } }
        },
        new Book
        {
            Id = 146,
            Title = "Túlpart",
            Price = 2490,
            PublishYear = 2007,
            PageNumber = 368,
            PublisherId = 54,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 146, AuthorId = 130 } }
        },
        new Book
        {
            Id = 147,
            Title = "Szarvak",
            Price = 3200,
            PublishYear = 2012,
            PageNumber = 504,
            PublisherId = 33,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 147, AuthorId = 131 } }
        },
        new Book
        {
            Id = 148,
            Title = "Sub Rosa",
            Price = 3499,
            PublishYear = 2012,
            PageNumber = 336,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 148, AuthorId = 132 } }
        },
        new Book
        {
            Id = 149,
            Title = "Csont és bőr",
            Price = 3499,
            PublishYear = 2012,
            PageNumber = 560,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 149, AuthorId = 133 } }
        },
        new Book
        {
            Id = 150,
            Title = "Sasok és angyalok",
            Price = 2490,
            PublishYear = 2004,
            PageNumber = 344,
            PublisherId = 69,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 150, AuthorId = 147 } }
        },
        new Book
        {
            Id = 151,
            Title = "A velencei árulás",
            Price = 3999,
            PublishYear = 2010,
            PageNumber = 656,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 151, AuthorId = 134 } }
        },
        new Book
        {
            Id = 152,
            Title = "A makedón összeesküvés",
            Price = 3499,
            PublishYear = 2012,
            PageNumber = 302,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 152, AuthorId = 135 } }
        },
        new Book
        {
            Id = 153,
            Title = "A Bankár",
            Price = 3499,
            PublishYear = 2011,
            PageNumber = 624,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 153, AuthorId = 136 } }
        },
        new Book
        {
            Id = 154,
            Title = "Holtomiglan",
            Price = 3499,
            PublishYear = 2012,
            PageNumber = 400,
            PublisherId = 59,
            CategoryId = 20,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 154, AuthorId = 137 } }
        },
        new Book
        {
            Id = 155,
            Title = "A birodalom hajnala",
            Price = 3498,
            PublishYear = 2010,
            PageNumber = 624,
            PublisherId = 70,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 155, AuthorId = 138 } }
        },
        new Book
        {
            Id = 156,
            Title = "Férjem, Bár Kochbá",
            Subtitle = "Zsidó és római levelek a II.századból",
            Price = 2900,
            PublishYear = 2004,
            PageNumber = 296,
            PublisherId = 71,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 156, AuthorId = 139 } }
        },
        new Book
        {
            Id = 157,
            Title = "A hölgy és az egyszarvú",
            Price = 2990,
            PublishYear = 2009,
            PageNumber = 296,
            PublisherId = 72,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 157, AuthorId = 140 } }
        },
        new Book
        {
            Id = 158,
            Title = "Milyen édes az élet a pálmafák árnyékában",
            Subtitle = "Legújabb egyiptomi elbeszélések",
            Price = 2600,
            PublishYear = 2007,
            PageNumber = 208,
            PublisherId = 33,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 158, AuthorId = 141 } }
        },
        new Book
        {
            Id = 159,
            Title = "Miksa és Sarolta",
            Subtitle = "Habsburg pár Mexikó trónján",
            Price = 3600,
            PublishYear = 2008,
            PageNumber = 524,
            PublisherId = 33,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 159, AuthorId = 142 } }
        },
        new Book
        {
            Id = 160,
            Title = "Körforgás",
            Price = 2800,
            PublishYear = 2008,
            PageNumber = 568,
            PublisherId = 33,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 160, AuthorId = 143 } }
        },
        new Book
        {
            Id = 161,
            Title = "A velencei bába",
            Price = 3570,
            PublishYear = 2011,
            PageNumber = 280,
            PublisherId = 73,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 161, AuthorId = 144 } }
        },
        new Book
        {
            Id = 162,
            Title = "Medici Katalin vallomásai",
            Price = 3970,
            PublishYear = 2011,
            PageNumber = 552,
            PublisherId = 73,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 162, AuthorId = 145 } }
        },
        new Book
        {
            Id = 163,
            Title = "Assassin's Creed: Testvériség",
            Price = 3790,
            PublishYear = 2011,
            PageNumber = 474,
            PublisherId = 74,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 163, AuthorId = 146 } }
        },
        new Book
        {
            Id = 164,
            Title = "Assassin's Creed: Reneszánsz",
            Price = 3790,
            PublishYear = 2011,
            PageNumber = 480,
            PublisherId = 75,
            CategoryId = 21,
            // BookAuthors = new List<BookAuthor> { new BookAuthor { BookId = 164, AuthorId = 146 } }
        }
        );
    }
}