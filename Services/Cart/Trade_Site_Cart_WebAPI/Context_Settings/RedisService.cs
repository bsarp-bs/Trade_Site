using StackExchange.Redis;

namespace Trade_Site_Cart_WebAPI.Context_Settings
{
    public class RedisService
    {
        public string _host { get; set; }

        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(RedisSettings settings)
        {
            _host = settings.Host;
            _port = settings.Port;
            
        }

       public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

       public IDatabase GetDatabase(int db = 0) => _connectionMultiplexer.GetDatabase(db);
    }
}
