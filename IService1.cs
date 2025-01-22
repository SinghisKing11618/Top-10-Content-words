using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.ServiceModel.Web;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet]
        List<string> Top10ContentWords(string input);

        [OperationContract]
        [WebGet]
        Boolean isPalindrome(string input);

        [OperationContract]
        [WebGet]
        string sort(string s);

        [OperationContract]
        [WebGet]
        string stemming(string s);

    }

}
