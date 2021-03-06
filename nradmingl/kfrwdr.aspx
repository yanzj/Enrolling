﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kfrwdr.aspx.cs" Inherits="nradmingl_export" %>
<!DOCTYPE html>
<html lang="zh-cn">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="UTF-8" content="编码" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />

    <!--引用ＬＡＹＵＩ前端必须ＣＳＳ-->
        <link rel="stylesheet" href="plugins/layui/css/layui.css" media="all" />
		<link rel="stylesheet" href="plugins/global.css" media="all" />
         <!--引用ＬＡＹＵＩ前端字体图标ＣＳＳ-->
		<link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css" />
         <!--引用ＬＡＹＵＩ前端表格ＣＳＳ,使用表格时才引用-->
		<link rel="stylesheet" href="plugins/table.css" />
    
     <!--引用ＬＡＹＵＩ前端必须ＣＳＳ OVER-->
     <!--下面为步骤专用CSS样式-->
   <style>
   .wizard {
    -moz-user-select: none;
    -webkit-user-select: none;
    -ms-user-select: none;
    -khtml-user-select: none;
    user-select: none;
    border: 1px solid #ccc;
    border-radius: 0;
    background-clip: padding-box;
    background-color: #fff;
    position: relative;
    overflow: hidden;
}
.wizard ul {
    list-style: none outside none;
    padding: 0;
    margin: 0;
    width: 4000px;
}
ul, menu, dir {
    display: block;
    list-style-type: disc;
    -webkit-margin-before: 1em;
    -webkit-margin-after: 1em;
    -webkit-margin-start: 0px;
    -webkit-margin-end: 0px;
    -webkit-padding-start: 40px;
}
.wizard ul li:first-child {
    -webkit-border-radius: 2px 0 0 0;
    -webkit-background-clip: padding-box;
    -moz-border-radius: 2px 0 0 0;
    -moz-background-clip: padding;
    border-radius: 2px 0 0 0;
    background-clip: padding-box;
    padding-left: 20px;
}
.wizard ul li.active {
    background: #fff;
    color: #262626;
}
.wizard ul li {
    float: left;
    margin: 0;
    padding: 0 20px 0 30px;
    line-height: 46px;
    position: relative;
    background: #f5f5f5;
    color: #d0d0d0;
    font-size: 16px;
    cursor: default;
    -webkit-transition: all .218s ease;
    -moz-transition: all .218s ease;
    -o-transition: all .218s ease;
    transition: all .218s ease;
}
.wizard ul li.active:before {
    display: block;
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    right: -1px;
    height: 2px;
    max-height: 2px;
    overflow: hidden;
    background-color: #337ab7;
    z-index: 10000;
}
.wizard ul li.active .step {
    border-color: #337ab7;
    color: #337ab7;
}
.wizard ul li .step {
    border: 2px solid #e5e5e5;
    color: #ccc;
    font-size: 13px;
    border-radius: 100%;
    position: relative;
    z-index: 2;
    display: inline-block;
    width: 22px;
    height: 22px;
    line-height: 20px;
    text-align: center;
    margin-right: 10px;
}
* {
    padding: 0;
    margin: 0;
    font-size: 9pt;
}
.wizard ul li .chevron {
    border: 20px solid transparent;
    border-left: 14px solid #d4d4d4;
    border-right: 0;
    display: block;
    position: absolute;
    right: -14px;
    top: 0;
    z-index: 1;
}
.wizard ul li.active {
    background: #fff;
    color: #262626;
}
.wizard ul li {
    float: left;
    margin: 0;
    padding: 0 0px 0 20px;
    line-height: 38px;
    position: relative;
    background: #f5f5f5;
    color: #d0d0d0;
    font-size: 16px;
    cursor: default;
    -webkit-transition: all .218s ease;
    -moz-transition: all .218s ease;
    -o-transition: all .218s ease;
    transition: all .218s ease;
}
.wizard ul li.active .chevron:before {
    border-left: 14px solid #fff;
}
.wizard ul li .chevron:before {
    border: 20px solid transparent;
    border-left: 14px solid #f5f5f5;
    border-right: 0;
    content: "";
    display: block;
    position: absolute;
    right: 1px;
    top: -20px;
    -webkit-transition: all .218s ease;
    -moz-transition: all .218s ease;
    -o-transition: all .218s ease;
    transition: all .218s ease;
}
   </style>
    <!--步骤专用CSS样式OVER-->
   
