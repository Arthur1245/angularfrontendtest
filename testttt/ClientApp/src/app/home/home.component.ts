import { Component } from '@angular/core';
import { Button } from 'protractor';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent
{
  public name = "";
  testfunctie()
  {
    this.name = "Arthur";
    
  }
}

