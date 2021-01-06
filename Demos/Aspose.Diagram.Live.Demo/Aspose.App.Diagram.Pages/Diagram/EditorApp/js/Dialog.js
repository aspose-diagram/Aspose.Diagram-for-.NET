var Dialog = function() {
    this.zIndex = 10086;
    this.closeImage = '/Diagram/EditorApp/images/close.png'
}

Dialog.prototype.ShowDialog = function(lab, w, h) {

    this.parent = document.createElement('div');
    this.parent.className = 'dialog';

    var ds = mxUtils.getDocumentSize();

    var dh = ds.height;
    var left = Math.max(1, Math.round((ds.width) / 2));
    var top = Math.max(1, Math.round((dh) / 3));

    this.parent.style.width = w + 'px';
    this.parent.style.height = h + 'px';
    this.parent.style.left = left + 'px';
    this.parent.style.top = top + 'px';

    if (this.bg == null) {
        this.bg = document.createElement('div');
        this.bg.className = 'background';
        this.bg.style.position = 'absolute';
        this.bg.style.background = 'white';
        this.bg.style.height = dh + 'px';
        this.bg.style.width = ds.width + 'px';
        this.bg.style.opacity = 0.8;
        this.bg.style.zIndex = this.zIndex - 2;
        mxUtils.setOpacity(this.bg);
    }

    mxEvent.addListener(this.bg, 'click', mxUtils.bind(this, function() {
        this.hideDialog(true);
    }));

    document.body.appendChild(this.parent);
    document.body.appendChild(this.bg);
    this.parent.appendChild(lab);

    this.init();
}

//ReName
Dialog.prototype.ReName = function(ui, filename, buttonText, fn, label) {
    var row, td;

    var table = document.createElement('table');
    var tbody = document.createElement('tbody');
    table.style.marginTop = '8px';

    row = document.createElement('tr');

    td = document.createElement('td');
    td.style.whiteSpace = 'nowrap';
    td.style.fontSize = '10pt';
    td.style.width = '120px';
    mxUtils.write(td, (label != null ? label : "PageName" + ':'));
    row.appendChild(td);

    var nameInput = document.createElement('input');
    nameInput.setAttribute('value', filename || '');
    nameInput.style.marginLeft = '4px';
    nameInput.style.width = '180px';
    nameInput.className = "input-box";

    td = document.createElement('td');
    td.style.whiteSpace = 'nowrap';
    td.appendChild(nameInput);
    row.appendChild(td);
    tbody.appendChild(row);

    row = document.createElement('tr');
    td = document.createElement('td');
    td.colSpan = 2;
    td.style.paddingTop = '20px';
    td.style.whiteSpace = 'nowrap';
    td.setAttribute('align', 'right');

    var cancelBtn = document.createElement('button');
    cancelBtn.className = 'button';
    mxUtils.write(cancelBtn, 'Cancel');
    mxEvent.addListener(cancelBtn, 'click', mxUtils.bind(this, function() { this.hideDialog(true) }))

    var reNameBtn = document.createElement('button');
    reNameBtn.className = 'button button-primary';
    mxUtils.write(reNameBtn, buttonText);
    mxEvent.addListener(reNameBtn, 'click', mxUtils.bind(this, function() {
        this.hideDialog(true);
        fn(nameInput.value)
    }));

    td.appendChild(cancelBtn);
    td.appendChild(reNameBtn);
    row.appendChild(td);
    tbody.appendChild(row);

    table.appendChild(tbody);

    mxEvent.addListener(nameInput, 'keypress', function(e) {
        if (e.keyCode == 13) {
            reNameBtn.click();
        }
    });

    this.init = function() {
        nameInput.select();
        nameInput.focus();
    }

    return table;
}

