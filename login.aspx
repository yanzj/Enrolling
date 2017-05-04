﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_Default" %>
<%
    
    
    string agent = (Request.UserAgent + "").ToLower().Trim();
   

    if (agent == "" ||
        agent.IndexOf("mobile") != -1 ||
        agent.IndexOf("mobi") != -1 ||
        agent.IndexOf("nokia") != -1 ||
        agent.IndexOf("samsung") != -1 ||
        agent.IndexOf("sonyericsson") != -1 ||
        agent.IndexOf("mot") != -1 ||
        agent.IndexOf("blackberry") != -1 ||
        agent.IndexOf("lg") != -1 ||
        agent.IndexOf("htc") != -1 ||
        agent.IndexOf("j2me") != -1 ||
        agent.IndexOf("ucweb") != -1 ||
        agent.IndexOf("opera mini") != -1 ||
        agent.IndexOf("mobi") != -1)
    {
        //终端可能是手机
        Response.Write("<?xml version='1.0'?><!DOCTYPE html><HTML>");
    }
    else
    {
        Response.Write(" <!DOCTYPE html><html>");
    }
     %>


<head runat="server">

<style>
﻿html,body,h1,h2,h3,h4,h5,h6,blockquote,p,pre,dl,dd,ol,ul,li,a,span,caption,th,td,form,fieldset,legend,input,button,textarea,address{margin:0;padding:0}h1,h2,h3,h4,h5,h6{font-size:100%}ol,ul{list-style:none}li{list-style:none}fieldset,img{border:0}address,cite,dfn,em,var{font-style:normal}code,kbd,pre,samp{font-family:courier new,courier,monospace}input,button,textarea,select{font-size:150%}input,button,select,textarea{outline:0}textarea{resize:none}table{border-collapse:collapse;border-spacing:0;empty-cells:show;font-size:inherit}abbr[title]{border-bottom:1px dotted;cursor:help}a,a:hover{text-decoration:none}a,label,:focus{outline:0 none}a,img,input{border:0 none}s{font-style:normal;text-decoration:none}body{font-size:18px;font-family:arial,"Hiragino Sans GB","Microsoft YaHei","微軟正黑體","儷黑 Pro",sans-serif}button,input,select,textarea{font-family:arial,"Hiragino Sans GB","Microsoft YaHei",sans-serif}input::-moz-placeholder,textarea::-moz-placeholder{color:#3b3b3b;font-weight:normal}::-webkit-input-placeholder{color:#3b3b3b;font-weight:normal}input:-ms-input-placeholder{color:#3b3b3b;font-weight:normal}::-ms-clear{display:none}::-ms-reveal{display:none}.clearfix:after{display:block;content:"\20";height:0;clear:both;overflow:hidden;visibility:hidden}.clearfix{*zoom:1}input::-ms-clear{display:none}input::-ms-reveal{display:none}input:-webkit-autofill{-webkit-box-shadow:0 0 0 1000px white inset}@media screen and (-ms-high-contrast:active),(-ms-high-contrast:none){a{background-color:transparent}}input{background:0;border:0 none}input[type="button"],input[type="submit"],input[type="reset"],a{-webkit-appearance:none;appearance:none}.fl{float:left}.fr{float:right}.nbg{background:none !important}.t_l{text-align:left}.t_c{text-align:center}.t_r{text-align:right}.c_b:before,.c_b:after{content:"";display:block}.c_b:after{clear:both}.c_b{zoom:1}.hidden,.hide{display:none}.hideimportant{display:none !important}.underline{text-decoration:underline}input[type=text]::-ms-clear,input[type=password]::-ms-reveal{display:none}input{color:#333}input:required,input:invalid{-moz-box-shadow:none;box-shadow:none}input::-moz-focus-inner{border:0}html,body{height:100%}
body{background:#f5f5f5;color:#757575}a{color:#757575}input{color:#333}::-webkit-input-placeholder{color:#9d9d9d}input:-ms-input-placeholder{color:#9d9d9d}
.wrapper{width:100%;min-height:100%;height:auto;display:-webkit-box;display:box;display:-moz-box;display:-o-box;-webkit-box-align:center;-moz-box-align:center;-o-box-align:center;box-align:center;-webkit-box-pack:center;-moz-box-pack:center;-o-box-pack:center;box-pack:center}.wrap{padding-top:100px \9}@media screen and (min-width:0\0){.wrap{padding-top:100px}}.layout{background-color:#fff;width:854px;margin:0 auto 20px;position:relative;min-height:620px}.mainbox{padding-bottom:30px}.captcha_layout{min-height:700px}.ercode{width:68px;height:68px;position:absolute;right:0;top:0;opacity:.3;filter:alpha(opacity=30)}.ercode:hover,.ercode:focus{opacity:1;filter:alpha(opacity=100)}.header_tit{padding:50px 0 22px}.milogo{width:49px;height:48px;margin:0 auto;display:block}.header_tit_txt{font-size:30px;color:#424242;font-weight:normal;padding-top:22px}.lgn_inputbg{position:relative}.login_area{width:358px;margin:0 auto;padding-bottom:20px}.labelbox{height:45px;display:block;margin-bottom:14px;border:1px solid #e0e0e0;border-radius:5px;}.labelbox input{ font-size:18px; height:40px;line-height:40px;width:320px;padding:5px 16px 0px 14px;}.placehld{width:326px;padding:13px 16px 13px 14px}.country_list{cursor:pointer;display:none;float:left}.country_regin{max-width:80px;overflow:hidden;white-space:nowrap;-webkit-text-overflow:ellipsis;-moz-text-overflow:ellipsis;-o-text-overflow:ellipsis;text-overflow:ellipsis}.item_account{float:left}.country_regin{margin-right:8px}.country_code{padding-right:12px;position:relative}.icon_arrow_down{width:8px;height:5px;position:absolute;top:8px;right:0;background-position:-19px -69px}.eye_panel{display:none}.divflex .item_account{width:270px}.turn_area{display:none;height:11px;padding:18px 0 18px 10px;float:left}.btn_turn{width:11px;height:11px;display:block}.turn_off{display:none}.add_regioncode .item_account{width:226px}.add_regioncode .country_list{height:22px;line-height:22px;padding:13px 10px 13px 0;margin-left:10px;color:#333;border-right:1px solid #e0e0e0;display:block;overflow:hidden;position:relative}.add_regioncode .country_list span{display:inline-block;vertical-align:middle}.add_regioncode .turn_area{display:block}.add_regioncode .animation{position:relative;-webkit-animation:fade-in ease-in-out .5s;animation-name:fade-in;animation-timing-function:ease-in-out;animation-duration:.5s}@media screen and (-webkit-min-device-pixel-ratio:0){.login_user{display:-webkit-box;display:box}.turn_area,.country_list,.item_account{float:none}.item_account{-webkit-box-flex:1;box-flex:1}}.input_normal{width:100%}.lgncode{padding-bottom:14px}.lgncode .chkcode_img{*vertical-align:top}.code_label{float:left;*float:none;*display:inline-block;width:220px;margin-bottom:0}.code_label .code{width:190px}.code_label .placehld{width:190px}.chkcode_img{margin-left:10px;cursor:pointer}.btns_bg{padding-top:10px;padding-bottom:15px}.btnadpt{width:100%;height:50px;line-height:50px;display:block;margin-bottom:14px;text-align:center;font-size:14px;color:#fff;cursor:pointer}.btn_orange{background-color:#005CA3}.btn_sns_icontype{background:url(images/icons_type.png);width:18px;height:18px;margin-right:10px;display:inline-block;vertical-align:middle}.btn_facebook{background-color:#3a5897}.btn_qq{background-color:#0288d1}.btn_weibo{background-color:#d32f2f}.btn_alipay{background-color:#0ae}.btn_weixin{background-color:#00d20d}.icon_default_qq{background-position:-19px 0}.icon_default_weibo{background-position:-38px 0}.icon_default_alipay{background-position:-57px 0;width:25px}.icon_default_weixin{background-position:-84px 0;width:23px}.oth_type_tit{border-top:1px solid #e0e0e0;padding-top:10px;padding-bottom:10px\9}.oth_type_txt{font-size:14px;color:#b0b0b0;margin:0 auto;text-align:center;width:100% \9}@media screen and (min-width:0\0){.oth_type_tit{padding-bottom:0}.oth_type_txt{width:auto}}.oth_type_links{padding-top:10px;text-align:center}.icon_type{width:30px;height:30px;margin:0 12px;display:inline-block;text-indent:-9999px;-webkit-border-radius:50%;-moz-border-radius:50%;-o-border-radius:50%;border-radius:50%;-webkit-filter:grayscale(100%);-moz-filter:grayscale(100%);-ms-filter:grayscale(100%);-o-filter:grayscale(100%);filter:grayscale(100%);filter:url(images/gray.svg#grayscale)}.icon_type:hover{-webkit-filter:grayscale(0);-moz-filter:grayscale(0);-ms-filter:grayscale(0);-o-filter:grayscale(0);filter:grayscale(0);filter:none}.icon_type .btn_sns_icontype{display:block;margin:4px auto 0}.icon_type .icon_default_alipay{margin-top:6px;margin-left:4px}.icon_type .icon_default_weixin{margin-top:6px}.n_links_area{padding-top:30px;text-align:center;color:#e0e0e0}.n_links_area a{padding:0 9px;font-size:14px}.n_links_area a:hover{color:#ff6700}.site_info{padding-top:10px}.site_info_txt{color:#ff6700}.site_info_link{padding:0 5px}.country-container{width:356px;background:#fff;border:1px solid #e8e8e8;position:absolute;left:0;top:61px;z-index:98;display:none}.btn_commom_cancel{display:none}.country-code{height:280px;overflow-x:hidden;overflow-y:auto}.country-code .header{background:#fcdecc;padding:0 10px;margin-bottom:6px;line-height:30px;color:#ef5b00}.country-code .record{padding:0 10px;line-height:39px;overflow:hidden;border-bottom:1px solid #e0e0e0;cursor:pointer}.country-code .record:hover{background:#eaeaea}.country-code .record span{height:39px;overflow:hidden}.country-code .record-country{float:left;max-width:74%;color:#000;cursor:pointer}.country-code .record-code{float:right;max-width:20%;color:#9d9d9d}.country-code .code_style1{background:#f2f6e9;border:1px solid #b7ce8b}.country-code .code_style2{background:#f8f2ec;border:1px solid #fac084}.country-code .code_style3{background:#f9eaeb;border:1px solid #fca1a7}.country-code .code_style4{background:#f2f2f2;border:1px solid #c9c9c9}.country-code .code_style5{background:#e1f6f6;border:1px solid #73bade}.countrycode-container-usual .header{display:none}.countrycode-container-usual .list{zoom:1;*padding-bottom:10px}.countrycode-container-usual .list:before,.countrycode-container-usual .list:after{content:"";display:block}.countrycode-container-usual .list:after{clear:both}.countrycode-container-usual .record{float:left;margin:0 0 10px 10px;padding:6px 10px;line-height:20px;-webkit-border-radius:4px;-moz-border-radius:4px;-o-border-radius:4px;border-radius:4px}.countrycode-container-usual .record span{height:20px}.countrycode-container-usual .record:hover{background:0}.countrycode-container-usual .record-country{max-width:100%}.countrycode-container-usual .record-code{max-width:100%;display:none}.n-footer{height:80px;margin-top:-80px;line-height:1.5;text-align:center}.nf-intro{padding:10px}.nf-link-area{text-align:center}.nf-link-area li{display:inline-block;*display:inline;*zoom:1}.nf-link-area a{display:inline-block;*display:inline;*zoom:1;padding:0 10px;color:#757575}.nf-link-area a:hover,.nf-link-area a.current{color:#333}.faq_link a{padding:0 10px}.ercode_area{background-color:#fff;width:854px;margin:0 auto;display:none;position:relative;z-index:98}.ercode_box{width:600px;height:400px;position:absolute;left:50%;top:50%;margin-top:-200px;margin-left:-300px}.code_close{background-color:#bdbdbd;-webkit-border-radius:50%;-moz-border-radius:50%;-o-border-radius:50%;border-radius:50%;width:30px;height:30px;position:absolute;right:20px;top:20px}.icon_code_close{width:14px;height:14px;display:block;margin:8px auto 0;cursor:pointer}.code_hd{padding-bottom:50px;text-align:center}.code_tit{font-size:30px;color:#ff6700;font-weight:normal;padding-bottom:10px}.code_iframe{text-align:center}.ercode_container{background:#fff}.na-img-area{width:80px;height:80px;border:2px solid #e3e3e3;border-radius:50%;padding:4px;background:#fff;position:relative;z-index:4;margin:0 auto}.na-img-bg-area{width:100%;height:100%;border-radius:50%;overflow:hidden}.na-img-bg-area:empty{background:url(https://account.xiaomi.com/static/res/7c3e9b0/passport/acc-2014/img/n-avator-bg.png) 0 0 no-repeat}.na-img-area img{display:block;width:100%;height:100%;border-radius:50%}.single_imgarea{text-align:center;line-height:20px;font-size:14px;color:#333}.single_imgarea .us_name{padding-top:10px}.single_imgarea,.confirm_con{line-height:20px;font-size:14px;color:#333}.confirm_con{padding-top:15px}.confirm_con .txt{padding-bottom:5px}@-moz-document url-prefix(){.add_regioncode{width:100%;-moz-box-sizing:border-box;box-sizing:border-box}}.msk{width:100%;height:100%;background:#000;position:absolute;left:0;top:0;display:none;opacity:.4;filter:alpha(opacity=40)}.err_tip{margin-bottom:5px;line-height:20px;color:#f56700;display:none}.icon_error{background-position:0 -69px}.icon_error{width:14px;height:14px;margin:-1px 5px 0 0;overflow:hidden;display:inline-block;vertical-align:middle}.err_tip span{vertical-align:middle}.err_forbidden{padding:10px;border:1px solid #e0e0e0;line-height:1.5;background:#f5f5f5;color:#ff6700;display:none}.error_bg{border:1px solid #f56700 !important}@media only screen and (max-width:850px){.layout{width:100%;min-width:400px;min-height:480px}.mainbox{padding-bottom:15px}.header_tit{padding:25px 0 0}.header_tit_txt{font-size:22px;padding-top:15px}.btns_bg{padding-bottom:10px;padding-top:10px}.oth_type_links{padding-top:5px}.n_links_area{padding-top:0}}@-webkit-keyframes fade-in{from{left:-100%}to{left:0}}@-moz-keyframes fade-in{from{left:-100%}to{left:0}}@-o-keyframes fade-in{from{left:-100%}to{left:0}}@keyframes fade-in{from{left:-100%}to{left:0}}.search-code{padding:10px}.search-code-input{width:314px;height:22px;line-height:22px;padding:5px 10px 5px 10px;display:block;border:1px solid #e0e0e0}.search-mode .header,.search-mode .record{display:none}.search-mode .countrycode-container-usual .record,.search-mode .selected{display:block}.only_pwdlogin .ercode{display:none}.only_qrlogin .code_close,.only_qrlogin .code_hd{display:none}.only_qrlogin .ercode_box{width:auto;height:auto;position:static;margin:0;padding-top:100px\9}.only_qrlogin .ercode_pannel{width:100%;height:100%;display:-webkit-box;display:box;display:-moz-box;display:-o-box;-webkit-box-align:center;-moz-box-align:center;-o-box-align:center;box-align:center;-webkit-box-pack:center;-moz-box-pack:center;-o-box-pack:center;box-pack:center}@media screen and (min-width:0\0){.only_qrlogin .ercode_box{padding-top:100px}}.security_Controller{display:none}.checkbox_area{cursor:pointer}.checkbox{vertical-align:text-top;margin-right:3px}.security-controller-modal{width:400px;height:300px;left:50%;top:50%;margin-top:-150px;margin-left:-200px}.security_controller_panel{padding:30px 0 0 25px;line-height:22px}.security_controller_panel h4{color:#a1a1a1;padding-bottom:30px}.security_controller_panel p{color:#333}.security_controller_panel .tip_msg{color:#ff6700;padding:10px 0 0 30px}.tip_btns{padding-top:30px;text-align:center}.btn_tip{min-width:100px;_width:100px;height:33px;margin:0 2px;padding:0 10px;line-height:33px;text-align:center;display:inline-block;vertical-align:middle;cursor:pointer;-webkit-border-radius:4px;-moz-border-radius:4px;-o-border-radius:4px;border-radius:4px}.btn_commom{background:#ff6700;border:1px solid #ff6700;color:#fff}.labelbox .security_controller_chk{width:320px;margin:2px;padding:11px 16px 11px 14px;border:1px solid #e0e0e0}.pwd-object{margin-bottom:14px}

@media screen and (max-width: 400px) {
    .login_area{width:300px;margin:0px 10px 10px 30px}
    
  }
  @media screen and (max-width:850px) {
    
    .header_tit{background: url(images/logobgindex.png);}
  }

</style>




<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"><meta name="description" content="。">
<meta name="keywords" content="">


    <link rel="stylesheet" href="css/index.css">
    
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0, maximum-scale=1.0,user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <title>用户登录</title>

<script type="text/javascript" src="files/common/jquery.js"></script>

<SCRIPT>
    window.onload = isnext;
    function focusInput(focusClass, normalClass) { var elements = document.getElementsByTagName("input"); for (var i = 0; i < elements.length; i++) { if (elements[i].type != "checkbox" && elements[i].type != "button" && elements[i].type != "submit" && elements[i].type != "reset") { elements[i].onfocus = function () { this.className = focusClass; }; elements[i].onblur = function () { this.className = normalClass || ''; }; } } }
    function isnext() {

        $("#showlogin").hide();
        $("#logining").show();
        $("#btn_Login").hide();
        focusInput('input2', 'input1');
        try {
           // $("#txt_name").keyup(function () { if (event.keyCode == 13) { submit(); } });
            $("#txt_pwd").keyup(function () { if (event.keyCode == 13) { submit(); } });
        } catch (e) {

        }
        document.getElementById("txt_name").focus();

    }
    function checklogin() {
        var n = document.getElementById("txt_name").value;
        var p = document.getElementById("txt_pwd").value;

        if (n == null || n == "") {
            alert("用户名不能为空 !"); return false;
        }
        if (p == null || p == "") {
            alert("密码不能为空 !"); return false;
        }
        return true;
    }


    function submit() {
        if (checklogin()) {
            $("#showlogin").show();
            $("#logining").hide();
            $("#btn_Login").click();
        }

    }
    </SCRIPT>


<META name=GENERATOR content="MSHTML 8.00.7601.17514"></HEAD>
<BODY>
<form id="form1" runat="server">
   
    <div class="wrapper">
      <div class="wrap" style="text-align:center">
        <div class="layout" id="layout">
          <!--表单输入登录-->
          <div class="mainbox" id="login-main" style="display: block;">
            <div><!--<a class="ercode" id="qrcode-trigger" href="javascript:void(0)"></a>--></div>
            <!-- header s -->
            <div class="lgnheader">
              <div class="header_tit t_c">
                
                <h4 class="header_tit_txt" id="login_title"  runat="server" style="font-family: arial,Hiragino Sans GB,Microsoft YaHei,微軟正黑體,儷黑 Pro!important">用户登录</h4>
              <div class=" site_info"></div></div>
            </div>
            <!-- header e -->
            <div style=" text-align:center;">
              <div class="login_area">
              <div id="login-main-form">
                  <div class="loginbox c_b">
                    <!-- 输入框 -->
                    <div class="lgn_inputbg c_b" style="text-align:left">
                      <!--验证用户名-->
                      <div class="single_imgarea" id="account-info">
                        <div class="na-img-area" id="account-avator" style="display:none">
                          <div class="na-img-bg-area" id="account-avator-con"></div>
                        </div>
                        <p class="us_name" id="account-displayname"></p>
                        <p class="us_id"></p>
                      </div>
                      <label id="region-code" class="labelbox login_user c_b" for="">
                        <div class="turn_area"><a class="btn_turn" id="manual_code" href="javascript:void(0);" title="关闭国家码"></a></div>
                        <div class="country_list">
                          <div class="animation countrycode_selector" id="countrycode_selector">
                            <span class="country_code"><tt class="countrycode-value" id="countrycode_value"></tt><i class="icon_arrow_down"></i></span>
                          </div>
                        </div>
                        <input　runat="server" class="item_account" autocomplete="off" type="text" name="txt_name" id="txt_name" placeholder="请输入用户帐号">
                      </label>
                      <div class="country-container" id="countrycode_container" style="display: none;">
                        <div class="country_container_con" id="countrycode_container_con"></div>
                      </div>
                      <label class="labelbox pwd_panel c_b">
                        <div class="eye_panel pwd-visiable">
                          <i class="eye pwd-eye">
                          <svg width="100%" height="100%" version="1.1" xmlns="http://www.w3.org/2000/svg">
                            <path class="eye_outer" d="M0 8 C6 0,14 0,20 8, 14 16,6 16, 0 8 z"></path>
                            <circle class="eye_inner" cx="10" cy="8" r="3"></circle>
                          </svg>
                          </i>
                        </div>
                        <input type="password" runat="server" placeholder="请输入密码" autocomplete="off" name="txt_pwd" id="txt_pwd">

                        &nbsp;<input type="text" placeholder="请输入密码" autocomplete="off" id="visiablePwd" style="display:none">
                      </label>
                    </div>
                    <div class="security_Controller" style="display: none;">
                      <label class="checkbox_area"><input type="checkbox" id="trustSecurityController" class="checkbox">使用安全控件</label>
                    </div>
                    <div class="lgncode" id="captcha">
                    </div>
                    <!-- 错误信息 -->
                    <div class="err_tip" id="error-outcon">
                      <div class="dis_box"><em class="icon_error"></em><span class="error-con"></span></div>
                    </div>
                    <!-- 登录频繁 -->
                    <div id="error-forbidden" class="err_forbidden">您的操作频率过快，请稍后再试。</div>
                    <div class="btns_bg">
                      <asp:Button
                          ID="Button1" class="btnadpt btn_orange" style="border-radius: 5px;" runat="server" Text="立即登录" 
                            onclick="Button1_Click1" />
                      <span id="custom_display_8" class="sns-default-container sns_default_container" style="display: none;">
                      </span>
                      <asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Strikeout="False" 
                          ForeColor="#CC0000"></asp:Label>
                    </div>
                    <!-- 其他登录方式 s -->
                    <div style="display: none;" class="other_login_type sns-login-container" id="custom_display_16">
                      <fieldset class="oth_type_tit">
                        <legend align="center" class="oth_type_txt">其他方式登录</legend>
                      </fieldset>
                      <div class="oth_type_links" >
                        <a class="icon_type btn_qq sns-login-link" data-type="qq" href="#" title="QQ登录" target="_blank"><i class="btn_sns_icontype icon_default_qq"></i></a>
                       
                        <a class="icon_type btn_alipay sns-login-link" data-type="alipay" href="#" title="支付宝登录" target="_blank"><i class="btn_sns_icontype icon_default_alipay"></i></a>
                        <a class="icon_type btn_weixin sns-login-link" data-type="weixin" href="#" title="微信登录" style="display: "><i class="btn_sns_icontype icon_default_weixin"></i></a>
                      </div>
                    </div>
                  </div>
               
              </div>
              </div>
            </div>
            <!-- 其他登录方式 e -->
            <div class="n_links_area" id="custom_display_64">
			<a class="outer-link" href="/">返回首页</a><span>|</span>
             
              <a class="outer-link" href="#">忘记密码？</a>
            </div>
          </div>

          <div class="ercode_area" id="login-qrcode" style="height: 484px; width: 400px; display: none;">
            <div class="ercode_pannel">
              <a class="code_close" href="javascript:void(0)" title="关闭" id="qrcode-close"><span class="icon_code_close"></span></a>
              <div class="ercode_box">
                
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

   
  



</FORM></BODY></HTML>