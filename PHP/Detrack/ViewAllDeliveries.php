<?php   
	//Execute from command prompt as 'php ViewAllDeliveries.php'
	//Initialize the data that will be send to View All Deliveries request
	$data = array("date" => "2014-02-13");  //Specify the date for which delivery data is requested                                                                  
	$data_string = json_encode($data);   
	
	/*Set common properties of request*/
	$headers = array(
		'Content-Type: application/json', 
		'Accept: application/json', 
		'Content-length:'.strlen($data_string),
		'X-API-KEY: 3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff'
	);

	

	// 4. View All Deliveries
	//Initialize the cURL handler with common properties
	$connection = curl_init();
	curl_setopt($connection, CURLOPT_URL, "https://app.detrack.com/api/v1/deliveries/view/all.json");
	curl_setopt ($connection, CURLOPT_POST, true); //Mark request as POST
	curl_setopt($connection, CURLOPT_CUSTOMREQUEST, "POST");  
	curl_setopt($connection,CURLOPT_POSTFIELDS, $data_string); //Set the POST data
	curl_setopt($connection, CURLOPT_RETURNTRANSFER, 1);
	curl_setopt($connection, CURLINFO_HEADER_OUT, 1); // enable tracking
	curl_setopt($connection, CURLOPT_SSL_VERIFYHOST, 0);
	curl_setopt($connection, CURLOPT_SSL_VERIFYPEER, 0);
	curl_setopt($connection, CURLOPT_HTTPHEADER, $headers);
	$response = curl_exec($connection);

    if ($response === false) {
        die('Error fetching data: ' . curl_error($connection));  
    }
	
    curl_close ($response);  
	
	//$headerSent = curl_getinfo($connection, CURLINFO_HEADER_OUT ); // request headers
	//print_r($headerSent);
	
	$json = json_decode($response, true);
	print_r($json); //Get Resposne as JSON Array
	//echo 'Vehicle Name: ';
	//echo $json['vehicles'][0]['name']; //Access Individual property within Response. Response comes as array so use index / iterate thorugh array

?> 