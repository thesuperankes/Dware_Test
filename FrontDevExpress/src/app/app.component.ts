import { Component } from '@angular/core';

import * as esMessages from "devextreme/localization/messages/es.json";
import { locale, loadMessages } from "devextreme/localization";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Billing';

  constructor(){
    loadMessages(esMessages);
    locale('es');
  }
  
  helloWorld(){
    console.log("Correcto");
  }
}
