<?PHP
//https://tldp.org/HOWTO/XML-RPC-HOWTO/xmlrpc-howto-php.html
include "lib/xmlrpc.inc";
include "lib/xmlrpcs.inc";
function sumAndDifference ($params) {

    // Parse our parameters.
    $xval = $params->getParam(0);
    $x = $xval->scalarval();
    $yval = $params->getParam(1);
    $y = $yval->scalarval();

    // Build our response.
    $struct = array('sum' => new xmlrpcval($x + $y, 'int'),
                    'difference' => new xmlrpcval($x - $y, 'int'));
    return new xmlrpcresp(new xmlrpcval($struct, 'struct'));
}

function MultiplyAndDivide ($params) {

    // Parse our parameters.
    $xval = $params->getParam(0);
    $x = $xval->scalarval();
    $yval = $params->getParam(1);
    $y = $yval->scalarval();

    // Build our response.
    $struct = array('multiply' => new xmlrpcval($x * $y, 'int'),
                    'divide' => new xmlrpcval($x / $y, 'int'));
    return new xmlrpcresp(new xmlrpcval($struct, 'struct'));
}

// Declare our signature and provide some documentation.
// (The PHP server supports remote introspection. Nifty!)
$sumAndDifference_sig = array(array('struct', 'int', 'int'));
$sumAndDifference_doc = 'Add and subtract two numbers';

$MultiplyAndDivide_sig = array(array('struct', 'int', 'int'));
$MultiplyAndDivide_doc = 'Multiply and divide two numbers';

new xmlrpc_server(array(
						'sample.sumAndDifference' =>
                        array('function' => 'sumAndDifference',
                              'signature' => $sumAndDifference_sig,
                              'docstring' => $sumAndDifference_doc),				
						'sample.MultiplyAndDivide' =>
                        array('function' => 'MultiplyAndDivide',
                              'signature' => $MultiplyAndDivide_sig,
                              'docstring' => $MultiplyAndDivide_doc)
						)
						);

?>