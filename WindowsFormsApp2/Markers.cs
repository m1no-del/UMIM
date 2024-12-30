using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Markers
    {
        // Constructor that accepts WebView2
        private WebView2 webView2;

        public Markers(WebView2 webView2)
        {
            this.webView2 = webView2;
        }

        // Method to delete marker from map
        public async Task DeleteMarkerFromMap(double latitude, double longitude)
        {
            string script = $@"
            // Check if the markers array exists
            if (typeof window.markers !== 'undefined') {{
                // Find the index of the marker with the given coordinates
                var index = window.markers.findIndex(function(marker) {{
                    return marker[0] === {latitude} && marker[1] === {longitude};
                }});

                // If the marker exists, remove it from the map and the array
                if (index !== -1) {{
                    var markerToRemove = window.markers.splice(index, 1)[0];
                    if (markerToRemove) {{
                        map.eachLayer(function(layer) {{
                            if (layer instanceof L.Marker) {{
                                var latLng = layer.getLatLng();
                                if (latLng.lat === {latitude} && latLng.lng === {longitude}) {{
                                    map.removeLayer(layer); // Remove the marker from the map
                                }}
                            }}
                        }});
                    }}
                }}
            }}";

            // Check if CoreWebView2 is available to execute the script
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
        }
    }
}
