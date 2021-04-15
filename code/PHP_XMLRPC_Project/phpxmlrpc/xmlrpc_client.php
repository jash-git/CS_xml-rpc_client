<html>
	<head>
	<title>XML-RPC PHP Demo</title>
	</head>
	<body>
	<h1>XML-RPC PHP Demo</h1>

	<?php
	//https://tldp.org/HOWTO/XML-RPC-HOWTO/xmlrpc-howto-php.html	
	include 'lib/xmlrpc.inc';

	// Make an object to represent our server.
	$server = new xmlrpc_client('phpxmlrpc/xmlrpc_server.php',
								'127.0.0.1', 8080);

	// Send a message to the server.
	$message = new xmlrpcmsg('sample.sumAndDifference',
							 array(new xmlrpcval(5, 'int'),
								   new xmlrpcval(3, 'int')));
	$result = $server->send($message);

	// Process the response.
	if (!$result) {
		print "<p>Could not connect to HTTP server.</p>";
	} elseif ($result->faultCode()) {
		print "<p>XML-RPC Fault #" . $result->faultCode() . ": " .
			$result->faultString();
	} else {
		$struct = $result->value();
		$sumval = $struct->structmem('sum');
		$sum = $sumval->scalarval();
		$differenceval = $struct->structmem('difference');
		$difference = $differenceval->scalarval();
		print "<p>Sum: " . htmlentities($sum) .
			", Difference: " . htmlentities($difference) . "</p>";
	}
	?>

	</body>
</html>