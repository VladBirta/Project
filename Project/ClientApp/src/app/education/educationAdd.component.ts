import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Education } from './education.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-education-add',
  templateUrl: './educationAdd.component.html'
})
export class EducationAddComponent {

  public education: Education = <Education>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveEducation() {
    this.http.post(this.baseUrl + 'api/educations', this.education).subscribe(result => {
      this.router.navigateByUrl("/educations");
    }, error => console.error(error))
  }
}
