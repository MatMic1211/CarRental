import { Component, OnInit, OnDestroy } from '@angular/core';
import { TranslateService } from '../../Services/translate.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit, OnDestroy {
  private images: string[] = [
    './assets/Images/png/MATI_BMW_M3_BRAZOWA.png',
    './assets/Images/png/BMW_TOURING_ZOLTE.png',
    './assets/Images/png/bmw_x5m_zielona.png',
    './assets/Images/png/BMW_M5_LIM_RED_MET.png',
    './assets/Images/png/Mati_BMW_M3_Mietowa.png',
    './assets/Images/png/MERCEDES_AMG45_DREAM.png',
  ];
  currentImageIndex: number = 0;
  backgroundImage: string = this.images[this.currentImageIndex];
  intervalId: any;

  constructor(private translateService: TranslateService) { }

  ngOnInit(): void {
    this.startImageRotation();
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalId);
  }

  startImageRotation(): void {
    this.intervalId = setInterval(() => {
      const mainElement = document.querySelector('main');
      mainElement?.classList.add('fade-in');

      setTimeout(() => {
        this.currentImageIndex = (this.currentImageIndex + 1) % this.images.length;
        this.backgroundImage = this.images[this.currentImageIndex];
        mainElement?.classList.remove('fade-in');
      }, 1000); 
    }, 5000);
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  checkOffer(): void {
    alert('Sprawdzamy ofertę!');
  }
}
