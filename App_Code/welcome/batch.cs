﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Data.SqlClient;



/// 动态调用web服务 
public class WSHelper
{
    /// < summary>           
    /// 动态调用web服务         
    /// < /summary>          
    /// < param name="url">WSDL服务地址< /param> 
    /// < param name="methodname">方法名< /param>           
    /// < param name="args">参数< /param>           
    /// < returns>< /returns>          
    public static object InvokeWebService(string url, string methodname, object[] args)
    {
        return WSHelper.InvokeWebService(url, null, methodname, args);
    }
    /// < summary>          
    /// 动态调用web服务 
    /// < /summary>          
    /// < param name="url">WSDL服务地址< /param>
    /// < param name="classname">类名< /param>  
    /// < param name="methodname">方法名< /param>  
    /// < param name="args">参数< /param> 
    /// < returns>< /returns>
    public static object InvokeWebService(string url, string classname, string methodname, object[] args)
    {
        string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
        if ((classname == null) || (classname == ""))
        {
            classname = WSHelper.GetWsClassName(url);
        }
        try
        {                   //获取WSDL   
            WebClient wc = new WebClient();
            Stream stream = wc.OpenRead(url + "?WSDL");
            ServiceDescription sd = ServiceDescription.Read(stream);
            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
            sdi.AddServiceDescription(sd, "", "");
            CodeNamespace cn = new CodeNamespace(@namespace);
            //生成客户端代理类代码          
            CodeCompileUnit ccu = new CodeCompileUnit();
            ccu.Namespaces.Add(cn);
            sdi.Import(cn, ccu);
            CSharpCodeProvider icc = new CSharpCodeProvider();
            //设定编译参数                 
            CompilerParameters cplist = new CompilerParameters();
            cplist.GenerateExecutable = false;
            cplist.GenerateInMemory = true;
            cplist.ReferencedAssemblies.Add("System.dll");
            cplist.ReferencedAssemblies.Add("System.XML.dll");
            cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
            cplist.ReferencedAssemblies.Add("System.Data.dll");
            //编译代理类                 
            CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
            if (true == cr.Errors.HasErrors)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                {
                    sb.Append(ce.ToString());
                    sb.Append(System.Environment.NewLine);
                }
                throw new Exception(sb.ToString());
            }
            //生成代理实例，并调用方法   
            System.Reflection.Assembly assembly = cr.CompiledAssembly;
            Type t = assembly.GetType(@namespace + "." + classname, true, true);
            object obj = Activator.CreateInstance(t);
            System.Reflection.MethodInfo mi = t.GetMethod(methodname);
            return mi.Invoke(obj, args);
            // PropertyInfo propertyInfo = type.GetProperty(propertyname);     
            //return propertyInfo.GetValue(obj, null); 
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
        }
    }
    private static string GetWsClassName(string wsUrl)
    {
        string[] parts = wsUrl.Split('/');
        string[] pps = parts[parts.Length - 1].Split('.');
        return pps[0];
    }
}


/// <summary>
///名称：迎新批次
///作者：胡元
/// </summary>
public class fresh_batch{
    public string PK_Batch_NO;//迎新批次编号
    public string Batch_Name;//迎新批次名称
    public string Year;//迎新年
    public string STU_Type;//迎新学生类型
    public DateTime Welcome_Begin;//迎新办理开始时间
    public DateTime Welcome_End;//迎新办理结束时间
    public DateTime Service_Begin;//迎新服务开始时间
    public DateTime Service_End;//迎新服务结束时间
    public string Enabled;//迎新服务启停标志
}

/// <summary>
/// 名称：迎新事务
/// 作者：胡元
/// </summary>
public class fresh_affair
{
    public string PK_Affair_NO;//迎新事务编号
    public string FK_Batch_NO;//迎新批次编号
    public int Affair_Index;//自编序号 
    public string Affair_Name;//事务名称
    public string Affair_Type;//事务类型
    public string Precondition1;//使能条件1
    public string Precondition2;//使能条件2
    public string Call_Function;//返回迎新事务状态调用函数
    public string Affair_CHAR;//事务性质
    public string FK_OPER_NO;//与事务绑定的操作编号
    public string Parameters;//其他操作参数
}

/// <summary>
/// 名称：迎新操作
/// 作者：胡元
/// </summary>
public class fresh_oper
{
    public string PK_OPER_NO;//操作编号
    public string OPER_Name;//操作名称
    public string OPER_URL;//操作URL地址
    public string OPER_Type;//操作类型
}

/// <summary>
/// 名称：学生基本信息
/// 作者：胡元
/// </summary>
public class base_stu
{
    public string PK_SNO;//学号

}

/// <summary>
/// 名称：学生迎新事务
/// 作者：胡元
/// </summary>
public class fresh_affair_log
{
    public string PK_Affair_Log;//学生迎新事务主键
    public string FK_SNO;//学号
    public string FK_Affair_NO;//迎新事务编号
    public string Log_Status;//事务状态
    public string Creater;//创建者
    public DateTime Create_DT;//创建时间
    public string Updater;//更新者
    public DateTime Update_DT;//更新时间
}

/// <summary>
///迎新批次服务类说明
/// </summary>
public class batch
{
   
