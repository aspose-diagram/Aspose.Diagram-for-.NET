var Vsdx = function () {

}

Vsdx.prototype.export = function (filename, format) {
    var idsMap = {};
    var idsCounter = 1;

    var pagesName = [];
    var pages = {};
    var PageLayers = [];
    var ModelsAttr = [];
    var shapesXml = [];
    var images = [];
    var pagesXml = [];

    this.exportVsdx(idsMap, idsCounter, pagesName, images, PageLayers, ModelsAttr, pagesXml, filename, format);
}

Vsdx.prototype.exportVsdx = function (idsMap, idsCounter, pagesName, images, PageLayers, ModelsAttr, shapesXml, filename, format) {
    graph.vsdxCanvas = new mxVsdxCanvas2D();
    var idsMap = {};
    var idsCounter = 1;

    if (graph.pages != null && graph.isEnabled()) {
        var pagesName = [];
        var pages = {};
        var PageLayers = [];
        var ModelsAttr = [];
        var pagesXml = [];


        var getCellVsdxId = mxUtils.bind(this, function (cellId) {
            var vsdxId = idsMap[cellId];

            if (vsdxId == null) {
                vsdxId = idsCounter++;
                idsMap[cellId] = vsdxId;
            }
            return vsdxId;
        })

        var collectLayers = mxUtils.bind(this, function (graph, diagramName) {
            var pageLayers = {};
            var layers = graph.model.getChildCells(graph.model.root);
            pageLayers["name"] = diagramName;
            pageLayers["pagelay"] = [];

            for (var k = 0; k < layers.length; k++) {
                if (layers[k].visible) {
                    pageLayers["pagelay"].push({
                        name: layers[k].value || 'Background',
                        visible: layers[k].visible,
                        locked: layers[k].style && layers[k].style.indexOf('locked=1') >= 0
                    });
                }
            }

            PageLayers.push(pageLayers);
        })

        var convertMxModel2Page = mxUtils.bind(this, function (graph, modelAttrib) {
            var xmlDoc = mxUtils.createXmlDocument();

            var root = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "PageContents");

            root.setAttributeNS('http://www.w3.org/2000/xmlns/', 'xmlns', Vsdx.prototype.XMLNS);
            root.setAttributeNS('http://www.w3.org/2000/xmlns/', "xmlns:r", Vsdx.prototype.XMLNS_R);

            var shapes = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Shapes");
            root.appendChild(shapes);

            var model = graph.model;

            var t = graph.view.translate;
            var s = graph.view.scale;
            var bounds = graph.getGraphBounds();

            graph.vsdxCanvas.shiftX = 0;
            graph.vsdxCanvas.shiftY = 0;

            if (bounds.x / s < t.x || bounds.y / s < t.y) {
                graph.vsdxCanvas.shiftX = Math.ceil((t.x - bounds.x / s) / graph.pageFormat.width) * graph.pageFormat.width;
                graph.vsdxCanvas.shiftY = Math.ceil((t.y - bounds.y / s) / graph.pageFormat.height) * graph.pageFormat.height;
            }

            graph.vsdxCanvas.save();
            graph.vsdxCanvas.translate(-t.x, -t.y);
            graph.vsdxCanvas.scale(1 / s);
            graph.vsdxCanvas.newPage();

            var layers = graph.model.getChildCells(graph.model.root);
            var layerIdsMaps = {};

            for (var k = 0; k < layers.length; k++) {
                layerIdsMaps[layers[k].id] = k;
            }

            for (var id in model.cells) {
                var cell = model.cells[id];
                //top-most cells
                var layerIndex = cell.parent != null ? layerIdsMaps[cell.parent.id] : null;

                if (layerIndex != null) {
                    var shape = convertMxCell2Shape(cell, layerIndex, graph, xmlDoc, modelAttrib.pageHeight);

                    if (shape != null)
                        shapes.appendChild(shape);
                }
            }

            var connects = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Connects");
            root.appendChild(connects);

            for (var id in model.cells) {
                var cell = model.cells[id];

                if (cell.edge) {
                    if (cell.source) {
                        var connect = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Connect");
                        connect.setAttribute("FromSheet", getCellVsdxId(cell.id));
                        connect.setAttribute("FromCell", "BeginX");
                        connect.setAttribute("ToSheet", getCellVsdxId(cell.source.id));
                        connects.appendChild(connect);
                    }

                    if (cell.target) {
                        var connect = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Connect");
                        connect.setAttribute("FromSheet", getCellVsdxId(cell.id));
                        connect.setAttribute("FromCell", "EndX");
                        connect.setAttribute("ToSheet", getCellVsdxId(cell.target.id));
                        connects.appendChild(connect);
                    }
                }
            }

            xmlDoc.appendChild(root);

            graph.vsdxCanvas.restore();

            return xmlDoc;
        })

        var addPagesXML = mxUtils.bind(this, function (pages) {
            var i = 1;
            for (var name in pages) {
                var pageName = "page" + i + ".xml";

                var xmlDoc = pages[name];
                pagesXml.push(this.writeXmlDoc2Zip(Vsdx.prototype.VISIO_PAGES + pageName, xmlDoc));
                i++;
            }
        })

        var convertMxCell2Shape = mxUtils.bind(this, function (cell, layerIndex, graph, xmlDoc, parentHeight, parentGeo, isChild) {
            var geo = cell.geometry;

            if (geo != null) {
                if (geo.relative && parentGeo) {
                    geo = geo.clone();
                    geo.x *= parentGeo.width;
                    geo.y *= parentGeo.height;
                    geo.relative = 0;
                }

                var vsdxId = getCellVsdxId(cell.id);

                if (!cell.treatAsSingle && cell.getChildCount() > 0) //Group
                {
                    var shape = this.createShape(vsdxId + "10000", geo, layerIndex, xmlDoc, parentHeight, isChild);
                    shape.setAttribute("Type", "Group");

                    var gShapes = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Shapes");

                    graph.vsdxCanvas.save();
                    graph.vsdxCanvas.translate(-geo.x, -geo.y);

                    var newGeo = geo.clone();
                    newGeo.x = 0;
                    newGeo.y = 0;
                    cell.setGeometry(newGeo);
                    cell.treatAsSingle = true;
                    var subShape = convertMxCell2Shape(cell, layerIndex, graph, xmlDoc, geo.height, geo, true);
                    cell.treatAsSingle = false;
                    cell.setGeometry(geo);

                    if (subShape != null) {
                        gShapes.appendChild(subShape);
                    }

                    for (var i = 0; i < cell.getChildCount(); i++) {
                        var child = cell.children[i];

                        var subShape = convertMxCell2Shape(child, layerIndex, graph, xmlDoc, geo.height, geo, true);

                        if (subShape != null) {
                            gShapes.appendChild(subShape);
                        }
                    }

                    shape.appendChild(gShapes);

                    graph.vsdxCanvas.restore();

                    return shape;
                } else if (cell.vertex) {

                    var shape = this.createShape(vsdxId, geo, layerIndex, xmlDoc, parentHeight, isChild);

                    var state = graph.view.getState(cell, true);

                    this.applyMxCellStyle(state, shape, xmlDoc);

                    graph.vsdxCanvas.newShape(shape, state, xmlDoc);

                    if (state.text != null && state.text.checkBounds()) {
                        graph.vsdxCanvas.save();
                        state.text.paint(graph.vsdxCanvas);
                        graph.vsdxCanvas.restore();
                    }
                    if (state.shape != null && state.shape.checkBounds()) {
                        graph.vsdxCanvas.save();
                        state.shape.paint(graph.vsdxCanvas);
                        graph.vsdxCanvas.restore();
                    }

                    shape.appendChild(graph.vsdxCanvas.getShapeGeo());

                    graph.vsdxCanvas.endShape();
                    shape.setAttribute("Type", graph.vsdxCanvas.getShapeType());

                    return shape;
                } else {
                    return createEdge(cell, layerIndex, graph, xmlDoc, parentHeight, isChild);
                }
            } else {
                return null;
            }
        })

        var createEdge = mxUtils.bind(this, function (cell, layerIndex, graph, xmlDoc, parentHeight, isChild) {
            var state = graph.view.getState(cell, true);

            if (state == null || state.absolutePoints == null || state.cellBounds == null) {
                return null;
            }

            var shape = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Shape");
            var vsdxId = getCellVsdxId(cell.id);
            shape.setAttribute("ID", vsdxId);
            shape.setAttribute("NameU", "Dynamic connector." + vsdxId);
            shape.setAttribute("Name", "Dynamic connector." + vsdxId);
            shape.setAttribute("Type", "Shape");
            shape.setAttribute("Master", "4"); //Dynamic Connector Master

            var s = graph.vsdxCanvas.state;
            var points = state.absolutePoints;
            var bounds = state.cellBounds;

            var hw = bounds.width / 2,
                hh = bounds.height / 2;

            shape.appendChild(this.createCellElemScaled("PinX", bounds.x + hw, xmlDoc));
            shape.appendChild(this.createCellElemScaled("PinY", parentHeight - bounds.y - hh, xmlDoc));
            shape.appendChild(this.createCellElemScaled("Width", bounds.width, xmlDoc));
            shape.appendChild(this.createCellElemScaled("Height", bounds.height, xmlDoc));
            shape.appendChild(this.createCellElemScaled("LocPinX", hw, xmlDoc));
            shape.appendChild(this.createCellElemScaled("LocPinY", hh, xmlDoc));

            graph.vsdxCanvas.newEdge(shape, state, xmlDoc);

            var calcVsdxPoint = function (p, noHeight) {
                var x = p.x,
                    y = p.y;
                x = (x * s.scale - bounds.x + s.dx + (isChild ? 0 : graph.vsdxCanvas.shiftX));
                y = ((noHeight ? 0 : bounds.height) - y * s.scale + bounds.y - s.dy - (isChild ? 0 : graph.vsdxCanvas.shiftY));
                return { x: x, y: y };
            };

            var p0 = calcVsdxPoint(points[0], true);

            shape.appendChild(this.createCellElemScaled("BeginX", bounds.x + p0.x, xmlDoc, "_WALKGLUE(BegTrigger,EndTrigger,WalkPreference)"));
            shape.appendChild(this.createCellElemScaled("BeginY", parentHeight - bounds.y + p0.y, xmlDoc, "_WALKGLUE(BegTrigger,EndTrigger,WalkPreference)"));

            var pe = calcVsdxPoint(points[points.length - 1], true);

            shape.appendChild(this.createCellElemScaled("EndX", bounds.x + pe.x, xmlDoc, "_WALKGLUE(EndTrigger,BegTrigger,WalkPreference)"));
            shape.appendChild(this.createCellElemScaled("EndY", parentHeight - bounds.y + pe.y, xmlDoc, "_WALKGLUE(EndTrigger,BegTrigger,WalkPreference)"));

            shape.appendChild(this.createCellElem("BegTrigger", "2", xmlDoc, cell.source ? "_XFTRIGGER(Sheet." + getCellVsdxId(cell.source.id) + "!EventXFMod)" : null));
            shape.appendChild(this.createCellElem("EndTrigger", "2", xmlDoc, cell.target ? "_XFTRIGGER(Sheet." + getCellVsdxId(cell.target.id) + "!EventXFMod)" : null));
            shape.appendChild(this.createCellElem("ConFixedCode", "6", xmlDoc));
            shape.appendChild(this.createCellElem("LayerMember", layerIndex + "", xmlDoc));

            this.applyMxCellStyle(state, shape, xmlDoc);

            var startFill = state.style[mxConstants.STYLE_STARTFILL];
            var startArrow = state.style[mxConstants.STYLE_STARTARROW];
            var startSize = state.style[mxConstants.STYLE_STARTSIZE];

            var type = this.getArrowType(startArrow, startFill);
            shape.appendChild(this.createCellElem("BeginArrow", type, xmlDoc));
            shape.appendChild(this.createCellElem("BeginArrowSize", this.getArrowSize(startSize), xmlDoc));

            var endFill = state.style[mxConstants.STYLE_ENDFILL];
            var endArrow = state.style[mxConstants.STYLE_ENDARROW];
            var endSize = state.style[mxConstants.STYLE_ENDSIZE];

            var type = this.getArrowType(endArrow, endFill);
            shape.appendChild(this.createCellElem("EndArrow", type, xmlDoc));
            shape.appendChild(this.createCellElem("EndArrowSize", this.getArrowSize(endSize), xmlDoc));

            if (state.text != null && state.text.checkBounds()) {
                graph.vsdxCanvas.save();
                state.text.paint(graph.vsdxCanvas);
                graph.vsdxCanvas.restore();
            }

            var geoSec = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Section");

            geoSec.setAttribute("N", "Geometry");
            geoSec.setAttribute("IX", "0");

            for (var i = 0; i < points.length; i++) {
                var p = calcVsdxPoint(points[i]);
                geoSec.appendChild(this.createRow(i == 0 ? "MoveTo" : "LineTo", (i + 1), p.x, p.y, xmlDoc));
            }

            geoSec.appendChild(this.createCellElem("NoFill", "1", xmlDoc));
            geoSec.appendChild(this.createCellElem("NoLine", "0", xmlDoc));
            shape.appendChild(geoSec);

            return shape;
        })

        for (var i = 0; i < graph.pages.length; i++) {
            var modelsAttr = {};

            var page = graph.pages[i];
            if (graph.currentPage != page) {
                graph.page.selectPage(page, true);
            }
            var diagramName = page.getName();
            var temp = null;
            try {
                var modelAttrib = this.getGraphAttributes(graph);
                pages[diagramName] = convertMxModel2Page(graph, modelAttrib);
                collectLayers(graph, diagramName);
                pagesName.push(diagramName);
                modelsAttr["diagramName"] = diagramName;
                modelsAttr["modelAttr"] = modelAttrib;
                ModelsAttr.push(modelsAttr);
            } finally {
                if (temp != null) {
                    graph.stylesheet = temp;
                    graph.refresh();
                }
            }
        }
    }

    addPagesXML(pages);

    var images = [];

    for (var cell in graph.model.cells) {
        if (graph.model.cells[cell].style != null || graph.model.cells[cell].style != undefined) {
            var img = graph.getCellStyle(graph.model.cells[cell]).image;

            if (img != null) {
                var ss = new Image();
                ss.src = img;
                var imgs = {};
                imgs["name"] = cell + "." + img.substring('data:image/'.length, img.indexOf(';'));
                imgs["xml"] = ss.src;

                images.push(imgs);
            }
        }
    }

    XDownload(exportAction, filename, {
        "filename": filename,
        "pagesName": pagesName,
        "images": images,
        "shapesXml": shapesXml,
        'ModelsAttr': ModelsAttr,
        'PageLayers': PageLayers,
        'pagesXml': pagesXml,
        "format": format,
        'currentFile': graph.page.compress(graph.page.currentFile.data)
    });
}


