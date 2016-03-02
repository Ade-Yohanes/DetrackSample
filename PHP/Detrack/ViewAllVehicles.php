<?php   

	/*Set common properties of request*/
	$headers = array(
		'Content-Type: application/json', 
		'Content-Length: 0', 
		'X-API-KEY: 3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff'
	);

	// 6. View All Vehicles
	$connection = curl_init();
	curl_setopt($connection, CURLOPT_URL, "https://app.detrack.com/api/v1/vehicles/view/all.json");
	curl_setopt ($connection, CURLOPT_POST, 1);
	curl_setopt($connection, CURLOPT_RETURNTRANSFER, 1);
	curl_setopt($connection, CURLOPT_SSL_VERIFYHOST, 0);
	curl_setopt($connection, CURLOPT_SSL_VERIFYPEER, 0);
	curl_setopt($connection, CURLOPT_HTTPHEADER, $headers);
	$response = curl_exec($connection);

    if ($response === false) {
        die('Error fetching data: ' . curl_error($connection));  
    }
	
    curl_close ($response);  
	
	$json = json_decode($response, true);
	print_r($json); //Get Resposne as JSON Array
	echo 'Vehicle Name: ';
	echo $json['vehicles'][0]['name']; //Access Individual property within Response. Response comes as array so use index / iterate thorugh array

?> 