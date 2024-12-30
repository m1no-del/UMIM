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
    public partial class resultCon1 : UserControl
    {
        private Form1 form1Instance;
        public resultCon1(Form1 form)
        {
            InitializeComponent();
            form1Instance = form;  // Store the reference to Form1
        }
        string temp_id;
        public static string id;
        private void resultCon1_Load(object sender, EventArgs e)
        {

        }
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
        
        private void resultCon1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;   // Change background to a subtle gray
            this.Cursor = Cursors.Hand;        // Change cursor to a hand pointer for better UX
        }

        private void resultCon1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;           // Restore original background
            this.Cursor = Cursors.Default;
        }
        public static bool clicked = false;
        private async void resultCon1_Click(object sender, EventArgs e)
        {
            clicked = true;
            BuildingData buildingData = new BuildingData();
            id = temp_id;
            if (BuildingData.list.Any())
            {
                buildingData = BuildingData.list[0]; // Assuming the first result is selected
            }
            form1Instance.searchTo.Text = buildingData.BuildingName;
            form1Instance.resultContainer1.Height = 0;
            form1Instance.directionBtn.PerformClick();
            await form1Instance.AddMarkerToMap((double)buildingData.Latitude, (double)buildingData.Longitude,"Your Are Here!");

        }
    }
}
