var graph;
var layoutManager;

mxGraph.prototype.defaultPageVisible = true;
mxGraph.prototype.initialTopSpacing = 0;
mxGraph.prototype.connectionArrowsEnabled = true;
mxGraph.prototype.lightbox = false;
mxGraph.prototype.pageFormat = new mxRectangle(0, 0, 1442, 2040);
mxGraph.prototype.gridSize = 15;
mxGraph.prototype.pageScale = 1;

$(document).ready(function () {
    InitDrawPageContainer(document.getElementById("graph_container"));
    bigSvg();
    createItems();
    graph.page = new Pages(graph);
    graph.sizeDidChange();
    initPageScroll();
    graph.HoverIcons = createHoverIcons(graph);
})

var undoManager;


//#region 
function fontNameChange() {
    var fontName = $("#font_select").val();
    updateCellsStyle("fontFamily", fontName);
    $(".number2 span").text(fontName);
}
//#endregion

//#region
function InitDrawPageContainer(container) {
    var model = new mxGraphModel();
    graph = new mxGraph(container, model);

    graph.setConnectable(true);
    graph.dropEnabled = true;
    graph.graphHandler.guidesEnabled = true;
    graph.setTooltips(true);
    graph.setEnabled(true);
    graph.setHtmlLabels(true);
    graph.isHtmlLabels(true);
    graph.constrainChildren = false;
    graph.resetEdgesOnConnect = false;
    graph.foldingEnabled = false;
    graph.constrainRelativeChildren = true;
    graph.graphHandler.scrollOnMove = false;
    graph.graphHandler.scaleGrid = true;
    graph.connectionHandler.setCreateTarget(false);
    graph.connectionHandler.insertBeforeSource = true;
    graph.setMultigraph(false);


    var node = mxUtils.load('/Diagram/EditorApp/Resources/default.xml').getDocumentElement();
    if (node != null) {
        var dec = new mxCodec(node.ownerDocument);
        dec.decode(node, graph.getStylesheet());
    }

    graph.items = new Items();

    undoManager = new mxUndoManager();
    var listener = function (sender, evt) {
        undoManager.undoableEditHappened(evt.getProperty('edit'));
    };
    graph.getModel().addListener(mxEvent.UNDO, listener);
    graph.getView().addListener(mxEvent.UNDO, listener);

    graph.actions = new Actions(graph.container);
    graph.shape = new Primitives(graph);
    graph.dialog = new Dialog();

    var convertValueToString = graph.convertValueToString;
    graph.convertValueToString = function (cell) {
        if (cell.value != null && typeof (cell.value) == 'object') {
            if (cell.value.getAttribute('placeholders') == '1' && cell.getAttribute('placeholder') != null) {
                var name = cell.getAttribute('placeholder');
                var current = cell;
                var result = null;
                while (result == null && current != null) {
                    if (current.value != null && typeof (current.value) == 'object') {
                        result = (current.hasAttribute(name)) ? ((current.getAttribute(name) != null) ?
                            current.getAttribute(name) : '') : null;
                    }
                    current = this.model.getParent(current);
                }
                return result || '';
            }
            else {
                return cell.value.getAttribute('label') || '';
            }
        }
        return convertValueToString.apply(this, arguments);
    };

    //#region
    var graphSizeDidChange = graph.sizeDidChange;
    graph.sizeDidChange = function () {
        if (this.container != null && mxUtils.hasScrollbars(this.container) && !graph.Search) {
            var pages = getPageLayout();
            var pad = new mxPoint(Math.max(0, Math.round((graph.container.offsetWidth - 33) / graph.view.scale)),
                Math.max(0, Math.round((graph.container.offsetHeight - 32) / graph.view.scale)));
            var size = new mxRectangle(0, 0, graph.pageFormat.width * graph.view.scale,
                graph.pageFormat.height * graph.view.scale)

            var minw = Math.ceil(2 * pad.x + pages.width * size.width);
            var minh = Math.ceil(2 * pad.y + pages.height * size.height);

            var min = graph.minimumGraphSize;

            if (min == null || min.width != minw || min.height != minh) {
                graph.minimumGraphSize = new mxRectangle(0, 0, minw, minh);
            }

            var dx = pad.x - pages.x * size.width;
            var dy = (pad.y - pages.y * size.height - 760) > 0 ? (pad.y - pages.y * size.height - 760) : 60;

            if (!this.autoTranslate && (this.view.translate.x != dx || this.view.translate.y != dy)) {
                this.autoTranslate = true;
                this.view.x0 = pages.x;
                this.view.y0 = pages.y;

                var tx = graph.view.translate.x;
                var ty = graph.view.translate.y;
                graph.view.setTranslate(dx, dy);

                graph.container.scrollLeft += Math.round((dx - tx) * graph.view.scale);
                graph.container.scrollTop += Math.round((dy - ty) * graph.view.scale);

                this.autoTranslate = false;

                return;
            }
            graphSizeDidChange.apply(this, arguments);
        }
    };
    //#endregion

    graph.getSelectionModel().addListener(mxEvent.CHANGE, mxUtils.bind(this, function () {
        Actions.prototype.updateActionStates();
    }));
}
//#endregion

