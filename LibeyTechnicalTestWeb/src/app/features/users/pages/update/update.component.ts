import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class PageUpdateUserComponent implements OnInit {
  documentNumber: string = '';

  constructor(private route: ActivatedRoute) {
    this.documentNumber = this.route.snapshot.paramMap.get('documentNumber') ?? '';
  }

  ngOnInit(): void { }

  submit() { }
}