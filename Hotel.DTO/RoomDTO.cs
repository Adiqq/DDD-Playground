using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class RoomDTO
    {
        public string Type { get; set; }
        public string Quality { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<string> Features { get; set; } 
    }
}
