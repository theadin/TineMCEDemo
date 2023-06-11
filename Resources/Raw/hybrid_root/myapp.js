function SendMessageToCSharp(message) {
    HybridWebView.SendRawMessageToDotNet('NEW_CONTENT' + message);
}

function SendMessageToCSharp2() {
    var message = tinyMCE.activeEditor.getContent();
    HybridWebView.SendRawMessageToDotNet(message);
}

function SendToJs(message) {
    document.getElementById('myTextArea').value = message;

    var bubu = tinymce.init({
        selector: 'textarea',
        plugins: 'anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount',
        toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table | align lineheight | numlist bullist indent outdent | emoticons charmap | removeformat',
        mobile: {
            menubar: true
        },
        init_instance_callback: function (editor) {
            editor.on('Change', function (e) {
                SendMessageToCSharp((editor.getContent()));
            });
        }
    });
}

HybridWebView.SendRawMessageToDotNet('PAGE_LOADING');