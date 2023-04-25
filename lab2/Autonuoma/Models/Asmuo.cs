namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Automobilis' in list form.
/// </summary>
public class AsmuoL
{
	[DisplayName("Asmens Kodas")]
	[Required]
	public string AsmensKodas { get; set; }
	
	[DisplayName("Pavarde")]
	[Required]
	public string Pavarde { get; set; }

	[DisplayName("Vardas")]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Adresas")]
	[Required]
	public string Adresas { get; set; }

	[DisplayName("TelefonoNumeris")]
	[Required]
	public string TelefonoNumeris { get; set; }

	[DisplayName("El. Pastas")]
    [EmailAddress]
	[Required]
	public string ElPastas { get; set; }
}
