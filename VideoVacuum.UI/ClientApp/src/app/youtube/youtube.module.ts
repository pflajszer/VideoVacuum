import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YoutubeComponent } from './youtube.component';
import { YoutubeDownloaderService } from '../services/youtube/youtube-downloader.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatProgressSpinnerModule } from '@angular/material';
import { FileService } from '../services/shared/file.service';
import { ToastrService } from '../services/shared/toastr.service';



@NgModule({
  declarations: [YoutubeComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule
  ],
  providers: [YoutubeDownloaderService, FileService, ToastrService]
})
export class YoutubeModule { }
