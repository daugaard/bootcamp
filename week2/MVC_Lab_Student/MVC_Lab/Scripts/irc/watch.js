(function () {
	'use strict';

	var trailer = document.getElementById('trailer');

	$('.navbar-collapse').on('activate.bs.scrollspy', function () {
		if (document.querySelector('.nav .active').textContent === 'Watch') {
			trailer.play();
		} else {
			trailer.pause();
		}
	});
})();