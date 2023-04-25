namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Automobilis' in list form.
/// </summary>
public class Zemynas
{
	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }
	
	[DisplayName("Klimato Zona")]
	[Required]
	public string KlimatoZona { get; set; }

	[DisplayName("Plotas")]
	[Required]
	public string Plotas { get; set; }

	[DisplayName("Gyvenotoju Skaicius")]
	[Required]
	public string GyventojuSK { get; set; }

	[DisplayName("Kalnuoota")]
	[Required]
	public byte Kalnuota { get; set; }

}