const VIEWABLE_EXTENSIONS = [
    'VSD', 'VSDX', 'VSX', 'VTX', 'VDX', 'VSSX', 'VSTX', 'VSDM', 'VSSM', 'VSTM'
];

// filedrop component
var fileDrop = {};
var fileDrop2 = {};

$.extend($.expr[':'], {
    isEmpty: function (e) {
        return e.value === '';
    }
});

// Restricts input for the set of matched elements to the given inputFilter function.
(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));

function showLoader() {
    $('.progress > .progress-bar').html('15%');
    $('.progress > .progress-bar').css('width', '15%');
    $('#loader').removeClass("hidden");
    hideAlert();
}

function hideLoader() {
    $('#loader').addClass("hidden");
}

function generateViewerLink(res) {
    var data = res.Data;
    return encodeURI(o.ViewerPathWF + data.FolderName) + '?FileName=' + encodeURIComponent(data.FileName);
}

function generateEditorLink(res) {
    var data = res.Data;
    return encodeURI(o.EditorPathWF + '?FolderName=' + data.FolderName + '&FileName=') + encodeURIComponent(data.FileName);
}
function generateNewEditorLink() {
    return encodeURI(o.EditorPathWF);
}

function sendPageView(url) {
    if ('ga' in window)
        try {
            var tracker = ga.getAll()[0];
            if (tracker !== undefined) {
                tracker.send('pageview', url);
            }
        } catch (e) {
            /**/
        }
}

function workSuccess(res, textStatus, xhr) {
    hideLoader();

    if (res.Code === 200) {
        var data = res.Data;
        $('#WorkPlaceHolder').addClass('hidden');
        $('.appfeaturesectionlist').addClass('hidden');
        $('.howtolist').addClass('hidden');
        $('.app-features-section').addClass('hidden');
        $('.app-product-section').addClass('hidden');
        $('#TextPlaceHolder').addClass('hidden');

        $('#DownloadPlaceHolder').removeClass('hidden');
        $('#OtherApps').removeClass('hidden');

        if (o.ReturnFromViewer === undefined) {
            const pos = o.AppDownloadURL.indexOf('?');
            const url = pos === -1 ? o.AppDownloadURL : o.AppDownloadURL.substring(0, pos);
            sendPageView(url);
        }

        var url = encodeURI(o.APIBasePath + `Storage/Download`) + `?file=${encodeURIComponent(data.FileName)}` + `&folder=${encodeURIComponent(data.FolderName)}`;
        $('#DownloadButton').attr('href', url);
        o.DownloadUrl = url;

        if (o.ShowViewerButton) {
            let viewerlink = $('#ViewerLink');
            let dotPos = data.FileName.lastIndexOf('.');
            let ext = dotPos >= 0 ? data.FileName.substring(dotPos + 1).toUpperCase() : null;
            if (ext !== null && viewerlink.length && VIEWABLE_EXTENSIONS.indexOf(ext) !== -1) {
                viewerlink.on('click', function (evt) {
                    evt.preventDefault();
                    evt.stopPropagation();
                    openIframe(generateViewerLink(data), '/viewer', '/diagram/view');
                });
            } else {
                viewerlink.hide();
                $(viewerlink[0].parentNode.previousElementSibling).hide(); // div.clearfix
            }
        }
    } else {
        showAlert(res.Status);
        ShowReportModal(res);
    }
}

function sendEmail() {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var email = $('#EmailToInput').val();
    if (!email || !re.test(String(email).toLowerCase())) {
        window.alert('Please specify the valid email address!');
        return;
    }

    var data = {
        appname: o.AppName,
        email: email,
        url: o.DownloadUrl,
        title: $('#ProductTitle')[0].innerText
    };

    $('#sendEmailModal').modal('hide');
    $('#sendEmailButton').addClass('hidden');

    $.ajax({
        method: 'POST',
        url: '/diagram/sendemail',
        data: data,
        dataType: 'json',
        success: (data) => {
            showMessage(data.message);
        },
        complete: () => {
            $('#sendEmailButton').removeClass('hidden');
            hideLoader();
        },
        error: (data) => {
            showAlert(data.responseJSON.message);
        }
    });
}

