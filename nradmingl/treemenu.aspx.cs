﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class nradmingl_treemenu : System.Web.UI.Page
{
    #region 功能模块说明及页面基本信息说明
    //所属模块：开发演示
    //任务名称：验证权限显示左侧导航菜单 
    //完成功能描述：验证用户是否登陆,并根据权限显示菜单功能
    //编写人：张明
    //创建日期：2016年11月29日
    //更新日期：2016年11月29日
    //版本记录：第一版
    #endregion
    #region 页面初始化参数
    private string xwdith = "1366";//屏宽
    private string xheight = "768";//屏高
    private string pagelm1 = "菜单显示";//请与系统栏目管理中栏目关键字设置为一致便于权限管理

    private string pageqx1 = "浏览";//权限名称，根据页面的权限控制命名，与栏目管理中权限一致，最大设置为５个
    private string pageqx2 = "";
    private string pageqx3 = "";
    private string pageqx4 = "";
    private string pageqx5 = "";
    private string webpage = "";//当前页面值，在加载时会自动获取
    private string btitle = "";//附属标题
    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 页面基本配置及标题标识
        btitle = pagelm1;
        try
        {
            //读取cookies中的当前网址信息,如果没有使用服务器获取
            if (Request.Cookies["xurl"] != null)
            {
                HttpCookie cookiesurl = Request.Cookies["xurl"];
                webpage = cookiesurl.Value.ToString().Replace("%3A", ":").Replace("%3F", "?").Replace("%3D", "=").Replace("%26", "&");
            }
            else
            {
                webpage = Request.Url.GetLeftPart(UriPartial.Query).ToString().Replace(Request.Url.Port.ToString(), Sqlhelper.serverport);
            }

        }
        catch (Exception e1) { Response.Write(e1.Message); }

        

        #endregion
        #region 当前页浏览权限验证
        new c_login().tongyiyz(webpage, pagelm1, pageqx1, "进入" + pagelm1 + "页", true, pageqx1, pageqx2, pageqx3, pageqx4, pageqx5);
        //默认如权限１，若单独验证某个权限，如下方式
        //new c_login().powerYanzheng(Session["username"].ToString(), pagelm1, pageqx2, "2");//验证当前栏目关键字中的权限２,通常在按钮中需验证权限时使用
        #endregion
        //左部菜单
        string sc = "";
        string sqlSerachByDhcdh = "SELECT * FROM lanm WHERE (sfcdxs=1 and sfdhxs=1) and fid='-1' order by px asc";
        DataTable dt = Sqlhelper.Serach(sqlSerachByDhcdh);
        string url = "";
        if (dt.Rows.Count > 0)
        {
            //{"title": "基本元素","icon": "fa-cubes","spread": true,"children": [{"title": "按钮","icon": "&#xe641;","href": "button.html"}
            sc = "[";
            string isone = "0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //判断是否有权限
                string qxok = "0";
                if (Session["UserName"] != null)
                {
                    if (new c_login().powerYanzheng(Session["UserName"].ToString(), dt.Rows[i]["gjz"].ToString(), "浏览", "2"))
                    {
                        qxok = "1";
                        //Response.Write(Session["UserName"].ToString() + dt.Rows[i]["gjz"].ToString() + "有权限");
                    }
                }
                if (qxok == "1")
                {
                    url = dt.Rows[i]["url"].ToString();
                    string sqlSerachByDhcdh2 = "SELECT * FROM lanm WHERE (sfcdxs=1 or sfdhxs=1) and fid='" + dt.Rows[i]["lmid"].ToString() + "' order by px asc";
                    DataTable dt2 = Sqlhelper.Serach(sqlSerachByDhcdh2);

                    if (dt2.Rows.Count > 0)
                    {
                        #region 二级栏目
                        //Response.Write(sqlSerachByDhcdh2);
                        //展示二级栏目　

                        if (isone == "0")
                        {
                            if (qxok == "1")
                            {
                                sc += "{\"title\": \"" + dt.Rows[i]["lmmc"].ToString() + "\",\"icon\": \"" + dt.Rows[i]["lmfont"].ToString() + "\",\"spread\": true,\"children\": [";
                                isone = "1";
                            }
                        }
                        else
                        {
                            if (qxok == "1")
                            {
                                sc += ",{\"title\": \"" + dt.Rows[i]["lmmc"].ToString() + "\",\"icon\": \"" + dt.Rows[i]["lmfont"].ToString() + "\",\"spread\": false,\"children\": [";
                            }
                        }



                        string isone2 = "0";
                        #region 展示第三级
                        for (int c = 0; c < dt2.Rows.Count; c++)
                        {
                            //展示第三级








                            string qxok2 = "0";


                            if (Session["UserName"] != null)
                            {
                                if (new c_login().powerYanzheng(Session["UserName"].ToString(), dt2.Rows[c]["gjz"].ToString(), "浏览", "2"))
                                {
                                    qxok2 = "1";
                                }
                            }
                            url = dt2.Rows[c]["url"].ToString();

                            if (isone2 == "0")
                            {
                                if (qxok2 == "1")
                                {
                                    sc += "{\"title\": \"" + dt2.Rows[c]["lmmc"].ToString() + "\",\"icon\": \"" + dt2.Rows[c]["lmfont"].ToString() + "\",\"href\": \"" + url + "\" }";
                                    isone2 = "1";
                                }
                                // Response.Write("<br>" + isone2 + "$");
                            }
                            else
                            {
                                if (qxok2 == "1")
                                {
                                    sc += ",{\"title\": \"" + dt2.Rows[c]["lmmc"].ToString() + "\",\"icon\": \"" + dt2.Rows[c]["lmfont"].ToString() + "\",\"href\": \"" + url + "\" }";
                                }
                                //Response.Write("<br>" + isone2 + "@");

                            }

                            qxok2 = "0";

                        }
                        #endregion

                        #endregion
                        if (qxok == "1")
                        {
                            sc += "]}";
                        }
                    }
                    else
                    {
                        //无二级栏目

                        if (i == 0)
                        {
                            sc += "{\"title\": \"" + dt.Rows[i]["lmmc"].ToString() + "\",\"icon\": \"" + dt.Rows[i]["lmfont"].ToString() + "\",\"spread\": false,\"href\": \"" + url + "\" }";
                        }
                        else
                        {
                            sc += ",{\"title\": \"" + dt.Rows[i]["lmmc"].ToString() + "\",\"icon\": \"" + dt.Rows[i]["lmfont"].ToString() + "\",\"spread\":false,\"href\": \"" + url + "\" }";
                        }


                    }
                }
                
                qxok = "0";
                // Response.Write("{\"title\": \"基本元素\",\"icon\": \"fa-cubes\",\"spread\": true,\"children\": ");


            }


            sc+="]";
        }
        else
        {
            sc="[]";
        }
        //sc = sc.Replace("}]}]", "}]");
        //if (sc.Contains("@"))
        //{

        //    sc = sc.Replace(" ", "").Replace("}{", "}@");
        //    sc = sc.Split('@')[0] + "]}]";
        //}
        //if (sc.Contains("mymd5.aspx"))
        //{
        //    sc=sc.Replace("mymd5.aspx","@");
            
        //    sc = sc.Split('@')[0] + "\" }]}]";
        //}
        
        Response.Write(sc);
    }
}