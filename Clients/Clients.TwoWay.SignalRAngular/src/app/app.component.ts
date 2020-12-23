import { Component } from '@angular/core';
import { SignalrService } from './signal-r/signalr.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private _signalR : SignalrService;

  title = 'SignalR Client';

  constructor(signalR : SignalrService)
  {
    this._signalR = signalR;
  }

  onAdd() : void
  {
    this._signalR.sendAddRequest();
  }

}
