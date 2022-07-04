
function buildChart(id = "", title = "", datasets = [], labels = []) {
    const data = {
        labels: labels,
        datasets: datasets
    };

    const config = {
        type: 'line',
        data: data,
        options: {
            responsive: true,
            maintainAspectRatio: true,
            interaction: {
                mode: 'index',
                intersect: false,
            },
            scales: {
                y: {
                    type: 'linear',
                    display: true,
                    position: 'left'
                }
            },
            plugins: {
                title: {
                    display: true,
                    text: title
                },
                zoom: {
                    pan: {
                        enabled: true,
                        mode: 'x',
                        modifierKey: 'ctrl',
                    },
                    zoom: {
                        drag: {
                            enabled: true
                        },
                        mode: 'x',
                    },
                }
            }
        },
    };
    
    new Chart(document.getElementById(id).getContext('2d'), config);
}
