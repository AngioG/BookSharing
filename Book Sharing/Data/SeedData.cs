using Microsoft.AspNetCore.Identity;
using Book_Sharing.Models;

namespace Book_Sharing.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceScope scope)
        {
            var UserContext = scope.ServiceProvider.GetService<UserDbContext>();

            if (!UserContext.Roles.Any())
            {
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                if (roleManager == null)
                    throw new Exception("roleManager is null");

                if (!await roleManager.RoleExistsAsync("Pending"))
                    await roleManager.CreateAsync(new IdentityRole("Pending"));

                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new IdentityRole("User"));

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var context = scope.ServiceProvider.GetService<DataDbContext>();
            if (!context.Regioni.Any())
            {
                await context.Regioni.AddRangeAsync(
                    new Regione[] {
                        new Regione{
                        Nome = "Abruzzo",
                    },
new Regione{
                        Nome = "Basilicata",
                    },
                        new Regione{
                        Nome = "Calabria",
                    },
new Regione{
                        Nome = "Campania",
                    },
new Regione{
                        Nome = "Emilia-Romagna",
                    },
new Regione{
                        Nome = "Friuli-Venezia Giulia",
                    },
new Regione{
                        Nome = "Lazio",
                    },
new Regione{
                        Nome = "Liguria",
                    },
new Regione{
                        Nome = "Lombardia",
                    },
new Regione{
                        Nome = "Marche",
                    },
new Regione{
                        Nome = "Molise",
                    },
new Regione{
                        Nome = "Piemonte",
                    },
new Regione{
                        Nome = "Puglia",
                    },
new Regione{
                        Nome = "Sardegna",
                    },
new Regione{
                        Nome = "Sicilia",
                    },
new Regione{
                        Nome = "Toscana",
                    },
new Regione{
                        Nome = "Trentino-Alto Adige",
                    },
new Regione{
                        Nome = "Umbria",
                    },
new Regione{
                        Nome = "Valle d'Aosta",
                    },
new Regione{
                        Nome = "Veneto",
                    }});
                await context.SaveChangesAsync();
            }

            if (!context.Province.Any())
            {
                await context.Province.AddRangeAsync(
                     new Provincia[] {
                        new Provincia{
                        Nome = "L'aquila",
                        Sigla = "AQ",
                        fkRegione = 1
                    },
                        new Provincia{
                        Nome = "Teramo",
                        Sigla = "TE",
                        fkRegione = 1
                    },
                        new Provincia{
                        Nome = "Pescara",
                        Sigla = "PE",
                        fkRegione = 1
                    },
                        new Provincia{
                        Nome = "Chieti",
                        Sigla = "CH",
                        fkRegione = 1
                    },
                        new Provincia{
                        Nome = "Matera",
                        Sigla = "MT",
                        fkRegione = 2
                    },
                        new Provincia{
                        Nome = "Potenza",
                        Sigla = "PZ",
                        fkRegione = 2
                    },
                     new Provincia{
                        Nome = "Catanzaro",
                        Sigla = "CZ",
                        fkRegione = 3
                    },
                        new Provincia{
                        Nome = "Cosenza",
                        Sigla = "CS",
                        fkRegione = 3
                    },
                        new Provincia{
                        Nome = "Crotone",
                        Sigla = "KR",
                        fkRegione = 3
                    },
                        new Provincia{
                        Nome = "Reggio Calabria",
                        Sigla = "VV",
                        fkRegione = 3
                    },
                        new Provincia{
                        Nome = "Avellino",
                        Sigla = "AV",
                        fkRegione = 4
                    },
                        new Provincia{
                        Nome = "Benevento",
                        Sigla = "BN",
                        fkRegione = 4
                    },
                        new Provincia{
                        Nome = "Caserta",
                        Sigla = "CE",
                        fkRegione = 4
                    },
                        new Provincia{
                        Nome = "Napoli",
                        Sigla = "NA",
                        fkRegione = 4
                    },
                        new Provincia{
                        Nome = "Salerno",
                        Sigla = "SA",
                        fkRegione = 4
                    },
                        new Provincia{
                        Nome = "Bologna",
                        Sigla = "BO",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Ferrara",
                        Sigla = "FE",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Forlì-Cesena",
                        Sigla = "FC",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Modena",
                        Sigla = "MO",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Parma",
                        Sigla = "PR",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Piacenza",
                        Sigla = "PC",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Ravenna",
                        Sigla = "RA",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Reggio Emilia",
                        Sigla = "RE",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Rimini",
                        Sigla = "RN",
                        fkRegione = 5
                    },
                        new Provincia{
                        Nome = "Gorizia",
                        Sigla = "GO",
                        fkRegione = 6
                    },
                        new Provincia{
                        Nome = "Pordenone",
                        Sigla = "PN",
                        fkRegione = 6
                    },
                        new Provincia{
                        Nome = "Trieste",
                        Sigla = "TS",
                        fkRegione = 6
                    },
                        new Provincia{
                        Nome = "Udine",
                        Sigla = "UD",
                        fkRegione = 6
                    },
                        new Provincia{
                        Nome = "Frosinone",
                        Sigla = "FR",
                        fkRegione = 7
                    },
                     new Provincia{
                        Nome = "Latina",
                        Sigla = "LT",
                        fkRegione = 7
                    },
                        new Provincia{
                        Nome = "Rieti",
                        Sigla = "RI",
                        fkRegione = 7
                    },
                        new Provincia{
                        Nome = "Roma",
                        Sigla = "RM",
                        fkRegione = 7
                    },
                        new Provincia{
                        Nome = "Viterbo",
                        Sigla = "VT",
                        fkRegione = 7
                    },
                        new Provincia{
                        Nome = "Genova",
                        Sigla = "GE",
                        fkRegione = 8
                    },
                        new Provincia{
                        Nome = "Imperia",
                        Sigla = "IM",
                        fkRegione = 8
                    },
                        new Provincia{
                        Nome = "La Spezia",
                        Sigla = "SP",
                        fkRegione = 8
                    },
                        new Provincia{
                        Nome = "Savina",
                        Sigla = "SV",
                        fkRegione = 8
                    },
                        new Provincia{
                        Nome = "Bergamo",
                        Sigla = "BG",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Brescia",
                        Sigla = "BS",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Como",
                        Sigla = "CO",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Cremona",
                        Sigla = "CR",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Lecco",
                        Sigla = "LC",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Lodi",
                        Sigla = "LO",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Mantova",
                        Sigla = "MN",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Milano",
                        Sigla = "MI",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Monza e Brianza",
                        Sigla = "MB",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Pavia",
                        Sigla = "PV",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Sondrio",
                        Sigla = "SO",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Varese",
                        Sigla = "VA",
                        fkRegione = 9
                    },
                        new Provincia{
                        Nome = "Ancona",
                        Sigla = "AN",
                        fkRegione = 10
                    },
                        new Provincia{
                        Nome = "Ascoli Piceno",
                        Sigla = "AP",
                        fkRegione = 10
                    },
                        new Provincia{
                        Nome = "Fermo",
                        Sigla = "FM",
                        fkRegione = 10
                    },
                        new Provincia{
                        Nome = "Macerata",
                        Sigla = "MC",
                        fkRegione = 10
                    },
                        new Provincia{
                        Nome = "Pesaro e Urbino",
                        Sigla = "PU",
                        fkRegione = 10
                    },
                        new Provincia{
                        Nome = "Campobasso",
                        Sigla = "CB",
                        fkRegione = 11
                    },
                        new Provincia{
                        Nome = "Isernia",
                        Sigla = "IS",
                        fkRegione = 11
                    },
                        new Provincia{
                        Nome = "Alessandria",
                        Sigla = "AL",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Asti",
                        Sigla = "AT",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Biella",
                        Sigla = "BI",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Cuneo",
                        Sigla = "CN",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Novara",
                        Sigla = "NO",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Torino",
                        Sigla = "TO",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Verbano-Cusio-Ossola",
                        Sigla = "VB",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Vercelli",
                        Sigla = "VC",
                        fkRegione = 12
                    },
                        new Provincia{
                        Nome = "Bari",
                        Sigla = "BA",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Barletta-Andria-Trani",
                        Sigla = "BT",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Brindisi",
                        Sigla = "BR",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Foggia",
                        Sigla = "FG",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Lecce",
                        Sigla = "LE",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Taranto",
                        Sigla = "TA",
                        fkRegione = 13
                    },
                        new Provincia{
                        Nome = "Cagliari",
                        Sigla = "CA",
                        fkRegione = 14
                    },
                        new Provincia{
                        Nome = "Nuoro",
                        Sigla = "NU",
                        fkRegione = 14
                    },
                        new Provincia{
                        Nome = "Oristano",
                        Sigla = "OR",
                        fkRegione = 14
                    },
                        new Provincia{
                        Nome = "Sassari",
                        Sigla = "SS",
                        fkRegione = 14
                    },
                        new Provincia{
                        Nome = "Sud Sardegna",
                        Sigla = "SU",
                        fkRegione = 14
                    },
                        new Provincia{
                        Nome = "Agrigento",
                        Sigla = "AG",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Caltanissetta",
                        Sigla = "CL",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Catania",
                        Sigla = "CT",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Enna",
                        Sigla = "EN",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Messina",
                        Sigla = "ME",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Palermo",
                        Sigla = "PA",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Ragusa",
                        Sigla = "RG",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Siracusa",
                        Sigla = "SR",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Trapani",
                        Sigla = "TP",
                        fkRegione = 15
                    },
                        new Provincia{
                        Nome = "Bolzano",
                        Sigla = "BZ",
                        fkRegione = 16
                    },
                        new Provincia{
                        Nome = "Trento",
                        Sigla = "TN",
                        fkRegione = 16
                    },
                        new Provincia{
                        Nome = "Arezzo",
                        Sigla = "AR",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Firenze",
                        Sigla = "FI",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Grosseto",
                        Sigla = "GR",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Livorno",
                        Sigla = "LI",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Lucca",
                        Sigla = "LU",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Massa-Carrara",
                        Sigla = "MS",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Pisa",
                        Sigla = "PI",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Prato",
                        Sigla = "PO",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Siena",
                        Sigla = "SI",
                        fkRegione = 17
                    },
                        new Provincia{
                        Nome = "Perugia",
                        Sigla = "PG",
                        fkRegione = 18
                    },
                        new Provincia{
                        Nome = "Terni",
                        Sigla = "TR",
                        fkRegione = 18
                    },
                        new Provincia{
                        Nome = "Aosta",
                        Sigla = "AO",
                        fkRegione = 19
                    },
                        new Provincia{
                        Nome = "Belluno",
                        Sigla = "BL",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Padova",
                        Sigla = "PD",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Rovigo",
                        Sigla = "RO",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Treviso",
                        Sigla = "TV",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Venezia",
                        Sigla = "VE",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Verona",
                        Sigla = "VR",
                        fkRegione = 20
                    },
                        new Provincia{
                        Nome = "Vicenza",
                        Sigla = "VI",
                        fkRegione = 20
                    }});
                await context.SaveChangesAsync();
            }

        }
    }
}