Vsdx.prototype.createShape = function (id, geo, layerIndex, xmlDoc, parentHeight, isChild) {
    var shape = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Shape");

    shape.setAttribute("ID", id);
    shape.setAttribute("NameU", "Shape" + id);
    shape.setAttribute("LineStyle", "0");
    shape.setAttribute("FillStyle", "0");
    shape.setAttribute("TextStyle", "0");

    var hw = geo.width / 2,
        hh = geo.height / 2;

    shape.appendChild(this.createCellElemScaled("PinX", geo.x + hw + (isChild ? 0 : graph.vsdxCanvas.shiftX), xmlDoc));
    shape.appendChild(this.createCellElemScaled("PinY", parentHeight - geo.y - hh - (isChild ? 0 : graph.vsdxCanvas.shiftY), xmlDoc));
    shape.appendChild(this.createCellElemScaled("Width", geo.width, xmlDoc));
    shape.appendChild(this.createCellElemScaled("Height", geo.height, xmlDoc));
    shape.appendChild(this.createCellElemScaled("LocPinX", hw, xmlDoc));
    shape.appendChild(this.createCellElemScaled("LocPinY", hh, xmlDoc));
    shape.appendChild(this.createCellElem("LayerMember", layerIndex + "", xmlDoc));

    return shape;
};



