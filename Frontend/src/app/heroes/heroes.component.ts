import { Component, OnInit } from '@angular/core';
import { hero } from '../hero';
import { HeroService } from '../Hero.service';
import { MessagesService } from '../messages.service';

import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})
export class HeroesComponent implements OnInit {
  heroFromInterface: hero = {
    id: 1,
    name: 'firstHero'
  }
  private searchTerms = new Subject<string>();

  thisHeroesArray: hero[] = [];

  getHeroes(): void {
    this.heroService.getHeroes().subscribe(heroesArray => {
      this.thisHeroesArray = heroesArray;
      this.selectedHero = this.thisHeroesArray[0];
    });
  }

  search(term: string): void {
    this.searchTerms.next(term);
  }

  selectedHero?: hero;
  onSelect(hero: hero): void {
    this.selectedHero = hero;
    this.messageService.add('wybrano hero o nazwie:' + hero.name)
  }

  constructor(private heroService: HeroService, private messageService: MessagesService) { }

  ngOnInit() {
    this.getHeroes();
  }

}