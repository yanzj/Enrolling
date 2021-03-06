﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class wblue_serch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //显示菜单
        if (Request["word"] != null)
        {
            lmmc2.InnerHtml = "搜索'" + Request["word"].ToString() + "'的结果";
        }

        #region 网站标题标识
        DataTable wangzxx = Sqlhelper.Serach("SELECT TOP 100 *  FROM [wangzxx] order by xxid asc");
        if (wangzxx.Rows.Count > 0)
        {
            for (int i = 0; i < wangzxx.Rows.Count; i++)
            {
                //网站开关
                if (wangzxx.Rows[i]["xxgjz"].ToString() == "isopen")
                {
                    if (wangzxx.Rows[i]["xxnr"].ToString() == "0")
                    {
                        this.Title = "网站正在维护，请稍后再访问！";
                        Response.Write("<font color=red>网站正在维护，请稍后再访问</font>");
                        Response.End();
                    }
                }
                //网站标题及META
                if (wangzxx.Rows[i]["xxgjz"].ToString() == "title") this.Title = wangzxx.Rows[i]["xxnr"].ToString();
                if (wangzxx.Rows[i]["xxgjz"].ToString() == "MetaKeywords") this.MetaKeywords = wangzxx.Rows[i]["xxnr"].ToString();
                if (wangzxx.Rows[i]["xxgjz"].ToString() == "description") this.MetaDescription = wangzxx.Rows[i]["xxnr"].ToString();
                //底部版权
                if (wangzxx.Rows[i]["xxgjz"].ToString() == "copyright") this.downlx.InnerHtml = wangzxx.Rows[i]["xxnr"].ToString();
                //BANNER



            }
        }
        #endregion
        DataTable menus = Sqlhelper.Serach("SELECT TOP 8 *  FROM [xw_lanm] where (sfcdxs='1' or sfdhxs='1') and fid='-1' order by px");
        if (menus.Rows.Count > 0)
        {
            menushow.InnerHtml = "";
            for (int i = 0; i < menus.Rows.Count; i++)
            {
                string lmmc = basic.ReplaceHtmlTag(menus.Rows[i]["lmmc"].ToString(), 20);
                string urlok = "list.aspx?id=" + menus.Rows[i]["lmid"].ToString();
                if (menus.Rows[i]["url"].ToString().Length > 4) urlok = menus.Rows[i]["url"].ToString();
                menushow.InnerHtml += "<li class=\"nav-item i" + (i + 1).ToString() + "\"><a href=\"" + urlok + "\" target=\"" + menus.Rows[i]["dkfs"].ToString() + "\" class=\"\"><span class=\"item-name\">" + lmmc + "</span></a><i class=\"mark\"></i>";
                //menushow.InnerHtml += "<li class=\"expanded\"> <a title=\"" + lmmc + "\" target=\"" + menus.Rows[i]["dkfs"].ToString() + "\" href=\"" + menus.Rows[i]["url"].ToString() + "\">" + lmmc + "</a>";


                //字菜单
                DataTable zmenus = Sqlhelper.Serach("SELECT TOP 8 *  FROM [xw_lanm] where (sfcdxs='1' or sfdhxs='1') and fid='" + menus.Rows[i]["lmid"].ToString() + "' order by px");
                if (zmenus.Rows.Count > 0)
                {
                    menushow.InnerHtml += "<ul class=\"sub-nav\" style=\"width: 0px; height: 0px; top: 46px; left: 0px; visibility: hidden;\">";
                    for (int o = 0; o < zmenus.Rows.Count; o++)
                    {
                        lmmc = basic.ReplaceHtmlTag(zmenus.Rows[o]["lmmc"].ToString(), 20);
                        urlok = "list.aspx?id=" + zmenus.Rows[o]["lmid"].ToString();
                        if (zmenus.Rows[o]["url"].ToString().Length > 4) urlok = zmenus.Rows[o]["url"].ToString();
                        menushow.InnerHtml += " <li class=\"nav-item i" + (i + 1).ToString() + "-" + (o + 1).ToString() + " \" style=\"display: block; width: 100%;\"><a href=\"" + urlok + "\" target=\"" + zmenus.Rows[o]["dkfs"].ToString() + "\" style=\"display: block; width: auto;\"><span class=\"item-name\">" + lmmc + "</span></a><i class=\"mark\"></i></li>";
                        // menushow.InnerHtml += "<li class=\"leaf\"><a title=\"" + lmmc + "\" target=\"" + zmenus.Rows[o]["dkfs"].ToString() + "\" href=\"" + zmenus.Rows[o]["url"].ToString() + "\">" + lmmc + "</a></li>";

                    }
                    menushow.InnerHtml += "</ul>";
                }
                menushow.InnerHtml += "</li>";
            }
        }
        //设置底部导航
        DataTable downdh = Sqlhelper.Serach("SELECT TOP 10 *  FROM [xw_lanm] where  sfdown='1' order by px");
        if (downdh.Rows.Count > 0)
        {
            downshow.InnerHtml = "";
            for (int i = 0; i < downdh.Rows.Count; i++)
            {
                string urlok = "list.aspx?id=" + downdh.Rows[i]["lmid"].ToString();
                if (downdh.Rows[i]["url"].ToString().Length > 4) urlok = downdh.Rows[i]["url"].ToString();
                if (i == 0)
                {
                    downshow.InnerHtml += "<li class=\"first leaf\"><a title=\"\" href=\"" + urlok + "\">" + downdh.Rows[i]["lmmc"].ToString() + "</a></li>";
                }
                else if (i == downdh.Rows.Count - 1)
                {
                    downshow.InnerHtml += "<li class=\"leaf\"><a title=\"\" href=\"" + urlok + "\">" + downdh.Rows[i]["lmmc"].ToString() + "</a></li>";

                }
                else
                {
                    downshow.InnerHtml += "<li class=\"last leaf\"><a title=\"\" href=\"" + urlok + "\">" + downdh.Rows[i]["lmmc"].ToString() + "</a></li>";

                }
            }
            // <li class="first leaf"><a title="" href="#">学生</a></li>
        }
        else
        {
            downshow.InnerHtml = "";
        }
        //设置底部联系方式
        DataTable downlx1 = Sqlhelper.Serach("SELECT TOP 1 *  FROM [wangzxx] where xxgjz='downlx'");
        if (downlx1.Rows.Count > 0)
        {
            downlx.InnerHtml = downlx1.Rows[0]["xxnr"].ToString();
        }

        this.lmmc.InnerHtml = "新闻搜索";
        wp_content_w89_0.Style.Add("display", "none");
        wp_content_w89_1.Style.Add("display", "");

        if (Request["id"] != null)
        {
            DataTable lanms = Sqlhelper.Serach("SELECT TOP 1 *  FROM [xw_lanm] where lmid=@lmid order by px",new SqlParameter("lmid", Request["id"].ToString()));
            if (lanms.Rows.Count > 0)
            {
                //读取新闻内容
                if (lanms.Rows[0]["lx"].ToString() == "列表")
                {
                    //列表显示
                    //wp_content_w89_0.InnerHtml = "<div class=\"title\">列表显示！</div>";
                    wp_content_w89_0.Style.Add("display", "none");
                    wp_content_w89_1.Style.Add("display", "");


                }
                if (lanms.Rows[0]["lx"].ToString() == "介绍")
                {
                    wp_content_w89_1.Style.Add("display", "none");
                    wp_content_w89_0.Style.Add("display", "");
                    //介绍显示wp_content_w89_0
                    DataTable xws = Sqlhelper.Serach("SELECT TOP 1 *  FROM [xw_neirong] where isyn=1 and LMID=@lmid order by fabutime desc", new SqlParameter("lmid", Request["id"].ToString()));
                    if (xws.Rows.Count > 0)
                    {
                        wp_content_w89_0.InnerHtml = "<p style=\"text-align:justify;text-indent:37px;font:12px/28px simsun;letter-spacing:normal;color:#4b4b4b;word-spacing:0px;font-size-adjust:none;font-stretch:normal;-webkit-text-stroke-width:0px\">" + xws.Rows[0]["Content"].ToString() + "</p>";
                    }
                    else
                    {
                        wp_content_w89_0.InnerHtml = "<div class=\"title\">该栏目管理员正在维护更新，请过段时间再访问！</div>";
                    }
                }


                //根目录

                if (lanms.Rows[0]["fid"].ToString() == "-1")
                {
                    //显示栏目名称
                    this.lmmc.InnerHtml = lanms.Rows[0]["lmmc"].ToString();
                    this.lmmc2.InnerHtml = lanms.Rows[0]["lmmc"].ToString();
                    string urlok = "list.aspx?id=" + lanms.Rows[0]["lmid"].ToString();
                    if (lanms.Rows[0]["url"].ToString().Length > 4) urlok = lanms.Rows[0]["url"].ToString();
                    this.lmdh.InnerHtml = "<span class=\"path-name\">当前位置：</span><a href=\"/\" target=\"_self\">首页</a><span class='possplit'>&nbsp;&nbsp;</span><a href=\"" + urlok + "\" target=\"" + lanms.Rows[0]["dkfs"].ToString() + "\">" + lanms.Rows[0]["lmmc"].ToString() + "</a>";
                    //栏目图片
                    if (lanms.Rows[0]["logoimg"].ToString().Length > 4) this.lmlogo.Src = lanms.Rows[0]["logoimg"].ToString();
                    //读取子栏目
                    DataTable zlanms = Sqlhelper.Serach("SELECT TOP 20 *  FROM [xw_lanm] where fid=@lmid order by px", new SqlParameter("lmid", Request["id"].ToString()));
                    if (zlanms.Rows.Count > 0)
                    {
                        this.wp_listcolumn_w87.InnerHtml = "  <ul class=\"column-list-wrap\">";
                        for (int i = 0; i < zlanms.Rows.Count; i++)
                        {
                            urlok = "list.aspx?id=" + zlanms.Rows[i]["lmid"].ToString();
                            if (zlanms.Rows[i]["url"].ToString().Length > 4) urlok = zlanms.Rows[i]["url"].ToString();
                            string lmmc = basic.ReplaceHtmlTag(zlanms.Rows[i]["lmmc"].ToString(), 20);
                            this.wp_listcolumn_w87.InnerHtml += " <li class=\"column-item column-1\"><a href=\"" + urlok + "\" title=\"" + lmmc + "\" class=\"column-item-link\"><span class=\"column-name\">" + lmmc + "</span></a></li>";
                        }
                        this.wp_listcolumn_w87.InnerHtml += "  </ul>";
                    }
                    else
                    {
                        this.wp_listcolumn_w87.InnerHtml = "";
                    }
                }
                else
                {
                    //读取根目录
                    DataTable lanms1 = Sqlhelper.Serach("SELECT TOP 1 *  FROM [xw_lanm] where lmid='" + lanms.Rows[0]["fid"].ToString() + "' order by px");
                    if (lanms1.Rows.Count > 0)
                    {//根目录
                        if (lanms1.Rows[0]["fid"].ToString() == "-1")
                        {
                            //显示栏目名称
                            this.lmmc.InnerHtml = lanms1.Rows[0]["lmmc"].ToString();

                            //读取子栏目
                            DataTable zlanms = Sqlhelper.Serach("SELECT TOP 20 *  FROM [xw_lanm] where fid='" + lanms1.Rows[0]["lmid"].ToString() + "' order by px");
                            if (zlanms.Rows.Count > 0)
                            {
                                this.wp_listcolumn_w87.InnerHtml = "  <ul class=\"column-list-wrap\">";
                                for (int i = 0; i < zlanms.Rows.Count; i++)
                                {
                                    string urlok = "list.aspx?id=" + zlanms.Rows[i]["lmid"].ToString();
                                    if (zlanms.Rows[i]["url"].ToString().Length > 4) urlok = zlanms.Rows[i]["url"].ToString();
                                    string lmmc = basic.ReplaceHtmlTag(zlanms.Rows[i]["lmmc"].ToString(), 20);
                                    if (zlanms.Rows[i]["lmid"].ToString() == Request["id"].ToString())
                                    {
                                        this.lmmc2.InnerHtml = zlanms.Rows[i]["lmmc"].ToString();
                                        this.wp_listcolumn_w87.InnerHtml += " <li class=\"column-item column-1 selected\"><a href=\"" + urlok + "\" title=\"" + lmmc + "\" class=\"column-item-link selected\"><span class=\"column-name\">" + lmmc + "</span></a></li>";
                                        string urlok1 = "list.aspx?id=" + lanms1.Rows[0]["lmid"].ToString();
                                        if (lanms1.Rows[0]["url"].ToString().Length > 4) urlok1 = lanms1.Rows[0]["url"].ToString();
                                        this.lmdh.InnerHtml = "<span class=\"path-name\">当前位置：</span><a href=\"/\" target=\"_self\">首页</a><span class='possplit'>&nbsp;&nbsp;</span><a href=\"" + urlok1 + "\" target=\"" + lanms1.Rows[0]["dkfs"].ToString() + "\">" + lanms1.Rows[0]["lmmc"].ToString() + "</a><span class='possplit'>&nbsp;&nbsp;</span><a href=\"" + urlok + "\">" + lmmc + "</a>";
                                        //栏目图片
                                        if (zlanms.Rows[i]["logoimg"].ToString().Length > 4) this.lmlogo.Src = zlanms.Rows[i]["logoimg"].ToString();
                                    }
                                    else
                                    {
                                        this.wp_listcolumn_w87.InnerHtml += " <li class=\"column-item column-1\"><a href=\"" + urlok + "\" title=\"" + lmmc + "\" class=\"column-item-link\"><span class=\"column-name\">" + lmmc + "</span></a></li>";
                                    }
                                }
                                this.wp_listcolumn_w87.InnerHtml += "  </ul>";
                            }
                            else
                            {
                                this.wp_listcolumn_w87.InnerHtml = "";
                            }
                        }




                    }
                    //读取子栏目

                }
            }
            else
            {
                this.lmmc.InnerHtml = "无该栏目";
            }


        }


    }



















    #region 设置页面显示条数事件
    protected void PageSize_Go(object sender, EventArgs e)
    {
        //this.DropDownList2.Items.Insert(0, new ListItem("全部"));

        TextBox ps = (TextBox)this.GridView1.BottomPagerRow.FindControl("PageSize_Set");
        if (!string.IsNullOrEmpty(ps.Text))
        {

            int _PageSize = 0;

            if ((Int32.TryParse(ps.Text, out _PageSize) == true) && _PageSize > 0)
            {

                GridView1.PageSize = _PageSize;
                //this.SqlDataSource1.SelectCommand = ViewState["SqlDataSource1.SelectCommand"].ToString();
                //GridView1.DataBind();
                //GV_DataBind();
            }

        }
    }
    #endregion
    #region 分页事件总页数

    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        ViewState["count"] = e.AffectedRows;
        //ViewState["countbd"] = getbds();
        //int s=GridView1.Rows
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    #endregion
    #region 定向转到

    protected void LinkButtonGo_Click(object sender, EventArgs e)
    {

        LinkButton lbtn_go = (LinkButton)this.GridView1.BottomPagerRow.FindControl("LinkButtonGo");

        TextBox txt_go = (TextBox)this.GridView1.BottomPagerRow.FindControl("txt_go");

        if (!string.IsNullOrEmpty(txt_go.Text))
        {

            int PageToGo = 0;

            if ((Int32.TryParse(txt_go.Text, out PageToGo) == true) && PageToGo > 0)
            {

                lbtn_go.CommandName = "Page";

                lbtn_go.CommandArgument = PageToGo.ToString();

            }

        }
        //this.SqlDataSource1.SelectCommand = ViewState["SqlDataSource1.SelectCommand"].ToString();
        //GridView1.DataBind();

    }

    #endregion
    #region 始终显示下部控制区
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (this.GridView1.Rows.Count != 0)
        {
            Control table = this.GridView1.Controls[0];
            int count = table.Controls.Count;
            table.Controls[count - 1].Visible = true;
        }
    }
    #endregion

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        GridView _gridView = (GridView)sender;
        string id, sql;

        id = e.CommandArgument.ToString();




        if (e.CommandName == "删除")
        {
            //string xx = textbox.Text;

            if (Sqlhelper.ExcuteNonQuery("DELETE FROM xw_neirong  where id=" + id + " ") > 0)
            {
                this.Label1.Text = "<font color=green> &nbsp;&nbsp;&nbsp;&nbsp;新闻删除成功!</font>";
            }
            else
            {
                this.Label1.Text = "<font color=red> &nbsp;&nbsp;&nbsp;&nbsp;新闻删除失败,请重试!!</font>";
            }
        }
        ViewState["gridsql"] = SqlDataSource1.SelectCommand;
        SqlDataSource1.SelectCommand = ViewState["gridsql"].ToString();
        _gridView.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string[] chkIds = null;

        string xtje = Request["hdfWPBH"].ToString();
        string batchRegroup = xtje.TrimEnd(',');//通过这种方式来获得前台隐藏域的内容  
        if (batchRegroup.Length != 0)
        {
            chkIds = batchRegroup.Split(',');
        }
        //string sql = "";
        try
        {
            int cg = 0;
            int sb = 0;
            string sbjl = "";

            for (int i = 0; i < chkIds.Length; i++)
            {
                string xm1 = "";
                string zt1 = "";
                //将传过来的ID记录状态改为删除
                //sql = "UPDATE T_WPXX_CK SET SPR='" + userrealName + "' WHERE ID='" + chkIds[i] + "'";
                // wpck.auditOrDelete(sql);//传入SQL语句并执行  
                // DataTable xm = Sqlhelper.Serach("select 姓名,领取状态 from byz where id=" + chkIds[i] + "");
                if (Sqlhelper.ExcuteNonQuery("DELETE FROM xw_neirong  where id=" + chkIds[i] + " ") > 0)
                {
                    // this.Label1.Text = "<font color=green>新闻删除成功!</font>";
                    cg = cg + 1;
                }
                else
                {
                    sb = sb + 1;
                    sbjl = " &nbsp;&nbsp;&nbsp;&nbsp;有" + sb + "条新闻删除失败";
                }
                //Response.Write("<script>alert('" + chkIds[i] + "');</script>");

            }
            this.Label1.Text = "<font color=green> &nbsp;&nbsp;&nbsp;&nbsp;共删除" + cg + "条新闻!</font><font color=red>" + sbjl + "</font>";
        }
        catch
        {
            this.Label1.Text = "<font color=red> &nbsp;&nbsp;&nbsp;&nbsp;批量删除出错！</font>";
        }


    }
    protected string imagestu(string images)
    {
        if (images.Length > 0)
        {
            return "[图]";
        }
        return "";
    }
    protected string xwtitle(string title, string one)
    {
        if (one == "all")
        {
            return basic.ReplaceHtmlTag(title, 200);
        }
        else
        {
            return basic.ReplaceHtmlTag(title, 40);
        }
        return title;
    }

    protected string xwzt(string isyn)
    {
        if (isyn == "0")
        {
            return "<font color=red>未审核</font>";
        }
        if (isyn == "1")
        {
            return "<font color=green>已审核</font>";
        }
        if (isyn == "2")
        {
            return "<font color=red>被打回</font>";
        }
        return "未审核";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}