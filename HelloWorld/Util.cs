using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    static class Util
    {
        public static string GetMacByNetworkInterface()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }
        /**根据经纬度查询地理位置接口示例
         * http://restapi.amap.com/v3/geocode/regeo?location=119.785925777778,33.4773057777778&key=17479d86c0c6a0305024e1142351a0a4
         * */
        public static string HttpGetNew(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        public static async Task<HttpResult> UploadPicture(string filePath)
        {
            string AccessKey = "mjd6uCjQwnEAJIuBO7SVEZmgKc9oIwS3qHGWJx_O";
            string SecretKey = "f7N8e_NqIWD32WZiq1tHz64amL60WbK28Ikl1nK8";
            Mac mac = new Mac(AccessKey, SecretKey);
            // 上传文件名
            string key = "dk/" + Util.GetMacByNetworkInterface() + "/" + DateTime.Now.ToString() + ".jpg";
            // 存储空间名
            string Bucket = "z1334";
            // 设置上传策略
            PutPolicy putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            // putPolicy.DeleteAfterDays = 1;
            // 生成上传token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZoneCnEast;
            // 设置 http 或者 https 上传
            config.UseHttps = false;
            config.UseCdnDomains = false;
            config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result =await target.UploadFile(filePath, key, token, null);
            return result;
        }
    }
}
