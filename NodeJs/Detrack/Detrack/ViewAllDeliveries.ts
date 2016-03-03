var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client;
var client = new Client();

function viewAllDeliveries() {
  var postData = { "date": "2016-03-02"};
  var args = {
    data: postData,
    headers: {
      'X-API-KEY': apiKey,
      'Content-Type': 'application/json',
    }
  };

  client.post("https://app.detrack.com/api/v1/deliveries/view/all.json", args, function (data, response) {
    console.log(data); 
    console.log("Address: " + data["deliveries"][0]["address"]);
  });
}

viewAllDeliveries();