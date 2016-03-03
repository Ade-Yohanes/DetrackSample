var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client; // Get the rest client that will be used to send the request
var fs = require('fs'); //get node js library to write/read to file 
var client = new Client();
function downloadSignatureFile() {
    var postData = {
        "date": "2016-03-02",
        "do": "DO140211001",
    };
    var file = fs.createWriteStream("signature.jpeg"); //Provide local file system path where file will be downloaded
    var args = {
        data: postData,
        headers: {
            'X-API-KEY': apiKey,
            'Content-Type': 'application/json',
        }
    };
    //Initiate file download
    client.post("https://app.detrack.com/api/v1/deliveries/signature.json", args, function (data, response) {
        file.write(data); //Write binary response data to file system.
        file.close(); //Close the file stream
    });
}
downloadSignatureFile(); //Type script entry point. - Run from command prompt: node DownloadDeliveryPodSignatureFile.ts
//# sourceMappingURL=DownloadDeliveryPodSignatureFile.js.map