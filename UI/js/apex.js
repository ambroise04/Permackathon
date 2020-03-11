




document.addEventListener('DOMContentLoaded', function(){
    
    console.log('koala');
    
    


    let targetURL = "http://192.168.0.100:86/api/chart/fusion/2019";
 
    let xhr = new XMLHttpRequest();

    xhr.addEventListener('readystatechange', function (event){
        if (xhr.readyState == 4 && xhr.status == 200) {
            let json =JSON.parse(xhr.responseText);
            console.log(json.EAT);
            console.log(json.GROW);
            console.log(json.LEARN);

            var options = {
                series: [{
                    name: 'EAT',
                    data: [
                        ]
                    }, 
                    {
                    name: 'GROW',
                    data: [ ]
                    }, 
                    {
                    name: 'LEARN',
                    data: [ ]
                    }
                ],
            
                chart: {
                type: 'bar',
                height: 650,
                width: 1200,
                stacked: true,
                stackType: '300%'
              },
              responsive: [{
                breakpoint: 480,
                options: {
                  legend: {
                    position: 'bottom',
                    offsetX: -10,
                    offsetY: 0
                  }
                }
              }],
              xaxis: {
                categories: ['Jan', 'Fev', 'Mar', 'Avr', 'Mai', 'Jui',
                  'Juil', 'Août', 'Sept', 'Oct', 'Nov', 'Dec'
                ],
              },
              fill: {
                opacity: 1
              },
              legend: {
                position: 'right',
                offsetX: 0,
                offsetY: 50
              },
            
              theme: {
                mode: 'light', 
                palette: 'palette9', 
                monochrome: {
                    enabled: false,
                    color: '#255aee',
                    shadeTo: 'light',
                    shadeIntensity: 0.65
                },
            },
              };
           
      
                    for(let j=0; j<12; j++){ 
                    options.series[0].data[j] = json.EAT[j].Value; 
                    }
                    for(let j=0; j<12; j++){ 
                        options.series[1].data[j] = json.GROW[j].Value; 
                        }
                        for(let j=0; j<12; j++){ 
                            options.series[2].data[j] = json.LEARN[j].Value; 
                            }

                            
                              var chart = new ApexCharts(document.querySelector("#chart"), options);
                              chart.render();
        }

    });

    xhr.open('GET', targetURL, true);
    xhr.send();

})




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// camenbert //

document.addEventListener('DOMContentLoaded', function(){
    
    console.log('koala');
    
    


    let targetURL = "http://192.168.0.100:86/api/chart/pie/2019";
 
    let xhr = new XMLHttpRequest();

    xhr.addEventListener('readystatechange', function (event){
        if (xhr.readyState == 4 && xhr.status == 200) {
            let json =JSON.parse(xhr.responseText);

            var options = {
                series: [],
                chart: {
                    width: 580,
                    type: 'pie',
                },
                
                theme: {
                    mode: 'light', 
                    palette: 'palette9', 
                    monochrome: {
                        enabled: false,
                        color: '#255aee',
                        shadeTo: 'light',
                        shadeIntensity: 0.65
                    },
                },
                
                labels: ['Eat', 'Grow', 'Learn'],
                responsive: [{
                    breakpoint: 480,
                    options: {
                        chart: {
                            width: 200
                        },
                        legend: {
                            position: 'bottom'
                        }
                    }
                }]
                
            };  

            options.series[0] = json[0];
            options.series[1] = json[1];
            options.series[2] = json[2];



            
            
      

                            
                              var chart = new ApexCharts(document.querySelector("#chart2"), options);
                              chart.render();
        }

    });

    xhr.open('GET', targetURL, true);
    xhr.send();

})


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// CA Ligne ////

document.addEventListener('DOMContentLoaded', function(){
    
    console.log('koala');
    
    


    let targetURL = "http://192.168.0.100:86/api/chart/line/2019";
 
    let xhr = new XMLHttpRequest();

    xhr.addEventListener('readystatechange', function (event){
        if (xhr.readyState == 4 && xhr.status == 200) {
            let json =JSON.parse(xhr.responseText);
            

            var options = {
                series: [{
                    name: "Prévisionnel",
                    data: []
                },
                {
                    name: "Réel",
                    data: []
                },
                // {
                //     name: 'Learn',
                //     data: []
                // }
            ],
            chart: {
                height: 350,
                type: 'line',
                zoom: {
                    enabled: false
                },
            },
            
            colors:
            ['#5C4742', '#A5978B',	'#8D5B4C',	'#5A2A27','#C4BBAF'],
            
            dataLabels: {
                enabled: false
            },
            stroke: {
                width: [5, 7, 5],
                curve: 'straight',
                dashArray: [0, 8, 5]
            },
            title: {
                text: 'Monthly income',
                align: 'left'
            },
            legend: {
                tooltipHoverFormatter: function(val, opts) {
                    return val + ' - ' + opts.w.globals.series[opts.seriesIndex][opts.dataPointIndex] + ''
                }
            },
            markers: {
                size: 0,
                hover: {
                    sizeOffset: 6
                }
            },
            xaxis: {
                categories: ['Jan', 'Fev', 'Mar', 'Avr', 'Mai', 'Jui',
                'Juil', 'Août', 'Sept', 'Oct', 'Nov', 'Dec'
              ],
            },
            tooltip: {
                y: [
                    {
                        title: {
                            formatter: function (val) {
                                return val + " (mins)"
                            }
                        }
                    },
                    {
                        title: {
                            formatter: function (val) {
                                return val + " per session"
                            }
                        }
                    },
                    {
                        title: {
                            formatter: function (val) {
                                return val;
                            }
                        }
                    }
                ]
            },
            grid: {
                borderColor: '#f1f1f1',
            }
            };
            
            
           
      
                    for(let j=0; j<12; j++){ 
                    options.series[0].data[j] = json.Objectives[j].Value; 
                    }
                    for(let j=0; j<12; j++){ 
                        options.series[1].data[j] = json.RealSales[j].Value; 
                        }
                        // for(let j=0; j<12; j++){ 
                        //     options.series[2].data[j] = json.[j].Value; 
                        //     }

                            
                              var chart = new ApexCharts(document.querySelector("#chart3"), options);
                              chart.render();
        }

    });

    xhr.open('GET', targetURL, true);
    xhr.send();

})






////



