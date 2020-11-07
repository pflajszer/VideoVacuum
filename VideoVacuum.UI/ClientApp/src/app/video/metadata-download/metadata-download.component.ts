import { Component, OnInit, Inject } from '@angular/core';
import { VideoViewModel } from '../../models/video-view-model';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-metadata-download',
  templateUrl: './metadata-download.component.html',
  styleUrls: ['./metadata-download.component.css']
})
export class MetadataDownloadComponent implements OnInit {
  loading: boolean;
  video: VideoViewModel;
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
    this.http.get<VideoViewModel>(this.baseUrl + 'api/Video/DownloadVideoMetadata?videoAddress=' + videoUrl).subscribe(result => {
      this.video = result;
      this.loading = false;
      this.options2 = this.fb.group({
        hideRequired: this.hideRequiredControl,
        floatLabel: this.floatLabelControl,
        author: this.video.author
      });
    }, error => console.error(error));
  }

  onSubmitSetMetadata(form: any) {
    this.loading = true;
    this.video.author = form.value["author"];
    this.http.post<VideoViewModel>(this.baseUrl + 'api/Video/SetVideoMetadata', this.video).subscribe(result => {
      //this.video = result;
      this.loading = false;
    }, error => console.error(error));
  }

}