Dialog.prototype.import = function() {
    var div = document.createElement('div');
    div.className = "import-container"
    var form = document.createElement('form');
    form.enctype = "multipart/form-data";
    form.id = "formData";

    var file = document.createElement('input');
    file.setAttribute('type', 'file');
    file.setAttribute('name', 'upfile');
    file.setAttribute('id', 'file_open');
    file.setAttribute("accept", ".vsd, .vsdx, .vsx, .vtx, .vdx, .vssx, .vstx, .vsdm, .vssm,.vstm")
    file.style.marginLeft = '4px';
    file.style.width = '180px';

    var span = document.createElement("span");
    span.innerHTML = "Supported formats:VSD, VSDX, VSX, VTX, VDX, VSSX, VSTX, VSDM, VSSM or VSTM";

    var btnGroup = document.createElement("div");
    btnGroup.className = "button-group";
    var saveBtn = document.createElement('button');
    var cancelBtn = document.createElement('button');
    btnGroup.appendChild(cancelBtn);
    btnGroup.appendChild(saveBtn);

    form.appendChild(file);
    div.appendChild(span);
    div.appendChild(form);
    div.appendChild(btnGroup);


    function fileClick(obj) {
        if (file.value.length > 0) {
            saveBtn.removeAttribute('disabled');
        } else {
            saveBtn.setAttribute('disabled', 'disabled');
        }
    }

    mxEvent.addListener(file, 'change', function() {
        fileClick(this);
    })

    saveBtn.className = 'button button-primary';
    saveBtn.setAttribute('disabled', 'disabled');
    mxUtils.write(saveBtn, 'Import');
    mxEvent.addListener(saveBtn, 'click', mxUtils.bind(this, function() {
        var files = file.files;
        if (files.length > 0) {
            $.bootstrapLoading.start({ loadingTips: "" });
            var data = new FormData(document.getElementById("formData"));
            $.ajax({
                url: xhost + importAction,
                type: "post",
                data: data,
                processData: false,
                contentType: false,
                success: function(res) {
                    if (res.code == 200) {
                        var xml = res.data;
                        sessionId = res.FolderName;
                        importedCells = graph.page.importXml(xml, 0, 0, true);
                        graph.actions.get('selectAll'.toLowerCase()).funct();
                        graph.actions.get('setAppName'.toLowerCase()).funct(files[0].name);
                        undoManager.clear();
                        initPageScroll();
                        $("#zoom_val").text(graph.view.scale * 100 + "%");
                    } else {
                        mxUtils.alert("Error:  " + res.Message);
                    }
                    $.bootstrapLoading.end();
                },
                error: function(e) {
                    mxUtils.alert("Error:  " + e.responseJSON.Message);
                    $.bootstrapLoading.end();
                }
            });
            graph.actions.get('resetView'.toLowerCase()).funct();
        }
        this.hideDialog(true);
    }))


    cancelBtn.className = 'button'
    mxUtils.write(cancelBtn, 'Cancel');
    mxEvent.addListener(cancelBtn, 'click', mxUtils.bind(this, function() { this.hideDialog(true) }))

    mxEvent.addListener(file, 'keypress', function(e) {
        if (e.keyCode == 13) {
            saveBtn.click();
        }
    });


    this.init = function() {
        fileClick()
    }

    return div;
}

