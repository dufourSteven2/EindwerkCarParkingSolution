   WebFontConfig = { 
    google: { families: [ 'Roboto+Slab::latin' ] }
  };
  (function() {
    var wf = document.createElement('script');
    wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
      '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
    wf.type = 'text/javascript';
    wf.async = 'true';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(wf, s);
  })();
  
  /* http://www.google.com/fonts/#UsePlace:use een van de mogelijkheden om een font toe te voegen */
  
  
  
  window.addEventListener('resize', function () { 
    "use strict";
    window.location.reload(); 
});

/* Trick om een refresh te doen als de window wordt geresized. Op die manier geen nare overlappingen */

