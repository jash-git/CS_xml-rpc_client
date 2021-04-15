using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookComputing.XmlRpc;//Step 2 ~ xml-rpc

/*
GOOGLE: c# xml-rpc

https://stackoverflow.com/questions/40647779/how-to-call-an-api-which-is-based-on-xml-rpc-specification-in-c
https://tldp.org/HOWTO/XML-RPC-HOWTO/xmlrpc-howto-php.html
https://github.com/marcosbozzani/xmlrpcnet/tree/master/samples/SumAndDiffVB

Step 1 : Created a Console Application in .NET

Step 2 : Install the NuGet "xml-rpc.net"

Step 3: Created a sample request model class like this,

Step 4 : Created a sample response model class like this,

Step 5 : Create an interface which is inherited form IXmlRpcProxy base class with the help of the namespace using CookComputing.XmlRpc; and this interface must contain our endpoint method and it should decorate with the filter XmlRpcUrl having the API resource.                     

Step 6 : To make calls to an XML-RPC server it is necessary to use an instance of a proxy class.         
*/

namespace CS_xml_rpc_client
{

    public class response//Step 4 ~ xml-rpc
    {
        public int sum { get; set; }
        public int difference { get; set; }
    }

    [XmlRpcUrl("http://127.0.0.1:8080/phpxmlrpc/xmlrpc_server.php")]//Step 5 ~ xml-rpc
    public interface sumAndDifference : IXmlRpcProxy
    {
        [XmlRpcMethod("sample.sumAndDifference")]//endpoint name
        response sumAndDifference(int x,int y);
    }

    class Program
    {
        static void Pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            //---
            //Step 6 ~ xml-rpc
            response response = new response();
            sumAndDifference fun = XmlRpcProxyGen.Create<sumAndDifference>();
            response = fun.sumAndDifference(5,3);
            Console.WriteLine("response = {0},{1}", response.sum, response.difference);
            //---Step 6 ~ xml-rpc 
            Pause();
        }
    }
}
