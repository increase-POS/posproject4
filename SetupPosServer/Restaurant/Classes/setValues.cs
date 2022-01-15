using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SetupPosServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

using System.Security.Claims;


namespace SetupPosServer.Classes
{
    public class SetValues
    {
        public int valId { get; set; }
        public string value { get; set; }
        public Nullable<int> isDefault { get; set; }
        public Nullable<int> isSystem { get; set; }
        public string notes { get; set; }
        public Nullable<int> settingId { get; set; }
        //setting
        public string name { get; set; }
        public async Task<List<SetValues>> GetAll()
        {

            List<SetValues> list = new List<SetValues>();
            //  Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("mainBranchId", mainBranchId.ToString());
            //parameters.Add("userId", userId.ToString());
            //parameters.Add("date", date.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("setValues/Get");

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    list.Add(JsonConvert.DeserializeObject<SetValues>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return list;

            //List<SetValues> list = null;
            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "setValues/Get");
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Get;
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var jsonString = await response.Content.ReadAsStringAsync();
            //        jsonString = jsonString.Replace("\\", string.Empty);
            //        jsonString = jsonString.Trim('"');
            //        // fix date format
            //        JsonSerializerSettings settings = new JsonSerializerSettings
            //        {
            //            Converters = new List<JsonConverter> { new BadDateFixingConverter() },
            //            DateParseHandling = DateParseHandling.None
            //        };
            //        list = JsonConvert.DeserializeObject<List<SetValues>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            //        return list;
            //    }
            //    else //web api sent error response 
            //    {
            //        list = new List<SetValues>();
            //    }
            //    return list;
            //}
        }


        //print
       
        public async Task<List<SetValues>> GetBySetvalNote(string setvalnote)
        {
            List<SetValues> list = new List<SetValues>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("setvalnote", setvalnote);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("setValues/GetBySetvalNote", parameters);



            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    list.Add(JsonConvert.DeserializeObject<SetValues>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return list;



            //List<SetValues> list = null;
            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "setValues/GetBySetvalNote?setvalnote=" + setvalnote);
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Get;
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var jsonString = await response.Content.ReadAsStringAsync();
            //        jsonString = jsonString.Replace("\\", string.Empty);
            //        jsonString = jsonString.Trim('"');
            //        // fix date format
            //        JsonSerializerSettings settings = new JsonSerializerSettings
            //        {
            //            Converters = new List<JsonConverter> { new BadDateFixingConverter() },
            //            DateParseHandling = DateParseHandling.None
            //        };
            //        list = JsonConvert.DeserializeObject<List<SetValues>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            //        return list;
            //    }
            //    else //web api sent error response 
            //    {
            //        // SetValues sv = new SetValues();
            //        //    sv.notes =  await response.Content.ReadAsStringAsync();
            //        list = new List<SetValues>();
            //        //  list.Add(sv);

            //    }
            //    return list;
            //}
        }
        // email
        public async Task<List<SetValues>> GetBySetName(string name)
        {

            List<SetValues> list = new List<SetValues>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", name);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("setValues/GetBySetName", parameters);



            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    list.Add(JsonConvert.DeserializeObject<SetValues>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return list;


            //List<SetValues> list = null;
            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "setValues/GetBySetName?name=" + name);
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Get;
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var jsonString = await response.Content.ReadAsStringAsync();
            //        jsonString = jsonString.Replace("\\", string.Empty);
            //        jsonString = jsonString.Trim('"');
            //        // fix date format
            //        JsonSerializerSettings settings = new JsonSerializerSettings
            //        {
            //            Converters = new List<JsonConverter> { new BadDateFixingConverter() },
            //            DateParseHandling = DateParseHandling.None
            //        };
            //        list = JsonConvert.DeserializeObject<List<SetValues>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            //        return list;
            //    }
            //    else //web api sent error response 
            //    {
            //       // SetValues sv = new SetValues();
            //    //    sv.notes =  await response.Content.ReadAsStringAsync();
            //       list = new List<SetValues>();
            //      //  list.Add(sv);

            //    }
            //    return list;
            //}
        }
        // email
        public async Task<int> SaveValueByNotes(SetValues obj)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "setValues/SaveValueByNotes";

            var myContent = JsonConvert.SerializeObject(obj);
            parameters.Add("Object", myContent);
           return await APIResult.post(method, parameters);



            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //// 
            //var myContent = JsonConvert.SerializeObject(newObject);

            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    // encoding parameter to get special characters
            //    myContent = HttpUtility.UrlEncode(myContent);
            //    request.RequestUri = new Uri(Global.APIUri
            //                                 + "setValues/SaveValueByNotes?newObject="
            //                                 + myContent);
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Post;
            //    //set content type
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var message = await response.Content.ReadAsStringAsync();
            //        message = JsonConvert.DeserializeObject<string>(message);
            //        return message;
            //    }
            //    return "";
            //}
        }

        public async Task<int> Save(SetValues obj)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "setValues/Save";

            var myContent = JsonConvert.SerializeObject(obj);
            parameters.Add("Object", myContent);
           return await APIResult.post(method, parameters);

            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //// 
            //var myContent = JsonConvert.SerializeObject(newObject);

            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    // encoding parameter to get special characters
            //    myContent = HttpUtility.UrlEncode(myContent);
            //    request.RequestUri = new Uri(Global.APIUri
            //                                 + "setValues/Save?newObject="
            //                                 + myContent);
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Post;
            //    //set content type
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var message = await response.Content.ReadAsStringAsync();
            //        message = JsonConvert.DeserializeObject<string>(message);
            //        return message;
            //    }
            //    return "";
            //}
        }


        public async Task<SetValues> GetByID(int valId)
        {

            SetValues item = new SetValues();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", valId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("setValues/GetByID", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<SetValues>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;


            //SetValues Object = new SetValues();

            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "setValues/GetByID");
            //    request.Headers.Add("Id", valId.ToString());
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Get;
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var jsonString = await response.Content.ReadAsStringAsync();

            //        Object = JsonConvert.DeserializeObject<SetValues>(jsonString);

            //        return Object;
            //    }

            //    return Object;
            //}
        }

      



        public async Task<int> Delete(int Id, int userId)
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", Id.ToString());
            parameters.Add("userId", userId.ToString());

            string method = "setValue/Delete";
           return await APIResult.post(method, parameters);



            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "setValue/Delete?Id=" + Id + "&userId=" + userId );

            //    request.Headers.Add("APIKey", Global.APIKey);

            //    request.Method = HttpMethod.Post;

            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
        }


        // get is exist

        //image part
        
        //


    }
}

