//#region
function createBackgroundPage() {
    if (graph.container != null) {
        if (graph.pageVisible) {
            var bounds = getBackgroundPageBounds();
            if (graph.view.backgroundPageShape == null) {
                var firstChild = graph.container.firstElementChild;
                if (firstChild != null) {
                    graph.view.backgroundPageShape = new mxRectangleShape(bounds, '#ffffff', this.graph.defaultPageBorderColor);
                    graph.view.backgroundPageShape.scale = 1;

                    graph.view.backgroundPageShape.isShadow = !mxClient.IS_QUIRKS;
                    graph.view.backgroundPageShape.dialect = mxConstants.DIALECT_STRICTHTML;
                    graph.view.backgroundPageShape.init(graph.container);

                    firstChild.style.position = 'absolute';
                    graph.container.insertBefore(graph.view.backgroundPageShape.node, firstChild);
                    graph.view.backgroundPageShape.redraw();

                    graph.view.backgroundPageShape.node.className = 'geBackgroundPage';
                }

            }
            else {
                graph.view.backgroundPageShape.scale = 1;
                graph.view.backgroundPageShape.bounds = bounds;
                graph.view.backgroundPageShape.redraw();
            }
        }
        else {
            var bounds = new mxRectangle(0, 0, graph.minimumGraphSize.width * graph.view.scale, graph.minimumGraphSize.height * graph.view.scale);
            if (graph.view.backgroundPageShape == null) {
                var firstChild = graph.container.firstElementChild;
                if (firstChild != null) {
                    graph.view.backgroundPageShape = new mxRectangleShape(bounds, '#ffffff', this.graph.defaultPageBorderColor);
                    graph.view.backgroundPageShape.scale = 1;

                    graph.view.backgroundPageShape.isShadow = !mxClient.IS_QUIRKS;
                    graph.view.backgroundPageShape.dialect = mxConstants.DIALECT_STRICTHTML;
                    graph.view.backgroundPageShape.init(graph.container);

                    firstChild.style.position = 'absolute';
                    graph.container.insertBefore(graph.view.backgroundPageShape.node, firstChild);
                    graph.view.backgroundPageShape.redraw();

                    graph.view.backgroundPageShape.node.className = 'geBackgroundPage';
                }

            }
            else {
                graph.view.backgroundPageShape.scale = 1;
                graph.view.backgroundPageShape.bounds = bounds;
                graph.view.backgroundPageShape.redraw();
            }
        }
    }
}
//#endregion

