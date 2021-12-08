using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Version
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
    }
}
