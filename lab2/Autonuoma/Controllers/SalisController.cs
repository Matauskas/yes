namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Salis;


/// <summary>
/// Controller for working with 'Automobilis' entity.
/// </summary>
public class SalisController : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(SalisRepo.ListSalis());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var autoCE = new SalisCE();
		PopulateSelections(autoCE);

		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="autoCE">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(SalisCE autoCE)
	{
		//form field validation passed?
		if( ModelState.IsValid )
		{
			SalisRepo.InsertSalis(autoCE);

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
	public ActionResult Edit(string id)
	{
		var autoCE = SalisRepo.FindSalisCE(id);
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
	public ActionResult Edit(string id, SalisCE autoCE)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			SalisRepo.UpdateSalis(autoCE);

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
	public ActionResult Delete(string id)
	{
		var autoEvm = SalisRepo.FindSalisCE(id);
		return View(autoEvm);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(string id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			SalisRepo.DeleteSalis(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var autoCE = SalisRepo.FindSalisCE(id);
			PopulateSelections(autoCE);

			return View("Delete", autoCE);
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="autoCE">'Automobilis' view model to append to.</param>
	public void PopulateSelections(SalisCE autoCE)
	{
		//load entities for the select lists
		var zemynai = ZemynasRepo.List();

		//build select lists
		autoCE.Lists.Zemynai = 
			zemynai.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Pavadinimas),
							Text = it.Pavadinimas
						};
				})
				.ToList();


		
	}
}