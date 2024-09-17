using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;

namespace CretaceousClient.Controllers;

public class AnimalsController : Controller
{
  public IActionResult Index()
  {
    List<Animal> animals = Animal.GetAnimals();
    return View(animals);
  }

  public IActionResult Details(int id)
  {
    Animal myAnimal = Animal.GetDetails(id);
    return View(myAnimal);
  }

    // GET: animals/create
    [HttpGet] // Display the create form
    public IActionResult Create()
    {
        return View();
    }

    // POST: anmals/create
    [HttpPost] // Handle form submission
    public IActionResult Create(Animal animal)
    {
        Animal.Post(animal);
        return RedirectToAction("Index");
    }

      // GET: /Animals/Edit/{id}
    [HttpGet]  // Display the editing form
    public IActionResult Edit(int id)
    {
        Animal animal = Animal.GetDetails(id);
        return View(animal);
    }

     // POST: /Animals/Edit/{id}
    [HttpPost]  // Handle form submission for edits
    public IActionResult Edit(Animal animal)
    {
        Animal.Put(animal);
        return RedirectToAction("Details", new { id = animal.AnimalId} );
    }

      public ActionResult Delete(int id)
    {
        Animal animal = Animal.GetDetails(id);
        return View(animal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Animal.Delete(id);
        return RedirectToAction("Index");
    }



}

/*
    Notice that we're using a file-scoped namespace for the CretaceousClient.Controllers namespace.
    order to view our list of animals in our MVC client, we still need to do the following:
        1. Create a controller route
        2. Create the corresponding views

    For the Delete Action
    Remember that we name the second action POST DeleteConfirmed() because if we named it POST Delete(), we'd have a conflict caused by two methods having the same signature: name and parameters. That's why it's called DeleteConfirmed(). We add the attribute ActionName("Delete") so that our DeleteConfirmed() POST action can still be found by the name Delete(). This ensures that our form made with HTML helper methods in Animals/Delete.cshtml works as expected.
*/