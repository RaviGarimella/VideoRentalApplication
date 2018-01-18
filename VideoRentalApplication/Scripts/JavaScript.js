function initMap() {
    var options = {
        zoom: 8,
        center: { lat: 27.7634, lng: -82.5437 }
    }
    var map = new google.maps.Map(document.getElementById('map'), options);

    // creating array of marker objects
    var markers = [
      {
          coords: { lat: 28.0728, lng: -82.4264 },
          content: '<h1>Oak Ramble Apts</h1>'
      },
      {
          coords: { lat: 27.9659, lng: -82.8001 },
          content: '<h1>Clearwater MA</h1>'
      },
      {
          coords: { lat: 27.3364, lng: -82.5307 },
          content: '<h1>Sarasota MA</h1>'
      }
    ]

    for (var i = 0; i < markers.length; i++) {
        addMarker(markers[i]);
    }
    google.maps.event.addListener(map, 'click', function (event) {
        addMarker({ coords: event.latLng })
    })
    function addMarker(props) {
        var marker = new google.maps.Marker({
            position: props.coords,
            map: map
        });
        if (props.content) {
            var infoWindow = new google.maps.InfoWindow({
                content: props.content
            });
            marker.addListener('click', function () {
                infoWindow.open(map, marker);
            });
        }
    }
}