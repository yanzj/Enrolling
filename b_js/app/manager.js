﻿function load() {
    try {
        init();
        clear_student_status();
        var pk_batch_no = $("#pk_batch_no").val();//初始值由服务器回传网页时生成
        var pk_staff_no = $("#pk_staff_no").val();//初始值由服务器回传网页时生成

        if (pk_batch_no == null || $.trim(pk_batch_no).length == 0 || pk_staff_no == null || $.trim(pk_staff_no).length == 0) {
            alert("无效的参数");
            return;
        }
        //NO:3 该批次是否开始服务
        $.ajax({
            url: "appserver/manager.aspx",
            type: "get",
            dataType: "text",
            data: { "cs": "get_freshbatch_isrun","pk_batch_no":pk_batch_no },
            success: function (data) {
                var json_data = JSON.parse(data);
                if (json_data.code == 'success') {
                    if (json_data.data == true) {
                        //NO:5操作员是否在该批次有效
                        $.ajax({
                            url: "appserver/manager.aspx",
                            type: "get",
                            dataType: "text",
                            data: { "cs": "get_freshoperator_isauth", "pk_batch_no": pk_batch_no, "pk_staff_no": pk_staff_no },
                            success: function (data) {
                                var json_data = JSON.parse(data);
                                if (json_data.code == 'success') {
                                    if (json_data.data == true) {
                                        //NO:2获取该批次迎新基本数据
                                        $.ajax({
                                            url: "appserver/manager.aspx",
                                            type: "get",
                                            dataType: "text",
                                            data: { "cs": "get_freshbatch", "pk_batch_no": pk_batch_no},
                                            success: function (data) {
                                                var json_data = JSON.parse(data);
                                                if (json_data.code == 'success') {
                                                    $('#batch_year').html(json_data.data.Year + "年");
                                                    $('#batch_name').html(json_data.data.Batch_Name);
                                                    $('#batch_service_time').html(json_data.data.Service_Begin + "~" + json_data.data.Service_End);
                                                    //NO:7 获取操作员事务操作列表
                                                    $.ajax({
                                                        url: "appserver/manager.aspx",
                                                        type: "get",
                                                        dataType: "text",
                                                        data: { "cs": "get_freshoperator_auth_affair_list", "pk_batch_no": pk_batch_no,"pk_staff_no":pk_staff_no },
                                                        success: function (data) {
                                                            var json_data = JSON.parse(data);
                                                            if (json_data.code == 'success') {
                                                                $('#admin-navbar-side ul li').remove();
                                                                if (json_data.data != null && json_data.data.length > 0) {
                                                                    for (var i = 0; i < json_data.data.length; i++) {
                                                                        var name = json_data.data[i].Affair_Name;
                                                                        $('#admin-navbar-side ul').append('<li class="layui-nav-item"><a href="javascript:void(0)" onclick="goto_affair(\'' + json_data.data[i].PK_Affair_NO + '\')">' + name + '</a></li>');
                                                                    }
                                                                    goto_affair(json_data.data[0].PK_Affair_NO);
                                                                } else {
                                                                    alert('未获取到有效的操作员事务操作列表');
                                                                }
                                                            } else {
                                                                alert(json_data.message);
                                                            }
                                                        },
                                                        error: function (data) {
                                                            alert("错误");
                                                        }
                                                    });
                                                } else {
                                                    alert(json_data.message);
                                                }
                                            },
                                            error: function (data) {
                                                alert("错误");
                                            }
                                        });
                                    } else {
                                        alert("本批次迎新未给您授权操作");
                                    }
                                } else {
                                    alert(json_data.message);
                                }
                            },
                            error: function (data) {
                                alert("错误");
                            }
                        });
                    } else {
                        alert("本批次迎新没有开始服务");
                    }
                } else {
                    alert(json_data.message);
                }
            },
            error: function (data) {
                alert("错误");
            }
        });
    }
    catch (e) {
        alert("错误："+e.message);
    }
}

//初始化页面
function init(){
    $('#iframeId').hide();
    $('#admin-navbar-side ul li').remove();
    $('#batch_year').html('');
    $('#batch_name').html('');
    $('#batch_service_time').html('');

    $('#affair_name').html('');
    $('#affair_willcount').html('');
    $('#affair_havecount').html('');
}

//清除学生状态区域
function clear_student_status(){
    $('#xs_xh').html('');
    $('#xs_xm').html('');
    $('#xs_xb').html('');
    $('#xs_sfzh').html('');
    $('#xs_xl').html('');
    $('#xs_xy').html('');
    $('#xs_zy').html('');
    $('#xs_nj').html('');
    $('#xs_bj').html('');
    $('#xs_bzr').html('');
    $('#affair_list').html('');

}

