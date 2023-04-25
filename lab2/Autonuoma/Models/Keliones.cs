namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Keliones;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Automobilis' in list form.
/// </summary>
public class KelionesL
{
	[DisplayName("ID")]
	[Required]
	public int Id { get; set; }
	
	[DisplayName("Salis")]
	[Required]
	public string Salis { get; set; }
	[DisplayName("Dienos")]
	[Required]
	public short Dienos { get; set; }

	[DisplayName("Kaina")]
	[Required]
	public int Kaina { get; set; }

}
public class KelionesCE
{
    public class KelionesM
    {
    [DisplayName("ID")]
	[Required]
	public int Id { get; set; }

	[DisplayName("Dienos")]
	[Required]
	public short Dienos { get; set; }
	
	[DisplayName("Pradzia")]
	[Required]
	public DateTime Pradzia { get; set; }
	[DisplayName("Pabaiga")]
	[Required]
	public DateTime Pabaiga { get; set; }

	[DisplayName("Kaina")]
	[Required]
	public int Kaina { get; set; }
	[DisplayName("Tipas")]
	[Required]
	public int fkTipas { get; set; }
	[DisplayName("Viesbutis")]
	[Required]
	public string fkViesbutis { get; set; }

	[DisplayName("Salis")]
	[Required]
	public string fkSalis { get; set; }
    }
    public class ListsM
	{
		public IList<SelectListItem> Salys { get; set; }
        public IList<SelectListItem> Viesbuciai { get; set; }
        public IList<SelectListItem> Tipai { get; set; }
	}


	/// <summary>
	/// Automobilis.
	/// </summary>
	public KelionesM Keliones { get ; set; } = new KelionesM();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}

public class TipaiClass
{
    public int Id { get; set; }

	public string Tipas { get; set; }
}