//#region
function createItems() {
    mxEvent.disableContextMenu(graph.container);

    graph.popupMenuHandler.factoryMethod = mxUtils.bind(this, function (menu, cell, evt) {
        graph.items.createPopupMenu(menu, cell, evt);
    });

    graph.actions.createControlShiftKey();
}
//#endregion

//#region
mxConnectionHandler.prototype.createEdgeState = function (me) {
    var style = "edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;";
    var edge = this.graph.createEdge(null, null, null, null, null, style);
    var state = new mxCellState(this.graph.view, edge, this.graph.getCellStyle(edge));
    for (var key in this.graph.currentEdgeStyle) {
        state.style[key] = this.graph.currentEdgeStyle[key];
    }

    return state;
};
//#endregion

function initPageScroll() {
    var pad = new mxPoint(Math.max(0, Math.round((graph.container.offsetWidth - 34) / graph.view.scale)),
        Math.max(0, Math.round((graph.container.offsetHeight - 80) / graph.view.scale)));
    graph.container.scrollTop = 0; //Math.floor(pad.y - graph.initialTopSpacing) - 1;
    graph.container.scrollLeft = Math.floor(Math.min(pad.x, (graph.container.scrollWidth - graph.container.clientWidth) / 2)) - 20;
}

mxConnectionHandler.prototype.isValidSource = function (cell, me) {
    return false;
};

//#region
function createHoverIcons(graph) {
    mxConstants.VERTEX_SELECTION_COLOR = '#883333';
    mxVertexHandler.prototype.handleImage = this.createSvgImage(18, 18, '<circle cx="9" cy="9" r="4" stroke="#883333" fill="' + "#fff" + '" stroke-width="1"/>');
    mxVertexHandler.prototype.secondaryHandleImage = this.createSvgImage(16, 16, '<path d="m 8 3 L 13 8 L 8 13 L 3 8 z" stroke="#883333" fill="#fff"/>');
    mxEdgeHandler.prototype.handleImage = this.createSvgImage(18, 18, '<circle cx="9" cy="9" r="4" stroke="#883333" fill="' + "#fff" + '" stroke-width="1"/>');
    mxVertexHandler.prototype.rotationHandle =
        createSvgImage(16, 16, '<path stroke="#883333" fill="#fff" d="M15.55 5.55L11 1v3.07C7.06 4.56 4 7.92 4 12s3.05 7.44 7 7.93v-2.02c-2.84-.48-5-2.94-5-5.91s2.16-5.43 5-5.91V10l4.55-4.45zM19.93 11c-.17-1.39-.72-2.73-1.62-3.89l-1.42 1.42c.54.75.88 1.6 1.02 2.47h2.02zM13 17.9v2.02c1.39-.17 2.74-.71 3.9-1.61l-1.44-1.44c-.75.54-1.59.89-2.46 1.03zm3.89-2.42l1.42 1.41c.9-1.16 1.45-2.5 1.62-3.89h-2.02c-.14.87-.48 1.72-1.02 2.48z"/>',
            24, 24);
    return new HoverIcons(graph);
}

HoverIcons = function (graph) {
    this.graph = graph;
    this.init();
};

