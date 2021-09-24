import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration, ChartData, ChartOptions, registerables } from 'chart.js';

@Component({
  selector: 'app-team-charts',
  templateUrl: './team-charts.component.html',
  styleUrls: ['./team-charts.component.sass'],
})
export class TeamChartsComponent implements OnInit {
  // https://edupala.com/how-to-use-angular-chartjs/

  @ViewChild('doughnut', { static: true }) donut: ElementRef;
  @ViewChild('resultBar', { static: true }) resultBar: ElementRef;

  dougnut: any;
  bar: any;

  doughnutData = {
    labels: ['OK', 'WARNING', 'CRITICAL', 'UNKNOWN'],
    datasets: [
      {
        label: '# of Tomatoes',
        data: [12, 19, 3, 5],
        backgroundColor: [
          'rgba(255, 99, 132, 0.5)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
        ],
        borderColor: [
          'rgba(255,99,132,1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
        ],
        borderWidth: 1,
      },
    ],
  };

  saleData = [
    { name: 'Mobiles', value: 105000 },
    { name: 'Laptop', value: 55000 },
    { name: 'AC', value: 15000 },
    { name: 'Headset', value: 150000 },
    { name: 'Fridge', value: 20000 },
  ];

  // barData: ChartData = {

  // };

  barOptions: ChartOptions = {
    indexAxis: 'x'
  }

  barConfig: ChartConfiguration = {
    type: 'bar',
    data: {
      labels: ['Foo'],
      datasets: [
        {
          data: [727, 589, 537, 543, 574],
          backgroundColor: 'rgba(63,103,126,1)',
          hoverBackgroundColor: 'rgba(50,90,100,1)',
        },
      ],
    },
    options: this.barOptions
    // {
    //   scales: {
    //     xAxes: [
    //       {
    //         ticks: {
    //           beginAtZero: true,
    //           fontFamily: "'Open Sans Bold', sans-serif",
    //           fontSize: 11,
    //         },
    //         scaleLabel: {
    //           display: false,
    //         },
    //         gridLines: {},
    //         stacked: true,
    //       },
    //     ],
    //     yAxes: [
    //       {
    //         gridLines: {
    //           display: false,
    //           color: '#fff',
    //           zeroLineColor: '#fff',
    //           zeroLineWidth: 0,
    //         },
    //         ticks: {
    //           fontFamily: "'Open Sans Bold', sans-serif",
    //           fontSize: 11,
    //         },
    //         stacked: true,
    //       },
    //     ],
    //   },
    //   // tooltips: {
    //   //   enabled: false,
    //   // },
    //   // hover: {
    //   //   animationDuration: 0,
    //   // },
    //   // scales: {
    //   //   xAxes: [
    //   //     {
    //   //       ticks: {
    //   //         beginAtZero: true,
    //   //         fontFamily: "'Open Sans Bold', sans-serif",
    //   //         fontSize: 11,
    //   //       },
    //   //       scaleLabel: {
    //   //         display: false,
    //   //       },
    //   //       gridLines: {},
    //   //       stacked: true,
    //   //     },
    //   //   ],
    //   //   yAxes: [
    //   //     {
    //   //       gridLines: {
    //   //         display: false,
    //   //         color: '#fff',
    //   //         zeroLineColor: '#fff',
    //   //         zeroLineWidth: 0,
    //   //       },
    //   //       ticks: {
    //   //         fontFamily: "'Open Sans Bold', sans-serif",
    //   //         fontSize: 11,
    //   //       },
    //   //       stacked: true,
    //   //     },
    //   //   ],
    //   // },
    //   // legend: {
    //   //   display: false,
    //   // },

    //   // animation: {
    //   //   onComplete: function () {
    //   //     var chartInstance = this.chart;
    //   //     var ctx = chartInstance.ctx;
    //   //     ctx.textAlign = 'left';
    //   //     ctx.font = '9px Open Sans';
    //   //     ctx.fillStyle = '#fff';

    //   //     Chart.helpers.each(
    //   //       this.data.datasets.forEach(function (dataset, i) {
    //   //         var meta = chartInstance.controller.getDatasetMeta(i);
    //   //         Chart.helpers.each(
    //   //           meta.data.forEach(function (bar, index) {
    //   //             data = dataset.data[index];
    //   //             if (i == 0) {
    //   //               ctx.fillText(data, 50, bar._model.y + 4);
    //   //             } else {
    //   //               ctx.fillText(data, bar._model.x - 25, bar._model.y + 4);
    //   //             }
    //   //           }),
    //   //           this
    //   //         );
    //   //       }),
    //   //       this
    //   //     );
    //   //   },
    //   // },
    //   // pointLabelFontFamily: 'Quadon Extra Bold',
    //   // scaleFontFamily: 'Quadon Extra Bold',
    // },
  };

  constructor() {}

  ngOnInit(): void {
    Chart.register(...registerables);

    this.dougnut = new Chart(this.donut.nativeElement, {
      type: 'doughnut',
      data: this.doughnutData,
    });

    this.bar = new Chart(this.resultBar.nativeElement, this.barConfig);
  }
}
