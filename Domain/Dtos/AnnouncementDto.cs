using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Note { get; set; }
    }
}
