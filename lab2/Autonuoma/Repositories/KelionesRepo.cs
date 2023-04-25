namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Keliones;


/// <summary>
/// Database operations related to 'Automobilis'.
/// </summary>
public class KelionesRepo
{
	public static List<KelionesL> ListKeliones()
	{
		var query =
			$@"SELECT
				a.id,
				b.Pavadinimas AS salis,
                a.Dienos,
                a.Kaina
			FROM
				kelione a
				LEFT JOIN salis b ON b.Pavadinimas = a.fk_SalisPavadinimas
			ORDER BY a.id ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<KelionesL>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Salis = dre.From<string>("salis");
                t.Dienos = dre.From<short>("Dienos");
				t.Kaina = dre.From<int>("Kaina");
			});

		return result;
	}

	public static KelionesCE FindKelionesCE(int id)
	{
		var query = $@"SELECT * FROM kelione WHERE id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<KelionesCE>(drc, (dre, t) => {
				//make a shortcut
				var auto = t.Keliones;

				//
				auto.Id = dre.From<int>("id");
				auto.Dienos = dre.From<short>("Dienos");
				auto.Pradzia = dre.From<DateTime>("Pradzia");
				auto.Pabaiga = dre.From<DateTime>("Pabaiaga");
				auto.Kaina = dre.From<int>("Kaina");
                auto.fkTipas = dre.From<int>("tipas");
                auto.fkViesbutis = dre.From<string>("fk_ViesbutisPavadinimas");
                auto.fkSalis = dre.From<string>("fk_SalisPavadinimas");
			});

		return result;
	}

	public static void InsertKeliones(KelionesCE autoCE)
	{
		var query =
			$@"INSERT INTO kelione
			(
				id,
                Dienos,
                Pradzia,
                Pabaiaga,
                Kaina,
                tipas,
                fk_ViesbutisPavadinimas,
                fk_SalisPavadinimas
			)
			VALUES (
				?id,
				?die,
				?pra,
				?pab,
				?kai,
                ?tip,
                ?vie,
                ?sal
			)";

		Sql.Insert(query, args => {
			//make a shortcut
			var auto = autoCE.Keliones;

			//
			args.Add("?id", auto.Id);
			args.Add("?die", auto.Dienos);
			args.Add("?pra", auto.Pradzia);
			args.Add("?pab", auto.Pabaiga);
			args.Add("?kai", auto.Kaina);
            args.Add("?tip", auto.fkTipas);
            args.Add("?sal", auto.fkSalis);
            args.Add("?vie", auto.fkViesbutis);
		});
	}

	public static void UpdateKeliones(KelionesCE autoCE)
	{
		var query =
			$@"UPDATE kelione
			SET
				id=?id,
                Dienos=?die,
                Pradzia=?pra,
                Pabaiaga=?pab,
                Kaina=?kai,
                tipas=?tip,
                fk_ViesbutisPavadinimas=?vie,
                fk_SalisPavadinimas=?sal
			WHERE
				id=?id";

		Sql.Update(query, args => {
			//make a shortcut
			var auto = autoCE.Keliones;

			//
			args.Add("?id", auto.Id);
			args.Add("?die", auto.Dienos);
			args.Add("?pra", auto.Pradzia);
			args.Add("?pab", auto.Pabaiga);
			args.Add("?kai", auto.Kaina);
            args.Add("?tip", auto.fkTipas);
            args.Add("?sal", auto.fkSalis);
            args.Add("?vie", auto.fkViesbutis);
		});
	}

	public static void DeleteKeliones(int id)
	{
		var query = $@"DELETE FROM kelione WHERE id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}
    public static List<TipaiClass> ListTipai()
	{
		var query = $@"SELECT * FROM keliones_tipas ORDER BY id_ ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<TipaiClass>(drc, (dre, t) => {
				t.Id = dre.From<int>("id_");
				t.Tipas = dre.From<string>("name");
			});

		return result;
	}
}