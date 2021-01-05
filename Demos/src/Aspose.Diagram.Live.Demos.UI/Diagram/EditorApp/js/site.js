var xhost = "/api/";
var sessionId = "";
var exportAction = "AsposeEditor/Export";
var importAction = "AsposeEditor/Import";
var uploadOpenAction = "AsposeEditor/Open";

function AlterDanger(msg) {
    bootoast({
        message: msg,
        type: 'danger',
        position: 'top-center',
        timeout: 1
    })
};

function AlterSucess(msg) {
    bootoast({
        message: msg,
        type: 'success',
        position: 'top-center',
        timeout: 1
    });
};

function XPost(url, data, success) {
    $.bootstrapLoading.start({ loadingTips: "" });
    $.ajax({
        url: xhost + url,
        type: "post",
        data: JSON.stringify(data),
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $.bootstrapLoading.end();
            if (res.code == 200) {
                success(res)
                sessionId = res.FolderName;
            } else {
                window.parent.fileDrop.reset();
                window.parent.showAlert(e.responseJSON.Message);
                window.parent.ShowReportModal(e.responseJSON);
                window.parent.closeIframe();
                //AlterDanger("Error:" + res.message);
            }
        },
        error: function (e) {
            window.parent.fileDrop.reset();
            window.parent.showAlert(e.responseJSON.Message);
            window.parent.ShowReportModal(e.responseJSON);
            window.parent.closeIframe();
        }
    });
};

function XGet(url, data, success) {
    $.bootstrapLoading.start({ loadingTips: "" });
    $.ajax({
        url: xhost + url,
        type: "get",
        data: JSON.stringify(data),
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $.bootstrapLoading.end();
            if (res.code == 200) {
                success(res);
            } else {
                AlterDanger("Error:" + res.message);
            }
        },
        error: function (e) {
            AlterDanger(JSON.stringify(e));
            $.bootstrapLoading.end();
        }
    });
};


function XDownload(url, filename, data) {
    $.bootstrapLoading.start({ loadingTips: "" });
    url = xhost + url + "?SessionId=" + sessionId;
    var xhr = createXHR();
    if (!data) {
        xhr.open('GET', url);
    } else {
        xhr.open('POST', url, true);
    }

    xhr.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');
    xhr.responseType = 'blob';
    xhr.onload = function () {
        //alert(xhr.status);
        if (xhr.status === 200) {
            var downloadFileName = filename;
            try {
                downloadFileName = xhr.getResponseHeader('Content-Disposition').split(';')[1].split('filename=')[1];
                downloadFileName = decodeURI(downloadFileName).replace(/\"/g, "");
            } catch (e) {

            }
            //console.log(xhr.getAllResponseHeaders());
            var blob = new Blob([xhr.response]);
            if (window.navigator && window.navigator.msSaveOrOpenBlob) {
                window.navigator.msSaveOrOpenBlob(blob, downloadFileName);
            } else {
                var urlBlob = window.URL.createObjectURL(blob);

                var link = document.createElement('a');
                link.href = urlBlob;
                link.style.display = 'none';

                link.setAttribute('download', downloadFileName);
                link.click();
                window.URL.revokeObjectURL(urlBlob);
            }
        } else {
            mxUtils.alert("Download fail,internal server error");
        }

        $.bootstrapLoading.end();
    };

    xhr.addEventListener('error', HandleError);

    if (!data) {
        xhr.send();
    } else {
        xhr.send(JSON.stringify(data));
    }
}

function HandleError(e) {
    $.bootstrapLoading.end();
}

function createXHR() {
    var xhr;

    if (window.XMLHttpRequest) {
        xhr = new XMLHttpRequest();
    } else {
        xhr = new ActiveXObject("Microsoft.XMLHTTP");
    }

    return xhr;
}



function XDelete(url, data, success, IsNeedLogin) {
    if (IsNeedLogin) {
        IsNeedLogin = true;
    }
    $.ajax({
        url: xhost + url,
        type: "delete",
        data: JSON.stringify(data),
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            if (res.code == 200) {
                success(res)
            } else {
                AlterDanger("Error:" + res.message);
            }
        },
        error: function (e) {
            AlterDanger(JSON.stringify(e));
        }
    });
};

function createSvgImage(w, h, data, coordWidth, coordHeight) {
    var tmp = unescape(encodeURIComponent(
        '<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">' +
        '<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="' + w + 'px" height="' + h + 'px" ' +
        ((coordWidth != null && coordHeight != null) ? 'viewBox="0 0 ' + coordWidth + ' ' + coordHeight + '" ' : '') +
        'version="1.1">' + data + '</svg>'));

    return new mxImage('data:image/svg+xml;base64,' + ((window.btoa) ? btoa(tmp) : Base64.encode(tmp, true)), w, h)
};

var storage = window.localStorage;

function setlocalStorage(key, value) {
    storage.setItem(key, value);
}

function getLocalStorge(key) {
    return storage.getItem(key);
}

function removeLocalStorge(key) {
    storage.removeItem(key);
}

function clearLocalStorge() {
    storage.clear();
}