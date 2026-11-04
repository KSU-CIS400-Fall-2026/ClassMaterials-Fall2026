using System;
using System.Collections.Generic;
using System.Text;
using VehicleRentalManager.Models;
using System.IO;

namespace VehicleRentalManager.ViewModels
{
    public class RentalReportViewModel
    {
        private VehicleManager _manager;

        public RentalReportViewModel(VehicleManager manager)
        {
            _manager = manager;

        }


        public int TotalVehicles
        {
            get
            {
              return  _manager.Vehicles.Count();

            }
        }

        public int AvailableVehicles
        {
            get
            {
                return _manager.Vehicles.Count(vehicle => vehicle.IsAvailable);
            }
        }

        public int RentedVehicles
        {
            get
            {
                return _manager.Vehicles.Count(vehicle => !vehicle.IsAvailable);            }
        }
       

      public double UtilizationRate
        {
            get
            {
                if(TotalVehicles == 0)
                {
                    return 0;
                }

                return (double) RentedVehicles / TotalVehicles * 100;

            }
        }

        public decimal TotalRevenue
        {
            get
            {
                decimal total = 0;

                foreach (Rental rent in _manager.Rentals)
                {
                    total += rent.TotalCharge;
                }

                return total;

                //return _manager.Rentals.Sum(rental => rental.TotalCharge);


            }
        }


















        public string GenerateHtml()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");

            html.AppendLine("<head>");
            html.AppendLine("<title>Vehicle Rental Report</title>");
            html.AppendLine("</head>");

            html.AppendLine("<body>");

            html.AppendLine("<h1>Vehicle Rental Report</h1>");

            html.AppendLine(
                $"<p>Total Vehicles: {TotalVehicles}</p>");

            html.AppendLine(
                $"<p>Available Vehicles: {AvailableVehicles}</p>");

            html.AppendLine(
                $"<p>Rented Vehicles: {RentedVehicles}</p>");

            html.AppendLine(
                $"<p>Utilization Rate: {UtilizationRate:F1}%</p>");

            html.AppendLine(
                $"<p>Total Revenue: {TotalRevenue:C}</p>");

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }


        public string SaveHtmlReport()
        {
            // First generate the HTML document.
            string html = GenerateHtml();

            // Create a filename containing the current date and time.
            string fileName =
                $"VehicleReport_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.html";

            // For this classroom demo, save to the Desktop.
            string desktop =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);

            // Safely combine the folder and filename.
            string filePath =
                Path.Combine(desktop, fileName);

            // Write the HTML text into the file.
            File.WriteAllText(filePath, html);

            // Return the path so the View knows where
            // the file was saved.
            return filePath;
        }



    }
}
