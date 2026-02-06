using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class AuctionSvcHttpClient(HttpClient _httpClient, IConfiguration _config)
{
	public async Task<List<Item>> GetItemsFromSearchDb()
	{
		var lastUpdate = await  DB.Find<Item, string>()
															.Sort(x => x.Descending(x => x.UpdatedAt))
															.Project(x => x.UpdatedAt.ToString())
															.ExecuteFirstAsync();

		var auctionServer = _config["AuctionServiceUrl"] + "/api/auctions?date=" + lastUpdate;

		return await _httpClient.GetFromJsonAsync<List<Item>>(auctionServer);
	}
}
