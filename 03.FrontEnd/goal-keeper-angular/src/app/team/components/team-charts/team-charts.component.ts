import { AfterContentInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-team-charts',
  templateUrl: './team-charts.component.html',
  styleUrls: ['./team-charts.component.sass']
})
export class TeamChartsComponent implements OnInit, AfterContentInit {

  // https://edupala.com/how-to-use-angular-chartjs/

  @ViewChild('doughnut', {static: true}) donut: ElementRef;

  data = {
    labels: ['OK', 'WARNING', 'CRITICAL', 'UNKNOWN'],
    datasets: [{
      label: '# of Tomatoes',
      data: [12, 19, 3, 5],
      backgroundColor: [
        'rgba(255, 99, 132, 0.5)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(255, 206, 86, 0.2)',
        'rgba(75, 192, 192, 0.2)'
      ],
      borderColor: [
        'rgba(255,99,132,1)',
        'rgba(54, 162, 235, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)'
      ],
      borderWidth: 1
    }]
  };

  saleData = [
    { name: "Mobiles", value: 105000 },
    { name: "Laptop", value: 55000 },
    { name: "AC", value: 15000 },
    { name: "Headset", value: 150000 },
    { name: "Fridge", value: 20000 }
  ];

  constructor() { }
  ngAfterContentInit(): void {
    console.log(this.donut);
    // var chart = new Chart(this.donut.nativeElement, { type: 'doughnut', data: this.data});
    // Chart.register(chart);
  }

  ngOnInit(): void {
    
  }
  

}