//装入某迎新事务操作界面
function goto_affair(PK_Affair_NO) {
    try {
        var pk_batch_no = $("#pk_batch_no").val();
        var pk_staff_no = $("#pk_staff_no").val();

        //10、迎新事务定义 获取某迎新事务
        $.ajax({
            url: "appserver/manager.aspx",
            type: "get",
            dataType: "text",
            data: { "cs": "get_affair","pk_affair_no": PK_Affair_NO },
            success: function (data) {
                var json_data = JSON.parse(data);
                if (json_data.code == 'success') {
                    var name=json_data.data.Affair_Name;
                    //NO:8&9 获取预操作总人数和已操作总人数
                    $.ajax({
                        url: "appserver/manager.aspx",
                        type: "get",
                        dataType: "text",
                        data: { "cs": "get_freshoperator_affair_students_count", "pk_batch_no": pk_batch_no, "pk_staff_no": pk_staff_no, "pk_affair_no": PK_Affair_NO },
                        success: function (data) {
                            var json_data = JSON.parse(data);
                            if (json_data.code == 'success') {
                                $('#affair_name').html(name);
                                $('#affair_willcount').html(json_data.data.will_count);
                                $('#affair_havecount').html(json_data.data.finish_count);
                                $('#admin-navbar-side').attr("pk_affair_no", PK_Affair_NO);//绑定当前操作事务编号
                                $('#iframeId').hide();
                                clear_student_status();//清除学生状态
                            } else {
                                alert(json_data.message);
                            }
                        },
                        error: function (data) {
                            alert("错误");
                        }
                    });
                } else {
                    alert(json_data.message);
                }
            },
            error: function (data) {
                alert("错误");
            }
        });
    }
    catch (e) {
        alert("错误：" + e.message);
    }
}

function find(){
    try{
        var pk_sno = $("#find_xh").val();
        if (pk_sno == null || $.trim(pk_sno).length == 0) {
            alert("请输入学号");
            return;
        }
        var pk_batch_no = $("#pk_batch_no").val();
        var pk_staff_no = $("#pk_staff_no").val();

        var pk_affair_no=$('#admin-navbar-side').attr("pk_affair_no");//当前操作事务编号

        //NO:11 校验学生迎新批次
        $.ajax({
            url: "appserver/manager.aspx",
            type: "get",
            dataType: "text",
            data: { "cs": "check_student_in_freshbatch", "pk_batch_no": pk_batch_no, "pk_sno": pk_sno},
            success: function (data) {
                var json_data = JSON.parse(data);
                if (json_data.code == 'success') {
                    if(json_data.data==true){
                        //NO:12 校校验操作员操作对象
                        $.ajax({
                            url: "appserver/manager.aspx",
                            type: "get",
                            dataType: "text",
                            data: { "cs": "check_operator_object", "pk_affair_no": pk_affair_no,"pk_staff_no":pk_staff_no, "pk_sno": pk_sno},
                            success: function (data) {
                                var json_data = JSON.parse(data);
                                if (json_data.code == 'success') {
                                    if(json_data.data==true){
                                        //NO:13 校验学生事务操作条件
                                        $.ajax({
                                            url: "appserver/manager.aspx",
                                            type: "get",
                                            dataType: "text",
                                            data: { "cs": "check_student_affair_condition", "pk_affair_no": pk_affair_no,"pk_sno": pk_sno},
                                            success: function (data) {
                                                var json_data = JSON.parse(data);
                                                if (json_data.code == 'success') {
                                                    if(json_data.data==true){
                                                        alert('ok');
                                                    }else{
                                                        alert('学号为'+pk_sno+' 的同学目前不具备操作当前事务的条件，请检查当前事务的前置条件是否具备')
                                                    }
                                                } else {
                                                    alert(json_data.message);
                                                }
                                            },
                                            error: function (data) {
                                                alert("错误");
                                            }
                                        });
                                    }else{
                                        alert('当前操作员在当前事务中不具备操作学号为'+pk_sno+' 同学的权限')
                                    }
                                } else {
                                    alert(json_data.message);
                                }
                            },
                            error: function (data) {
                                alert("错误");
                            }
                        });
                    }else{
                        alert('学号：'+pk_sno+' 同学不是本迎新批次的学生')
                    }
                } else {
                    alert(json_data.message);
                }
            },
            error: function (data) {
                alert("错误");
            }
        });

    }
    catch (e) {
        alert("错误：" + e.message);
    }
}