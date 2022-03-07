import { Component, OnInit, Input } from '@angular/core';
import { hero } from '../hero';

@Component({
  selector: 'app-selected-hero-details',
  templateUrl: './selected-hero-details.component.html',
  styleUrls: ['./selected-hero-details.component.scss']
})
export class SelectedHeroDetailsComponent implements OnInit {

  @Input() selectedHeroInComponent?: hero;

  constructor() { }

  ngOnInit() {
  }

}