</head>
<body style="font-family: 微软雅黑,宋体,Arial,Helvetica,Verdana,sans-serif;"> 
    <form id="form1" runat="server">
     <div class="admin-main">
     <blockquote class="layui-elem-quote">
      <div id="wizard" class="wizard" data-target="#wizard-steps" style="border-left: none; border-top: none; border-right: none;">
        <ul class="steps">
            <li data-target="#step-1" class="active" style="padding-left:0px;"><span class="step">1</span>准备模板<span class="chevron"></span></li>
            <li data-target="#step-2" id="setp2" runat="server"><span class="step">2</span>上传文件<span class="chevron"></span></li>
            <li data-target="#step-3" id="setp3" runat="server"><span class="step">3</span>确认上传<span class="chevron"></span></li>
           
        </ul>
        <span style=" float:right;"><a id="setpup" runat="server" class="layui-btn layui-btn-small" style="margin-right:15px;margin-top:4px;">上一步</a><a  id="setpdown" runat="server"  style="margin-right:15px;margin-top:4px;" class="layui-btn layui-btn-small">下一步</a></span>
    </div>  
				
	</blockquote>
    <div  id="setp1cz" runat="server">
     <blockquote class="layui-elem-quote">
     <a href="#" class="layui-btn layui-btn-small" id="mbfile" runat="server">
					<i class="layui-icon">&#xe61e;</i>下载模板
				</a>
      <asp:Label ID="setp1ts" runat="server"
         Text="系统为您提供了标准的导入模板,请先下载EXCLE模板按模板准备资料,若你已经准备好资料,请点击＂下一步＂!" 
             Font-Size="Medium"></asp:Label>
				
	</blockquote>
    </div>
     <div   id="setp2cz" runat="server">
       <blockquote class="layui-elem-quote">
			 <div class="layui-box layui-upload-button"><form target="layui-upload-iframe" method="post" key="set-mine" enctype="multipart/form-data" action=""><input type="file" name="file1" lay-type="file" class="layui-upload-file"></form><span class="layui-upload-icon"><i class="layui-icon"></i>上传文件</span></div>
    	
	</blockquote>
    </div>
    <div   id="setp3cz" runat="server">
    显示导入结果
    </div>
       </div>


        <script type="text/javascript" src="plugins/layui/layui.js"></script>
		<script>
		    layui.use('element', function () {
		        var $ = layui.jquery,
					element = layui.element(); //Tab的切换功能，切换事件监听等，需要依赖element模块

		        //触发事件
		        var active = {
		            tabAdd: function () {
		                //新增一个Tab项
		                element.tabAdd('demo', {
		                    title: '新选项' + (Math.random() * 1000 | 0) //用于演示
								,
		                    content: '内容' + (Math.random() * 1000 | 0)
		                })
		            },
		            tabDelete: function () {
		                //删除指定Tab项
		                element.tabDelete('demo', 2); //删除第3项（注意序号是从0开始计算）
		            },
		            tabChange: function () {
		                //切换到指定Tab项
		                element.tabChange('demo', 1); //切换到第2项（注意序号是从0开始计算）
		            }
		        };

		        $('.site-demo-active').on('click', function () {
		            var type = $(this).data('type');
		            active[type] ? active[type].call(this) : '';
		        });
		    });


		</script>
        	<script>
        	    layui.use(['form', 'layedit', 'laydate'], function () {
        	        var form = layui.form(),
					layer = layui.layer,
					layedit = layui.layedit,
					laydate = layui.laydate;

        	        //创建一个编辑器
        	        var editIndex = layedit.build('LAY_demo_editor');
        	        //自定义验证规则
        	        form.verify({
        	            title: function (value) {
        	                if (value.length < 5) {
        	                    return '标题至少得5个字符啊';
        	                }
        	            },
        	            pass: [/(.+){6,12}$/, '密码必须6到12位'],
        	            content: function (value) {
        	                layedit.sync(editIndex);
        	            }
        	        });

        	        //监听提交
        	        form.on('submit(demo1)', function (data) {
        	            layer.alert(JSON.stringify(data.field), {
        	                title: '最终的提交信息'
        	            })
        	            return false;
        	        });
        	    });
		</script>

    </form>
</body>
</html>
