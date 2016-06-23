using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    /// <summary>
    /// 单元测试过程中使用的参数。
    /// </summary>
    /// <remarks>
    /// 所有参数均以演示数据中心为基准。
    /// </remarks>
    public class UnitTestParameter
    {
        public virtual string URL
        {
            //ipv4.fiddler地址是针对Fidder捕获本机http请求所设置的特殊地址，
            //相关知识:http://stackoverflow.com/questions/826134/how-to-display-localhost-traffic-in-fiddler-while-debugging-an-asp-net-applicati
            //若没有使用Fidder捕获需求可替换为localhost。
            get { return "http://ipv4.fiddler/K3Cloud"; }
        }//end property

        /// <summary>
        /// 数据中心主键。
        /// </summary>
        public virtual string DBId
        {
            //主键获取通过查询管理中心T_BAS_DATACENTER_L表获得。
            //SELECT * FROM T_BAS_DATACENTER_L
            get { return "5756387562288f"; }
        }//end property

        /// <summary>
        /// 用户名。
        /// </summary>
        public virtual string UserName
        {
            get { return "00001"; }
        }//end property

        /// <summary>
        /// 用户密码。
        /// </summary>
        public virtual string Password
        {
            get { return "888888"; }
        }//end property

    }//end class
}//end namespace
