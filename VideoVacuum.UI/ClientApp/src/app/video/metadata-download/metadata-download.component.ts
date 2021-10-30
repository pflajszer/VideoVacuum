import { Component, OnInit, Inject } from '@angular/core';
import { YoutubeVideoViewModel } from '../../models/video-view-model';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-metadata-download',
  templateUrl: './metadata-download.component.html',
  styleUrls: ['./metadata-download.component.css']
})
export class MetadataDownloadComponent implements OnInit {
  loading: boolean;
  video: YoutubeVideoViewModel;
  http: HttpClient;
  baseUrl: string = '';
  videoUrl: string = '';


  fb: FormBuilder;
  options: FormGroup;
  options2: FormGroup;
  hideRequiredControl = new FormControl(false);
  floatLabelControl = new FormControl('auto');

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, fb: FormBuilder) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.loading = false;
    this.fb = fb;

    this.options = fb.group({
      hideRequired: this.hideRequiredControl,
      floatLabel: this.floatLabelControl,
      videoUrl: this.videoUrl
    });

    this.options2 = this.fb.group({
      hideRequired: this.hideRequiredControl,
      floatLabel: this.floatLabelControl
    });
  }

  ngOnInit() {
  }

  onSubmitDownloadMetadata() {
    this.loading = true;
    let videoUrl = this.options.value.videoUrl;
    this.http.get<YoutubeVideoViewModel>(this.baseUrl + 'api/Video/DownloadVideoMetadata?videoAddress=' + videoUrl).subscribe(result => {
      this.video = result;
      this.loading = false;
      this.options2 = this.fb.group({
        hideRequired: this.hideRequiredControl,
        floatLabel: this.floatLabelControl,
        author: this.video.author,
        title: this.video.title
      });
    }, error => console.error(error));
  }

  onSubmitSetMetadata(form: any) {
    this.loading = true;
    this.video.author = form.value["author"];
    this.video.title = form.value["title"];
    this.http.post<YoutubeVideoViewModel>(this.baseUrl + 'api/Video/SetVideoMetadata', this.video).subscribe(result => {
      //this.video = result;
      this.loading = false;
    }, error => console.error(error));
  }

  //download(filename: string): Observable<Blob> {
  //  return this.http.post<Blob>(this.baseUrl + 'api/Video/DownloadFile?filename=' + filename,
  //    { responseType: 'blob' });
  //}

  //getMp3() {
  //  //var fileName = this.video.author + ' - ' + this.video.title + '.mp3';
  //  var fileName = 'cave canem - Tim Buckley ― Phantasmagoria In Two_517efe52-afeb-47af-8bdf-89bf4b52f840.mp3';
  //  this.download(fileName).subscribe(
  //    blob => {
  //      downloadFile(blob, fileName);
  //    },
  //    error => {
  //      console.log(error);
  //    });
  //}

  getMp3() {
    //var filename = 'cave canem - Tim Buckley ― Phantasmagoria In Two_517efe52-afeb-47af-8bdf-89bf4b52f840.mp3';
    var filename = this.video.mP3FileName;
    var outputFileName = this.video.author + ' - ' + this.video.title + '.mp3';
    this.download(this.baseUrl + 'api/Video/DownloadFile?filename=' + filename)
      .subscribe(blob => saveAs(blob, outputFileName))
  }

  download(url: string): Observable<Blob> {
    return this.http.get(url, {
      responseType: 'blob'
    })
  }
}
