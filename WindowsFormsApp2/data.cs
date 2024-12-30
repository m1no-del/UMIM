using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class BuildingData
    {
        // SQL Server connection string
        string connsring = "Data Source=DESKTOP-RFCQLIV\\SQLEXPRESS01;Initial Catalog=UMIM;Integrated Security=True;Encrypt=False";

        public string BuildingName { get; set; }
        public decimal Latitude { get; set; }  // Adjusted for the decimal type of Latitude
        public decimal Longitude { get; set; } // Adjusted for the decimal type of Longitude
        public byte[] RoomImage { get; set; }  // To hold the image data

        public static List<BuildingData> list = new List<BuildingData>();

        // Search method to find buildings based on a partial BuildingName or description

        public async Task SearchBuildings(string key)
        {
            try
            {
     
                using (SqlConnection conn = new SqlConnection(connsring))
                {
                    await conn.OpenAsync(); // Asynchronously open connection

                    // Select only the necessary columns
                    string sql = "SELECT BuildingName, Latitude, Longitude FROM Building_Room WHERE BuildingName LIKE @key";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Explicitly set the parameter type for 'key'
                        cmd.Parameters.AddWithValue("@key", SqlDbType.NVarChar).Value = "%" + key + "%";

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) // Asynchronously execute query
                        {
                            list.Clear(); // Clear previous results

                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync()) // Asynchronously read rows
                                {
                                    // Create a new BuildingData object for each building
                                    BuildingData buildingData = new BuildingData
                                    {
                                        BuildingName = reader["BuildingName"].ToString(),
                                        Latitude = Convert.ToDecimal(reader["Latitude"]),
                                        Longitude = Convert.ToDecimal(reader["Longitude"])
                                    };

                                    // Add it to the list
                                    list.Add(buildingData);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error (e.g., show message or log)
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        // Method to get detailed building information (including image) based on BuildingName
        public async Task GetSelected(string buildingName)
        {
            using (SqlConnection conn = new SqlConnection(connsring))
            {
                await conn.OpenAsync(); // Asynchronously open the connection

                string sql = "SELECT * FROM Building_Room WHERE BuildingName = @buildingName";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@buildingName", buildingName);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) // Asynchronously execute the query
                    {
                        if (reader.Read())
                        {
                            // Populate properties with data from the database
                            this.BuildingName = reader["BuildingName"].ToString();
                            this.Latitude = Convert.ToDecimal(reader["Latitude"]);
                            this.Longitude = Convert.ToDecimal(reader["Longitude"]);

                            // Handle the RoomImage (if it's stored as a binary field in the database)
                            if (!(reader["RoomImage"] is DBNull))
                            {
                                this.RoomImage = (byte[])reader["RoomImage"];
                            }
                        }
                    }
                }
            }
        }
    }
}
