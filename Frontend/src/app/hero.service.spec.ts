/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HeroService as heroService } from './Hero.service';

describe('Service: Hero', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [heroService]
    });
  });

  it('should ...', inject([heroService], (service: heroService) => {
    expect(service).toBeTruthy();
  }));
});