import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Company, CompanyService } from '../../../../Services/companies.service';

@Component({
  selector: 'app-companies-form',
  templateUrl: './companies-form.component.html',
  styleUrls: ['./companies-form.component.css'],
})
export class CompaniesFormComponent implements OnChanges {
  @Input() companyToEdit: Company | null = null;
  @Output() companyAdded = new EventEmitter<Company>();
  @Output() closeForm = new EventEmitter<void>();

  companyForm: FormGroup;
  isSubmitting = false;

  constructor(private fb: FormBuilder, private companyService: CompanyService) {
    this.companyForm = this.fb.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      telephoneNumber: ['', Validators.required],
    });
  }

  ngOnChanges(): void {
    if (this.companyToEdit) {
      this.companyForm.patchValue(this.companyToEdit);
    } else {
      this.companyForm.reset();
    }
  }

  submitForm(): void {
    if (this.companyForm.invalid) {
      return;
    }

    this.isSubmitting = true;
    const companyData: Company = this.companyForm.value;

    if (this.companyToEdit) {
      this.companyService.updateCompany(this.companyToEdit.id, companyData).subscribe({
        next: (updatedCompany) => {
          this.companyAdded.emit(updatedCompany);
          this.closeForm.emit();
          this.isSubmitting = false;
        },
        error: () => {
          alert('Failed to update the company.');
          this.isSubmitting = false;
        },
      });
    } else {
      this.companyService.addCompany(companyData).subscribe({
        next: (newCompany) => {
          this.companyAdded.emit(newCompany);
          this.closeForm.emit();
          this.isSubmitting = false;
        },
        error: () => {
          alert('Failed to add the company.');
          this.isSubmitting = false;
        },
      });
    }
  }

  cancel(): void {
    this.closeForm.emit();
  }
}
