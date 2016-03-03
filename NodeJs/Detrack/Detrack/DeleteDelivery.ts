var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client; // Get the rest client that will be used to send the request
var client = new Client();

function deleteDeliveries() {
// Prepare the rest data that will be used in the post request.
  var postData = [
    {
      "date": new Date().toISOString().split('T')[0], //Date of the delivery job
      "do": "DO140211001", //unique job number for the date specified
    }
  ];
  var args = {
    data: postData,
    headers: {
      'X-API-KEY': apiKey,
      'Content-Type': 'application/json',
    }
  };

  //Initiate the post request
  client.post("https://app.detrack.com/api/v1/deliveries/delete.json", args, function (data, response) {
    console.log(data); 
    //console.log("Address: " + data["deliveries"][0]["address"]);
  });
}

deleteDeliveries();//Type script entry point. - Run from command prompt: node DeleteDelivery.ts