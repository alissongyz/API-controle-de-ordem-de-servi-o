using System;

namespace ProjectOs.Domain.Models
{
    public class OrderOfService
    {
		public Guid Id { get; set; }

		public DateTime DataOpeningaOS { get; set; }

		public string OS { get; set; }

		public string City { get; set; }

		public string Address { get; set; }

		public string Neighborhood { get; set; }

		public int Number { get; set; }

		public string Complement { get; set; }

		public string ServicePerfomed { get; set; }

		public DateTime DeadlineOS { get; set; }

		public bool? FinishedTask { get; set; }

		public Materials Materials { get; set; }
	}
}
