using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace API.Services
{
    public class LeagueApiService
    {
        private readonly IConfiguration _configuration;
        private readonly string region = "br1";
        private readonly HttpClient _httpClient;
        public LeagueApiService(HttpClient httpClient)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _httpClient = httpClient;
        }

        private void ConfigureHttpClientHeaders(){
            string apiKey = _configuration.GetSection("ApiSettings")["ApiKey"];
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
        }
        

        public async Task<ActionResult<SummonerDTO>> GetSummonerByUsername(string username){
            ConfigureHttpClientHeaders();

            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{username}");
                                                                
            if(httpResponse.IsSuccessStatusCode){
                var summonerDataJson = await httpResponse.Content.ReadAsStringAsync();
                var summonerData = JsonConvert.DeserializeObject<SummonerDTO>(summonerDataJson);

                return summonerData; 
            } else {
                return null;
            }
        }

        public async Task<ActionResult<List<ChampionMasteryDTO>>> GetChampionMasteryBySummonerId(string Id){
            ConfigureHttpClientHeaders();

            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{Id}");

            if(httpResponse.IsSuccessStatusCode){
                var championMasteryDataJson = await httpResponse.Content.ReadAsStringAsync();
                var championMasteryData = JsonConvert.DeserializeObject<List<ChampionMasteryDTO>>(championMasteryDataJson);

                return championMasteryData;
            } else {
                return null;
            }
        }

        public async Task<ActionResult<object>> GetChampionNameByChampionId(long championId)
        {
            ConfigureHttpClientHeaders();

            HttpResponseMessage championResponse = await _httpClient.GetAsync($"http://ddragon.leagueoflegends.com/cdn/11.17.1/data/en_US/champion.json");
            if (championResponse.IsSuccessStatusCode)
            {
                var championsDataResponseJSON = await championResponse.Content.ReadAsStringAsync();
                var championsData = JsonConvert.DeserializeObject<ChampionDTO>(championsDataResponseJSON);

                foreach (var champion in championsData.Data.Where(x => x.Value.Key == championId.ToString()))
                {
                    var championToReturn = champion.Value.Name;
                    return new { ChampionName = championToReturn };
                }

                return null; 
            }
            else
            {
                return null;
            }
        }

        public async Task<ActionResult<List<string>>> GetMatchesByPuuId(string PuuId){
            ConfigureHttpClientHeaders();

            HttpResponseMessage matchesResponse = await _httpClient.GetAsync($"https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/{PuuId}/ids");
            if(matchesResponse.IsSuccessStatusCode){
                var matchesDataResponseJSON = await matchesResponse.Content.ReadAsStringAsync();
                var matchesData = JsonConvert.DeserializeObject<List<string>>(matchesDataResponseJSON);

                return matchesData;
            } else{
                return null;
            }
        }

        public async Task<MatchDTO> GetMatchByMatchId(string MatchId){
            ConfigureHttpClientHeaders();

            HttpResponseMessage matchResponse = await _httpClient.GetAsync($"https://americas.api.riotgames.com/lol/match/v5/matches/{MatchId}");
            if(matchResponse.IsSuccessStatusCode){
                var matchDataResponseJSON = await matchResponse.Content.ReadAsStringAsync();
                var matchData = JsonConvert.DeserializeObject<MatchDTO>(matchDataResponseJSON);

                return matchData;
            } else {
                return null;
            }
        }

    }
}