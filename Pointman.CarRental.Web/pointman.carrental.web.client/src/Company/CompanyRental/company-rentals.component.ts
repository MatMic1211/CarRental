import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../Services/car.service';
import { TranslateService } from '../../../Services/translate.service';

@Component({
  selector: 'app-company-rentals',
  templateUrl: './company-rentals.component.html',
  styleUrls: ['./company-rentals.component.css']
})
export class CompanyRentalsComponent implements OnInit {
  cars: any[] = [];
  errorMessage: string = '';

  constructor(
    private carService: CarService,
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    this.getCars();
  }

  getCars(): void {
    this.carService.getCars().subscribe({
      next: (data) => {
        this.cars = data;
      },
      error: () => {
        this.errorMessage = this.translateService.translate('ERROR_LOADING_DATA');
      }
    });
  }

  deleteCar(id: number): void {
    this.carService.deleteCar(id).subscribe({
      next: () => {
        this.cars = this.cars.filter(car => car.id !== id);
      },
      error: () => {
        this.errorMessage = this.translateService.translate('ERROR_DELETING_CAR');
      }
    });
  }

  translate(key: string): string {
    return this.translateService.translate(key);
  }
}