Dialog.prototype.PageSetUp = function(width, height) {
    var row, td;

    var table = document.createElement('table');

    var tbody = document.createElement('tbody');
    tbody.className = "PageSetUp";
    table.style.width = '100%';
    table.style.height = '100%';

    //#region  pageSize
    row = document.createElement('tr')

    td = document.createElement('td');
    mxUtils.write(td, "PageSize" + ':');
    row.appendChild(td);

    td = document.createElement('td');
    var customDiv = document.createElement('div');
    customDiv.style.marginLeft = '4px';
    customDiv.style.width = '210px';
    customDiv.style.height = '24px';

    mxUtils.write(customDiv, 'W:');
    var widthInput = document.createElement('input');
    widthInput.setAttribute('type', 'number');
    widthInput.setAttribute('size', '7');
    widthInput.style.textAlign = 'right';
    widthInput.style.width = '75px';
    widthInput.setAttribute('value', width);
    customDiv.appendChild(widthInput);
    mxUtils.write(customDiv, 'H:');
    //mxUtils.write(customDiv, ' PX * ');

    var heightInput = document.createElement('input');
    heightInput.setAttribute('type', 'number');
    heightInput.setAttribute('size', '7');
    heightInput.style.textAlign = 'right';
    heightInput.style.width = '75px';
    heightInput.setAttribute('value', height);
    customDiv.appendChild(heightInput);
    //mxUtils.write(customDiv, ' PX');

    td.appendChild(customDiv);
    row.appendChild(td);
    tbody.appendChild(row);
    //#endregion

    //#region gridsize
    row = document.createElement('tr');
    td = document.createElement('td');

    mxUtils.write(td, "GridSize" + ':');
    row.appendChild(td);

    td = document.createElement('td');
    var gridSizeInput = document.createElement('input');
    gridSizeInput.setAttribute('type', 'number');
    gridSizeInput.style.textAlign = 'right';
    gridSizeInput.setAttribute('min', '0');
    gridSizeInput.style.width = '60px';
    gridSizeInput.style.marginLeft = '6px';

    gridSizeInput.value = graph.getGridSize();
    td.appendChild(gridSizeInput);

    row.appendChild(td);
    tbody.appendChild(row);
    //#endregion

    //#region backgroundColor
    row = document.createElement('tr');
    td = document.createElement('td');
    mxUtils.write(td, "backColor" + ':');
    row.appendChild(td);

    td = document.createElement('td');

    var div = document.createElement('button');
    div.setAttribute('title', 'Color: ' + (div.style.backgroundColor == "" ? '#ffffff' : div.style.backgroundColor));
    div.className = 'backColor'
    div.style.height = '15px';
    div.style.width = '35px';
    div.style.left = '3px';
    div.style.bottom = '2px';
    div.style.backgroundColor = graph.backgroundColor
    td.appendChild(div);

    var color = graph.backgroundColor;

    $(div).bigColorpicker(function(target, val) {
        div.setAttribute('title', 'Color: ' + val);
        $(div).css("background-color", val);
        color = val;
    }, "l");

    row.appendChild(td);
    tbody.appendChild(row);
    //#endregion

    //#region backgroundimage
    //row = document.createElement('tr');
    //td = document.createElement('td');
    //mxUtils.write(td, 'Image' + ':');
    //row.appendChild(td);

    td = document.createElement('td');
    var changeImageLink = document.createElement('a');
    changeImageLink.style.textDecoration = 'underline';
    changeImageLink.style.cursor = 'pointer';
    changeImageLink.style.color = '#a0a0a0';
    changeImageLink.style.display = 'none';

    var newBackgroundImage = graph.backgroundImage;

    function updateBackgroundImage() {
        if (newBackgroundImage == null) {
            changeImageLink.removeAttribute('title');
            changeImageLink.style.fontSize = '';
            changeImageLink.innerHTML = "Change" + '...';
            return false;
        } else {
            changeImageLink.setAttribute('title', newBackgroundImage.src);
            changeImageLink.style.fontSize = '11px';
            changeImageLink.innerHTML = newBackgroundImage.src.substring(0, 30) + '...';
            return true;
        }
    };

    updateBackgroundImage();

    mxEvent.addListener(changeImageLink, 'click', mxUtils.bind(this, function(evt) {
        this.showBackgroundImageDialog('BackGroundImage', (newBackgroundImage != null ? newBackgroundImage.src : ''), function(image) {
            newBackgroundImage = image;
            var show = updateBackgroundImage();
            imageChang(image, show);
        });
    }));

    td.appendChild(changeImageLink);
    row.appendChild(td);
    tbody.appendChild(row);
    //#endregion

    //#region imageSize
    imageRow = document.createElement('tr');
    imageRow.style.display = 'none';

    td = document.createElement('td');
    mxUtils.write(td, 'ImageSize' + ':');
    imageRow.appendChild(td);

    td = document.createElement('td');
    var imagesize = document.createElement('div');
    imagesize.style.marginLeft = '4px';
    imagesize.style.width = '210px';
    imagesize.style.height = '24px';

    var imageWidth = document.createElement('input');
    imageWidth.setAttribute('type', 'number');
    imageWidth.setAttribute('size', '7');
    imageWidth.style.textAlign = 'right';
    imageWidth.style.width = '75px';
    imagesize.appendChild(imageWidth);
    mxUtils.write(imagesize, ' PX * ');

    var imageHeight = document.createElement('input');
    imageHeight.setAttribute('type', 'number');
    imageHeight.setAttribute('size', '7');
    imageHeight.style.textAlign = 'right';
    imageHeight.style.width = '75px';
    imagesize.appendChild(imageHeight);
    mxUtils.write(imagesize, ' PX');

    td.appendChild(imagesize);
    imageRow.appendChild(td);
    tbody.appendChild(imageRow);

    var imageChang = mxUtils.bind(this, function(image, show) {
        if (image != "" && image != null && show) {
            imageRow.style.display = '';
            imageWidth.setAttribute('value', image.width);
            imageHeight.setAttribute('value', image.height);
        } else if (!show) {
            imageRow.style.display = 'none';
        }
    })

    imageChang(newBackgroundImage, true);

    mxEvent.addListener(imageWidth, 'change', mxUtils.bind(this, function() {
        newBackgroundImage.width = imageWidth.value;
    }))

    mxEvent.addListener(imageHeight, 'change', mxUtils.bind(this, function() {
            newBackgroundImage.height = imageHeight.value;
        }))
        //#endregion

    //#region apply/cancel
    row = document.createElement('tr');
    td = document.createElement('td');
    td.setAttribute('align', 'right');
    td.style.paddingTop = '10px';
    td.colSpan = 2;

    var saveBtn = document.createElement('button');
    saveBtn.className = 'button button-primary';
    mxUtils.write(saveBtn, 'Apply');
    mxEvent.addListener(saveBtn, 'click', mxUtils.bind(this, function() {
        this.hideDialog(true);
        var pageFormat = graph.pageFormat;
        pageFormat.width = widthInput.value;
        pageFormat.height = heightInput.value;

        var gridSize = parseInt(gridSizeInput.value);
        graph.actions.get('setPageSize').funct(pageFormat, gridSize, newBackgroundImage, color);
    }))

    var cancelBtn = document.createElement('button');
    cancelBtn.className = 'button'
    mxUtils.write(cancelBtn, 'Cancel');
    mxEvent.addListener(cancelBtn, 'click', mxUtils.bind(this, function() {
        this.hideDialog(true)
    }))

    td.appendChild(cancelBtn);
    td.appendChild(saveBtn);

    row.appendChild(td);
    tbody.appendChild(row);
    //#endregion

    table.appendChild(tbody);

    //#region enter apply
    mxEvent.addListener(gridSizeInput, 'keypress', function(e) {
        if (e.keyCode == 13) {
            saveBtn.click();
        }
    });

    mxEvent.addListener(heightInput, 'keypress', function(e) {
        if (e.keyCode == 13) {
            saveBtn.click();
        }
    });

    mxEvent.addListener(widthInput, 'keypress', function(e) {
        if (e.keyCode == 13) {
            saveBtn.click();
        }
    });

    mxEvent.addListener(imageRow, 'keypress', function(e) {
        if (e.keyCode == 13) {
            saveBtn.click();
        }
    });
    //#endregion


    this.init = function() {
        widthInput.select();
        widthInput.focus();
    }
    return table;
}

