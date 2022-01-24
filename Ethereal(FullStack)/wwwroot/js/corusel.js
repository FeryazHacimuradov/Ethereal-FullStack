var owl = $('.owl-carousel');
owl.owlCarousel({
    items: 1,
    loop: true,
    margin: 1000,
    autoplay: true,
    autoplayTimeout: 1500,
    autoplayHoverPause: true,
    stagePadding: 230,
    dots: true,
    dotsEach: 10
});
$('.play').on('click', function() {
    owl.trigger('play.owl.autoplay', [1000])
})
$('.stop').on('click', function() {
    owl.trigger('stop.owl.autoplay')
})