var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client; // Get the rest client that will be used to send the request
var client = new Client();

function addDeliveries() {
  // Prepare the rest data that will be used in the post request.
  var postData = [
    {
      "date": new Date().toISOString().split('T')[0],
      "do" : "DO140211001",
      "address" : "63 Ubi Avenue 1 Singapore 408937",
      "delivery_time" : "09 : 00 AM - 12 : 00 PM",
      "deliver_to" : "John Tan",
      "phone" : "+6591234567",
      "notify_email" : "john.tan@example.com",
      "notify_url" : "http : //www.example.com/notify.php",
      "assign_to" : "1111",
      "instructions" : "Call customer upon arrival.",
      "zone" : "East",
      "items" : [
      {
        "sku": "T0201",
        "desc": "Test Item #01",
        "qty": 1
      },
      {
        "sku": "T0202",
        "desc": "Test Item #02",
        "qty": 5
      },
        {
          "sku": "T0203",
          "desc": "Test Item #03",
          "qty": 10
        }
      ]
    }
];
  var args = {
    data: postData,
    headers: {
      'X-API-KEY': apiKey, // API of your account to access the API
      'Content-Type': 'application/json',//How the Data will be returned from API. In case of Detrack API it will be JSON format
    }
  };

  client.post("https://app.detrack.com/api/v1/deliveries/create.json", args, function (data, response) {
    console.log(data);
    console.log("Do: " + data["results"][0]["do"]); //Return data is in JSON array format. Access the individual Elements with index or iterate over it to access the individual property
  });
}

addDeliveries(); //Type script entry point. - Run from command prompt: node AddDelivery.ts