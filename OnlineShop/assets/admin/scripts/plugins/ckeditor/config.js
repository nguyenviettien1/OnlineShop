/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowserUrl = '/assets/admin/scripts/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowserUrl = '/assets/admin/scripts/plugins/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowserUrl = '/assets/admin/scripts/plugins/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/assets/admin/scripts/plugins/ckfinder/core/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowseFlashUploadUrl = '/assets/admin/scripts/plugins/ckfinder/core/aspx/connector.aspx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor(null, '/assets/admin/scripts/plugins/ckfinder');
};
