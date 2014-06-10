/**
 * @author Clinton Freeman <clintonfreeman@infusion.com>
 * @date 2014-06-09
 */ 

var IRC = {};
(function (IRC) {
	'use strict';

	var installWatchHandler = function() {
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

	var fadeElementOut = function(elt) {
		var tick = function() {
			if (elt.style.opacity > 0.05) {
				elt.style.opacity = parseFloat(elt.style.opacity) - 0.05;
				requestAnimationFrame(tick);
			} else {
				elt.style.opacity = 0;
			}
		};
		if (!elt.style.opacity) {
			elt.style.opacity = 1;
		}
		tick();
	};

	var fadeElementIn = function(elt) {
		var tick = function() {
			if (elt.style.opacity < 1) {
				elt.style.opacity = parseFloat(elt.style.opacity) + 0.05;
				requestAnimationFrame(tick);
			} else {
				elt.style.opacity = 1;
			}
		};
		if (!elt.style.opacity) {
			elt.style.opacity = 0;
		}
		tick();
	};

	var nameField = document.getElementById('name');
	var nameComment = document.getElementById('name-comment');
	nameField.onfocus = function(e) {
		fadeElementOut(nameComment);	
	};
	nameField.onblur = function(e) {
		if (nameField.value) {
			nameComment.innerText = 'Hello there ' + nameField.value + '!';	
			fadeElementIn(nameComment);
		}
	};

	var cityField = document.getElementById('city');
	var cityComment = document.getElementById('city-comment');
	cityField.onfocus = function(e) {
		fadeElementOut(cityComment);	
	};
	cityField.onblur = function(e) {
		var weatherRequest = new XMLHttpRequest();

		if (cityField.value) {
			weatherRequest.onreadystatechange = function() {
				if (weatherRequest.readyState === 4 && weatherRequest.status === 200) {
					var weatherData = JSON.parse(weatherRequest.responseText);
					console.log(weatherData);
					cityComment.innerText = 'city is ' + weatherData.weather[0].description + '!';	
					fadeElementIn(cityComment);
				}
			};
			weatherRequest.open(
				'GET',
				'http://api.openweathermap.org/data/2.5/weather?q='+cityField.value
			);
			weatherRequest.send();
		}
	};


	// var fadeRobotIn = function(elt) {
	// 	var tick = function() {
	// 		if (elt.style.opacity < 1) {
	// 			elt.style.opacity = parseFloat(elt.style.opacity) + 0.05;
	// 			console.log(elt.offsetLeft);
	// 			elt.offsetLeft = elt.offsetLeft - 40;
	// 			debugger;
	// 			//elt.style.left = parseInt(elt.style.left.substr(0, elt.style.left.length-2), 10) - 40;
	// 			requestAnimationFrame(tick);
	// 		} else {
	// 			elt.style.opacity = 1;
	// 		}
	// 	};
	// 	if (!elt.style.opacity) {
	// 		elt.style.opacity = 0;
	// 	}
	// 	tick();
	// };

	var messageBox = document.getElementById('message');
	var sendButton = document.getElementById('send');
	var robotWrap = document.getElementById('robot-wrapper');
	sendButton.onclick = function(e) {
		if (messageBox.value) {
			//fadeRobotIn(robotWrap);
			robotWrap.className = 'robot-visible';
		}
		return false;
	};
	messageBox.onfocus = function() {
		robotWrap.className = '';
	};

})(IRC || (IRC = {}));