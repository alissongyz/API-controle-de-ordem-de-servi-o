using ProjectOs.Domain.Models;
using System;

namespace ProjectOs.Dto.OrderOfService
{
    public class OsOutputDto
    {
        public string Id { get; set; }

        public DateTime DataOpeningaOS { get; set; }

        public string OS { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Neighborhood { get; set; }

        public int Number { get; set; }

        public string Complement { get; set; }

        public string ServicePerfomed { get; set; }

        public DateTime DeadlineOS { get; set; }

        public bool FinishedTask { get; set; }

        public Materials Materials { get; set; }
    }
}
