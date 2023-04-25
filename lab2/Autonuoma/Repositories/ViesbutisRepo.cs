namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Viesbutis;


/// <summary>
/// Database operations related to 'Automobilis'.
/// </summary>
public class ViesbutisRepo
{
	public static List<ViesbutisL> ListViesbutis()
	{
		var query =
			$@"SELECT
				a.Pavadinimas,
				a.Adresas,
                a.Kaina_uz_nakti,
                a.Pusryciai
			FROM
				viesbutis a
			ORDER BY a.Pavadinimas ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<ViesbutisL>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("Pavadinimas");
				t.Adresas = dre.From<string>("Adresas");
				t.KainaUzNakti = dre.From<int>("Kaina_uz_nakti");
				t.Pusryciai = dre.From<string>("Pusryciai");
			});

		return result;
	}

	public static ViesbutisCE FindViesbutisCE(string id)
	{
		var query = $@"SELECT * FROM viesbutis WHERE Pavadinimas=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<ViesbutisCE>(drc, (dre, t) => {
				//make a shortcut
				var auto = t.Viesbutis;

				//
				auto.Pavadinimas = dre.From<string>("Pavadinimas");
				auto.Adresas = dre.From<string>("Adresas");
				auto.KainaUzNakti = dre.From<int>("Kaina_uz_nakti");
				auto.Pusryciai = dre.From<string>("Pusryciai");
				auto.Ivertinimas = dre.From<int>("Ivertinimas");
			});

		return result;
	}

	public static void InsertViesbutis(ViesbutisCE autoCE)
	{
		var query =
			$@"INSERT INTO viesbutis
			(
				Pavadinimas,
                Adresas,
                Kaina_uz_nakti,
                Pusryciai,
                Ivertinimas
			)
			VALUES (
				?pav,
				?adr,
				?kaina,
				?pus,
				?ivert
			)";

		Sql.Insert(query, args => {
			//make a shortcut
			var auto = autoCE.Viesbutis;

			//
			args.Add("?pav", auto.Pavadinimas);
			args.Add("?adr", auto.Adresas);
			args.Add("?kaina", auto.KainaUzNakti);
			args.Add("?pus", auto.Pusryciai);
			args.Add("?ivert", auto.Ivertinimas);
		});
	}

	public static void UpdateViesbutis(ViesbutisCE autoCE)
	{
		var query =
			$@"UPDATE viesbutis
			SET
				Pavadinimas=?pav,
                Adresas=?adr,
                Kaina_uz_nakti=?kaina,
                Pusryciai=?pus,
                Ivertinimas=?ivert
			WHERE
				Pavadinimas=?id";

		Sql.Update(query, args => {
			//make a shortcut
			var auto = autoCE.Viesbutis;

			//
			args.Add("?pav", auto.Pavadinimas);
			args.Add("?adr", auto.Adresas);
			args.Add("?kaina", auto.KainaUzNakti);
			args.Add("?pus", auto.Pusryciai);
			args.Add("?ivert", auto.Ivertinimas);

			args.Add("?id", auto.Pavadinimas);
		});
	}

	public static void DeleteViesbutis(string id)
	{
		var query = $@"DELETE FROM viesbutis WHERE Pavadinimas=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
    public static List<Ivertinimai> ListIvertinimai()
	{
		var query = $@"SELECT * FROM viesbutis_ivertinimas ORDER BY id_ ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Ivertinimai>(drc, (dre, t) => {
				t.Id = dre.From<int>("id_");
				t.Zvaigzdutes = dre.From<string>("name");
			});

		return result;
	}
}