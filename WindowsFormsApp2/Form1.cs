    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
    using System.Text;
using System.Threading;
using System.Threading.Tasks;
    using System.Windows.Forms;
using System.Data.SqlClient;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using static WindowsFormsApp2.buildings;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public bool searchbarExpand;

        private Dictionary<string, int> locations = new Dictionary<string, int>();  // Location names to IDs
        private Dictionary<int, locate> points = new Dictionary<int, locate>();  // Location IDs to Location objects
        private Dictionary<int, List<int>> connections = new Dictionary<int, List<int>>();  // FromLocationId -> List of ToLocationIds

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            webView2.Source = new Uri("file:///C:/Users/Coco Romeo/Desktop/Vs Code/map.html");
            LoadLocationsFromDatabase();
            LoadConnectionsFromDatabase();


        }
        public class locate
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public locate(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            // Calculate distance between two locations using Haversine formula
            public double GetDistanceTo(locate other)
            {
                const double R = 6371; // Radius of the Earth in kilometers
                double latDistance = (other.Latitude - Latitude) * (Math.PI / 180);
                double lonDistance = (other.Longitude - Longitude) * (Math.PI / 180);

                double a = Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2) +
                           Math.Cos(Latitude * (Math.PI / 180)) * Math.Cos(other.Latitude * (Math.PI / 180)) *
                           Math.Sin(lonDistance / 2) * Math.Sin(lonDistance / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                return R * c; // Returns distance in kilometers
            }


        }

        public List<int> AStar(int start, int end)
        {
            var openSet = new List<int> { start };
            var cameFrom = new Dictionary<int, int>();
            var gScore = new Dictionary<int, double>();
            var fScore = new Dictionary<int, double>();

            foreach (var point in points)
            {
                gScore[point.Key] = double.PositiveInfinity;
                fScore[point.Key] = double.PositiveInfinity;
            }

            gScore[start] = 0;
            fScore[start] = Heuristic(points[start], points[end]);

            while (openSet.Count > 0)
            {
                // Get the node with the lowest fScore
                int current = openSet[0];
                foreach (var node in openSet)
                {
                    if (fScore[node] < fScore[current])
                    {
                        current = node;
                    }
                }

                if (current == end)
                {
                    // Reconstruct the path
                    var path = new List<int>();
                    while (cameFrom.ContainsKey(current))
                    {
                        path.Add(current);
                        current = cameFrom[current];
                    }
                    path.Add(start); // Make sure we add the start point to the path
                    path.Reverse();
                    return path;
                }

                openSet.Remove(current);

                foreach (var neighbor in connections[current])
                {
                    double tentativeGScore = gScore[current] + Heuristic(points[current], points[neighbor]);

                    if (tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + Heuristic(points[neighbor], points[end]);

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }

            return new List<int>(); // No path found
        }

        private double Heuristic(locate a, locate b)
        {
            return a.GetDistanceTo(b); // Use GetDistanceTo to calculate distance between two Location objects
        }



        private void LoadLocationsFromDatabase()
        {
            string query = "SELECT LocationId, Name, Location.Lat AS Latitude, Location.Long AS Longitude FROM coord"; // Adjust the query to use the GEOGRAPHY data type
            string connectionString = "Data Source=DESKTOP-RFCQLIV\\SQLEXPRESS01;Initial Catalog=UMIM;Integrated Security=True;Encrypt=False"; // Set your connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            int id = Convert.ToInt32(reader["LocationId"]);
                            double latitude = Convert.ToDouble(reader["Latitude"]);
                            double longitude = Convert.ToDouble(reader["Longitude"]);

                            locations[name] = id;
                            points[id] = new locate(latitude, longitude);
                        }
                    }
                }
            }
        }
        private void LoadConnectionsFromDatabase()
        {
            string query = "SELECT FromLocationId, ToLocationId FROM coordCon"; // Query to load connections
            string connectionString = "Data Source=DESKTOP-RFCQLIV\\SQLEXPRESS01;Initial Catalog=UMIM;Integrated Security=True;Encrypt=False"; // Set your connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fromLocationId = Convert.ToInt32(reader["FromLocationId"]);
                            int toLocationId = Convert.ToInt32(reader["ToLocationId"]);

                            if (!connections.ContainsKey(fromLocationId))
                            {
                                connections[fromLocationId] = new List<int>();
                            }

                            connections[fromLocationId].Add(toLocationId);
                        }
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
       
        void loadDetails()
        {
            var localList = BuildingData.list.ToList(); // Create a copy
            foreach (BuildingData building in localList)
            {
                searchResultControl res = new searchResultControl(this);
                res.DisplayDetails(building);
                resultContainer.Controls.Add(res);
            }
        }
        private void txSearch_TextChanged(object sender, EventArgs e)
        {

            if (txSearch.TextLength >= 1)
            {
                resultContainer.Controls.Clear();// Clear previous results and start loading indicator
                resultContainer.Height = 0;

                searchResultControl res = new searchResultControl(this);// Perform the search asynchronously
                res.searchresult(txSearch.Text);

                loadDetails();// Update UI with search results

                resultContainer.Height = resultContainer.Controls.Count * 54;// Adjust container height based on results
            }
            else
            {
                // Reset container if the search box is empty
                resultContainer.Controls.Clear();
                resultContainer.Height = 0;
            }
        }
        public async Task AddMarkerToMap(double latitude, double longitude, string labelText = "You are here")
        {
            string script = $@"
var marker = L.marker([{latitude}, {longitude}]).addTo(map);

// Store marker coordinates in a global JavaScript array to track them
if (typeof window.markers === 'undefined') {{
    window.markers = [];
}}
window.markers.push([{latitude}, {longitude}]);

// Zoom in to the marker's location
map.setView([{latitude}, {longitude}], 19); // 19 is the zoom level (you can adjust this as needed)

// Add a popup with dynamic labelText passed as a parameter
marker.bindPopup('<b>{labelText}</b>').openPopup();
";

            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
        }


        public async void delmark()
        {
            string script = @"
        if (typeof map !== 'undefined') {
            var currentZoom = map.getZoom();
            map.setZoom(currentZoom - 1); // Decrease the zoom level by 1 to zoom out
        } else {
            console.log('Map is not initialized');
        }
    ";

            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
            string deleteMarkerScript = @"
        if (typeof window.markers !== 'undefined' && window.markers.length > 0) {
            var lastMarkerCoordinates = window.markers.pop(); // Get the last added marker's coordinates
            // Find and remove the marker from the map
            map.eachLayer(function(layer) {
                if (layer.getLatLng && layer.getLatLng().lat === lastMarkerCoordinates[0] && layer.getLatLng().lng === lastMarkerCoordinates[1]) {
                    map.removeLayer(layer); // Remove the marker from the map
                }
            });
        } else {
            console.log('No markers to remove');
        }
    ";

            // Execute Remove Marker Script
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(deleteMarkerScript);
            }
            txSearch.Enabled = true;
        }
        public async void DeleteAllMarkers()
        {
            string script = @"
    if (typeof window.markers !== 'undefined' && window.markers.length > 0) {
        // Remove all markers from the map
        window.markers.forEach(function(markerCoordinates) {
            map.eachLayer(function(layer) {
                if (layer.getLatLng && layer.getLatLng().lat === markerCoordinates[0] && layer.getLatLng().lng === markerCoordinates[1]) {
                    map.removeLayer(layer); // Remove the marker from the map
                }
            });
        });
        // Clear the markers array
        window.markers = [];
        console.log('All markers have been removed');
    } else {
        console.log('No markers to remove');
    }

    // Zoom out to level 18
    if (typeof map !== 'undefined') {
        map.setZoom(18);
    } else {
        console.log('Map is not initialized');
    }
";

            // Execute the script to remove all markers and zoom out
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }

           
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            resultContainer.Height = 0;
            txSearch.Text = "Search for Building or Destination";
            searchBar.Width = 0;
            txSearch.ForeColor = Color.Silver;
            delmark();
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (searchResultControl.clicked == true)
            {
                // Create a BuildingData instance
                BuildingData selectedBuilding = new BuildingData();

                // Fetch details of the selected building based on the clicked Building name
                await selectedBuilding.GetSelected(searchResultControl.Building);

                // Display the building's image if available
                if (selectedBuilding.RoomImage != null && selectedBuilding.RoomImage.Length > 0)
                {
                    try
                    {
                        // Convert byte[] to an image and display it in the PictureBox
                        using (MemoryStream ms = new MemoryStream(selectedBuilding.RoomImage))
                        {
                            image.Image = Image.FromStream(ms); // 'image' is your PictureBox
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error displaying image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        image.Image = null; // Clear the PictureBox in case of an error
                    }
                }
                else
                {
                    // If no image is available, show a placeholder or clear the PictureBox
                    image.Image = null;
                    MessageBox.Show("No image available for the selected building.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reset the clicked flag
                searchResultControl.clicked = false;
            }
        }

        private void btnDirection_Click(object sender, EventArgs e)
        {
            searchFrom.Text = txSearch.Text;
            searchBar.Width = 0;
            directionPan.Width = 500;
            searchTo.Text = "Choose Starting Point";

            searchTo.ForeColor = Color.Silver;
            resultContainer2.Height = 0;
            resultContainer1.Height = 0;

        }
        private void loadDetails1()
        {
            foreach(BuildingData data in BuildingData.list)
            {
                resultCon1 res = new resultCon1(this);
                res.DisplayDetails(data);
                resultContainer1.Controls.Add(res);
            }
        }
        private void searchTo_TextChanged(object sender, EventArgs e)
        {
            if(searchTo.TextLength >= 1)
            {
                resultContainer1.Controls.Clear();
                resultCon1 res = new resultCon1(this);
                res.searchresult(searchTo.Text);
                loadDetails1();
                resultContainer1.Height = resultContainer1.Controls.Count * 54;

            }
            else
            {
                resultContainer1.Height = 0;
            }
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if(txSearch.Text == "Search for Building or Destination")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if(txSearch.Text == "")
            {
                txSearch.Text = "Search for Building or Destination";
                txSearch.ForeColor = Color.Silver;
            }
        }

        private void searchTo_Enter(object sender, EventArgs e)
        {
            if (searchTo.Text == "Choose Starting Point")
            {
                searchTo.Text = "";
                searchTo.ForeColor = Color.Black;
            }
        }

        private void searchTo_Leave(object sender, EventArgs e)
        {
            if (searchTo.Text == "")
            {
                searchTo.Text = "Choose Starting Point";
                searchTo.ForeColor = Color.Silver;
            }
        }

        private async void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string startLocation = searchFrom.Text;  // Get the starting location from textBox1
            string endLocation = searchTo.Text;    // Get the destination from textBox2

            // Check if the locations exist in the dictionary
            if (!locations.ContainsKey(startLocation) || !locations.ContainsKey(endLocation))
            {
                if (searchTo.Text == "" || searchTo.Text == "Choose Starting Point")
                {
                    MessageBox.Show("Please choose starting Point");
                    return;  // Exit if the locations are invalid
                }
                else if (searchFrom.Text == "")
                {
                    MessageBox.Show("Please search for desired location");
                    return;  // Exit if the locations are invalid
                }
            }

            // Get the corresponding point IDs from the dictionary
            int startPoint = locations[startLocation];
            int endPoint = locations[endLocation];

            // Run the A* algorithm to find the path between startPoint and endPoint
            List<int> path = AStar(startPoint, endPoint);

            // Check if the path is empty (no path found)
            if (path.Count == 0)
            {
                MessageBox.Show("No path found!");
                return;  // Exit if no path is found
            }

            // Prepare the path as a string of coordinates for JavaScript
            string pathCoords = string.Join(",", path.ConvertAll(p => $"[{points[p].Latitude}, {points[p].Longitude}]"));

            // Send the path to JavaScript to render on the map
            string script = $"displayPath([{pathCoords}]);";
            await webView2.ExecuteScriptAsync(script);

            double totalDistance = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                totalDistance += points[path[i]].GetDistanceTo(points[path[i + 1]]);
            }

            // Estimate walking time (assuming 5 km/h walking speed)
            double walkingSpeedKmH = 5.0; // Average walking speed
            double walkingTimeHours = totalDistance / walkingSpeedKmH;
            TimeSpan walkingTime = TimeSpan.FromHours(walkingTimeHours);

            // Display the results in a Label
            distance.Text = $"Distance: {totalDistance:F2} km\n" +
                          $"Estimated Walking Time: {walkingTime.Hours}h {walkingTime.Minutes}m {walkingTime.Seconds}s";
        }



        private void txSearch_Click(object sender, EventArgs e)
        {
            delmark();
            txSearch.Text = "";
        }

        private async void backBtn_Click(object sender, EventArgs e)
        {
            DeleteAllMarkers();
            await DeletePolylineFromMap();
            directionPan.Width = 0;
            searchBar.Width = 500;
            BuildingData buildingData = new BuildingData();
            await buildingData.GetSelected(txSearch.Text);

            // Add the marker to the map if it doesn't already exist
            await AddMarkerToMap((double)buildingData.Latitude, (double)buildingData.Longitude, "Your Destination");
        }
        private void loadDetails2()
        {
            foreach (BuildingData data in BuildingData.list)
            {
                resultCon2 res = new resultCon2(this);
                res.DisplayDetails(data);
                resultContainer2.Controls.Add(res);
            }
        }
        private void searchFrom_TextChanged(object sender, EventArgs e)
        {
            if (searchFrom.TextLength >= 1)
            {
                resultContainer2.Controls.Clear();
                resultCon2 res = new resultCon2(this);
                res.searchresult(searchFrom.Text);
                loadDetails2();
                resultContainer2.Height = resultContainer2.Controls.Count * 54;

            }
            else
            {
                resultContainer2.Height = 0;

            }
        }
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

        private async void searchTo_Click(object sender, EventArgs e)
        {
            string buildingName = searchTo.Text.Trim();  // Get building name from the TextBox
            BuildingData buildingData = new BuildingData();

            // Asynchronously call GetSelected method
            await buildingData.GetSelected(buildingName);

            if (buildingData.Latitude != 0 && buildingData.Longitude != 0)
            {
                await DeleteMarkerFromMap((double)buildingData.Latitude, (double)buildingData.Longitude);
            }
            searchTo.Text = "";
            await DeletePolylineFromMap();
        }

        private async void searchFrom_Click(object sender, EventArgs e)
        {
            string buildingName = searchFrom.Text.Trim();  // Get building name from the TextBox
            BuildingData buildingData = new BuildingData();

            // Asynchronously call GetSelected method
            await buildingData.GetSelected(buildingName);

            if (buildingData.Latitude != 0 && buildingData.Longitude != 0)
            {
                await DeleteMarkerFromMap((double)buildingData.Latitude, (double)buildingData.Longitude);
            }
            searchFrom.Text = "";
            await DeletePolylineFromMap();
        }

        public async Task DeletePolylineFromMap()
        {
            string script = @"
// Check if the currentPath polyline exists
if (typeof window.currentPath !== 'undefined' && window.currentPath) {
    map.removeLayer(window.currentPath); // Remove the polyline from the map
    window.currentPath = undefined; // Clear the reference
    console.log('Polyline removed from map');
} else {
    console.log('No polyline to remove');
}
";

            // Check if WebView2 CoreWebView2 is available
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
            else
            {
                MessageBox.Show("WebView2 is not initialized.");
            }
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            await DeletePolylineFromMap();
            DeleteAllMarkers();
            searchFrom.Text = "";
            searchTo.Text = "Choose Starting Point";
            searchTo.ForeColor = Color.Silver;
            resultContainer1.Height = 0;
            resultContainer.Height = 0;
            distance.Text = "";
            directionPan.Width = 0;
            txSearch.Text = "Search for Building or Destination";
            txSearch.ForeColor = Color.Silver;
        }
        private void instruct_Click(object sender, EventArgs e)
        {
            buildings buildingsForm = new buildings();

            // Show the form
            buildingsForm.Show();
        }
    }
}

