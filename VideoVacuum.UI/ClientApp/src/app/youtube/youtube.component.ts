import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { YoutubeVideoViewModel } from '../models/video-view-model';
import { FileService } from '../services/shared/file.service';
import { YoutubeDownloaderService } from '../services/youtube/youtube-downloader.service';
import { saveAs } from 'file-saver';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { ToastrService } from '../services/shared/toastr.service';

@Component({
  selector: 'app-youtube',
  templateUrl: './youtube.component.html',
  styleUrls: ['./youtube.component.css']
})
export class YoutubeComponent implements OnInit {

  getMetadataForm: FormGroup;
  editMetadataForm: FormGroup;

  floatLabelControl: FormControl = new FormControl('auto');


  loading: boolean;

  video: YoutubeVideoViewModel;
  
  constructor(
    private ytSvc: YoutubeDownloaderService,
    private fileSvc: FileService,
    private toastrSvc: ToastrService) { }

  ngOnInit() {
    this.getMetadataForm = new FormGroup({
      videoUrl: new FormControl()
    });
  }

  onSubmitGetMetadata() {
    // turn on the spinner
    this.loading = true;

    // this is the url from the form
    let videoUrl = this.getMetadataForm.value.videoUrl;

    // call to youtube API (download locally)
    this.ytSvc.getYoutubeVideo(videoUrl).subscribe(result => {
      
      // once video is assigned to, it will show the table result
      this.video =  result;
      console.log(this.video);

      // turn off the spinner
      this.loading = false;

      // display success toast
      this.toastrSvc.success("Successfully found the video");

    }, error => {
        this.toastrSvc.error(error);
        console.error(error);
    });

    this.editMetadataForm = new FormGroup({
      title: new FormControl(),
      author: new FormControl()
    });
  }

  onSubmitSetMetadata() {

    // show loading spinner
    this.loading = true;


    // get form values and assign to the video object
    this.video.author = this.editMetadataForm.value.author;
    this.video.title = this.editMetadataForm.value.title;

    // set the file metadata
    this.ytSvc.setVideoMetadata(this.video).subscribe(result => {

      // hide loading spinner
      this.loading = false;

      // display success toast
      this.toastrSvc.success("Successfully set the video metadata");

    }, error => {
        console.error(error);
        this.toastrSvc.error(error);
    });
  }

  getMp3() {
    // show loading spinner
    this.loading = true;

    var outputFileName = this.video.author + ' - ' + this.video.title + '.mp3';
    this.fileSvc.downloadF(this.video.mP3FileName)
      .subscribe(blob => {


        // save the file
        saveAs(blob, outputFileName);

        // hide loading spinner
        this.loading = false;

        // display success toast
        this.toastrSvc.success("Successfully downloaded the video");
      })
  }

}
