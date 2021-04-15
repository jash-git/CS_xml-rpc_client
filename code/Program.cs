using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookComputing.XmlRpc;//Step 2 ~ xml-rpc

/*
GOOGLE: c# xml-rpc

https://stackoverflow.com/questions/40647779/how-to-call-an-api-which-is-based-on-xml-rpc-specification-in-c
Step 1 : Created a Console Application in .NET

Step 2 : Install the NuGet "xml-rpc.net"

Step 3: Created a sample request model class like this,

Step 4 : Created a sample response model class like this,

Step 5 : Create an interface which is inherited form IXmlRpcProxy base class with the help of the namespace using CookComputing.XmlRpc; and this interface must contain our endpoint method and it should decorate with the filter XmlRpcUrl having the API resource.                     

Step 6 : To make calls to an XML-RPC server it is necessary to use an instance of a proxy class.         
*/

namespace CS_xml_rpc_client
{
    public class request//Step 3 ~ xml-rpc
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class response//Step 4 ~ xml-rpc
    {
        public int id { get; set; }
        public int status { get; set; }
    }

    [XmlRpcUrl("https://api.XXX.com/XXX")]//Step 5 ~ xml-rpc
    public interface FlRPC : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]//endpoint name
        response login(request request);
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
            request request = new request();
            FlRPC proxy = XmlRpcProxyGen.Create<FlRPC>();
            request.password = "xxxxxxxx";
            request.username = "xxxx@xxxx.org";
            response = proxy.login(request);
            //---Step 6 ~ xml-rpc 
            Pause();
        }
    }
}
