import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApiCalls } from './Utils/ApiCalls';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ScrabbleFront';
  lettersToRequest:string="";
  preSelectedLang = '';
  private apiCallsModule:ApiCalls;

  constructor(private translate: TranslateService, private http: HttpClient) {
    this.preSelectedLang = '';    
    this.apiCallsModule = new ApiCalls(http);
  }

  onOptionsSelected(value: string) {
    this.translate.use(value);
  }

  public async requestWordsToBack(){
    try {
      const availableWords = await this.apiCallsModule.GetAsync("");
      return availableWords;
    } catch (ex) {
      console.error(ex);
    }
  }
}

