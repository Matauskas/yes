namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Salis'.
/// </summary>
public class DarbuotojasRepo
{
	public static List<DarbuotojasL> ListDarbuotojas()
	{
		var query =
			$@"SELECT * FROM darbuotojas ORDER BY El_Pastas ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<DarbuotojasL>(drc, (dre, t) => {
				t.ElPastas = dre.From<string>("El_Pastas");
				t.Vardas = dre.From<string>("Vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.GimimoData = dre.From<DateTime>("GimimoData");
                t.TelefonoNumeris = dre.From<string>("Telefono_Numeris");
                t.Adresas = dre.From<string>("Adresas");
				t.BiuroAdresas = dre.From<string>("fk_Agenturos_biurasAdresas");
			});

		return result;
	}
	public static DarbuotojasL Find(string tabnr)
	{
		var query = $@"SELECT * FROM darbuotojaS WHERE El_Pastas=?tab";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?tab", tabnr);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<DarbuotojasL>(drc, (dre, t) => {
					t.ElPastas = dre.From<string>("El_Pastas");
				t.Vardas = dre.From<string>("Vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.GimimoData = dre.From<DateTime>("GimimoData");
                t.TelefonoNumeris = dre.From<string>("Telefono_Numeris");
                t.Adresas = dre.From<string>("Adresas");
				t.BiuroAdresas = dre.From<string>("fk_Agenturos_biurasAdresas");
				});
			
			return result;
		}

		return null;
	}

	public static void Update(DarbuotojasL darb)
	{						
		var query = 
			$@"UPDATE darbuotojas
			SET 
				Vardas=?vardas,
				Pavarde=?pavarde,
				GimimoData=?gimimoData
				Telefono_Numeris=?telefonoNumeris
				Adresas=?adresas
				fk_Agenturos_biurasAdresas=?fkAdresas
			WHERE 
				tabelio_nr=?tab";

		Sql.Update(query, args => {
			args.Add("?el_pastas", darb.ElPastas);
			args.Add("?vardas", darb.Vardas);
			args.Add("?pavarde", darb.Pavarde);
			args.Add("?gimimoData", darb.GimimoData);
			args.Add("?telefonoNumeris", darb.TelefonoNumeris);
			args.Add("?adresas", darb.Adresas);
			args.Add("?fkAdresas", "Herman Cliff");
		});				
	}

	public static void Insert(DarbuotojasL darb)
	{							
		var query = 
			$@"INSERT INTO darbuotojas
			(
				El_Pastas,
				Vardas,
				Pavarde,
				GimimoData,
				Telefono_Numeris,
				Adresas,
				fk_Agenturos_biurasAdresas
			)
			VALUES(
				?el_pastas,
				?vardas,
				?pavarde,
				?gimimoData,
				?telefonoNumeris,
				?adresas
				?fkAdresas
			)";

		Sql.Insert(query, args => {
			args.Add("?el_pastas", darb.ElPastas);
			args.Add("?vardas", darb.Vardas);
			args.Add("?pavarde", darb.Pavarde);
			args.Add("?gimimoData", darb.GimimoData);
			args.Add("?telefonoNumeris", darb.TelefonoNumeris);
			args.Add("?adresas", darb.Adresas);
			args.Add("?fkAdresas", "Herman Cliff");
		});				
	}

	public static void Delete(string id)
	{			
		var query = $@"DELETE FROM darbutuojas WHERE El_Pastas=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});			
	}
}