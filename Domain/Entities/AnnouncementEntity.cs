using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class AnnouncementEntity : BaseEntity 
    {
        [Column("marca")]
        public string Brand { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("version")]
        public string Version { get; set; }
        [Column("ano")]
        public int Year { get; set; }
        [Column("quilometragem")]
        public int Mileage { get; set; }
        [Column("observaoca")]
        public string Note { get; set; }
    }
}
