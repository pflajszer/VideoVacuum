import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  downloadF(filename: string): Observable<Blob> {
    return this.http.get(this.baseUrl + 'api/Video/DownloadFile?filename=' + filename,
    {
      responseType: 'blob'
    })
  }

  
  // download(url: string): Observable<Blob> {
  //   return this.http.get(url, {
  //     responseType: 'blob'
  //   })
  // }
}
