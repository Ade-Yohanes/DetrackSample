var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client;
var client = new Client();
function viewAllVehicles() {
  var postData = {};
  // set content-type header and data as json in args parameter 
  var args = {
    data: postData,
    headers: {
      'X-API-KEY': apiKey,
      'Content-Type': 'application/json'
    }
  };

  client.post("https://app.detrack.com/api/v1/vehicles/view/all.json", args, function (data, response) {
    console.log(data); 
    console.log("vehicle name: " + data["vehicles"][0]["name"]);
  });
}

viewAllVehicles();