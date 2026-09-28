import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  private readonly http = inject(HttpClient);
  private readonly token =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiJEdvY2hhICRnb2NoYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImdvY2hhQGdtYWlsLmNvbSIsImZpcnN0TmFtZSI6IkdvY2hhIiwibGFzdE5hbWUiOiJnb2NoYSIsImV4cCI6MTc3NTU2ODYzOSwiaXNzIjoiYXV0aC1hcGkuY29tIiwiYXVkIjoiYXV0aC5jb20ifQ.dGB9LWPwhWJvQ6TeYr6caVu7S7D4b65GOCSHlbabxIo';

  constructor() {
    this.http.get('https://localhost:7056/api/Posts').subscribe((data) => {
      console.log(data);
    });

    this.http
      .get('https://localhost:7056/api/Posts/user', {
        headers: { Authorization: `Bearer ${this.token}` },
      })
      .subscribe((data) => {
        console.log(data);
      });
  }
}
