$(document).ready(function() {
    if (GetQueryString("FileName") != null) {
        var fileName = GetQueryString("FileName");
        var folderName = GetQueryString("FolderName")
        var data = { "FileName": fileName, "FolderName": folderName };
        XPost(uploadOpenAction + "?sessionId=" + folderName, data, function(res) {
            var xml = res.data;
            importedCells = graph.page.importXml(xml, 0, 0, true);
            graph.actions.get('selectAll'.toLowerCase()).funct();
            graph.actions.get('setAppName'.toLowerCase()).funct(decodeURI(fileName));
            undoManager.clear();
            initPageScroll();
            $("#zoom_val").text(graph.view.scale * 100 + "%");
        });
    }
});


function GetQueryString(name) {
    var url = window.location.href;
    if (url.indexOf("?") == -1) { return null; }
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = url.split("?")[1].match(reg);
    if (r != null) return r[2];
    return null;
}