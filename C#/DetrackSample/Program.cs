using DetrackSample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DetrackSample
{
  /// <summary>
  /// Sample program to make Detrack api calls
  /// </summary>
  public class Program
  {
    #region Public Properties
    /// <summary>
    /// Assign your api key - this should be defined either in App.Config/Web.Config/Db
    /// which is accessible in all locations of your app.
    /// </summary>
    public static string ApiKey = "3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff";
    #endregion

    #region MainProgram
    public static void Main(string[] args)
    {
      MakeAPICall().Wait();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Make desired API Calls
    /// </summary>
    /// <returns></returns>
    private static async Task MakeAPICall()
    {
      //1. Add Deliveries
      await AddDeliveries();

      //2. Edit Deliveries
      await EditDeliveries();

      //4. View All Deliveries
      await ViewAllDeliveries();

      //5. download delivery pod signature image file
      await DownloadDeliveryPodSignature();

      //6. View All Deliveries
      await ViewAllVehicles();

      //3. Delete Deliveries
      await DeleteDeliveries();

    }
    #endregion

    #region API Calls
    /// <summary>
    /// Get HttpClient with common properties set
    /// </summary>
    /// <returns></returns>
    private static HttpClient GetHttpClient()
    {
      var client = new HttpClient
      {
        BaseAddress = new Uri("https://app.detrack.com/api/v1/")

      };

      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Add("X-API-KEY", ApiKey); //Set Custom Header for defining API key.
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      return client;
    }

    /// <summary>
    /// Add Deliveries
    /// </summary>
    /// <returns></returns>
    private static async Task AddDeliveries()
    {
      using (var client = GetHttpClient())
      {
        var obj = GetSampleDeliveryItem();
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("deliveries/create.json", obj);
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }

    /// <summary>
    /// Edit Deliveries - Specify the list of deliveries that you want to update
    /// </summary>
    /// <returns></returns>
    private static async Task EditDeliveries()
    {
      using (var client = GetHttpClient())
      {
        var obj = GetSampleDeliveryItem();
        obj[0].delivery_time = "12:00 PM - 03:00 PM";
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("deliveries/update.json", obj);
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }

    /// <summary>
    /// Delete Deliveries - Specify the list of deliveries that you want to delete
    /// </summary>
    /// <returns></returns>
    private static async Task DeleteDeliveries()
    {
      using (var client = GetHttpClient())
      {
        var obj = GetSampleDeleteDeliveryItem();
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("deliveries/delete.json", obj);
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }

    /// <summary>
    /// View All deliveries for given date
    /// </summary>
    /// <returns></returns>
    private static async Task ViewAllDeliveries()
    {
      using (var client = GetHttpClient())
      {
        var obj = new ViewAllDeliveries { date = "2014-02-13" };
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("deliveries/view/all.json", obj);
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }

    /// <summary>
    /// If a POD signature image file is available for the delivery, the file will be returned for binary transfer. 
    /// If no POD image file is available, then a HTTP 404 error will be returned.
    /// </summary>
    /// <returns></returns>
    private static async Task DownloadDeliveryPodSignature()
    {
      using (var client = GetHttpClient())
      {
        var obj = new DownloadDeliveryPodSignatureSearchCriteria { date = "2014-02-13", Do = "DO140213001" };
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("deliveries/signature.json", obj);
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
          else
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }

    /// <summary>
    /// View All Vehicles
    /// </summary>
    /// <returns></returns>
    private static async Task ViewAllVehicles()
    {
      using (var client = GetHttpClient())
      {
        try
        {
          var response = await client.PostAsJsonWithNoCharSetAsync("vehicles/view/all.json", new object());
          if (response.IsSuccessStatusCode)
          {
            Console.WriteLine("Response: {0}", response.Content.ReadAsStringAsync().Result);
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
    #endregion

    #region Sample Objects
    /// <summary>
    /// Prepare the list of deliveries that you want to create
    /// </summary>
    /// <returns></returns>
    private static List<DeliveryItem> GetSampleDeliveryItem()
    {
      return new List<DeliveryItem>
      {
        new DeliveryItem
        {
          date = "2016-03-01",
          Do = "DO140211001",
          delivery_time = "09:00 AM - 12:00 PM",
          deliver_to = "John Tan",
          phone = "+6591234567",
          notify_email = "john.tan@example.com",
          notify_url = "http://www.example.com/notify.php",
          assign_to = "1111",
          instructions = "Call customer upon arrival.",
          zone = "East",
          address = "63 Ubi Avenue 1 Singapore 408937"
        },
      };
    }

    /// <summary>
    /// Prepare the list of deliveries that you want to delete
    /// </summary>
    /// <returns></returns>
    private static List<DeleteDeliveryRequest> GetSampleDeleteDeliveryItem()
    {
      return new List<DeleteDeliveryRequest>
      {
        new DeleteDeliveryRequest
        {
          date = "2016-03-01",
          Do = "DO140211001",
        },
      };
    }
    #endregion
  }
}
