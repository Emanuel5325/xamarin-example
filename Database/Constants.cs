namespace MauiExample.Business.Database
{
    public static class Constants
    {
        public const string DatabaseFilename = "MauiExampleDatabase.db3";

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
