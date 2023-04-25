namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Viesbutis;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Automobilis' in list form.
/// </summary>
/// 

public class ViesbutisL
    {
	[DisplayName("Pavadinimas")]
	public string Pavadinimas { get; set; }

	[DisplayName("Adresas")]
	public string Adresas { get; set; }

	[DisplayName("Kaina uz nakti")]
	public int KainaUzNakti { get; set; }

	[DisplayName("Pusryciai")]
	public  string  Pusryciai { get; set; }
    }
public class ViesbutisCE
{
    public class ViesbutisM
    {
	[DisplayName("Pavadinimas")]
	public string Pavadinimas { get; set; }

	[DisplayName("Adresas")]
	public string Adresas { get; set; }

	[DisplayName("Kaina uz nakti")]
	public int KainaUzNakti { get; set; }

	[DisplayName("Pusryciai")]
	public  string  Pusryciai { get; set; }

	[DisplayName("Ivertinimas")]
	public int Ivertinimas { get; set; }
    }
    public class ListsM
	{
		public IList<SelectListItem> Ivertinimas { get; set; }

	}


	/// <summary>
	/// Automobilis.
	/// </summary>
	public ViesbutisM Viesbutis { get ; set; } = new ViesbutisM();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}


public class Ivertinimai
{
    public int Id { get; set; }

	public string Zvaigzdutes { get; set; }
}