import { TransactionService } from '../service/uiService.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css']
  })


export class Test implements OnInit {
    
    list = []

    constructor(private ts: TransactionService, private router: Router) { }

    ngOnInit(): void {
        console.log(this.ts.getAllPersonal().subscribe(data => {
          console.log(data);
        }));
      }

    public testAPI(){
        console.log(this.ts.getAllPersonal().subscribe(data => {
            console.log(data);
          }));
    }
}