HoverIcons.prototype.cssCursor = 'copy';

HoverIcons.prototype.tolerance = 0;

/**
 * Up arrow.
 */
HoverIcons.prototype.arrowUp =
    createSvgImage(18, 28, '<path d="m 6 26 L 12 26 L 12 12 L 18 12 L 9 1 L 1 12 L 6 12 z" ' +
        'stroke="#fff" fill="' + HoverIcons.prototype.arrowFill + '"/>');

/**
 * Right arrow.
 */
HoverIcons.prototype.arrowRight =
    createSvgImage(26, 18, '<path d="m 1 6 L 14 6 L 14 1 L 26 9 L 14 18 L 14 12 L 1 12 z" ' +
        'stroke="#fff" fill="' + HoverIcons.prototype.arrowFill + '"/>');

/**
 * Down arrow.
 */
HoverIcons.prototype.arrowDown =
    createSvgImage(18, 26, '<path d="m 6 1 L 6 14 L 1 14 L 9 26 L 18 14 L 12 14 L 12 1 z" ' +
        'stroke="#fff" fill="' + HoverIcons.prototype.arrowFill + '"/>');

/**
 * Left arrow.
 */
HoverIcons.prototype.arrowLeft =
    createSvgImage(28, 18, '<path d="m 1 9 L 12 1 L 12 6 L 26 6 L 26 12 L 12 12 L 12 18 z" ' +
        'stroke="#fff" fill="' + HoverIcons.prototype.arrowFill + '"/>');

HoverIcons.prototype.initAll = function () {
    this.checkState = null;
}


