import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { YoutubeVideoViewModel } from 'src/app/models/video-view-model';

@Injectable({
  providedIn: 'root'
})
export class YoutubeDownloaderService {

  //baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  getYoutubeVideo(videoUrl: string): Observable<YoutubeVideoViewModel> {
    return this.http.get<YoutubeVideoViewModel>(
      this.baseUrl + 'api/Video/DownloadVideoMetadata?videoAddress=' + videoUrl);
  }

  setVideoMetadata(video: YoutubeVideoViewModel): Observable<YoutubeVideoViewModel> {
    return this.http.post<YoutubeVideoViewModel>(this.baseUrl + 'api/Video/SetVideoMetadata', video);
  }
}
