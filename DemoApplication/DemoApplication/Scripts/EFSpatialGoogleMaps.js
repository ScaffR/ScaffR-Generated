(function () {
    var geocoder, autocomplete;
    // Method signature matching $.fn.each()'s, for easy use in the .each loop later.
    var initialize = function (i, el) {
        geocoder = new google.maps.Geocoder();
                
        // el is the input element that we need to initialize a map for, jQuery-ize it,
        //  and cache that since we'll be using it a few times.

        var $address = $(this).closest('.control-group').find('[data-address]');
        var $input = $(el);
        
        // Create the map div and insert it into the page.
        var $map = $('<div>', {
            css: {
                width: '100%',
                height: '400px'
            }
        }).insertAfter($input);

        var parseLatLong = function (value) {
            if (!value) { return undefined; }

            var values = value.match(/-?\d+\.\d+/g);

            return {
                latitude: values[0],
                longitude: values[1]
            };
        };

        // Attempt to parse the address or lat/long coordinates out of this input element.
        var latLong = parseLatLong(this.value);

        // If there was a problem attaining a lat/long from the input element's value,
        //  set it to a sensible default that isn't in the middle of the ocean.
        if (!latLong || !latLong.latitude || !latLong.longitude) {
            latLong = {
                latitude: 40.716948,
                longitude: -74.003563
            };
        }

        // Create a "Google(r)(tm)" LatLong object representing our DBGeometry's lat/long.
        var position = new google.maps.LatLng(latLong.latitude, latLong.longitude);

        // Initialize the map widget.
        var map = new google.maps.Map($map[0], {
            zoom: 14,
            center: position,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            maxZoom: 14
        });

        // Place a marker on it, representing the DBGeometry object's position.
        var marker = new google.maps.Marker({
            position: position,
            map: map
        });

        var updateMarker = function (updateEvent) {
            marker.setPosition(updateEvent.latLng);

            // This new location might be outside the current viewport, especially
            //  if it was manually entered. Pan to center on the new marker location.
            map.panTo(updateEvent.latLng);

            // Black magic, courtesy of Hanselman's original version.
            $input.val(marker.getPosition().toUrlValue(13));
        };

        var setLocation = function (value) {
            var value = new google.maps.LatLng(value.latitude, value.longitude);

            updateMarker({ latLng: value });
        };

        // If the input came from an EditorFor, initialize editing-related events.
        //if ($input.hasClass('hidden-for-dbgeography')) {
        //    google.maps.event.addListener(map, 'click', updateMarker);

        //    // Attempt to react to user edits in the input field.
        //    $input.on('change', function () {
        //        var latLong = parseLatLong(this.value);

        //        if (latLong) {
        //            setLocation(latLong);
        //        }
        //    });
        //}
        
        // wire up autocomplete
        if ($address.length) {

            autocomplete = new google.maps.places.Autocomplete($address[0]);
            autocomplete.bindTo('bounds', map);

            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                var place = autocomplete.getPlace();
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                } else {
                    map.setCenter(place.geometry.location);
                    map.setZoom(17);  // Why 17? Because it looks good.
                }

                marker.setPosition(place.geometry.location);

                $input.val(marker.getPosition().toUrlValue(13));
            });
        }

    };

    // Find all DBGeography inputs and initialize maps for them.
    $('.hidden-for-dbgeography').each(initialize);
})();