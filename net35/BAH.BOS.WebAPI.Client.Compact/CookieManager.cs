using System;
using System.Collections.Generic;
using System.Linq;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// Cookie管理器，CE平台自定义的解决方案。
    /// </summary>
    public static class CookieManager
    {
        #region 私有域

        /// <summary>
        /// 存储Cookie的字典对象。
        /// </summary>
        private static Dictionary<string, string> _cookieDict = new Dictionary<string, string>();

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取Cookie。
        /// </summary>
        /// <param name="url">URL地址。</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            string key = GenerateKey(url);
            if (_cookieDict.Keys.Contains(key))
            {
                return _cookieDict[key];
            }
            else
            {
                return string.Empty;
            }
        }//end method

        /// <summary>
        /// 保存Cookie。
        /// </summary>
        /// <param name="url">URL地址。</param>
        /// <param name="cookie">Cookie信息。</param>
        public static void Save(string url, string cookie)
        {
            string key = GenerateKey(url);

            if (_cookieDict.Keys.Contains(key))
            {
                _cookieDict[key] = cookie;
            }
            else
            {
                _cookieDict.Add(key, cookie);
            }//end if else

        }//end method

        /// <summary>
        /// 移除Cookie。
        /// </summary>
        /// <param name="url">URL地址。</param>
        public static void Remove(string url)
        {
            string key = GenerateKey(url);
            if (_cookieDict.Keys.Contains(key))
            {
                _cookieDict.Remove(key);
            }//end if
        }//end method

        /// <summary>
        /// 清空Cookie。
        /// </summary>
        public static void Clear()
        {
            _cookieDict.Clear();
        }//end method

        #endregion

        #region 私有方法

        /// <summary>
        /// 生成访问字段的键。
        /// </summary>
        /// <param name="url">URL地址。</param>
        /// <returns>返回访问字典的键。</returns>
        private static string GenerateKey(string url)
        {
            return url;
        }//end method

        #endregion

    }//end class
}//end namespace