function sendFeedback(text) {
    var msg = (typeof text === 'string' ? text : $('#feedbackText').val());
    if (!msg || msg.match(/^\s+$/) || msg.length > 1000) {
        return;
    }

    var data = {
        appname: o.AppName,
        text: msg
    };

    if (!text) {
        if ('ga' in window) {
            try {
                var tracker = window.ga.getAll()[0];
                if (tracker !== undefined) {
                    tracker.send('event', {
                        'eventCategory': 'Social',
                        'eventAction': 'feedback-in-download'
                    });
                }
            } catch (e) {
            }
        }
    }

    $.ajax({
        method: "POST",
        url: '/Diagram/sendfeedback',
        data: data,
        dataType: "json",
        success: (data) => {
            showMessage(data.message);
            $('#feedback').hide();
        },
        error: (data) => {
            showAlert(data.responseJSON.message);
        }
    });
}

function hideAlert() {
    $('#alertMessage').addClass("hidden");
    $('#alertMessage').text("");
    $('#alertSuccess').addClass("hidden");
    $('#alertSuccess').text("");
}

function showAlert(msg) {
    hideLoader();
    $('#alertMessage').html(msg);
    $('#alertMessage').removeClass("hidden");
    $('#alertMessage').fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100);
}

function showMessage(msg) {
    hideLoader();
    $('#alertSuccess').text(msg);
    $('#alertSuccess').removeClass("hidden");
}

(function ($) {
    $.QueryString = (function (paramsArray) {
        let params = {};

        for (let i = 0; i < paramsArray.length; ++i) {
            let param = paramsArray[i]
                .split('=', 2);

            if (param.length !== 2)
                continue;

            params[param[0]] = decodeURIComponent(param[1].replace(/\+/g, " "));
        }

        return params;
    })(window.location.search.substr(1).split('&'))
})(jQuery);

function progress(evt) {
    if (evt.lengthComputable) {
        var max = evt.total;
        var current = evt.loaded;

        var percentage = Math.round((current * 100) / max);
        percentage = (percentage < 15 ? 15 : percentage) + '%';

        $('.progress > .progress-bar').html(percentage);
        $('.progress > .progress-bar').css('width', percentage);
    }
}

function removeAllFileBlocks() {
    fileDrop.droppedFiles.forEach(function (item) {
        $('#fileupload-' + item.id).remove();
    });
    fileDrop.droppedFiles = [];
    hideLoader();
}

function openIframe(url, fakeUrl, pageViewUrl) {
    // push fake state to prevent from going back
    window.history.pushState(null, null, fakeUrl);

    // remove body scrollbar
    $('body').css('overflow-y', 'hidden');

    // create iframe and add it into body
    var div = $('<div id="iframe-wrap"></div>');
    $('<iframe>', {
        src: url,
        id: 'iframe-document',
        frameborder: 0,
        scrolling: 'yes'
    }).appendTo(div);
    div.appendTo('body');
    sendPageView(pageViewUrl);
}

function closeIframe() {
    removeAllFileBlocks();
    $('div#iframe-wrap').remove();
    $('body').css('overflow-y', 'auto');
}

function request(url, data) {
    showLoader();
    $.ajax({
        method: 'POST',
        url: url,
        data: data,
        processData: false,
        contentType: false,
        cache: false,
        timeout: 600000,
        success: workSuccess,
        xhr: function () {
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload)
                myXhr.upload.addEventListener('progress', progress, false);
            return myXhr;
        },
        error: function (err) {
            showAlert(err.responseJSON.Message);
            ShowReportModal(err.responseJSON);
        }
    });
}

function ShowReportModal(data) {
}

function requestErrorReport() {
    if ($("#errorEmail").val().trim() == "") {
        return;
    }
    var reg = new RegExp("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$");
    if (!reg.test($("#errorEmail").val())) {
        alert("email is invalid");
        return;
    }
    if ($('#forumPrivate').prop('checked')) {
        $("#errorPrivate").val("true");
    } else {
        $("#errorPrivate").val("false");
    }
    var url = o.APIBasePath + "report/error";
    $.ajax({
        method: 'POST',
        url: url,
        data: $("#errorForm").serialize(),
        contentType: 'application/x-www-form-urlencoded',
        cache: false,
        timeout: 600000,
        success: (d) => {
            if (d.StatusCode == 200) {
                $('#errorModal').modal('hide');
                $('#lnkForums').attr("href", d.ForumLink);
                $('#reportResultModal').modal('show');
            } else {
                alert(d.Status);
            }
        },
        error: (err) => {
            //alert("Internal Server Error");
        }
    });
}

