(function () {
    $(function () {
        var _articleService = abp.services.app.articleInfo;
        var _$modal = $('#ArticleCreateModal');
        var _$form = _$modal.find('form');
        var _$articleTable = $("#articleTable");
        _$articleTable.bootstrapTable({
            //url: "/ArticleInfoes/GetArticleInfoes",         //请求后台的URL（*）
            abpMethod: _articleService.getAllArticles,
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
            uniqueId: "id",                     //每一行的唯一标识，一般为主键列
            cardView: false,                    //是否显示详细视图
            detailView: false,
            clickToSelect: true,
            columns: [
                {
                    field: 'title',
                    title: '标题'
                },
                {
                    field: 'articleClassify',
                    title: '分类',
                    formatter: function (data) {
                        return data.className;
                    }
                },
                {
                    field: 'intro',
                    title: '简介',
                    formatter: function (data) {
                        return abp.utils.truncateString(data, 50);
                    }
                },
                {
                    field: 'lastModificationTime',
                    title: '最后更新日期',
                    formatter: function (data) {
                        return moment(data).format("YYYY-MM-DD HH:mm:ss")
                    }
                },
                {
                    field: 'creationTime',
                    title: '创建日期',
                    formatter: function (data) {
                        return moment(data).format("YYYY-MM-DD HH:mm:ss")
                    }
                },
                {
                    field: "operator",
                    title: "操作",
                    align: "center",
                    formatter: function (value, row, index) {
                        return '<a name="edit-article" class="btn btn-default btn-sm" href="ArticleInfoes/CreateOrEdit?id=' + row.id + '">编辑</a>' +
                            '<a class="btn btn-warning btn-sm delete-article" data-article-id="' + row.id + '">删除</a>'
                    }
                }
            ],
            onLoadSuccess: function () {
                $(".delete-article").click(function () {
                    var articleId = $(this).attr("data-article-id");
                    deleteArticle(articleId);
                })
            }

        })

        function refreshArticleList() {
            _$articleTable.bootstrapTable('refresh');
        };
        function deleteArticle(id) {
            abp.message.confirm(
                "确认删除选中项？",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _articleService.deleteArticleInfo({
                            id: id
                        }).done(function () {
                            refreshArticleList();
                        });
                    }
                }
            );
        };
    })
})()