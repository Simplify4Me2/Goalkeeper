import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration, ChartData, ChartOptions, registerables } from 'chart.js';

@Component({
  selector: 'app-team-charts',
  templateUrl: './team-charts.component.html',
  styleUrls: ['./team-charts.component.sass'],
})
export class TeamChartsComponent implements OnInit {

  @ViewChild('resultBar', { static: true }) resultBar: ElementRef;

  bar: any;

  barOptions: ChartOptions = {
    indexAxis: 'y',
    scales: {
      x: {
        stacked: true,
        grid: {
          display: false
        },
        display: false
      },
      y: { 
        stacked: true,
        grid: {
          display: false
        },
        display: false
      },
    },
    plugins: {
      legend: {
        display: false
      },
      tooltip: {
        enabled: false
      }
    }
  }

  barConfig: ChartConfiguration = {
    type: 'bar',
    data: {
      labels: [''],
      datasets: [
        {
          data: [4],
          backgroundColor: 'rgba(0,128,0,1)',
          borderRadius: Number.MAX_VALUE
        },
        {
          data: [2],
          backgroundColor: 'rgba(255,165,0,1)',
          borderRadius: Number.MAX_VALUE
        },
        {
          data: [6],
          backgroundColor: 'rgba(255,0,0,1)',
          borderRadius: Number.MAX_VALUE
        }
      ],
    },
    options: this.barOptions
  };

  constructor() {}

  ngOnInit(): void {
    Chart.register(...registerables);

    this.bar = new Chart(this.resultBar.nativeElement, this.barConfig);
  }
}
