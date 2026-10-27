using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPFEventsDemo.Classes
{
    class Equipment : INotifyPropertyChanged
    {
        private string _name;
        private string _category;
        private int _quantity;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ReportPropertyChanged(nameof(Name));
            }
        }


        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                ReportPropertyChanged(nameof(Category));
            }
        }



        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                ReportPropertyChanged(nameof(Quantity));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;


        public void ReportPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        }


    }
}