//#region
function bigSvg() {
    //mxEvent.disableContextMenu(document.body);
    // Creates the graph inside the given container
    graph.graphHandler.scaleGrid = true;
    graph.setPanning(true);

    // Enables rubberband selection
    new mxRubberband(graph);

    try {
        var canvas = document.createElement("canvas");
        canvas.style.position = "absolute";
        canvas.style.top = "0px";
        canvas.style.left = "0px";
        canvas.style.zIndex = 0;

        var ctx = canvas.getContext("2d");

        // Modify event filtering to accept canvas as container
        var mxGraphViewIsContainerEvent = mxGraphView.prototype.isContainerEvent;
        mxGraphView.prototype.isContainerEvent = function (evt) {
            return (
                mxGraphViewIsContainerEvent.apply(this, arguments) ||
                mxEvent.getSource(evt) == canvas
            );
        };

        var s = 0;
        var gs = 0;
        var tr = new mxPoint();
        var w = 0;
        var h = 0;

        function repaintGrid() {
            createBackgroundPage()
            var color = graph.backgroundColor != null ? graph.backgroundColor : "#FFFFFF";
            graph.view.backgroundPageShape.node.style.backgroundColor = color;

            if (ctx != null) {
                var bounds;
                if (graph.pageVisible) {
                    bounds = getBackgroundPageBounds();
                } else {
                    bounds = new mxRectangle(0, 0, graph.minimumGraphSize.width * graph.view.scale, graph.minimumGraphSize.height * graph.view.scale);
                }
                var width = Math.max(
                    bounds.x + bounds.width,
                    graph.container.firstElementChild.clientWidth
                );
                var height = Math.max(
                    bounds.y + bounds.height,
                    graph.container.firstElementChild.clientHeight
                );

                var sizeChanged = width != w || height != h;

                if (
                    graph.view.scale != s ||
                    graph.view.translate.x != tr.x ||
                    graph.view.translate.y != tr.y ||
                    gs != graph.gridSize ||
                    sizeChanged
                ) {
                    tr = graph.view.translate.clone();
                    s = graph.view.scale;
                    gs = graph.gridSize;
                    w = width;
                    h = height;

                    // Clears the background if required
                    if (!sizeChanged) {
                        ctx.clearRect(0, 0, w, h);

                    } else {
                        canvas.setAttribute("width", w);
                        canvas.setAttribute("height", h);
                    }
                    var tx = tr.x * s;
                    var ty = tr.y * s;

                    // Sets the distance of the grid lines in pixels
                    var minStepping = gs;
                    var stepping = minStepping * s;

                    // if (stepping < minStepping) {
                    //     var count = Math.round(Math.ceil(minStepping / stepping) / 2) * 2;
                    //     stepping = count * stepping;
                    // }

                    var xs = Math.floor((0 - tx) / stepping) * stepping + tx;
                    var xe = Math.ceil(w / stepping) * stepping;
                    var ys = Math.floor((0 - ty) / stepping) * stepping + ty;
                    var ye = Math.ceil(h / stepping) * stepping;

                    xe += Math.ceil(stepping);
                    ye += Math.ceil(stepping);

                    var ixs = Math.round(xs);
                    var ixe = Math.round(xe);
                    var iys = Math.round(ys);
                    var iye = Math.round(ye);

                    // Draws the actual grid
                    ctx.strokeStyle = "#E5E5E5";
                    ctx.beginPath();

                    var rx = 0;
                    for (var x = 0; x <= xe; x += stepping) {
                        ctx.beginPath();


                        var ix = Math.round(x);

                        ctx.moveTo(ix + 0.5, iys + 0.5);
                        ctx.lineTo(ix + 0.5, iye + 0.5);
                        if (rx == 0 || rx % 4 == 0) {
                            ctx.lineWidth = 1;
                        } else {
                            ctx.lineWidth = 0.5;
                        }
                        ctx.stroke();

                        rx = rx + 1;
                    }

                    var ry = 0;
                    for (var y = 0; y <= ye; y += stepping) {
                        ctx.beginPath();


                        var iy = Math.round(y);

                        ctx.moveTo(ixs + 0.5, iy + 0.5);
                        ctx.lineTo(ixe + 0.5, iy + 0.5);
                        if (ry == 0 || ry % 4 == 0) {
                            ctx.lineWidth = 1;
                        } else {
                            ctx.lineWidth = 0.5;
                        }
                        ctx.stroke();

                        ry = ry + 1;
                    }
                    ctx.stroke();
                    ctx.closePath();
                }
            }
            if (graph.isGridEnabled()) {
                graph.container.firstElementChild.appendChild(canvas);
            }
        }
    } catch (e) {
        // mxLog.show();
        // mxLog.debug("Using background image");

        container.backgroundImage = "url('editors/images/grid.gif')";
        console.log(container);
    }

    var mxGraphViewValidateBackground = mxGraphView.prototype.validateBackground;
    mxGraphView.prototype.validateBackground = function () {
        mxGraphViewValidateBackground.apply(this, arguments);

        repaintGrid();
    };

    var graphViewValidateBackgroundPage = mxGraphView.prototype.validateBackgroundPage;
    mxGraphView.prototype.validateBackgroundPage = function () {
        scale = this.scale, translate = this.translate;

        graphViewValidateBackgroundPage.apply(this, arguments);
    };

    // Adds cells to the model in a single step
    graph.getModel().beginUpdate();
    try {
        graph.pageVisible = graph.defaultPageVisible;
        repaintGrid();
    } finally {
        // Updates the display
        graph.getModel().endUpdate();
    }
};
//#endregion

//#region
function getPagePadding() {
    var pages = this.getPageLayout();
    var pad = new mxPoint(Math.max(0, Math.round((graph.container.offsetWidth - 33) / graph.view.scale)),
        Math.max(0, Math.round((graph.container.offsetHeight - 32) / graph.view.scale)));
    var size = new mxRectangle(0, 0, graph.pageFormat.width * graph.pageScale,
        graph.pageFormat.height * graph.pageScale)

    var tx = graph.view.translate.x;
    var ty = graph.view.translate.y;
    graph.view.translate.x = pad.x - (graph.view.x0 || 0) * size.width;
    graph.view.translate.y = pad.y - (graph.view.y0 || 0) * size.height;

    // Updates the minimum graph size
    var minw = Math.ceil(2 * pad.x + pages.width * size.width);
    var minh = Math.ceil(2 * pad.y + pages.height * size.height);

    var min = graph.minimumGraphSize;

    if (min == null || min.width != minw || min.height != minh) {
        graph.minimumGraphSize = new mxRectangle(0, 0, minw, minh);
    }
};

