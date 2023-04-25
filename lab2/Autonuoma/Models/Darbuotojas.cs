namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbuotojas' entity.
/// </summary>
public class DarbuotojasL
{
    [DisplayName("El. Pastas")]
    [EmailAddress]
	[Required]
	public string ElPastas { get; set; }

	[DisplayName("Vardas")]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Pavardė")]
	[Required]
	public string Pavarde { get; set; }

    [DisplayName("Gimimo data")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	[Required]
	public DateTime? GimimoData { get; set; }

    [DisplayName("TelefonoNumeris")]
	[Required]
	public string TelefonoNumeris { get; set; }

    [DisplayName("Adresas")]
	[Required]
	public string Adresas { get; set; }

   [DisplayName("Biuro Adresas")]
	[Required]
	public string BiuroAdresas { get; set; }
}
