import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Summoner } from './_models/summoner';
import { Mastery } from './_models/mastery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  summoner: Summoner | undefined;
  mastery: Mastery[] = [];

  constructor(private httpClient: HttpClient){}

  ngOnInit(): void {

  }


}
