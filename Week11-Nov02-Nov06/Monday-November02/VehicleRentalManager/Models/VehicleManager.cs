using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VehicleRentalManager.Models
{
    public class VehicleManager
    {
        //Collection for vehicles
        public ObservableCollection<Vehicle> Vehicles = new ObservableCollection<Vehicle>();

        //Collection for rentals
        public ObservableCollection<Rental> Rentals = new ObservableCollection<Rental>();


    }
}
