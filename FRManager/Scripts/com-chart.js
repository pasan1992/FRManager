
/*disk usage-dougnut */
var doughnutData = [
        {
            value: 45,
            color: "#F7464A",
            highlight: "#FF5A5E",
            label: "Used"
        },
        {
            value: 55,
            color: "#3d3d3d",
            highlight: "#aaa4a4",
            label: "Rest"
        }
];

/*memory usage-dougnut */
var doughnutData2 = [
        {
            value: 70,
            color: "#3f8712",
            highlight: "#a0f185",
            label: "Used"
        },
        {
            value: 30,
            color: "#3d3d3d",
            highlight: "#aaa4a4",
            label: "Rest"
        }
];

/*cpu usage-dougnut */
var doughnutData3 = [
        {
            value: 82,
            color: "#0c0c40",
            highlight: "#7265ea",
            label: "Used"
        },
        {
            value: 18,
            color: "#3d3d3d",
            highlight: "#aaa4a4",
            label: "Rest"
        }
];

$("[rel='tooltip']").tooltip();

$('.view').hover(
    function () {
        $(this).find('.caption').slideDown(250); //.fadeIn(250)
    },
    function () {
        $(this).find('.caption').slideUp(250); //.fadeOut(205)
    }
);

/*onload window function */
window.onload = function () {
    var c2 = document.getElementById("memory-usage").getContext("2d");
    window.myDoughnut2 = new Chart(c2).Doughnut(doughnutData2, { responsive: true });

    var c1 = document.getElementById("disk-usage").getContext("2d");
    window.myDoughnut1 = new Chart(c1).Doughnut(doughnutData, { responsive: true });

    var c3 = document.getElementById("cpu-usage").getContext("2d");
    window.myDoughnut3 = new Chart(c3).Doughnut(doughnutData3, { responsive: true });
};





