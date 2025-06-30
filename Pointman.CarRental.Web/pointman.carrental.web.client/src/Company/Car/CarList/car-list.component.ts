import { Component, OnInit } from '@angular/core';
import { CarService, Car } from '../../../../Services/car.service';
import { TranslateService } from '../../../../Services/translate.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  cars: Car[] = [];
  uniqueBrands: string[] = [];
  loading: boolean = true;
  errorMessage: string = '';
  newCar = { model: '', brand: '' };
  showModal: boolean = false;
  showEditModal: boolean = false;
  showConfirmDeleteModal: boolean = false;
  editCarData: Car = { id: 0, model: '', brand: '' };
  carToDeleteId: number | null = null;

  searchQuery: string = '';
  selectedBrand: string = '';

  currentPage: number = 1;
  itemsPerPage: number = 9;
  totalPages: number = 0;
  totalItems: number = 0;

  constructor(private carService: CarService, public translateService: TranslateService) { }

  ngOnInit(): void {
    this.loadCars();
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  changeLanguage(lang: string): void {
    this.translateService.setLanguage(lang);
    this.loadCars(); 
  }

  loadCars(): void {
    this.loading = true;
    this.carService.getCarsPaged(this.currentPage, this.itemsPerPage).subscribe({
      next: (response) => {
        this.cars = response.items;
        this.totalItems = response.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
        this.updateUniqueBrands();
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'Nie udało się załadować danych. Spróbuj ponownie później.';
        this.loading = false;
      }
    });
  }

  updateUniqueBrands(): void {
    const brandSet = new Set(this.cars.map(car => car.brand));
    this.uniqueBrands = Array.from(brandSet);
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.loadCars();
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadCars();
    }
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.loadCars();
    }
  }

  getPageNumbers(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  addCar(): void {
    this.carService.addCar(this.newCar).subscribe({
      next: () => {
        this.loadCars();
        this.closeAddCarModal();
        this.newCar = { model: '', brand: '' };
        this.errorMessage = '';
      },
      error: () => {
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

  openConfirmDeleteModal(id: number): void {
    this.carToDeleteId = id;
    this.showConfirmDeleteModal = true;
  }

  closeConfirmDeleteModal(): void {
    this.carToDeleteId = null;
    this.showConfirmDeleteModal = false;
  }

  confirmDeleteCar(): void {
    if (this.carToDeleteId !== null) {
      this.carService.deleteCar(this.carToDeleteId).subscribe({
        next: () => {
          this.loadCars();
          this.closeConfirmDeleteModal();
          this.errorMessage = '';
        },
        error: () => {
          this.errorMessage = 'Nie udało się usunąć samochodu. Spróbuj ponownie.';
        }
      });
    }
  }

  openEditCarModal(car: Car): void {
    this.editCarData = { ...car };
    this.showEditModal = true;
  }

  closeEditCarModal(): void {
    this.showEditModal = false;
  }

  editCar(): void {
    this.carService.updateCar(this.editCarData.id, this.editCarData).subscribe({
      next: () => {
        this.loadCars();
        this.closeEditCarModal();
        this.errorMessage = '';
      },
      error: () => {
        this.errorMessage = 'Nie udało się zaktualizować samochodu. Spróbuj ponownie.';
      }
    });
  }
}
