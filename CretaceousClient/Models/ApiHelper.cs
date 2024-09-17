using System.Threading.Tasks;
using RestSharp;

namespace CretaceousClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

   public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      await client.PostAsync(request);
    }

        public static async void Put(int id, string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      await client.PutAsync(request);
    }

     public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }


  }

}


/*
    Your API call should include the port that CretaceousApi is set to listen to. For the purposes of this project, we assume it listens on port 5000 using HTTP, as it does in the example repo. If you choose to deploy an API at some point, you'll need to update the URL to include the domain of the deployed site instead of localhost. The endpoint itself for this particular call will be api/animals. Also note that when you are done developing, you should revert back to using HTTPS with your API, and make a corresponding update to the domain in your MVC client requests.

Notice that we're not using the ExecuteAsync() RestSharp method as we did in the New York Times API call example project. Now we're using GetAsync(). There's actually a variety of methods we can use to make an API call with RestSharp. The advantage of using GetAsync() is that it will throw an error if the server returns an error to us. This is vital if we want to create a robust frontend application. We'll use similar methods for other requests:
    PostAsync()
    PutAsync()
    DeleteAsync()
    Take note that we won't be including additional error handling or model validation as we put together a basic MVC frontend to communicate with our Cretaceous Park API. If you want to learn more about error handling with RestSharp, visit the docs.

    For the Post method under ApiHelper:
        The arguments passed into the RestRequest() method specify the route and method that should be passed into the API controller.

        When making a POST request to our API (or any request that will be modifying our database), we need to add a header and a body. This way, our API can recognize the data types it receives and pass in the right argument for the controller route parameter(s).

        We're also using the PostAsync() method, which will throw on a server error, just like the GetAsync() method we used in the last two lessons. To learn about the details of how error handling with RestSharp works, visit the docs.

    Our PUT functionality is very similar to our POST functionality. The key difference is that we need to include an id for our PUT functionality. Unlike with a POST request, where we are simply adding a record to the database, we are actually modifying an existing record — and we need that record's id to correctly modify it.



*/