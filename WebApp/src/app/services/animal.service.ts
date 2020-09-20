import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Animal} from '@app/models/animal';
import {NewAnimal} from '@app/models/new-animal';
import {ReportRequestDto} from '@app/models/ReportRequestDto';
import {EditAnimal} from '@app/models/edit-animal';

const headers = new HttpHeaders({
  'Content-Type': 'application/json',
  'Accept': 'application/json'
});

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private animalListUrl = 'https://localhost:5001/api/Animals';

  constructor(private http: HttpClient) { }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.animalListUrl);
  }

  getFilteredAnimals(fromDate: Date, toDate: Date): Observable<Animal[]> {
    return this.http.get<Animal[]>(`${this.animalListUrl}/filter`, {
      params: {
        fromDate: fromDate.toDateString(),
        toDate: toDate.toDateString()
      }
    });
  }

  getAnimal(animalId: string): Observable<EditAnimal> {
    return this.http.get<EditAnimal>(`${this.animalListUrl}/${animalId}`);
  }

  addAnimal(animal: NewAnimal): Observable<Animal> {
    return this.http.post<Animal>(this.animalListUrl, animal, {headers});
  }

  getAnimalYearReport(reportSettings: ReportRequestDto): Observable<any> {
    return this.http.get<any>(`${this.animalListUrl}/Report`,{
      responseType: 'arraybuffer' as 'json',
      headers: headers,
      params: {
        Year: reportSettings.Year.toString(),
        Type: reportSettings.AnimalType.toString()
      }
    });
  }

  getAnimalAct(id: number): Observable<any> {
    return this.http.get<any>(`${this.animalListUrl}/Act/${id}`,{
      responseType: 'arraybuffer' as 'json',
      headers: headers,
    });
  }

  putAnimal(animalId: string, animal: EditAnimal): Observable<EditAnimal>{
    return this.http.put<EditAnimal>(`${this.animalListUrl}/${animalId}`, animal, {headers});
  }

  deleteAnimal(animalId: number): Observable<Animal> {
    return this.http.delete<Animal>(`${this.animalListUrl}/${animalId}`);
  }
}
