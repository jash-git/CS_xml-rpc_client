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
    //---
    //Step 4 ~ xml-rpc
    public class response01
    {
        public int sum { get; set; }
        public int difference { get; set; }
    }
    public class response02
    {
        public int multiply { get; set; }
        public int divide { get; set; }
    }
    //---Step 4 ~ xml-rpc

    //---
    //Step 5 ~ xml-rpc
    [XmlRpcUrl("http://127.0.0.1:8080/phpxmlrpc/xmlrpc_server.php")]
    public interface sumAndDifference : IXmlRpcProxy
    {
        [XmlRpcMethod("sample.sumAndDifference")]//endpoint name
        response01 sumAndDifference(int x,int y);
    }

    [XmlRpcUrl("http://127.0.0.1:8080/phpxmlrpc/xmlrpc_server.php")]
    public interface MultiplyAndDivide : IXmlRpcProxy
    {
        [XmlRpcMethod("sample.MultiplyAndDivide")]//endpoint name
        response02 MultiplyAndDivide(int x, int y);
    }
    //---Step 5 ~ xml-rpc

    class Program
    {
        static void Pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            try
            {
                //---
                //Step 6 ~ xml-rpc
                response01 response01 = new response01();
                sumAndDifference fun01 = XmlRpcProxyGen.Create<sumAndDifference>();
                response01 = fun01.sumAndDifference(5, 3);
                Console.WriteLine("response01 = {0},{1}", response01.sum, response01.difference);

                response02 response02 = new response02();
                MultiplyAndDivide fun02 = XmlRpcProxyGen.Create<MultiplyAndDivide>();
                response02 = fun02.MultiplyAndDivide(5, 3);
                Console.WriteLine("response02 = {0},{1}", response02.multiply, response02.divide);
                //---Step 6 ~ xml-rpc 
            }
            catch
            {
                Console.WriteLine("XmlRpc isn't connect");
            }

            Pause();
        }
    }
}
