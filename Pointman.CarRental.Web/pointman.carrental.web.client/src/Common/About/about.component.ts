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
    {logo: 'assets/Images/png/fazi_cars_logo.png' },
    { logo: 'assets/Images/png/mago_cars_logo.png' },
    {logo: 'assets/Images/png/race_cars_24_logo.png'},
    {logo: 'assets/Images/png/spcetrum_cars_logo.png'},
    {logo: 'assets/Images/png/trofeo_logo.png'},
    {logo: 'assets/Images/png/bad_cars_log.png'}
  ];

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }
}
