namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Salis;


/// <summary>
/// Database operations related to 'Salis'.
/// </summary>
public class SalisRepo
{
	public static List<SalisL> ListSalis()
	{
		var query =
			$@"SELECT
				a.Pavadinimas,
				a.Miestas,
				b.Pavadinimas AS zemynas
			FROM
				salis a
				LEFT JOIN zemynas b ON b.Pavadinimas = a.fk_ZemynasPavadinimas
			ORDER BY a.Pavadinimas ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<SalisL>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Miestas = dre.From<string>("Miestas");
				t.Zemynas = dre.From<string>("zemynas");
			});

		return result;
	}
	public static SalisCE FindSalisCE(string id)
	{
		var query = $@"SELECT * FROM salis WHERE Pavadinimas=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<SalisCE>(drc, (dre, t) => {
				//make a shortcut
				var auto = t.Salis;

				//
				auto.Pavadinimas = dre.From<string>("Pavadinimas");
				auto.Miestas = dre.From<string>("Miestas");
				auto.Sostine = dre.From<byte>("Sostine");
				auto.Kalba = dre.From<string>("Kalba");
				auto.Valiuta = dre.From<string>("Valiuta");
				auto.Jura = dre.From<byte>("Jura");
				auto.fkZemynas = dre.From<string>("fk_ZemynasPavadinimas");
			});

		return result;
	}

	public static void InsertSalis(SalisCE autoCE)
	{
		var query =
			$@"INSERT INTO salis
			(
				Pavadinimas,
                Miestas,
                Sostine,
                Kalba,
                Valiuta,
				Jura,
				fk_ZemynasPavadinimas
			)
			VALUES (
				?pav,
				?me,
				?sos,
				?kal,
				?val,
				?jur,
				?zem
			)";

		Sql.Insert(query, args => {
			//make a shortcut
			var auto = autoCE.Salis;

			//
			args.Add("?pav", auto.Pavadinimas);
			args.Add("?me", auto.Miestas);
			args.Add("?sos", auto.Sostine);
			args.Add("?kal", auto.Kalba);
			args.Add("?val", auto.Valiuta);
			args.Add("?jur", auto.Jura);
			args.Add("?zem", auto.fkZemynas);
		});
	}

	public static void UpdateSalis(SalisCE autoCE)
	{
		var query =
			$@"UPDATE salis
			SET
				
                Miestas=?me,
                Sostine=?sos,
                Kalba=?kal,
                Valiuta=?val,
				Jura=?jur,
				fk_ZemynasPavadinimas=?zem
			WHERE
				Pavadinimas=?id";

		Sql.Update(query, args => {
			//make a shortcut
			var auto = autoCE.Salis;

			//
			args.Add("?pav", auto.Pavadinimas);
			args.Add("?me", auto.Miestas);
			args.Add("?sos", auto.Sostine);
			args.Add("?kal", auto.Kalba);
			args.Add("?val", auto.Valiuta);
			args.Add("?jur", auto.Jura);
			args.Add("?zem", auto.fkZemynas);

			args.Add("?id", auto.Pavadinimas);
		});
	}

	public static void DeleteSalis(string id)
	{
		var query = $@"DELETE FROM salis WHERE Pavadinimas=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
}
	