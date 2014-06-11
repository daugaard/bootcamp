/**
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-09
 */

(function () {
	'use strict';

	var installWatchHandler = function () {
		$('body').on('activate.bs.scrollspy', function (e) {
			var trailer = document.getElementById('trailer');
			if (e.target.lastChild.hash === "#watch") {
				if (trailer.paused) {
					trailer.play();
				}
			} else {
				trailer.pause();
			}
		});
	};
	installWatchHandler();

	var nameField = document.getElementById('name');
	var nameComment = document.getElementById('name-comment');
	nameField.onfocus = function (e) {
		nameComment.classList.remove('visible');
	};
	nameField.onblur = function (e) {
		if (nameField.value) {
			nameComment.innerText = 'Hello there ' + nameField.value + '!';
			nameComment.classList.add('visible');
		}
	};

	var cityField = document.getElementById('city');
	var cityComment = document.getElementById('city-comment');
	cityField.onfocus = function (e) {
		cityComment.classList.remove('visible');
	};
	cityField.onblur = function (e) {
		var weatherRequest = new XMLHttpRequest();

		if (cityField.value) {
			weatherRequest.onreadystatechange = function () {
				if (weatherRequest.readyState === 4 && weatherRequest.status === 200) {
					var weatherData = JSON.parse(weatherRequest.responseText);
					console.log(weatherData);
					cityComment.innerText = 'city is ' + weatherData.weather[0].description + '!';
					cityComment.classList.add('visible');
				}
			};
			weatherRequest.open(
				'GET',
				'http://api.openweathermap.org/data/2.5/weather?q=' + cityField.value
			);
			weatherRequest.send();
		}
	};

	var messageBox = document.getElementById('message');
	var sendButton = document.getElementById('send');
	var robotWrap = document.getElementById('robot-wrapper');
	sendButton.onclick = function (e) {
		if (messageBox.value) {
			robotWrap.className = 'robot-visible';
		}
		return false;
	};
	messageBox.onfocus = function () {
		robotWrap.className = '';
	};

})();