function getPageLayout() {
    var size = new mxRectangle(0, 0, graph.pageFormat.width * graph.view.scale,
        graph.pageFormat.height * graph.view.scale);
    var bounds = graph.getGraphBounds();

    if (bounds.width == 0 || bounds.height == 0) {
        return new mxRectangle(0, 0, 1, 1);
    }
    else {
        // Computes untransformed graph bounds
        var x = Math.ceil(bounds.x / graph.view.scale - graph.view.translate.x);
        var y = Math.ceil(bounds.y / graph.view.scale - graph.view.translate.y);
        var w = Math.floor(bounds.width / graph.view.scale);
        var h = Math.floor(bounds.height / graph.view.scale);

        var x0 = Math.floor(x / size.width);
        var y0 = Math.floor(y / size.height);
        var w0 = Math.ceil((x + w) / size.width) - x0;
        var h0 = Math.ceil((y + h) / size.height) - y0;

        return new mxRectangle(x0, y0, w0, h0);
    }
};

function getBackgroundPageBounds() {
    var layout = getPageLayout();
    var page = new mxRectangle(0, 0, graph.pageFormat.width * graph.view.scale,
        graph.pageFormat.height * graph.view.scale)

    return new mxRectangle(graph.view.scale * (graph.view.translate.x + layout.x * page.width),
        graph.view.scale * (graph.view.translate.y + layout.y * page.height),
        graph.view.scale * layout.width * page.width,
        graph.view.scale * layout.height * page.height);
}

function getPageBounds() {
    var layout = getPageLayout();
    var page = new mxRectangle(0, 0, graph.pageFormat.width * graph.pageScale,
        graph.pageFormat.height * graph.pageScale)

    return new mxRectangle(graph.view.scale * (graph.view.translate.x + layout.x * page.width),
        graph.view.scale * (graph.view.translate.y + layout.y * page.height),
        0, 0);
}

mxGraphView.prototype.getBackgroundPageBounds = function () {
    var layout = getPageLayout();
    var page = new mxRectangle(0, 0, graph.pageFormat.width * this.scale,
        graph.pageFormat.height * this.scale)

    return new mxRectangle((this.translate.x * this.scale + layout.x * page.width),
        (this.translate.y * this.scale + layout.y * page.height),
        graph.view.scale * layout.width * page.width,
        graph.view.scale * layout.height * page.height);
};
//#endregion

//#region
mxGraphHandler.prototype.maxLivePreview = 16;
mxGraph.prototype.hintOffset = 20;
mxVertexHandler.prototype.rotationEnabled = true;

mxVertexHandler.prototype.removeHint = function () {
    if (this.hint != null) {
        this.hint.parentNode.removeChild(this.hint);
        this.hint = null;
    }
};

mxGraphHandler.prototype.removeHint = function () {
    if (this.hint != null) {
        this.hint.parentNode.removeChild(this.hint);
        this.hint = null;
    }
};

mxEdgeHandler.prototype.removeHint = function () {
    if (this.hint != null) {
        this.hint.parentNode.removeChild(this.hint);
        this.hint = null;
    }
}

function createHint() {
    var hint = document.createElement('div');
    hint.style.whiteSpace = 'nowrap';
    hint.style.position = 'absolute';
    hint.style.backgroundColor = '#ffffff';
    hint.style.border = '1px solid gray';
    hint.style.padding = '4px 16px 4px 16px';
    hint.style.borderRadius = '3px';
    hint.style.opacity = '0.8';
    hint.style.fontSize = '9pt';
    return hint;
};

mxGraphHandler.prototype.updateHint = function (me) {
    try {
        if (this.pBounds != null && (this.shape != null || this.livePreviewActive)) {
            if (this.hint == null) {
                this.hint = createHint();
                this.graph.container.appendChild(this.hint);
            }

            var t = this.graph.view.translate;
            var s = this.graph.view.scale;
            var x = this.roundLength((this.bounds.x + this.currentDx) / s - t.x);
            var y = this.roundLength((this.bounds.y + this.currentDy) / s - t.y);

            this.hint.innerHTML = x + ', ' + y;

            this.hint.style.left = Math.round(this.pBounds.x + this.currentDx +
                Math.round((this.pBounds.width - this.hint.clientWidth) / 2)) + 'px';
            this.hint.style.top = Math.round(this.pBounds.y + this.currentDy +
                this.pBounds.height + graph.hintOffset) + 'px';
        }
    } catch(e) { graph.refresh() }
};

