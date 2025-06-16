import { Component } from '@angular/core';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {

  constructor(public translateService: TranslateService) { }


  trustedCompanies = [
    { name: 'Fazi Cars', logo: 'assets/Images/png/fazi_cars_logo.png' },
    { name: 'Mago Cars', logo: 'assets/Images/png/mago_cars_logo.png' },
    { name: 'Race Cars 24', logo: 'assets/Images/png/race_cars_24_logo.png' },
    { name: 'Spectrum Cars', logo: 'assets/Images/png/spcetrum_cars_logo.png' },
    { name: 'Trofeo', logo: 'assets/Images/png/trofeo_logo.png' },
    { name: 'Bad Cars', logo: 'assets/Images/png/bad_cars_log.png' }
  ];

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }
}