HoverIcons.prototype.init = function () {
    this.cellArrowUp = this.createCellArrow(this.arrowUp, 'arrowUp');
    this.cellArrowRight = this.createCellArrow(this.arrowRight, 'arrowRight');
    this.cellArrowDown = this.createCellArrow(this.arrowDown, 'arrowDown');
    this.cellArrowLeft = this.createCellArrow(this.arrowLeft), 'arrowLeft';

    this.arrow = [this.cellArrowUp, this.cellArrowDown, this.cellArrowLeft, this.cellArrowRight];

    mxEvent.addListener(this.graph.container, 'mouseleave', mxUtils.bind(this, function (evt) {
        if (evt.relatedTarget != null && mxEvent.getSource(evt) == this.graph.container) {
            this.setDisplay('none');
            this.checkState = null;
        }
    }));

    this.resetHandler = mxUtils.bind(this, function () {
        this.remove();
    });

    mxEvent.addListener(this.graph.container, 'scroll', this.resetHandler);

    var showClick = false;
    this.graph.addMouseListener({
        mouseDown: mxUtils.bind(this, function (sender, me) {
            showClick = false;
            this.remove();
        }),
        mouseMove: mxUtils.bind(this, function (sender, me) {
            var evt = me.getEvent();
            if (this.checkState != null && this.checkState != me.getState() && me.getState() == null) {
                window.setTimeout(mxUtils.bind(this, function () { if (this.showArrow == null) { this.remove() } }), 1000)
            } else if (!this.graph.isMouseDown && !mxEvent.isTouchEvent(evt) && me.getState() != null && me.getState().cell.vertex) {
                this.setDisplay('');
                this.removeNodes();
                this.setCheckState(this.graph.view.getState(me.getState().cell));
                this.repaint();
            }
            if (this.graph.connectionHandler != null && this.graph.connectionHandler.shape != null) {
                showClick = true;
            }
        }),
        mouseUp: mxUtils.bind(this, function (sender, me) {
            if (this.showArrow != null && this.checkState != null && this.checkState.cell.vertex && !showClick) {
                var dir = mxConstants.DIRECTION_EAST;
                if (this.showArrow == this.cellArrowUp) {
                    dir = mxConstants.DIRECTION_NORTH;
                } else if (this.showArrow == this.cellArrowDown) {
                    dir = mxConstants.DIRECTION_SOUTH;
                } else if (this.showArrow == this.cellArrowLeft) {
                    dir = mxConstants.DIRECTION_WEST;
                }

                if (this.checkState != null) {
                    this.graph.getModel().beginUpdate();
                    try {
                        var cell = this.checkState.cell;
                        var cell1 = mxClipboard.copy(this.graph, [cell])[0];
                        cell1 = mxClipboard.paste(this.graph)[0];

                        var parentState = this.graph.view.getState(this.graph.model.getParent(cell));
                        var s = this.graph.view.scale;
                        var t = this.graph.view.translate;
                        var dx = t.x * s;
                        var dy = t.y * s;

                        if (parentState != null && this.graph.model.isVertex(parentState.cell)) {
                            dx = parentState.x;
                            dy = parentState.y;
                        }

                        var tmp;

                        var geoo = cell.geometry;
                        if (dir == mxConstants.DIRECTION_EAST) {
                            geo = geoo.clone();
                            geo.x = Math.round(geo.x + geo.width + 60);
                            this.graph.model.setGeometry(cell1, geo);

                            tmp = this.graph.getCellAt(dx + geoo.x + geoo.width + 60 + 1 + geoo.width / 2, dy + geoo.y + geoo.height / 2);
                        } else if (dir == mxConstants.DIRECTION_NORTH) {
                            geo = geoo.clone();
                            geo.y = Math.round(geo.y - 60 - geo.height);
                            this.graph.model.setGeometry(cell1, geo);

                            tmp = this.graph.getCellAt(dx + geoo.x + geoo.width / 2, dy + geoo.y - 60 - geoo.height + 1 + geoo.height / 2);
                        } else if (dir == mxConstants.DIRECTION_SOUTH) {
                            geo = geoo.clone();
                            geo.y = Math.round(geo.y + geo.height + 60);
                            this.graph.model.setGeometry(cell1, geo);

                            tmp = this.graph.getCellAt(dx + geoo.x + geoo.width / 2, dy + geoo.y + geoo.height + 60 + 1 + geoo.height / 2);
                        } else if (dir == mxConstants.DIRECTION_WEST) {
                            geo = geoo.clone();
                            geo.x = Math.round(geo.x - 60 - geo.width);
                            this.graph.model.setGeometry(cell1, geo);

                            tmp = this.graph.getCellAt(dx + geoo.x - 60 - geoo.width + 1 + geoo.width / 2, dy + geoo.y + geoo.height / 2);
                        }
                        if (tmp == null) {
                            this.graph.insertEdge(this.graph.model.getParent(cell), null, '', cell, cell1, "edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;")
                        } else {
                            mxClipboard.removeCells(this.graph, [cell1]);
                            this.graph.insertEdge(this.graph.model.getParent(cell), null, '', cell, tmp, "edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;")
                        }
                    } finally {
                        this.graph.getModel().endUpdate();
                    }
                }
            }
            showClick = false;
        })
    });
}

var vertexHandlerCreateSizerShape = mxVertexHandler.prototype.createSizerShape;
mxVertexHandler.prototype.createSizerShape = function (bounds, index, fillColor) {
    this.handleImage = (index == mxEvent.ROTATION_HANDLE) ? this.rotationHandle : (index == mxEvent.LABEL_HANDLE) ? this.secondaryHandleImage : this.handleImage;

    return vertexHandlerCreateSizerShape.apply(this, arguments);
};

mxVertexHandler.prototype.getRotationHandlePosition = function () {
    var padding = this.getHandlePadding();

    return new mxPoint(this.bounds.x + this.bounds.width - this.rotationHandleVSpacing + padding.x / 2,
        this.bounds.y + this.rotationHandleVSpacing - padding.y / 2)
};

HoverIcons.prototype.setCheckState = function (state) {
    if (state.style['portConstraint'] != 'eastwest') {
        this.graph.container.appendChild(this.cellArrowUp);
        this.graph.container.appendChild(this.cellArrowDown);
    }

    this.graph.container.appendChild(this.cellArrowRight);
    this.graph.container.appendChild(this.cellArrowLeft);
    this.checkState = state;
}


HoverIcons.prototype.removeNodes = function () {
    this.showNodes(function (arrow) {
        if (arrow.parentNode != null) {
            arrow.parentNode.removeChild(arrow);
        }
    })
}

HoverIcons.prototype.setDisplay = function (display) {
    this.showNodes(function (elt) {
        elt.style.display = display;
    });
};


