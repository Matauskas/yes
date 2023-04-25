namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Salis'.
/// </summary>
public class AsmuoRepo
{
	public static List<AsmuoL> ListAsmuo()
	{
		var query =
			$@"SELECT * FROM asmuo ORDER BY Vardas ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<AsmuoL>(drc, (dre, t) => {
				t.AsmensKodas = dre.From<string>("Asmens_kodas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Vardas = dre.From<string>("Vardas");
				t.Adresas = dre.From<string>("Adresas");
                t.TelefonoNumeris = dre.From<string>("TelefonoNumeris");
                t.ElPastas = dre.From<string>("El_Pastas");
			});

		return result;
	}
    public static AsmuoL Find(string asmkodas)
	{
		var query = $@"SELECT * FROM asmuo WHERE asmens_kodas=?asmkodas";

		var drc =
			Sql.Query(query, args => {
				args.Add("?asmkodas", asmkodas);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<AsmuoL>(drc, (dre, t) => {
					t.AsmensKodas = dre.From<string>("Asmens_kodas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Vardas = dre.From<string>("Vardas");
				t.Adresas = dre.From<string>("Adresas");
                t.TelefonoNumeris = dre.From<string>("TelefonoNumeris");
                t.ElPastas = dre.From<string>("El_Pastas");
				});

			return result;
		}

		return null;
	}

	public static void Insert(AsmuoL asmuo)
	{
		var query =
			$@"INSERT INTO asmuo
			(
				Asmens_kodas,
				Pavarde,
				Vardas,
				Adresas,
				TelefonoNumeris,
				El_Pastas    
			)
			VALUES(
				?asmkod,
				?vardas,
				?pavarde,
				?gimdata,
				?tel,
				?email
			)";

		Sql.Insert(query, args => {
			args.Add("?asmkod", asmuo.AsmensKodas);
			args.Add("?pavarde", asmuo.Pavarde);
			args.Add("?vardas", asmuo.Vardas);
			args.Add("?gimdata", asmuo.Adresas);
			args.Add("?tel", asmuo.TelefonoNumeris);
			args.Add("?email", asmuo.ElPastas);
		});
	}

	public static void Update(AsmuoL asmuo)
	{
		var query =
			$@"UPDATE asmuo
			SET
				
				Pavarde=?pavarde,
                Vardas=?vardas,
				Adresas=?gimdata,
				TelefonoNumeris=?tel,
				El_Pastas=?email
			WHERE
				Asmens_kodas=?asmkod";

		Sql.Update(query, args => {
			args.Add("?asmkod", asmuo.AsmensKodas);
			args.Add("?pavarde", asmuo.Pavarde);
			args.Add("?vardas", asmuo.Vardas);
			args.Add("?gimdata", asmuo.Adresas);
			args.Add("?tel", asmuo.TelefonoNumeris);
			args.Add("?email", asmuo.ElPastas);
		});
	}

	public static void Delete(string id)
	{
		var query = $@"DELETE FROM asmuo WHERE Asmens_kodas=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
}