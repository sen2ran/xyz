<template>
  <div class="d-flex flex-row align-items-center justify-content-center gmap-container">
    <div id="googleMap" style="width:100%; height:290px;"></div>
  </div>
</template>

<script>
export default {
  name: "GoogleMap",
  props: ["geometry"],
  data() {
    return {
      map: null,
      markers: [],
    };
  },
  watch: {
    geometry: {
      immediate: true,
      handler(val) {
        if (val) {
          this.placeMarker(val);
        }
      },
    },
  },
  mounted() {
    this.initFn();
  },
  methods: {
    initFn() {
      var myLatLng = { lat: 7.8731, lng: 80.7718 };
      this.map = new window.google.maps.Map(
        document.getElementById("googleMap"),
        {
          center: myLatLng,
          draggable: true,
          zoom: 6,
          streetViewControl: false,
          mapTypeId: "roadmap",
        }
      );
      this.map.addListener("click", (e) => {
        this.placeMarker(e.latLng);
      });
    },
    placeMarker(location) {
      this.setMapOnAll(null);
      let marker = new window.google.maps.Marker({
        position: location,
        map: this.map,
      });
      let payload = {
        lat: location.lat(),
        long: location.lng(),
      };
      this.$emit("setLatLng", payload);
      this.map.setCenter(location);
      this.map.setZoom(15);
      this.markers.push(marker);
    },
    setMapOnAll(map) {
      for (var i = 0; i < this.markers.length; i++) {
        this.markers[i].setMap(map);
      }
    },
  },
};
</script>