HoverIcons.prototype.showNodes = function (fn) {
    for (var i = 0; i < this.arrow.length; i++) {
        if (this.arrow[i] != null) {
            fn(this.arrow[i]);
        }
    }
}


HoverIcons.prototype.repaint = function () {
    if (this.checkState != null) {
   
        if (this.graph.model.contains(this.checkState.cell)) {
            this.checkState = this.graph.view.getState(this.checkState.cell);
        } else {
            this.checkState = null;
        }


        if (this.checkState != null && this.checkState.cell.vertex) {
            var box = mxRectangle.fromRectangle(this.checkState);


            if (this.checkState.shape != null && this.checkState.shape.boundingBox != null) {
                box = mxRectangle.fromRectangle(this.checkState.shape.boundingBox);
            }


            box.grow(this.graph.tolerance);
            box.grow(2);

            var handler = this.graph.selectionCellsHandler.getHandler(this.checkState.cell);
            var rotationBbox = null;

            if (handler != null) {
                box.x -= handler.horizontalOffset / 2;
                box.y -= handler.verticalOffset / 2;
                box.width += handler.horizontalOffset;
                box.height += handler.verticalOffset;

                if (handler.rotationShape != null && handler.rotationShape.node != null &&
                    handler.rotationShape.node.style.visibility != 'hidden' &&
                    handler.rotationShape.node.style.display != 'none' &&
                    handler.rotationShape.boundingBox != null) {
                    rotationBbox = handler.rotationShape.boundingBox;
                }
            }


            var addArrow = mxUtils.bind(this, function (arrow, x, y) {
                if (rotationBbox != null) {
                    var bbox = new mxRectangle(x, y, arrow.clientWidth, arrow.clientHeight);


                    if (mxUtils.intersects(bbox, rotationBbox)) {
                        if (arrow == this.cellArrowUp) {
                            y -= bbox.y + bbox.height - rotationBbox.y;
                        }
                        else if (arrow == this.cellArrowRight) {
                            x += rotationBbox.x + rotationBbox.width - bbox.x;
                        }
                        else if (arrow == this.cellArrowDown) {
                            y += rotationBbox.y + rotationBbox.height - bbox.y;
                        }
                        else if (arrow == this.cellArrowLeft) {
                            x -= bbox.x + bbox.width - rotationBbox.x;
                        }
                    }
                }

                arrow.style.left = x + 'px';
                arrow.style.top = y + 'px';
                mxUtils.setOpacity(arrow, '15');
            })

            addArrow(this.cellArrowUp, Math.round(this.checkState.getCenterX() - this.cellArrowUp.width / 2 - this.tolerance),
                Math.round(box.y - this.cellArrowUp.height - this.tolerance));

            addArrow(this.cellArrowRight, Math.round(box.x + box.width - this.tolerance),
                Math.round(this.checkState.getCenterY() - this.cellArrowRight.height / 2 - this.tolerance));

            addArrow(this.cellArrowDown, parseInt(this.cellArrowUp.style.left),
                Math.round(box.y + box.height - this.tolerance));

            addArrow(this.cellArrowLeft, Math.round(box.x - this.cellArrowLeft.width - this.tolerance),
                parseInt(this.cellArrowRight.style.top));

            this.cellArrowLeft.style.visibility = 'visible';
            this.cellArrowRight.style.visibility = 'visible';
            this.cellArrowUp.style.visibility = 'visible';
            this.cellArrowDown.style.visibility = 'visible';
        }
    }
}


HoverIcons.prototype.remove = function () {
    this.mouseDownPoint = null;
    this.checkState = null;
    this.setDisplay('none');
    this.removeNodes();
}


