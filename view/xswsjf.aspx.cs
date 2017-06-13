﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class view_xswsjf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //设置链接
        //查看详情链接
        string xh = "";
        //验证是否传递学号
        if (Session["username"] != null)
        {

            xh = Session["username"].ToString();



           
            #region 获取操作状态
            //基本状态
            //写法未完成
            //<font color=red>未完成</font>  
            //写法已完成
            //<font color=green>已完成</font>
            this.xszt_jf1.InnerHtml = "<font color=red>未完成</font>";//缴费项目确认  
            this.xszt_jf2.InnerHtml = "<font color=red>未完成</font>";//网上缴费
           

            //详细情况
            this.xsztxq_jf1.InnerHtml = "";//缴费项目确认  
            this.xsztxq_jf2.InnerHtml = "";//网上缴费

            batch batch_logic = new batch();
            List<fresh_affair> affairlst_stu = batch_logic.get_freshstudent_affair_list(xh);//学生事务            

            if (affairlst_stu != null)
            {
                for (int j = 0; affairlst_stu != null && j < affairlst_stu.Count; j++)
                {
                    List<fresh_affair_log> affairlog_list = null;//事务日志列表
                    if (affairlst_stu[j].Affair_Index == 6)//缴费项目确认
                    {
                        this.xscz_jf1.HRef = "xsbjf.aspx?pk_affair_no=" + affairlst_stu[j].PK_Affair_NO.ToString().Trim() + "&pk_sno=" + Session["username"].ToString();//缴费项目选择

                        affairlog_list = batch_logic.get_student_affair_affairlog_list(xh, affairlst_stu[j].PK_Affair_NO);
                        if (affairlog_list != null && !affairlog_list[0].Log_Status.Trim().Equals("未确认"))
                        {
                            this.xszt_jf1.InnerHtml = affairlog_list[0].Log_Status.Trim();//缴费项目确认
                        }
                    }
                    if (affairlst_stu[j].Affair_Index == 9)//网上缴费
                    {
                        this.xscz_jf2.HRef = "xsbjf_order.aspx?pk_affair_no=" + affairlst_stu[j].PK_Affair_NO.ToString().Trim() + "&pk_sno=" + Session["username"].ToString();//确认网上缴费

                        affairlog_list = batch_logic.get_student_affair_affairlog_list(xh, affairlst_stu[j].PK_Affair_NO);
                        if (affairlog_list != null && !affairlog_list[0].Log_Status.Trim().Equals("未确认"))
                        {
                            this.xszt_jf2.InnerHtml = affairlog_list[0].Log_Status.Trim();//网上缴费
                        }
                    }
                }
            }            


            #endregion
        }
        else
        {
            Response.Write("<script>top.location.href='/login.aspx?sf=xs'</script>");
        }
    }
}