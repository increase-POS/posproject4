using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using System.Drawing.Printing;

using Newtonsoft.Json.Converters;

namespace SetupPosServer.Classes
{

    public class PosSerialSend
    {

        public string serial { get; set; }
        public string posDeviceCode { get; set; }

        public bool isBooked { get; set; }
        public int isActive { get; set; }
    }


    public class packagesSend
    {

        public string packageName { get; set; }

        public int branchCount { get; set; }
        public int posCount { get; set; }
        public int userCount { get; set; }
        public int vendorCount { get; set; }
        public int customerCount { get; set; }
        public int itemCount { get; set; }
        public int salesInvCount { get; set; }

        public string programName { get; set; }

        public string verName { get; set; }

        public int isActive { get; set; }
        public string packageSaleCode { get; set; }
        public string packageCode { get; set; }
        public int storeCount { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public bool islimitDate { get; set; }
        public Nullable<bool> isOnlineServer { get; set; }
        public string customerServerCode { get; set; }


    }
    public class SendDetail
    {
        public List<PosSerialSend> PosSerialSendList;

        public packagesSend packageSend;
    }
    public class AvtivateServer
    {
      
        public string serverUri { get; set; }
        public string activateCode { get; set; }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 





        public async Task<int> checkconn()
        {
            int id = 1;
            int item = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Activate/checkconn", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = int.Parse(c.Value) ;
                    break;
                }
            }
            return item;


         
        }

        public async Task<int> Sendserverkey(string skey)
        {
            int item = 0;
           // int res = 0;
          //  SendDetail item = new SendDetail();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("skey", skey);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Activate/Sendserverkey", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = int.Parse(c.Value);
                  // item = JsonConvert.DeserializeObject<SendDetail>(c.Value, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                    break;
                }
            }
            return item;

        }



        //public async Task<SendDetail> GetSerialsAndDetails(string packageSaleCode, string customerServerCode)
        //{
        //    SendDetail item = new SendDetail();
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("packageSaleCode", packageSaleCode);
        //    parameters.Add("customerServerCode", customerServerCode);

        //    //#################
        //    IEnumerable<Claim> claims = await APIResult.getList("packageUser/ActivateServer", parameters);

        //    foreach (Claim c in claims)
        //    {
        //        if (c.Type == "scopes")
        //        {
        //            item = JsonConvert.DeserializeObject<SendDetail>(c.Value, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

        //        }
        //    }
        //    return item;

        //}

        // checkincconn

        //public async Task<string> checkincconn()
        //{
          
        //    string item = "";
         
        //    //#################
        //    IEnumerable<Claim> claims = await APIResult.getList("Activate/checkincconn");

        //    foreach (Claim c in claims)
        //    {
        //        if (c.Type == "scopes")
        //        {
        //            item = c.Value;
        //            break;
        //        }
        //    }
        //    return item;



        //}

    }
}
