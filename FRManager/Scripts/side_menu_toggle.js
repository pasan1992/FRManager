$("#t_button").click(function (event) {
    event.preventDefault();

    if ($(window).width() >= 768) {
        // do your stuff





        $("#menu2").animate({ left: 'toggle' }, 400, 'linear');

        $("#wrapper_main").toggleClass("wrapper_collapsed");


    }
    $("#toggle_button").toggleClass("fa fa-bars").toggleClass("fa fa-plus");
});

$("#t_button").hover(function(){
    $("#toggle_button").toggleClass("fa fa-bars color_light").toggleClass("fa fa-bars color_blue");
})


