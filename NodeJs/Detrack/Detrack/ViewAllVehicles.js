var apiKey = '3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff';
var Client = require('node-rest-client').Client; // Get the rest client that will be used to send the request
var client = new Client();
function viewAllVehicles() {
    var postData = {}; // Prepare the rest data that will be used in the post request. In case of ViewAllVehicles, it will be empty body
    // set content-type header and data as json in args parameter 
    var args = {
        data: postData,
        headers: {
            'X-API-KEY': apiKey,
            'Content-Type': 'application/json' //How the Data will be returned from API. In case of Detrack API it will be JSON format
        }
    };
    client.post("https://app.detrack.com/api/v1/vehicles/view/all.json", args, function (data, response) {
        console.log(data);
        console.log("vehicle name: " + data["vehicles"][0]["name"]); //Return data is in JSON array format. Access the individual Elements with index or iterate over it to access the individual property
    });
}
viewAllVehicles(); // Type script entry point. - Run from command prompt: node ViewAllVehicles.ts
//# sourceMappingURL=ViewAllVehicles.js.map