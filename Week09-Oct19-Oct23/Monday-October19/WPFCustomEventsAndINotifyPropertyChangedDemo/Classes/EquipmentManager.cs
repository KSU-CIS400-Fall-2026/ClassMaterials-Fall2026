using System;
using System.Collections.Generic;
using System.Text;

namespace WPFEventsDemo.Classes
{
    class EquipmentManager
    {

        public event EventHandler? EquipmentAdded;

        public void AddEquipment()
        {
            EquipmentAdded?.Invoke(this, EventArgs.Empty);
        }

    }
}
