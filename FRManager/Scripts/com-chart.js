
/*disk usage-dougnut */

//var doughnutData = [
//        {
//            value: 45,
//            color: "#F7464A",
//            highlight: "#FF5A5E",
//            label: "Used"
//        },
//        {
//            value: 55,
//            color: "#3d3d3d",
//            highlight: "#aaa4a4",
//            label: "Rest"
//        }
//];

/*memory usage-dougnut */
//var memorydata = [
//        {
//            value: 70,
//            color: "#3f8712",
//            highlight: "#a0f185",
//            label: "Used"
//        },
//        {
//            value: 30,
//            color: "#3d3d3d",
//            highlight: "#aaa4a4",
//            label: "Rest"
//        }
//];

/*cpu usage-dougnut */
//var doughnutData3 = [
//        {
//            value: 82,
//            color: "#0c0c40",
//            highlight: "#7265ea",
//            label: "Used"
//        },
//        {
//            value: 18,
//            color: "#3d3d3d",
//            highlight: "#aaa4a4",
//            label: "Rest"
//        }
//];

/*tile mask */
//$("[rel='tooltip']").tooltip();

//$('.view').hover(
//    function () {
//        $(this).find('.caption').slideDown(600); //.fadeIn(250)
//    },
//    function () {
//        $(this).find('.caption').slideUp(600); //.fadeOut(205)
//    }
//);

/*cpu usage-monthly-line chart */
var randomScalingFactor = function () { return Math.round(Math.random() * 100) };
var lineChartData = {
    labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18",
        "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"],
    datasets: [
        {
            label: "My First dataset",
            fillColor: "rgba(220,220,220,0.2)",
            strokeColor: "rgba(220,220,220,1)",
            pointColor: "rgba(220,220,220,1)",
            pointStrokeColor: "#fff",
            pointHighlightFill: "#fff",
            pointHighlightStroke: "rgba(220,220,220,1)",
            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        },
    ]
}



/*onload window function */
//window.onload = function () {
//    var c2 = document.getElementById("memory-usage").getContext("2d");
//    window.myDoughnut2 = new Chart(c2).Doughnut(doughnutData2, { responsive: true });

//    var c1 = document.getElementById("disk-usage").getContext("2d");
//    window.myDoughnut1 = new Chart(c1).Doughnut(doughnutData, { responsive: true });

//    var c3 = document.getElementById("cpu-usage").getContext("2d");
//    window.myDoughnut3 = new Chart(c3).Doughnut(doughnutData3, { responsive: true });

//    var c4 = document.getElementById("cpu-monthly").getContext("2d");
//    window.myLine = new Chart(c4).Line(lineChartData, { responsive: true });

//};






/*progress bar */
$(".progress-bar").animate({
    width: "40%"
}, 2500);

$(".progress-bar2").animate({
    width: "80%"
}, 2500);

//page scoll
$(function () {
    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})



function cpuUsage() {



    $.ajax({
        type: "GET",
        url: "/Analyse/cpuPartialView",
        data: { ID: idnum },

        dataType: "html",



        success: function (data) {
            //alert("working3")
            $("#currentCPUcontainer").html(data);


            var c3 = document.getElementById("cpu-usage").getContext("2d");
            window.cpuchart = new Chart(c3).Doughnut(cpudata, {
                responsive: true, animateRotate: false, animateScale: false, animationEasing: "ease", animationSteps: 1

            });
            return false;
        }
    })
}
function memoryUsage() {



    $.ajax({
        type: "GET",
        url: "/Analyse/memoryPartialView",
        data: { ID: idnum },

        dataType: "html",



        success: function (data) {
            //alert("working3")
            $("#CurrentMemoryContainer").html(data);


            var c3 = document.getElementById("memory-usage").getContext("2d");
            window.cpuchart = new Chart(c3).Doughnut(memorydata, {
                responsive: true, animateRotate: false, animateScale: false, animationEasing: "ease", animationSteps: 1

            });
            return false;
        }
    })
}

function diskUsage() {
   


    $.ajax({
        type: "GET",
        url: "/Analyse/diskPartialView",
        data: { ID: idnum },

        dataType: "html",



        success: function (data) {
            
            $("#CurrentDiskContainer").html(data);


            var c3 = document.getElementById("disk-usage").getContext("2d");
            window.cpuchart = new Chart(c3).Doughnut(diskData, {
                responsive: true, animateRotate: false, animateScale: false, animationEasing: "ease", animationSteps: 1

            });
            return false;
        }
    })
}



function all(){
    cpuUsage()
    memoryUsage()
    diskUsage()
}
$(all)

setInterval(all, 5000);




    


