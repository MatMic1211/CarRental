import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TranslateService {
  private translations: any = {
    en: {
      HOME: 'Home',
      COMPANIES: 'Companies',
      ABOUT: 'About',
      CONTACT: 'Contact',
      SIGN_IN: 'Sign In',
      LANGUAGE: 'Language',
    },
    pl: {
      HOME: 'Strona główna',
      COMPANIES: 'Firmy',
      ABOUT: 'O nas',
      CONTACT: 'Kontakt',
      SIGN_IN: 'Zaloguj się',
      LANGUAGE: 'Język',
    },
  };

  private currentLang: string = 'en';

  setLanguage(lang: string) {
    this.currentLang = lang;
  }

  translate(key: string): string {
    return this.translations[this.currentLang]?.[key] || key;
  }

  getCurrentLanguage(): string {
    return this.currentLang;
  }
}
