$(document).ready(() => {
    let colors = getColors();

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

        var ctx = document.getElementById('tracks-by-genre');
        var data = {
            labels: genreLabels,
            datasets: [{
                label: "Tracks by Genre",
                data: trackCount,
                backgroundColor: colors.backgrounds,
                hoverBackgroundColor: colors.hoverBackgrounds,
                borderColor: colors.borders,
                borderWidth: 1
            }]
        };

        var options = {
            legend: {
                position: "right",
                labels: {
                    boxWidth: 30
                }
            }
        };

        // For a pie chart
        var genreCountChart = new Chart(ctx, {
            type: 'doughnut',
            data: data,
            options: options
        });
    });





    fetch('/api/gettotalsongsbyinstrument', {
        method: "GET",
        headers: {
            'Accept': 'application/json',
        }
    })
        .then(data => { return data.json(); })
        .then(json => {
            console.log(json);

            let instrumentLabels = [];
            let trackCount = [];

            json.forEach(instrument => {
                instrumentLabels.push(instrument.name.split(' ')
                                                     .map(w => w.charAt(0).toUpperCase() + w.substring(1))
                                                     .join(' '));
                trackCount.push(instrument.count);
            });

            var ctx = document.getElementById('tracks-by-instrument');
            var data = {
                labels: instrumentLabels,
                datasets: [{
                    label: "Tracks by Instrument",
                    data: trackCount,
                    backgroundColor: colors.backgrounds,
                    hoverBackgroundColor: colors.hoverBackgrounds,
                    borderColor: colors.borders,
                    borderWidth: 1
                }]
            };

            var options = {
                legend: {
                    position: "right",
                    labels: {
                        boxWidth: 30
                    }
                }
            };

            var instrumentCountChart = new Chart(ctx, {
                type: 'doughnut',
                data: data,
                options: options
            });
        });


    fetch('/api/gettotalsongsbymood', {
        method: "GET",
        headers: {
            'Accept': 'application/json',
        }
    })
    .then(data => { return data.json(); })
    .then(json => {
        console.log(json);

        let moodLabels = [];
        let trackCount = [];

        json.forEach(mood => {
            moodLabels.push(mood.name.split(' ')
                .map(w => w.charAt(0).toUpperCase() + w.substring(1))
                .join(' '));
            trackCount.push(mood.count);
        });

        var ctx = document.getElementById('tracks-by-mood');
        var data = {
            labels: moodLabels,
            datasets: [{
                label: "Tracks by Mood",
                data: trackCount,
                backgroundColor: colors.backgrounds,
                hoverBackgroundColor: colors.hoverBackgrounds,
                borderColor: colors.borders,
                borderWidth: 1
            }]
        };

        var options = {
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        stepSize: 1
                    }
                }]
            }
        };

        var moodCountChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: options
        });
    });
        
})

function getColors() {

    // repeat colors for moods
    let backgrounds = ['#d7dfff', '#afbeff', '#889eff', '#607eff', '#8d99ae', '#2b2d42', '#584b53', '#a7b4ac',
                       '#d7dfff', '#afbeff', '#889eff', '#607eff', '#8d99ae', '#2b2d42', '#584b53', '#a7b4ac',
                       '#d7dfff', '#afbeff', '#889eff', '#607eff', '#8d99ae', '#2b2d42', '#584b53', '#a7b4ac'];
    let hoverBackgrounds = ['#BEC6E6', '#96a5e6', '#6F85E6', '#4765E6', '#748095', '#121429', '#3F323A', '#8E9B93',
                            '#BEC6E6', '#96a5e6', '#6F85E6', '#4765E6', '#748095', '#121429', '#3F323A', '#8E9B93',
                            '#BEC6E6', '#96a5e6', '#6F85E6', '#4765E6', '#748095', '#121429', '#3F323A', '#8E9B93'];
    let borders = hoverBackgrounds;

    return {
        "backgrounds": backgrounds,
        "hoverBackgrounds": hoverBackgrounds,
        "borders": borders
    };
}