using Car_Rental.Repositories;
using System;

namespace Car_Rental.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int StatusService { get; set; }

        public string LicensePlate { get; set; }
    }
}
