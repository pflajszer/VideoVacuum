import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { YoutubeVideoViewModel } from '../../models/video-view-model';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-metadata-edit-form',
  templateUrl: './metadata-edit-form.component.html',
  styleUrls: ['./metadata-edit-form.component.css']
})
export class MetadataEditFormComponent implements OnInit {
  loading: boolean;
  video: YoutubeVideoViewModel;
  http: HttpClient;
  baseUrl: string;

  options: FormGroup;
  hideRequiredControl = new FormControl(false);
  floatLabelControl = new FormControl('auto');

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, fb: FormBuilder) { }

  ngOnInit() {
  }

  onSubmit() {
    this.loading = true;
    let videoUrl = this.options.value.videoUrl;
    this.http.post<YoutubeVideoViewModel>(this.baseUrl + 'api/Video/SetVideoMetadata', this.video).subscribe(result => {
      this.video = result;
      this.loading = false;
    }, error => console.error(error));
  }

}
