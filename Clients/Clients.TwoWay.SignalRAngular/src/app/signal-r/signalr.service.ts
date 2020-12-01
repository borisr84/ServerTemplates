import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private _hubConnection: HubConnection;  

  constructor() { 
    this.createConnection();
    this.addCurrentTimeListener();
    this.startConnection();
  }

  private createConnection() {  
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl('https://localhost:5001/calculatorHub')  
      .build();  
  }  

  private startConnection() {
    
    this._hubConnection.start()
    .then(() => console.log('connection started'))
    .catch(error => console.log('Error while creating connection:' + error));
  }

  public sendAddRequest() {
    this._hubConnection.invoke('Add', 3.5, 4).then(res =>
      console.log(res)
    );
  }

  public addCurrentTimeListener = () => {
    this._hubConnection.on('CurrentTime', (response) => {
      console.log(`Current time is: ${response}`)
    })
  }
}
