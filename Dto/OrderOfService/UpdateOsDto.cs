using ProjectOs.Domain.Models;
using System;

namespace ProjectOs.Dto.OrderOfService
{
    public class UpdateOsDto
    {
		public string OS { get; set; }

		public string City { get; set; }

		public string Address { get; set; }

		public string Neighborhood { get; set; }

		public int Number { get; set; }

		public string Complement { get; set; }

		public string ServicePerfomed { get; set; }

		public DateTime DeadlineOS { get; set; }

		public Materials Materials { get; set; }
	}
}
