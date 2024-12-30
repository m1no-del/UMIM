using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class searchResultControl : UserControl
    {
        private Form1 form1;
        public searchResultControl(Form1 form)
        {
            InitializeComponent();
            this.form1 = form;  // Save the reference to Form1
        }

        string tempBuildingName;
        public static string Building;


        private void searchResultControl_Load(object sender, EventArgs e)
        {
            
        }


        // Method to display details of a specific BuildingData object
        public void DisplayDetails(BuildingData building)
        {
            lbName.Text = building.BuildingName;  // Display BuildingName in lbName
            tempBuildingName = building.BuildingName;  // Store BuildingName as tempBuildingN

        }
        public async void searchresult(string key)
        {
            // Create an instance of BuildingData and call the SearchBuildings method
            BuildingData buildingData = new BuildingData();
            await buildingData.SearchBuildings(key);

            // Retrieve the first matching result from the static list
            if (BuildingData.list.Any())
            {
                lbName.Text = BuildingData.list[0].BuildingName; // Display the first result's BuildingName
            }
            else
            {
                lbName.Text = "No results found"; // Handle the case when no results match
            }
        }

        private void searchResultControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;   // Change background to a subtle gray
            this.Cursor = Cursors.Hand;        // Change cursor to a hand pointer for better UX
        }

        private void searchResultControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;           // Restore original background
            this.Cursor = Cursors.Default;
        }
        public static bool clicked = false;
        private async void HandleSearchResultClick()
        {
            if (searchResultControl.clicked)
            {
                BuildingData selectedBuilding = new BuildingData();
                await selectedBuilding.GetSelected(searchResultControl.Building);

                // Reset the result container height
                form1.resultContainer.Height = 0;

                // Display the room image if available
                if (selectedBuilding.RoomImage != null)
                {
                    try
                    {
                        // Convert byte[] to an image and set it to the PictureBox
                        using (MemoryStream ms = new MemoryStream(selectedBuilding.RoomImage))
                        {
                            form1.image.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error displaying image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form1.image.Image = null;
                    }
                }
                else
                {
                    // Clear the PictureBox if no image is available
                    form1.image.Image = null;
                }

                // Reset the clicked flag
                searchResultControl.clicked = false;
            }
        }

        private async void searchResultControl_Click(object sender, EventArgs e)
        {
            
            clicked = true;
            Building = tempBuildingName;
            Form1 form1Instance = (Form1)Application.OpenForms["form1"];

             HandleSearchResultClick();

            // Use the BuildingData class to fetch the coordinates based on the building name
            BuildingData buildingData = new BuildingData();
            await buildingData.GetSelected(Building);

            // Add the marker to the map if it doesn't already exist
            await form1Instance.AddMarkerToMap((double)buildingData.Latitude, (double)buildingData.Longitude, "Your Destination");

            // Update the UI (UI thread)
            this.Invoke((Action)(() =>
            {
                form1Instance.searchBar.Width = 500;

                form1Instance.buildingName.Text = "University of Mindanao - " + buildingData.BuildingName;
                form1Instance.location.Text = "University of Mindanao, New Matina, Davao City, Davao del Sur";
                form1Instance.txSearch.Text = buildingData.BuildingName;
                form1Instance = (Form1)Application.OpenForms["form1"];
                form1Instance.resultContainer.Height = 0;
                form1Instance.txSearch.ForeColor = Color.Black;
            }));
        }
    }
}
