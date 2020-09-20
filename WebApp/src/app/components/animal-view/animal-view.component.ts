import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {EditAnimal} from '@app/models/edit-animal';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';
import {switchMap} from 'rxjs/operators';
import {NgForm} from '@angular/forms';
import citiesJson from '@app/models/cities.json';


@Component({
  selector: 'app-animal-view',
  templateUrl: './animal-view.component.html',
  styleUrls: ['./animal-view.component.scss']
})
export class AnimalViewComponent implements OnInit {

  @Output() saveButtonClick = new EventEmitter<EditAnimal>();
  animal: EditAnimal = new EditAnimal();
  cities = JSON.parse(JSON.stringify(citiesJson));

  constructor(private route: ActivatedRoute,
              private router: Router,
              private animalService: AnimalService) {}

  ngOnInit(): void {
     this.route.paramMap.pipe( // combines observable functions
      switchMap((params: ParamMap) => { // cancels previous requests
          // emits Product observable when parameter map changes
          const id = params.get('id'); // gets id parameter from route parameter array
          return this.animalService.getAnimal(id); // returns Observable<Product>
        }
      )).subscribe(animal => { // subscription to observable
      this.animal = animal;
      console.log(this.animal);
    });
  }

  onSaveButtonClick(): void {
    this.saveButtonClick.emit(this.animal);
  }

  onSubmit(newAnimalForm: NgForm) {
    // call the api and patch the data
    this.route.paramMap.pipe( // combines observable functions
      switchMap((params: ParamMap) => { // cancels previous requests
          // emits Product observable when parameter map changes
          const id = params.get('id'); // gets id parameter from route parameter array
          return this.animalService.putAnimal(id, this.animal); // returns Observable<Product>
        }
      )).subscribe(
      res => {
        console.log('Animal updated');
        console.log(this.animal);
        this.router.navigateByUrl('animal/list');
      },
      error =>
      {
        console.log(error);
      });
  }
}
