var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client;
var fs = require('fs');
var client = new Client();

function downloadSignatureFile() {
  var postData = {
      "date": "2016-03-02",
      "do": "DO140211001",
    }
  ;
  var file = fs.createWriteStream("signature.jpeg");
  var args = {
    data: postData,
    headers: {
      'X-API-KEY': apiKey,
      'Content-Type': 'application/json',
    }
  };


  client.post("https://app.detrack.com/api/v1/deliveries/signature.json", args, function (data, response) {
    file.write(data);
    file.close();
  });
}

downloadSignatureFile();