Dialog.prototype.InsertImage = function(title, newBackgroundImage, fn) {
    this.showBackgroundImageDialog(title, (newBackgroundImage != null ? newBackgroundImage : ''), function(image) {
        if (image != null) {
            fn(image, image.width, image.height);
        }
    });
}

Dialog.prototype.insertLink = function(value, fn) {
    var row, td;

    var table = document.createElement('table');
    var tbody = document.createElement('tbody');
    table.style.marginTop = '8px';

    row = document.createElement('tr');

    td = document.createElement('td');
    td.style.whiteSpace = 'nowrap';
    td.style.fontSize = '10pt';
    td.style.width = '120px';
    mxUtils.write(td, "Link" + ':');
    row.appendChild(td);

    var linkInput = document.createElement('input');
    linkInput.setAttribute('value', value || '');
    linkInput.setAttribute('placeholder', 'http://www.example.com/');
    linkInput.style.marginLeft = '4px';
    linkInput.style.width = '180px';
    linkInput.className = "input-box";

    td = document.createElement('td');
    td.style.whiteSpace = 'nowrap';
    td.appendChild(linkInput);
    row.appendChild(td);
    tbody.appendChild(row);

    row = document.createElement('tr');
    td = document.createElement('td');
    td.colSpan = 2;
    td.style.paddingTop = '20px';
    td.style.whiteSpace = 'nowrap';
    td.setAttribute('align', 'right');

    var cancelBtn = document.createElement('button');
    cancelBtn.className = 'button';
    mxUtils.write(cancelBtn, 'Cancel');
    mxEvent.addListener(cancelBtn, 'click', mxUtils.bind(this, function() { this.hideDialog(true) }))

    var insertBtn = document.createElement('button');
    insertBtn.className = 'button button-primary';
    mxUtils.write(insertBtn, 'Insert');
    mxEvent.addListener(insertBtn, 'click', mxUtils.bind(this, function() {
        this.hideDialog(true);
        fn(linkInput.value)
    }));

    td.appendChild(cancelBtn);
    td.appendChild(insertBtn);
    row.appendChild(td);
    tbody.appendChild(row);

    table.appendChild(tbody);

    mxEvent.addListener(linkInput, 'keypress', function(e) {
        if (e.keyCode == 13) {
            insertBtn.click();
        }
    });

    this.init = function() {
        linkInput.select();
        linkInput.focus();
    }

    return table;
}

Dialog.prototype.hideDialog = function(cancel) {
    try {
        if (this.bg != null && this.bg.parentNode != null) {
            this.bg.parentNode.removeChild(this.bg);
        }

        this.parent.parentNode.removeChild(this.parent);
    } catch (e) {

    }
};

Dialog.prototype.showBackgroundImageDialog = function(title, value, fn) {
    var newValue = mxUtils.prompt(title, value);

    if (newValue != null && newValue.length > 0) {
        var img = new Image();

        img.onload = function() {
            fn(new mxImage(newValue, img.width, img.height));
        };
        img.onerror = function() {
            fn(null);
            mxUtils.alert("file Not Found");
        };

        img.src = newValue;
    } else {
        fn(null);
    }
}