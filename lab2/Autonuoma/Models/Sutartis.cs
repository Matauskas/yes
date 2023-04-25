namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbuotojas' entity.
/// </summary>
public class SutartisL
{
    [DisplayName("ID")]
	[Required]
	public int ID { get; set; }

    [DisplayName("Sutarties Data")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	[Required]
	public DateTime? GimimoData { get; set; }

	[DisplayName("Busena")]
	[Required]
	public string Busena { get; set; }

	[DisplayName("Aprasymas")]
	[Required]
	public string Aprasymas { get; set; }

    [DisplayName("Pasirasyta")]
	[Required]
	public string Pasirasyta { get; set; }

    [DisplayName("Kaina")]
	[Required]
	public int Kaina { get; set; }

    [DisplayName("AsmensKodas")]
	[Required]
	public int FkAsmensKodas { get; set; }

    [DisplayName("El. Pastas")]
    [EmailAddress]
	[Required]
	public string FkElPastas { get; set; }
    [DisplayName("Keliones ID")]
	[Required]
	public int FkKelionsID { get; set; }
}
