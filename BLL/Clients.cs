
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz.BLL
{
    public class Clients
    {
        public int ClientID { get; set; }
        public string  UniName{ get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public float Credit { get; set; }
    }
}
