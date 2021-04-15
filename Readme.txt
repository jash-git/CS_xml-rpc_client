C# Call xml-rpc API [CS_xml-rpc_client]

GOOGLE: c# xml-rpc

https://stackoverflow.com/questions/40647779/how-to-call-an-api-which-is-based-on-xml-rpc-specification-in-c
Step 1 : Created a Console Application in .NET

Step 2 : Install the NuGet "xml-rpc.net"

Step 3: Created a sample request model class like this,

Step 4 : Created a sample response model class like this,

Step 5 : Create an interface which is inherited form IXmlRpcProxy base class with the help of the namespace using CookComputing.XmlRpc; and this interface must contain our endpoint method and it should decorate with the filter XmlRpcUrl having the API resource.                     

Step 6 : To make calls to an XML-RPC server it is necessary to use an instance of a proxy class.    