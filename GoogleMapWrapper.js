$("#__tab_ContentPlaceHolder2_tbMain_tbpnlMaps").live("click", function () {

    initialize();


});

function initialize() {
    // GService.GetGoogleObject(fGetGoogleObject);//
    fGetGoogleObject(googleObject);
   
  
}
function fGetGoogleObject(result) {
  
    var myOptions = {
        zoom: 14,
        panControl: true,
        zoomControl: true,
        mapTypeControl: true,
        scaleControl: true,
        streetViewControl: true,
        overviewMapControl: true,
        center: new google.maps.LatLng(result.CenterPoint.Latitude, result.CenterPoint.Longitude),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    //Draw the Map
    map = new google.maps.Map(document.getElementById("GoogleMap_Div"), myOptions);
    //plot the points to show places
    plotPoints(result);
}
function plotPoints(result_value) {

    var total = result_value.Points.length;
    var infowindow = new google.maps.InfoWindow();
    var marker, i;
    var ZindexVal;
    for (i = 0; i < total; i++) {
        if (i == 0)
            ZindexVal = 1000;
        else
            ZindexVal = 500;
        var image = result_value.Points[i].IconImage;
        var myLatLng = new google.maps.LatLng(result_value.Points[i].Latitude, result_value.Points[i].Longitude);
        if (result_value.Points[i].IconImage != '') {
            marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                icon: image,
                zIndex: parseInt(ZindexVal)
            });
            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(result_value.Points[i].InfoHTML);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }
    }
}
