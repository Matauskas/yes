namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Salis;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Automobilis' in list form.
/// </summary>
public class SalisL
{
	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }
	
	[DisplayName("Miestas")]
	[Required]
	public string Miestas { get; set; }

	[DisplayName("Zemynas")]
	[Required]
	public string Zemynas { get; set; }

}
public class SalisCE
{
    public class SalisM
    {
	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }
	
	[DisplayName("Miestas")]
	[Required]
	public string Miestas { get; set; }
	[DisplayName("Sostine")]
	[Required]
	public byte Sostine { get; set; }

	[DisplayName("Kalba")]
	[Required]
	public string Kalba { get; set; }
	[DisplayName("Valiuta")]
	[Required]
	public string Valiuta { get; set; }
	[DisplayName("Jura")]
	[Required]
	public byte Jura { get; set; }

	[DisplayName("Zemynas")]
	[Required]
	public string fkZemynas { get; set; }
    }
    public class ListsM
	{
		public IList<SelectListItem> Zemynai { get; set; }

	}


	/// <summary>
	/// Automobilis.
	/// </summary>
	public SalisM Salis { get ; set; } = new SalisM();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}