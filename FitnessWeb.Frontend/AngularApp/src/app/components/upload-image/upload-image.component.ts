import { Component, OnInit } from '@angular/core';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileUploadService } from 'src/app/components/upload-image/file-upload.service';
import { AuthenticationService } from 'src/services/authentication.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})

export class UploadImagesComponent implements OnInit {
  fileName = '';
  selectedFile!: File;
  constructor(private uploadService: FileUploadService, private authService: AuthenticationService, private toastr: ToastrService) { }
  ngOnInit(): void {
  }

  onFileSelected() {
    if (this.selectedFile) {
        this.authService.uploadPhoto(this.selectedFile).subscribe(() => this.toastr.success("Upload is successfull"));
    }
}
}