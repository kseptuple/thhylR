function jump(page, anchor) {
    if (!/^[a-zA-Z0-9-_]+$/.test(page)) {
        page = "main";
        anchor = "";
    }
    if (!/^[a-zA-Z0-9-_]+$/.test(anchor)) {
        anchor = "";
    }
    var path = "contents/" + page + ".html";
    if (anchor !== "") {
        path += "#" + anchor;
    }
    var iframeElement = document.getElementById("content");
    iframeElement.src = path;
    iframeElement.contentWindow.scrollTo(0, 0);
}
