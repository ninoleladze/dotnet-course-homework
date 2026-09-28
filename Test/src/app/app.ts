import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
 private readonly http = inject(HttpClient);
 private readonly token =
 `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiJG5pbmlrbyAkbGVsYWR6ZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImJyZWd2YW1hcmk5QGdtYWlsLmNvbSIsImZpcnN0TmFtZSI6Im5pbmlrbyIsImxhc3ROYW1lIjoibGVsYWR6ZSIsImV4cCI6MTc3NTU2OTUwNywiaXNzIjoiYXV0aC1hcGkuY29tIiwiYXVkIjoiYXV0aC5jb20ifQ.G_mMR_qI_D0gUBcRQPdteVC1QDPLvCqKgF0bcxlN1ms`;

 constructor() {  
  this.http.get("https://localhost:7056/api/Posts").subscribe((data) => {
    console.log(data);  
  });


  this.http
  .get("https://localhost:7056/api/Posts/user",{
    headers: {
      Authorization: `Bearer ${this.token}`
    }
  })
  .subscribe((data) => {
    console.log(data);  
  });


   }
  }

