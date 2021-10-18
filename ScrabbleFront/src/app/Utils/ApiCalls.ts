import { HttpClient, HttpHeaders } from '@angular/common/http';

export class ApiCalls {
  private Http: HttpClient;

  constructor(http: HttpClient) {
    this.Http = http;
  }

  private generateHeaders(): HttpHeaders {
    
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
      .set('Access-Control-Allow-Origin', '*')

    return headers;
  }

  public async GetAsync(url: string) {
    let items: any = null;
    
    try {
      const headers = this.generateHeaders();
      items = await this.Http.get(url, { headers: headers }).toPromise();
    } 
    catch (ex) {
      console.error(ex);
    }

    return items;
  }

  public async PostAsync(url: string, body: any) {
    let items: any = null;
    
    try {
      const headers = this.generateHeaders();
      items = await this.Http.post(url, body, { headers: headers }).toPromise();
    } 
    catch (ex) {
      console.error(ex);
    }

    return items;
  }
}
