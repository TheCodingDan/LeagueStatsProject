using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SummonerController : BaseAPIController
    {
        private readonly LeagueApiService _leagueApiService;
        public SummonerController(LeagueApiService leagueApiService)
        {
            _leagueApiService = leagueApiService;
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<SummonerDTO>> GetSummonerByNameAsync(string username){
            return await _leagueApiService.GetSummonerByUsername(username);
        }

        [HttpGet("mastery/{id}")]
        public async Task<ActionResult<List<ChampionMasteryDTO>>> GetChampionMasteryById(string id){
            return await _leagueApiService.GetChampionMasteryBySummonerId(id);
        }

        [HttpGet("mastery/champion/{championId}")]
        public async Task<ActionResult<object>> GetChampionNameByChampionId(long championId){
            return await _leagueApiService.GetChampionNameByChampionId(championId);
        }

        [HttpGet("matches/{puuid}")]
        public async Task<ActionResult<List<string>>> GetMatchesByPuuId(string puuid){
            return await _leagueApiService.GetMatchesByPuuId(puuid);
        }

        [HttpGet("match/{matchId}")]
        public async Task<ActionResult<MatchDTO>> GetMatchByMatchId(string matchId){
            return await _leagueApiService.GetMatchByMatchId(matchId);
        }

    }
}