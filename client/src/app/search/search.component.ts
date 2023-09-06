import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Summoner } from '../_models/summoner';
import { Mastery } from '../_models/mastery';
import { Champion } from '../_models/champion';
import { Match } from '../_models/match';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  model: any = {};
  summoner: Summoner | undefined;
  mastery: Mastery[] = [];
  champion: string | undefined;
  matches: string[] = [];
  match: Match | undefined;
  matchesList: Match[] = [];


  constructor(private httpClient: HttpClient){}
  

  getSummoner(username: string){
    this.httpClient.get<Summoner>("https://localhost:7085/api/Summoner/" + username).subscribe({
      next: response => {
        this.summoner = response;
        this.getChampionMastery(this.summoner.id)
      },
      error: error => console.log(error),
      complete: () => console.log('getSummoner has completed')
    });

    
    
  }

  getChampionMastery(id: string){
    this.httpClient.get<Mastery[]>("https://localhost:7085/api/Summoner/mastery/" + id).subscribe({
      next: response => {
        this.mastery = response
        this.getChampionName(this.mastery[0].championId)
      },
      error: error => console.log(error),
      complete: () => console.log('getChampionMastery has completed')
    })
  }

  getChampionName(championId: number){
    this.httpClient.get<any>("https://localhost:7085/api/Summoner/mastery/champion/" + championId).subscribe({
      next: response => this.champion = response.championName,
      error: error => console.log(error),
      complete: () => console.log('getChampionName has completed')
    })
  }

  getMatches(puuId: string){
    this.httpClient.get<string[]>("https://localhost:7085/api/Summoner/matches/" + puuId).subscribe({
      next: response => {
        this.matches = response;
        for(let i = 0; i<=19; i++){
          this.getMatch(response[i])
        }
      },
      error: error => console.log(error),
      complete: () => console.log("getMatches has completed")
    })
  }

  getMatch(matchId: string){
    this.httpClient.get<Match>("https://localhost:7085/api/Summoner/match/" + matchId).subscribe({
      next: response => {
        this.match = response;
        this.matchesList.push(this.match);
      },
      error: error => console.log(error),
      complete: () => console.log("getMatch has completed")
    })
  }

}
