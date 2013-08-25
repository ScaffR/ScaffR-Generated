/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */
(function () {
    $(function () {
 
        CKEDITOR.editorConfig = function( config ) {
	        // Define changes to default configuration here.
	        // For the complete reference:
	        // http://docs.ckeditor.com/#!/api/CKEDITOR.config
	        // The toolbar groups arrangement, optimized for two toolbar rows.
	        config.toolbarGroups = [
		        { name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		        { name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
		        { name: 'links' },
		        { name: 'insert' },
		        { name: 'forms' },
		        { name: 'tools' },
		        { name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
		        { name: 'others' },
		        '/',
		        { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		        { name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ] },
		        { name: 'styles' },
		        { name: 'colors' },
		        { name: 'about' }
	        ];
            
	        // Remove some buttons, provided by the standard plugins, which we don't
	        // need to have in the Standard(s) toolbar.
	        config.removeButtons = 'Underline,Subscript,Superscript';

	        // Se the most common block elements.
	        config.format_tags = 'p;h1;h2;h3;pre';
	        config.autoParagraph = false;
	        // Make dialogs simpler.
	        config.removeDialogTabs = 'image:advanced;link:advanced';
            
	        config.toolbar_Full = [
                ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript', '-', 'Format'],
                ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
                '/',
                ['Image', 'Table', 'HorizontalRule', 'SpecialChar'],
                ['Cut', 'Copy', 'Paste', 'PasteText', '-', 'SpellChecker'], //, 'Scayt'
                ['Undo', 'Redo'],
                ['Link', 'Unlink'],
                ['MediaEmbed']
	        ];
	        config.toolbar_Basic = [
                ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
                '/',
                ['Table', 'HorizontalRule', 'SpecialChar'],
                ['Cut', 'Copy', 'Paste', 'PasteText', '-', 'SpellChecker'], //, 'Scayt'
                ['Undo', 'Redo'],
                ['Link', 'Unlink']
	        ];

            config.contentsCss = '/Scripts/lib/ckeditor/contents.css';
            config.skin = 'moono,/Scripts/lib/ckeditor/skins/moono/';

        };
       
        $.each(CKEDITOR.instances, function (i, obj) {
            var id = obj.name,
                el = $('#' + id),
                toolbarCfg = el.attr('data-toolbar'),
                useCKFinder = el.attr('data-ckfinder');

            /*
            obj.destroy();
            el.ckeditor($.noop, {
                toolbar: toolbarCfg
            });
            //CKEDITOR.replace(id, { toolbar: toolbarCfg });
            */
        });
    });
})();