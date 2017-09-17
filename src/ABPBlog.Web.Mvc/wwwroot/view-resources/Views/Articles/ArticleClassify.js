(function () {
    $(function () {

        var _classService = abp.services.app.articleClassify;
        var _$modal = $('#ClassifyCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('.delete-classify').click(function () {
            var classifyId = $(this).attr("data-classify-id");
            var classifyName = $(this).attr('data-classify-name');

            deleteRole(classifyId, classifyName);
        });

        $('.edit-classify').click(function (e) {
            var classifyId = $(this).attr("data-classify-id");
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'ArticleClassifies/EditCLassifyModal?classifyId=' + classifyId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#ClassifyEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
            var classifyInfo = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            abp.ui.setBusy(_$modal);
            _classService.createOrEditArticleClassify(classifyInfo).done(function () {
                _$modal.modal('hide');
                refreshClassifyList();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshClassifyList() {
            location.reload(true); //reload page to see new role!
        }

        function deleteRole(roleId, roleName) {
            abp.message.confirm(
                "确认删除分类：" + roleName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _classService.deleteArticleClassify({
                            id: roleId
                        }).done(function () {
                            refreshClassifyList();
                        });
                    }
                }
            );
        }
    });
})();