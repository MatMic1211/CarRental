import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../../Services/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  cars: { id: number; model: string; brand: string }[] = [];
  loading: boolean = true;
  errorMessage: string = '';
  newCar = { model: '', brand: '' };
  showModal: boolean = false;
  showEditModal: boolean = false; 
  editCarData: { id: number; model: string; brand: string } = { id: 0, model: '', brand: '' }; 

  constructor(private carService: CarService) { }

  ngOnInit(): void {
    this.loadCars();
  }

  loadCars(): void {
    this.carService.getCars().subscribe({
      next: (data) => {
        this.cars = data;
        this.loading = false;
      },
      error: (error) => {
        this.errorMessage = 'Nie udało się załadować danych. Spróbuj ponownie później.';
        this.loading = false;
      }
    });
  }

  addCar(): void {
    this.carService.addCar(this.newCar).subscribe({
      next: (car) => {
        this.cars.push(car);
        this.closeAddCarModal();
        this.newCar = { model: '', brand: '' };
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Nie udało się dodać samochodu. Spróbuj ponownie.';
      }
    });
  }

  openAddCarModal(): void {
    this.showModal = true;
  }

  closeAddCarModal(): void {
    this.showModal = false;
  }

  deleteCar(id: number): void {
    if (confirm('Czy na pewno chcesz usunąć ten samochód?')) {
      this.carService.deleteCar(id).subscribe({
        next: () => {
          this.cars = this.cars.filter(car => car.id !== id);
          this.errorMessage = '';
        },
        error: (error) => {
          this.errorMessage = 'Nie udało się usunąć samochodu. Spróbuj ponownie.';
        }
      });
    }
  }

  openEditCarModal(car: { id: number; model: string; brand: string }): void {
    this.editCarData = { ...car }; 
    this.showEditModal = true; 
  }

  closeEditCarModal(): void {
    this.showEditModal = false;
  }

  editCar(): void {
    this.carService.updateCar(this.editCarData.id, this.editCarData).subscribe({
      next: (updatedCar) => {
        const index = this.cars.findIndex(car => car.id === updatedCar.id);
        if (index !== -1) {
          this.cars[index] = updatedCar; 
        }
        this.closeEditCarModal(); 
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Nie udało się zaktualizować samochodu. Spróbuj ponownie.';
      }
    });
  }
}
