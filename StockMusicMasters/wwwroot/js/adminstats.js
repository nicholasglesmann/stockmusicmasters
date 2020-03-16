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
        var genreCountPieChart = new Chart(ctx, {
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

            // For a pie chart
            var instrumentCountPieChart = new Chart(ctx, {
                type: 'doughnut',
                data: data,
                options: options
            });
        });
        
})

function dynamicColors(numColors) {
    let backgrounds = ['#d7dfff', '#afbeff', '#889eff', '#607eff', '#8d99ae', '#2b2d42', '#584b53', '#a7b4ac'];
    let hoverBackgrounds = ['#BEC6E6', '#96a5e6', '#6F85E6', '#4765E6'];
    let borders = backgrounds;
    //let borders = [];

    //for (let i = 0; i <= numColors; i++) {
    //    var r = Math.floor(Math.random() * 255);
    //    var g = Math.floor(Math.random() * 255);
    //    var b = Math.floor(Math.random() * 255);
    //    backgrounds.push("rgb(" + r + "," + g + "," + b + ", 1)");
    //    borders.push("rgb(" + r + "," + g + "," + b + ", .2)");
    //}

    return {
        "backgrounds": backgrounds,
        "hoverBackgrounds": hoverBackgrounds,
        "borders": borders
    };
}