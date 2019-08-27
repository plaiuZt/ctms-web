using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Common.Utility
{
    using CTMS.Common.Json;
    /// <summary>
    /// 
    /// </summary>
    public partial class Utility
    {
        /// <summary>
        /// 验证JSON字符串格式是否法
        /// </summary>
        /// <param name="str">JSON字符串</param>
        /// <returns></returns>
        public static bool IsJson(string str)
        {
            try
            {
                Newtonsoft.Json.Linq.JObject.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 验证JSON节点是否存在
        /// </summary>
        /// <param name="jsonStr">JSON字符串</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static bool IsJsonNodeName(string jsonStr, string nodeName)
        {
            try
            {
                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(jsonStr);
                if (jo.Property(nodeName) == null || jo.Property(nodeName).ToString() == "")
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// JSON字符串转字典类型
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> JsonToSortedDictionary(string jsonString)
        {
            try
            {
                string str = jsonString;
                SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
                var jo = Newtonsoft.Json.Linq.JObject.Parse(str);
                foreach (Newtonsoft.Json.Linq.JToken child in jo.Children())
                {
                    var property = child as Newtonsoft.Json.Linq.JProperty;
                    var keyType = property.Value.Type;
                    string keyName = property.Name.ToString().Trim();
                    string keyValue = string.Empty;
                    switch (keyType)
                    {
                        case Newtonsoft.Json.Linq.JTokenType.Object:
                        case Newtonsoft.Json.Linq.JTokenType.Array:
                            keyValue = property.Value.ToJson().Trim();
                            break;
                        case Newtonsoft.Json.Linq.JTokenType.Boolean:
                            keyValue = property.Value.ToString().Trim().ToLower();
                            break;
                        case Newtonsoft.Json.Linq.JTokenType.Null:
                            keyValue = string.Empty;
                            break;
                        default:
                            keyValue = property.Value.ToString().Trim();
                            break;
                    }
                    sParams.Add(keyName, keyValue);
                }
                return sParams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