function requestConversion() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'Conversion/Convert?outputType=' + $('#saveAs').val();
    request(url, data);
}

function requestViewer(data) {
    var url = generateViewerLink(data);
    openIframe(url, '/diagram/viewer', '/diagram/view');
}

function requestEditor(data) {
    var url = generateEditorLink(data);
    openIframe(url, '/diagram/editor', '/diagram/edit');
}

function requestNewEditor() {
    $("#newButton").val("Loading");
    var url = generateNewEditorLink();
    openIframe(url, '/diagram/editor', '/diagram/edit');
}

function requestMerger() {
    let data = fileDrop.prepareFormData(2, o.MaximumUploadFiles);
    if (data === null)
        return;

    let url = o.APIBasePath + 'Merger/Merge?outputType=' + $('#saveAs').val();
    request(url, data);
}

function prepareDownloadUrl() {
    o.AppDownloadURL = o.AppURL;
    var pos = o.AppDownloadURL.indexOf(':');
    if (pos > 0)
        o.AppDownloadURL = (pos > 0 ? o.AppDownloadURL.substring(pos + 3) : o.AppURL) + '/download';
    pos = o.AppDownloadURL.indexOf('/');
    o.AppDownloadURL = o.AppDownloadURL.substring(pos);
}

function checkReturnFromViewer() {
    var query = window.location.search;
    if (query.length > 0) {
        o.ReturnFromViewer = true;
        var data = {
            StatusCode: 200,
            FolderName: $.QueryString['id'],
            FileName: $.QueryString['FileName'],
            FileProcessingErrorCode: 0
        };
        var beforeQueryString = window.location.href.split("?")[0];
        window.history.pushState({}, document.title, beforeQueryString);

        if (!o.UploadAndRedirect)
            workSuccess(data);
    }
}

function shareApp(type) {
    if (['facebook', 'twitter', 'linkedin', 'cloud', 'feedback', 'otherapp', 'bookmark'].indexOf(type) !== -1) {
        var gaEvent = function (action, category) {
            if (!category) {
                category = 'Social';
            }
            if ('ga' in window) {
                try {
                    var tracker = window.ga.getAll()[0];
                    if (tracker !== undefined) {
                        tracker.send('event', {
                            'eventCategory': category,
                            'eventAction': action
                        });
                    }
                } catch (err) {
                }
            }
        };
        var appPath = window.location.pathname.split('/');
        var appURL = 'https://' + window.location.hostname + "/" + appPath[1] + "/" + appPath[2];
        var title = document.title.replace('&', 'and');
        // Google Analytics event
        gaEvent(type.charAt(0).toUpperCase() + type.slice(1));

        // perform an action
        switch (type) {
            case 'facebook':
                var a = document.createElement('a');
                a.href = 'https://www.facebook.com/sharer/sharer.php?u=#' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'twitter':
                var a = document.createElement('a');
                a.href = 'https://twitter.com/intent/tweet?text=' + encodeURI(title) + '&url=' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'linkedin':
                var a = document.createElement('a');
                a.href = 'https://www.linkedin.com/sharing/share-offsite/?url=' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'feedback':
                $('#feedbackModal').modal({
                    keyboard: true
                });
                break;
            case 'otherapp':
                document.location.href = 'https://products.aspose.app/Diagram/family';
                break;
            case 'cloud':
                var e = e || window.event;
                e = e.target || e.srcElement;
                if (e.tagName !== "A") {
                    var a = document.createElement('a');
                    a.href = 'https://products.aspose.cloud/Diagram/family';
                    a.setAttribute('target', '_blank');
                    a.click();
                }
                break;
            case 'bookmark':
                $('#bookmarkModal').modal({
                    keyboard: true
                });
                break;
            default:
            // nothing
        }
    }
}

