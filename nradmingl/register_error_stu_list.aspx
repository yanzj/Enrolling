﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register_error_stu_list.aspx.cs" Inherits="nradmingl_Default3" %>

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
             <asp:HiddenField ID="pk_batch_no" Value="" runat="server" />
        <div class="admin-main">
            <blockquote class="layui-elem-quote">
                <i class="layui-icon">&#xe602;</i>信息有误学生           
            </blockquote>
            <div>                
                <div class="layui-form-item">
                    <!--迎新批次下拉列表-->
                    <div class="layui-inline">
                        <label class="layui-form-label">批次：</label>
                        <div class="layui-input-inline">
                            <select name="batchlist" id="batchlist">

                            </select>
                        </div>
                    </div>

                    <div class="layui-inline">
                        <label class="layui-form-label" style="width:100px;" id="count">总计：0人</label>
                    </div>
                   
                    <table class="site-table table-hover" cellspacing="0" rules="all" border="1" id="studentlist" style="border-collapse: collapse;">
                        <thead>
                            <tr>        
                                <th scope="col">序号</th>  
                                <th scope="col">年级</th>                        
                                <th scope="col">学院</th>
                                <th scope="col" >专业</th>
                                <th scope="col" >班级</th>
                                <th scope="col">姓名</th>
                                <th scope="col">性别</th>
                                <th scope="col">高考报名号</th>
                                <th scope="col">身份证号</th>
                                <th scope="col">联系电话</th>
                                <th scope="col">辅导员</th>
                                <th scope="col">辅导员电话</th>
                                <th scope="col">辅导员QQ</th>
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
        <script type="text/javascript" src="../b_js/app/register_error_stu_list.js"></script>

<%--        <script type="text/javascript" src="plugins/layui/layui.js"></script>--%>
    <script>
        load();
        //layui.use('form', function () {
        //    var form = layui.form(); //只有执行了这一步，部分表单元素才会修饰成功
        //});
    </script>

</body>
</html>
