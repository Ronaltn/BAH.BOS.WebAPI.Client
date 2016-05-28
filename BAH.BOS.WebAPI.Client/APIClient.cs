using BAH.BOS.WebAPI.Client.AuthServiceOperation;
using BAH.BOS.WebAPI.Client.BusinessServiceOperation;
using BAH.BOS.WebAPI.Client.DynamicFormOperation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API调用客户端。
    /// </summary>
    public class APIClient
    {
        #region 公共属性

        /// <summary>
        /// K/3 Cloud系统的根级URL，
        /// 例如：http://localhost/K3Cloud
        /// </summary>
        public virtual string URL { get; private set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法，将K/3 Cloud系统的根级URL在实例化时传入。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        public APIClient(string url)
        {
            this.URL = url;
        }//end constructor

        #endregion

        #region 公共方法

        #region CreateAPIOperation

        /// <summary>
        /// 根据传入的泛型定义实例化API操作对象。
        /// </summary>
        /// <typeparam name="T">泛型定义，必须继承APIOperation并且可无参实例化。</typeparam>
        /// <returns>返回泛型定义的API操作对象实例。</returns>
        public virtual T CreateAPIOperation<T>() where T : APIOperation, new()
        {
            return CreateAPIOperation<T>(this.URL);
        }//end method

        /// <summary>
        /// 根据传入的泛型定义实例化API操作对象。
        /// </summary>
        /// <typeparam name="T">泛型定义，必须继承APIOperation并且可无参实例化。</typeparam>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回泛型定义的API操作对象实例。</returns>
        public static T CreateAPIOperation<T>(string url) where T : APIOperation, new()
        {
            return new T().SetRootUrl<T>(url);
        }//end method

        #endregion

        #region AuthServiceOperation

        #region Login

        /// <summary>
        /// 执行验证用户操作，
        /// 其他操作执行之前需要先调用该方法来取得认证。
        /// </summary>
        /// <returns>返回验证用户操作实例对象。</returns>
        public Login Login()
        {
            return Login(this.URL);
        }//end method

        /// <summary>
        /// 执行验证用户操作，
        /// 其他操作执行之前需要先调用该方法来取得认证。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回验证用户操作实例对象。</returns>
        public static Login Login(string url)
        {
            return CreateAPIOperation<Login>(url);
        }//end method

        #endregion

        #endregion

        #region DynamicFormOperation

        #region ExecuteFormOperation

        /// <summary>
        /// 执行表单操作。
        /// </summary>
        /// <returns>返回执行操作实例对象。</returns>
        public ExecuteFormOperation ExecuteFormOperation()
        {
            return ExecuteFormOperation(this.URL);
        }//end method

        /// <summary>
        /// 执行表单操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行操作实例对象。</returns>
        public static ExecuteFormOperation ExecuteFormOperation(string url)
        {
            return CreateAPIOperation<ExecuteFormOperation>(url);
        }//end method

        #endregion

        #region Save

        /// <summary>
        /// 执行表单保存操作。
        /// </summary>
        /// <returns>返回执行保存操作实例对象。</returns>
        public Save Save()
        {
            return Save(this.URL);
        }//end method

        /// <summary>
        /// 执行表单保存操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行保存操作实例对象。</returns>
        public static Save Save(string url)
        {
            return CreateAPIOperation<Save>(url);
        }//end method

        #endregion

        #region View

        /// <summary>
        /// 执行表单查看操作。
        /// </summary>
        /// <returns>返回执行查看操作实例对象。</returns>
        public View View()
        {
            return View(this.URL);
        }//end method

        /// <summary>
        /// 执行表单查看操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行查看操作实例对象。</returns>
        public static View View(string url)
        {
            return CreateAPIOperation<View>(url);
        }//end method

        #endregion

        #region Delete

        /// <summary>
        /// 执行表单删除操作。
        /// </summary>
        /// <returns>返回执行删除操作实例对象。</returns>
        public Delete Delete()
        {
            return Delete(this.URL);
        }//end method

        /// <summary>
        /// 执行表单删除操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行删除操作实例对象。</returns>
        public static Delete Delete(string url)
        {
            return CreateAPIOperation<Delete>(url);
        }//end method

        #endregion

        #region Submit

        /// <summary>
        /// 执行表单提交操作。
        /// </summary>
        /// <returns>返回执行提交操作实例对象。</returns>
        public Submit Submit()
        {
            return Submit(this.URL);
        }//end method

        /// <summary>
        /// 执行表单提交操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行提交操作实例对象。</returns>
        public static Submit Submit(string url)
        {
            return CreateAPIOperation<Submit>(url);
        }//end method

        #endregion

        #region Audit

        /// <summary>
        /// 执行表单审核操作。
        /// </summary>
        /// <returns>返回执行审核操作实例对象。</returns>
        public Audit Audit()
        {
            return Audit(this.URL);
        }//end method

        /// <summary>
        /// 执行表单审核操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行审核操作实例对象。</returns>
        public static Audit Audit(string url)
        {
            return CreateAPIOperation<Audit>(url);
        }//end method 

        #endregion

        #region UnAudit

        /// <summary>
        /// 执行表单反审核操作。
        /// </summary>
        /// <returns>返回执行审核操作实例对象。</returns>
        public UnAudit UnAudit()
        {
            return UnAudit(this.URL);
        }//end method

        /// <summary>
        /// 执行表单反审核操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行反审核操作实例对象。</returns>
        public static UnAudit UnAudit(string url)
        {
            return CreateAPIOperation<UnAudit>(url);
        }//end method 

        #endregion

        #region BillInvalid

        /// <summary>
        /// 执行单据作废操作。
        /// </summary>
        /// <returns>返回执行作废操作实例对象。</returns>
        public BillInvalid BillInvalid()
        {
            return BillInvalid(this.URL);
        }//end method

        /// <summary>
        /// 执行单据作废操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行作废操作实例对象。</returns>
        public static BillInvalid BillInvalid(string url)
        {
            return CreateAPIOperation<BillInvalid>(url);
        }//end method 

        #endregion

        #region BDForbid

        /// <summary>
        /// 执行基础资料禁用操作。
        /// </summary>
        /// <returns>返回执行禁用操作实例对象。</returns>
        public BDForbid BDForbid()
        {
            return BDForbid(this.URL);
        }//end method

        /// <summary>
        /// 执行基础资料禁用操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行禁用操作实例对象。</returns>
        public static BDForbid BDForbid(string url)
        {
            return CreateAPIOperation<BDForbid>(url);
        }//end method 

        #endregion

        #region BDEnable

        /// <summary>
        /// 执行基础资料禁反禁用操作。
        /// </summary>
        /// <returns>返回执行反禁用操作实例对象。</returns>
        public BDEnable BDEnable()
        {
            return BDEnable(this.URL);
        }//end method

        /// <summary>
        /// 执行基础资料禁反禁用操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行反禁用操作实例对象。</returns>
        public static BDEnable BDEnable(string url)
        {
            return CreateAPIOperation<BDEnable>(url);
        }//end method 

        #endregion

        #endregion

        #region BusinessServiceOperation

        /// <summary>
        /// 执行不依赖于表单的服务操作。
        /// </summary>
        /// <returns>返回执行不依赖于表单的服务操作实例对象。</returns>
        public ExecuteServiceOperation ExecuteServiceOperation()
        {
            return ExecuteServiceOperation(this.URL);
        }//end method

        /// <summary>
        /// 执行不依赖于表单的服务操作。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回执行不依赖于表单的服务操作实例对象。</returns>
        public static ExecuteServiceOperation ExecuteServiceOperation(string url)
        {
            return CreateAPIOperation<ExecuteServiceOperation>(url);
        }//end method

        #endregion

        #endregion

    }//end class
}//end method
