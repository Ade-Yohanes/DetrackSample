var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client;
var client = new Client();

function editDeliveries() {
  var postData = [
    {
      "date": new Date().toISOString().split('T')[0],
      "do": "DO140211001",
      "address": "63 Ubi Avenue 1 Singapore 408937",
      "delivery_time": "12 : 00 PM - 03 : 00 PM",
      "deliver_to": "John Tan",
      "phone": "+6591234567",
      "notify_email": "john.tan@example.com",
      "notify_url": "http : //www.example.com/notify.php",
      "assign_to": "1111",
      "instructions": "Call customer upon arrival.",
      "zone": "East",
      "items": [
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
      'X-API-KEY': apiKey,
      'Content-Type': 'application/json',
    }
  };

  client.post("https://app.detrack.com/api/v1/deliveries/update.json", args, function (data, response) {
    console.log(data);
    //console.log("Address: " + data["deliveries"][0]["address"]);
  });
}

editDeliveries();