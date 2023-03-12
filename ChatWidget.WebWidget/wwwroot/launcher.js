(function (args) {
    window.onload = function () {
        var iframe = document.createElement('iframe');
        iframe.frameBorder = 0;
        iframe.setAttribute("allowtransparency", "true");
        iframe.style = "position:fixed; right: 0; bottom: 0; height:100px;width:100px;z-index: 9999";
        iframe.src = "http://localhost:42467/Widget";
        document.body.appendChild(iframe);

        window.addEventListener('message', e => {
            IframeMessageHandler(iframe, e.data);
        }, false);
    };

    function IframeMessageHandler(iframe, data) {
        if (data.IsOpenedChat) {
            if (data.IsMobile) {
                iframe.style.width = "100%";
                iframe.style.height = "100%";
            } else {
                iframe.style.width = "420px";
                iframe.style.height = "640px";
            }
        }
        else if (data.HasWelcomeMessage) {
            iframe.style.width = "350px";
            iframe.style.height = "160px";
        }
        else {
            iframe.style.width = "100px";
            iframe.style.height = "100px";
        }
    }
    var utils = {
        getBotId() {
            const urlParams = new URLSearchParams(window.location.search);
            return urlParams.get('id');
        }
    }
})(window["args"]);