    /// <summary>
    ///功能名称：获取当前有效迎新批次目录
    ///功能描述：
    ///返回当前时间介于“迎新服务开始时间”和“迎新服务结束时间”之间，并且“启停服务标志”为“run”的迎新批次数据集合。否则返回null。
    ///编写人：胡元
    ///创建时间：2017-1-17
    ///更新记录：无
    ///版本记录：v0.0.1
    /// </summary>
    /// <returns></returns>
    public List<fresh_batch> get_freshbatch_list()
    {
        List<fresh_batch> result = null;
        try {
            string sqlstr = "select * from fresh_batch where Service_Begin<getdate() and Service_End>getdate() and UPPER(Enabled)='RUN'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr);
            if (dt != null && dt.Rows.Count > 0)
            {
                result = new List<fresh_batch>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fresh_batch row = new fresh_batch();
                    row.Batch_Name = dt.Rows[i]["Batch_Name"].ToString().Trim();
                    row.Enabled = dt.Rows[i]["Enabled"].ToString().Trim();
                    row.PK_Batch_NO = dt.Rows[i]["PK_Batch_NO"].ToString().Trim();
                    row.Service_Begin =DateTime.Parse(dt.Rows[i]["Service_Begin"].ToString());
                    row.Service_End = DateTime.Parse(dt.Rows[i]["Service_End"].ToString());
                    row.STU_Type = dt.Rows[i]["STU_Type"].ToString().Trim();
                    row.Welcome_Begin = DateTime.Parse(dt.Rows[i]["Welcome_Begin"].ToString());
                    row.Welcome_End = DateTime.Parse(dt.Rows[i]["Welcome_End"].ToString());
                    row.Year = dt.Rows[i]["Year"].ToString().Trim();
                    result.Add(row);
                }
            }
        }
        catch (Exception ex)
        {
            try{
                new c_log().logAdd("batch.cs", "get_freshbatch_list", ex.Message, "2", "huyuan");//记录错误日志
            }catch { }
            throw ex;
        }
        return result;
    }

    /// <summary>
    ///功能名称：获取某迎新批次
    ///功能描述：
    ///根据“迎新批次编号”返回迎新批次数据。否则返回null。
    ///参数：
    ///PK_Batch_NO：迎新批次编号
    ///编写人：胡元
    ///创建时间：2017-1-17
    ///更新记录：无
    ///版本记录：v0.0.1
    /// </summary>
    /// <returns></returns>
    public fresh_batch get_freshbatch(string PK_Batch_NO)
    {
        fresh_batch result = null;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0)
            {
                return result;
            }
            PK_Batch_NO = PK_Batch_NO.Trim();

            string sqlstr = "select * from fresh_batch where PK_Batch_NO=@pa" ;
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr,new SqlParameter("pa", PK_Batch_NO.Trim()));
            if (dt != null && dt.Rows.Count ==1)
            {
                int i = 0;
                result = new fresh_batch();
                result.Batch_Name = dt.Rows[i]["Batch_Name"].ToString().Trim();
                result.Enabled = dt.Rows[i]["Enabled"].ToString().Trim();
                result.PK_Batch_NO = dt.Rows[i]["PK_Batch_NO"].ToString().Trim();
                result.Service_Begin = DateTime.Parse(dt.Rows[i]["Service_Begin"].ToString());
                result.Service_End = DateTime.Parse(dt.Rows[i]["Service_End"].ToString());
                result.STU_Type = dt.Rows[i]["STU_Type"].ToString().Trim();
                result.Welcome_Begin = DateTime.Parse(dt.Rows[i]["Welcome_Begin"].ToString());
                result.Welcome_End = DateTime.Parse(dt.Rows[i]["Welcome_End"].ToString());
                result.Year = dt.Rows[i]["Year"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            try{
                new c_log().logAdd("batch.cs", "get_freshbatch", ex.Message, "2", "huyuan");//记录错误日志
            }catch { }
            throw ex;
        }
        return result;
    }

    /// <summary>
    ///功能名称：获取某迎新批次是否有效
    ///功能描述：
    ///根据“迎新批次编号”查询“启停服务标志”为“启动”并且当前时间在“迎新服务开始时间”和“迎新服务结束时间”之间的记录，找到返回true。否则返回false。    
    ///参数：
    ///PK_Batch_NO：迎新批次编号
    /// 编写人：胡元
    ///创建时间：2017-1-17
    ///更新记录：无
    ///版本记录：v0.0.1
    /// </summary>
    /// <returns></returns>
    public bool get_freshbatch_isrun(string PK_Batch_NO)
    {
        bool result = false;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0)
            {
                return result;
            }
            PK_Batch_NO = PK_Batch_NO.Trim();

            string sqlstr = "select * from fresh_batch where  PK_Batch_NO=@pa and Service_Begin<getdate() and Service_End>getdate() and UPPER(Enabled)='RUN'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("pa", PK_Batch_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                result = true;
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshbatch_isrun", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    /// <summary>
    ///功能名称：获取操作员在某批次是否有效
    ///功能描述：
    ///查找“员工编号”在“批次编号”的迎新批次中是否被分配了权限，没有则返回false。
    ///否则检查该用户在该批次的“禁止操作标志”，等于true则返回false。
    ///否则继续检查是否被分配了相应的“迎新事务操作”项目，存在被分配的“迎新事务操作”返回true。否则返回false。    
    ///编写人：胡元
    ///参数：
    ///PK_Batch_NO：迎新批次编号；PK_Staff_NO：员工编号   
    ///创建时间：2017-1-18
    ///更新记录：无
    ///版本记录：v0.0.1
    /// </summary>
    /// <returns></returns>
    public bool get_freshoperator_isauth(string PK_Batch_NO, string PK_Staff_NO)
    {
        bool result = false;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0 || PK_Staff_NO == null || PK_Staff_NO.Trim().Length == 0)
            {
                return result;
            }
            string sqlstr = "select * from Fresh_Operator_AUTH where  FK_Fresh_Batch=@cs1 and FK_Staff_NO=@cs2 and UPPER(Enabled)='ENABLED'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                sqlstr = "select count(*) as sl from Fresh_Operator_AUTH a,Fresh_Affair_AUTH b,Fresh_Affair c " +
                " where a.PK_Operator_AUTH=b.FK_Operator_AUTH and b.FK_Affair_NO=c.PK_Affair_NO and UPPER(a.Enabled)='ENABLED' "+
                "and a.FK_Staff_NO=@cs2 and a.FK_Fresh_Batch=@cs1";
                dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
                if (int.Parse(dt.Rows[0]["sl"].ToString())>0)
                {
                    result = true;
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshoperator_isauth", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    /// <summary>
    ///功能名称：获取操作员事务操作列表
    ///功能描述：
    ///根据“批次编号”查询“员工编号”在该批次中“禁止操作标志”为false，并且被授权“迎新事务”的“事务性质”为“交互性”，
    ///“事务类型”为“现场”或“两者”的数据。否则返回null。  
    ///编写人：胡元
    ///参数：
    ///PK_Batch_NO：迎新批次编号；PK_Staff_NO：员工编号   
    ///创建时间：2017-1-30
    ///更新记录：无
    ///版本记录：v0.0.1
    /// </summary>
    /// <returns></returns>
    public List<fresh_affair> get_freshoperator_auth_affair_list(string PK_Batch_NO, string PK_Staff_NO)
    {
        List<fresh_affair> result = null;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0 || PK_Staff_NO == null || PK_Staff_NO.Trim().Length == 0)
            {
                return null;
            }
            string sqlstr = "select * from Fresh_Operator_AUTH where  FK_Fresh_Batch=@cs1 and FK_Staff_NO=@cs2 and UPPER(Enabled)='ENABLED'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                sqlstr = "select c.* from Fresh_Operator_AUTH a,Fresh_Affair_AUTH b,Fresh_Affair c " +
                " where a.PK_Operator_AUTH=b.FK_Operator_AUTH and b.FK_Affair_NO=c.PK_Affair_NO and UPPER(a.Enabled)='ENABLED' " +
                "and a.FK_Staff_NO=@cs2 and a.FK_Fresh_Batch=@cs1 "+
                " and upper(c.Affair_CHAR)='INTERACTIVE' and (upper(c.Affair_Type)='SCHOOL' OR upper(c.Affair_Type)='BOTH')";
                dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
                if (dt != null && dt.Rows.Count>0)
                {
                    result = new List<fresh_affair>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        fresh_affair row = new fresh_affair();
                        row.PK_Affair_NO = dt.Rows[i]["PK_Affair_NO"].ToString().Trim();//迎新事务编号
                        row.FK_Batch_NO = dt.Rows[i]["FK_Batch_NO"].ToString().Trim();//迎新批次编号
                        row.Affair_Index = int.Parse(dt.Rows[i]["Affair_Index"] is DBNull?"0":dt.Rows[i]["Affair_Index"].ToString());//自编序号 
                        row.Affair_Name = dt.Rows[i]["Affair_Name"].ToString().Trim();//事务名称
                        row.Affair_Type = dt.Rows[i]["Affair_Type"].ToString().Trim();//事务类型
                        row.Precondition1 = dt.Rows[i]["Precondition1"].ToString().Trim();//使能条件1
                        row.Precondition2 = dt.Rows[i]["Precondition2"].ToString().Trim();//使能条件2
                        row.Call_Function = dt.Rows[i]["Call_Function"].ToString().Trim();//返回迎新事务状态调用函数
                        row.Affair_CHAR = dt.Rows[i]["Affair_CHAR"].ToString().Trim();//事务性质
                        row.FK_OPER_NO = dt.Rows[i]["FK_OPER_NO"].ToString().Trim();//与事务绑定的操作编号
                        row.Parameters = dt.Rows[i]["Parameters"].ToString().Trim();//其他操作参数
                        result.Add(row);
                    }                
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshoperator_auth_list", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    /// <summary>
    ///功能名称：获取预操作总人数
    ///功能描述：
    ///返回 “员工编号”在被授权的批次中“事务编号”中可操作的总的学生数量减去该员工已成功完成的学生数量。
    ///编写人：胡元
    ///参数：
    ///PK_Batch_NO：迎新批次编号；PK_Staff_NO：员工编号；PK_Affair_NO：迎新事务编号   
    ///创建时间：2017-1-30
    ///更新记录：无
    ///版本记录：v0.0.1
    public int get_freshoperator_will_affair_students_count(string PK_Batch_NO, string PK_Staff_NO, string PK_Affair_NO)
    {
        int result = -1;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0 || PK_Staff_NO == null || PK_Staff_NO.Trim().Length == 0 || PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0)
            {
                return -1;
            }
            string sqlstr = "select * from Fresh_Operator_AUTH where  FK_Fresh_Batch=@cs1 and FK_Staff_NO=@cs2 and UPPER(Enabled)='ENABLED'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                sqlstr = "select count(*) as sl from vw_fresh_student_base where FK_Fresh_Batch+'_'+SPE_Code+'_'+[year] in ( "+
                            "select distinct(FK_Batch_NO+'_'+SPE_Code+'_'+[year]) from vw_operator_scope "+
                            "where FK_Batch_NO=@cs1 and FK_Staff_NO=@cs2 and PK_Affair_NO=@cs3)" +
                            "and PK_SNO not in (select distinct(FK_SNO) from Fresh_Affair_Log where FK_Affair_NO=@cs3)";
                dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()), new SqlParameter("cs3", PK_Affair_NO.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = int.Parse(dt.Rows[0]["sl"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshoperator_will_students_count", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }

    /// <summary>
    ///功能名称：获取已完成操作总人数
    ///功能描述：
    ///返回 “员工编号”在被授权的批次中“事务编号”中已成功完成的学生数量。
    ///编写人：胡元
    ///参数：
    ///PK_Batch_NO：迎新批次编号；PK_Staff_NO：员工编号；PK_Affair_NO：迎新事务编号   
    ///创建时间：2017-1-30
    ///更新记录：无
    ///版本记录：v0.0.1
    public int get_freshoperator_finish_affair_students_count(string PK_Batch_NO, string PK_Staff_NO, string PK_Affair_NO)
    {
        int result = -1;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0 || PK_Staff_NO == null || PK_Staff_NO.Trim().Length == 0 || PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0)
            {
                return -1;
            }
            string sqlstr = "select * from Fresh_Operator_AUTH where  FK_Fresh_Batch=@cs1 and FK_Staff_NO=@cs2 and UPPER(Enabled)='ENABLED'";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                sqlstr = "select count(*) as sl from vw_fresh_student_base where FK_Fresh_Batch+'_'+SPE_Code+'_'+[year] in ( " +
                            "select distinct(FK_Batch_NO+'_'+SPE_Code+'_'+[year]) from vw_operator_scope " +
                            "where FK_Batch_NO=@cs1 and FK_Staff_NO=@cs2 and PK_Affair_NO=@cs3)" +
                            "and PK_SNO in (select distinct(FK_SNO) from Fresh_Affair_Log where FK_Affair_NO=@cs3)";
                dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_Staff_NO.Trim()), new SqlParameter("cs3", PK_Affair_NO.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = int.Parse(dt.Rows[0]["sl"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshoperator_finish_students_count", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }

    /// <summary>
    ///功能名称： 获取某迎新事务
    ///功能描述：
    ///返回“事务编号”对应的事务数据。否则返回null。
    ///编写人：胡元
    ///参数：
    ///PK_Affair_NO：迎新事务编号   
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public fresh_affair get_affair(string PK_Affair_NO)
    {
        fresh_affair result = null;
        try
        {
            if (PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0)
            {
                return null;
            }
            string sqlstr = "select * from Fresh_Affair where  PK_Affair_NO=@cs1 ";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Affair_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                int i = 0;
                result = new fresh_affair();
                result.PK_Affair_NO = dt.Rows[i]["PK_Affair_NO"].ToString().Trim();//迎新事务编号
                result.FK_Batch_NO = dt.Rows[i]["FK_Batch_NO"].ToString().Trim();//迎新批次编号
                result.Affair_Index = int.Parse(dt.Rows[i]["Affair_Index"] is DBNull ? "0" : dt.Rows[i]["Affair_Index"].ToString());//自编序号 
                result.Affair_Name = dt.Rows[i]["Affair_Name"].ToString().Trim();//事务名称
                result.Affair_Type = dt.Rows[i]["Affair_Type"].ToString().Trim();//事务类型
                result.Precondition1 = dt.Rows[i]["Precondition1"].ToString().Trim();//使能条件1
                result.Precondition2 = dt.Rows[i]["Precondition2"].ToString().Trim();//使能条件2
                result.Call_Function = dt.Rows[i]["Call_Function"].ToString().Trim();//返回迎新事务状态调用函数
                result.Affair_CHAR = dt.Rows[i]["Affair_CHAR"].ToString().Trim();//事务性质
                result.FK_OPER_NO = dt.Rows[i]["FK_OPER_NO"].ToString().Trim();//与事务绑定的操作编号
                result.Parameters = dt.Rows[i]["Parameters"].ToString().Trim();//其他操作参数
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_affair", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }

    /// <summary>
    ///功能名称： 校验学生迎新批次
    ///功能描述：
    ///如果“学号”对应学生的“批次编号”等于参数“批次编号”返回true，否则返回false。
    ///编写人：胡元
    ///参数：
    ///PK_Batch_NO：迎新批次编号；PK_SNO：学号   
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public bool check_student_in_freshbatch(string PK_Batch_NO, string PK_SNO)
    {
        bool result =false;
        try
        {
            if (PK_Batch_NO == null || PK_Batch_NO.Trim().Length == 0 || PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return result;
            }
            string sqlstr = "select * from vw_fresh_student_base where FK_Fresh_Batch=@cs1 and PK_SNO=@cs2";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                result = true;
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "check_student_in_freshbatch", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    /// <summary>
    ///功能名称： 校验操作员操作对象
    ///功能描述：
    ///如果：操作员在某批次是否有效(批次编号,员工编号)==false，则返回false，否则根据“员工编号”检查被授权的“事务编号”，
    ///根据该操作员在该事务编号上被授权的“可操作院系”检查“学号”对应学生是否被包含其中，包含则返回true，否则返回false。
    ///编写人：胡元
    ///参数：
    ///PK_Staff_NO：迎新操作员编号；PK_Affair_NO：迎新事务编号；PK_SNO：学号   
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public bool check_operator_object(string PK_Staff_NO,string PK_Affair_NO, string PK_SNO)
    {
        bool result = false;
        try
        {
            if (PK_Staff_NO == null || PK_Staff_NO.Trim().Length == 0 || PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0 || PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return result;
            }
            string sqlstr = "select * from vw_fresh_student_base where FK_Fresh_Batch+'_'+SPE_Code+'_'+[year] in ( "+
                            " select distinct(FK_Batch_NO+'_'+SPE_Code+'_'+[year]) from vw_operator_scope "+
                            " where FK_Staff_NO=@cs1 and PK_Affair_NO=@cs2)and PK_SNO=@cs3";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Staff_NO.Trim()), new SqlParameter("cs2", PK_Affair_NO.Trim()), new SqlParameter("cs3", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                result = true;
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "check_operator_object", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 获取某迎新事务操作
    ///功能描述：
    ///根据“事务编号”查找返回绑定的“操作定义”，否则返回null。
    ///编写人：胡元
    ///参数：
    ///PK_Affair_NO：迎新事务编号  
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public fresh_oper get_oper(string PK_Affair_NO)
    {
        fresh_oper result = null;
        try
        {
            if (PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0)
            {
                return null;
            }
            string sqlstr = "select b.* from Fresh_Affair a,Fresh_OPER b where a.FK_OPER_NO=b.PK_OPER_NO and PK_Affair_NO=@cs1";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Affair_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                int i = 0;
                result = new fresh_oper();
                result.PK_OPER_NO = dt.Rows[i]["PK_OPER_NO"].ToString().Trim();//操作编号
                result.OPER_Name = dt.Rows[i]["OPER_Name"].ToString().Trim();//操作名称
                result.OPER_URL = dt.Rows[i]["OPER_URL"].ToString().Trim();//地址 
                result.OPER_Type = dt.Rows[i]["OPER_Type"].ToString().Trim();//操作类型
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_oper", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 获取学生事务操作列表
    ///功能描述：
    ///根据“学号”查询所在批次中被授权“迎新事务”的“事务性质”为“交互性”，
    ///“事务类型”为“学生”或“两者”的数据。否则返回null。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号  
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public List<fresh_affair> get_freshstudent_affair_list(string PK_SNO)
    {
        List<fresh_affair> result = null;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return null;
            }
            
            string sqlstr = "select c.* from vw_fresh_student_base a,Fresh_Batch b,Fresh_Affair c "+
                            " where a.FK_Fresh_Batch=b.PK_Batch_NO and c.FK_Batch_NO=b.PK_Batch_NO "+
                            " and  a.PK_SNO=@cs1 and upper(c.Affair_CHAR)='INTERACTIVE' and (upper(c.Affair_Type)='STUDENT' or upper(c.Affair_Type)='BOTH')";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count>0)
            {
                result = new List<fresh_affair>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    fresh_affair row = new fresh_affair();
                    row.PK_Affair_NO = dt.Rows[i]["PK_Affair_NO"].ToString().Trim();//迎新事务编号
                    row.FK_Batch_NO = dt.Rows[i]["FK_Batch_NO"].ToString().Trim();//迎新批次编号
                    row.Affair_Index = int.Parse(dt.Rows[i]["Affair_Index"] is DBNull ? "0" : dt.Rows[i]["Affair_Index"].ToString());//自编序号 
                    row.Affair_Name = dt.Rows[i]["Affair_Name"].ToString().Trim();//事务名称
                    row.Affair_Type = dt.Rows[i]["Affair_Type"].ToString().Trim();//事务类型
                    row.Precondition1 = dt.Rows[i]["Precondition1"].ToString().Trim();//使能条件1
                    row.Precondition2 = dt.Rows[i]["Precondition2"].ToString().Trim();//使能条件2
                    row.Call_Function = dt.Rows[i]["Call_Function"].ToString().Trim();//返回迎新事务状态调用函数
                    row.Affair_CHAR = dt.Rows[i]["Affair_CHAR"].ToString().Trim();//事务性质
                    row.FK_OPER_NO = dt.Rows[i]["FK_OPER_NO"].ToString().Trim();//与事务绑定的操作编号
                    row.Parameters = dt.Rows[i]["Parameters"].ToString().Trim();//其他操作参数
                    result.Add(row);
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_freshstudent_affair_list", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 学生现场报到
    ///功能描述：
    ///根据“学号”修改“学生基本状态”为“报到”。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号  
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public bool set_freshstudent_register(string PK_SNO)
    {
        bool result = false;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return false;
            }

            string sqlstr = "select * from vw_fresh_student_base where PK_SNO=@cs1";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count ==1)
            {
                sqlstr = "update Base_STU set Status_Code='已报到' where PK_SNO=@cs1";
                int jg=Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()));
                if (jg == 1){
                    result = true;
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "set_freshstudent_register", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 获取某学生现场迎新事务列表
    ///功能描述：
    ///1、	根据“学号”查找该学生所有“事务类型”为“现场”或“两者”的“学生迎新事务”列表，列表为空返回null。否则第2步。
    ///2、	扫描“学生迎新事务”列表中的每一项。
    ///3、	如果扫描项中的“迎新事务状态”等于“完成”，则扫描下一项。否则检查该项对应的“迎新事务定义”中的“返回迎新事务状态调用函数”（该函数返回“完成”、“未完成”、“开始”之一）是否为空，如果为空则扫描下一项，否则调用“返回迎新事务状态调用函数”并将调用值赋值给“迎新事务状态”并保持到数据库中，然后扫描下一项。
    ///4、	返回“学生迎新事务”列表。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号  
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public List<fresh_affair_log> get_schoolaffairlog_list(string PK_SNO)
    {
        List<fresh_affair_log> result = null;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return null;
            }

            string sqlstr = "select d.PK_Affair_Log,a.PK_SNO as FK_SNO,c.PK_Affair_NO as FK_Affair_NO,"+
                            "(case when d.Log_Status='已完成' or d.Log_Status=NULL then '已完成' else '未完成' end) as Log_Status,"+
                            "d.Creater,d.Create_DT,d.Updater,d.Update_DT,c.Call_Function" +
                            " from vw_fresh_student_base a,Fresh_Batch b,"+
                            "Fresh_Affair c LEFT JOIN Fresh_Affair_Log d on c.PK_Affair_NO=d.FK_Affair_NO "+
                            " where a.FK_Fresh_Batch=b.PK_Batch_NO and c.FK_Batch_NO=b.PK_Batch_NO"+ 
                            " and  a.PK_SNO=@cs1 and upper(c.Affair_CHAR)='INTERACTIVE' and (upper(c.Affair_Type)='SCHOOL' or upper(c.Affair_Type)='BOTH')";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count > 0)
            {
                result = new List<fresh_affair_log>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fresh_affair_log row = new fresh_affair_log();
                    row.PK_Affair_Log = dt.Rows[i]["PK_Affair_Log"].ToString().Trim();//学生迎新事务主键
                    row.FK_SNO = dt.Rows[i]["FK_SNO"].ToString().Trim();//学号
                    row.FK_Affair_NO =dt.Rows[i]["FK_Affair_NO"].ToString().Trim();//迎新事务编号 
                    row.Log_Status = dt.Rows[i]["Log_Status"].ToString().Trim();//事务状态
                    row.Creater = dt.Rows[i]["Creater"].ToString().Trim();//创建者
                    row.Create_DT = dt.Rows[i]["Create_DT"] is DBNull?DateTime.Now:DateTime.Parse(dt.Rows[i]["Create_DT"].ToString());//创建时间
                    row.Updater = dt.Rows[i]["Updater"].ToString().Trim();//更新者
                    row.Update_DT = dt.Rows[i]["Update_DT"] is DBNull ? DateTime.Now : DateTime.Parse(dt.Rows[i]["Update_DT"].ToString());//更新时间

                    if (dt.Rows[i]["Log_Status"].ToString().Trim() == "未完成" && dt.Rows[i]["Call_Function"] != null && dt.Rows[i]["Call_Function"].ToString().Trim().Length!=0)
                    {
                        /*Call_Function格式，web服务器url地址?方法名称，例如：http://localhost:3893/test/WebService.asmx?test_Log_Status*/
                        string url = dt.Rows[i]["Call_Function"].ToString().Trim();
                        string[] parts = url.Split('?');
                        if (parts.Length != 2)
                        {
                            throw new Exception("Call_Function format error");
                        }

                        url = parts[0];
                        string method = parts[1];
                        string[] args = new string[1];
                        args[0] = row.FK_SNO;
                        object data = WSHelper.InvokeWebService(url, method, args);
                        string jg = data.ToString().Trim();
                        row.Log_Status = jg.Trim();

                        if (row.PK_Affair_Log != null && row.PK_Affair_Log.Trim().Length!=0 && jg.Trim() == "已完成")
                        {
                            sqlstr = "update Fresh_Affair_Log set Log_Status='已完成',Updater='system',Update_DT=getdate() where FK_SNO=@cs1 and FK_Affair_NO=@cs2";
                            Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", row.FK_Affair_NO.Trim()));
                        }else
                            if ((row.PK_Affair_Log == null || row.PK_Affair_Log.Trim().Length == 0) && jg.Trim() == "已完成")
                            {
                                sqlstr = "insert into Fresh_Affair_Log (PK_Affair_Log,FK_SNO,FK_Affair_NO,Log_Status,Creater,Create_DT,Updater,Update_DT) values ("+
                                        "  newid(),@cs1,@cs2,'已完成','system',getdate(),'system',getdate())";
                                Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", row.FK_Affair_NO.Trim()));
                            }
                        
                    }
                    result.Add(row);
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_schoolaffairlog_list", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }

    ///功能名称： 获取某学生自助迎新事务列表
    ///功能描述：
    ///1、	根据“学号”查找该学生所有“事务类型”为“学生”或“两者”的“学生迎新事务”列表，列表为空返回null。否则第2步。
    ///2、	扫描“学生迎新事务”列表中的每一项。
    ///3、	如果扫描项中的“迎新事务状态”等于“完成”，则扫描下一项。否则检查该项对应的“迎新事务定义”中的“返回迎新事务状态调用函数”（该函数返回“完成”、“未完成”、“开始”之一）是否为空，如果为空则扫描下一项，否则调用“返回迎新事务状态调用函数”并将调用值赋值给“迎新事务状态”并保持到数据库中，然后扫描下一项。
    ///4、	返回“学生迎新事务”列表。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号  
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public List<fresh_affair_log> get_studentaffairlog_list(string PK_SNO)
    {
        List<fresh_affair_log> result = null;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0)
            {
                return null;
            }

            string sqlstr = "select d.PK_Affair_Log,a.PK_SNO as FK_SNO,c.PK_Affair_NO as FK_Affair_NO," +
                            "(case when d.Log_Status='已完成' or d.Log_Status=NULL then '已完成' else '未完成' end) as Log_Status," +
                            "d.Creater,d.Create_DT,d.Updater,d.Update_DT,c.Call_Function" +
                            " from vw_fresh_student_base a,Fresh_Batch b," +
                            "Fresh_Affair c LEFT JOIN Fresh_Affair_Log d on c.PK_Affair_NO=d.FK_Affair_NO " +
                            " where a.FK_Fresh_Batch=b.PK_Batch_NO and c.FK_Batch_NO=b.PK_Batch_NO" +
                            " and  a.PK_SNO=@cs1 and upper(c.Affair_CHAR)='INTERACTIVE' and (upper(c.Affair_Type)='STUDENT' or upper(c.Affair_Type)='BOTH')";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()));
            if (dt != null && dt.Rows.Count > 0)
            {
                result = new List<fresh_affair_log>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fresh_affair_log row = new fresh_affair_log();
                    row.PK_Affair_Log = dt.Rows[i]["PK_Affair_Log"].ToString().Trim();//学生迎新事务主键
                    row.FK_SNO = dt.Rows[i]["FK_SNO"].ToString().Trim();//学号
                    row.FK_Affair_NO = dt.Rows[i]["FK_Affair_NO"].ToString().Trim();//迎新事务编号 
                    row.Log_Status = dt.Rows[i]["Log_Status"].ToString().Trim();//事务状态
                    row.Creater = dt.Rows[i]["Creater"].ToString().Trim();//创建者
                    row.Create_DT = dt.Rows[i]["Create_DT"] is DBNull ? DateTime.Now : DateTime.Parse(dt.Rows[i]["Create_DT"].ToString());//创建时间
                    row.Updater = dt.Rows[i]["Updater"].ToString().Trim();//更新者
                    row.Update_DT = dt.Rows[i]["Update_DT"] is DBNull ? DateTime.Now : DateTime.Parse(dt.Rows[i]["Update_DT"].ToString());//更新时间

                    if (dt.Rows[i]["Log_Status"].ToString().Trim() == "未完成" && dt.Rows[i]["Call_Function"] != null && dt.Rows[i]["Call_Function"].ToString().Trim().Length != 0)
                    {
                        string url = dt.Rows[i]["Call_Function"].ToString().Trim();
                        string[] parts = url.Split('?');
                        if (parts.Length != 2)
                        {
                            throw new Exception("Call_Function format error");
                        }
                        url = parts[0];
                        string method = parts[1];
                        string[] args = new string[1];
                        args[0] = row.FK_SNO;
                        object data = WSHelper.InvokeWebService(url, method, args);//动态调用webservice格式的回调函数
                        string jg = data.ToString().Trim();
                        row.Log_Status = jg.Trim();

                        if (row.PK_Affair_Log != null && row.PK_Affair_Log.Trim().Length != 0 && jg.Trim() == "已完成")
                        {
                            sqlstr = "update Fresh_Affair_Log set Log_Status='已完成',Updater='system',Update_DT=getdate() where FK_SNO=@cs1 and FK_Affair_NO=@cs2";
                            Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", row.FK_Affair_NO.Trim()));
                        }
                        else
                            if ((row.PK_Affair_Log == null || row.PK_Affair_Log.Trim().Length == 0) && jg.Trim() == "已完成")
                            {
                                sqlstr = "insert into Fresh_Affair_Log (PK_Affair_Log,FK_SNO,FK_Affair_NO,Log_Status,Creater,Create_DT,Updater,Update_DT) values (" +
                                        "  newid(),@cs1,@cs2,'已完成','system',getdate(),'system',getdate())";
                                Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", row.FK_Affair_NO.Trim()));
                            }

                    }
                    result.Add(row);
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "get_studentaffairlog_list", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 更新学生迎新事务状态
    ///功能描述：
    ///如果该“学号”所在迎新批次的“事务编号”没有对应的“学生迎新事务”记录，则创建记录，
    ///将对应记录的“迎新事务状态”标记为“事务状态”。。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号；PK_Affair_NO：事务编号；Log_Status：事务状态；Creater：操作者姓名
    ///创建时间：2017-1-31
    ///更新记录：无
    ///版本记录：v0.0.1
    public bool set_affairlog(string PK_SNO, string PK_Affair_NO, string Log_Status, string Creater)
    {
        bool result = false;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0 || PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0
                || Log_Status == null || Log_Status.Trim().Length == 0 || Creater == null || Creater.Trim().Length == 0)
            {
                return result;
            }

            if (Log_Status.Trim() != "未完成" && Log_Status.Trim() != "已完成")
            {
                return result;
            }

            string sqlstr = "select * from Fresh_Affair_Log where FK_SNO=@cs1 and FK_Affair_NO=@cs2";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", PK_Affair_NO.Trim()));
            if (dt != null && dt.Rows.Count ==1)
            {
                sqlstr = "update Fresh_Affair_Log set Log_Status=@cs3,Updater=@cs4,Update_DT=getdate() where FK_SNO=@cs1 and FK_Affair_NO=@cs2 ";
                int jg=Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", PK_Affair_NO.Trim()),
                    new SqlParameter("cs3", Log_Status.Trim()), new SqlParameter("cs4", Creater.Trim()));
                if (jg == 1)
                {
                    result = true;
                }
            }else
                if (dt == null || dt.Rows.Count == 0)
                {
                    sqlstr = "insert into Fresh_Affair_Log (PK_Affair_Log,FK_SNO,FK_Affair_NO,Log_Status,Creater,Create_DT,Updater,Update_DT) values (" +
                            "  newid(),@cs1,@cs2,@cs3,@cs4,getdate(),@cs4,getdate())";
                    int jg = Sqlhelper.ExcuteNonQuery(sqlstr, new SqlParameter("cs1", PK_SNO.Trim()), new SqlParameter("cs2", PK_Affair_NO.Trim()),
                        new SqlParameter("cs3", Log_Status.Trim()), new SqlParameter("cs4", Creater.Trim()));
                    if (jg == 1)
                    {
                        result = true;
                    }
                }
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "set_affairlog", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }


    ///功能名称： 校验学生事务操作条件
    ///功能描述：
    ///根据“事务编号”获取“使能条件1”（前置迎新事务状态条件表达式）和“使能条件2”（前置迎新事务应收款的付款状态条件表达式），
    ///并将“学号”对应学生的状态应用到“使能条件”中，都满足返回true，否则返回false。
    ///编写人：胡元
    ///参数：
    ///PK_SNO：学号；PK_Affair_NO：事务编号；PK_SNO：学号
    ///创建时间：2017-2-1
    ///更新记录：无
    ///版本记录：v0.0.1
    public bool check_student_affair_condition(string PK_SNO, string PK_Affair_NO)
    {
        bool result = false;
        try
        {
            if (PK_SNO == null || PK_SNO.Trim().Length == 0 || PK_Affair_NO == null || PK_Affair_NO.Trim().Length == 0)
            {
                return result;
            }

            string sqlstr = "select * from Fresh_Affair where PK_Affair_NO=@cs1";
            System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Affair_NO.Trim()));
            if (dt != null && dt.Rows.Count == 1)
            {
                string PK_Batch_NO=dt.Rows[0]["FK_Batch_NO"].ToString().Trim();
                if (dt.Rows[0]["Precondition1"] != null && dt.Rows[0]["Precondition1"] != System.DBNull.Value && dt.Rows[0]["Precondition1"].ToString().Trim().Length > 0)
                {
                    string status_condition = dt.Rows[0]["Precondition1"].ToString().Trim();//事务状态条件
                    result=analysis_status_condition(status_condition, PK_Batch_NO, PK_SNO);//前置条件解析
                }else
                {
                    result = true;//没有前置条件，返回真
                }
                //前置收费条件解析，还未完成
            }
            else
                throw new Exception("invalid PK_Affair_NO");
        }
        catch (Exception ex)
        {
            try
            {
                new c_log().logAdd("batch.cs", "check_student_affair_condition", ex.Message, "2", "huyuan");//记录错误日志
            }
            catch { }
            throw ex;
        }
        return result;
    }

    //前置事务状态条件解析
    private bool analysis_status_condition(string status_condition, string PK_Batch_NO, string PK_SNO)
    {
        //status_condition的格式是：{@a1=已完成 and @a2=未完成}:{@a1,@a2}
        //a1中的a是必须的关键字符，a1中的1是迎新事务的索引号(一个迎新批次中的事务索引号唯一)。常量只能是"已完成"和"未完成"两种。
        string sqlstr = "";
        bool result = false;
        string[] arr = status_condition.Split(':');

        if (arr.Length != 2)
            throw new Exception("status_condition format error");

        arr[0] = arr[0].Substring(1, arr[0].Length - 2);
        string express = arr[0];

        arr[1] = arr[1].Substring(1, arr[1].Length - 2);
        if (arr[1].Trim().Length > 0)
        {
            List<fresh_affair_log> data1 = get_studentaffairlog_list(PK_SNO);
            List<fresh_affair_log> data2 = get_schoolaffairlog_list(PK_SNO);
            List<fresh_affair_log> affairlog = new List<fresh_affair_log>();//学生事务日志
            if (data1 != null && data1.Count > 0)
            {
                for (int i = 0; i < data1.Count; i++)
                {
                    affairlog.Add(data1[i]);
                }
            }
            if (data2 != null && data2.Count > 0)
            {
                if (affairlog.Count == 0)
                {
                    for (int i = 0; i < data2.Count; i++)
                    {
                        affairlog.Add(data2[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < data2.Count; i++)
                    {
                        bool havesame = false;
                        for (int j = 0; j < affairlog.Count; j++)
                        {
                            if (affairlog[j].FK_Affair_NO.Trim() == data2[i].FK_Affair_NO.Trim())
                            {
                                havesame = true;
                                break;
                            }
                        }
                        if (!havesame)
                        {
                            affairlog.Add(data2[i]);
                        }
                    }
                }
            }

            string[] parameters = arr[1].Split(',');

            for (int i = 0; i < parameters.Length; i++)
            {
                string index = parameters[i].Substring(2);
                sqlstr = "select PK_Affair_NO from Fresh_Affair where FK_Batch_NO=@cs1 and Affair_Index=@cs2";
                System.Data.DataTable dt = Sqlhelper.Serach(sqlstr, new SqlParameter("cs1", PK_Batch_NO.Trim()), new SqlParameter("cs2", index.Trim()));
                if (dt != null && dt.Rows.Count == 1)
                {
                    string PK_Affair_NO = dt.Rows[0]["PK_Affair_NO"].ToString().Trim();
                    for (int j = 0; j < affairlog.Count; j++)
                    {
                        if (affairlog[j].FK_Affair_NO.Trim() == PK_Affair_NO.Trim())
                        {
                            express = express.Replace(parameters[i], affairlog[j].Log_Status.Trim());
                            break;
                        }
                    }
                }
            }
            express = express.Replace("已完成","\'已完成\'");
            express = express.Replace("未完成", "\'未完成\'");
        }

        sqlstr = "select isnull((select 1  where " + express.Trim() + " ),0) as flag";
        System.Data.DataTable jg = Sqlhelper.Serach(sqlstr);
        if (jg.Rows[0]["flag"].ToString().Trim() == "1")
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    //前置收费条件解析
    private bool analysis_fee_condition(string fee_condition, string PK_Batch_NO, string PK_SNO)
    {
        ///fee_condition的格式是：{@f1=@fs1 and @f2>0}:{@f1=001,@f2=003}
        ///f1中的f是必须的关键字符，f1中的1是任意整数，@f1=001，f1代表'收费款项编号'(Fee_No)为'001'的学生
        ///实际缴费数,fs1代表'收费款项编号'(Fee_No)为'001'的收费标准。
        ///
        string sqlstr = "";
        bool result = false;
        string[] arr = fee_condition.Split(':');

        if (arr.Length != 2)
            throw new Exception("fee_condition format error");

        arr[0] = arr[0].Substring(1, arr[0].Length - 2);
        string express = arr[0];//表达式

        arr[1] = arr[1].Substring(1, arr[1].Length - 2);
        if (arr[1].Trim().Length > 0)
        {
            string[] arr1 = arr[1].Split(',');//参数变量数组
            List<string> parameter_list= new List<string>();//参数变量列表
            List<string> fee_no_list = new List<string>();//参数对应的财务收费编号列表

            for (int i = 0; i < arr1.Length; i++)
            {
                string[] arr2 = arr1[i].Trim().Split('=');
                parameter_list.Add(arr2[0]);//参数变量
                fee_no_list.Add(arr2[1]);//参数变量对应的财务收费编号
            }

            for (int i = 0; i < parameter_list.Count; i++)
            {
                //获取学生收费条目实收金额 ssje= getssje(xh,fee_no_list[i])
                //获取学生收费条目收费标准金额 bzje= getbzje(xh,fee_no_list[i])
                //替换实收金额 express = express.Replace(parameter_list[i], ssje);
                //替换收费标准金额
                //string[] arr3 = parameter_list[i].Split(',')
                //string fs=arr3[0]+"s"+arr3[1];
                //express = express.Replace(fs, ssje);
            }

        }

        sqlstr = "select isnull((select 1  where " + express.Trim() + " ),0) as flag";
        System.Data.DataTable jg = Sqlhelper.Serach(sqlstr);
        if (jg.Rows[0]["flag"].ToString().Trim() == "1")
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

}