using Guna.UI2.WinForms;
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
    public partial class buildings : Form
    {
        public buildings()
        {
            InitializeComponent();
        }

        private void Buildings_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            var buildings = new List<Building>
        {
          new Building { Name = "BE BUILDING", Description = "BUSINESS AND ENGINEERING COURSES. COLLEGES : CEE, CAE, CHE." },
          new Building { Name = "GET BUILDING", Description = "GUILLERMO E. TORRES BUILDING. COLLEGES : CCJE AND CTE." },
          new Building { Name = "DPT BUILDING", Description = "DOLORES P. TORRES. COLLEGES : CHSE, CASE, CAFAE, AND CCE." },
          new Building { Name = "PS BUILDING", Description = "PROFESSIONAL SCHOOL COURSES AND COLLEGE OF LEGAL EDUCATION." },
          new Building { Name = "MAA GATE", Description = "ENTRANCE FOR MAA." },
          new Building { Name = "MATINA GATE", Description = "ENTRANCE FOR MATINA GRAVAHAN." },
          new Building { Name = "UMPX BUILDING", Description = "UNIVERSITY OF MINDANAO FOOD SERVICES" },
          new Building { Name = "GYM", Description = "STATE OF THE ART FITNESS FACILITY FOR STUDENTS" },
          new Building { Name = "MOTORPOOL", Description = "FACILITY RESPONSIBLE FOR MAINTAINING AND MANAGING THE UNIVERSITY'S FLEET OF VEHICLES." },
          new Building { Name = "UM OVAL SPORTS COMPLEX", Description = "MULTI-PURPOSE SPORTS FACILITY FOR ATHLETICS." },
          new Building { Name = "BOOKSTORE", Description = "UNIVERSITY STORE OFFERING TEXTBOOKS AND SUPPLIES." },
          new Building { Name = "STUDY HALL", Description = "QUIET SPACE FOR FOCUSED STUDENT LEARNING." },
          new Building { Name = "SSO", Description = "ENSURING CAMPUS SECURITY, SAFETY, AND EMERGENCY RESPONSE." },
          new Building { Name = "FOOD COURT 1", Description = "VARIETY OF AFFORDABLE MEALS FOR STUDENTS AND STAFF, ALONG BE BUILDING." },
          new Building { Name = "FOOD COURT 2", Description = "VARIETY OF AFFORDABLE MEALS FOR STUDENTS AND STAFF, INBETWEEN GET AND DPT BUILDING." },
          new Building { Name = "CAGLIARI HALL", Description = "SERVES AS A CENTRAL AREA FOR ACADEMIC FUNCTIONS." },
           new Building { Name = "FEA COVERED COURT", Description = "OUTDOOR FACILITY FOR SPORTS AND RECREATIONAL ACTIVITIES, LOCATED NEAR FEA BUILDING." },
          new Building { Name = "CHE", Description = "USED FOR PRACTICAL LEARNING IN HOSPITALITY, CULINARY, AND TOURISM COURSES." },
          new Building { Name = "ROTC FIELD", Description = "LOCATION FOR MILITARY TRAINING, DRILLS, AND PHYSICAL FITNESS ACTIVITIES." },
          new Building { Name = "ELEMENTARY AND HIGHSCHOOL BUILDING", Description = "HOUSES CLASSROOMS AND FACILITIES FOR K-12 STUDENTS." },
          new Building { Name = "HRM HOT KITCHEN BUILDING", Description = "FACILITY FOR CULINARY PRACTICES AND HANDS-ON COOKING TRAINING." },
          new Building { Name = "CHAPEL", Description = "A SACRED SPACE FOR WORSHIP, PRAYERS, AND SPIRITUAL REFLECTION." },
          new Building { Name = "SPORTS DIRECTOR BUILDING", Description = "OFFICES AND FACILITIES FOR ATHLETIC MANAGEMENT AND EVENTS." },
          new Building { Name = "FITNESS GYM BUILDING", Description = "EQUIPPED WITH EXERCISE FACILITIES FOR STUDENT FITNESS AND WELLNESS." },
          new Building { Name = "ALUMNI BUILDING", Description = "A HUB FOR ALUMNI EVENTS, MEETINGS, AND REUNIONS." },
          new Building { Name = "RESEARCH HANGAR", Description = "FACILITY FOR CONDUCTING SCIENTIFIC RESEARCH AND EXPERIMENTS." },
          new Building { Name = "MN BUILDING", Description = "HOUSES ACADEMIC OFFICES AND CLASSROOMS FOR VARIOUS PROGRAMS." },
          new Building { Name = "FEA BUILDING", Description = "FACILITY AND ROOMS FOR ENVIRONMENTAL SCIENCE AND RELATED COURSES." },
          new Building { Name = "LIBRARY", Description = "A RESOURCE CENTER FOR STUDYING, RESEARCH, AND ACCESSING ACADEMIC MATERIALS." }

        };

            // Set up the DataGridView
            dataGridView1.DataSource = buildings;
            dataGridView1.Columns[0].Width = 200;  // Name column (adjust as necessary)
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public class Building
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

    }
}