function sendFeedbackExtended() {
    var text = $('#feedbackBody').val();
    if (text && !text.match(/^.s+$/)) {
        $('#feedbackModal').modal('hide');
        sendFeedback(text);
    }
}

function otherAppClick(name, left = false) {
    if ('ga' in window) {
        try {
            var tracker = window.ga.getAll()[0];
            if (tracker !== undefined) {
                tracker.send('event', {
                    'eventCategory': 'Other App Click' + (left ? ' Left' : ''),
                    'eventAction': name
                });
            }
        } catch (e) {
        }
    }
}

$(document).ready(function () {
    try {
        prepareDownloadUrl();
        checkReturnFromViewer();

        if (o.AppName == "Conversion" && o.Accept == ".excel") {
            o.Accept = ".xls,.xlsx";
            o.UploadOptions = ".XLS,.XLSX";
        }
        fileDrop = $('form#UploadFile').filedrop(Object.assign({
            showAlert: showAlert,
            hideAlert: hideAlert,
            showLoader: showLoader,
            progress: progress
        }, o));

        if (o.AppName === "Comparison") {
            fileDrop2 = $('form#UploadFile').filedrop(Object.assign({
                showAlert: showAlert,
                hideAlert: hideAlert,
                showLoader: showLoader,
                progress: progress
            }, o));
        }

        // close iframe if it was opened
        window.onpopstate = function (event) {
            if ($('div#iframe-wrap').length > 0) {
                closeIframe();
            }
        };

        if (!o.UploadAndRedirect) {
            $('#uploadButton').on('click', o.Method);
        }

        if (o.UploadAndRedirect) {
            $('#newButton').on('click', o.NewMethod);
        }

        if (!o.ShowHelpButton) {
            $('#showHelpButton').on('click', function () {
                // const helpTemplate = o.getTrustedResourceUrl('/assembly/' + ASPOSE_PRODUCTNAME + 'HelpTemplate.html');
                alert("showHelpButton");
                const helpTemplate = "/assembly/diagramHelpTemplate.html";
                $("#help-dialog-template > .modal-dialog > .modal-content").html(helpTemplate).contents();
            });
        }

        // social network modal
        $('#bookmarkModal').on('show.bs.modal', function (e) {
            $('#bookmarkModal').css('display', 'flex');
            $('#bookmarkModal').on('keydown', function (evt) {
                if ((evt.metaKey || evt.ctrlKey) && String.fromCharCode(evt.which).toLowerCase() === 'd') {
                    $('#bookmarkModal').modal('hide');
                }
            });
        });
        $('#bookmarkModal').on('hidden.bs.modal', function (e) {
            $('#bookmarkModal').off('keydown');
        });

        // send email modal
        $('#sendEmailButton').on('click', function () {
            $('#sendEmailModal').modal({
                keyboard: true
            });
        });
        $('#sendEmailModal').on('show.bs.modal', function () {
            $('#sendEmailModal').css('display', 'flex');
        });
        $('#sendEmailModal').on('shown.bs.modal', function () {
            $('#EmailToInput').focus();
        });

        // send feedback modal
        $('#feedbackModal').on('show.bs.modal', function (e) {
            $('#feedbackModal').css('display', 'flex');
        });
        $('#feedbackModal').on('shown.bs.modal', function () {
            $('#feedbackBody').focus();
        });

        //$('#sendFeedbackBtn').on('click', sendFeedback);

        // detect Ctrl + D keypress
        $(document).on('keydown', function (evt) {
            if (evt.originalEvent.code === 'KeyD' && evt.originalEvent.ctrlKey && !evt.originalEvent.altKey && !evt.originalEvent.shiftKey && !evt.originalEvent.metaKey) {
                if ('ga' in window) {
                    try {
                        var tracker = window.ga.getAll()[0];
                        if (tracker !== undefined) {
                            tracker.send('event', {
                                'eventCategory': '[Ctrl + D] keypress',
                                'eventAction': 'Target: ' + window.location.pathname
                            });
                        }
                    } catch (e) {
                    }
                }
            }
        });
    } catch{

    }
});
