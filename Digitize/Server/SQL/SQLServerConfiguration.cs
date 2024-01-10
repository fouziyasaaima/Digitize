namespace Digitize.Server.SQL
{
    public class SQLServerConfiguration
    {
        public SQLServerConfiguration(string mydbvalue) => MyDBValue = mydbvalue;
        public string MyDBValue { get; }
    }
}
