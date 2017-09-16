(function () {
    $(function () {
        'use strict';
        var _articleInfoService = abp.services.app.articleInfo;
        var _$form = $('#createOrEditArticleForm');
        $("#SaveArticle").click(function () {
            if (!_$form.valid()) {
                return;
            }
            for (let instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            var articleInfo = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            abp.ui.setBusy(_$form);
            _articleInfoService.createOrEditArticleInfo(articleInfo).done(function () {
                location.href = "/ArticleInfoes/Index";
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        });

        //server-side upload handler:
        var url = abp.appPath + 'FileUpload/UploadImageFile';
        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            maxFileSize: 999000,
            done: function (e, response) {
                var jsonResult = response.result;
                if (jsonResult.success) {
                    //var fileUrl = abp.appPath + 'AppAreaName/DemoUiComponents/GetFile?id=' + jsonResult.result.id + '&contentType=' + jsonResult.result.contentType;
                    var uploadedFile = '<a href="' + jsonResult.result.url + '" target="_blank">文件上传</a><br/><br/>' + ' Free text: ' + jsonResult.result.defaultFileUploadTextInput;
                    $("#CoverImg").val(jsonResult.result.url);
                    $("#ShowCoverImg").attr("src", jsonResult.result.url)
                    abp.libs.sweetAlert.config.info.html = true;
                    //abp.message.info(uploadedFile, "上传完成");
                    abp.notify.info(uploadedFile,"上传完成");
                } else {
                    abp.message.error(jsonResult.error.message);
                }
            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            }
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');
    })
})()