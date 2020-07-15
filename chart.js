var dataPoints = []
var datapointsAPI = ""
function charty() {
    $.ajax({
        url: 'https://localhost:44330/api/ChartAPI',
        type: 'get',
        success: function (response) {
            datapointsAPI = JSON.parse(response); for (i = 0; i < datapointsAPI.length; i++) { dataPoints.push({ x: parseInt(datapointsAPI[i].x), y: parseInt(datapointsAPI[i].y), label: datapointsAPI[i].label }) };
            var chart = new CanvasJS.Chart("charty", {
                animationEnabled: true,
                backgroundColor: "#FFEECC",
                title: { text: "Output in a some Factory" },
                axisY: {
                    interval: 1,
                    title: "output in tonnes",
                    fontColor: "#ca7128"
                },
                axisX: {
                    interval: 1,
                    gridColor: "rgba(1,77,101,.1)",
                    title: "month",
                    fontColor: "#ca7128"
                },
                data: [{
                    type: "column",
                    name: "companies",
                    color: "#014D65",
                    dataPoints: dataPoints,
                }]
            });
            chart.render();
        },
        error: function (response) { alert("Error in fetching data") }
    });
}