Vsdx.prototype.createElt = function (doc, ns, name) {
    return (doc.createElementNS != null) ? doc.createElementNS(ns, name) : doc.createElement(name);
};

Vsdx.prototype.createRow = function (type, index, x, y, xmlDoc) {
    var row = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Row");
    row.setAttribute("T", type);
    row.setAttribute("IX", index);
    row.appendChild(this.createCellElemScaled("X", x, xmlDoc));
    row.appendChild(this.createCellElemScaled("Y", y, xmlDoc));
    return row;
};

Vsdx.prototype.applyMxCellStyle = function (state, shape, xmlDoc) {
    var fillClr = state.style[mxConstants.STYLE_FILLCOLOR];

    if (!fillClr || fillClr == "none") {
        shape.appendChild(this.createCellElem("FillPattern", 0, xmlDoc));
    } else {
        shape.appendChild(this.createCellElem("FillForegnd", fillClr, xmlDoc));
        var gradClr = state.style[mxConstants.STYLE_GRADIENTCOLOR];

        if (gradClr && gradClr != "none") {
            shape.appendChild(this.createCellElem("FillBkgnd", gradClr, xmlDoc));

            var gradDir = state.style[mxConstants.STYLE_GRADIENT_DIRECTION];
            var dir = 28;

            if (gradDir) {
                switch (gradDir) {
                    case mxConstants.DIRECTION_EAST:
                        dir = 25;
                        break
                    case mxConstants.DIRECTION_WEST:
                        dir = 27;
                        break
                    case mxConstants.DIRECTION_NORTH:
                        dir = 30;
                        break
                }
            }
            shape.appendChild(this.createCellElem("FillPattern", dir, xmlDoc));
        }
    }

    var strokeClr = state.style[mxConstants.STYLE_STROKECOLOR];

    if (!strokeClr || strokeClr == "none")
        shape.appendChild(this.createCellElem("LinePattern", 0, xmlDoc));
    else
        shape.appendChild(this.createCellElem("LineColor", strokeClr, xmlDoc));

    var strokeW = state.style[mxConstants.STYLE_STROKEWIDTH];
    if (strokeW) shape.appendChild(this.createCellElemScaled("LineWeight", strokeW, xmlDoc));


    var opacity = state.style[mxConstants.STYLE_OPACITY];
    var fillOpaq;
    var strkOpaq;

    if (opacity) {
        fillOpaq = opacity;
        strkOpaq = opacity;
    } else {
        fillOpaq = state.style[mxConstants.STYLE_FILL_OPACITY];
        strkOpaq = state.style[mxConstants.STYLE_STROKE_OPACITY];
    }

    if (fillOpaq) shape.appendChild(this.createCellElem("FillForegndTrans", 1 - parseInt(fillOpaq) / 100.0, xmlDoc));
    if (strkOpaq) shape.appendChild(this.createCellElem("LineColorTrans", 1 - parseInt(strkOpaq) / 100.0, xmlDoc));

    var isDashed = state.style[mxConstants.STYLE_DASHED];

    if (isDashed == 1) {
        var dashPatrn = state.style[mxConstants.STYLE_DASH_PATTERN];
        var pattern = 9

        if (dashPatrn) {
            switch (dashPatrn) {
                case "1 1":
                    pattern = 10;
                    break;
                case "1 2":
                    pattern = 3;
                    break;
                case "1 4":
                    pattern = 17;
                    break;
            }
        }

        shape.appendChild(this.createCellElem("LinePattern", pattern, xmlDoc));
    }

    var hasShadow = state.style[mxConstants.STYLE_SHADOW];

    if (hasShadow == 1) {
        shape.appendChild(this.createCellElem("ShdwPattern", 1, xmlDoc));
        shape.appendChild(this.createCellElem("ShdwForegnd", '#000000', xmlDoc));
        shape.appendChild(this.createCellElem("ShdwForegndTrans", 0.6, xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwType", 1, xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwOffsetX", '0.02946278254943948', xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwOffsetY", '-0.02946278254943948', xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwScaleFactor", '1', xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwBlur", '0.05555555555555555', xmlDoc));
        shape.appendChild(this.createCellElem("ShapeShdwShow", 2, xmlDoc));
    }

    var flibX = state.style[mxConstants.STYLE_FLIPH];
    if (flibX == 1) shape.appendChild(this.createCellElem("FlipX", 1, xmlDoc));

    var flibY = state.style[mxConstants.STYLE_FLIPV];
    if (flibY == 1) shape.appendChild(this.createCellElem("FlipY", 1, xmlDoc));

    var rounded = state.style[mxConstants.STYLE_ROUNDED];
    if (rounded == 1) shape.appendChild(this.createCellElemScaled("Rounding", state.cell.geometry.width * 0.1, xmlDoc));

    var lbkgnd = state.style[mxConstants.STYLE_LABEL_BACKGROUNDCOLOR];
    if (lbkgnd) shape.appendChild(this.createCellElem("TextBkgnd", lbkgnd, xmlDoc));
};

Vsdx.prototype.getGraphAttributes = function (graph) {
    var attr = {};

    try {
        var bounds = graph.getGraphBounds().clone();
        var sc = graph.view.scale;
        var tr = graph.view.translate;

        var x0 = Math.round(bounds.x / sc) - tr.x;
        var y0 = Math.round(bounds.y / sc) - tr.y;

        var availableWidth = graph.pageFormat.width;
        var availableHeight = graph.pageFormat.height;

        if (x0 < 0) {
            x0 += Math.ceil((tr.x - bounds.x / sc) / availableWidth) * availableWidth;
        }

        if (y0 < 0) {
            y0 += Math.ceil((tr.y - bounds.y / sc) / availableHeight) * availableHeight;
        }

        var hpages = Math.max(1, Math.ceil((bounds.width / sc + x0) / availableWidth));
        var vpages = Math.max(1, Math.ceil((bounds.height / sc + y0) / availableHeight));

        attr['gridEnabled'] = graph.gridEnabled;
        attr['gridSize'] = graph.gridSize;
        attr['guidesEnabled'] = graph.graphHandler.guidesEnabled
        attr['pageVisible'] = graph.pageVisible;
        attr['pageScale'] = graph.pageScale;
        attr['pageWidth'] = graph.pageFormat.width * hpages;
        attr['pageHeight'] = graph.pageFormat.height * vpages;
        attr['backgroundClr'] = graph.backgroundColor;
        attr['mathEnabled'] = graph.mathEnabled;
        attr['shadowVisible'] = graph.shadowVisible;
    } catch (e) {
        //nothing
    }
    return attr;
};

Vsdx.prototype.getArrowType = function (arrow, isFilled) {
    isFilled = isFilled == null ? "1" : isFilled;
    arrow = arrow == null ? "none" : arrow;
    var key = arrow + "|" + isFilled;
    var type = Vsdx.prototype.ARROWS_MAP[key];
    if (type != null)
        return type;
    else
        return 1;
};

Vsdx.prototype.getArrowSize = function (size) {
    if (size == null) return 2;
    if (size <= 2)
        return 0;
    else if (size <= 3)
        return 1;
    else if (size <= 5)
        return 2;
    else if (size <= 7)
        return 3;
    else if (size <= 9)
        return 4;
    else if (size <= 22)
        return 5;
    else
        return 6;
};

Vsdx.prototype.writeXmlDoc2Zip = function (name, xmlDoc, noHeader) {
    return { "name": name, "xml": (noHeader ? "" : "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" + mxUtils.getXml(xmlDoc, '\n')) };
};

Vsdx.prototype.createCellElemScaled = function (name, val, xmlDoc, formula) {
    return this.createCellElem(name, val / Vsdx.prototype.CONVERSION_FACTOR, xmlDoc, formula);
};

Vsdx.prototype.createCellElem = function (name, val, xmlDoc, formula) {
    var cell = this.createElt(xmlDoc, Vsdx.prototype.XMLNS, "Cell");
    cell.setAttribute("N", name);
    cell.setAttribute("V", val);

    if (formula) cell.setAttribute("F", formula);

    return cell;
};


Vsdx.prototype.CONVERSION_FACTOR = 40 * 2.54; //screenCoordinatesPerCm (40) x CENTIMETERS_PER_INCHES (2.54)
Vsdx.prototype.PAGES_TYPE = "http://schemas.microsoft.com/visio/2010/relationships/page";
Vsdx.prototype.RELS_XMLNS = "http://schemas.openxmlformats.org/package/2006/relationships";
Vsdx.prototype.XML_SPACE = "preserve";
Vsdx.prototype.XMLNS_R = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
Vsdx.prototype.XMLNS = "http://schemas.microsoft.com/office/visio/2012/main";
Vsdx.prototype.VISIO_PAGES = "visio/pages/";
Vsdx.prototype.PREFEX = "com/mxgraph/io/vsdx/resources/export/";
Vsdx.prototype.VSDX_ENC = "ISO-8859-1";
Vsdx.prototype.PART_NAME = "PartName";
Vsdx.prototype.CONTENT_TYPES_XML = "[Content_Types].xml";
Vsdx.prototype.VISIO_PAGES_RELS = "visio/pages/_rels/";
Vsdx.prototype.ARROWS_MAP = {
    "none|1": 0,
    "none|0": 0,
    "open|1": 1,
    "open|0": 1,
    "block|1": 4,
    "block|0": 14,
    "classic|1": 5,
    "classic|0": 17,
    "oval|1": 10,
    "oval|0": 20,
    "diamond|1": 11,
    "diamond|0": 22,
    "blockThin|1": 2,
    "blockThin|0": 15,
    "dash|1": 23,
    "dash|0": 23,
    "ERone|1": 24,
    "ERone|0": 24,
    "ERmandOne|1": 25,
    "ERmandOne|0": 25,
    "ERmany|1": 27,
    "ERmany|0": 27,
    "ERoneToMany|1": 28,
    "ERoneToMany|0": 28,
    "ERzeroToMany|1": 29,
    "ERzeroToMany|0": 29,
    "ERzeroToOne|1": 30,
    "ERzeroToOne|0": 30,
    "openAsync|1": 9,
    "openAsync|0": 9
};