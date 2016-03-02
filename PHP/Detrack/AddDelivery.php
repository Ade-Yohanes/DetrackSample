<?php   

	$data = array(
	array(
      "date"=>date('Y-m-d'),
      "do"=>"DO140211001",
      "address"=>"63 Ubi Avenue 1 Singapore 408937",
      "delivery_time"=>"09=>00 AM - 12=>00 PM",
      "deliver_to"=>"John Tan",
      "phone"=>"+6591234567",
      "notify_email"=>"john.tan@example.com",
      "notify_url"=>"http=>//www.example.com/notify.php",
      "assign_to"=>"1111",
      "instructions"=>"Call customer upon arrival.",
      "zone"=>"East",
      "items"=>array(
         array(
            "sku"=>"T0201",
            "desc"=>"Test Item #01",
            "qty"=>1
         ),
         array(
            "sku"=>"T0202",
            "desc"=>"Test Item #02",
            "qty"=>5
         ),
         array(
            "sku"=>"T0203",
            "desc"=>"Test Item #03",
            "qty"=>10
         )
      )
	)
   );
   
	$data_string = json_encode($data);   
	print_r($data_string);
	/*Set common properties of request*/
	$headers = array(
		'Content-Type: application/json', 
		'Accept: application/json', 
		'Content-length:'.strlen($data_string),
		'X-API-KEY: 3a99928772f834765b675efef2d7330be2e2a7a3ba33b8ff'
	);

	

	// 6. View All Deliveries
	$connection = curl_init();
	curl_setopt($connection, CURLOPT_URL, "https://app.detrack.com/api/v1/deliveries/create.json");
	curl_setopt ($connection, CURLOPT_POST, true);
	curl_setopt($connection, CURLOPT_CUSTOMREQUEST, "POST");  
	curl_setopt($connection,CURLOPT_POSTFIELDS, $data_string);
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
	
	$headerSent = curl_getinfo($connection, CURLINFO_HEADER_OUT ); // request headers
	print_r($headerSent);
	
	$json = json_decode($response, true);
	print_r($json); //Get Resposne as JSON Array
	//echo 'Vehicle Name: ';
	//echo $json['vehicles'][0]['name']; //Access Individual property within Response. Response comes as array so use index / iterate thorugh array

?> 