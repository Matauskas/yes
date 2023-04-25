namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Keliones;


/// <summary>
/// Controller for working with 'Automobilis' entity.
/// </summary>
public class KelionesController : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(KelionesRepo.ListKeliones());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var autoCE = new KelionesCE();
		PopulateSelections(autoCE);

		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="autoCE">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(KelionesCE autoCE)
	{
		//form field validation passed?
		if( ModelState.IsValid )
		{
			KelionesRepo.InsertKeliones(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}
		
		//form field validation failed, go back to the form
		PopulateSelections(autoCE);
		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var autoCE = KelionesRepo.FindKelionesCE(id);
		PopulateSelections(autoCE);

		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>		
	/// <param name="autoCE">Entity model filled with latest data.</param>
	/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, KelionesCE autoCE)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			KelionesRepo.UpdateKeliones(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		//form field validation failed, go back to the form
		PopulateSelections(autoCE);
		return View(autoCE);
	}

	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var autoEvm = KelionesRepo.FindKelionesCE(id);
		return View(autoEvm);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			KelionesRepo.DeleteKeliones(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var autoCE = KelionesRepo.FindKelionesCE(id);
			PopulateSelections(autoCE);

			return View("Delete", autoCE);
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="autoCE">'Automobilis' view model to append to.</param>
	public void PopulateSelections(KelionesCE autoCE)
	{
		//load entities for the select lists
		var viesbuciai = ViesbutisRepo.ListViesbutis();
        var salys = SalisRepo.ListSalis();

		//build select lists
		autoCE.Lists.Viesbuciai = 
			viesbuciai.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Pavadinimas),
							Text = it.Pavadinimas
						};
				})
				.ToList();
        autoCE.Lists.Salys = 
			salys.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Pavadinimas),
							Text = it.Pavadinimas
						};
				})
				.ToList();
        var tipai = KelionesRepo.ListTipai();

		//build select lists
		autoCE.Lists.Tipai = 
			tipai.Select(it => {
				return
					new SelectListItem() { 
						Value = Convert.ToString(it.Id), 
						Text = it.Tipas
					};
			})
			.ToList();


		
	}
}