mxVertexHandler.prototype.updateHint = function (me) {
    if (this.index != mxEvent.LABEL_HANDLE) {
        if (this.hint == null) {
            this.hint = createHint();
            this.state.view.graph.container.appendChild(this.hint);
        }

        if (this.index == mxEvent.ROTATION_HANDLE) {
            this.hint.innerHTML = this.currentAlpha + '&deg;';
        }
        else {
            var s = this.state.view.scale;
            this.hint.innerHTML = this.roundLength(this.bounds.width / s) + ' x ' +
                this.roundLength(this.bounds.height / s);
        }

        var rot = (this.currentAlpha != null) ? this.currentAlpha : this.state.style[mxConstants.STYLE_ROTATION] || '0';
        var bb = mxUtils.getBoundingBox(this.bounds, rot);

        if (bb == null) {
            bb = this.bounds;
        }

        this.hint.style.left = Math.round(bb.x + Math.round((bb.width - this.hint.clientWidth) / 2)) + 'px';
        this.hint.style.top = Math.round(bb.y + bb.height + graph.hintOffset) + 'px';
    }
};

mxEdgeHandler.prototype.updateHint = function (me, point) {
    if (this.hint == null) {
        this.hint = createHint();
        this.state.view.graph.container.appendChild(this.hint);
    }

    var t = this.graph.view.translate;
    var s = this.graph.view.scale;
    var x = this.roundLength(point.x / s - t.x);
    var y = this.roundLength(point.y / s - t.y);

    this.hint.innerHTML = x + ', ' + y;
    this.hint.style.visibility = 'visible';

    this.hint.style.left = Math.round(me.getGraphX() - this.hint.clientWidth / 2) + 'px';
    this.hint.style.top = (Math.max(me.getGraphY(), point.y) + graph.hintOffset) + 'px';
}

//base64 转image
function createSvgImage(w, h, data, coordWidth, coordHeight) {
    var tmp = unescape(encodeURIComponent(
        '<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">' +
        '<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="' + w + 'px" height="' + h + 'px" ' +
        ((coordWidth != null && coordHeight != null) ? 'viewBox="0 0 ' + coordWidth + ' ' + coordHeight + '" ' : '') +
        'version="1.1">' + data + '</svg>'));

    return new mxImage('data:image/svg+xml;base64,' + ((window.btoa) ? btoa(tmp) : Base64.encode(tmp, true)), w, h)
};

function xmlToPath(str) {
    var xml = "";
    var path = str.split(" ");
    for (var i = 0; i <= path.length; i++) {
        if (path[i] == "M" || path[i] == "m") {
            xml = xml + "<move x=\"" + Math.floor(path[i + 1]) + "\" y=\"" + Math.floor(path[i + 2]) + "\"/>";
        }
        else if (path[i] == "L" || path[i] == "l") {
            xml = xml + "<line x=\"" + Math.floor(path[i + 1]) + "\" y=\"" + Math.floor(path[i + 2]) + "\"/>";
        }
        else if (path[i] == "C" || path[i] == "c") {
            xml = xml + "<curve " + "x1 = \"" + Math.floor(path[i + 1]) + "\" y1 = \"" + Math.floor(path[i + 2]) + "\" x2 = \"" + Math.floor(path[i + 3]) + "\" y2 =\"" + Math.floor(path[i + 4]) + "\" x3=\"" + Math.floor(path[i + 5]) + "\" y3=\"" + Math.floor(path[i + 6]) + "\"/>";
            // xml = xml + "<curve rx=\"" + path[i - 2] / 2 + "ry=\"" + path[i - 1] / 2 + "\" x-axis-rotation=\"" + 0 + "\" large-arc-flag=\"" + 0 + "\" sweep-flag=\"" + 1 + "\" x=\"" + path[i + 5] + "\" y=\"" + path[i + 6] + "/>";
        }
        else if (path[i] == "z" || path[i] == "Z") {
            xml = xml + "<close/>"
        }
        else if (path[i] == "S" || path[i] == "s") {
            xml = xml + "<quad " + "x1 = \"" + Math.floor(path[i + 1]) + "\" y1 = \"" + Math.floor(path[i + 2]) + "\" x2 = \"" + Math.floor(path[i + 3]) + "\" y2 =\"" + Math.floor(path[i + 4]) + "\"/>"
        }
    }
    return xml;
}