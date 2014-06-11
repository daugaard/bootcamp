(function () {
	'use strict';

	var nameInput = document.getElementById('name');
	var nameOutput = document.getElementById('name-comment');

	nameInput.addEventListener('blur', function () {
		if (nameInput.value) {
			nameOutput.textContent = 'Nice to meet you, ' + nameInput.value + '.';
			nameOutput.classList.add('revealed');
		}
	});

	nameInput.addEventListener('focus', function () {
		nameOutput.classList.remove('revealed');
	});
})();


(function () {
	'use strict';

	var cityInput = document.getElementById('city');
	var cityOutput = document.getElementById('city-comment');

	function getWeather(city, successCallback, errorCallback) {
		var request = new XMLHttpRequest();
		request.onreadystatechange = function () {
			if (request.readyState === 4) {
				if (request.status === 200) {
					var response = JSON.parse(request.responseText);
					if (response.cod == 200 && response.name.toUpperCase() === city.toUpperCase()) {
						successCallback(response.weather[0].main);	
					} else {
						errorCallback();
					}
				} else {
					errorCallback();
				}
			}
		};
		request.open('GET', 'http://api.openweathermap.org/data/2.5/weather?q=' + city, true);
		request.send();
	}

	cityInput.addEventListener('blur', function () {
		var city = this.value;
		if (city) {
			getWeather(city, function (weather) {
				switch (weather) {
					case 'Thunderstorm':
						cityOutput.textContent = city + '?  Thunderstorms ahoy!  Better chat for a bit in case the power goes out.';
						break;
					case 'Drizzle':
					case 'Rain':
						cityOutput.textContent = city + '?  Looks like rain, better stay dry and chat with your friends.';
						break;
					case 'Snow':
						cityOutput.textContent = city + '?  I heard it was snowing there.  Cuddle up and chat away the day.';
						break;
					case 'Clouds':
						cityOutput.textContent = city + '?  It\'s too cloudy to do anything but chat.';
						break;
					case 'Clear':
						cityOutput.textContent = city + '?  This website isn\'t going anywhere, go outside and enjoy the sun!';
						break;
					default:
						cityOutput.textContent = city + '?  I hear it gets crazy weather.  Safest to stay inside and chat.';
						break;
				}
				cityOutput.classList.add('revealed');
			}, function () {
				cityOutput.textContent = city + '?  Never heard of it.  At least they have internet there.';
				cityOutput.classList.add('revealed');
			});
		}
	});

	cityInput.addEventListener('focus', function () {
		cityOutput.classList.remove('revealed');
	});
})();

(function () {
	'use strict';

	var sendButton = document.getElementById('send');
	var robot = document.getElementById('robot-wrapper');
	var speech = document.getElementById('robot-speech');
	var hasAnimated = false;
	var slideDuration = 1000;
	var fadeDuration = 500;
	var offset = 800;
	var start, progress;

	function slideStep(timestamp) {
		start || (start = timestamp);
		progress = (timestamp - start) / slideDuration;
		robot.style.left = ((1 - progress) * 100) + '%';
		if (progress >= 1) {
			robot.style.left = 0;
			start = null;
			requestAnimationFrame(fadeStep);
		} else {
			requestAnimationFrame(slideStep);
		}
	}

	function fadeStep(timestamp) {
		start || (start = timestamp);
		progress = (timestamp - start) / fadeDuration;
		speech.style.opacity = progress;
		if (progress >= 1) {
			robot.style.opacity = 1;
			start = null;
		} else {
			requestAnimationFrame(fadeStep);
		}
	}

	robot.style.left = '100%';

	sendButton.addEventListener('click', function (event) {
		event.preventDefault();
		if (!hasAnimated) {
			//hasAnimated = true;
			speech.style.opacity = 0;
			requestAnimationFrame(slideStep);
		}
	});
})();