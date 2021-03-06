﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultgl.aspx.cs" Inherits="nradmingl_Defaultgl" %>

<!DOCTYPE html>

<html>
<head runat="server">
    
    <meta charset="utf-8">
		<title>后台管理</title>
		<meta name="renderer" content="webkit">
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="format-detection" content="telephone=no">

		<link rel="stylesheet" href="plugins/layui/css/layui.css" media="all" />
		<link rel="stylesheet" href="plugins/global.css" media="all">
		<link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css">
</head>
<body>
   <form id="form1" runat="server">
    <div class="layui-layout layui-layout-admin">
			<div class="layui-header header header-demo">
				<div class="layui-main">
					<div class="admin-login-box">
						<a class="logo"  href="/">
							<span style="font-size: 22px;">迎新管理系统</span>
						</a>
						<div title="左侧导航菜单显示/隐藏" class="admin-side-toggle  hidden-xs">
							<i class="fa fa-chevron-left" aria-hidden="true"></i>
						</div>
					</div>
                     
					<ul class="layui-nav">
                    <li class="layui-nav-item" id="tsxx" runat="server"> </li>
						
						<li class="layui-nav-item  hidden-xs">
							<a href="/default.aspx"><i class="fa fa fa-home" aria-hidden="true"  style="margin-right:2px;"></i>返回首页</a>
						</li>
                        
						
						<li class="layui-nav-item">
							<a href="javascript:;" class="admin-header-user">
								<img src="../img/user2-160x160.jpg" style="width: 40px; height: 40px; border-radius: 100%;" />
                                
								<span  id="username" runat="server">用户名</span>
                               
							</a>
							<dl class="layui-nav-child dda">

								<dd>
									<a href="/logout.aspx"><i class="fa fa-sign-out" aria-hidden="true"></i> 注销退出</a>
								</dd>
                                
							</dl>
						</li>
                        <li class="layui-nav-item   hidden-xs"><a href="javascript:" class="admin-side-full" style="margin-right: -10px;margin-left: -10px;" title="全屏"  >
					<i class="fa fa-arrows-alt" aria-hidden="true"></i>
				</a></li>
					</ul>
                     
				</div>
			</div>
			<div class="layui-side layui-bg-black" id="admin-side">
				<div class="layui-side-scroll" id="admin-navbar-side" lay-filter="side"></div>
			</div>
			<div class="layui-body" style="bottom: 0;" id="admin-body">
				<div class="layui-tab admin-nav-card layui-tab-brief" lay-filter="admin-tab">
               
					<ul class="layui-tab-title">
						<li class="layui-this">
							<i class="fa fa-dashboard" aria-hidden="true"></i>
							<cite>迎新管理首页</cite>
						</li>
            
					</ul>
                   
                  
					<div class="layui-tab-content" style="min-height: 150px; padding: 5px 0 0 0;">
						<div class="layui-tab-item layui-show">
							<iframe src="/view/Defaultczzt.aspx"></iframe>
						</div>
					</div>
				</div>
			</div>
			
			<div class="site-tree-mobile layui-hide">
				<i class="layui-icon">&#xe602;</i>
			</div>
			<div class="site-mobile-shade"></div>
            <!--前端框架ＪＳ及弹出层ＪＳ-->
			<script type="text/javascript" src="plugins/layui/layui.js"></script>
             <!--前端框架ＪＳ及弹出层ＪＳＯＶＥＲ-->
             <!--页面自动生成二维码ＪＳ　
			<script type="text/javascript" src="plugins/jquery.qrcode.min.js"></script>
             页面自动生成二维码ＪＳＯＶＥＲ-->
			<script>
            //忽略所有JS错误
			    function killerrors() { return true; }
			    window.onerror = killerrors;
                //忽略错误结束,加载页面JS执行


			    layui.config({
			        base: 'js/'
			    }).use(['element', 'layer', 'navbar'], function () {
			        var element = layui.element(),
						$ = layui.jquery,
						layer = layui.layer,
						navbar = layui.navbar();

			        //navbar.render();
			        //iframe自适应
			        $(window).on('resize', function () {
			            var $content = $('.admin-nav-card .layui-tab-content');
			            $content.height($(this).height() - 117);
			            $content.find('iframe').each(function () {
			                $(this).height($content.height());
			            });
			        }).resize();
			        //设置navbar
			        navbar.set({
			            elem: '#admin-navbar-side',
			            url: 'treemenu.aspx'
			        });
			        //渲染navbar
			        navbar.render();
			        var $body = $('.admin-nav-card');
			        var $tabs = $body.children('ul.layui-tab-title');
			        var $contents = $body.children('div.layui-tab-content');
			        var tabFilter = 'admin-tab';
			        //监听点击事件
			        navbar.on('click(side)', function (data) {
			            var href = data.field.href;
			            if (href === undefined || href === '') {
			                return;
			            }
			            var iframe = '<iframe src="' + href + '"></iframe>';
			            var html = data.elem.html();
			            var count = 0;
			            var tabIndex;
			            console.log($tabs);
			            $tabs.find('li').each(function (i, e) {
			                var $cite = $(this).children('cite');
			                if ($cite.text() === data.elem.find('cite').text()) {
			                    count++;
			                    tabIndex = i;
			                };
			            });
			            //tab不存在
			            if (count === 0) {
			                //添加删除样式
			                html += '<i class="layui-icon layui-unselect layui-tab-close">&#x1006;</i>';
			                //添加tab
			                element.tabAdd(tabFilter, {
			                    title: html,
			                    content: iframe
			                });
			                //iframe 自适应
			                var $content = $('.admin-nav-card .layui-tab-content');
			                $content.find('iframe').each(function () {
			                    $(this).height($content.height());
			                });
			                //绑定关闭事件
			                $tabs = $body.children('ul.layui-tab-title');
			                var $li = $tabs.find('li');
			                $li.eq($li.length - 1).children('i.layui-tab-close').on('click', function () {
			                    element.tabDelete(tabFilter, $(this).parent('li').index()).init();
			                });
			                //获取焦点
			                element.tabChange(tabFilter, $li.length - 1);

			            } else {
			                //切换tab
			                element.tabChange(tabFilter, tabIndex);
			            }
			        });
			        //菜单的隐藏显示
			        $('.admin-side-toggle').on('click', function () {
			            console.log($('#admin-side').width());
			            console.log($('#admin-body').css('left'));
			            var sideWidth = $('#admin-side').width();
			            if (sideWidth === 180) {
			                $('#admin-side').width(0);
			                $('#admin-body').css('left', '0');
			                $(".admin-side-toggle").html("<i class='fa fa-chevron-right' aria-hidden='true'></i>");
                            
			            } else {
			                $('#admin-side').width(180);
			                $('#admin-body').css('left', '180px');
			                $(".admin-side-toggle").html("<i class='fa fa-chevron-left' aria-hidden='true'></i>");
			            }

			        });
			       
			        
			        
			        //全屏控制
			        $('.admin-side-full').on('click', function () {
			            if (!$(this).attr('fullscreen')) {
			                $(this).attr('fullscreen', 'true');
			                //全屏操作
			                var de = document.documentElement;
			                if (de.requestFullscreen) {
			                    de.requestFullscreen();
			                } else if (de.mozRequestFullScreen) {
			                    de.mozRequestFullScreen();
			                } else if (de.webkitRequestFullScreen) {
			                    de.webkitRequestFullScreen();
			                }
			            } else {
			                $(this).removeAttr('fullscreen')
			                //退出全屏
			                var de = document;
			                if (de.exitFullscreen) {
			                    de.exitFullscreen();
			                } else if (de.mozCancelFullScreen) {
			                    de.mozCancelFullScreen();
			                } else if (de.webkitCancelFullScreen) {
			                    de.webkitCancelFullScreen();
			                }
			            }
			        });
			        //手机设备的简单适配
			        var treeMobile = $('.site-tree-mobile'),
						shadeMobile = $('.site-mobile-shade');
			        treeMobile.on('click', function () {
			            $('body').addClass('site-mobile');
			        });
			        shadeMobile.on('click', function () {
			            $('body').removeClass('site-mobile');
			        });
			    });
			    function setCookie(name, value) {
			        var Days = 30;
			        var exp = new Date();
			        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
			        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
			    }
			   
			    //将当前页的ＵＲＬ宽高存入ＣＯＯＫＩＥ
                
			    setCookie('xwidth', screen.availWidth);
                setCookie('xheight', screen.availHeight);
                setCookie('xurl', window.location.href);
                //生成当前页二维码ＣＯＤＥ
                //$('#code').qrcode(window.location.href);
                
			</script>
		</div>
  
</form>  
</body>
</html>
