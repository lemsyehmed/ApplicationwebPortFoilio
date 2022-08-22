using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Address:EntitiyBase
    {
        public string Street { get; set; }

        public string City { get; set; }

        public int Number { get; set; }
    }
}
