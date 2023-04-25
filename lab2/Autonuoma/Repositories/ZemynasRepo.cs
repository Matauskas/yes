namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class ZemynasRepo
{
	public static List<Zemynas> List()
	{
		var query = $@"SELECT * FROM zemynas ORDER BY Pavadinimas ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Zemynas>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.KlimatoZona = dre.From<string>("Klimato_zona");
				t.Plotas = dre.From<string>("Plotas");
				t.GyventojuSK = dre.From<string>("Gyventojuskaicius");
                t.Kalnuota = dre.From<byte>("Kalnuota");
			});

		return result;
	}
}
