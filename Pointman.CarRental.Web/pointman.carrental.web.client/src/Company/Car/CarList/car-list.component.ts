import { Component, OnInit } from '@angular/core';
import { CarService, Car } from '../../../../Services/car.service';
import { BrandService, BrandViewModel } from '../../../../Services/brand.service';
import { TranslateService } from '../../../../Services/translate.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  allCars: Car[] = [];
  cars: Car[] = [];
  uniqueBrands: string[] = [];
  selectedBrand: string = '';
  searchQuery: string = '';
  loading: boolean = true;
  errorMessage: string = '';

  newCar = { model: '', brand: '' };
  editCarData: Car = { id: 0, model: '', brand: '' };

  showModal: boolean = false;
  showEditModal: boolean = false;
  showConfirmDeleteModal: boolean = false;

  carToDeleteId: number | null = null;

  currentPage: number = 1;
  itemsPerPage: number = 9;
  totalPages: number = 0;
  totalItems: number = 0;

  constructor(
    private carService: CarService,
    private brandService: BrandService,
    public translateService: TranslateService
  ) { }

  ngOnInit(): void {
    this.loadCars();
    this.loadBrands();
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }

  loadCars(): void {
    this.loading = true;
    this.carService.getCarsPaged(this.currentPage, this.itemsPerPage, this.selectedBrand, this.searchQuery).subscribe({
      next: (response) => {
        this.cars = response.items;
        this.totalItems = response.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'Nie udało się załadować danych. Spróbuj ponownie później.';
        this.loading = false;
      }
    });
  }

  loadBrands(): void {
    this.brandService.getBrands().subscribe({
      next: (brands: BrandViewModel[]) => {
        this.uniqueBrands = brands.map(b => b.name);
      },
      error: () => {
        this.uniqueBrands = [];
      }
    });
  }

  applyFilters(): void {
    this.currentPage = 1;
    this.loadCars();
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
  
  openAddCarModal(): void {
    this.showModal = true;
  }

  closeAddCarModal(): void {
    this.showModal = false;
  }

  addCar(): void {
    this.carService.addCar(this.newCar).subscribe({
      next: () => {
        this.loadCars();
        this.loadBrands();
        this.closeAddCarModal();
        this.newCar = { model: '', brand: '' };
        this.errorMessage = '';
      },
      error: () => {
        this.errorMessage = 'Nie udało się dodać samochodu. Spróbuj ponownie.';
      }
    });
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
        this.loadBrands();
        this.closeEditCarModal();
        this.errorMessage = '';
      },
      error: () => {
        this.errorMessage = 'Nie udało się zaktualizować samochodu. Spróbuj ponownie.';
      }
    });
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
          this.loadBrands();
          this.closeConfirmDeleteModal();
          this.errorMessage = '';
        },
        error: () => {
          this.errorMessage = 'Nie udało się usunąć samochodu. Spróbuj ponownie.';
        }
      });
    }
  }
  changeLanguage(lang: string): void {
    this.translateService.setLanguage(lang);
    this.loadCars();
    this.loadBrands();
  }

  showReservationModal: boolean = false;
  selectedCarId: number | null = null;
  selectedCar: Car | null = null;

  reservationData = {
    startDate: '',
    endDate: '',
    startTime: '',
    endTime: '',
    pickupLocation: '',
    returnLocation: '',
    customerName: ''
  };

  reserveCar(carId: number): void {
    this.selectedCarId = carId;
    this.selectedCar = this.cars.find(c => c.id === carId) || null;
    this.showReservationModal = true;
    this.reservationData = {
      startDate: '',
      endDate: '',
      startTime: '',
      endTime: '',
      pickupLocation: '',
      returnLocation: '',
      customerName: ''
    };
  }

  closeReservationModal(): void {
    this.showReservationModal = false;
    this.selectedCarId = null;
    this.selectedCar = null;
  }

  submitReservation(): void {
    if (
      !this.selectedCarId ||
      !this.reservationData.startDate ||
      !this.reservationData.endDate ||
      !this.reservationData.startTime ||
      !this.reservationData.endTime ||
      !this.reservationData.pickupLocation ||
      !this.reservationData.returnLocation ||
      !this.reservationData.customerName
    ) {
      this.errorMessage = 'Wszystkie pola są wymagane.';
      return;
    }

    if (this.reservationData.endDate < this.reservationData.startDate) {
      this.errorMessage = 'Data zakończenia nie może być wcześniejsza niż rozpoczęcia.';
      return;
    }

    console.log('Rezerwacja samochodu ID:', this.selectedCarId);
    console.log('Dane rezerwacji:', this.reservationData);

    this.closeReservationModal();
  }
}
