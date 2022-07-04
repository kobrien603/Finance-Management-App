
function buildChart() {
    const data = {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        datasets: [
            {
                label: 'Dataset 1',
                data: [12, 19, 3, 5, 2, 3],
                yAxisID: 'y',
            },
            {
                label: 'Dataset 2',
                data: [12, 19, 3, 5, 2, 3],
                yAxisID: 'y1',
            }
        ]
    };

    const config = {
        type: 'line',
        data: data,
        options: {
            responsive: true,
            interaction: {
                mode: 'index',
                intersect: false,
            },
            stacked: false,
            plugins: {
                title: {
                    display: true,
                    text: 'Chart.js Line Chart - Multi Axis'
                }
            },
            scales: {
                y: {
                    type: 'linear',
                    display: true,
                    position: 'left',
                    min: -50,
                    max: 135,
                   // maxTicksLimit: 5,
                    suggestedMin: -50,
                    suggestedMax: 135
                },
                y1: {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    min: -45,
                    max: 65,
                    //maxTicksLimit: 5,
                    //suggestedMin: -500,
                    //suggestedMax: 1000,
                    // grid line settings
                    grid: {
                        drawOnChartArea: false, // only want the grid lines for one axis to show up
                    },
                },
            }
        },
    };
    
    new Chart(document.getElementById('myChart').getContext('2d'), config);
}
