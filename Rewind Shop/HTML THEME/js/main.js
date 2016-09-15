// MAIN.JS
//--------------------------------------------------------------------------------------------------------------------------------
//This is main JS file that contains custom JS scipts and initialization used in this template*/
// -------------------------------------------------------------------------------------------------------------------------------
// Template Name: REWIND - eCommerce Fashion Responsive Html5 Template
// Author: Iwthemes
// Version 1.0
// Website: http://www.iwthemes.com 
// Email: support@iwthemes.com
// Copyright: (C) 2016
// -------------------------------------------------------------------------------------------------------------------------------

$(document).ready(function(){

   "use strict";
  // Loader ------------------------------------------//
  jQuery(window).load(function() {
    jQuery(".status").fadeOut();
    jQuery(".preloader").delay(500).fadeOut("slow");
  })

  // Totop -------------------------------------------//
  $().UItoTop({
    scrollSpeed:500,
    easingType:'linear'
  });

  // Filter toggle Portfolio -------------------------//
  $( ".filter-toggle a" ).click(function() {
    $( ".filterdrop" ).toggle( "slow" );
    $(".filter-toggle i").toggleClass("active");
    return false;
  });

  // Popover & Tooltip -------------------------------//
  $('[data-toggle="tooltip"]').tooltip() 
  
  // Twitter -----------------------------------------//
  $(".twitter-list").tweet({
      modpath: 'js/twitter/index.php',
      username: "envato",
      count: 5,
      loading_text: "Loading tweets...",
  });

  // Carousels --------------------------------------//
  $('.carousel-collection').owlCarousel({
      loop:true,
      nav:true,
      autoplay: true,
      autoplayHoverPause: true,
      margin: 30,
      autoplayTimeout: 2500,
      responsive:{
          0:{
              items:1
          },
          510:{
              items:2
          },
          769:{
              items:3
          },
          1050:{
              items:4
          }
      }
  })
  $('.carousel-blog').owlCarousel({
      loop:true,
      nav:true,
      autoplay: true,
      autoplayHoverPause: true,
      autoplayTimeout: 2000,
      margin: 30,
      responsive:{
          0:{
              items:1
          },
          769:{
              items:2
          },
          1050:{
              items:2
          }
      }
  })

   $('.brands').owlCarousel({
      loop:true,
      nav:true,
      autoplay: true,
      autoplayHoverPause: true,
      autoplayTimeout: 2000,
      margin: 60,
      responsive:{
          0:{
              items:3
          },
          769:{
              items:4
          },
          1050:{
              items:5
          }
      }
  })
  $('.carousel-blog-single').owlCarousel({
      loop:true,
      margin:10,
      nav:false,
      autoplay: true,
      autoplayHoverPause: true,
      autoplayTimeout: 5500,
      responsive:{
          0:{
              items:1
          }
      }
  })

  $('.tweet_list').owlCarousel({
      loop:true,
      margin:10,
      nav:false,
      autoplay: true,
      autoplayTimeout: 30000,
      animateIn: 'flipInX',
      responsive:{
          0:{
              items:1
          }
      }
  })

  $('.carousel-product-view').owlCarousel({
      loop:true,
      margin:10,
      nav:false,
      autoplay: true,
      autoplayTimeout: 2000,
      animateOut: 'fadeOut',
      autoplayHoverPause: true,
      responsive:{
          0:{
              items:1
          }
      }
  })

  $('.carousel-product').owlCarousel({
      loop:true,
      margin:10,
      nav:false,
      autoplay: true,
      autoplayTimeout: 1600,
      animateOut: 'fadeOut',
      autoplayHoverPause: true,
      responsive:{
          0:{
              items:1
          },
          769:{
              items:2
          },
          1050:{
              items:4
          }
      }
  })

  $('.carousel-project').owlCarousel({
      loop:true,
      margin:0,
      nav:true,
      autoplay: true,
      autoplayTimeout: 2000,
      autoHeight:true,
      responsive:{
          0:{
              items:1
          }
      }
  })
  
  $('.carousel-product-fullwidht').owlCarousel({
      loop:true,
      margin:30,
      nav:false,
      autoplay: true,
      autoplayTimeout: 1600,
      animateOut: 'fadeOut',
      autoplayHoverPause: true,
      responsive:{
          0:{
              items:1
          },
          769:{
              items:2
          },
          1050:{
              items:6
          }
      }
  })
  // ShowBag ----------------------------------------//
  $('#showbag').click(function() {
            $('#bagpanel').slideToggle('slow', function() {
             $("#triangle_down").toggle(); 
          $("#triangle_up").toggle();
      });
    });
  
  // Scroll ----------------------------------------//
  var scrollAnimationTime = 1200,
      scrollAnimation = 'easeInOutExpo';
  $('a.scrollto').bind('click.smoothscroll', function (event) {
      event.preventDefault();
      var target = this.hash;
      $('html, body').stop().animate({
          'scrollTop': $(target).offset().top
      }, scrollAnimationTime, scrollAnimation, function () {
          window.location.hash = target;
      });
  });

  // Lightbox --------------------------------------//
    $(".iframe_video").fancybox({
      'width'       : '65%',
      'height'      : '75%',
      'autoScale'   : false,
      'transitionIn': 'none',
      'transitionOut': 'none',
      'type'        : 'iframe'
    });
     
     
      jQuery("a[class*=fancybox]").fancybox({
      'overlayOpacity'  : 0.7,
      'overlayColor'    : '#000000',
      'transitionIn'    : 'elastic',
      'transitionOut'   : 'elastic',
      'easingIn'        : 'easeOutBack',
      'easingOut'       : 'easeInBack',
      'speedIn'       : '700',
      'centerOnScroll'  : true,
      'titlePosition'     : 'over'
    });

  // Animations ------------------------------------//
    new WOW().init();

  // Contact Form ----------------------------------//
    $('.form-contact').submit(function(event) {  
      event.preventDefault();  
      var url = $(this).attr('action');  
      var datos = $(this).serialize();  
      $.get(url, datos, function(resultado) {  
        $('.result').html(resultado);  
      });  
    }); 
    
  // Newsletter -----------------------------------//
  $('.newsletterForm').submit(function(event) {  
    event.preventDefault();  
    var url = $(this).attr('action');
    var datos = $(this).serialize();  
     $.get(url, datos, function(resultado) {  
      $('.result-newsletter').html(resultado);  
    });
  }); 

  // Filters --------------------------------------//
  $(window).load(function(){
      var $container = $('.portfolioContainer');
      $container.isotope({
      filter: '*',
          animationOptions: {
          duration: 750,
          easing: 'linear',
          queue: false
    }
  });
  $('.portfolioFilter a').click(function(){
      $('.portfolioFilter .current').removeClass('current');
      $(this).addClass('current');
       var selector = $(this).attr('data-filter');
       $container.isotope({
        filter: selector,
              animationOptions: {
              duration: 750,
              easing: 'linear',
              queue: false
            }
        });
       return false;
      }); 
   });
});  