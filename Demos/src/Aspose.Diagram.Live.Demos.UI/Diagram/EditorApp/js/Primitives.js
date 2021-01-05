function Primitives(graph) {
    this.graph = this.createTemporaryGraph(graph.getStylesheet());
    this.taglist = new Object();
    this.palettes = new Object();
    this.container = document.getElementsByClassName("content-left")[0];
    this.init();
    this.initPalettes();
}

Primitives.prototype.thumbPadding = 1;
Primitives.prototype.thumbBorder = 1;
Primitives.prototype.thumbWidth = 32;
Primitives.prototype.thumbHeight = 30;
Primitives.prototype.dragPreviewBorder = '1px dashed black';
Primitives.prototype.defaultImageWidth = 80;
Primitives.prototype.defaultImageHeight = 80;
Primitives.prototype.originalNoForeignObject = mxClient.NO_FO;
Primitives.prototype.tooltipBorder = 16;
Primitives.prototype.tooltipDelay = 300;
Primitives.prototype.showTooltips = true;
Primitives.prototype.maxTooltipWidth = 400;
Primitives.prototype.maxTooltipHeight = 400;

Primitives.prototype.init = function () {
    this.layoutManager = new mxLayoutManager(graph);
    this.layoutManager.getLayout = function (cell) {
        var style = graph.getCellStyle(cell);

        if (style != null) {
            if (style['childLayout'] == 'stackLayout') {
                var stackLayout = new mxStackLayout(graph, true);
                stackLayout.resizeParentMax = mxUtils.getValue(style, 'resizeParentMax', '1') == '1';
                stackLayout.horizontal = mxUtils.getValue(style, 'horizontalStack', '1') == '1';
                stackLayout.resizeParent = mxUtils.getValue(style, 'resizeParent', '1') == '1';
                stackLayout.resizeLast = mxUtils.getValue(style, 'resizeLast', '0') == '1';
                stackLayout.spacing = style['stackSpacing'] || stackLayout.spacing;
                stackLayout.border = style['stackBorder'] || stackLayout.border;
                stackLayout.marginLeft = style['marginLeft'] || 0;
                stackLayout.marginRight = style['marginRight'] || 0;
                stackLayout.marginTop = style['marginTop'] || 0;
                stackLayout.marginBottom = style['marginBottom'] || 0;
                stackLayout.fill = true;

                return stackLayout;
            } else if (style['childLayout'] == 'treeLayout') {
                var treeLayout = new mxCompactTreeLayout(graph);
                treeLayout.horizontal = mxUtils.getValue(style, 'horizontalTree', '1') == '1';
                treeLayout.resizeParent = mxUtils.getValue(style, 'resizeParent', '1') == '1';
                treeLayout.groupPadding = mxUtils.getValue(style, 'parentPadding', 20);
                treeLayout.levelDistance = mxUtils.getValue(style, 'treeLevelDistance', 30);
                treeLayout.maintainParentLocation = true;
                treeLayout.edgeRouting = false;
                treeLayout.resetEdges = false;

                return treeLayout;
            } else if (style['childLayout'] == 'flowLayout') {
                var flowLayout = new mxHierarchicalLayout(graph, mxUtils.getValue(style,
                    'flowOrientation', mxConstants.DIRECTION_EAST));
                flowLayout.resizeParent = mxUtils.getValue(style, 'resizeParent', '1') == '1';
                flowLayout.parentBorder = mxUtils.getValue(style, 'parentPadding', 20);
                flowLayout.maintainParentLocation = true;

                // Special undocumented styles for changing the hierarchical
                flowLayout.intraCellSpacing = mxUtils.getValue(style, 'intraCellSpacing', mxHierarchicalLayout.prototype.intraCellSpacing);
                flowLayout.interRankCellSpacing = mxUtils.getValue(style, 'interRankCellSpacing', mxHierarchicalLayout.prototype.interRankCellSpacing);
                flowLayout.interHierarchySpacing = mxUtils.getValue(style, 'interHierarchySpacing', mxHierarchicalLayout.prototype.interHierarchySpacing);
                flowLayout.parallelEdgeSpacing = mxUtils.getValue(style, 'parallelEdgeSpacing', mxHierarchicalLayout.prototype.parallelEdgeSpacing);

                return flowLayout;
            } else if (style['childLayout'] == 'circleLayout') {
                return new mxCircleLayout(graph);
            } else if (style['childLayout'] == 'organicLayout') {
                return new mxFastOrganicLayout(graph);
            }
        }

        return null;
    };

    //#region
    this.pointerUpHandler = mxUtils.bind(this, function () {
        this.showTooltips = true;
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerup' : 'mouseup', this.pointerUpHandler);

    this.pointerDownHandler = mxUtils.bind(this, function () {
        this.showTooltips = false;
        this.hideTooltip();
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerdown' : 'mousedown', this.pointerDownHandler);

    this.pointerMoveHandler = mxUtils.bind(this, function (evt) {
        var src = mxEvent.getSource(evt);

        while (src != null) {
            if (src == this.currentElt) {
                return;
            }

            src = src.parentNode;
        }

        this.hideTooltip();
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointermove' : 'mousemove', this.pointerMoveHandler);

    this.pointerOutHandler = mxUtils.bind(this, function (evt) {
        if (evt.toElement == null && evt.relatedTarget == null) {
            this.hideTooltip();
        }
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerout' : 'mouseout', this.pointerOutHandler);

    mxEvent.addListener(this.container, 'scroll', mxUtils.bind(this, function () {
        this.showTooltips = true;
        this.hideTooltip();
    }));
    //#endregion
}

Primitives.prototype.addGeneralPalette = function (expand) {

    var lineTags = 'line lines connector connectors connection connections arrow arrows ';

    var fns = [
        this.createVertexTemplateEntry('rounded=0;whiteSpace=wrap;html=1;', 120, 60, '', 'Rectangle', null, null, 'rect rectangle box'),
        this.createVertexTemplateEntry('rounded=1;whiteSpace=wrap;html=1;', 120, 60, '', 'Rounded Rectangle', null, null, 'rounded rect rectangle box'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;',
            40, 20, 'Text', 'Text', null, null, 'text textbox textarea label'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=none;fillColor=none;spacing=5;spacingTop=-20;whiteSpace=wrap;overflow=hidden;rounded=0;', 190, 120,
            '<h1>Heading</h1><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>',
            'Textbox', null, null, 'text textbox textarea'),
        this.createVertexTemplateEntry('ellipse;whiteSpace=wrap;html=1;', 120, 80, '', 'Ellipse', null, null, 'oval ellipse state'),
        this.createVertexTemplateEntry('whiteSpace=wrap;html=1;aspect=fixed;', 80, 80, '', 'Square', null, null, 'square'),
        this.createVertexTemplateEntry('ellipse;whiteSpace=wrap;html=1;aspect=fixed;', 80, 80, '', 'Circle', null, null, 'circle'),
        this.createVertexTemplateEntry('shape=process;whiteSpace=wrap;html=1;backgroundOutline=1;', 120, 60, '', 'Process', null, null, 'process task'),
        this.createVertexTemplateEntry('rhombus;whiteSpace=wrap;html=1;', 80, 80, '', 'Diamond', null, null, 'diamond rhombus if condition decision conditional question test'),
        this.createVertexTemplateEntry('shape=parallelogram;perimeter=parallelogramPerimeter;whiteSpace=wrap;html=1;', 120, 60, '', 'Parallelogram'),
        this.createVertexTemplateEntry('shape=hexagon;perimeter=hexagonPerimeter2;whiteSpace=wrap;html=1;', 120, 80, '', 'Hexagon', null, null, 'hexagon preparation'),
        this.createVertexTemplateEntry('triangle;whiteSpace=wrap;html=1;', 60, 80, '', 'Triangle', null, null, 'triangle logic inverter buffer'),
        this.createVertexTemplateEntry('shape=cylinder;whiteSpace=wrap;html=1;boundedLbl=1;backgroundOutline=1;', 60, 80, '', 'Cylinder', null, null, 'cylinder data database'),
        this.createVertexTemplateEntry('ellipse;shape=cloud;whiteSpace=wrap;html=1;', 120, 80, '', 'Cloud', null, null, 'cloud network'),
        this.createVertexTemplateEntry('shape=document;whiteSpace=wrap;html=1;boundedLbl=1;', 120, 80, '', 'Document'),
        this.createVertexTemplateEntry('shape=internalStorage;whiteSpace=wrap;html=1;backgroundOutline=1;', 80, 80, '', 'Internal Storage'),
        this.createVertexTemplateEntry('shape=cube;whiteSpace=wrap;html=1;boundedLbl=1;backgroundOutline=1;darkOpacity=0.05;darkOpacity2=0.1;', 120, 80, '', 'Cube'),
        this.createVertexTemplateEntry('shape=step;perimeter=stepPerimeter;whiteSpace=wrap;html=1;fixedSize=1;', 120, 80, '', 'Step'),
        this.createVertexTemplateEntry('shape=trapezoid;perimeter=trapezoidPerimeter;whiteSpace=wrap;html=1;', 120, 60, '', 'Trapezoid'),
        this.createVertexTemplateEntry('shape=tape;whiteSpace=wrap;html=1;', 120, 100, '', 'Tape'),
        this.createVertexTemplateEntry('shape=note;whiteSpace=wrap;html=1;backgroundOutline=1;darkOpacity=0.05;', 80, 100, '', 'Note'),
        this.createVertexTemplateEntry('shape=card;whiteSpace=wrap;html=1;', 80, 100, '', 'Card'),
        this.createVertexTemplateEntry('shape=callout;whiteSpace=wrap;html=1;perimeter=calloutPerimeter;', 120, 80, '', 'Callout', null, null, 'bubble chat thought speech message'),
        this.createVertexTemplateEntry('shape=umlActor;verticalLabelPosition=bottom;labelBackgroundColor=#ffffff;verticalAlign=top;html=1;outlineConnect=0;', 30, 60, 'Actor', 'Actor', false, null, 'user person human stickman'),
        this.createVertexTemplateEntry('shape=xor;whiteSpace=wrap;html=1;', 60, 80, '', 'Or', null, null, 'logic or'),
        this.createVertexTemplateEntry('shape=or;whiteSpace=wrap;html=1;', 60, 80, '', 'And', null, null, 'logic and'),
        this.createVertexTemplateEntry('shape=dataStorage;whiteSpace=wrap;html=1;', 100, 80, '', 'Data Storage'),

        this.addEntry('curve', mxUtils.bind(this, function () {
            var cell = new mxCell('', new mxGeometry(0, 0, 50, 50), 'curved=1;endArrow=classic;html=1;');
            cell.geometry.setTerminalPoint(new mxPoint(0, 50), true);
            cell.geometry.setTerminalPoint(new mxPoint(50, 0), false);
            cell.geometry.points = [new mxPoint(50, 50), new mxPoint(0, 0)];
            cell.geometry.relative = true;
            cell.edge = true;

            return this.createItem(cell, 'Curve', '', cell.geometry.width, cell.geometry.height);
        })),

        this.createEdgeTemplateEntry('shape=flexArrow;endArrow=classic;startArrow=classic;html=1;', 50, 50, '', 'Bidirectional Arrow', null, lineTags + 'bidirectional'),
        this.createEdgeTemplateEntry('shape=flexArrow;endArrow=classic;html=1;', 50, 50, '', 'Arrow', null, lineTags + 'directional directed'),
        this.createEdgeTemplateEntry('shape=link;html=1;', 50, 50, '', 'Link', null, lineTags + 'link'),
        this.createEdgeTemplateEntry('endArrow=none;dashed=1;html=1;', 50, 50, '', 'Dashed Line', null, lineTags + 'dashed undirected no'),
        this.createEdgeTemplateEntry('endArrow=none;html=1;', 50, 50, '', 'Line', null, lineTags + 'simple undirected plain blank no'),
        this.createEdgeTemplateEntry('endArrow=classic;startArrow=classic;html=1;', 50, 50, '', 'Bidirectional Connector', null, lineTags + 'bidirectional'),
        this.createEdgeTemplateEntry('endArrow=classic;html=1;', 50, 50, '', 'Directional Connector', null, lineTags + 'directional directed')
    ];

    this.addPaletteFunctions('general', 'General', (expand != null) ? expand : true, fns);

}

Primitives.prototype.addArrowsPalette = function (expand) {
    var fns = this.addStencilPalette('arrows', 'Arrows', '/Diagram/EditorApp/xml/Arrows.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('Arrows', 'Arrows', true, fns);
};

Primitives.prototype.addUserInterfacePalette = function (expand) {
    var fns = this.addStencilPalette('userInterface', 'UserInterface', '/Diagram/EditorApp/xml/UserInterface.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('UserInterface', 'UserInterface', true, fns);
};

Primitives.prototype.addBasicPalette = function (expand) {
    var fns = this.addStencilPalette('basic', 'Basic', '/Diagram/EditorApp/xml/Basic.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('Basic', 'Basic', true, fns);
};

Primitives.prototype.addDemoPalette = function (expand) {
    var fns = this.addStencilPalette('demo', 'Demo', '/Diagram/EditorApp/xml/demo.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('Demo', 'Demo', true, fns);
};

Primitives.prototype.addFlowchartPalette = function (expand) {
    var fns = this.addStencilPalette('flowchart', 'Flowchart', '/Diagram/EditorApp/xml/flowchart.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('flowchart', 'Flowchart', true, fns);
};

Primitives.prototype.addUmlPalette = function (expand, display, doc) {
    // Reusable cells
    var field = new mxCell('+ field: type', new mxGeometry(0, 0, 100, 26), 'text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;');
    field.vertex = true;

    var divider = new mxCell('', new mxGeometry(0, 0, 40, 8), 'line;strokeWidth=1;fillColor=none;align=left;verticalAlign=middle;spacingTop=-1;spacingLeft=3;spacingRight=3;rotatable=0;labelPosition=right;points=[];portConstraint=eastwest;');
    divider.vertex = true;

    // Default tags
    var dt = 'uml static class ';

    var fns = [
        this.createVertexTemplateEntry('html=1;', 110, 50, 'Object', 'Object', null, null, dt + 'object instance'),
        this.createVertexTemplateEntry('verticalAlign=top;align=left;overflow=fill;html=1;', 180, 90,
            '<div style="box-sizing:border-box;width:100%;background:#e4e4e4;padding:2px;">Tablename</div>' +
            '<table style="width:100%;font-size:1em;" cellpadding="2" cellspacing="0">' +
            '<tr><td>PK</td><td>uniqueId</td></tr><tr><td>FK1</td><td>' +
            'foreignKey</td></tr><tr><td></td><td>fieldname</td></tr></table>', 'Entity', null, null, 'er entity table'),
        this.createVertexTemplateEntry('html=1;', 110, 50, '&laquo;interface&raquo;<br><b>Name</b>', 'Interface', null, null, dt + 'interface object instance annotated annotation'),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function () {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<i>&lt;&lt;Interface&gt;&gt;</i><br/><b>Interface</b></p>' +
                '<hr size="1"/><p style="margin:0px;margin-left:4px;">+ field1: Type<br/>' +
                '+ field2: Type</p>' +
                '<hr size="1"/><p style="margin:0px;margin-left:4px;">' +
                '+ method1(Type): Type<br/>' +
                '+ method2(Type, Type): Type</p>', new mxGeometry(0, 0, 190, 140),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Interface 2');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function () {
            var cell = new mxCell('Classname', new mxGeometry(0, 0, 160, 90),
                'swimlane;fontStyle=1;align=center;verticalAlign=top;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;');
            cell.vertex = true;
            cell.insert(field.clone());
            cell.insert(divider.clone());
            cell.insert(this.cloneCell(field, '+ method(type): type'));

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Class');
        })),
        this.addEntry(dt + 'section subsection', mxUtils.bind(this, function () {
            var cell = new mxCell('Classname', new mxGeometry(0, 0, 140, 110),
                'swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;');
            cell.vertex = true;
            cell.insert(field.clone());
            cell.insert(field.clone());
            cell.insert(field.clone());

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Class 2');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function () {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><div style="height:2px;"></div>', new mxGeometry(0, 0, 140, 60),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 3');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function () {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><div style="height:2px;"></div><hr size="1"/><div style="height:2px;"></div>', new mxGeometry(0, 0, 140, 60),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 4');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function () {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><p style="margin:0px;margin-left:4px;">+ field: Type</p><hr size="1"/>' +
                '<p style="margin:0px;margin-left:4px;">+ method(): Type</p>', new mxGeometry(0, 0, 160, 90),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 5');
        })),
        this.addEntry('uml relation', mxUtils.bind(this, function () {
            var edge = new mxCell('name', new mxGeometry(0, 0, 0, 0), 'endArrow=block;endFill=1;html=1;edgeStyle=orthogonalEdgeStyle;align=left;verticalAlign=top;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.geometry.x = -1;
            edge.edge = true;

            var cell = new mxCell('1', new mxGeometry(-1, 0, 0, 0), 'resizable=0;html=1;align=left;verticalAlign=bottom;labelBackgroundColor=#ffffff;fontSize=10;');
            cell.geometry.relative = true;
            cell.setConnectable(false);
            cell.vertex = true;
            edge.insert(cell);

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Relation 1');
        })),
        this.addEntry('uml relation', mxUtils.bind(this, function () {
            var edge = new mxCell('Relation', new mxGeometry(0, 0, 0, 0), 'endArrow=open;html=1;endSize=12;startArrow=diamondThin;startSize=14;startFill=0;edgeStyle=orthogonalEdgeStyle;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.edge = true;

            var cell1 = new mxCell('0..n', new mxGeometry(-1, 0, 0, 0), 'resizable=0;html=1;align=left;verticalAlign=top;labelBackgroundColor=#ffffff;fontSize=10;');
            cell1.geometry.relative = true;
            cell1.setConnectable(false);
            cell1.vertex = true;
            edge.insert(cell1);

            var cell2 = new mxCell('1', new mxGeometry(1, 0, 0, 0), 'resizable=0;html=1;align=right;verticalAlign=top;labelBackgroundColor=#ffffff;fontSize=10;');
            cell2.geometry.relative = true;
            cell2.setConnectable(false);
            cell2.vertex = true;
            edge.insert(cell2);

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Relation 2');
        })),
        this.addEntry('uml association', mxUtils.bind(this, function () {
            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'endArrow=none;html=1;edgeStyle=orthogonalEdgeStyle;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.edge = true;

            var cell1 = new mxCell('parent', new mxGeometry(-1, 0, 0, 0), 'resizable=0;html=1;align=left;verticalAlign=bottom;labelBackgroundColor=#ffffff;fontSize=10;');
            cell1.geometry.relative = true;
            cell1.setConnectable(false);
            cell1.vertex = true;
            edge.insert(cell1);

            var cell2 = new mxCell('child', new mxGeometry(1, 0, 0, 0), 'resizable=0;html=1;align=right;verticalAlign=bottom;labelBackgroundColor=#ffffff;fontSize=10;');
            cell2.geometry.relative = true;
            cell2.setConnectable(false);
            cell2.vertex = true;
            edge.insert(cell2);

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Association 1');
        })),
        this.addEntry('uml aggregation', mxUtils.bind(this, function () {
            var edge = new mxCell('1', new mxGeometry(0, 0, 0, 0), 'endArrow=open;html=1;endSize=12;startArrow=diamondThin;startSize=14;startFill=0;edgeStyle=orthogonalEdgeStyle;align=left;verticalAlign=bottom;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.geometry.x = -1;
            edge.geometry.y = 3;
            edge.edge = true;

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Aggregation 1');
        })),
        this.createEdgeTemplateEntry('endArrow=open;endSize=12;dashed=1;html=1;', 160, 0, 'Use', 'Dependency', null, 'uml dependency use'),
        this.createEdgeTemplateEntry('endArrow=block;dashed=1;endFill=0;endSize=12;html=1;', 160, 0, '', 'Implementation', null, 'uml realization implementation'),
        this.createEdgeTemplateEntry('endArrow=diamondThin;endFill=0;endSize=24;html=1;', 160, 0, '', 'Aggregation 2', null, 'uml aggregation'),
        this.createEdgeTemplateEntry('endArrow=open;endFill=1;endSize=12;html=1;', 160, 0, '', 'Association 3', null, 'uml association')
    ];

    this.addPaletteFunctions('uml', 'UML', expand, fns);
};

Primitives.prototype.createVertexTemplateFromCells = function (cells, width, height, title, showLabel, allowCellsInserted) {
    return this.createItem(cells, title, showLabel, width, height, allowCellsInserted);
};

Primitives.prototype.createEdgeTemplateFromCells = function (cells, width, height, title, showLabel, allowCellsInserted) {
    return this.createItem(cells, title, showLabel, width, height, allowCellsInserted);
};

Primitives.prototype.addStencilPalette = function (id, title, stencilFile, style, ignore, onInit, scale, tags, customFns) {
    var fns = [];
    if (customFns != null) {
        for (var i = 0; i < customFns.length; i++) {
            fns.push(customFns[i]);
        }
    }

    var xmlDoc = loadXMLDoc(stencilFile);

    var postStencilLoad = mxUtils.bind(this, function (packageName, stencilName, displayName, w, h) {
        if (ignore == null || mxUtils.indexOf(ignore, stencilName) < 0) {

            var tmp = this.getTagsForStencil(packageName, stencilName);
            var tmpTags = (tags != null) ? tags[stencilName] : null;

            if (tmpTags != null) {
                tmp.push(tmpTags);
            }

            fns.push(this.createVertexTemplateEntry('shape=' + packageName + stencilName.toLowerCase() + style,
                Math.round(w), Math.round(h), '', stencilName.replace(/_/g, ' '), null, null, this.filterTags(tmp.join(' '))));
        }
    })

    if (xmlDoc != null) {
        mxStencilRegistry.packages[stencilFile] = xmlDoc;
        install = true;
        mxStencilRegistry.parseStencilSet(xmlDoc.documentElement, postStencilLoad, install);
    }

    return fns;
}

function loadXMLDoc(dname) {
    if (window.XMLHttpRequest) {
        xhttp = new XMLHttpRequest();
    } else {
        xhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xhttp.open("GET", dname, false);
    xhttp.send();
    return xhttp.responseXML;
}

/**
 * Creates the array of tags for the given stencil. Duplicates are allowed and will be filtered out later.
 */
Primitives.prototype.getTagsForStencil = function (packageName, stencilName, moreTags) {
    var tags = packageName.split('.');

    for (var i = 1; i < tags.length; i++) {
        tags[i] = tags[i].replace(/_/g, ' ')
    }

    tags.push(stencilName.replace(/_/g, ' '));

    if (moreTags != null) {
        tags.push(moreTags);
    }

    return tags.slice(1, tags.length);
};


/**
 * Adds shape search UI.
 */
Primitives.prototype.filterTags = function (tags) {
    if (tags != null) {
        var arr = tags.split(' ');
        var result = [];
        var hash = {};

        // Ignores tags with leading numbers, strips trailing numbers
        for (var i = 0; i < arr.length; i++) {
            // Removes duplicates
            if (hash[arr[i]] == null) {
                hash[arr[i]] = '1';
                result.push(arr[i]);
            }
        }

        return result.join(' ');
    }

    return null;
};


Primitives.prototype.addEntry = function (tags, fn) {
    if (this.taglist != null && tags != null && tags.length > 0) {
        // Replaces special characters
        var tmp = tags.toLowerCase().replace(/[\/\,\(\)]/g, ' ').split(' ');

        var doAddEntry = mxUtils.bind(this, function (tag) {
            if (tag != null && tag.length > 1) {
                var entry = this.taglist[tag];

                if (typeof entry !== 'object') {
                    entry = { entries: [], dict: new mxDictionary() };
                    this.taglist[tag] = entry;
                }

                // Ignores duplicates
                if (entry.dict.get(fn) == null) {
                    entry.dict.put(fn, fn);
                    entry.entries.push(fn);
                }
            }
        });

        for (var i = 0; i < tmp.length; i++) {
            doAddEntry(tmp[i]);

            // Adds additional entry with removed trailing numbers
            var normalized = tmp[i].replace(/\.*\d*$/, '');

            if (normalized != tmp[i]) {
                doAddEntry(normalized);
            }
        }
    }

    return fn;
};


Primitives.prototype.createVertexTemplateEntry = function (style, width, height, value, title, showLabel, showTitle, tags) {
    return this.addEntry(tags, mxUtils.bind(this, function () {
        return this.createVertexTemplate(style, width, height, value, title, showLabel, showTitle);
    }))
}


Primitives.prototype.createEdgeTemplateEntry = function (style, width, height, value, title, showLabel, tags) {
    return this.addEntry(tags, mxUtils.bind(this, function () {
        return this.createEdgeTemplate(style, width, height, value, title, showLabel);
    }))
}


Primitives.prototype.createVertexTemplate = function (style, width, height, value, title, showLabel, showTitle) {
    var vertex = new mxCell((value != null) ? value : '', new mxGeometry(0, 0, width, height), style);
    vertex.setVertex(true);
    return this.createItem(vertex, title, showLabel, width, height);
}


Primitives.prototype.createEdgeTemplate = function (style, width, height, value, title, showLabel) {

    var cell = new mxCell((value != null) ? value : '', new mxGeometry(0, 0, width, height), style);
    cell.geometry.setTerminalPoint(new mxPoint(0, height), true);
    cell.geometry.setTerminalPoint(new mxPoint(width, 0), false);
    cell.geometry.relative = true;
    cell.edge = true;

    return this.createItem(cell, title, showLabel, width, height);
};


Primitives.prototype.createItem = function (cell, title, showLabel, width, height) {
    var elt = document.createElement('a');
    elt.className = 'geItem';
    elt.style.overflow = 'hidden';
    var border = (mxClient.IS_QUIRKS) ? 8 + 2 * this.thumbPadding : 2 * this.thumbBorder;
    elt.style.width = (this.thumbWidth + border) + 'px';
    elt.style.height = (this.thumbHeight + border) + 'px';
    elt.style.padding = this.thumbPadding + 'px';
    var toolbar = elt;

    var show = elt;

    if (cell[0] != null) this.createThumb(cell, this.thumbWidth, this.thumbHeight, toolbar);
    else this.createThumb([cell], this.thumbWidth, this.thumbHeight, toolbar);
    return this.addToolbarItem(graph, toolbar, cell, this.createDragPreview(width, height), width, height, title);
}


Primitives.prototype.addToolbarItem = function (graph, toolbar, prototype, show, width, height, title, showLabel) {
    sb = this;
    var funct = function (graph, evt, cell, x, y) {

        var vertex = sb.getCellsLayout(prototype);
        graph.stopEditing(false);
        graph.getModel().beginUpdate();

        try {
            var pt = graph.getPointForEvent(evt);
            if (x != null && y != null) {
                if (vertex.vertex) {
                    vertex.geometry.x = Math.round(x);
                    vertex.geometry.y = Math.round(y);
                } else if (vertex.edge) {
                    vertex.geometry.setTerminalPoint(new mxPoint(x + 50, y), false);
                    vertex.geometry.setTerminalPoint(new mxPoint(x, y + 50), true);
                    if (vertex.geometry.points != null) {
                        vertex.geometry.points = [new mxPoint(x + 50, y + 50), new mxPoint(x, y)];
                    }
                } else {
                    vertex.geometry.x = Math.round(x);
                    vertex.geometry.y = Math.round(y);
                }
            } else {
                if (vertex.vertex) {
                    vertex.geometry.x = Math.round(pt.x);
                    vertex.geometry.y = Math.round(pt.y);
                } else if (vertex.edge) {
                    vertex.geometry.setTerminalPoint(new mxPoint(pt.x, pt.y), false);
                    vertex.geometry.setTerminalPoint(new mxPoint(pt.x - 50, pt.y + 50), true);
                }
            }
            //console.log(vertex);
            vertex = graph.importCells([vertex], 0, 0, cell);
            graph.setSelectionCells(vertex);

        } finally {
            graph.getModel().endUpdate();
        }
    };


    var ds = mxUtils.makeDraggable(toolbar, graph, funct, show, 0, 0, graph.autoScroll, true, true);

    mxEvent.addGestureListeners(toolbar, null, mxUtils.bind(this, function (evt) {

        if (mxEvent.isMouseEvent(evt)) {
            showVertex = sb.getCellsLayout(prototype);
            this.showTooltip(toolbar, [showVertex], width, height, title, showLabel);
        }
    }));


    mxEvent.addListener(toolbar, 'click', function (evt) {
        addClickHandler(toolbar, ds, evt, prototype);
    })

    mxEvent.addListener(toolbar, 'mousedown', function (evt) {
        HoverIcons.prototype.initAll();
    })

    return toolbar;
}

Primitives.prototype.getCellsLayout = function (cells) {
    layoutManagers = this.layoutManager;

    var showVertex = graph.getModel().cloneCell(cells[0] != null ? cells[0] : cells);
    var layout = layoutManagers.getLayout(showVertex);
    layoutManagers.executeLayout(layout, showVertex);

    return showVertex;
}

originalNoForeignObject = mxClient.NO_FO;
transparentImage = 'data:image/gif;base64,R0lGODlhMAAwAIAAAP///wAAACH5BAEAAAAALAAAAAAwADAAAAIxhI+py+0Po5y02ouz3rz7D4biSJbmiabqyrbuC8fyTNf2jef6zvf+DwwKh8Si8egpAAA7';

Primitives.prototype.createThumb = function (cells, width, height, parent, title, showLabel, showTitle, realWidth, realHeight) {
    this.graph.labelsVisible = (showLabel == null || showLabel);
    var fo = mxClient.NO_FO;
    mxClient.NO_FO = originalNoForeignObject;
    this.graph.view.setGraphBounds(new mxPoint(0, 0));
    this.graph.view.translate = new mxPoint(0, 0);
    this.graph.view.scaleAndTranslate(1, 0, 0);
    cells = this.getCellsLayout(cells);
    this.graph.addCells([cells]);
    var bounds = this.graph.getGraphBounds();
    var s = Math.floor(Math.min((width - 2 * this.thumbBorder) / bounds.width,
        (height - 2 * this.thumbBorder) / bounds.height) * 100) / 100;
    this.graph.view.scaleAndTranslate(s, Math.floor((width - bounds.width * s) / 2 / s - bounds.x),
        Math.floor((height - bounds.height * s) / 2 / s - bounds.y));
    var node = null;

    // For supporting HTML labels in IE9 standards mode the container is cloned instead
    if (this.graph.dialect == mxConstants.DIALECT_SVG && !mxClient.NO_FO &&
        this.graph.view.getCanvas().ownerSVGElement != null) {
        node = this.graph.view.getCanvas().ownerSVGElement.cloneNode(true);
    }
    // LATER: Check if deep clone can be used for quirks if container in DOM
    else {
        node = this.graph.container.cloneNode(false);
        node.innerHTML = this.graph.container.innerHTML;

        // Workaround for clipping in older IE versions
        if (mxClient.IS_QUIRKS || document.documentMode == 8) {
            node.firstChild.style.overflow = 'visible';
        }
    }

    this.graph.getModel().clear();
    mxClient.NO_FO = fo;

    // Catch-all event handling
    if (mxClient.IS_IE6) {
        parent.style.backgroundImage = 'url(' + transparentImage + ')';
    }

    node.style.position = 'relative';
    node.style.overflow = 'hidden';
    node.style.left = this.thumbBorder + 'px';
    node.style.top = this.thumbBorder + 'px';
    node.style.width = width + 'px';
    node.style.height = height + 'px';
    node.style.visibility = '';
    node.style.minWidth = '';
    node.style.minHeight = '';

    parent.appendChild(node);

    // Adds title for sidebar entries
    if (this.sidebarTitles && title != null && showTitle != false) {
        var border = (mxClient.IS_QUIRKS) ? 2 * this.thumbPadding + 2 : 0;
        parent.style.height = (this.thumbHeight + border + this.sidebarTitleSize + 8) + 'px';

        var div = document.createElement('div');
        div.style.fontSize = this.sidebarTitleSize + 'px';
        div.style.color = '#303030';
        div.style.textAlign = 'center';
        div.style.whiteSpace = 'nowrap';

        if (mxClient.IS_IE) {
            div.style.height = (this.sidebarTitleSize + 12) + 'px';
        }

        div.style.paddingTop = '4px';
        mxUtils.write(div, title);
        parent.appendChild(div);
    }
    graph.Search = false;
    return bounds;
};

Primitives.prototype.cloneCell = function (cell, value) {
    var clone = cell.clone();

    if (value != null) {
        clone.value = value;
    }

    return clone;
};


Primitives.prototype.addPaletteFunctions = function (id, title, bool, fns) {
    this.addPalette(id, title, bool, mxUtils.bind(this, function (content) {
        for (var i = 0; i < fns.length; i++) {
            content.appendChild(fns[i](content));
        }
    }));
};

Primitives.prototype.addPalette = function (id, title, bool, onInit) {
    if (title == null || title == undefined) {
        var a = 1;
    }
    var elt = document.createElement('div');
    elt.className = 'title1 title-' + title;

    var div = document.createElement('div');
    div.className = 'geSidebar ' + title;

    var outer = document.createElement('div');
    outer.appendChild(elt);
    outer.appendChild(div);
    this.container.appendChild(outer);

    if (bool) {
        onInit(div);
    } else {
        div.style.display = 'none';
    }
    this.addFoldingHandler(title, elt, div, onInit);
    if (id != null) {
        this.palettes[id] = [elt, outer];
    }

    onInit = null;
    return div;
};


Primitives.prototype.addFoldingHandler = function (title, prent, doc, oninit) {
    var span = document.createElement('span');
    mxUtils.write(span, title);

    prent.appendChild(span);
}

Primitives.prototype.createDragPreview = function (width, height) {
    var elt = document.createElement('div');
    elt.style.border = this.dragPreviewBorder;
    elt.style.width = width + 'px';
    elt.style.height = height + 'px';

    return elt;
};


function addClickHandler(elt, ds, evt, cells) {
    graph.container.focus();

    var pt = getFreeInsertPoint();

    ds.drop(graph, evt, null, pt.x, pt.y, true);
}


function getFreeInsertPoint() {
    var view = graph.view;
    var bds = graph.getGraphBounds();
    var pt = getInsertPoint();

    var x = graph.snap(Math.round(Math.max(pt.x, bds.x / view.scale - view.translate.x +
        ((bds.width == 0) ? 2 * graph.gridSize : 0))));
    var y = graph.snap(Math.round(Math.max(pt.y, (bds.y + bds.height) / view.scale - view.translate.y +
        2 * graph.gridSize)));

    return new mxPoint(x, y);
}

function getInsertPoint() {
    var gs = graph.gridSize;
    var dx = graph.container.scrollLeft / graph.view.scale - graph.view.translate.x;
    var dy = graph.container.scrollTop / graph.view.scale - graph.view.translate.y;

    var layout = getPageLayout();
    var page = new mxRectangle(0, 0, graph.pageFormat.width * graph.pageScale,
        graph.pageFormat.height * graph.pageScale)
    dx = Math.max(dx, layout.x * page.width);
    dy = Math.max(dy, layout.y * page.height);


    return new mxPoint(graph.snap(dx + gs), graph.snap(dy + gs));
}

Primitives.prototype.showTooltip = function (elt, cells, w, h, title, showLabel) {
    if (this.showTooltips) {
        if (this.currentElt != elt) {
            if (this.thread != null) {
                window.clearTimeout(this.thread);
                this.thread = null;
            }

            var show = mxUtils.bind(this, function () {
                if (this.tooltip == null) {
                    this.tooltip = document.createElement('div');
                    this.tooltip.className = 'geSidebarTooltip';
                    this.tooltip.style.zIndex = 2 * mxPopupMenu.prototype.zIndex;
                    document.body.appendChild(this.tooltip);

                    this.graph2 = new mxGraph(this.tooltip, null, null, graph.getStylesheet());
                    this.graph2.resetViewOnRootChange = false;
                    this.graph2.foldingEnabled = false;
                    this.graph2.setHtmlLabels(true);
                    this.graph2.isHtmlLabels(true);
                    this.graph2.gridEnabled = false;
                    this.graph2.autoScroll = false;
                    this.graph2.setTooltips(false);
                    this.graph2.setConnectable(false);
                    this.graph2.setEnabled(false);

                    if (!mxClient.IS_SVG) {
                        this.graph2.view.canvas.style.position = 'relative';
                    }
                }

                this.graph2.model.clear();
                this.graph2.view.setTranslate(this.tooltipBorder, this.tooltipBorder);

                if (w > this.maxTooltipWidth || h > this.maxTooltipHeight) {
                    this.graph2.view.scale = Math.round(Math.min(this.maxTooltipWidth / w, this.maxTooltipHeight / h) * 100) / 100;
                } else {
                    this.graph2.view.scale = 1;
                }

                this.tooltip.style.display = 'block';
                this.graph2.labelsVisible = (showLabel == null || showLabel);
                var fo = mxClient.NO_FO;
                mxClient.NO_FO = this.originalNoForeignObject;
                this.graph2.addCells(cells);
                mxClient.NO_FO = fo;

                var bounds = this.graph2.getGraphBounds();
                var width = bounds.width + 2 * this.tooltipBorder + 4;
                var height = bounds.height + 2 * this.tooltipBorder;

                if (mxClient.IS_QUIRKS) {
                    height += 4;
                    this.tooltip.style.overflow = 'hidden';
                } else {
                    this.tooltip.style.overflow = 'visible';
                }

                this.tooltip.style.width = width + 'px';
                var w2 = width;

                if (this.showTooltips && title != null && title.length > 0) {
                    if (this.tooltipTitle == null) {
                        this.tooltipTitle = document.createElement('div');
                        this.tooltipTitle.style.borderTop = '1px solid gray';
                        this.tooltipTitle.style.textAlign = 'center';
                        this.tooltipTitle.style.width = '100%';
                        this.tooltipTitle.style.overflow = 'hidden';
                        this.tooltipTitle.style.position = 'absolute';
                        this.tooltipTitle.style.paddingTop = '6px';
                        this.tooltipTitle.style.bottom = '6px';

                        this.tooltip.appendChild(this.tooltipTitle);
                    } else {
                        this.tooltipTitle.innerHTML = '';
                    }

                    this.tooltipTitle.style.display = '';
                    mxUtils.write(this.tooltipTitle, title);

                    w2 = Math.min(this.maxTooltipWidth, Math.max(width, this.tooltipTitle.scrollWidth + 4));
                    var ddy = this.tooltipTitle.offsetHeight + 10;
                    height += ddy;

                    if (mxClient.IS_SVG) {
                        this.tooltipTitle.style.marginTop = (2 - ddy) + 'px';
                    } else {
                        height -= 6;
                        this.tooltipTitle.style.top = (height - ddy) + 'px';
                    }
                } else if (this.tooltipTitle != null && this.tooltipTitle.parentNode != null) {
                    this.tooltipTitle.style.display = 'none';
                }


                if (w2 > width) {
                    this.tooltip.style.width = w2 + 'px';
                }

                this.tooltip.style.height = height + 'px';
                var x0 = -Math.round(bounds.x - this.tooltipBorder) + (w2 - width) / 2;
                var y0 = -Math.round(bounds.y - this.tooltipBorder);

                var b = document.body;
                var d = document.documentElement;
                var off = new mxPoint(0, 0);
                var bottom = Math.max(b.clientHeight || 0, d.clientHeight);
                var left = graph.container.offsetLeft + off.x;
                var top = Math.min(bottom - height - 20, Math.max(0, (elt.offsetParent.offsetTop + elt.offsetTop - this.container.scrollTop - elt.offsetParent.scrollTop - height / 2 + 16))) + off.y;

                if (mxClient.IS_SVG) {
                    if (x0 != 0 || y0 != 0) {
                        this.graph2.view.canvas.setAttribute('transform', 'translate(' + x0 + ',' + y0 + ')');
                    } else {
                        this.graph2.view.canvas.removeAttribute('transform');
                    }
                } else {
                    this.graph2.view.drawPane.style.left = x0 + 'px';
                    this.graph2.view.drawPane.style.top = y0 + 'px';
                }
                this.tooltip.style.position = 'absolute';
                this.tooltip.style.left = left + 'px';
                this.tooltip.style.top = top + 'px';
            });

            if (this.tooltip != null && this.tooltip.style.display != 'none') {
                show();
            } else {
                this.thread = window.setTimeout(show, this.tooltipDelay);
            }

            this.currentElt = elt;
        }
    }
};


Primitives.prototype.hideTooltip = function () {
    if (this.thread != null) {
        window.clearTimeout(this.thread);
        this.thread = null;
    }

    if (this.tooltip != null) {
        this.tooltip.style.display = 'none';
        this.currentElt = null;
    }
};


Primitives.prototype.createTemporaryGraph = function (stylesheet) {
    var graph = new mxGraph(document.createElement('div'), null, null, stylesheet);
    graph.resetViewOnRootChange = false;
    graph.setConnectable(false);
    graph.gridEnabled = false;
    graph.autoScroll = false;
    graph.setTooltips(false);
    graph.setEnabled(false);
    graph.setHtmlLabels(true);
    graph.isHtmlLabels(true);

    // Container must be in the DOM for correct HTML rendering
    graph.container.style.visibility = 'hidden';
    graph.container.style.position = 'absolute';
    graph.container.style.overflow = 'hidden';
    graph.container.style.height = '1px';
    graph.container.style.width = '1px';

    return graph;
};

Primitives.prototype.initPalettes = function () {
    this.addGeneralPalette(true);
    this.addFlowchartPalette(true);
    this.addUmlPalette(true);
    this.addUserInterfacePalette(true);
    this.addBasicPalette(true);
    this.addArrowsPalette(true);
    //this.addDemoPalette(true);
};