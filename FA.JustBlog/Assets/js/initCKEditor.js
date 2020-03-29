var editor;
function createEditor(languageCode) {
    if (editor)
        editor.destroy();
    //alert(data);
    //Replace <textarea id="PostContent" with a CKEditor, use the default configuration
    editor = CKEDITOR.replace('PostContent', {
        language: languageCode,
        on: {
            instanceReady: function () {

                // Wait until the editor is ready to set the language.
                var languages = document.getElementById('languages');
                languages.value = this.langCode;
                languages.disabled = false;
            }
        }
    });

}
//At the beginning, load the default language.
createEditor('');