HoverIcons.prototype.createCellArrow = function (arrowImg, tip) {
    var arrow = null;
    if (arrowImg != null) {
        arrow = mxUtils.createImage(arrowImg.src);
        arrow.style.width = arrowImg.width + 'px';
        arrow.style.height = arrowImg.height + 'px';
        arrow.style.display = 'inline-block';
        arrow.style.position = 'absolute';
        arrow.style.cursor = this.cssCursor;
        if (tip != null) {
            arrow.setAttribute('title', tip);
        }
    }


    mxEvent.addListener(arrow, 'mouseenter', mxUtils.bind(this, function (evt) {

        mxUtils.setOpacity(arrow, 100);
        this.showArrow = arrow;
    }))


    mxEvent.addListener(arrow, 'mouseleave', mxUtils.bind(this, function (evt) {
        this.removeShowArrow();
    }))

    mxEvent.addGestureListeners(arrow, mxUtils.bind(this, function (evt) {
        if (this.checkState != null) {
            this.mouseDownPoint = mxUtils.convertPoint(this.graph.container,
                mxEvent.getClientX(evt), mxEvent.getClientY(evt));
            this.dragEdge(evt, this.mouseDownPoint.x, this.mouseDownPoint.y);
            this.showArrow = arrow;
            this.setDisplay('none');
            mxEvent.consume(evt);
        }
    }));

    return arrow;
}

var mxCellEditorStartEditing = mxCellEditor.prototype.startEditing;
mxCellEditor.prototype.startEditing = function (cell, trigger) {
    mxCellEditorStartEditing.apply(this, arguments);

    var state = this.graph.view.getState(cell);

    if (state != null && state.style['html'] == 1) {
        this.textarea.className = 'mxCellEditor geContentEditable';
    } else {
        this.textarea.className = 'mxCellEditor mxPlainTextEditor';
    }
}

var mxCellEditorResize = mxCellEditor.prototype.resize;
mxCellEditor.prototype.resize = function (state, trigger) {
    if (this.textarea != null) {
        var state = this.graph.getView().getState(this.editingCell);

        if (this.codeViewMode && state != null) {
        } else {
            this.textarea.style.height = '';
            this.textarea.style.overflow = '';
            mxCellEditorResize.apply(this, arguments);
        }
    }
};

mxCellEditorGetInitialValue = mxCellEditor.prototype.getInitialValue;
mxCellEditor.prototype.getInitialValue = function (state, trigger) {
    if (mxUtils.getValue(state.style, 'html', '0') == '0') {
        return mxCellEditorGetInitialValue.apply(this, arguments);
    } else {
        var result = this.graph.getEditingValue(state.cell, trigger)

        if (mxUtils.getValue(state.style, 'nl2Br', '1') == '1') {
            result = result.replace(/\n/g, '<br/>');
        }

        result = this.graph.sanitizeHtml(result, true);

        return result;
    }
};

mxCellEditorGetCurrentValue = mxCellEditor.prototype.getCurrentValue;
mxCellEditor.prototype.getCurrentValue = function (state) {
    if (mxUtils.getValue(state.style, 'html', '0') == '0') {
        return mxCellEditorGetCurrentValue.apply(this, arguments);
    } else {
        var result = this.graph.sanitizeHtml(this.textarea.innerHTML, true);

        if (mxUtils.getValue(state.style, 'nl2Br', '1') == '1') {
            result = result.replace(/\r\n/g, '<br/>').replace(/\n/g, '<br/>');
        } else {
            result = result.replace(/\r\n/g, '').replace(/\n/g, '');
        }

        return result;
    }
};

mxGraph.prototype.sanitizeHtml = function (value, editing) {
    function urlX(link) {
        if (link != null && link.toString().toLowerCase().substring(0, 11) !== 'javascript:') {
            return link;
        }
        return null;
    };

    function idX(id) { return id };

    return html_sanitize(value, urlX, idX);
};

HoverIcons.prototype.dragEdge = function (evt, x, y) {
    this.graph.stopEditing(false);

    if (this.checkState != null) {
        this.graph.connectionHandler.start(this.checkState, x, y);
        this.graph.isMouseTrigger = mxEvent.isMouseEvent(evt);
        this.graph.isMouseDown = true;


        var handler = this.graph.selectionCellsHandler.getHandler(this.checkState.cell);

        if (handler != null) {
            handler.setHandlesVisible(false);
        }
    }
}


HoverIcons.prototype.removeShowArrow = function () {
    if (this.showArrow != null) {
        mxUtils.setOpacity(this.showArrow, '15');
        this.setDisplay('none');
    }
}

//#endregion