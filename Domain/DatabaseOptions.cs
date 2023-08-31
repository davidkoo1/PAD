namespace Domain
{
    public class DatabaseOptions
    {
#if DEBUG
        public const string databaseString = @"Data Source=DESKTOP-IQ404L4;Initial Catalog=Postdb;Integrated Security=true;";
#endif

#if RELEASE
        public readonly string _databaseName = @"";
#endif

    }
}
