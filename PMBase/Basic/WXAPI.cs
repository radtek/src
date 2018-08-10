using cn.justwin.Domain.Services;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm.action;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace PMBase.Basic
{
    public class WXAPI
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        /// <summary>
        /// 获取 access_token
        /// </summary>
        /// <returns>返回 access_token</returns>
        //public static string getToken()
        //{
        //    #region
        //    /*
        //     获取access_token
        //    请求方式：GET（HTTPS）
        //    请求URL：https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=ID&corpsecret=SECRECT
        //    注：此处标注大写的单词ID和SECRET，为需要替换的变量，根据实际获取值更新。其它接口也采用相同的标注，不再说明。

        //    参数说明：

        //    参数	必须	说明
        //    corpid	是	企业ID
        //    corpsecret	是	应用的凭证密钥
        //    权限说明：

        //    每个应用有独立的secret，所以每个应用的access_token应该分开来获取

        //    返回结果：

        //    {
        //       "errcode":0，
        //       "errmsg":""，
        //       "access_token": "accesstoken000001",
        //       "expires_in": 7200
        //    }
        //    参数	说明
        //    access_token	获取到的凭证,最长为512字节
        //    expires_in	凭证的有效时间（秒）
        //    出错返回示例：

        //    {
        //       "errcode":40091,
        //       "errmsg":"secret is invalid"
        //    }
        //    第四步：缓存和刷新access_token

        //    开发者需要缓存access_token，用于后续接口的调用（注意：不能频繁调用gettoken接口，否则会受到频率拦截）。当access_token失效或过期时，需要重新获取。

        //    access_token的有效期通过返回的expires_in来传达，正常情况下为7200秒（2小时），有效期内重复获取返回相同结果，过期后获取会返回新的access_token。此时企业微信保证新旧两个access_token在短时间内同时可用（access_token对应的有效期内可用），以保证企业服务的平滑过渡。
        //    由于企业微信每个应用的access_token是彼此独立的，所以进行缓存时需要区分应用来进行存储。
        //    access_token至少保留512字节的存储空间。
        //    企业微信可能会出于运营需要，提前使access_token失效，开发者应实现access_token失效时重新获取的逻辑。
        //     */
        //    #endregion
        //    string strToken = null;
        //    try
        //    {
        //        strToken = HttpContext.Current.Request.Cookies["access_token"].Value;
        //    }
        //    catch
        //    {
        //        strToken = null;
        //    }
        //    if (strToken == null)
        //    {
        //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("corpSecret") + "";
        //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
        //        StreamReader sr = new StreamReader(response.GetResponseStream());
        //        string strResult = sr.ReadToEnd();
        //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
        //        HttpCookie httpCookie = new HttpCookie("access_token");
        //        httpCookie.Value = access_token;
        //        HttpContext.Current.Response.Cookies.Add(httpCookie);
        //        httpCookie.Expires = DateTime.Now.AddHours(1);
        //        return access_token;
        //    }
        //    else
        //    {
        //        return strToken;
        //    }
        //}

        public static string getTokenByAgentId(string AgentId)
        {
            #region
            /*
             获取access_token
            请求方式：GET（HTTPS）
            请求URL：https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=ID&corpsecret=SECRECT
            注：此处标注大写的单词ID和SECRET，为需要替换的变量，根据实际获取值更新。其它接口也采用相同的标注，不再说明。

            
             */
            #endregion
            string Secret = string.Empty;
            string strToken = string.Empty;
            if (AgentId != "-1")
            {
                try
                {
                    //Get access_token from Cookies
                    return HttpContext.Current.Request.Cookies["access_token_"+ AgentId].Value;
                }
                catch
                {
                    string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_"+ AgentId) + "";
                    HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string strResult = sr.ReadToEnd();
                    string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
                    HttpCookie httpCookie = new HttpCookie("access_token_"+ AgentId);
                    httpCookie.Value = access_token;
                    HttpContext.Current.Response.Cookies.Add(httpCookie);
                    httpCookie.Expires = DateTime.Now.AddHours(1);
                    return access_token;
                }
            }
            else //通讯录
            {
                try
                {
                    return HttpContext.Current.Request.Cookies["access_token_txl"].Value;
                }
                catch
                {
                    string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_txl") + "";
                    HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string strResult = sr.ReadToEnd();
                    string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
                    HttpCookie httpCookie = new HttpCookie("access_token_txl");
                    httpCookie.Value = access_token;
                    HttpContext.Current.Response.Cookies.Add(httpCookie);
                    httpCookie.Expires = DateTime.Now.AddHours(1);
                    return access_token;
                }
            }
        }
        /// <summary>
        /// 获取 通讯录 的access_token
        /// </summary>  
        /// <param name="AgentId">AgentId (通讯录 无AgentId,参数设定为 -1) </param>
        /// <returns>返回 access_token</returns>
        public static string getTokenByAgentId(int AgentId)
        {
            #region
            /*
             获取access_token
            请求方式：GET（HTTPS）
            请求URL：https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=ID&corpsecret=SECRECT
            注：此处标注大写的单词ID和SECRET，为需要替换的变量，根据实际获取值更新。其它接口也采用相同的标注，不再说明。

            
             */
            #endregion
            string Secret = string.Empty;
            string strToken = string.Empty;
            #region

            // if(AgentId== 1000008)//工作日志
            //{
            //    try
            //    {
            //        return HttpContext.Current.Request.Cookies["access_token_log"].Value;
            //    }
            //    catch
            //    {
            //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_log") + "";
            //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            //        StreamReader sr = new StreamReader(response.GetResponseStream());
            //        string strResult = sr.ReadToEnd();
            //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
            //        HttpCookie httpCookie = new HttpCookie("access_token_log");
            //        httpCookie.Value = access_token;
            //        HttpContext.Current.Response.Cookies.Add(httpCookie);
            //        httpCookie.Expires = DateTime.Now.AddHours(1);
            //        return access_token;
            //    }
            //}
            //else if(AgentId == 1000010)//工作任务
            //{
            //    try
            //    {
            //        return HttpContext.Current.Request.Cookies["access_token_task"].Value;
            //    }
            //    catch
            //    {
            //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_task") + "";
            //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            //        StreamReader sr = new StreamReader(response.GetResponseStream());
            //        string strResult = sr.ReadToEnd();
            //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
            //        HttpCookie httpCookie = new HttpCookie("access_token_task");
            //        httpCookie.Value = access_token;
            //        HttpContext.Current.Response.Cookies.Add(httpCookie);
            //        httpCookie.Expires = DateTime.Now.AddHours(1);
            //        return access_token;
            //    }
            //}
            //else if(AgentId == 1000012)//工程文档
            //{
            //    try
            //    {
            //        return HttpContext.Current.Request.Cookies["access_token_doc"].Value;
            //    }
            //    catch
            //    {
            //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_doc") + "";
            //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            //        StreamReader sr = new StreamReader(response.GetResponseStream());
            //        string strResult = sr.ReadToEnd();
            //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
            //        HttpCookie httpCookie = new HttpCookie("access_token_doc");
            //        httpCookie.Value = access_token;
            //        HttpContext.Current.Response.Cookies.Add(httpCookie);
            //        httpCookie.Expires = DateTime.Now.AddHours(1);
            //        return access_token;
            //    }
            //}
            //else if (AgentId == 1000015)//库存信息
            //{
            //    try
            //    {
            //        return HttpContext.Current.Request.Cookies["access_token_Treasury"].Value;
            //    }
            //    catch
            //    {
            //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_Treasury") + "";
            //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            //        StreamReader sr = new StreamReader(response.GetResponseStream());
            //        string strResult = sr.ReadToEnd();
            //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
            //        HttpCookie httpCookie = new HttpCookie("access_token_Treasury");
            //        httpCookie.Value = access_token;
            //        HttpContext.Current.Response.Cookies.Add(httpCookie);
            //        httpCookie.Expires = DateTime.Now.AddHours(1);
            //        return access_token;
            //    }
            //}
            //else if (AgentId == -2)//全局
            //{
            //    try
            //    {
            //        return HttpContext.Current.Request.Cookies["access_token"].Value;
            //    }
            //    catch
            //    {
            //        string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("corpSecret") + "";
            //        HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            //        StreamReader sr = new StreamReader(response.GetResponseStream());
            //        string strResult = sr.ReadToEnd();
            //        string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
            //        HttpCookie httpCookie = new HttpCookie("access_token");
            //        httpCookie.Value = access_token;
            //        HttpContext.Current.Response.Cookies.Add(httpCookie);
            //        httpCookie.Expires = DateTime.Now.AddHours(1);
            //        return access_token;
            //    }
            //}
            //else 
            //{
            #endregion
            //通讯录
            try
            {
                return HttpContext.Current.Request.Cookies["access_token_txl"].Value;
            }
            catch
            {
                string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + new BasicConfigService().GetValue("corpId") + "&corpsecret=" + new BasicConfigService().GetValue("Secret_txl") + "";
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string strResult = sr.ReadToEnd();
                string access_token = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
                HttpCookie httpCookie = new HttpCookie("access_token_txl");
                httpCookie.Value = access_token;
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                httpCookie.Expires = DateTime.Now.AddHours(1);
                return access_token;
            }
            //}
        }
        public static string getTicket(string AgentId)
        {
            #region
            /*
                获取jsapi_ticket

                生成签名之前必须先了解一下jsapi_ticket，jsapi_ticket是H5应用调用企业微信JS接口的临时票据。正常情况下，jsapi_ticket的有效期为7200秒，通过access_token来获取。由于获取jsapi_ticket的api调用次数非常有限，频繁刷新jsapi_ticket会导致api调用受限，影响自身业务，开发者必须在自己的服务全局缓存jsapi_ticket。

                请求方式：GET（HTTPS）
                请求URL：https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=ACCESS_TOKEN

                参数说明：

                参数	必须	说明
                access_token	是	调用接口凭证，获取方式参考“获取企业access_token”
                返回结果：

                {
                    "errcode":0,
                    "errmsg":"ok",
                    "ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA",
                    "expires_in":7200
                }
             */
            #endregion
            string strTicket = null;
            try
            {
                strTicket = HttpContext.Current.Request.Cookies["jsapi_ticket"].Value;
            }
            catch
            {
                strTicket = null;
            }
            if (strTicket == null)
            {
                string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + getTokenByAgentId(AgentId) + "";
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string strResult = sr.ReadToEnd();
                string ticket = strResult.Split(',')[2].Split(':')[1].Split('"')[1].ToString();
                HttpCookie httpCookie = new HttpCookie("jsapi_ticket");
                httpCookie.Value = ticket;
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                httpCookie.Expires = DateTime.Now.AddHours(1);
                return ticket;
            }
            else
            {
                return strTicket;
            }
        }
        /// <summary>
        /// 获取微信端 当前操作用户ID
        /// </summary>
        /// <param name="strCode">code</param>
        /// <returns></returns>
        public static string getUserIdByCode(string strCode, string AgentId)
        {
            string UserId = null;
            try
            {
                UserId = HttpContext.Current.Request.Cookies["UserId"].Value;
            }
            catch
            {
                UserId = null;
            }
            if (UserId == null || UserId == "no_user")
            {
                string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + getTokenByAgentId(AgentId) + "&code=" + strCode + "";
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string strResult = sr.ReadToEnd();//{ "UserId":"8aac9e075a8ca902015a8cfdd75d0018","DeviceId":"cd9e459ea708a948d5c2f5a6ca8838cf","errcode":0,"errmsg":"ok"}
                try
                {
                    UserId = strResult.Split(',')[0].Split(':')[1].Split('"')[1].ToString();
                    string strSQL = "select * from PT_yhmc where WXID='" + UserId + "'";
                    DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        HttpCookie httpCookie = new HttpCookie("UserId");
                        httpCookie.Value = dt.Rows[0]["v_yhdm"].ToString();
                        HttpContext.Current.Response.Cookies.Add(httpCookie);
                        httpCookie.Expires = DateTime.Now.AddHours(1);
                        return dt.Rows[0]["v_yhdm"].ToString();
                    }
                    else
                    {
                        return "no_user";
                    }
                }
                catch(Exception ex)
                {
                    return strResult;//"ex_user";
                }
            }
            else
            {
                return UserId;
            }
        }

        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="USERID">用户ID</param>
        /// <returns></returns>
        public static JObject getUserInfo(string USERID, string AgentId)
        {
            #region 微信 读取成员 说明
            /*
           在通讯录同步助手中此接口可以读取企业通讯录的所有成员信息，而企业自定义的应用可以读取该应用设置的可见范围内的成员信息。

            请求方式：GET（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&userid=USERID

            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            userid	是	成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
            权限说明：

            系统应用须拥有指定部门的管理权限。

            返回结果：

            {
               "errcode": 0,
               "errmsg": "ok",
               "userid": "zhangsan",
               "name": "李四",
               "department": [1, 2],
               "order": [1, 2],
               "position": "后台工程师",
               "mobile": "15913215421",
               "gender": "1",
               "email": "zhangsan@gzdev.com",
               "isleader": 1,
               "avatar": "http://wx.qlogo.cn/mmopen/ajNVdqHZLLA3WJ6DSZUfiakYe37PKnQhBIeOQBO4czqrnZDS79FH5Wm5m4X69TBicnHFlhiafvDwklOpZeXYQQ2icg/0",
               "telephone": "020-123456",
               "english_name": "jackzhang",
               "extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}，
               "status": 1
            }
             */
            #endregion
            try
            {
                string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=" + getTokenByAgentId(AgentId) + "&userid=" + USERID + "";
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string strResult = sr.ReadToEnd();
                JObject json1 = (JObject)JsonConvert.DeserializeObject(strResult);

                //JArray array = (JArray)json1;
                //string aa = "";
                //foreach (var jObject in array)
                //{
                //    //赋值属性
                //    aa = jObject["id"].ToString();//获取字符串中id值
                //}
                //return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
                return json1;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 创建部门 
        /// </summary>
        /// <param name="dataRow">数据信息行</param>
        /// <returns>返回结果</returns>
        public static string createWXdpt(DataRow dataRow)
        {
            #region 微信 创建部门 说明
            /*
            请求方式：POST（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=ACCESS_TOKEN

            请求包体：

            {
               "name": "广州研发中心",
               "parentid": 1,
               "order": 1,
               "id": 2
            }
            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            name	是	部门名称。长度限制为1~64个字节，字符不能包括\:?”<>｜
            parentid	是	父部门id，32位整型
            order	否	在父部门中的次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
            id	否	部门id，32位整型。指定时必须大于1，否则自动生成
            权限说明：

            系统应用须拥有父部门的管理权限。

            注意，部门的最大层级为15层；部门总数不能超过3万个；每个部门下的节点不能超过3万个。建议保证创建的部门和对应部门成员是串行化处理。
            返回结果：

            {
               "errcode": 0,
               "errmsg": "created",
               "id": 2
            }
            参数说明：

            参数	说明
            errcode	返回码
            errmsg	对返回码的文本描述内容
            id	创建的部门id
            */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");//gb2312
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "\"" + dataRow["V_BMMC"].ToString() + "\"");
            parameters.Add("parentid", "\"" + dataRow["i_sjdm"].ToString() + "\"");
            parameters.Add("order", "" + dataRow["i_xh"].ToString() + "");
            parameters.Add("id", "\"" + dataRow["i_bmdm"].ToString() + "\"");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="dataRow">数据信息行</param>
        /// <returns>返回结果</returns>
        public static string updateWXdpt(DataRow dataRow)
        {
            #region 微信 更新部门 说明
            /*
             请求方式：POST（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=ACCESS_TOKEN

            请求包体（如果非必须的字段未指定，则不更新该字段）：

            {
               "id": 2,
               "name": "广州研发中心",
               "parentid": 1,
               "order": 1
            }
            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            id	是	部门id
            name	否	部门名称。长度限制为1~64个字节，字符不能包括\:?”<>｜
            parentid	否	父部门id
            order	否	在父部门中的次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
            权限说明 ：

            系统应用须拥有指定部门的管理权限。

            注意，部门的最大层级为15层；部门总数不能超过3万个；每个部门下的节点不能超过3万个。
            返回结果：

            {
               "errcode": 0,
               "errmsg": "updated"
            }
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");//gb2312
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "\"" + dataRow["V_BMMC"].ToString() + "\"");
            parameters.Add("parentid", "\"" + dataRow["i_sjdm"].ToString() + "\"");
            parameters.Add("order", "" + dataRow["i_xh"].ToString() + "");
            parameters.Add("id", "\"" + dataRow["i_bmdm"].ToString() + "\"");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="ID">部门ID</param>
        /// <returns>返回结果</returns>
        public static string deletedWXdpt(string ID)
        {
            #region 微信 删除部门 说明
            /*
             请求方式：GET（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token=ACCESS_TOKEN&id=ID

            参数说明 ：

            参数	必须	说明
            access_token	是	调用接口凭证
            id	否	部门id。（注：不能删除根部门；不能删除含有子部门、成员的部门）
            权限说明：

            系统应用须拥有指定部门的管理权限。

            返回结果：

            {
               "errcode": 0,
               "errmsg": "deleted"
            }
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token=" + strToken + "&id=" + ID + "";
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        /// <summary>
        /// 创建人员
        /// </summary>
        /// <param name="dataRow">数据信息行</param>
        /// <returns>返回结果</returns>
        public static string createWXry(DataRow dataRow)
        {
            #region 微信 创建成员 说明  
            /*
             创建成员
            请求方式：POST（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=ACCESS_TOKEN

            请求包体：

            {
               "userid": "zhangsan",
               "name": "张三",
               "english_name": "jackzhang",
               "mobile": "15913215421",
               "department": [1, 2],
               "order":[10,40],
               "position": "产品经理",
               "gender": "1",
               "email": "zhangsan@gzdev.com",
               "isleader": 1,
               "enable":1,
               "avatar_mediaid": "2-G6nrLmr5EC3MNb_-zL1dDdzkd0p7cNliYu9V5w7o8K0",
               "telephone": "020-123456"，
               "extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
            }
            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            userid	是	成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
            name	是	成员名称。长度为1~64个字节
            english_name	否	英文名。长度为1-64个字节。
            mobile	否	手机号码。企业内必须唯一，mobile/email二者不能同时为空
            department	是	成员所属部门id列表,不超过20个
            order	否	部门内的排序值，默认为0。数量必须和department一致，数值越大排序越前面。有效的值范围是[0, 2^32)
            position	否	职位信息。长度为0~64个字节
            gender	否	性别。1表示男性，2表示女性
            email	否	邮箱。长度为0~64个字节。企业内必须唯一，mobile/email二者不能同时为空
            telephone	否	座机。长度0-64个字节。
            isleader	否	上级字段，标识是否为上级。
            avatar_mediaid	否	成员头像的mediaid，通过多媒体接口上传图片获得的mediaid
            enable	否	启用/禁用成员。1表示启用成员，0表示禁用成员
            extattr	否	自定义字段。自定义字段需要先在WEB管理端“我的企业” — “通讯录管理”添加，否则忽略未知属性的赋值
            权限说明：

            系统应用须拥有指定部门的管理权限。

            注意，每个部门下的节点不能超过3万个。建议保证创建department对应的部门和创建成员是串行化处理。
            返回结果：
            {
               "errcode": 0,
               "errmsg": "created"
            }
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");//gb2312
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userid", "\"" + dataRow["v_yhdm"].ToString() + "\"");
            parameters.Add("name", "\"" + dataRow["v_xm"].ToString() + "\"");
            parameters.Add("mobile", "\"" + dataRow["MobilePhoneCode"].ToString() + "\"");
            // parameters.Add("email", "\"xsrsl1686@126.com\"");
            parameters.Add("department", "[" + dataRow["i_bmdm"].ToString() + "]");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="dataRow">数据信息行</param>
        /// <returns>返回结果</returns>
        public static string updateWXry(DataRow dataRow)
        {
            #region 微信 更新人员 说明  
            /*
             更新成员
            请求方式：POST（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=ACCESS_TOKEN

            请求包体：

            {
               "userid": "zhangsan",
               "name": "李四",
               "department": [1],
               "order": [10],
               "position": "后台工程师",
               "mobile": "15913215421",
               "gender": "1",
               "email": "zhangsan@gzdev.com",
               "isleader": 0,
               "enable": 1,
               "avatar_mediaid": "2-G6nrLmr5EC3MNb_-zL1dDdzkd0p7cNliYu9V5w7o8K0",
               "telephone": "020-123456",
               "english_name": "jackzhang",
               "extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
            }
            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            userid	是	成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
            name	否	成员名称。长度为1~64个字节
            english_name	否	英文名。长度为1-64个字节。
            mobile	否	手机号码。企业内必须唯一。若成员已激活企业微信，则需成员自行修改
            department	否	成员所属部门id列表,不超过20个
            order	否	部门内的排序值，默认为0。数量必须和department一致，数值越大排序越前面。有效的值范围是[0, 2^32)
            position	否	职位信息。长度为0~64个字节
            gender	否	性别。1表示男性，2表示女性
            email	否	邮箱。长度为0~64个字节。企业内必须唯一
            telephone	否	座机。长度0-64个字节。
            isleader	否	上级字段，标识是否为上级。
            avatar_mediaid	否	成员头像的mediaid，通过多媒体接口上传图片获得的mediaid
            enable	否	启用/禁用成员。1表示启用成员，0表示禁用成员
            extattr	否	扩展属性。扩展属性需要在WEB管理端创建后才生效，否则忽略未知属性的赋值
            特别地，如果userid由系统自动生成，则仅允许修改一次。新值可由new_userid字段指定。
            权限说明：

            系统应用须拥有指定部门、成员的管理权限。

            注意，每个部门下的节点不能超过3万个。
            返回结果：

            {
               "errcode": 0,
               "errmsg": "updated"
            }
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");//gb2312
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userid", "\"" + dataRow["v_yhdm"].ToString() + "\"");
            parameters.Add("name", "\"" + dataRow["v_xm"].ToString() + "\"");
            parameters.Add("mobile", "\"" + dataRow["MobilePhoneCode"].ToString() + "\"");
            // parameters.Add("email", "\"xsrsl1686@126.com\"");
            parameters.Add("department", "[" + dataRow["i_bmdm"].ToString() + "]");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="ID">人员ID</param>
        /// <returns>返回结果</returns>
        public static string deletedWXry(string ID)
        {
            #region 微信 删除人员 说明
            /*
            删除成员
            请求方式：GET（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token=ACCESS_TOKEN&userid=USERID

            参数说明：

            参数	必须	说明
            access_token	是	调用接口凭证
            userid	是	成员UserID。对应管理端的帐号
            权限说明：

            系统应用须拥有指定成员的管理权限。

            返回结果：

            {
               "errcode": 0,
               "errmsg": "deleted"
            }
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token=" + strToken + "&userid=" + ID + "";
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
        }

        //创建随机字符串  
        public static string createNonceStr()
        {

            int length = 16;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string str = "";
            Random rad = new Random();
            for (int i = 0; i < length; i++)
            {
                str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
            }
            return str;
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>double</returns>  
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = Convert.ToInt32((time - startTime).TotalSeconds);
            return intResult;
        }
        //SHA1哈希加密算法  
        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }
        ///   <summary> 
        ///   得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        ///   </summary> 
        ///   <param   name="CnChar">单个汉字</param> 
        ///   <returns>单个大写字母</returns> 
        public static string GetCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                //   get   the     array   of   byte   from   the   single   char    
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }
            #region table   of   the   constant   list
            //expresstion 
            //table   of   the   constant   list 
            // 'A';           //45217..45252 
            // 'B';           //45253..45760 
            // 'C';           //45761..46317 
            // 'D';           //46318..46825 
            // 'E';           //46826..47009 
            // 'F';           //47010..47296 
            // 'G';           //47297..47613 

            // 'H';           //47614..48118 
            // 'J';           //48119..49061 
            // 'K';           //49062..49323 
            // 'L';           //49324..49895 
            // 'M';           //49896..50370 
            // 'N';           //50371..50613 
            // 'O';           //50614..50621 
            // 'P';           //50622..50905 
            // 'Q';           //50906..51386 

            // 'R';           //51387..51445 
            // 'S';           //51446..52217 
            // 'T';           //52218..52697 
            //没有U,V 
            // 'W';           //52698..52979 
            // 'X';           //52980..53640 
            // 'Y';           //53689..54480 
            // 'Z';           //54481..55289 
            #endregion
            //   iCnChar match     the   constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= .51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }


        /// <summary>
        /// 发送微信消息
        /// </summary>
        /// <param name="sendUserId">发送人ID</param>
        /// <param name="toUserId1">接收人ID1</param>
        /// <param name="toUserId2">接收人ID2</param>
        /// <param name="mk">对应的功能模块</param>
        /// <param name="Id">对应的功能模块 ID</param>
        /// <param name="title">对应的功能模块 标题</param>
        /// <param name="time">对应的功能模块 时间</param>
        public static void sendWeChatMsg(string sendUserId, string toUserId1, string toUserId2, string mk, string Id, string title, string time)
        {
            string strSYR = toUserId1;//审阅人
            string strXGRS = toUserId2;//相关人

            string strUsers = "";
            if (!string.IsNullOrEmpty(strSYR))
            {
                strUsers += "'" + strSYR + "',";
            }
            if (!string.IsNullOrEmpty(strXGRS))
            {
                ////string[] strXGR = strXGRS.Replace(",","','");//.Split(',');
                //    strUsers += "," + "'" + strXGRS.Replace(",", "','") + "'";
                string[] strXGR = strXGRS.Split(',');
                foreach (string str in strXGR)
                {
                    strUsers += "'" + str + "'" + ",";
                }
            }
            if (!string.IsNullOrEmpty(strUsers))
            {
            string strSQL1 = "select * from PT_yhmc where v_yhdm ='" + sendUserId + "'";
            DataTable dt1 = publicDbOpClass.DataTableQuary(strSQL1);
            string strSQL = "select * from PT_yhmc where v_yhdm in(" + strUsers.Substring(0, strUsers.Length - 1) + ") and WXID is not null";
            DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
            //string wxUsers = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str1 = new BasicConfigService().GetValue("domain");
                    string str2 = "";
                    string strTitle = "";
                    int AgentId = 0;
                    if (mk == "log")
                    {
                        str2 = "/WeChat/log/show.html?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        strTitle = "您有新的工作日志待查阅";
                        AgentId = 1000008;
                    }
                    if (mk == "logPL")
                    {
                        str2 = "/WeChat/log/show.html?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        strTitle = "有新的工作日志评论@您";
                        AgentId = 1000008;
                    }
                    if (mk == "task")
                    {
                        str2 = "/WeChat/task/show.aspx?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        strTitle = "您有新的工作任务待查阅";
                        AgentId = 1000010;//1000010
                    }
                    if (mk == "taskPL")
                    {
                        str2 = "/WeChat/task/show.aspx?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        strTitle = "有新的工作任务评论@您";
                        AgentId = 1000010;//1000010
                    }
                    if (mk == "taskUp")
                    {
                        str2 = "/WeChat/task/show.aspx?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        strTitle = "您创建的工作任务有新的进度";
                        AgentId = 1000010;//1000010
                    }
                        //if (mk == "wf")
                        //{
                        //    str2 = "/WeChat/task/show.aspx?id=" + Id + "&userType=tj&userID=" + dr["v_yhdm"];
                        //    //https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx251384a873c4d422&redirect_uri=http%3a%2f%2fjs.e-fucheng.com%2fEPC%2fWorkFlow%2fPTAuditListWX.aspx&response_type=code&scope=snsapi_base#wechat_redirect
                          
                        //}
                        string strURL = "";
                        if (mk == "wf")
                        {
                            strURL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx251384a873c4d422&redirect_uri=http%3a%2f%2fjs.e-fucheng.com%2fEPC%2fWorkFlow%2fPTAuditListWX.aspx&response_type=code&scope=snsapi_base#wechat_redirect";
                            strTitle = "您有新的工作待审批";
                            AgentId = 1000024;
                        } else
                        {
                            strURL = str1 + str2;
                        }
                        string description = "<div class=\\\"highlight\\\">" + title + "</div><div class=\\\"gray\\\">[发送人:" + dt1.Rows[0]["v_xm"].ToString() + "] " + time + "</div>";
                    string btntxt = "点击查看";
                    string strs = WXAPI.sendTextCard(strTitle, AgentId, description, strURL, dr["WXID"].ToString(), btntxt);
                    //RegisterScript("alert('" + strs + "');");
                }
                }
            }
        }

        /// <summary>
        /// 文本消息
        /// </summary>
        /// /// <param name="agentid">企业应用的id，整型。 工作日志：1000008</param>
        /// <param name="content">文本消息内容</param>
        /// <param name="touser">消息接收者，多个接收者用‘|’分隔，最多支持1000个</param>
        /// <returns></returns>
        public static string sendText(int agentid, string content, string url, string touser)
        {
            #region 说明
            /*
             文本消息
            请求示例：

            {
               "touser" : "UserID1|UserID2|UserID3",
               "toparty" : "PartyID1|PartyID2",
               "totag" : "TagID1 | TagID2",
               "msgtype" : "text",
               "agentid" : 1,
               "text" : {
                   "content" : "你的快递已到，请携带工卡前往邮件中心领取。\n出发前可查看<a href=\"http://work.weixin.qq.com\">邮件中心视频实况</a>，聪明避开排队。"
               },
               "safe":0
            }
            参数说明：

            参数	是否必须	说明
            touser	否	成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向该企业应用的全部成员发送
            toparty	否	部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            totag	否	标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            msgtype	是	消息类型，此时固定为：text
            agentid	是	企业应用的id，整型。可在应用的设置页面查看
            content	是	消息内容，最长不超过2048个字节
            safe	否	表示是否是保密消息，0表示否，1表示是，默认0

            特殊说明：
            其中text参数的content字段可以支持换行、以及A标签，即可打开自定义的网页（可参考以上示例代码）(注意：换行符请用转义过的\n)
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(Convert.ToString(agentid));
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("touser", "\"" + touser + "\"");
            parameters.Add("msgtype", "\"text\"");
            parameters.Add("agentid", "" + agentid + "");
            //parameters.Add("text", "\"" + content + "\"");
            parameters.Add("text", "{\"content\" : \"" + content + "<a href=\\\"" + url + "\\\">点击查看</a>\"}");
            //parameters.Add("text", "{\"content\" : \"你的快递已到，请携带工卡前往邮件中心领取。出发前可查看<a href=\\\"http://work.weixin.qq.com\\\">点击查看</a>\"}");
            parameters.Add("safe", "0");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();//return 0 发送成功
        }
        /// <summary>
        /// 文本消息
        /// </summary>
        /// /// <param name="agentid">企业应用的id，整型。 工作日志：1000008</param>
        /// <param name="content">文本消息内容</param>
        /// <param name="touser">消息接收者，多个接收者用‘|’分隔，最多支持1000个</param>
        /// <returns></returns>
        public static string sendTextCard(string title, int agentid, string description, string strURL, string touser, string btntxt)
        {
            #region 说明
            /*
            文本卡片消息
            请求示例：

            {
               "touser" : "UserID1|UserID2|UserID3",
               "toparty" : "PartyID1 | PartyID2",
               "totag" : "TagID1 | TagID2",
               "msgtype" : "textcard",
               "agentid" : 1,
               "textcard" : {
                        "title" : "领奖通知",
                        "description" : "<div class=\"gray\">2016年9月26日</div> <div class=\"normal\">恭喜你抽中iPhone 7一台，领奖码：xxxx</div><div class=\"highlight\">请于2016年10月10日前联系行政同事领取</div>",
                        "url" : "URL",
                        "btntxt":"更多"
               }
            }
            参数说明：
            参数	是否必须	说明
            touser	否	成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
            toparty	否	部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            totag	否	标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            msgtype	是	消息类型，此时固定为：textcard
            agentid	是	企业应用的id，整型。可在应用的设置页面查看
            title	是	标题，不超过128个字节，超过会自动截断
            description	是	描述，不超过512个字节，超过会自动截断
            url	是	点击后跳转的链接。
            btntxt	否	按钮文字。 默认为“详情”， 不超过4个文字，超过自动截断。
            文本卡片消息展现 ：
            特殊说明：
            卡片消息的展现形式非常灵活，支持使用br标签或者空格来进行换行处理，也支持使用div标签来使用不同的字体颜色，目前内置了3种文字颜色：灰色(gray)、高亮(highlight)、默认黑色(normal)，将其作为div标签的class属性即可，具体用法请参考上面的示例。
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(Convert.ToString(agentid));
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("touser", "\"" + touser + "\"");
            parameters.Add("msgtype", "\"textcard\"");
            parameters.Add("agentid", "" + agentid + "");
            parameters.Add("textcard", "{ \"title\" : \""+ title + "\",\"description\" : \"" + description + "\",\"url\" : \""+ strURL + "\",\"btntxt\" : \""+ btntxt + "\"}");
            //parameters.Add("text", "{\"content\" : \"你的快递已到，请携带工卡前往邮件中心领取。出发前可查看<a href=\\\"http://work.weixin.qq.com\\\">点击查看</a>\"}");
          
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();//return 0 发送成功
        }
        /// <summary>
        /// 图文消息
        /// </summary>
        /// <param name="agentid">企业应用的id，整型。</param>
        /// <param name="news">图文消息，一个图文消息支持1到8条图文 demo:  {"articles": [{"title": "中秋节礼品领取","description": "今年中秋节公司有豪礼相送","url": "URL","picurl":"http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png","btntxt": "更多"}]}</param>
        /// <param name="touser">消息接收者，多个接收者用‘|’分隔，最多支持1000个</param>
        /// <returns></returns>
        public static string sendText_Pic(int agentid, string news, string touser)
        {

            #region 说明
            /*
             
            {
    "articles": [
        {
            "title": "中秋节礼品领取",
            "description": "今年中秋节公司有豪礼相送",
            "url": "URL",
            "picurl": "http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png",
            "btntxt": "更多"
        },
        {
            "title": "中秋节礼品领取",
            "description": "今年中秋节公司有豪礼相送",
            "url": "URL",
            "picurl": "http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png",
            "btntxt": "更多"
        }
    ]
}

             
             图文消息
            请求示例：
            {
               "touser" : "UserID1|UserID2|UserID3",
               "toparty" : "PartyID1 | PartyID2",
               "totag" : "TagID1 | TagID2",
               "msgtype" : "news",
               "agentid" : 1,
               "news" : {
                   "articles" : [
                       {
                           "title" : "中秋节礼品领取",
                           "description" : "今年中秋节公司有豪礼相送",
                           "url" : "URL",
                           "picurl" : "http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png",
                           "btntxt":"更多"
                       }
                    ]
               }
            }
            参数说明：

            参数	是否必须	说明
            touser	否	成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
            toparty	否	部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            totag	否	标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
            msgtype	是	消息类型，此时固定为：news
            agentid	是	企业应用的id，整型。可在应用的设置页面查看
            articles	是	图文消息，一个图文消息支持1到8条图文
            title	是	标题，不超过128个字节，超过会自动截断
            description	否	描述，不超过512个字节，超过会自动截断
            url	是	点击后跳转的链接。
            picurl	否	图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640320，小图8080。
            btntxt	否	按钮文字，仅在图文数为1条时才生效。 默认为“阅读全文”， 不超过4个文字，超过自动截断。该设置只在企业微信上生效，微信插件上不生效。
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(Convert.ToString(agentid));
            string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + strToken + "";
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("touser", "\"" + touser + "\"");
            parameters.Add("msgtype", "\"news\"");
            parameters.Add("agentid", "" + agentid + "");
            parameters.Add("news", "" + news + "");
            
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponseWX(PostUrl, parameters, null, null, encoding, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();//return 0 发送成功
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="ID">部门ID</param>
        /// <returns>返回结果</returns>
        public static string getWXdpt()
        {
            #region 获取部门列表 说明
            /*
            获取部门列表
            请求方式：GET（HTTPS）
            请求地址：https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token=ACCESS_TOKEN&id=ID

            参数说明 ：

            参数	必须	说明
            access_token	是	调用接口凭证
            id	否	部门id。获取指定部门及其下的子部门。 如果不填，默认获取全量组织架构
            权限说明：

            系统应用须拥有指定部门的查看权限。

            返回结果：

            {
               "errcode": 0,
               "errmsg": "ok",
               "department": [
                   {
                       "id": 2,
                       "name": "广州研发中心",
                       "parentid": 1,
                       "order": 10
                   },
                   {
                       "id": 3
                       "name": "邮箱产品部",
                       "parentid": 2,
                       "order": 40
                   }
               ]
            }
            参数说明：

            参数	说明
            errcode	返回码
            errmsg	对返回码的文本描述内容
            department	部门列表数据。
            id	创建的部门id
            name	部门名称
            parentid	父亲部门id。根部门为1
            order	在父部门中的次序值。order值大的排序靠前。值范围是[0, 2^32)
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token=" + strToken + "";
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            //return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
            string strs = sr.ReadToEnd().ToString();
            //{"errcode":0,"errmsg":"ok","department":[{"id":1,"name":"大连富成","parentid":0,"order":2147483447},{"id":2,"name":"项目部","parentid":1,"order":2147483447},{"id":3,"name":"实验室","parentid":1,"order":2147483247}]}
            JObject Jo = (JObject)JsonConvert.DeserializeObject(strs);
            JArray Jarows = JArray.Parse(Jo["department"].ToString());
            for (int i = 0; i < Jarows.Count; i++)
            {
                JObject Jorow = (JObject)JsonConvert.DeserializeObject(Jarows[i].ToString());
                string str2=Jorow.Root.Root.ToString();
                string id = Jorow["id"].ToString(); ///id
                string name = Jorow["name"].ToString(); ///名称
                string parentid = Jorow["parentid"].ToString(); //父ID
                string order = Jorow["order"].ToString(); //排序
                string strSQL = string.Format("SELECT * FROM [PT_d_bm] WHERE [i_bmdm]='"+ id + "'");
                DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
                if (dt.Rows.Count == 1)
                {
                    string str1 = string.Format(@"UPDATE [PT_d_bm]
   SET[i_sjdm] = '{1}'
      ,[V_BMMC] = '{2}'
      ,[v_bmqc] = '{3}'
      ,[i_xh] = {4}
      ,[c_sfyx] = 'y'
 WHERE[i_bmdm] = '{0}'", id, parentid, name, name, order);
                    publicDbOpClass.NonQuerySqlString(str1);
                }
                else {
                    string str1 = string.Format(@"INSERT INTO [PT_d_bm]
           ([i_bmdm]
           ,[i_sjdm]
           ,[V_BMMC]
           ,[v_bmqc]
           ,[i_xh]
           ,[c_sfyx]
,[v_bmbm]
,[v_bmjx]
,[i_jb]

)
     VALUES
           ('{0}',{1},'{2}','{3}',{4},'y','{0}','2','2')", id, parentid, name, name, order);
                    publicDbOpClass.NonQuerySqlString(str1);
                }
            }
            return "1";
        }

        /// <summary>
        /// 获取读取成员
        /// </summary>
        /// <param name="ID">部门ID</param>
        /// <returns>返回结果</returns>
        public static string getWXry()
        {
            #region 获取部门成员详情 说明
            /*
               获取部门成员详情
                请求方式：GET（HTTPS）
                请求地址：https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token=ACCESS_TOKEN&department_id=DEPARTMENT_ID&fetch_child=FETCH_CHILD

                参数说明：

                参数	必须	说明
                access_token	是	调用接口凭证
                department_id	是	获取的部门id
                fetch_child	否	1/0：是否递归获取子部门下面的成员
                权限说明：

                系统应用须拥有指定部门的查看权限。

                返回结果：

                {
                    "errcode": 0,
                    "errmsg": "ok",
                    "userlist": [
                        {
                            "userid": "zhangsan",
                            "name": "李四",
                            "department": [1, 2],
                            "order": [1, 2],
                            "position": "后台工程师",
                            "mobile": "15913215421",
                            "gender": "1",
                            "email": "zhangsan@gzdev.com",
                            "isleader": 0,
                            "avatar":           "http://wx.qlogo.cn/mmopen/ajNVdqHZLLA3WJ6DSZUfiakYe37PKnQhBIeOQBO4czqrnZDS79FH5Wm5m4X69TBicnHFlhiafvDwklOpZeXYQQ2icg/0",
                            "telephone": "020-123456",
                            "english_name": "jackzhang",
                            "status": 1,
                            "extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
                        }
                    ]
                }
                参数说明 :

                参数	说明
                errcode	返回码
                errmsg	对返回码的文本描述内容
                userlist	成员列表
                userid	成员UserID。对应管理端的帐号
                name	成员名称
                mobile	手机号码，第三方仅通讯录套件可获取
                department	成员所属部门id列表
                order	部门内的排序值，默认为0。数量必须和department一致，数值越大排序越前面。值范围是[0, 2^32)
                position	职位信息
                gender	性别。0表示未定义，1表示男性，2表示女性
                email	邮箱，第三方仅通讯录套件可获取
                isleader	标示是否为上级。
                avatar	头像url。注：如果要获取小图将url最后的”/0”改成”/100”即可
                telephone	座机。第三方仅通讯录套件可获取
                english_name	英文名。
                status	激活状态: 1=已激活，2=已禁用，4=未激活 已激活代表已激活企业微信或已关注微信插件。未激活代表既未激活企业微信又未关注微信插件。
                extattr	扩展属性，第三方仅通讯录套件可获取
             */
            #endregion
            string strToken = WXAPI.getTokenByAgentId(-1);
            string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token=" + strToken + "&department_id=1&fetch_child=1";
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            //return sr.ReadToEnd().Split(',')[0].Split(':')[1].ToString();
            string strs = sr.ReadToEnd().ToString();
            JObject Jo = (JObject)JsonConvert.DeserializeObject(strs);
            JArray Jarows = JArray.Parse(Jo["userlist"].ToString());
            for (int i = 0; i < Jarows.Count; i++)
            {
                JObject Jorow = (JObject)JsonConvert.DeserializeObject(Jarows[i].ToString());
                string userid = Jorow["userid"].ToString();///成员UserID。对应管理端的帐号
                string name = Jorow["name"].ToString(); ///成员名称
                string department = Jorow["department"].ToString().Replace('[',' ').Replace(']', ' ').Trim();//.ToString();///成员所属部门id列表
                string mobile = Jorow["mobile"].ToString();///手机号码，第三方仅通讯录套件可获取
                string status = Jorow["status"].ToString();///激活状态: 1=已激活，2=已禁用，4=未激活 已激活代表已激活企业微信或已关注微信插件。未激活代表既未激活企业微信又未关注微信插件。
                string departmentID = "";
                try
                {
                    departmentID = department.Split(',')[0].ToString();
                }
                catch
                {
                    departmentID = department;
                }
                string strSQL = string.Format("SELECT * FROM PT_yhmc WHERE v_xm='{0}' and MobilePhoneCode='{1}'", name, mobile);
                DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mobile))
                {
                    if (dt.Rows.Count == 1)
                    {

                        updateUser(userid, status, departmentID, name, dt.Rows[0]["v_yhdm"].ToString());
                    }
                    else
                    {
                        string strSQL2 = string.Format("SELECT * FROM PT_yhmc WHERE v_xm='{0}' and MobilePhoneCode !='{1}'", name, mobile);
                        string strSQL3 = string.Format("SELECT * FROM PT_yhmc WHERE v_xm!='{0}' and MobilePhoneCode ='{1}'", name, mobile);
                        DataTable dt2 = publicDbOpClass.DataTableQuary(strSQL2);
                        DataTable dt3 = publicDbOpClass.DataTableQuary(strSQL3);
                        if (dt2.Rows.Count > 0 || dt3.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            createUser(userid, status, departmentID, mobile, name);
                        }
                    }
                }
            }
            return "1";
        }

        private static void createUser(string userid, string status, string departmentID, string mobile, string name)
        {
            string[] array = PersonnelAction.setUserCode(departmentID);
            string v_yhdm= SqlStringConstructor.GetQuotedString(array[1]);//用户编号
            string strSQL = string.Format("insert into PT_yhmc(v_yhdm,v_xm,i_bmdm,c_sfyx,MobilePhoneCode,State,RTXID,WXID,WXZT) VALUES ({0},'{1}',{2},'y','{3}',1,'{4}','{4}',{5})", 
                v_yhdm, name, departmentID, mobile,userid, status);
            publicDbOpClass.NonQuerySqlString(strSQL);
            string strSQL2 = string.Format("insert into pt_login(V_DLID,V_YHDM,v_DLMM,c_sfyx) VALUES ('{0}',{1},'{2}','y')",
               userid, v_yhdm, "48BB6E862E54F2A795FFC4E541CAED4D");
            publicDbOpClass.NonQuerySqlString(strSQL2);
        }
        private static void updateUser(string userid, string status, string departmentID, string name, string v_yhdm)
        {
            publicDbOpClass.NonQuerySqlString("update PT_yhmc set State=1,c_sfyx='y',i_bmdm = " + departmentID + ",WXZT = " + status + ",WXID = '" + userid + "' where v_yhdm = '" + v_yhdm + "'");
            publicDbOpClass.NonQuerySqlString("update pt_login set V_DLID = '" + userid + "' where V_YHDM = '" + v_yhdm + "'");
        }

        /// <summary>
        /// 微信上传多媒体文件
        /// </summary>
        /// <param name="filepath">文件绝对路径</param>
        //public static string uploadVoice(string  filepath)
        //{
        //    #region 微信 上传临时素材 说明
        //    /*
        //    上传临时素材
        //    请求方式：POST（HTTPS）
        //    请求地址：https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=ACCESS_TOKEN&type=TYPE

        //    使用multipart/form-data POST上传文件， 文件标识名为”media”
        //    参数说明：

        //    参数	必须	说明
        //    access_token	是	调用接口凭证
        //    type	是	媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件（file）
        //    POST的请求包中，form-data中媒体文件标识，应包含有filename、filelength、content-type等信息

        //    权限说明：

        //    完全公开，media_id在同一企业内应用之间可以共享

        //    请求示例：

        //    POST https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=accesstoken001&type=file HTTP/1.1
        //    Content-Type: multipart/form-data; boundary=-------------------------acebdf13572468
        //    Content-Length: 220
        //    ---------------------------acebdf13572468
        //    Content-Disposition: form-data; name="media";filename="wework.txt"; filelength=6
        //    Content-Type: application/octet-stream
        //    mytext
        //    ---------------------------acebdf13572468--
        //    返回数据：

        //    {
        //       "errcode": 0,
        //       "errmsg": ""，
        //       "type": "image",
        //       "media_id": "1G6nrLmr5EC3MMb_-zK1dDdzmd0p7cNliYu9V5w7o8K0",
        //       "created_at": "1380000000"
        //    }
        //    参数说明：

        //    参数	说明
        //    type	媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件(file)
        //    media_id	媒体文件上传后获取的唯一标识，3天内有效
        //    created_at	媒体文件上传时间戳
        //    上传的媒体文件限制

        //    所有文件size必须大于5个字节

        //    图片（image）：2MB，支持JPG,PNG格式
        //    语音（voice） ：2MB，播放长度不超过60s，仅支持AMR格式
        //    视频（video） ：10MB，支持MP4格式
        //    普通文件（file）：20MB
        //    */
        //    #endregion
        //    using (WebClient client = new WebClient())
        //    {
        //        byte[] b = client.UploadFile(string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", WXAPI.getTokenByAgentId(0), "voice"), filepath);//调用接口上传文件
        //        string retdata = Encoding.Default.GetString(b);//获取返回值
        //        if (retdata.Contains("media_id"))//判断返回值是否包含media_id，包含则说明上传成功，然后将返回的json字符串转换成json
        //        {
        //            JObject Jo = (JObject)JsonConvert.DeserializeObject(retdata);
        //            return Jo["media_id"].ToString();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
