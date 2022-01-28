using ProjectOs.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectOs.Dto.OrderOfService
{
    public class CreateOsDto
    {
		[Required(ErrorMessage = "Data de abertura da OS é campo obrigatório.")]
		public DateTime DataOpeningaOS { get; set; }

		[Required(ErrorMessage = "Número da OS é campo obrigatório.")]
		public string OS { get; set; }

		[Required(ErrorMessage = "Cidade é campo obrigatório.")]
		public string City { get; set; }

		[Required(ErrorMessage = "Endereço é campo obrigatório.")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Bairro é campo obrigatório.")]
		public string Neighborhood { get; set; }

		[Required(ErrorMessage = "Número é campo obrigatório.")]
		public int Number { get; set; }

		public string Complement { get; set; }

		public string ServicePerfomed { get; set; }

		[Required(ErrorMessage = "Prazo da OS é campo obrigatório.")]
		public DateTime DeadlineOS { get; set; }

		public Materials Materials { get; set; }
	}
}
