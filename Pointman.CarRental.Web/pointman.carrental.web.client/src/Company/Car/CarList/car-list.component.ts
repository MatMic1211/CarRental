import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../../Services/car.service';
import { TranslateService } from '../../../../Services/translate.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  cars: { id: number; model: string; brand: string }[] = [];
  filteredCars: { id: number; model: string; brand: string }[] = [];
  uniqueBrands: string[] = [];
  loading: boolean = true;
  errorMessage: string = '';
  newCar = { model: '', brand: '' };
  showModal: boolean = false;
  showEditModal: boolean = false;
  showConfirmDeleteModal: boolean = false;
  editCarData: { id: number; model: string; brand: string } = { id: 0, model: '', brand: '' };
  carToDeleteId: number | null = null;

  searchQuery: string = '';
  selectedBrand: string = '';

  currentPage: number = 1;
  itemsPerPage: number = 9;
  totalPages: number = 0;


  constructor(private carService: CarService, public translateService: TranslateService) { }

  ngOnInit(): void {
    this.loadCars();
  }

  getTranslation(key: string): string {
    return this.translateService.translate(key);
  }
  changeLanguage(lang: string): void {
    this.translateService.setLanguage(lang);
    this.applyFilters(); 
  }

  loadCars(): void {
    this.carService.getCars().subscribe({
      next: (data) => {
        this.cars = data;
        this.filteredCars = [...this.cars];
        this.updateUniqueBrands();
        this.loading = false;
        this.totalPages = Math.ceil(this.filteredCars.length / this.itemsPerPage);
      },
      error: () => {
        this.errorMessage = 'Nie udało się załadować danych. Spróbuj ponownie później.';
        this.loading = false;
      }
    });
  }

  updateUniqueBrands(): void {
    this.uniqueBrands = [...new Set(this.cars.map(car => car.brand))];
  }

  applyFilters(): void {
    this.filteredCars = this.cars.filter(car => {
      const matchesSearch = car.model.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
        car.brand.toLowerCase().includes(this.searchQuery.toLowerCase());
      const matchesBrand = this.selectedBrand ? car.brand === this.selectedBrand : true;
      return matchesSearch && matchesBrand;
    });
    this.totalPages = Math.ceil(this.filteredCars.length / this.itemsPerPage);
    this.currentPage = 1;
  }

  getPaginatedCars(): { id: number; model: string; brand: string }[] {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    return this.filteredCars.slice(start, end);
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  getPageNumbers(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  addCar(): void {
    this.carService.addCar(this.newCar).subscribe({
      next: (car) => {
        this.cars.push(car);
        this.updateUniqueBrands();
        this.applyFilters(); 
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
          this.cars = this.cars.filter(car => car.id !== this.carToDeleteId);
          this.updateUniqueBrands(); 
          this.applyFilters();
          this.closeConfirmDeleteModal();
          this.errorMessage = '';
        },
        error: () => {
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
        this.updateUniqueBrands(); 
        this.applyFilters();
        this.closeEditCarModal();
        this.errorMessage = '';
      },
      error: () => {
        this.errorMessage = 'Nie udało się zaktualizować samochodu. Spróbuj ponownie.';
      }
    });
  }
}
