using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

     public static Animal GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

     public static void Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      ApiHelper.Post(jsonAnimal);
    }

     public static void Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }

    public static void Delete(int id)
    {
        ApiHelper.Delete(id);
    }
  }
}



/*
    Let's take a closer look at the Animal.GetAnimals() method. This method handles calling a method that queries our API for all Animal objects and deserializing the API's response.

Within this method we call on the ApiHelper.GetAll() method; we have yet to create that class and method. However, one thing to note now is that we'll need a different Animal class and ApiHelper class method for each type of API call (GET, POST, PUT, DELETE) we want to make, because each returns a different format of data.

Notice that we don't pass an API key as an argument to ApiHelper.GetAll();. Your personal API will not require a key unless you add Token-Based Authentication through your further exploration.

Next, take note that the jsonResponse variable is of the type JArray as opposed to JObject. Since we're getting a collection of results, we need to expect an array of objects. Remember that these types are from the Newtonsoft.Json library.
Next, let's actually create the ApiHelper class. This class will contain the definition for our ApiHelper.GetAll() method which actually handles making a call to our Cretaceous Park API.


    Why can't we just use one method for both the get all and get details functionality? Couldn't we just add an id to the URL string? The redundant code that we are creating doesn't look very DRY.

Well, even though the core functionality of our methods is the same, they return different types of data and must be separated.

Here, we can see three key differences between our GetDetails() and GetAnimals() methods:

We need to call on the ApiHelper.Get() method, instead of the ApiHelper.GetAll() method.

The GetDetails() method returns a singular animal.

The GetDetails() method takes in the id of the animal.

The API call within GetDetails() results in a JSON object as opposed to a JSON array.

Because of all of these reasons, we still need to create a new method for getting a single animal's details even though the code looks nearly identical to getting all animals from the database.


*/


