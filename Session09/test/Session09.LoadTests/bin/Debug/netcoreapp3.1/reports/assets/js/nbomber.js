$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#wrapper").toggleClass("active");
    $("#page-content-wrapper").toggleClass("active");    
});

window.chartColors = {
	red: 'rgb(255, 99, 132)',
	redlight: 'rgba(255, 99, 132, 0.2)',
	orange: 'rgb(255, 159, 64)',	
	yellow: 'rgb(255, 205, 86)',
	yellowlight: 'rgba(255, 206, 86, 0.2)',	
	green: 'rgb(75, 192, 192)',
	greenlight: 'rgba(75, 192, 192, 0.2)',	
	blue: 'rgb(54, 162, 235)',
	bluelight: 'rgba(54, 162, 235, 0.2)',
	purple: 'rgb(153, 102, 255)',
	grey: 'rgb(201, 203, 207)'
};