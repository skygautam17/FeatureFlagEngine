
using StackExchange.Redis;
using System.Threading.Tasks;

public class RedisCacheService
{
    private readonly IDatabase _db;
    public RedisCacheService(IConnectionMultiplexer mux){ _db = mux.GetDatabase(); }
    public Task SetAsync(string key,string val)=>_db.StringSetAsync(key,val);
    public async Task<string?> GetAsync(string key)=>await _db.StringGetAsync(key);
}
