$(document).ready(() => {
    let colors = dynamicColors(15);
    fetch('/api/gettotalsongsbygenre', {
        method: "GET",
        headers: {
            'Accept': 'application/json',
        }
    })
    .then(data => { return data.json(); })
    .then(json => {
        console.log(json);

        let genreLabels = [];
        let trackCount = [];

        json.forEach(genre => {
            genreLabels.push(genre.name);
            trackCount.push(genre.count);
        });

        var ctx = document.getElementById('myChart');
        var data = {
            labels: genreLabels,
            datasets: [{
                label: "Downloads by Genre",
                data: trackCount,
                backgroundColor: colors.backgrounds,
                borderColor: colors.borders,
                borderWidth: 1
            }]
        };

        var options = {};

        // For a pie chart
        var genreCountPieChart = new Chart(ctx, {
            type: 'pie',
            data: data,
            options: options
        });
    });
        


    //var myChart = new Chart(ctx, {
    //    type: 'bar',
    //    data: {
    //        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
    //        datasets: [{
    //            label: '# of Votes',
    //            data: [12, 19, 3, 5, 2, 3],
    //            backgroundColor: [
    //                'rgba(255, 99, 132, 0.2)',
    //                'rgba(54, 162, 235, 0.2)',
    //                'rgba(255, 206, 86, 0.2)',
    //                'rgba(75, 192, 192, 0.2)',
    //                'rgba(153, 102, 255, 0.2)',
    //                'rgba(255, 159, 64, 0.2)'
    //            ],
    //            borderColor: [
    //                'rgba(255, 99, 132, 1)',
    //                'rgba(54, 162, 235, 1)',
    //                'rgba(255, 206, 86, 1)',
    //                'rgba(75, 192, 192, 1)',
    //                'rgba(153, 102, 255, 1)',
    //                'rgba(255, 159, 64, 1)'
    //            ],
    //            borderWidth: 1
    //        }]
    //    },
    //    options: {
    //        scales: {
    //            yAxes: [{
    //                ticks: {
    //                    beginAtZero: true
    //                }
    //            }]
    //        }
    //    }
    //});
})

function dynamicColors(numColors) {
    let backgrounds = [];
    let borders = [];

    for (let i = 0; i <= numColors; i++) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        backgrounds.push("rgb(" + r + "," + g + "," + b + ", 1)");
        borders.push("rgb(" + r + "," + g + "," + b + ", .2)");
    }

    return {
        "backgrounds": backgrounds,
        "borders": borders
    };
}