﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bzr_view.aspx.cs" Inherits="nradmingl_Default3" %>

<!DOCTYPE html>

<html lang="zh-cn">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" content="编码" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
     <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <!--引用ＬＡＹＵＩ前端必须ＣＳＳ-->
        <link rel="stylesheet" href="plugins/layui/css/layui.css" media="all" />
		<link rel="stylesheet" href="plugins/global.css" media="all" />
         <!--引用ＬＡＹＵＩ前端字体图标ＣＳＳ-->
		<link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css" />
         <!--引用ＬＡＹＵＩ前端表格ＣＳＳ,使用表格时才引用-->
		<link rel="stylesheet" href="plugins/table.css" />    
        <!--引用ＬＡＹＵＩ前端必须ＣＳＳ OVER-->
    <style>
        .layui-form-label {
            float: left;
            display: block;
            padding: 9px 15px;
            width: 50px;
            font-weight: 400;
            text-align: left;
        }

                .layui-form-select dl dd.layui-this {
            background-color: #196BAB;
            color: #fff;
        }
.layui-form select {
    display: inherit;
     height: 37px;
}

    </style>
   
</head>
<body>
    <form id="form1" runat="server" class="layui-form">
              <asp:HiddenField ID="pk_staff_no" Value="" runat="server" />
              <asp:HiddenField ID="pk_batch_no" Value="" runat="server" />
        <div class="admin-main">
            <blockquote class="layui-elem-quote">
                <i class="layui-icon">&#xe602;</i>辅导员<i class="layui-icon">&#xe602;</i>网上报到情况           
            </blockquote>
            <div>
                
                <div class="layui-form-item" style="margin-bottom:0px;">
                    <!--迎新批次下拉列表-->
                    <div class="layui-inline" style="margin-bottom:0px;">
<%--                        <label class="layui-form-label">批次：</label>--%>
                        <div class="layui-input-inline">
                            <select name="batchlist" id="batchlist">

                            </select>
                        </div>
                    </div>

                    <!--班级下拉列表-->
                    <div class="layui-inline" style="margin-bottom:0px;">
<%--                        <label class="layui-form-label">班级：</label>--%>
                        <div class="layui-input-inline">
                            <select name="classlist" id="classlist">
                                <option value="">请选择班级</option>
                                <option value="1">layer</option>
                                <option value="2">form</option>
                                <option value="3">layim</option>
                                <option value="4">element</option>
                            </select>
                        </div>
                    </div>
                    <!--项目下拉列表-->
                    <div class="layui-inline" style="margin-bottom:0px;">
                        <label class="layui-form-label">项目：</label>
                        <div class="layui-input-inline">
                            <select name="affairlist" id="affairlist">
                                <option value="">请选择项目</option>
                                <option value="1">layer</option>
                                <option value="2">form</option>
                                <option value="3">layim</option>
                                <option value="4">element</option>
                            </select>
                        </div>
                    </div> 
                    
                     <div class="layui-inline" style="margin-bottom:0px;">
                         <a href="#" onclick="classoraffairchange();" class="layui-btn layui-btn-small hidden-xs">
					    <i class="layui-icon">&#x1002;</i> 刷新
				        </a>
                    </div>                  
                </div>

                <div class="layui-form-item" style="margin-bottom:0px;">
                    <div class="layui-inline" style="margin-bottom:0px;">
                        <label class="layui-form-label" style="width:100px;padding:0px 0px;" id="zj">总计：0人</label>
                        <label class="layui-form-label" style="width:220px;padding:0px 0px;" id="zc">网上注册：0人</label>
                        <%--<label class="layui-form-label" style="width:220px;padding:0px 0px;" id="lstd">绿色通道：0人</label>--%>
                        <label class="layui-form-label" style="width:220px;padding:0px 0px;" id="zxdk">助学贷款：0人</label>
                    </div>                 
                </div>
                <div class="layui-form-item" style="margin-bottom:0px;">
                    <div class="layui-inline" style="margin-bottom:0px;">
                        <label class="layui-form-label" style="width:800px;" id="xm">项目：0人</label>
                    </div>                 
                </div>

                <div class="layui-form-item">
 <table class="site-table table-hover" cellspacing="0" rules="all" border="1" id="studentlist" style="border-collapse: collapse;">
                        <thead>
                            <tr>        
                                <th scope="col">序号</th>                        
<%--                                <th scope="col">年级</th>
                                <th scope="col">学院</th>
                                <th scope="col" >专业</th>--%>
                                <th scope="col">姓名</th>
                                <th scope="col">性别</th>
                                <th scope="col" class="hidden-xs">学号</th>
                                <th scope="col" class="hidden-xs">高考报名号</th>
                                <th scope="col" class="hidden-xs">身份证号</th>
                                <th scope="col" class="hidden-xs">联系电话</th>
                                <th scope="col">网上注册</th>
                                <th scope="col">助学贷款</th>
                                <th scope="col" id="itemname">项目情况</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
        <script type="text/javascript" src="../b_js/jquery.min2.js"></script>
        <script type="text/javascript" src="../b_js/app/bzr_view.js"></script>

<%--        <script type="text/javascript" src="plugins/layui/layui.js"></script>--%>
    <script>
        load();
        //layui.use('form', function () {
        //    var form = layui.form(); //只有执行了这一步，部分表单元素才会修饰成功
        //});
    </script>

</body>
</html>
