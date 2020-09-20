import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {Animal} from '../../models/animal';
import {User} from '@app/models/user';
import {UserService} from '@app/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';
import {NewAnimal} from '@app/models/new-animal';
import {Fur} from '@app/models/fur';
import {AnimalHubService} from '@app/services/animal-hub.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import citiesJson from '@app/models/cities.json' ;
import {FurType} from '@app/models/furType';
import {AnimalType} from '@app/models/animalType';


@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})


export class AnimalRegisterComponent implements OnInit {

  public FurTypeEnum = FurType;
  public AnimalTypeEnum = AnimalType;

  @Output()
  addButtonClick = new EventEmitter<NewAnimal>();
  animal: NewAnimal = new NewAnimal();
  selectedValue: string;
  cities = JSON.parse(JSON.stringify(citiesJson));


  constructor(private animalService: AnimalService,
              private animalHub: AnimalHubService,
              private snackBar: MatSnackBar,
              private userService: UserService,
              private router: Router) {
  }

  ngOnInit(): void {

    this.animalHub.startConnection();
  }

  ngOnDestroy(): void {
    this.animalHub.disconnect();


    if (!this.userService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }

    if (!this.userService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }
  }

  onAddButtonClick(): void {
    this.addButtonClick.emit(this.animal);
    console.log(this.animal);

    this.animalService.addAnimal(this.animal)
      .subscribe(savedAnimal => {
          console.log(savedAnimal);
          this.animalHub.sendAnimal(savedAnimal);
          this.snackBar.open('Gyvūnas sėkmingai pridėtas', '', {duration: 5000});
          this.addButtonClick.emit();
        },
        error => {
          this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
          console.log(error);
        });
  }

  onSubmit(form: NgForm) {
    form.resetForm();

  }


}
