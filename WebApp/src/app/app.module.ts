import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AnimalRegisterComponent } from './components/animal-register/animal-register.component';
import {MatFormField, MatFormFieldModule} from '@angular/material/form-field';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule, MatOption} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepicker, MatDatepickerModule} from '@angular/material/datepicker';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatChipsModule} from '@angular/material/chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AnimalListComponent } from './components/animal-list/animal-list.component';
import { JwtInterceptor } from '@app/services/token-interceptor.service';
import { ErrorInterceptorService } from '@app/services/error-interceptor.service';
import {LandingPageComponent} from '@app/components/landing-page/landing-page.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { RemindPasswordComponent } from './components/remind-password/remind-password.component';
import { ReportFormComponent } from './components/report-form/report-form.component';
import { AnimalViewComponent } from './components/animal-view/animal-view.component';
import {MatMenuModule} from '@angular/material/menu';
import { FloatingBtnComponent } from './components/floating-btn/floating-btn.component';


@NgModule({
  declarations: [
    AppComponent,
    AnimalRegisterComponent,
    RegistrationComponent,
    LoginComponent,
    AnimalListComponent,
    LandingPageComponent,
    FooterComponent,
    HeaderComponent,
    RemindPasswordComponent,
    ReportFormComponent,
    AnimalViewComponent,
    FloatingBtnComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatChipsModule,
    MatSelectModule,
    MatToolbarModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    MatSnackBarModule,
    MatMenuModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
