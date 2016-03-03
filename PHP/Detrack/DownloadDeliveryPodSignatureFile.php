<?php   
    //Execute from command prompt as 'php DownloadDeliveryPodSignatureFile.php'
	/* Define post data for which signature is to be downloaded. i.e date and Do */
	$data = array(
      "date"=>date('Y-m-d'),
      "do"=>"DO140211001",
   );
   
	$data_string = json_encode($data);   
	//print_r($data_string);
	/*Set common properties of request*/
	$headers = array(
		'Content-Type: application/json', 
		'Content-length:'.strlen($data_string),
		'X-API-KEY: 3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff'
	);

	// 5. Download signature file
    //Initialize the cURL handler with common properties`
	$connection = curl_init();
	curl_setopt($connection, CURLOPT_URL, "https://app.detrack.com/api/v1/deliveries/signature.json");
	curl_setopt ($connection, CURLOPT_POST, true); //Mark requests as POST
	curl_setopt($connection, CURLOPT_CUSTOMREQUEST, "POST");  
	curl_setopt($connection,CURLOPT_POSTFIELDS, $data_string);//Set the POST body
	curl_setopt($connection, CURLOPT_RETURNTRANSFER, 1);
	//curl_setopt($connection, CURLINFO_HEADER_OUT, 1); // enable tracking
	curl_setopt($connection, CURLOPT_SSL_VERIFYHOST, 0);
	curl_setopt($connection, CURLOPT_SSL_VERIFYPEER, 0);
	curl_setopt($connection, CURLOPT_HTTPHEADER, $headers);
	
    /*Save the file to local file system - specify the file name in path as well*/
	if (file_put_contents('signature.jpeg', curl_exec($connection)) === false) {
        // Handle unable to write to file error.
        echo('you failed');
        exit;
    }
	
	//$headerSent = curl_getinfo($connection, CURLINFO_HEADER_OUT ); // request headers
	//print_r($headerSent);
	
	//$json = json_decode($response, true);
	//print_r($json); //Get Resposne as JSON Array
	//echo 'Vehicle Name: ';
	//echo $json['vehicles'][0]['name']; //Access Individual property within Response. Response comes as array so use index / iterate thorugh array

?> 