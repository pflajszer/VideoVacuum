import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VideoRoutingModule } from './video-routing.module';
import { VideoComponent } from './video.component';
import { MetadataDownloadComponent } from './metadata-download/metadata-download.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MetadataEditFormComponent } from './metadata-edit-form/metadata-edit-form.component';

@NgModule({
  declarations: [VideoComponent, MetadataDownloadComponent, MetadataEditFormComponent],
  imports: [
    CommonModule,
    VideoRoutingModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatTableModule
  ]
})
export class VideoModule { }
