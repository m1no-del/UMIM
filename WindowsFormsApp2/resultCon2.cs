using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class resultCon2 : UserControl
    {
        private Form1 form1Instance;
        public resultCon2(Form1 form)
        {
            InitializeComponent();
            form1Instance = form;
        }
        string temp_id;
        public static string id;
        public void DisplayDetails(BuildingData building)
        {
            lbDirection.Text = building.BuildingName;
            temp_id = id;
        }
        public async void searchresult(string key)
        {
            // Create an instance of BuildingData and call the SearchBuildings method
            BuildingData buildingData = new BuildingData();
            await buildingData.SearchBuildings(key);

            // Retrieve the first matching result from the static list
            if (BuildingData.list.Any())
            {
                lbDirection.Text = BuildingData.list[0].BuildingName; // Display the first result's BuildingName
            }
            else
            {
                lbDirection.Text = "No results found"; // Handle the case when no results match
            }
        }

        private void resultCon2_Load(object sender, EventArgs e)
        {

        }

        private void resultCon2_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;   // Change background to a subtle gray
            this.Cursor = Cursors.Hand;
        }

        private void resultCon2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;           // Restore original background
            this.Cursor = Cursors.Default;
        }
        public static bool clicked = false;

        private async void resultCon2_Click(object sender, EventArgs e)
        {
            clicked = true;
            BuildingData buildingData = new BuildingData();
            id = temp_id;
            if (BuildingData.list.Any())
            {
                buildingData = BuildingData.list[0]; // Assuming the first result is selected
            }
            form1Instance.searchFrom.Text = buildingData.BuildingName;
            form1Instance.resultContainer2.Height = 0;
            form1Instance.directionBtn.PerformClick();
            await form1Instance.AddMarkerToMap((double)buildingData.Latitude, (double)buildingData.Longitude,"Your Destination");
        }
    }
}
