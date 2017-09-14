(function () {
    $(function () {
        var _articleService = abp.services.app.articleInfo;
        var _$modal = $('#ArticleCreateModal');
        var _$form = _$modal.find('form');
        var _$articleTable = $("#articleTable");
        _$articleTable.bootstrapTable({
            url: "/ArticleInfoes/GetArticleInfoes",         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolBar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: function (params) {
                var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                    limit: params.limit,   //页面大小
                    offset: params.offset,  //页码
                    //departmentname: $("#txt_search_departmentname").val(),
                    //statu: $("#txt_search_statu").val()
                };
                return temp;
            },//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100, "All"],        //可供选择的每页的行数（*）
            strictSearch: true,
            showColumns: false,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            //height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "Id",                     //每一行的唯一标识，一般为主键列
            cardView: false,                    //是否显示详细视图
            detailView: false,
            columns: [
                {
                    checkbox: true
                },
                {
                    field: 'Title',
                    title: '标题'
                },
                {
                    field: 'ClassifyId',
                    title: '分类'
                },
                {
                    field: 'UpdateTime',
                    title: '最后更新日期'
                },
                {
                    field: 'CreationTime',
                    title: '创建日期'
                },
                {
                    field: "Operator",
                    title: "操作",
                    align: "center",
                    formatter: function (value, row, index) {
                        return '<a  class=" btn btn-default btn-sm">编辑</a>' +
                            '<a class=" btn btn-warning btn-sm">删除</a>'
                    }
                }
            ]
        })
    })
})()