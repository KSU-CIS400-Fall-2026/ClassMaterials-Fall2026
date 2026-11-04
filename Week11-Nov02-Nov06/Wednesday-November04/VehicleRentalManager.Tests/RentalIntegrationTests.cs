using System;
using System.Collections.Generic;
using System.Text;
using VehicleRentalManager.Models;
using VehicleRentalManager.ViewModels;

namespace VehicleRentalManager.Tests
{
    public class RentalIntegrationTests
    {
        [Fact]
        public void TestProjectIsWorking()
        {
            int expected = 10;

            int actual = 5 + 5;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReportViewModel_CalculationTest()
        {
            //Create a manager that stores vehicles and rentals
            VehicleManager manager = new VehicleManager();

            //Create 4 Vehicles

            Vehicle toyota = new Vehicle
            {
                VehicleNumber = "VEH=001",
                MakeModel = "Toyota Camry",
                DailyRate = 75m,
                IsAvailable = true,
            };
            Vehicle honda = new Vehicle
            {
                VehicleNumber = "VEH-002",
                MakeModel = "Honda CR-V",
                DailyRate = 95m,
                IsAvailable = false
            };

            Vehicle ford = new Vehicle
            {
                VehicleNumber = "VEH-003",
                MakeModel = "Ford Explorer",
                DailyRate = 110m,
                IsAvailable = false
            };

            Vehicle nissan = new Vehicle
            {
                VehicleNumber = "VEH-004",
                MakeModel = "Nissan Altima",
                DailyRate = 70m,
                IsAvailable = true
            };

            //Add to the Vehicle collections
            manager.Vehicles.Add(toyota);
            manager.Vehicles.Add(honda);
            manager.Vehicles.Add(ford);
            manager.Vehicles.Add(nissan);

            //Create rentals
            Rental rental1 = new Rental
            {
                RentalNumber = "RENT-001",
                CustomerName = "Jordan Smith",
                Vehicle = honda,
                NumberOfDays = 3,
                AmountPaid = 285m
            }
            ;

            // Create the second rental.
            Rental rental2 = new Rental
            {
                RentalNumber = "RENT-002",
                CustomerName = "Taylor Brown",
                Vehicle = ford,
                NumberOfDays = 5,
                AmountPaid = 300m
            };

            // Add rentals to the manager.
            manager.Rentals.Add(rental1);
            manager.Rentals.Add(rental2);

            //Create viewmodel using our manager
            RentalReportViewModel viewModel = new RentalReportViewModel(manager);

            //Retrieve the report calculation

            int totalVehicles = viewModel.TotalVehicles;
            int available = viewModel.AvailableVehicles;

            int rented = viewModel.RentedVehicles;

            double utilization = viewModel.UtilizationRate;

            decimal revenue = viewModel.TotalRevenue;

            Assert.Equal(4, totalVehicles);
            Assert.Equal(2, available);
            Assert.Equal(2, rented);
            Assert.Equal(50.0, utilization);
            Assert.Equal(835, revenue);

        }
    }
}
