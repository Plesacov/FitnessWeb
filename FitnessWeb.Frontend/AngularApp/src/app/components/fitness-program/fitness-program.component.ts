import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessProgramViewModel } from 'src/viewModels/fitnessProgramViewModel';

@Component({
  selector: 'fitness-program',
  templateUrl: './fitness-program.component.html',
  styleUrls: ['./fitness-program.component.css']
})
export class FitnessProgramComponent implements OnInit {
  fitnessProgram!: FitnessProgramViewModel;

  constructor(private fitnessService: FitnessProgramService, private route: ActivatedRoute) {
    this.getProgramById();

  }

  ngOnInit(): void {
  }

  public getProgramById = () => {
    this.fitnessProgram = this.route.snapshot.data['fitnessProgram'];
    console.log(this.fitnessProgram);
  }

  slideIndex: any = 1;

  public plusSlides(n: any) {
    if(this.slideIndex < 3 && this.slideIndex >= 1 && n != -1){
      this.slideIndex += n;
    }
    else if(this.slideIndex == 3 && n == 1){
      this.slideIndex = 1;
    }
    else if(this.slideIndex == 3 && n != 1){
      this.slideIndex = 2;
    }
    else if(this.slideIndex == 1){
      this.slideIndex = 3;
    }
    else{
      this.slideIndex = 1;
    }
  }
}
