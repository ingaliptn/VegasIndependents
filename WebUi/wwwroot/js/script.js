/* 
	author: istockphp.com
*/
jQuery(function($) {
	
	$("a.topopup").click(function() {
			loading(); // loading
			setTimeout(function(){ // then show popup, deley in .5 second
				loadPopup(); // function show popup 
			}, 500); // .5 second
	return false;
	});
	
	$("a.topopup2").click(function() {
			loading(); // loading
			setTimeout(function(){ // then show popup, deley in .5 second
				loadPopup2(); // function show popup 
			}, 500); // .5 second
	return false;
	});
	
	/* event for close the popup */
	$("div.close").hover(
					function() {
						$('span.ecs_tooltip').show();
					},
					function () {
    					$('span.ecs_tooltip').hide();
  					}
				);
	
	$("div.close").click(function() {
		disablePopup();  // function close pop up
	});
	
	$(".cancel_gray_btn").click(function() {
		disablePopup();  // function close pop up
	});
	
	$(".cancel_gray_btn2").click(function() {
		disablePopup2();  // function close pop up
	});
	
	$(this).keyup(function(event) {
		if (event.which == 27) { // 27 is 'Ecs' in the keyboard
			disablePopup();  // function close pop up
		}  	
	});
	
	$("div#backgroundPopup").click(function() {
		disablePopup();  // function close pop up
	});
	
	$('a.delete').click(function() {
		confirm('Confirm delete this user?');
	return false;
	});
	$('a.saved').click(function() {
		alert('Saved!');
	return false;
	});
	$('a.activate').click(function() {
		alert('User Activated!');
	return false;
	});
	$('a.deactivate').click(function() {
		alert('User Deactivated!');
	return false;
	});
	
	$('.btn-pop').click(function() {
		alert('User Created!');
	return false;
	});
	
	$('.btn-pop-agent').click(function() {
		alert('Agent Created!');
	return false;
	});
	
	$('.btn-pop-company').click(function() {
		alert('Company Created!');
	return false;
	});
	
	$('.save-conf').click(function() {
		alert('Settings Saved!');
	return false;
	});
	
	

	 /************** start: functions. **************/
	function loading() {
		$("div.loader").show();  
	}
	function closeloading() {
		$("div.loader").fadeOut('normal');  
	}
	
	var popupStatus = 0; // set value
	
	function loadPopup() { 
		if(popupStatus == 0) { // if value is 0, show popup
			closeloading(); // fadeout loading
			$("#toPopup").fadeIn(0500); // fadein popup div
			$("#backgroundPopup").css("opacity", "0.7"); // css opacity, supports IE7, IE8
			$("#backgroundPopup").fadeIn(0001); 
			popupStatus = 1; // and set value to 1
		}	
	}
	
	function loadPopup2() { 
		if(popupStatus == 0) { // if value is 0, show popup
			closeloading(); // fadeout loading
			$("#toPopup2").fadeIn(0500); // fadein popup div
			$("#backgroundPopup").css("opacity", "0.7"); // css opacity, supports IE7, IE8
			$("#backgroundPopup").fadeIn(0001); 
			popupStatus = 1; // and set value to 1
		}	
	}
		
	function disablePopup() {
		if(popupStatus == 1) { // if value is 1, close popup
			$("#toPopup").fadeOut("normal");  
			$("#backgroundPopup").fadeOut("normal");  
			popupStatus = 0;  // and set value to 0
		}
	}
	
	function disablePopup2() {
		if(popupStatus == 1) { // if value is 1, close popup
			$("#toPopup2").fadeOut("normal");  
			$("#backgroundPopup").fadeOut("normal");  
			popupStatus = 0;  // and set value to 0
		}
	}
	/************** end: functions. **************/
}); // jQuery End