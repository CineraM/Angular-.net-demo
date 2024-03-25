import { TransactionService } from '../transaction.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Personal } from '../models/personal.Personal';

@Component({
    selector: 'app-personal',
    templateUrl: './personal.component.html',
    styleUrls: ['./personal.component.css']
  })


export class PersonalComp implements OnInit {
    
    personalList: Personal[] = [];

    newPerson: Personal = {
      TipoDoc: '',
      NumeroDoc: '',
      ApPaterno: '',
      ApMaterno: '',
      Nombre1: '',
      Nombre2: '',
      NombreCompleto: '',
      FechaNac: new Date(),
      FechaIngreso: new Date(),
    };

    updatePerson: Personal = {
      TipoDoc: '',
      NumeroDoc: '',
      ApPaterno: '',
      ApMaterno: '',
      Nombre1: '',
      Nombre2: '',
      NombreCompleto: '',
      FechaNac: new Date(),
      FechaIngreso: new Date(),
    };

    constructor(private ts: TransactionService, private router: Router) { }

    ngOnInit(): void {
        this.getPersonal();
      }

    public getPersonal(){
      this.ts.getAllPersonal().subscribe(
        data => {
          this.personalList = data;
        }, err => {console.log(err);}
      );
    }
  
    public openModalAddP() {
      const modelDiv = document.getElementById('addModal');
      if(modelDiv!= null) {
        modelDiv.style.display = 'block';
      } 
    }
  
    public closeModalAddP() {
      const modelDiv = document.getElementById('addModal');
      if(modelDiv!= null) {
        modelDiv.style.display = 'none';
      } 
    }
    
    public submitModalAddP() {

      // if(this.myForm.valid)
      this.ts.postPersonal(this.newPerson).subscribe(
        (success) => {
          if (success) {
            const modelDiv = document.getElementById('addModal');
            if (modelDiv != null) {
              modelDiv.style.display = 'none';
            }
            window.location.reload(); // Reload page on success
          } else {
            console.error("Error creating personal data");
            // Handle error scenario (e.g., display error message)
          }
        }
      );
    }


    public openModalModP(person: Personal) {

      this.updatePerson = person

      const modelDiv = document.getElementById('addModal');
      if(modelDiv!= null) {
        modelDiv.style.display = 'block';
      } 
    }
  
    public closeModalModP() {
      const modelDiv = document.getElementById('addModal');
      if(modelDiv!= null) {
        modelDiv.style.display = 'none';
      } 
    }


    public submitModalModP() {

      // if(this.myForm.valid)
      this.ts.postPersonal(this.newPerson).subscribe(
        (success) => {
          if (success) {
            const modelDiv = document.getElementById('addModal');
            if (modelDiv != null) {
              modelDiv.style.display = 'none';
            }
            window.location.reload(); // Reload page on success
          } else {
            console.error("Error creating personal data");
            // Handle error scenario (e.g., display error message)
          }
        }
      );
    }

}