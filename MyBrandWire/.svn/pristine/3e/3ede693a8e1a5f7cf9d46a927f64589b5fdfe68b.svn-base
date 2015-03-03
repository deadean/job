namespace Model.DASqliteLayer
{
    internal class Constants
    {
        public static string csCreatePressRealiseTable = @"CREATE TABLE [PressRealise] 
                    (
                        [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                        [header] string NOT NULL,
                        [paragraph] string NOT NULL,
                        [fulltext] string NOT NULL,
                        [href] string NULL
                    );";

        public static string csCreateSitesTable = @"CREATE TABLE [Sites] 
                    (
                        [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                        [href] string NOT NULL
                    );";

        public static string csFillSitesTable = @"INSERT INTO [Sites](href) VALUES('http://i-ii.ru/services')";
        
        public static string csFillPressRealiseTable = @"INSERT INTO [PressRealise](header,paragraph,fulltext) VALUES('1Spain tragedy','Train is broken','Full train is broken')";

        public static string csSelectAllPressRealises = @"SELECT * FROM [PressRealise]";
        public static string csSelectAllSites = @"SELECT * FROM [Sites]";

        public static string csUpdatePressRealiseTable = @"UPDATE [PressRealise] SET header='{0}', paragraph='{1}', fulltext='{2}', href='{3}' WHERE id='{4}'";
    }
}
