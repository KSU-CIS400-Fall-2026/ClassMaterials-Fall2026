using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerWPFDemo
{
    public class Room
    {
        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int Floor { get; set; }

        public int Capacity { get; set; }

        public decimal Rate { get; set; }

        public string Status { get; set; }

        public bool IsClean { get; set; }

        public bool HasBalcony { get; set; }
    }
}
