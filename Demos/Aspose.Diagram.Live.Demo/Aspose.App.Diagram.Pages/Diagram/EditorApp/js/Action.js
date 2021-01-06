function Actions() {
    this.actions = new Object();
    this.init();
}


Actions.prototype.init = function () {

    this.addAction('delete', mxUtils.bind(this, function () {
        graph.cellsRemoved(graph.getSelectionCells(), false);
    }, null, 'Delete'));

    this.addAction('undo', mxUtils.bind(this, function () {
        undoManager.undo();
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Z')).setEnabled(undoManager.canUndo());

    this.addAction('redo', mxUtils.bind(this, function () {
        undoManager.redo();
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Y')).setEnabled(undoManager.canRedo());

    this.addAction('ToFront', mxUtils.bind(this, function () {
        graph.orderCells(false);
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+F'));

    this.addAction('ToBack', mxUtils.bind(this, function () {
        graph.orderCells(true);
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+B'));

    this.addAction('selectVertices', mxUtils.bind(this, function () {
        graph.selectVertices(null, true);
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+I'));

    this.addAction('selectEdges', mxUtils.bind(this, function () {
        graph.selectEdges();
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+E'));

    this.addAction('selectAll', mxUtils.bind(this, function () {
        graph.selectAll(null, true);
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+A'));

    this.addAction('selectNone', mxUtils.bind(this, function () {
        graph.clearSelection();
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+A'));

    this.addAction('cut', mxUtils.bind(this, function () {
        mxClipboard.cut(graph);
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+X'));

    this.addAction('copy', mxUtils.bind(this, function () {
        try {
            mxClipboard.copy(graph);
        } catch (e) { alert("error") }
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+C'));

    this.addAction('paste', mxUtils.bind(this, function () {
        if (graph.isEnabled() && !graph.isCellLocked(graph.getDefaultParent())) {
            mxClipboard.paste(graph);
        }
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+V')).setEnabled(this.isPasteEnable());

    this.addAction('bold', mxUtils.bind(this, function () {
        graph.getModel().beginUpdate();
        try {
            graph.setCellStyleFlags(mxConstants.STYLE_FONTSTYLE, mxConstants.FONT_BOLD, null, graph.getSelectionCells());
        } finally {
            graph.getModel().endUpdate();
        }
    }, null, null));

    this.addAction('italic', mxUtils.bind(this, function () {
        graph.getModel().beginUpdate();
        try {
            graph.setCellStyleFlags(mxConstants.STYLE_FONTSTYLE, mxConstants.FONT_ITALIC, null, graph.getSelectionCells());
        } finally {
            graph.getModel().endUpdate();
        }
    }, null, null));

    this.addAction('underline', mxUtils.bind(this, function () {
        graph.getModel().beginUpdate();
        try {
            graph.setCellStyleFlags(mxConstants.STYLE_FONTSTYLE, mxConstants.FONT_UNDERLINE, null, graph.getSelectionCells());
        } finally {
            graph.getModel().endUpdate();
        }
    }, null, null));

    this.addAction('scale', mxUtils.bind(this, function (number) {
        graph.getModel().beginUpdate()
        try {
            scrollTop = graph.container.scrollTop;
            scrollLeft = graph.container.scrollLeft;
            window.setTimeout(mxUtils.bind(this, function () {
                graph.zoom((number / 100) / graph.view.scale);
            }), 0);
        } finally {
            graph.getModel().endUpdate();
        }
        graph.container.focus();
    }));

    this.addAction('font', mxUtils.bind(this, function (font) {
        this.updateCellsStyle("fontFamily", font);
        this.updateLabelElements("fontFamily", font);
    }, null, null));

    this.addAction('fontsize', mxUtils.bind(this, function (size) {
        this.updateCellsStyle("fontSize", size);
        this.updateLabelElements("fontSize", size);
    }, null, null));

    this.addAction('fillcolor', mxUtils.bind(this, function (color) {
        this.updateCellsStyle("fillColor", color);
    }, null, null));

    this.addAction('fontcolor', mxUtils.bind(this, function (color) {
        this.updateCellsStyle("fontColor", color);
        this.updateLabelElements("fontColor", color);
    }, null, null));

    this.addAction('strokecolor', mxUtils.bind(this, function (color) {
        this.updateCellsStyle("strokeColor", color);
    }, null, null));

    this.addAction('aligntop', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_VERTICAL_ALIGN, mxConstants.ALIGN_TOP);
    }, null, null));

    this.addAction('alignmiddle', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_VERTICAL_ALIGN, mxConstants.ALIGN_MIDDLE);
    }, null, null));

    this.addAction('alignbottom', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_VERTICAL_ALIGN, mxConstants.ALIGN_BOTTOM);
    }, null, null));

    this.addAction('alignleft', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_ALIGN, mxConstants.ALIGN_LEFT);
    }, null, null));

    this.addAction('aligncenter', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_ALIGN, mxConstants.ALIGN_CENTER);
    }, null, null));

    this.addAction('alignright', mxUtils.bind(this, function () {
        this.updateCellsStyle(mxConstants.STYLE_ALIGN, mxConstants.ALIGN_RIGHT);
    }, null, null));

    this.addAction('getAsDefaultStyle', mxUtils.bind(this, function () {
        this.getCellStyle(graph.getSelectionCell());
    }), null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+c');

    this.addAction('setAsDefaultStyle', mxUtils.bind(this, function () {
        this.setCellStyle();
    }), null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+V');

    this.addAction('clearDefaultStyle', mxUtils.bind(this, function () {
        this.clearCellStyle();
    }), null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+Shift+R');
    this.addAction('importVsdx', function () {
        graph.dialog.ShowDialog(graph.dialog.import(), 400, 120)
    }, null, null);
    this.addAction('exportVsdx', mxUtils.bind(this, function (format) {
        var name = $('.nav-left span').text() + '';
        var fileName = name.substring(0, name.lastIndexOf(".")) + "." + format;
        var lab = graph.dialog.ReName(this, fileName, "DownLoad", mxUtils.bind(this, function (fileName) {
            var vsdx = new Vsdx();
            vsdx.export(fileName, format);
        }), "FileName:");

        graph.dialog.ShowDialog(lab, 300, 80);
    }))
    this.addAction('resetView', function () {
        graph.zoomTo(1);
        initPageScroll();
        graph.view.validateBackground();
    }, null, (mxClient.IS_MAC) ? 'Cmd' : 'Ctrl' + '+H');

    this.addAction('setAppName', mxUtils.bind(this, function (name) {
        $('.nav-left span').text(name);
    }, null, null));

    this.addAction('setPageSize', mxUtils.bind(this, function (pageFormat, gridSize, backgroundImage, backgroundColor) {
        graph.model.beginUpdate();
        try {
            graph.pageFormat = pageFormat;
            graph.gridSize = gridSize;
            graph.backgroundColor = backgroundColor;
            graph.setBackgroundImage(backgroundImage);
            graph.model.fireEvent(new mxEventObject('PageSizeChange', 'change', this));
            graph.view.validateBackground();
            if (backgroundColor != null || backgroundImage != null) {
                graph.model.fireEvent(new mxEventObject('backgroundChange', 'change', this));
            }
        }
        finally {
            graph.model.endUpdate();
        }
    }))
    //outline
    this.addAction('OutLine', mxUtils.bind(this, function () {
        if (graph.outline == null) {
            graph.outline = new OutLine();
            graph.outline.init(document.body.offsetWidth - 260, 100, 180, 180);

            graph.outline.form.setVisible(true);
        } else {
            graph.outline.form.setVisible(!graph.outline.form.isVisible());
        }
    }))
    //edgeStyle
    this.addAction('EdgeStyleChange', mxUtils.bind(this, function (keys, values) {
        graph.getModel().beginUpdate();
        try {
            var cells = graph.getSelectionCells();

            for (var i = 0; i < keys.length; i++) {
                graph.setCellStyles(keys[i], values[i], cells);
            }
        }
        finally {
            graph.getModel().endUpdate();
        }
    }), null, null);
    //insetLink
    this.addAction('InsertLink', mxUtils.bind(this, function () {
        graph.dialog.ShowDialog(
            graph.dialog.insertLink(null, mxUtils.bind(this, function (value) {
                this.insertEdit(value)
            })), 250, 80);
    }), null, null);
    //insetImage
    this.addAction('InsertImage', mxUtils.bind(this, function (imageUrl, select) {
        graph.dialog.InsertImage('Url(Img)', imageUrl != '' ? imageUrl : '', function (image, w, h) {
            var newValue = image.src;
            var cells = graph.getSelectionCells();
            if (!select) {
                cells = [];
            }

            if (newValue != null && (newValue.length > 0 || cells.length > 0)) {
                graph.getModel().beginUpdate();
                try {
                    if (cells.length == 0) {
                        var pt = getFreeInsertPoint();
                        cells = [graph.insertVertex(graph.getDefaultParent(), null, '', pt.x, pt.y, w, h,
                            'shape=image;imageAspect=0;aspect=fixed;verticalLabelPosition=bottom;verticalAlign=top;')];
                    }

                    graph.setCellStyles(mxConstants.STYLE_IMAGE, (newValue.length > 0) ? newValue : null, cells);
                }
                finally {
                    graph.getModel().endUpdate();
                }

                if (cells != null) {
                    graph.setSelectionCells(cells);
                    graph.scrollCellToVisible(cells[0]);
                }
            }
        })
    }), null, null);

    this.addAction('editImage', mxUtils.bind(this, function () {
        this.actions['insertimage'].funct(graph.view.getState(graph.getSelectionCell()).style.image, true);
    }))

    this.addAction('showCellSizeAndPosition', mxUtils.bind(this, function () {
        if (graph.getSelectionCell().isVertex() && graph.getSelectionCount() == 1) {
            var geo = graph.getCellGeometry(graph.getSelectionCell());
            $("#positionX").val(Math.round(geo.x));
            $("#positionY").val(Math.round(geo.y));
            $("#sizeW").val(Math.round(geo.width));
            $("#sizeH").val(Math.round(geo.height));
            $("#sizeLeft").val("0");
            $("#sizeTop").val("0");
        }
        else if (graph.getSelectionCell().isEdge() && graph.getSelectionCount() == 1) {
            var geo = graph.model.getGeometry(graph.getSelectionCell()).targetPoint;
            $("#positionX").val("0");
            $("#positionY").val("0");
            $("#sizeW").val("0");
            $("#sizeH").val("0");
            if (geo != null) {
                $("#sizeLeft").val(Math.round(geo.x));
                $("#sizeTop").val(Math.round(geo.y));
            }
        }
    }))

    this.addAction('clearCellSizeAndPosition', mxUtils.bind(this, function () {
        $("#positionX").val("0");
        $("#positionY").val("0");
        $("#sizeW").val("0");
        $("#sizeH").val("0");
        $("#sizeLeft").val("0");
        $("#sizeTop").val("0");
    }))

    this.addAction('changeCellSizeAndPosition', mxUtils.bind(this, function (style, value) {
        graph.getModel().beginUpdate();
        try {
            var cell = graph.getSelectionCell();
            if (cell != undefined) {
                if (graph.getModel().isVertex(cell)) {
                    var geo = graph.getCellGeometry(cell);
                    if (geo != null) {
                        geo = geo.clone();
                        switch (style) {
                            case "positionX": geo.x = Math.round(Math.max(0, value)); break;
                            case "positionY": geo.y = Math.round(Math.max(0, value)); break;
                            case "sizeW": geo.width = Math.round(Math.max(0, value)); break;
                            case "sizeH": geo.height = Math.round(Math.max(0, value)); break;
                            case "sizeLeft": geo.targetPoint.x = Math.round(Math.max(0, value)); break;
                            case "sizeTop": geo.targetPoint.y = Math.round(Math.max(0, value)); break;
                        }
                        graph.getModel().setGeometry(cell, geo);
                    }
                }
            }
        } finally {
            graph.getModel().endUpdate();
        }
    }))

    var UndoListener = mxUtils.bind(this, function () {
        graph.actions.get("undo").setEnabled(undoManager.canUndo());
        graph.actions.get("redo").setEnabled(undoManager.canRedo());
        graph.actions.get("paste").setEnabled(this.isPasteEnable());
    })
    undoManager.addListener(mxEvent.ADD, UndoListener);
    undoManager.addListener(mxEvent.UNDO, UndoListener);
    undoManager.addListener(mxEvent.REDO, UndoListener);
    undoManager.addListener(mxEvent.CLEAR, UndoListener);
}

Actions.prototype.addAction = function (key, funct, enable, shortcut) {
    var title;
    key = key.toLowerCase();
    title = mxResources.get(key);

    return this.put(key, new Action(title, funct, enable, shortcut));
}

Actions.prototype.updateActionStates = function () {
    graph.actions.get("paste").setEnabled(this.isPasteEnable());
    if (graph.getSelectionCells() != null) {
        this.StatusBarAssignment();
        this.ShapeSelected();
    } else {

    }
}

Actions.prototype.ShapeSelected = function () {
    if (graph.getSelectionCells().length > 0) {
        $(".shape-property").removeClass("disable");
        $(".shape-property").css("pointer-events", "");
    } else {
        $(".shape-property").addClass("disable");
        $(".shape-property").css("pointer-events", "none");
    }
}

Actions.prototype.put = function (name, action) {
    this.actions[name] = action;

    return action;
};

Actions.prototype.get = function (name) {
    return this.actions[name.toLowerCase()];
};

Actions.prototype.isPasteEnable = function () {
    return this.isContentEditing() || (!mxClipboard.isEmpty() && graph.isEnabled() && !graph.isCellLocked(graph.getDefaultParent()))
}

Actions.prototype.isContentEditing = function () {
    var state = graph.view.getState(this.editingCell);

    return state != null && state.style['html'] == 1;
};

Actions.prototype.getCellStyle = function (cell) {
    var state = graph.view.getState(cell);
    if (state != null) {
        this.CellStyle = graph.getCellStyle(cell);
    }
}

Actions.prototype.setCellStyle = function () {
    try {
        for (var key in graph.actions.CellStyle) {
            if (key != 'shape') {
                Action.prototype.updateCellsStyle(key, graph.actions.CellStyle[key])
            }
        }
        if (graph.actions.CellStyle['fontStyle'] == null || graph.actions.CellStyle['fontStyle'] == "") {
            Action.prototype.updateCellsStyle('fontStyle', 0);
        }
    } finally {

    }
}

Actions.prototype.clearCellStyle = function () {
    graph.actions.CellStyle = null;
}

Actions.prototype.cellStyle = function () {
    return graph.actions.CellStyle != null && graph.actions.CellStyle != undefined;
}

Actions.prototype.StatusBarAssignment = function () {
    var cells = graph.getSelectionCells();
    if (cells.length == 1) {
        var style = graph.getCellStyle(graph.getSelectionCell());
        for (var key in style) {
            if (key == "align") {
                var value = style[key];
                $(".text-x-position").removeClass("text-style-selected");
                if (value == "left") {
                    $("#align_Left").addClass("text-style-selected");
                }
                if (value == "center") {
                    $("#align_center").addClass("text-style-selected");
                }
                if (value == "right") {
                    $("#align_right").addClass("text-style-selected");
                }
            } else if (key == "fillColor") {
                $("#fill_color_picker_val").css("background-color", style[key]);
            } else if (key == "fontColor") {
                var color = this.getLableStyle(cells, 'fontColor');
                $("#text_color_picker_val").css("background-color", color == null || color == "" ? style[key] : color);
            } else if (key == "strokeColor") {
                $("#pen_color_picker_val").css("background-color", style[key]);
            } else if (key == "fontFamily") {
                var fontFamily = this.getLableStyle(cells, 'fontFamily');
                $("#font_family_val").text(fontFamily == null || fontFamily == "" ? style[key] : fontFamily);
            } else if (key == "fontSize") {
                var fontSize = this.getLableStyle(cells, 'fontSize');
                $("#font_size_val").text(fontSize == null || fontSize == "" ? style[key] + 'px' : fontSize);
            } else if (key == "fontStyle") {
                var value = style[key];
                $(".text-style").removeClass("text-style-selected");
                switch (value) {
                    case 0:
                        break;
                    case 1:
                        $("#text_bold").addClass("text-style-selected");
                        break;
                    case 2:
                        $("#text_italic").addClass("text-style-selected");
                        break;
                    case 3:
                        $("#text_bold").addClass("text-style-selected");
                        $("#text_italic").addClass("text-style-selected");
                        break;
                    case 4:
                        $("#text_underline").addClass("text-style-selected");
                        break;
                    case 5:
                        $("#text_bold").addClass("text-style-selected");
                        $("#text_underline").addClass("text-style-selected");
                        break;
                    case 6:
                        $("#text_italic").addClass("text-style-selected");
                        $("#text_underline").addClass("text-style-selected");
                        break;
                    default:
                        $("#text_bold").addClass("text-style-selected");
                        $("#text_italic").addClass("text-style-selected");
                        $("#text_underline").addClass("text-style-selected");
                        break;
                }
            } else if (key == "verticalAlign") {
                var value = style[key];
                $(".text-y-position").removeClass("text-style-selected");
                if (value == "top") {
                    $("#align_top").addClass("text-style-selected");
                }
                if (value == "middle") {
                    $("#align_middle").addClass("text-style-selected");
                }
                if (value == "bottom") {
                    $("#align_bottom").addClass("text-style-selected");
                }
            } else {
                $(".text-style").removeClass("text-style-selected");
            }
        }
        if (style['fillColor'] == null || style['fillColor'] == undefined) {
            $("#fill_color_picker_val").css("background-color", '#7F7F7F');
        }
        if (style['fontColor'] == null || style['fontColor'] == undefined) {
            $("#text_color_picker_val").css("background-color", '#7F7F7F');
        }
        if (style['strokeColor'] == null || style['strokeColor'] == undefined) {
            $("#pen_color_picker_val").css("background-color", '#7F7F7F');
        }
    } else {
        $("#fill_color_picker_val").css("background-color", '#7F7F7F');
        $("#text_color_picker_val").css("background-color", '#7F7F7F');
        $("#pen_color_picker_val").css("background-color", '#7F7F7F');
        $("#font_family_val").text('Helvetica');
        $("#font_size_val").text('14px');

        $(".text-style").removeClass("text-style-selected");

        $(".text-y-position").removeClass("text-style-selected");
        $("#align_middle").addClass("text-style-selected");

        $(".text-x-position").removeClass("text-style-selected");
        $("#align_center").addClass("text-style-selected");
    }
}

Actions.prototype.loadXMLDoc = function (dname) {
    if (window.XMLHttpRequest) {
        xhttp = new XMLHttpRequest();
    } else {
        xhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xhttp.open("GET", dname, false);
    xhttp.send();
    return xhttp.responseXML;
}

//action
function Action(label, funct, enabled, shortcut) {
    mxEventSource.call(this);
    this.label = label;
    this.funct = funct;
    this.enabled = (enabled != null) ? enabled : true;
    this.shortcut = shortcut;
    this.visible = true;
};

mxUtils.extend(Action, mxEventSource);


Action.prototype.setEnabled = function (value) {
    if (this.enabled != value) {
        this.enabled = value;
    }
}


Action.prototype.isEnabled = function () {
    return this.enabled;
}


Actions.prototype.updateCellsStyle = function (key, value) {
    graph.getModel().beginUpdate();
    try {
        graph.setCellStyles(key, value, graph.getSelectionCells());
    } catch (e) {
        mxUtils.alert('null cell');
    } finally {
        graph.getModel().endUpdate();
    }
}

//#region 
Actions.prototype.createControlShiftKey = function () {
    var keyHandler = new mxKeyHandler(graph);

    var action = graph.actions;

    keyHandler.bindKey(46, action.get('delete'.toLowerCase()).funct); // Delete delete
    keyHandler.bindControlKey(90, action.get('undo'.toLowerCase()).funct); // Ctrl+Z  undo
    keyHandler.bindControlKey(89, action.get('redo'.toLowerCase()).funct); // Ctrl+Y redo
    keyHandler.bindControlKey(65, action.get('selectAll'.toLowerCase()).funct); // Ctrl+A  selectAll
    keyHandler.bindControlShiftKey(65, action.get('selectNone'.toLowerCase()).funct); // Ctrl+Shift+A  selectNone
    keyHandler.bindControlShiftKey(73, action.get('selectVertices'.toLowerCase()).funct); // Ctrl+Shift+I  selectVertices
    keyHandler.bindControlShiftKey(69, action.get('selectEdges'.toLowerCase()).funct); // Ctrl+Shift+E  selectEdges
    keyHandler.bindControlKey(88, action.get('cut'.toLowerCase()).funct); // Ctrl+X cut
    keyHandler.bindControlKey(67, action.get('copy'.toLowerCase()).funct); // Ctrl+C  copy
    keyHandler.bindControlKey(86, action.get('paste'.toLowerCase()).funct); // Ctrl+V  paste
    keyHandler.bindControlShiftKey(67, action.get('getAsDefaultStyle'.toLowerCase()).funct); // Ctrl+Shift+C  getAsDefaultStyle
    keyHandler.bindControlShiftKey(86, action.get('setAsDefaultStyle'.toLowerCase()).funct); // Ctrl+Shift+V  setAsDefaultStyle
    keyHandler.bindControlShiftKey(82, action.get('clearDefaultStyle'.toLowerCase()).funct); // Ctrl+Shift+R  clearDefaultStyle


    mxEvent.addListener(graph.container, "mousewheel", mxUtils.bind(this, function (evt) {
        if (evt.ctrlKey == true) {
            event.preventDefault();

            var delta = 0;
            if (!event) event = window.event;
            if (event.wheelDelta) {
                delta = event.wheelDelta / 120;
                if (window.opera) delta = -delta;
            } else if (event.detail) {
                delta = -event.detail / 3;
            }
            this.Zoom(delta);
        }
    }))

    var keyHandGetFunction = keyHandler.getFunction
    mxKeyHandler.prototype.getFunction = function (evt) {
        var arrowChange = function (keyCode) {
            if (!graph.isSelectionEmpty() && graph.isEnabled()) {
                graph.getModel().beginUpdate()
                try {
                    var cell = graph.getSelectionCell()
                    var geo = graph.getCellGeometry(cell);
                    if (geo != null) {
                        var dx = 0;
                        var dy = 0;

                        if (keyCode == 37) {
                            dx = -graph.gridSize / graph.gridSize;
                        }
                        else if (keyCode == 38) {
                            dy = -graph.gridSize / graph.gridSize;
                        }
                        else if (keyCode == 39) {
                            dx = graph.gridSize / graph.gridSize;
                        }
                        else if (keyCode == 40) {
                            dy = graph.gridSize / graph.gridSize;
                        }
                        graph.moveCells(graph.getMovableCells(graph.getSelectionCells()), dx, dy);
                    }
                } finally {
                    graph.getModel().endUpdate();
                }
            }
        }

        if (graph.isEnabled() && graph.getSelectionCell() != null) {
            if (evt.keyCode == 37 && evt.ctrlKey == true) {
                keyHandler.bindKey(37, arrowChange(37));
            }
            if (evt.keyCode == 38 && evt.ctrlKey == true) {
                keyHandler.bindKey(38, arrowChange(38));
            }
            if (evt.keyCode == 39 && evt.ctrlKey == true) {
                keyHandler.bindKey(39, arrowChange(39));
            }
            if (evt.keyCode == 40 && evt.ctrlKey == true) {
                keyHandler.bindKey(40, arrowChange(40));
            }
        }
        return keyHandGetFunction.apply(this, arguments);
    }
}
//#endregion

Actions.prototype.Zoom = function (delta) {
    var value;
    if (delta > 0) {
        value = graph.view.scale * 110;
    } else {
        value = graph.view.scale * 90;
    }
    graph.actions.get("scale").funct(Math.round(value));
    $("#zoom_val").text(Math.round(value) + "%");
}

Actions.prototype.getLableStyle = function (cell, format) {
    var fn = function (elt) {
        if (elt != null && (elt.nodeName != 'BR')) {
            switch (format) {
                case "fontSize": return elt.style.fontSize.replace(/"/g, "")
                case "fontFamily": return elt.style.fontFamily.replace(/"/g, "");
                case "fontColor": return elt.style.color.replace(/"/g, "");
            }
        }
    }

    var cells = graph.getSelectionCells();
    for (var i = 0; i < cells.length; i++) {
        var div = document.createElement('div');

        if (graph.isHtmlLabel(cells[i])) {
            var label = graph.convertValueToString(cells[i]);

            if (label != null && label.length > 0) {
                div.innerHTML = label;
                var elts = div.getElementsByTagName('*');

                for (var j = 0; j < elts.length; j++) {
                    var style = fn(elts[j]);
                    if (style != null && style != "") {
                        return style;
                    }
                }
            }
        }
    }

    return "";
}

Action.prototype.Zoom = function (scale) {
    mxGraph.prototype.zoom.apply(graph, arguments);
}

ZoomTo = mxGraph.prototype.zoomTo;
mxGraph.prototype.zoomTo = function (scale, center) {
    ZoomTo.apply(this, arguments);
    $("#zoom_val").text(Math.ceil(this.view.scale * 100) + "%");
};

Actions.prototype.updateLabelElements = function (format, value) {

    var fn = function (elt) {
        if (elt != null && (elt.nodeName != 'BR')) {
            switch (format) {
                case "fontSize": elt.style.fontSize = value + 'px'; break;
                case "fontFamily": elt.style.fontFamily = value; break;
                case "fontColor": elt.style.color = value; break;
            }
        }
    }

    var cells = graph.getSelectionCells();
    for (var i = 0; i < cells.length; i++) {
        var div = document.createElement('div');

        if (graph.isHtmlLabel(cells[i])) {
            var label = graph.convertValueToString(cells[i]);

            if (label != null && label.length > 0) {
                div.innerHTML = label;
                var elts = div.getElementsByTagName('*');

                for (var j = 0; j < elts.length; j++) {
                    fn(elts[j]);
                }

                if (div.innerHTML != label) {
                    graph.labelChanged(cells[i], div.innerHTML);
                }
            }
        }
    }
}

Actions.prototype.insertEdit = function (Link) {
    var link = mxUtils.trim(Link);

    if (link.length > 0) {
        var title = link.substring(link.lastIndexOf('/') + 1);

        var pt = getFreeInsertPoint();

        var linkCell = new mxCell(title, new mxGeometry(pt.x, pt.y, 100, 40),
            'fontColor=#0000EE;fontStyle=4;rounded=1;overflow=hidden;fillColor=#ffffff;strokeColor=#000000;spacing=10;');
        linkCell.vertex = true;

        this.setLinkAttributeForCell(linkCell, 'link', link);
        graph.cellSizeUpdated(linkCell, true);

        graph.getModel().beginUpdate();
        try {
            linkCell = graph.addCell(linkCell);
        }
        finally {
            graph.getModel().endUpdate();
        }

        graph.setSelectionCell(linkCell);
        graph.scrollCellToVisible(graph.getSelectionCell());
    }
}

Actions.prototype.setLinkAttributeForCell = function (cell, attributeName, link) {
    var doc = mxUtils.createXmlDocument();
    var value = doc.createElement('UserObject');
    value.setAttribute('label', cell.value);

    if (link != null) {
        value.setAttribute(attributeName, link);
    }
    else {
        value.removeAttribute(attributeName);
    }

    graph.model.setValue(cell, value);
}


mxGraphHandler.prototype.selectDelayed = function (me) {
    if (!this.graph.popupMenuHandler.isPopupTrigger(me)) {
        var cell = me.getCell();

        if (cell == null) {
            cell = this.cell;
        }

        var state = this.graph.view.getState(cell)

        if (state != null && me.isSource(state.control)) {
            this.graph.selectCellForEvent(cell, me.getEvent());
        }
        else {
            var model = this.graph.getModel();
            var parent = model.getParent(cell);

            while (!this.graph.isCellSelected(parent) && model.isVertex(parent)) {
                cell = parent;
                parent = model.getParent(cell);
            }

            this.graph.selectCellForEvent(cell, me.getEvent());
        }
    }
};


var graphHandlerIsDelayedSelection = mxGraphHandler.prototype.isDelayedSelection;
mxGraphHandler.prototype.isDelayedSelection = function (cell, me) {
    var result = graphHandlerIsDelayedSelection.apply(this, arguments);

    if (!result) {
        var model = this.graph.getModel();
        var parent = model.getParent(cell);

        while (parent != null) {
            if (this.graph.isCellSelected(parent) && model.isVertex(parent)) {
                result = true;
                break;
            }

            parent = model.getParent(parent);
        }
    }

    return result;
};


mxVertexHandler.prototype.isRecursiveResize = function (state, me) {
    return !this.graph.isSwimlane(state.cell) && this.graph.model.getChildCount(state.cell) > 0 &&
        !mxEvent.isControlDown(me.getEvent()) && !this.graph.isCellCollapsed(state.cell) &&
        mxUtils.getValue(state.style, 'recursiveResize', '1') == '1' &&
        mxUtils.getValue(state.style, 'childLayout', null) == null;
};