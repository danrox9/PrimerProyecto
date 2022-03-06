import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponentComponent } from './pages/home/home-component/home-component.component';
import { InputFilterComponent } from './components/input-filter/input-filter.component';
import { ListBooksComponent } from './components/list-books/list-books.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BookService } from './services/book.service';
import { CreateBookComponent } from './components/create-book/create-book.component';
import { NgChartsModule } from 'ng2-charts';
import { FaltasService } from './services/faltas.service';
import { EmptyComponentComponent } from './components/empty-component/empty-component.component';
import { CabeceraComponent } from './components/cabecera/cabecera.component';
import { MedioComponent } from './components/medio/medio.component';
import { PieComponent } from './components/pie/pie.component';
import { RocaService } from './services/roca.service';
import { PujaService } from './services/puja.service';
import { InformacionComponenteComponent } from './pages/InformacionComponente/InformacionComponente.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponentComponent,
    InputFilterComponent,
    ListBooksComponent,
    CreateBookComponent,
    EmptyComponentComponent,
    CabeceraComponent,
    MedioComponent,
    PieComponent,
    InformacionComponenteComponent
  ],
  imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule,HttpClientModule,NgChartsModule,FormsModule],
  providers: [BookService, FaltasService, RocaService, PujaService],
  bootstrap: [AppComponent],
})
export class AppModule {}
