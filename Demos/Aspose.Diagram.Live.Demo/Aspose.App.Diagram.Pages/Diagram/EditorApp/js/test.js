function Primitives(graph) {
    this.graph = this.createTemporaryGraph(graph.getStylesheet());
    this.taglist = new Object();
    this.palettes = new Object();
    this.container = document.getElementsByClassName("content-left")[0];
    this.configuration = this.configuration();
    this.init();
    this.initPalettes();
}

/**
 * Specifies the padding for the thumbnails. Default is 3.
 */
Primitives.prototype.thumbPadding = (document.documentMode >= 5) ? 2 : 3;

Primitives.prototype.libAliases = { 'aws2': 'aws3', 'gcp': 'gcp2' };
/**
 * Specifies the delay for the tooltip. Default is 2 px.
 */
Primitives.prototype.thumbBorder = 2;

Primitives.prototype.thumbPadding = (document.documentMode >= 5) ? 0 : 1;
Primitives.prototype.thumbBorder = 1;
Primitives.prototype.thumbWidth = 32;
Primitives.prototype.thumbHeight = 30;
Primitives.prototype.minThumbStrokeWidth = 1.3;
Primitives.prototype.thumbAntiAlias = true;
Primitives.prototype.dragPreviewBorder = '1px dashed black';
Primitives.prototype.gearImage = '../stencils/clipart/Gear_128x128.png';
Primitives.prototype.defaultImageWidth = 80;
Primitives.prototype.defaultImageHeight = 80;
Primitives.prototype.defaultEntries = 'general;uml;bpmn;flowchart;basic;arrows';
Primitives.prototype.originalNoForeignObject = mxClient.NO_FO;


Primitives.prototype.tooltipBorder = 16;

Primitives.prototype.tooltipDelay = 300;

Primitives.prototype.splitSize = (mxClient.IS_TOUCH || mxClient.IS_POINTER) ? 12 : 8;

Primitives.prototype.dropTargetDelay = 200;

Primitives.prototype.showTooltips = true;

Primitives.prototype.maxTooltipWidth = 400;

Primitives.prototype.maxTooltipHeight = 400;

Primitives.prototype.showPalette = function() {
    var entries = this.entries();
}

Primitives.prototype.init = function() {
    this.layoutManager = new mxLayoutManager(graph);
    this.layoutManager.getLayout = function(cell) {
        // Workaround for possible invalid style after change and before view validation
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

    var Search = document.getElementsByClassName("Search")[0];
    var sb = this;
    mxEvent.addListener(Search, 'keypress', function(e) {
        if (e.keyCode == 13) {
            var text = Search.value;
            var doc = document.getElementsByClassName("center")[0];
            sb.Find(doc, text);
        }
    });

    this.pointerUpHandler = mxUtils.bind(this, function() {
        this.showTooltips = true;
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerup' : 'mouseup', this.pointerUpHandler);

    this.pointerDownHandler = mxUtils.bind(this, function() {
        this.showTooltips = false;
        this.hideTooltip();
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerdown' : 'mousedown', this.pointerDownHandler);

    this.pointerMoveHandler = mxUtils.bind(this, function(evt) {
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

    this.pointerOutHandler = mxUtils.bind(this, function(evt) {
        if (evt.toElement == null && evt.relatedTarget == null) {
            this.hideTooltip();
        }
    });

    mxEvent.addListener(document, (mxClient.IS_POINTER) ? 'pointerout' : 'mouseout', this.pointerOutHandler);

    mxEvent.addListener(this.container, 'scroll', mxUtils.bind(this, function() {
        this.showTooltips = true;
        this.hideTooltip();
    }));
}

Primitives.prototype.addGeneralPalette = function(expand, display, doc) {

    var lineTags = 'line lines connector connectors connection connections arrow arrows ';

    var fns = [
        this.createVertexTemplateEntry('rounded=0;whiteSpace=wrap;html=1;', 120, 60, '', 'Rectangle', null, null, 'rect rectangle box'),
        this.createVertexTemplateEntry('rounded=1;whiteSpace=wrap;html=1;', 120, 60, '', 'Rounded Rectangle', null, null, 'rounded rect rectangle box'),
        // Explicit strokecolor/fillcolor=none is a workaround to maintain transparent background regardless of current style
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

        this.addEntry('curve', mxUtils.bind(this, function() {
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

    this.addPaletteFunctions('general', mxResources.get('general'), (expand != null) ? expand : true, fns);
}

Primitives.prototype.addMiscPalette = function(expand) {

    var lineTags = 'line lines connector connectors connection connections arrow arrows '

    var fns = [
        this.createVertexTemplateEntry('text;strokeColor=none;fillColor=none;html=1;fontSize=24;fontStyle=1;verticalAlign=middle;align=center;', 100, 40, 'Title', 'Title', null, null, 'text heading title'),
        this.createVertexTemplateEntry('text;strokeColor=none;fillColor=none;html=1;whiteSpace=wrap;verticalAlign=middle;overflow=hidden;', 100, 80,
            '<ul><li>Value 1</li><li>Value 2</li><li>Value 3</li></ul>', 'Unordered List'),
        this.createVertexTemplateEntry('text;strokeColor=none;fillColor=none;html=1;whiteSpace=wrap;verticalAlign=middle;overflow=hidden;', 100, 80,
            '<ol><li>Value 1</li><li>Value 2</li><li>Value 3</li></ol>', 'Ordered List'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=#c0c0c0;fillColor=#ffffff;overflow=fill;rounded=0;', 280, 160,
            '<table border="1" width="100%" height="100%" cellpadding="4" style="width:100%;height:100%;border-collapse:collapse;">' +
            '<tr style="background-color:#A7C942;color:#ffffff;border:1px solid #98bf21;"><th align="left">Title 1</th><th align="left">Title 2</th><th align="left">Title 3</th></tr>' +
            '<tr style="border:1px solid #98bf21;"><td>Value 1</td><td>Value 2</td><td>Value 3</td></tr>' +
            '<tr style="background-color:#EAF2D3;border:1px solid #98bf21;"><td>Value 4</td><td>Value 5</td><td>Value 6</td></tr>' +
            '<tr style="border:1px solid #98bf21;"><td>Value 7</td><td>Value 8</td><td>Value 9</td></tr>' +
            '<tr style="background-color:#EAF2D3;border:1px solid #98bf21;"><td>Value 10</td><td>Value 11</td><td>Value 12</td></tr></table>', 'Table 1'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=#c0c0c0;fillColor=none;overflow=fill;', 180, 140,
            '<table border="0" width="100%" height="100%" style="width:100%;height:100%;border-collapse:collapse;">' +
            '<tr><td align="center">Value 1</td><td align="center">Value 2</td><td align="center">Value 3</td></tr>' +
            '<tr><td align="center">Value 4</td><td align="center">Value 5</td><td align="center">Value 6</td></tr>' +
            '<tr><td align="center">Value 7</td><td align="center">Value 8</td><td align="center">Value 9</td></tr></table>', 'Table 2'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=none;fillColor=none;overflow=fill;', 180, 140,
            '<table border="1" width="100%" height="100%" style="width:100%;height:100%;border-collapse:collapse;">' +
            '<tr><td align="center">Value 1</td><td align="center">Value 2</td><td align="center">Value 3</td></tr>' +
            '<tr><td align="center">Value 4</td><td align="center">Value 5</td><td align="center">Value 6</td></tr>' +
            '<tr><td align="center">Value 7</td><td align="center">Value 8</td><td align="center">Value 9</td></tr></table>', 'Table 3'),
        this.createVertexTemplateEntry('text;html=1;strokeColor=none;fillColor=none;overflow=fill;', 160, 140,
            '<table border="1" width="100%" height="100%" cellpadding="4" style="width:100%;height:100%;border-collapse:collapse;">' +
            '<tr><th align="center"><b>Title</b></th></tr>' +
            '<tr><td align="center">Section 1.1\nSection 1.2\nSection 1.3</td></tr>' +
            '<tr><td align="center">Section 2.1\nSection 2.2\nSection 2.3</td></tr></table>', 'Table 4'),
        this.addEntry('link hyperlink', mxUtils.bind(this, function() {
            var cell = new mxCell('Link', new mxGeometry(0, 0, 60, 40), 'text;html=1;strokeColor=none;fillColor=none;whiteSpace=wrap;align=center;verticalAlign=middle;fontColor=#0000EE;fontStyle=4;');
            cell.vertex = true;
            this.setLinkForCell(cell, 'https://www.draw.io');

            return this.createItem(cell, 'Link', "", cell.geometry.width, cell.geometry.height);
        })),
        this.addEntry('timestamp date time text label', mxUtils.bind(this, function() {
            var cell = new mxCell('%date{ddd mmm dd yyyy HH:MM:ss}%', new mxGeometry(0, 0, 160, 20), 'text;html=1;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;whiteSpace=wrap;overflow=hidden;');
            cell.vertex = true;
            this.setAttributeForCell(cell, 'placeholders', '1');

            return this.createItem(cell, 'Timestamp', "", cell.geometry.width, cell.geometry.height);
        })),
        this.addEntry('variable placeholder metadata hello world text label', mxUtils.bind(this, function() {
            var cell = new mxCell('%name% Text', new mxGeometry(0, 0, 80, 20), 'text;html=1;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;whiteSpace=wrap;overflow=hidden;');
            cell.vertex = true;
            this.setAttributeForCell(cell, 'placeholders', '1');
            this.setAttributeForCell(cell, 'name', 'Variable');

            return this.createItem(cell, 'Variable', "", cell.geometry.width, cell.geometry.height);
        })),
        this.createVertexTemplateEntry('shape=ext;double=1;rounded=0;whiteSpace=wrap;html=1;', 120, 80, '', 'Double Rectangle', null, null, 'rect rectangle box double'),
        this.createVertexTemplateEntry('shape=ext;double=1;rounded=1;whiteSpace=wrap;html=1;', 120, 80, '', 'Double Rounded Rectangle', null, null, 'rounded rect rectangle box double'),
        this.createVertexTemplateEntry('ellipse;shape=doubleEllipse;whiteSpace=wrap;html=1;', 100, 60, '', 'Double Ellipse', null, null, 'oval ellipse start end state double'),
        this.createVertexTemplateEntry('shape=ext;double=1;whiteSpace=wrap;html=1;aspect=fixed;', 80, 80, '', 'Double Square', null, null, 'double square'),
        this.createVertexTemplateEntry('ellipse;shape=doubleEllipse;whiteSpace=wrap;html=1;aspect=fixed;', 80, 80, '', 'Double Circle', null, null, 'double circle'),
        this.createEdgeTemplateEntry('rounded=0;comic=1;strokeWidth=2;endArrow=blockThin;html=1;fontFamily=Comic Sans MS;fontStyle=1;', 50, 50, '', 'Comic Arrow'),
        this.createVertexTemplateEntry('html=1;whiteSpace=wrap;comic=1;strokeWidth=2;fontFamily=Comic Sans MS;fontStyle=1;', 120, 60, 'RECTANGLE', 'Comic Rectangle', true, null, 'comic rectangle rect box text retro'),
        this.createVertexTemplateEntry('rhombus;html=1;align=center;whiteSpace=wrap;comic=1;strokeWidth=2;fontFamily=Comic Sans MS;fontStyle=1;', 100, 100, 'DIAMOND', 'Comic Diamond', true, null, 'comic diamond rhombus if condition decision conditional question test retro'),
        this.createVertexTemplateEntry('html=1;whiteSpace=wrap;aspect=fixed;shape=isoRectangle;', 150, 90, '', 'Isometric Square', true, null, 'rectangle rect box iso isometric'),
        this.createVertexTemplateEntry('html=1;whiteSpace=wrap;aspect=fixed;shape=isoCube;backgroundOutline=1;', 90, 100, '', 'Isometric Cube', true, null, 'cube box iso isometric'),
        this.createEdgeTemplateEntry('edgeStyle=isometricEdgeStyle;endArrow=none;html=1;', 50, 100, '', 'Isometric Edge 1'),
        this.createEdgeTemplateEntry('edgeStyle=isometricEdgeStyle;endArrow=none;html=1;elbow=vertical;', 50, 100, '', 'Isometric Edge 2'),
        this.createVertexTemplateEntry('shape=curlyBracket;whiteSpace=wrap;html=1;rounded=1;', 20, 120, '', 'Curly Bracket'),
        this.createVertexTemplateEntry('line;strokeWidth=2;html=1;', 160, 10, '', 'Horizontal Line'),
        this.createVertexTemplateEntry('line;strokeWidth=2;direction=south;html=1;', 10, 160, '', 'Vertical Line'),
        this.createVertexTemplateEntry('line;strokeWidth=4;html=1;perimeter=backbonePerimeter;points=[];outlineConnect=0;', 160, 10, '', 'Horizontal Backbone', false, null, 'backbone bus network'),
        this.createVertexTemplateEntry('line;strokeWidth=4;direction=south;html=1;perimeter=backbonePerimeter;points=[];outlineConnect=0;', 10, 160, '', 'Vertical Backbone', false, null, 'backbone bus network'),
        this.createVertexTemplateEntry('shape=crossbar;whiteSpace=wrap;html=1;rounded=1;', 120, 20, '', 'Crossbar', false, null, 'crossbar distance measure dimension unit'),
        this.createVertexTemplateEntry('shape=image;html=1;verticalLabelPosition=bottom;labelBackgroundColor=#ffffff;verticalAlign=top;imageAspect=1;aspect=fixed;image=' + this.gearImage, 52, 61, '', 'Image (Fixed Aspect)', false, null, 'fixed image icon symbol'),
        this.createVertexTemplateEntry('shape=image;html=1;verticalLabelPosition=bottom;labelBackgroundColor=#ffffff;verticalAlign=top;imageAspect=0;image=' + this.gearImage, 50, 60, '', 'Image (Variable Aspect)', false, null, 'strechted image icon symbol'),
        this.createVertexTemplateEntry('icon;html=1;image=' + this.gearImage, 60, 60, 'Icon', 'Icon', false, null, 'icon image symbol'),
        this.createVertexTemplateEntry('label;whiteSpace=wrap;html=1;image=' + this.gearImage, 140, 60, 'Label', 'Label 1', null, null, 'label image icon symbol'),
        this.createVertexTemplateEntry('label;whiteSpace=wrap;html=1;align=center;verticalAlign=bottom;spacingLeft=0;spacingBottom=4;imageAlign=center;imageVerticalAlign=top;image=' + this.gearImage, 120, 80, 'Label', 'Label 2', null, null, 'label image icon symbol'),
        this.addEntry('shape group container', mxUtils.bind(this, function() {
            var cell = new mxCell('Label', new mxGeometry(0, 0, 160, 70),
                'html=1;whiteSpace=wrap;container=1;recursiveResize=0;collapsible=0;');
            cell.vertex = true;

            var symbol = new mxCell('', new mxGeometry(20, 20, 20, 30), 'triangle;html=1;whiteSpace=wrap;');
            symbol.vertex = true;
            cell.insert(symbol);

            return this.createItem(cell, 'Shape Group', "", cell.geometry.width, cell.geometry.height);
        })),
        this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;left=0;right=0;fillColor=none;', 120, 60, '', 'Partial Rectangle'),
        this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;bottom=1;right=1;left=1;top=0;fillColor=none;routingCenterX=-0.5;', 120, 60, '', 'Partial Rectangle'),
        this.createEdgeTemplateEntry('edgeStyle=segmentEdgeStyle;endArrow=classic;html=1;', 50, 50, '', 'Manual Line', null, lineTags + 'manual'),
        this.createEdgeTemplateEntry('shape=filledEdge;rounded=0;fixDash=1;endArrow=none;strokeWidth=10;fillColor=#ffffff;edgeStyle=orthogonalEdgeStyle;', 60, 40, '', 'Filled Edge'),
        this.createEdgeTemplateEntry('edgeStyle=elbowEdgeStyle;elbow=horizontal;endArrow=classic;html=1;', 50, 50, '', 'Horizontal Elbow', null, lineTags + 'elbow horizontal'),
        this.createEdgeTemplateEntry('edgeStyle=elbowEdgeStyle;elbow=vertical;endArrow=classic;html=1;', 50, 50, '', 'Vertical Elbow', null, lineTags + 'elbow vertical')
    ];

    this.addPaletteFunctions('misc', mxResources.get('misc'), (expand != null) ? expand : true, fns);
}

Primitives.prototype.addAdvancedPalette = function(expand) {

    var field = new mxCell('List Item', new mxGeometry(0, 0, 60, 26), 'text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;');
    field.vertex = true;

    var fns = [
        this.createVertexTemplateEntry('shape=tapeData;whiteSpace=wrap;html=1;perimeter=ellipsePerimeter;', 80, 80, '', 'Tape Data'),
        this.createVertexTemplateEntry('shape=manualInput;whiteSpace=wrap;html=1;', 80, 80, '', 'Manual Input'),
        this.createVertexTemplateEntry('shape=loopLimit;whiteSpace=wrap;html=1;', 100, 80, '', 'Loop Limit'),
        this.createVertexTemplateEntry('shape=offPageConnector;whiteSpace=wrap;html=1;', 80, 80, '', 'Off Page Connector'),
        this.createVertexTemplateEntry('shape=delay;whiteSpace=wrap;html=1;', 80, 40, '', 'Delay'),
        this.createVertexTemplateEntry('shape=display;whiteSpace=wrap;html=1;', 80, 40, '', 'Display'),
        this.createVertexTemplateEntry('shape=singleArrow;direction=west;whiteSpace=wrap;html=1;', 100, 60, '', 'Arrow Left'),
        this.createVertexTemplateEntry('shape=singleArrow;whiteSpace=wrap;html=1;', 100, 60, '', 'Arrow Right'),
        this.createVertexTemplateEntry('shape=singleArrow;direction=north;whiteSpace=wrap;html=1;', 60, 100, '', 'Arrow Up'),
        this.createVertexTemplateEntry('shape=singleArrow;direction=south;whiteSpace=wrap;html=1;', 60, 100, '', 'Arrow Down'),
        this.createVertexTemplateEntry('shape=doubleArrow;whiteSpace=wrap;html=1;', 100, 60, '', 'Double Arrow'),
        this.createVertexTemplateEntry('shape=doubleArrow;direction=south;whiteSpace=wrap;html=1;', 60, 100, '', 'Double Arrow Vertical', null, null, 'double arrow'),
        this.createVertexTemplateEntry('shape=actor;whiteSpace=wrap;html=1;', 40, 60, '', 'User', null, null, 'user person human'),
        this.createVertexTemplateEntry('shape=cross;whiteSpace=wrap;html=1;', 80, 80, '', 'Cross'),
        this.createVertexTemplateEntry('shape=corner;whiteSpace=wrap;html=1;', 80, 80, '', 'Corner'),
        this.createVertexTemplateEntry('shape=tee;whiteSpace=wrap;html=1;', 80, 80, '', 'Tee'),
        this.createVertexTemplateEntry('shape=datastore;whiteSpace=wrap;html=1;', 60, 60, '', 'Data Store', null, null, 'data store cylinder database'),
        this.createVertexTemplateEntry('shape=orEllipse;perimeter=ellipsePerimeter;whiteSpace=wrap;html=1;backgroundOutline=1;', 80, 80, '', 'Or', null, null, 'or circle oval ellipse'),
        this.createVertexTemplateEntry('shape=sumEllipse;perimeter=ellipsePerimeter;whiteSpace=wrap;html=1;backgroundOutline=1;', 80, 80, '', 'Sum', null, null, 'sum circle oval ellipse'),
        this.createVertexTemplateEntry('shape=lineEllipse;perimeter=ellipsePerimeter;whiteSpace=wrap;html=1;backgroundOutline=1;', 80, 80, '', 'Ellipse with horizontal divider', null, null, 'circle oval ellipse'),
        this.createVertexTemplateEntry('shape=lineEllipse;line=vertical;perimeter=ellipsePerimeter;whiteSpace=wrap;html=1;backgroundOutline=1;', 80, 80, '', 'Ellipse with vertical divider', null, null, 'circle oval ellipse'),
        this.createVertexTemplateEntry('shape=sortShape;perimeter=rhombusPerimeter;whiteSpace=wrap;html=1;', 80, 80, '', 'Sort', null, null, 'sort'),
        this.createVertexTemplateEntry('shape=collate;whiteSpace=wrap;html=1;', 80, 80, '', 'Collate', null, null, 'collate'),
        this.createVertexTemplateEntry('shape=switch;whiteSpace=wrap;html=1;', 60, 60, '', 'Switch', null, null, 'switch router'),
        this.addEntry('process bar', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('zZXRaoMwFIafJpcDjbNrb2233rRQ8AkyPdPQaCRJV+3T7yTG2rUVBoOtgpDzn/xJzncCIdGyateKNeVW5iBI9EqipZLS9KOqXYIQhAY8J9GKUBrgT+jbRDZ02aBhCmrzEwPtDZ9MHKBXdkpmoDWKCVN9VptO+Kw+8kqwGqMkK7nIN6yTB7uTNizbD1FSSsVPsjYMC1qFKHxwIZZSSIVxLZ1/nJNar5+oQPMT7IYCrqUta1ENzuqGaeOFTArBGs3f3Vmtoo2Se7ja1h00kSoHK4bBIKUNy3hdoPYU0mF91i9mT8EEL2ocZ3gKa00ayWujLZY4IfHKFonVDLsRGgXuQ90zBmWgneyTk3yT1iArMKrDKUeem9L3ajHrbSXwohxsQd/ggOleKM7ese048J2/fwuim1uQGmhQCW8vQMkacP3GCQgBFMftHEsr7cYYe95CnmKTPMFbYD8CQ++DGQy+/M5X4ku5wHYmdIktfvk9tecpavThqS3m/0YtnqIWPTy1cD77K2wYjo+Ay317I74A', 296, 100, 'Process Bar');
        })),
        this.createVertexTemplateEntry('swimlane;', 200, 200, 'Container', 'Container', null, null, 'container swimlane lane pool group'),
        this.addEntry('list group erd table', mxUtils.bind(this, function() {
            var cell = new mxCell('List', new mxGeometry(0, 0, 140, 110),
                'swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;' +
                'resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;');
            cell.vertex = true;
            cell.insert(this.cloneCell(field, 'Item 1'));
            cell.insert(this.cloneCell(field, 'Item 2'));
            cell.insert(this.cloneCell(field, 'Item 3'));

            return this.createItem(cell, 'List', "", cell.geometry.width, cell.geometry.height);
        })),
        this.addEntry('list item entry value group erd table', mxUtils.bind(this, function() {
            return this.createItem(this.cloneCell(field, 'List Item'), 'List Item', "", field.geometry.width, field.geometry.height);
        }))
    ];

    this.addPaletteFunctions('advanced', mxResources.get('advanced'), (expand != null) ? expand : false, fns);
}


Primitives.prototype.addImagePalette = function(id, title, prefix, postfix, items, titles, tags) {
    var fns = [];

    for (var i = 0; i < items.length; i++) {
        (mxUtils.bind(this, function(item, title, tmpTags) {

            fns.push(this.createVertexTemplateEntry('image;html=1;labelBackgroundColor=#ffffff;image=' + prefix + item + postfix,
                this.defaultImageWidth, this.defaultImageHeight, '', title, title != null, null));
        }))(items[i], (titles != null) ? titles[i] : null, (tags != null) ? tags[items[i]] : null);
    }

    this.addPaletteFunctions(id, title, false, fns);
};

// Primitives.prototype.addBasicPalette = function (expand, display, doc) {
//     var fns = this.addStencilPalette('basic', mxResources.get('basic'), '../stencils/basic.xml',
//         ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2',
//         null, null, null, null, [
//         this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;top=0;bottom=0;fillColor=none;', 120, 60, '', 'Partial Rectangle'),
//         this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;right=0;top=0;bottom=0;fillColor=none;routingCenterX=-0.5;', 120, 60, '', 'Partial Rectangle'),
//         this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;bottom=0;right=0;fillColor=none;', 120, 60, '', 'Partial Rectangle'),
//         this.createVertexTemplateEntry('shape=partialRectangle;whiteSpace=wrap;html=1;top=0;left=0;fillColor=none;', 120, 60, '', 'Partial Rectangle')
//     ]);

//     this.addPaletteFunctions(doc, mxResources.get(doc), expand, fns);
//     this.getDisplay(display, doc);
// }

Primitives.prototype.addArrowsPalette = function(expand) {
    var fns = this.addStencilPalette('arrows', mxResources.get('arrows'), '../stencils/arrows.xml',
        ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

    this.addPaletteFunctions('arrows', mxResources.get('arrows'), expand, fns);
}

Primitives.prototype.addUmlPalette = function(expand, display, doc) {
    // Reusable cells
    var field = new mxCell('+ field: type', new mxGeometry(0, 0, 100, 26), 'text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;');
    field.vertex = true;

    var divider = new mxCell('', new mxGeometry(0, 0, 40, 8), 'line;strokeWidth=1;fillColor=none;align=left;verticalAlign=middle;spacingTop=-1;spacingLeft=3;spacingRight=3;rotatable=0;labelPosition=right;points=[];portConstraint=eastwest;');
    divider.vertex = true;

    // Default tags
    var dt = 'uml static class ';

    var fns = [
        this.createVertexTemplateEntry('html=1;', 110, 50, 'Object', 'Object', null, null, dt + 'object instance'),
        this.createVertexTemplateEntry('html=1;', 110, 50, '&laquo;interface&raquo;<br><b>Name</b>', 'Interface', null, null, dt + 'interface object instance annotated annotation'),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function() {
            var cell = new mxCell('Classname', new mxGeometry(0, 0, 160, 90),
                'swimlane;fontStyle=1;align=center;verticalAlign=top;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;');
            cell.vertex = true;
            cell.insert(field.clone());
            cell.insert(divider.clone());
            cell.insert(this.cloneCell(field, '+ method(type): type'));

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Class');
        })),
        this.addEntry(dt + 'section subsection', mxUtils.bind(this, function() {
            var cell = new mxCell('Classname', new mxGeometry(0, 0, 140, 110),
                'swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;');
            cell.vertex = true;
            cell.insert(field.clone());
            cell.insert(field.clone());
            cell.insert(field.clone());

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Class 2');
        })),
        this.addEntry(dt + 'item member method function variable field attribute label', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromCells([this.cloneCell(field, '+ item: attribute')], field.geometry.width, field.geometry.height, 'Item 1');
        })),
        this.addEntry(dt + 'item member method function variable field attribute label', mxUtils.bind(this, function() {
            var cell = new mxCell('item: attribute', new mxGeometry(0, 0, 120, field.geometry.height), 'label;fontStyle=0;strokeColor=none;fillColor=none;align=left;verticalAlign=top;overflow=hidden;' +
                'spacingLeft=28;spacingRight=4;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;imageWidth=16;imageHeight=16;image=' + this.gearImage);
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Item 2');
        })),
        this.addEntry(dt + 'divider hline line separator', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromCells([divider.clone()], divider.geometry.width, divider.geometry.height, 'Divider');
        })),
        this.addEntry(dt + 'spacer space gap separator', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 20, 14), 'text;strokeColor=none;fillColor=none;align=left;verticalAlign=middle;spacingTop=-1;spacingLeft=4;spacingRight=4;rotatable=0;labelPosition=right;points=[];portConstraint=eastwest;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Spacer');
        })),
        this.createVertexTemplateEntry('text;align=center;fontStyle=1;verticalAlign=middle;spacingLeft=3;spacingRight=3;strokeColor=none;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;',
            80, 26, 'Title', 'Title', null, null, dt + 'title label'),
        this.addEntry(dt + 'component', mxUtils.bind(this, function() {
            var cell = new mxCell('&laquo;Annotation&raquo;<br/><b>Component</b>', new mxGeometry(0, 0, 180, 90), 'html=1;');
            cell.vertex = true;

            var symbol = new mxCell('', new mxGeometry(1, 0, 20, 20), 'shape=component;jettyWidth=8;jettyHeight=4;');
            symbol.vertex = true;
            symbol.geometry.relative = true;
            symbol.geometry.offset = new mxPoint(-27, 7);
            cell.insert(symbol);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Component');
        })),
        this.addEntry(dt + 'component', mxUtils.bind(this, function() {
            var cell = new mxCell('<p style="margin:0px;margin-top:6px;text-align:center;"><b>Component</b></p>' +
                '<hr/><p style="margin:0px;margin-left:8px;">+ Attribute1: Type<br/>+ Attribute2: Type</p>', new mxGeometry(0, 0, 180, 90),
                'align=left;overflow=fill;html=1;');
            cell.vertex = true;

            var symbol = new mxCell('', new mxGeometry(1, 0, 20, 20), 'shape=component;jettyWidth=8;jettyHeight=4;');
            symbol.vertex = true;
            symbol.geometry.relative = true;
            symbol.geometry.offset = new mxPoint(-24, 4);
            cell.insert(symbol);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Component with Attributes');
        })),
        this.createVertexTemplateEntry('verticalAlign=top;align=left;spacingTop=8;spacingLeft=2;spacingRight=12;shape=cube;size=10;direction=south;fontStyle=4;html=1;',
            180, 120, 'Block', 'Block', null, null, dt + 'block'),
        this.createVertexTemplateEntry('shape=component;align=left;spacingLeft=36;', 120, 60, 'Module', 'Module', null, null, dt + 'module'),
        this.createVertexTemplateEntry('shape=folder;fontStyle=1;spacingTop=10;tabWidth=40;tabHeight=14;tabPosition=left;html=1;', 70, 50,
            'package', 'Package', null, null, dt + 'package'),
        this.createVertexTemplateEntry('verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;',
            160, 90, '<p style="margin:0px;margin-top:4px;text-align:center;text-decoration:underline;"><b>Object:Type</b></p><hr/>' +
            '<p style="margin:0px;margin-left:8px;">field1 = value1<br/>field2 = value2<br>field3 = value3</p>', 'Object',
            null, null, dt + 'object instance'),
        this.createVertexTemplateEntry('verticalAlign=top;align=left;overflow=fill;html=1;', 180, 90,
            '<div style="box-sizing:border-box;width:100%;background:#e4e4e4;padding:2px;">Tablename</div>' +
            '<table style="width:100%;font-size:1em;" cellpadding="2" cellspacing="0">' +
            '<tr><td>PK</td><td>uniqueId</td></tr><tr><td>FK1</td><td>' +
            'foreignKey</td></tr><tr><td></td><td>fieldname</td></tr></table>', 'Entity', null, null, 'er entity table'),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function() {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><div style="height:2px;"></div>', new mxGeometry(0, 0, 140, 60),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 3');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function() {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><div style="height:2px;"></div><hr size="1"/><div style="height:2px;"></div>', new mxGeometry(0, 0, 140, 60),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 4');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function() {
            var cell = new mxCell('<p style="margin:0px;margin-top:4px;text-align:center;">' +
                '<b>Class</b></p>' +
                '<hr size="1"/><p style="margin:0px;margin-left:4px;">+ field: Type</p><hr size="1"/>' +
                '<p style="margin:0px;margin-left:4px;">+ method(): Type</p>', new mxGeometry(0, 0, 160, 90),
                'verticalAlign=top;align=left;overflow=fill;fontSize=12;fontFamily=Helvetica;html=1;');
            cell.vertex = true;

            return this.createVertexTemplateFromCells([cell.clone()], cell.geometry.width, cell.geometry.height, 'Class 5');
        })),
        this.addEntry(dt + 'object instance', mxUtils.bind(this, function() {
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
        this.createVertexTemplateEntry('shape=providedRequiredInterface;html=1;verticalLabelPosition=bottom;', 20, 20, '', 'Provided/Required Interface', null, null, 'uml provided required interface lollipop notation'),
        this.createVertexTemplateEntry('shape=requiredInterface;html=1;verticalLabelPosition=bottom;', 10, 20, '', 'Required Interface', null, null, 'uml required interface lollipop notation'),
        this.addEntry('uml lollipop notation provided required interface', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('zVTBrptADPyavVYEkt4b0uQd3pMq5dD2uAUD27dgZJwE8vX1spsQlETtpVWRIjFjex3PmFVJWvc70m31hjlYlXxWSUqI7N/qPgVrVRyZXCUbFceR/FS8fRJdjNGo1QQN/0lB7AuO2h7AM57oeLCBIDw0Obj8SCVrJK6wxEbbV8RWyIWQP4F52Juzq9AHRqEqrm2IQpN/IsKTwAYb8MzWWBuO9B0hL2E2BGsqIQyxvJ9rzApD7QBrYBokhcBqNsf5UbrzsLzmXUu/oJET42jwGat5QYcHyiDkTDLKy03TiRrFfSx08m+FrrQtUkOZvZdbFKThmwMfVhf4fQ43/W3uZriiPPT+KKhjwnf4anKuQv//wsg+NPJ7/9d9Xf7eVykwbeeMOFWGYd/qzEVO8tHP/Suw4a2ujXV/+gXsEdhkOgSC8os44BQt0tggicZHeG1N2QiXibhAV48epRayEDd8MT7Ct06TUaXVWq027tCuhcx5VZjebeeaoDNn/WMcb/p+j0AM/dNr6InLl4Lgzylsk6OCgRWYsuI592gNZh5OhgmcblPv7+1l+ws=',
                40, 10, 'Lollipop Notation');
        })),
        this.createVertexTemplateEntry('shape=umlBoundary;whiteSpace=wrap;html=1;', 100, 80, 'Boundary Object', 'Boundary Object', null, null, 'uml boundary object'),
        this.createVertexTemplateEntry('ellipse;shape=umlEntity;whiteSpace=wrap;html=1;', 80, 80, 'Entity Object', 'Entity Object', null, null, 'uml entity object'),
        this.createVertexTemplateEntry('ellipse;shape=umlControl;whiteSpace=wrap;html=1;', 70, 80, 'Control Object', 'Control Object', null, null, 'uml control object'),
        this.createVertexTemplateEntry('shape=umlActor;verticalLabelPosition=bottom;labelBackgroundColor=#ffffff;verticalAlign=top;html=1;', 30, 60, 'Actor', 'Actor', false, null, 'uml actor'),
        this.createVertexTemplateEntry('ellipse;whiteSpace=wrap;html=1;', 140, 70, 'Use Case', 'Use Case', null, null, 'uml use case usecase'),
        this.addEntry('uml activity state start', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 30, 30),
                'ellipse;html=1;shape=startState;fillColor=#000000;strokeColor=#ff0000;');
            cell.vertex = true;

            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;verticalAlign=bottom;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge.geometry.setTerminalPoint(new mxPoint(15, 90), false);
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, true);

            return this.createVertexTemplateFromCells([cell, edge], 30, 90, 'Start');
        })),
        this.addEntry('uml activity state', mxUtils.bind(this, function() {
            var cell = new mxCell('Activity', new mxGeometry(0, 0, 120, 40),
                'rounded=1;whiteSpace=wrap;html=1;arcSize=40;fontColor=#000000;fillColor=#ffffc0;strokeColor=#ff0000;');
            cell.vertex = true;

            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;verticalAlign=bottom;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge.geometry.setTerminalPoint(new mxPoint(60, 100), false);
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, true);

            return this.createVertexTemplateFromCells([cell, edge], 120, 100, 'Activity');
        })),
        this.addEntry('uml activity composite state', mxUtils.bind(this, function() {
            var cell = new mxCell('Composite State', new mxGeometry(0, 0, 160, 60),
                'swimlane;html=1;fontStyle=1;align=center;verticalAlign=middle;childLayout=stackLayout;horizontal=1;startSize=30;horizontalStack=0;resizeParent=0;resizeLast=1;container=0;fontColor=#000000;collapsible=0;rounded=1;arcSize=30;strokeColor=#ff0000;fillColor=#ffffc0;swimlaneFillColor=#ffffc0;');
            cell.vertex = true;

            var cell1 = new mxCell('Subtitle', new mxGeometry(0, 0, 200, 26), 'text;html=1;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;spacingLeft=4;spacingRight=4;whiteSpace=wrap;overflow=hidden;rotatable=0;fontColor=#000000;');
            cell1.vertex = true;
            cell.insert(cell1);

            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;verticalAlign=bottom;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge.geometry.setTerminalPoint(new mxPoint(80, 120), false);
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, true);

            return this.createVertexTemplateFromCells([cell, edge], 160, 120, 'Composite State');
        })),
        this.addEntry('uml activity condition', mxUtils.bind(this, function() {
            var cell = new mxCell('Condition', new mxGeometry(0, 0, 80, 40), 'rhombus;whiteSpace=wrap;html=1;fillColor=#ffffc0;strokeColor=#ff0000;');
            cell.vertex = true;

            var edge1 = new mxCell('no', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;align=left;verticalAlign=bottom;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge1.geometry.setTerminalPoint(new mxPoint(180, 20), false);
            edge1.geometry.relative = true;
            edge1.geometry.x = -1;
            edge1.edge = true;

            cell.insertEdge(edge1, true);

            var edge2 = new mxCell('yes', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;align=left;verticalAlign=top;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge2.geometry.setTerminalPoint(new mxPoint(40, 100), false);
            edge2.geometry.relative = true;
            edge2.geometry.x = -1;
            edge2.edge = true;

            cell.insertEdge(edge2, true);

            return this.createVertexTemplateFromCells([cell, edge1, edge2], 180, 100, 'Condition');
        })),
        this.addEntry('uml activity fork join', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 200, 10), 'shape=line;html=1;strokeWidth=6;strokeColor=#ff0000;');
            cell.vertex = true;

            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;verticalAlign=bottom;endArrow=open;endSize=8;strokeColor=#ff0000;');
            edge.geometry.setTerminalPoint(new mxPoint(100, 80), false);
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, true);

            return this.createVertexTemplateFromCells([cell, edge], 200, 80, 'Fork/Join');
        })),
        this.createVertexTemplateEntry('ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#ff0000;', 30, 30, '', 'End', null, null, 'uml activity state end'),
        this.createVertexTemplateEntry('shape=umlLifeline;perimeter=lifelinePerimeter;whiteSpace=wrap;html=1;container=1;collapsible=0;recursiveResize=0;outlineConnect=0;', 100, 300, ':Object', 'Lifeline', null, null, 'uml sequence participant lifeline'),
        this.createVertexTemplateEntry('shape=umlLifeline;participant=umlActor;perimeter=lifelinePerimeter;whiteSpace=wrap;html=1;container=1;collapsible=0;recursiveResize=0;verticalAlign=top;spacingTop=36;labelBackgroundColor=#ffffff;outlineConnect=0;',
            20, 300, '', 'Actor Lifeline', null, null, 'uml sequence participant lifeline actor'),
        this.createVertexTemplateEntry('shape=umlLifeline;participant=umlBoundary;perimeter=lifelinePerimeter;whiteSpace=wrap;html=1;container=1;collapsible=0;recursiveResize=0;verticalAlign=top;spacingTop=36;labelBackgroundColor=#ffffff;outlineConnect=0;',
            50, 300, '', 'Boundary Lifeline', null, null, 'uml sequence participant lifeline boundary'),
        this.createVertexTemplateEntry('shape=umlLifeline;participant=umlEntity;perimeter=lifelinePerimeter;whiteSpace=wrap;html=1;container=1;collapsible=0;recursiveResize=0;verticalAlign=top;spacingTop=36;labelBackgroundColor=#ffffff;outlineConnect=0;',
            40, 300, '', 'Entity Lifeline', null, null, 'uml sequence participant lifeline entity'),
        this.createVertexTemplateEntry('shape=umlLifeline;participant=umlControl;perimeter=lifelinePerimeter;whiteSpace=wrap;html=1;container=1;collapsible=0;recursiveResize=0;verticalAlign=top;spacingTop=36;labelBackgroundColor=#ffffff;outlineConnect=0;',
            40, 300, '', 'Control Lifeline', null, null, 'uml sequence participant lifeline control'),
        this.createVertexTemplateEntry('shape=umlFrame;whiteSpace=wrap;html=1;', 300, 200, 'frame', 'Frame', null, null, 'uml sequence frame'),
        this.createVertexTemplateEntry('shape=umlDestroy;whiteSpace=wrap;html=1;strokeWidth=3;', 30, 30, '', 'Destruction', null, null, 'uml sequence destruction destroy'),
        this.createVertexTemplateEntry('shape=note;whiteSpace=wrap;html=1;size=14;verticalAlign=top;align=left;spacingTop=-6;', 100, 70, 'Note', 'Note', null, null, 'uml note'),
        this.addEntry('uml sequence invoke invocation call activation', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 10, 80), 'html=1;points=[];perimeter=orthogonalPerimeter;');
            cell.vertex = true;

            var edge = new mxCell('dispatch', new mxGeometry(0, 0, 0, 0), 'html=1;verticalAlign=bottom;startArrow=oval;endArrow=block;startSize=8;');
            edge.geometry.setTerminalPoint(new mxPoint(-60, 0), true);
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, false);

            return this.createVertexTemplateFromCells([cell, edge], 10, 80, 'Found Message');
        })),
        this.addEntry('uml sequence invoke call delegation synchronous invocation activation', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 10, 80), 'html=1;points=[];perimeter=orthogonalPerimeter;');
            cell.vertex = true;

            var edge1 = new mxCell('dispatch', new mxGeometry(0, 0, 0, 0), 'html=1;verticalAlign=bottom;endArrow=block;entryX=0;entryY=0;');
            edge1.geometry.setTerminalPoint(new mxPoint(-70, 0), true);
            edge1.geometry.relative = true;
            edge1.edge = true;

            cell.insertEdge(edge1, false);

            var edge2 = new mxCell('return', new mxGeometry(0, 0, 0, 0), 'html=1;verticalAlign=bottom;endArrow=open;dashed=1;endSize=8;exitX=0;exitY=0.95;');
            edge2.geometry.setTerminalPoint(new mxPoint(-70, 76), false);
            edge2.geometry.relative = true;
            edge2.edge = true;

            cell.insertEdge(edge2, true);

            return this.createVertexTemplateFromCells([cell, edge1, edge2], 10, 80, 'Synchronous Invocation');
        })),
        this.addEntry('uml sequence self call recursion delegation activation', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 20, 10, 40), 'html=1;points=[];perimeter=orthogonalPerimeter;');
            cell.vertex = true;

            var edge = new mxCell('self call', new mxGeometry(0, 0, 0, 0), 'edgeStyle=orthogonalEdgeStyle;html=1;align=left;spacingLeft=2;endArrow=block;rounded=0;entryX=1;entryY=0;');
            edge.geometry.setTerminalPoint(new mxPoint(5, 0), true);
            edge.geometry.points = [new mxPoint(30, 0)];
            edge.geometry.relative = true;
            edge.edge = true;

            cell.insertEdge(edge, false);

            return this.createVertexTemplateFromCells([cell, edge], 10, 60, 'Self Call');
        })),
        this.addEntry('uml sequence invoke call delegation callback activation', mxUtils.bind(this, function() {
            // TODO: Check if more entries should be converted to compressed XML
            return this.createVertexTemplateFromData('xZRNT8MwDIZ/Ta6oaymD47rBTkiTuMAxW6wmIm0q19s6fj1OE3V0Y2iCA4dK8euP2I+riGxedUuUjX52CqzIHkU2R+conKpuDtaKNDFKZAuRpgl/In264J303qSRCDVdk5CGhJ20WwhKEFo62ChoqritxURkReNMTa2X80LkC68AmgoIkEWHpF3pamlXR7WIFwASdBeb7KXY4RIc5+KBQ/ZGkY4RYY5Egyl1zLqLmmyDXQ6Zx4n5EIf+HkB2BmAjrV3LzftPIPw4hgNn1pQ1a2tH5Cp2QK1miG7vNeu4iJe4pdeY2BtvbCQDGlAljMCQxBJotJ8rWCFYSWY3LvUdmZi68rvkkLiU6QnL1m1xAzHoBOdw61WEb88II9AW67/ydQ2wq1Cy1aAGvOrFfPh6997qDA3g+dxzv3nIL6MPU/8T+kMw8+m4QPgdfrEJNo8PSQj/+s58Ag==',
                10, 60, 'Callback');
        })),
        this.createVertexTemplateEntry('html=1;points=[];perimeter=orthogonalPerimeter;', 10, 80, '', 'Activation', null, null, 'uml sequence activation'),
        this.createEdgeTemplateEntry('html=1;verticalAlign=bottom;startArrow=oval;startFill=1;endArrow=block;startSize=8;', 60, 0, 'dispatch', 'Found Message 1', null, 'uml sequence message call invoke dispatch'),
        this.createEdgeTemplateEntry('html=1;verticalAlign=bottom;startArrow=circle;startFill=1;endArrow=open;startSize=6;endSize=8;', 80, 0, 'dispatch', 'Found Message 2', null, 'uml sequence message call invoke dispatch'),
        this.createEdgeTemplateEntry('html=1;verticalAlign=bottom;endArrow=block;', 80, 0, 'dispatch', 'Message', null, 'uml sequence message call invoke dispatch'),
        this.addEntry('uml sequence return message', mxUtils.bind(this, function() {
            var edge = new mxCell('return', new mxGeometry(0, 0, 0, 0), 'html=1;verticalAlign=bottom;endArrow=open;dashed=1;endSize=8;');
            edge.geometry.setTerminalPoint(new mxPoint(80, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), false);
            edge.geometry.relative = true;
            edge.edge = true;

            return this.createEdgeTemplateFromCells([edge], 80, 0, 'Return');
        })),
        this.addEntry('uml relation', mxUtils.bind(this, function() {
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
        this.addEntry('uml association', mxUtils.bind(this, function() {
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
        this.addEntry('uml aggregation', mxUtils.bind(this, function() {
            var edge = new mxCell('1', new mxGeometry(0, 0, 0, 0), 'endArrow=open;html=1;endSize=12;startArrow=diamondThin;startSize=14;startFill=0;edgeStyle=orthogonalEdgeStyle;align=left;verticalAlign=bottom;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.geometry.x = -1;
            edge.geometry.y = 3;
            edge.edge = true;

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Aggregation 1');
        })),
        this.addEntry('uml composition', mxUtils.bind(this, function() {
            var edge = new mxCell('1', new mxGeometry(0, 0, 0, 0), 'endArrow=open;html=1;endSize=12;startArrow=diamondThin;startSize=14;startFill=1;edgeStyle=orthogonalEdgeStyle;align=left;verticalAlign=bottom;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(160, 0), false);
            edge.geometry.relative = true;
            edge.geometry.x = -1;
            edge.geometry.y = 3;
            edge.edge = true;

            return this.createEdgeTemplateFromCells([edge], 160, 0, 'Composition 1');
        })),
        this.addEntry('uml relation', mxUtils.bind(this, function() {
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
        this.createEdgeTemplateEntry('endArrow=open;endSize=12;dashed=1;html=1;', 160, 0, 'Use', 'Dependency', null, 'uml dependency use'),
        this.createEdgeTemplateEntry('endArrow=block;endSize=16;endFill=0;html=1;', 160, 0, 'Extends', 'Generalization', null, 'uml generalization extend'),
        this.createEdgeTemplateEntry('endArrow=block;startArrow=block;endFill=1;startFill=1;html=1;', 160, 0, '', 'Association 2', null, 'uml association'),
        this.createEdgeTemplateEntry('endArrow=open;startArrow=circlePlus;endFill=0;startFill=0;endSize=8;html=1;', 160, 0, '', 'Inner Class', null, 'uml inner class'),
        this.createEdgeTemplateEntry('endArrow=open;startArrow=cross;endFill=0;startFill=0;endSize=8;startSize=10;html=1;', 160, 0, '', 'Terminate', null, 'uml terminate'),
        this.createEdgeTemplateEntry('endArrow=block;dashed=1;endFill=0;endSize=12;html=1;', 160, 0, '', 'Implementation', null, 'uml realization implementation'),
        this.createEdgeTemplateEntry('endArrow=diamondThin;endFill=0;endSize=24;html=1;', 160, 0, '', 'Aggregation 2', null, 'uml aggregation'),
        this.createEdgeTemplateEntry('endArrow=diamondThin;endFill=1;endSize=24;html=1;', 160, 0, '', 'Composition 2', null, 'uml composition'),
        this.createEdgeTemplateEntry('endArrow=open;endFill=1;endSize=12;html=1;', 160, 0, '', 'Association 3', null, 'uml association')
    ];

    this.addPaletteFunctions('uml', mxResources.get('uml'), expand, fns);
};

Primitives.prototype.addBpmnPalette = function(dir, expend) {
    var fns = [
        this.createVertexTemplateEntry('shape=ext;rounded=1;html=1;whiteSpace=wrap;', 120, 80, 'Task', 'Process', null, null, 'bpmn task process'),
        this.createVertexTemplateEntry('shape=ext;rounded=1;html=1;whiteSpace=wrap;double=1;', 120, 80, 'Transaction', 'Transaction', null, null, 'bpmn transaction'),
        this.createVertexTemplateEntry('shape=ext;rounded=1;html=1;whiteSpace=wrap;dashed=1;dashPattern=1 4;', 120, 80, 'Event\nSub-Process', 'Event Sub-Process', null, null, 'bpmn event subprocess sub process sub-process'),
        this.createVertexTemplateEntry('shape=ext;rounded=1;html=1;whiteSpace=wrap;strokeWidth=3;', 120, 80, 'Call Activity', 'Call Activity', null, null, 'bpmn call activity'),
        this.addEntry('bpmn subprocess sub process sub-process', mxUtils.bind(this, function() {
            var cell = new mxCell('Sub-Process', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;shape=plus;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(-7, -14);
            cell.insert(cell1);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Sub-Process');
        })),
        this.addEntry(this.getTagsForStencil('mxgraph.bpmn', 'loop', 'subprocess sub process sub-process looped').join(' '), mxUtils.bind(this, function() {
            var cell = new mxCell('Looped\nSub-Process', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;shape=mxgraph.bpmn.loop;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(-15, -14);
            cell.insert(cell1);

            var cell2 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;shape=plus;');
            cell2.vertex = true;
            cell2.geometry.relative = true;
            cell2.geometry.offset = new mxPoint(1, -14);
            cell.insert(cell2);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Looped Sub-Process');
        })),
        this.addEntry('bpmn receive task', mxUtils.bind(this, function() {
            var cell = new mxCell('Receive', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0, 0, 20, 14), 'html=1;shape=message;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(7, 7);
            cell.insert(cell1);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Receive Task');
        })),
        this.addEntry(this.getTagsForStencil('mxgraph.bpmn', 'user_task').join(' '), mxUtils.bind(this, function() {
            var cell = new mxCell('User', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0, 0, 14, 14), 'html=1;shape=mxgraph.bpmn.user_task;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(7, 7);
            cell.insert(cell1);

            var cell2 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;shape=plus;outlineConnect=0;');
            cell2.vertex = true;
            cell2.geometry.relative = true;
            cell2.geometry.offset = new mxPoint(-7, -14);
            cell.insert(cell2);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'User Task');
        })),
        this.addEntry(this.getTagsForStencil('mxgraph.bpmn', 'timer_start', 'attached').join(' '), mxUtils.bind(this, function() {
            var cell = new mxCell('Process', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(1, 1, 30, 30), 'shape=mxgraph.bpmn.timer_start;perimeter=ellipsePerimeter;html=1;verticalLabelPosition=bottom;labelBackgroundColor=#ffffff;verticalAlign=top;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(-40, -15);
            cell.insert(cell1);

            return this.createVertexTemplateFromCells([cell], 120, 95, 'Attached Timer Event 1');
        })),
        this.addEntry(this.getTagsForStencil('mxgraph.bpmn', 'timer_start', 'attached').join(' '), mxUtils.bind(this, function() {
            var cell = new mxCell('Process', new mxGeometry(0, 0, 120, 80), 'html=1;whiteSpace=wrap;rounded=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(1, 0, 30, 30), 'shape=mxgraph.bpmn.timer_start;perimeter=ellipsePerimeter;html=1;labelPosition=right;labelBackgroundColor=#ffffff;align=left;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(-15, 10);
            cell.insert(cell1);

            return this.createVertexTemplateFromCells([cell], 135, 80, 'Attached Timer Event 2');
        })),
        this.createVertexTemplateEntry('swimlane;html=1;horizontal=0;startSize=20;', 320, 240, 'Pool', 'Pool', null, null, 'bpmn pool'),
        this.createVertexTemplateEntry('swimlane;html=1;horizontal=0;swimlaneLine=0;', 300, 120, 'Lane', 'Lane', null, null, 'bpmn lane'),
        this.createVertexTemplateEntry('shape=hexagon;html=1;whiteSpace=wrap;perimeter=hexagonPerimeter;rounded=0;', 60, 50, '', 'Conversation', null, null, 'bpmn conversation'),
        this.createVertexTemplateEntry('shape=hexagon;html=1;whiteSpace=wrap;perimeter=hexagonPerimeter;strokeWidth=4;rounded=0;', 60, 50, '', 'Call Conversation', null, null, 'bpmn call conversation'),
        this.addEntry('bpmn subconversation sub conversation sub-conversation', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 60, 50), 'shape=hexagon;whiteSpace=wrap;html=1;perimeter=hexagonPerimeter;rounded=0;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;shape=plus;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(-7, -14);
            cell.insert(cell1);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Sub-Conversation');
        })),
        this.addEntry('bpmn data object', mxUtils.bind(this, function() {
            var cell = new mxCell('', new mxGeometry(0, 0, 40, 60), 'shape=note;whiteSpace=wrap;size=16;html=1;');
            cell.vertex = true;

            var cell1 = new mxCell('', new mxGeometry(0, 0, 14, 14), 'html=1;shape=singleArrow;arrowWidth=0.4;arrowSize=0.4;outlineConnect=0;');
            cell1.vertex = true;
            cell1.geometry.relative = true;
            cell1.geometry.offset = new mxPoint(2, 2);
            cell.insert(cell1);

            var cell2 = new mxCell('', new mxGeometry(0.5, 1, 14, 14), 'html=1;whiteSpace=wrap;shape=parallelMarker;outlineConnect=0;');
            cell2.vertex = true;
            cell2.geometry.relative = true;
            cell2.geometry.offset = new mxPoint(-7, -14);
            cell.insert(cell2);

            return this.createVertexTemplateFromCells([cell], cell.geometry.width, cell.geometry.height, 'Data Object');
        })),
        this.createVertexTemplateEntry('shape=datastore;whiteSpace=wrap;html=1;', 60, 60, '', 'Data Store', null, null, 'bpmn data store'),
        this.createVertexTemplateEntry('shape=plus;html=1;outlineConnect=0;', 14, 14, '', 'Sub-Process Marker', null, null, 'bpmn subprocess sub process sub-process marker'),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.loop;html=1;outlineConnect=0;', 14, 14, '', 'Loop Marker', null, null, 'bpmn loop marker'),
        this.createVertexTemplateEntry('shape=parallelMarker;html=1;outlineConnect=0;', 14, 14, '', 'Parallel MI Marker', null, null, 'bpmn parallel mi marker'),
        this.createVertexTemplateEntry('shape=parallelMarker;direction=south;html=1;outlineConnect=0;', 14, 14, '', 'Sequential MI Marker', null, null, 'bpmn sequential mi marker'),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.ad_hoc;fillColor=#000000;html=1;outlineConnect=0;', 14, 14, '', 'Ad Hoc Marker', null, null, 'bpmn ad hoc marker'),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.compensation;html=1;outlineConnect=0;', 14, 14, '', 'Compensation Marker', null, null, 'bpmn compensation marker'),
        this.createVertexTemplateEntry('shape=message;whiteSpace=wrap;html=1;outlineConnect=0;fillColor=#000000;strokeColor=#ffffff;strokeWidth=2;', 40, 30, '', 'Send Task', null, null, 'bpmn send task'),
        this.createVertexTemplateEntry('shape=message;whiteSpace=wrap;html=1;outlineConnect=0;', 40, 30, '', 'Receive Task', null, null, 'bpmn receive task'),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.user_task;html=1;outlineConnect=0;', 14, 14, '', 'User Task', null, null, ''),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.manual_task;html=1;outlineConnect=0;', 14, 14, '', 'Manual Task', null, null, ''),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.business_rule_task;html=1;outlineConnect=0;', 14, 14, '', 'Business Rule Task', null, null, ''),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.service_task;html=1;outlineConnect=0;', 14, 14, '', 'Service Task', null, null, ''),
        this.createVertexTemplateEntry('shape=mxgraph.bpmn.script_task;html=1;outlineConnect=0;', 14, 14, '', 'Script Task', null, null, ''),
        this.createVertexTemplateEntry('html=1;shape=mxgraph.flowchart.annotation_2;align=left;labelPosition=right;', 50, 100, '', 'Annotation', null, null, ''),
        this.addEntry('container swimlane pool horizontal', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('zZRLbsIwEIZP4709TlHXhJYNSEicwCIjbNWJkWNKwumZxA6IlrRUaisWlmb+eX8LM5mXzdyrnV66Ai2TL0zm3rkQrbLJ0VoG3BRMzhgAp8fgdSQq+ijfKY9VuKcAYsG7snuMyso5G8U6tDaJ9cGUVlXkTXUoacuZIHOjjS0WqnX7blYd1OZt8KYea3PE1bCI+CAtVUMq7/o5b46uCmroSn18WFMm+XCdse5GpLq0OPqAzejxvZQun6MrMfiWUg6mCDpmZM8RENdotjqVyUFUdRS259oLSzISztto5Se0i44gcHEn3i9A/IQB3GbQpmi69DskAn4BSTaGBB4Jicj+k8nTGBP5SExg8odMyL38eH3s6kM8AQ==', 480, 380, 'Horizontal Pool 1');
        })),
        this.addEntry('container swimlane pool horizontal', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('zZTBbsIwDIafJvfU6dDOlI0LSEg8QUQtEi1tUBJGy9PPbcJQWTsxaZs4VLJ//07sT1WYKKpm6eRBrW2JhokXJgpnbYhR1RRoDAOuSyYWDIDTx+B1opr1VX6QDutwTwPEhndpjhiVjbUmij60Jon+pCsja8rmKlQ05SKjcKe0KVeytcfuLh/k7u2SzR16fcbNZZDsRlrLhlTenWedPts6SJMEOseFLTkph6Fj212RbGlwdAGbyeV7KW2+RFthcC1ZTroMKjry5wiIK9R7ldrELInSR2H/2XtlSUHCOY5WfEG76ggCz+7E+w2InzCAcQapIf0fAySzESQZ/AKSfAoJPCKS9mbzf0H0NIVIPDAiyP8QEaXX97CvDZ7LDw==', 480, 360, 'Horizontal Pool 2');
        })),
        this.createVertexTemplateEntry('swimlane;startSize=20;horizontal=0;', 320, 120, 'Lane', 'Horizontal Swimlane', null, null, 'swimlane lane pool'),
        this.addEntry('container swimlane pool horizontal', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('xZRBbsIwEEVP4709ThFrQssGJKSewCIjbNXGyDEl4fSdxKa0NJFQVTULSzP/e+T5b2EmS9esgjrqja/QMvnMZBm8j6lyTYnWMuCmYnLJADgdBi8jruhdflQBD/GRAUgD78qeMClb720S69jaLNZn46w6ULfQ0dGWS0HlThtbrVXrT91bdVS7t2u3CFibC26vi4g7aaMaUjmpNBbiKxnUQyfkjTBEbEZT9VKOtELvMIaWrpxNFXW6IWcpOddo9jqPFfMsqjoJ+8/ZGyQqMqdhZvIHs3WHBrh4kNvvIsNw5Da7OdgXAgKGCMz+gEAxRgCmINDcxZ2CyNMYETkhESj+jwi1t1+r9759ah8=', 360, 480, 'Vertical Pool 1');
        })),
        this.addEntry('container swimlane pool vertical', mxUtils.bind(this, function() {
            return this.createVertexTemplateFromData('xZTPbsIwDMafJvf86dDOlI0LSEg8QUQtEi1pUBJGy9PPbdJ1G1TqhXGoZH/219g/RSGitM3ay5PaugoMEW9ElN65mCLblGAM4VRXRKwI5xQ/wt8nqqyv0pP0UMc5Bp4Mn9KcISk750wSQ2xNFsNFWyNrzJYqWpxyxTA8KG2qjWzduTsrRHn4GLKlh6CvsBsGYX+krWxQpaiizcc9FjDnnaCc11dXR2lyxyjsuyPy3/Lg4CM0k8v3Ut58Dc5C9C22XHQVVeoQrwkQVaCPKtuKQZQhCcdv78gSg4zzPlpxg3bTEeSUzcR7Q2bWyvz+ytmQr8NPAow/ikAxRYA/kQAr/hPByxQC8cxLsHggAkzH56uv/XrdvgA=', 380, 480, 'Vertical Pool 2');
        })),
        this.createVertexTemplateEntry('swimlane;startSize=20;', 120, 320, 'Lane', 'Vertical Swimlane', null, null, 'swimlane lane pool'),
        this.createVertexTemplateEntry('rounded=1;arcSize=10;dashed=1;strokeColor=#000000;fillColor=none;gradientColor=none;dashPattern=8 3 1 3;strokeWidth=2;',
            200, 200, '', 'Group', null, null, ''),
        this.createEdgeTemplateEntry('endArrow=block;endFill=1;endSize=6;html=1;', 100, 0, '', 'Sequence Flow', null, 'bpmn sequence flow'),
        this.createEdgeTemplateEntry('startArrow=dash;startSize=8;endArrow=block;endFill=1;endSize=6;html=1;', 100, 0, '', 'Default Flow', null, 'bpmn default flow'),
        this.createEdgeTemplateEntry('startArrow=diamondThin;startFill=0;startSize=14;endArrow=block;endFill=1;endSize=6;html=1;', 100, 0, '', 'Conditional Flow', null, 'bpmn conditional flow'),
        this.createEdgeTemplateEntry('startArrow=oval;startFill=0;startSize=7;endArrow=block;endFill=0;endSize=10;dashed=1;html=1;', 100, 0, '', 'Message Flow 1', null, 'bpmn message flow'),
        this.addEntry('bpmn message flow', mxUtils.bind(this, function() {
            var edge = new mxCell('', new mxGeometry(0, 0, 0, 0), 'startArrow=oval;startFill=0;startSize=7;endArrow=block;endFill=0;endSize=10;dashed=1;html=1;');
            edge.geometry.setTerminalPoint(new mxPoint(0, 0), true);
            edge.geometry.setTerminalPoint(new mxPoint(100, 0), false);
            edge.geometry.relative = true;
            edge.edge = true;

            var cell = new mxCell('', new mxGeometry(0, 0, 20, 14), 'shape=message;html=1;outlineConnect=0;');
            cell.geometry.relative = true;
            cell.vertex = true;
            cell.geometry.offset = new mxPoint(-10, -7);
            edge.insert(cell);

            return this.createEdgeTemplateFromCells([edge], 100, 0, 'Message Flow 2');
        })),
        this.createEdgeTemplateEntry('shape=link;html=1;', 100, 0, '', 'Link', null, 'bpmn link')
    ];

    this.addPaletteFunctions('bpmn', mxResources.get('bpmn'), expend, fns);
};

// Primitives.prototype.addFlowchartPalette = function () {
//     var fns = this.addStencilPalette('flowchart', 'Flowchart', '../stencils/flowchart.xml',
//         ';whiteSpace=wrap;html=1;fillColor=#ffffff;strokeColor=#000000;strokeWidth=2');

//     this.addPaletteFunctions('flowchart', mxResources.get('flowchart'), true, fns);
// };

/**
 * Hides the current tooltip.
 */
Primitives.prototype.addEntry = function(tags, fn) {
    if (this.taglist != null && tags != null && tags.length > 0) {
        // Replaces special characters
        var tmp = tags.toLowerCase().replace(/[\/\,\(\)]/g, ' ').split(' ');

        var doAddEntry = mxUtils.bind(this, function(tag) {
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

Primitives.prototype.createVertexTemplateEntry = function(style, width, height, value, title, showLabel, showTitle, tags) {
    return this.addEntry(tags, mxUtils.bind(this, function() {
        return this.createVertexTemplate(style, width, height, value, title, showLabel, showTitle);
    }))
}

Primitives.prototype.createEdgeTemplateEntry = function(style, width, height, value, title, showLabel, tags) {
    return this.addEntry(tags, mxUtils.bind(this, function() {
        return this.createEdgeTemplate(style, width, height, value, title, showLabel);
    }))
}

Primitives.prototype.createVertexTemplate = function(style, width, height, value, title, showLabel, showTitle) {
    var vertex = new mxCell((value != null) ? value : '', new mxGeometry(0, 0, width, height), style);
    vertex.setVertex(true);
    return this.createItem(vertex, title, showLabel, width, height);
}

Primitives.prototype.createEdgeTemplate = function(style, width, height, value, title, showLabel) {

    var cell = new mxCell((value != null) ? value : '', new mxGeometry(0, 0, width, height), style);
    cell.geometry.setTerminalPoint(new mxPoint(0, height), true);
    cell.geometry.setTerminalPoint(new mxPoint(width, 0), false);
    cell.geometry.relative = true;
    cell.edge = true;

    return this.createItem(cell, title, showLabel, width, height);
};

/**
 * Creates a drop handler for inserting the given cells.
 */
Primitives.prototype.createVertexTemplateFromData = function(data, width, height, title, showLabel, showTitle, allowCellsInserted) {
    //var doc = mxUtils.parseXml(this.graph.decompress(data));
    //var codec = new mxCodec(doc);

    var model = new mxGraphModel();
    //codec.decode(doc.documentElement, model);

    var cell = this.graph.cloneCells(model.root.getChildAt(0).children);

    return this.createItem(cell, title, showLabel, width, height, showTitle, allowCellsInserted);
};

/**
 * Creates a drop handler for inserting the given cells.
 */
Primitives.prototype.createEdgeTemplateFromCells = function(cells, width, height, title, showLabel, allowCellsInserted) {
    return this.createItem(cells, title, showLabel, width, height, allowCellsInserted);
};

Primitives.prototype.createVertexTemplateFromCells = function(cells, width, height, title, showLabel, allowCellsInserted) {
    return this.createItem(cells, title, showLabel, width, height, allowCellsInserted);
};

Primitives.prototype.createItem = function(cell, title, showLabel, width, height) {
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

Primitives.prototype.addToolbarItem = function(graph, toolbar, prototype, show, width, height, title, showLabel) {
    sb = this;
    var funct = function(graph, evt, cell, x, y) {

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
            console.log(vertex);
            vertex = graph.importCells([vertex], 0, 0, cell);
            graph.setSelectionCells(vertex);

        } finally {
            graph.getModel().endUpdate();
        }
    };


    var ds = mxUtils.makeDraggable(toolbar, graph, funct, show, 0, 0, graph.autoScroll, true, true);

    mxEvent.addGestureListeners(toolbar, null, mxUtils.bind(this, function(evt) {

        if (mxEvent.isMouseEvent(evt)) {
            showVertex = sb.getCellsLayout(prototype);
            this.showTooltip(toolbar, [showVertex], width, height, title, showLabel);
        }
    }));

   
    mxEvent.addListener(toolbar, 'click', function(evt) {
        addClickHandler(toolbar, ds, evt, prototype);
    })

    mxEvent.addListener(toolbar, 'mousedown', function(evt) {
        HoverIcons.prototype.initAll();
    })

    return toolbar;
}

Primitives.prototype.getCellsLayout = function(cells) {
    layoutManagers = this.layoutManager;

    var showVertex = graph.getModel().cloneCell(cells[0] != null ? cells[0] : cells);
    var layout = layoutManagers.getLayout(showVertex);
    layoutManagers.executeLayout(layout, showVertex);

    return showVertex;
}

originalNoForeignObject = mxClient.NO_FO;
transparentImage = 'data:image/gif;base64,R0lGODlhMAAwAIAAAP///wAAACH5BAEAAAAALAAAAAAwADAAAAIxhI+py+0Po5y02ouz3rz7D4biSJbmiabqyrbuC8fyTNf2jef6zvf+DwwKh8Si8egpAAA7';

Primitives.prototype.createThumb = function(cells, width, height, parent, title, showLabel, showTitle, realWidth, realHeight) {
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

Primitives.prototype.cloneCell = function(cell, value) {
    var clone = cell.clone();

    if (value != null) {
        clone.value = value;
    }

    return clone;
};


Primitives.prototype.addDataEntry = function(tags, width, height, title, data) {
    return this.addEntry(tags, mxUtils.bind(this, function() {
        return this.createVertexTemplateFromData(data, width, height, title);
    }));
};

/**
 * Adds the given palette.
 */
Primitives.prototype.addPaletteFunctions = function(id, title, bool, fns) {
    this.addPalette(id, title, bool, mxUtils.bind(this, function(content) {
        for (var i = 0; i < fns.length; i++) {
            content.appendChild(fns[i](content));
        }
    }));
};

Primitives.prototype.addPalette = function(id, title, bool, onInit) {
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
    // Keeps references to the DOM nodes
    this.addFoldingHandler(title, elt, div, onInit);
    if (id != null) {
        this.palettes[id] = [elt, outer];
    }

    onInit = null;
    return div;
};

Primitives.prototype.addFoldingHandler = function(title, prent, doc, oninit) {
    var img = document.createElement('img');
    doc.style.display == 'none' ? img.src = 'image/下.png' : img.src = 'image/上.png';
    img.className = 'upanddown';

    var span = document.createElement('span');
    mxUtils.write(span, title);

    prent.appendChild(img);
    prent.appendChild(span);

    mxEvent.addListener(prent, 'click', function() {
        if (doc.style.display == "none") {
            doc.style.display = 'block';
            img.src = 'image/上.png';
            doc.innerHTML = "";
            oninit(doc);
        } else {
            doc.style.display = 'none';
            img.src = "image/下.png"

        }
    })
}

/**
 * Creates and returns a preview element for the given width and height.
 */
Primitives.prototype.createDragPreview = function(width, height) {
    var elt = document.createElement('div');
    elt.style.border = this.dragPreviewBorder;
    elt.style.width = width + 'px';
    elt.style.height = height + 'px';

    return elt;
};

/**
 * Sets the link for the given cell.
 */
Primitives.prototype.setAttributeForCell = function(cell, attributeName, attributeValue) {
    var value = null;

    if (cell.value != null && typeof(cell.value) == 'object') {
        value = cell.value.cloneNode(true);
    } else {
        var doc = mxUtils.createXmlDocument();

        value = doc.createElement('UserObject');
        value.setAttribute('label', cell.value || '');
    }

    if (attributeValue != null) {
        value.setAttribute(attributeName, attributeValue);
    } else {
        value.removeAttribute(attributeName);
    }

    this.graph.model.setValue(cell, value);
};

Primitives.prototype.getDisplay = function(display, doc) {
    // var content = document.getElementsByClassName(doc)[0];
    // var per = $('.title-' + doc)[0].children[0];
    // display ? content.style.display = 'block' : content.style.display = 'none';
    // !display ? per.src = "../image/下.png" : per.src = "../image/上.png";
}

Primitives.prototype.showEntries = function(stc, remember, force) {
    this.libs = (stc != null && (force || stc.length > 0)) ? stc : this.defaultEntries.split(";");
    var tmp = this.libs;

    // Maps library names via the alias table
    for (var i = 0; i < tmp.length; i++) {
        tmp[i] = this.libAliases[tmp[i]] || tmp[i];
    }

    for (var i = 0; i < this.configuration.length; i++) {
        // Search has separate switch in Extras menu
        if (this.configuration[i].id != 'search') {
            this.showPalettes(this.configuration[i].prefix || '',
                this.configuration[i].libs || [this.configuration[i].id],
                mxUtils.indexOf(tmp, this.configuration[i].id) >= 0);
        }
    }
}

Primitives.prototype.showPalettes = function(prefix, ids, visible) {
    for (var i = 0; i < ids.length; i++) {
        this.showPalette(prefix + ids[i], visible);
    }
};

Primitives.prototype.showPalette = function(id, visible) {
    var elts = this.palettes[id];

    if (elts != null) {
        var vis = (visible != null) ? ((visible) ? 'block' : 'none') : (elts[0].style.display == 'none') ? 'block' : 'none';

        for (var i = 0; i < elts.length; i++) {
            elts[i].style.display = vis;
        }
    }
};

/**
 * Sets the link for the given cell.
 */
Primitives.prototype.setLinkForCell = function(cell, link) {
    this.setAttributeForCell(cell, 'link', link);
};

Primitives.prototype.addStencilPalette = function(id, title, stencilFile, style, ignore, onInit, scale, tags, customFns) {
    var fns = [];
    if (customFns != null) {
        for (var i = 0; i < customFns.length; i++) {
            fns.push(customFns[i]);
        }
    }

    var xmlDoc = loadXMLDoc(stencilFile);

    var postStencilLoad = mxUtils.bind(this, function(packageName, stencilName, displayName, w, h) {
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

/**
 * Creates the array of tags for the given stencil. Duplicates are allowed and will be filtered out later.
 */
Primitives.prototype.getTagsForStencil = function(packageName, stencilName, moreTags) {
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
Primitives.prototype.filterTags = function(tags) {
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

// Loads the given stencil XML file.
mxStencilRegistry.loadStencil = function(filename, fn) {
    if (fn != null) {
        var req = mxUtils.get(filename, mxUtils.bind(this, function(req) {
            fn((req.getStatus() >= 200 && req.getStatus() <= 299) ? req.getXml() : null);
        }));
    } else {
        return mxUtils.load(filename).getXml();
    }
};

// Parses the given stencil set
mxStencilRegistry.parseStencilSet = function(root, postStencilLoad, install) {
    if (root.nodeName == 'stencils') {
        var shapes = root.firstChild;

        while (shapes != null) {
            if (shapes.nodeName == 'shapes') {
                mxStencilRegistry.parseStencilSet(shapes, postStencilLoad, install);
            }

            shapes = shapes.nextSibling;
        }
    } else {
        install = (install != null) ? install : true;
        var shape = root.firstChild;
        var packageName = '';
        var name = root.getAttribute('name');

        if (name != null) {
            packageName = name + '.';
        }

        while (shape != null) {
            if (shape.nodeType == mxConstants.NODETYPE_ELEMENT) {
                name = shape.getAttribute('name');

                if (name != null) {
                    packageName = packageName.toLowerCase();
                    var stencilName = name.replace(/ /g, "_");

                    if (install) {
                        mxStencilRegistry.addStencil(packageName + stencilName.toLowerCase(), new mxStencil(shape));
                    }

                    if (postStencilLoad != null) {
                        var w = shape.getAttribute('w');
                        var h = shape.getAttribute('h');

                        w = (w == null) ? 80 : parseInt(w, 10);
                        h = (h == null) ? 80 : parseInt(h, 10);

                        postStencilLoad(packageName, stencilName, name, w, h);
                    }
                }
            }

            shape = shape.nextSibling;
        }
    }
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

    // Places at same x-coord and 2 grid sizes below existing graph
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

/**
 * Creates the array of tags for the given stencil. Duplicates are allowed and will be filtered out later.
 */
Primitives.prototype.getTagsForStencil = function(packageName, stencilName, moreTags) {
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

Primitives.prototype.Find = function(doc, value) {

    var action = mxUtils.bind(this, function(results, len, more, expand) {
        doc.innerHTML = "";
        if (results.length > 0 || this.searchTerm == "") {
            for (var i = 0; i < results.length; i++) {
                graph.Search = true;
                doc.appendChild(results[i](doc));
            }
        } else {
            var err = document.createElement('div');
            err.className = 'geTitle';
            err.style.cssText = 'background-color:transparent;border-color:transparent;' +
                'color:gray;padding:6px 0px 0px 0px !important;margin:4px 8px 4px 8px;' +
                'text-align:center;cursor:default !important';

            mxUtils.write(err, mxResources.get('noResultsFor', [this.searchTerm]));
            doc.appendChild(err);
        }
        expand ? doc.style.display = 'block' : doc.style.display = 'none';
    });

    if (value != "") {
        if (this.searchTerm != value) {
            this.searchTerm = value;

            var tmp = this.searchTerm.toLowerCase().split(' ');
            var results = [];
            var dict = new mxDictionary();
            var index = 0;
            for (var i = 0; i < tmp.length; i++) {
                if (tmp[i].length > 0) {
                    var entry = this.taglist[tmp[i]];
                    var tmpDict = new mxDictionary();

                    if (entry != null) {
                        var arr = entry.entries;
                        results = [];

                        for (var j = 0; j < arr.length; j++) {
                            var entry = arr[j];
                            if ((index == 0) == (dict.get(entry) == null)) {
                                tmpDict.put(entry, entry);
                                results.push(entry);

                                if (tmp.length == index) {
                                    action(results, true, tmp, true);
                                    return;
                                }
                            }
                        }

                    } else {
                        results = [];
                    }
                    dict = tmpDict;
                    index++;
                }
            }
            action(results, true, tmp, true);
        }
    } else {
        this.searchTerm = "";
        action([], null, tmp, true);
    }
}

/**
 * Adds all palettes to the sidebar.
 */
Primitives.prototype.showTooltip = function(elt, cells, w, h, title, showLabel) {
    if (this.showTooltips) {
        if (this.currentElt != elt) {
            if (this.thread != null) {
                window.clearTimeout(this.thread);
                this.thread = null;
            }

            var show = mxUtils.bind(this, function() {
                // Lazy creation of the DOM nodes and graph instance
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

                // Adds title for entry
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

                    // Allows for wider labels
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

                // Updates width if label is wider
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

                // Workaround for ignored position CSS style in IE9
                // (changes to relative without the following line)
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

Primitives.prototype.hideTooltip = function() {
    if (this.thread != null) {
        window.clearTimeout(this.thread);
        this.thread = null;
    }

    if (this.tooltip != null) {
        this.tooltip.style.display = 'none';
        this.currentElt = null;
    }
};

Primitives.prototype.createTemporaryGraph = function(stylesheet) {
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

var include = function(src) {
    document.write('<script src="' + src + '"></script>');
}

Primitives.prototype.initPalettes = function() {
    var imgDir = '../img';
    var dir = STENCIL_PATH;
    var signs = this.signs;
    var gcp = this.gcp;
    var rack = this.rack;
    var pids = this.pids;
    var cisco = this.cisco;
    var cisco19 = this.cisco19;
    var cisco_safe = this.cisco_safe;
    var sysml = this.sysml;
    var eip = this.eip;
    var gmdl = this.gmdl;
    var office = this.office;
    var veeam = this.veeam;
    var veeam2 = this.veeam2;
    var archimate3 = this.archimate3;
    var electrical = this.electrical;

    if (urlParams['createindex'] == '1') {
        mxLog.show();
        mxLog.textarea.value = '';
    }

    this.addGeneralPalette(true);
    this.addMiscPalette(false);
    this.addAdvancedPalette(false);
    this.addBasicPalette(false);
    this.addArrowsPalette(false);
    this.addUmlPalette(false);

    this.addImagePalette('computer', 'Clipart / Computer', imgDir +
        '/lib/clip_art/computers/', '_128x128.png', ['Antivirus',
            'Data_Filtering', 'Database', 'Database_Add', 'Database_Minus',
            'Database_Move_Stack', 'Database_Remove', 'Fujitsu_Tablet',
            'Harddrive', 'IBM_Tablet', 'iMac', 'iPad', 'Laptop', 'MacBook',
            'Mainframe', 'Monitor', 'Monitor_Tower',
            'Monitor_Tower_Behind', 'Netbook', 'Network', 'Network_2',
            'Printer', 'Printer_Commercial', 'Secure_System', 'Server',
            'Server_Rack', 'Server_Rack_Empty', 'Server_Rack_Partial',
            'Server_Tower', 'Software', 'Stylus', 'Touch', 'USB_Hub',
            'Virtual_Application', 'Virtual_Machine', 'Virus',
            'Workstation'
        ], ['Antivirus', 'Data Filtering', 'Database',
            'Database Add', 'Database Minus', 'Database Move Stack',
            'Database Remove', 'Fujitsu Tablet', 'Harddrive', 'IBMTablet',
            'iMac', 'iPad', 'Laptop', 'MacBook', 'Mainframe', 'Monitor',
            'Monitor Tower', 'Monitor Tower Behind', 'Netbook', 'Network',
            'Network 2', 'Printer', 'Printer Commercial', 'Secure System',
            'Server', 'Server Rack', 'Server Rack Empty', 'Server Rack Partial',
            'Server Tower', 'Software', 'Stylus', 'Touch', 'USB Hub',
            'Virtual Application', 'Virtual Machine', 'Virus', 'Workstation'
        ]);

    this.addImagePalette('finance', 'Clipart / Finance', imgDir +
        '/lib/clip_art/finance/', '_128x128.png', ['Arrow_Down',
            'Arrow_Up', 'Coins', 'Credit_Card', 'Dollar', 'Graph',
            'Pie_Chart', 'Piggy_Bank', 'Safe', 'Shopping_Cart',
            'Stock_Down', 'Stock_Up'
        ], ['Arrow_Down', 'Arrow Up',
            'Coins', 'Credit Card', 'Dollar', 'Graph', 'Pie Chart',
            'Piggy Bank', 'Safe', 'Shopping Basket', 'Stock Down', 'Stock Up'
        ]);

    this.addImagePalette('clipart', 'Clipart / Various', imgDir +
        '/lib/clip_art/general/', '_128x128.png', ['Battery_0',
            'Battery_100', 'Battery_50', 'Battery_75', 'Battery_allstates',
            'Bluetooth', 'Earth_globe', 'Empty_Folder', 'Full_Folder',
            'Gear', 'Keys', 'Lock', 'Mouse_Pointer', 'Plug', 'Ships_Wheel',
            'Star', 'Tire'
        ], ['Battery 0%', 'Battery 100%', 'Battery 50%',
            'Battery 75%', 'Battery', 'Bluetooth', 'Globe',
            'Empty Folder', 'Full Folder', 'Gear', 'Keys', 'Lock', 'Mousepointer',
            'Plug', 'Ships Wheel', 'Star', 'Tire'
        ]);

    this.addImagePalette('networking', 'Clipart / Networking', imgDir +
        '/lib/clip_art/networking/', '_128x128.png', ['Bridge',
            'Certificate', 'Certificate_Off', 'Cloud', 'Cloud_Computer',
            'Cloud_Computer_Private', 'Cloud_Rack', 'Cloud_Rack_Private',
            'Cloud_Server', 'Cloud_Server_Private', 'Cloud_Storage',
            'Concentrator', 'Email', 'Firewall_02', 'Firewall',
            'Firewall-page1', 'Ip_Camera', 'Modem',
            'power_distribution_unit', 'Print_Server',
            'Print_Server_Wireless', 'Repeater', 'Router', 'Router_Icon',
            'Switch', 'UPS', 'Wireless_Router', 'Wireless_Router_N'
        ], ['Bridge', 'Certificate', 'Certificate Off', 'Cloud', 'Cloud Computer',
            'Cloud Computer Private', 'Cloud Rack', 'Cloud Rack Private',
            'Cloud Server', 'Cloud Server Private', 'Cloud Storage',
            'Concentrator', 'Email', 'Firewall 1', 'Firewall 2',
            'Firewall', 'Camera', 'Modem',
            'Power Distribution Unit', 'Print Server',
            'Print Server Wireless', 'Repeater', 'Router', 'Router Icon',
            'Switch', 'UPS', 'Wireless Router', 'Wireless Router N'
        ], {
            'Wireless_Router': 'wireless router switch wap wifi access point wlan',
            'Wireless_Router_N': 'wireless router switch wap wifi access point wlan',
            'Router': 'router switch',
            'Router_Icon': 'router switch'
        });

    this.addImagePalette('people', 'Clipart / People', imgDir +
        '/lib/clip_art/people/', '_128x128.png', ['Suit_Man',
            'Suit_Man_Black', 'Suit_Man_Blue', 'Suit_Man_Green',
            'Suit_Man_Green_Black', 'Suit_Woman', 'Suit_Woman_Black',
            'Suit_Woman_Blue', 'Suit_Woman_Green',
            'Suit_Woman_Green_Black', 'Construction_Worker_Man',
            'Construction_Worker_Man_Black', 'Construction_Worker_Woman',
            'Construction_Worker_Woman_Black', 'Doctor_Man',
            'Doctor_Man_Black', 'Doctor_Woman', 'Doctor_Woman_Black',
            'Farmer_Man', 'Farmer_Man_Black', 'Farmer_Woman',
            'Farmer_Woman_Black', 'Nurse_Man', 'Nurse_Man_Black',
            'Nurse_Woman',
            'Nurse_Woman_Black',
            'Military_Officer', 'Military_Officer_Black',
            'Military_Officer_Woman', 'Military_Officer_Woman_Black',
            'Pilot_Man', 'Pilot_Man_Black', 'Pilot_Woman',
            'Pilot_Woman_Black', 'Scientist_Man', 'Scientist_Man_Black',
            'Scientist_Woman', 'Scientist_Woman_Black', 'Security_Man',
            'Security_Man_Black', 'Security_Woman', 'Security_Woman_Black',
            'Tech_Man', 'Tech_Man_Black',
            'Telesales_Man', 'Telesales_Man_Black', 'Telesales_Woman',
            'Telesales_Woman_Black', 'Waiter', 'Waiter_Black',
            'Waiter_Woman', 'Waiter_Woman_Black', 'Worker_Black',
            'Worker_Man', 'Worker_Woman', 'Worker_Woman_Black'
        ]);

    this.addImagePalette('telco', 'Clipart / Telecommunication', imgDir +
        '/lib/clip_art/telecommunication/', '_128x128.png', [
            'BlackBerry', 'Cellphone', 'HTC_smartphone', 'iPhone',
            'Palm_Treo', 'Signal_tower_off', 'Signal_tower_on'
        ], ['BlackBerry', 'Cellphone', 'HTC smartphone', 'iPhone',
            'Palm Treo', 'Signaltower off', 'Signaltower on'
        ]);

    this.addFlowchartPalette();
    this.addActiveDirectoryPalette();
    this.addAndroidPalette();
    this.addAtlassianPalette();
    this.addBootstrapPalette();
    this.addDFDPalette();
    this.addErPalette();
    this.addIos7Palette();
    this.addIosPalette();
    this.addKubernetesPalette();
    this.addMockupPalette();
    this.addSitemapPalette();
    this.addAlliedTelesisPalette();
    this.addAWS3Palette();
    this.addAWS4bPalette();
    this.addAWS4Palette();
    this.addAWS3DPalette();
    this.addAzurePalette();
    this.addMSCAEPalette();
    this.addC4Palette();

    for (var i = 0; i < cisco.length; i++) {
        this.addStencilPalette('cisco' + cisco[i], 'Cisco / ' + cisco[i],
            dir + '/cisco/' + cisco[i].toLowerCase().replace(/ /g, '_') + '.xml',
            ';html=1;pointerEvents=1;dashed=0;fillColor=#036897;strokeColor=#ffffff;strokeWidth=2;verticalLabelPosition=bottom;verticalAlign=top;align=center;outlineConnect=0;', null, null, 1.6);
    }

    this.addCisco19Palette();
    this.addCiscoSafePalette();
    this.addCumulusPalette();
    this.addCitrixPalette();
    this.addGCP2Palette();
    this.addIBMPalette();
    this.addNetworkPalette();
    this.addOfficePalette();

    for (var i = 0; i < rack.length; i++) {
        if (rack[i].toLowerCase() === 'general') {
            this.addRackGeneralPalette();
        } else if (rack[i].toLowerCase() === 'f5') {
            this.addRackF5Palette();
        } else if (rack[i].toLowerCase() === 'dell') {
            this.addRackDellPalette();
        } else {
            this.addStencilPalette('rack' + rack[i], 'Rack / ' + rack[i],
                dir + '/rack/' + rack[i].toLowerCase() + '.xml',
                ';html=1;labelPosition=right;align=left;spacingLeft=15;dashed=0;shadow=0;fillColor=#ffffff;');
        }
    }

    this.addVeeamPalette();
    this.addVeeam2Palette();
    this.addVVDPalette();
    this.addArchimate3Palette();
    this.addArchiMatePalette();
    this.addBpmnPalette(dir, false);

    for (var i = 0; i < sysml.length; i++) {
        if (sysml[i] == 'Model Elements') {
            this.addSysMLModelElementsPalette();
        } else if (sysml[i] == 'Blocks') {
            this.addSysMLBlocksPalette();
        } else if (sysml[i] == 'Ports and Flows') {
            this.addSysMLPortsAndFlowsPalette();
        } else if (sysml[i] == 'Constraint Blocks') {
            this.addSysMLConstraintBlocksPalette();
        } else if (sysml[i] == 'Activities') {
            this.addSysMLActivitiesPalette();
        } else if (sysml[i] == 'Interactions') {
            this.addSysMLInteractionsPalette();
        } else if (sysml[i] == 'State Machines') {
            this.addSysMLStateMachinesPalette();
        } else if (sysml[i] == 'Use Cases') {
            this.addSysMLUseCasesPalette();
        } else if (sysml[i] == 'Allocations') {
            this.addSysMLAllocationsPalette();
        } else if (sysml[i] == 'Requirements') {
            this.addSysMLRequirementsPalette();
        } else if (sysml[i] == 'Profiles') {
            this.addSysMLProfilesPalette();
        } else if (sysml[i] == 'Stereotypes') {
            this.addSysMLStereotypesPalette();
        }
    }

    this.addLeanMappingPalette();

    this.addCabinetsPalette();
    this.addInfographicPalette();

    for (var i = 0; i < eip.length; i++) {
        if (eip[i] == 'Message Construction') {
            this.addEipMessageConstructionPalette();
        } else if (eip[i] == 'Message Routing') {
            this.addEipMessageRoutingPalette();
        } else if (eip[i] == 'Message Transformation') {
            this.addEipMessageTransformationPalette();
        } else if (eip[i] == 'Messaging Channels') {
            this.addEipMessagingChannelsPalette();
        } else if (eip[i] == 'Messaging Endpoints') {
            this.addEipMessagingEndpointsPalette();
        } else if (eip[i] == 'Messaging Systems') {
            this.addEipMessagingSystemsPalette();
        } else if (eip[i] == 'System Management') {
            this.addEipSystemManagementPalette();
        }
    }

    this.addElectricalPalette();
    this.addFloorplanPalette();

    for (var i = 0; i < gmdl.length; i++) {
        if (gmdl[i] == 'Bottom Navigation') {
            this.addGMDLBottomNavigationPalette();
        } else if (gmdl[i] == 'Bottom Sheets') {
            this.addGMDLBottomSheetsPalette();
        } else if (gmdl[i] == 'Buttons') {
            this.addGMDLButtonsPalette();
        } else if (gmdl[i] == 'Cards') {
            this.addGMDLCardsPalette();
        } else if (gmdl[i] == 'Chips') {
            this.addGMDLChipsPalette();
        } else if (gmdl[i] == 'Dialogs') {
            this.addGMDLDialogsPalette();
        } else if (gmdl[i] == 'Dividers') {
            this.addGMDLDividersPalette();
        } else if (gmdl[i] == 'Grid Lists') {
            this.addGMDLGridListsPalette();
        } else if (gmdl[i] == 'Icons') {
            this.addGMDLIconsPalette();
        } else if (gmdl[i] == 'Lists') {
            this.addGMDLListsPalette();
        } else if (gmdl[i] == 'Menus') {
            this.addGMDLMenusPalette();
        } else if (gmdl[i] == 'Misc') {
            this.addGMDLMiscPalette();
        } else if (gmdl[i] == 'Pickers') {
            this.addGMDLPickersPalette();
        } else if (gmdl[i] == 'Selection Controls') {
            this.addGMDLSelectionControlsPalette();
        } else if (gmdl[i] == 'Sliders') {
            this.addGMDLSlidersPalette();
        } else if (gmdl[i] == 'Steppers') {
            this.addGMDLSteppersPalette();
        } else if (gmdl[i] == 'Tabs') {
            this.addGMDLTabsPalette();
        } else if (gmdl[i] == 'Text Fields') {
            this.addGMDLTextFieldsPalette();
        }
    }

    for (var i = 0; i < pids.length; i++) {
        if (pids[i] == 'Instruments') {
            this.addPidInstrumentsPalette();
        } else if (pids[i] == 'Misc') {
            this.addPidMiscPalette();
        } else if (pids[i] == 'Valves') {
            this.addPidValvesPalette();
        } else if (pids[i] == 'Compressors') {
            this.addPidCompressorsPalette();
        } else if (pids[i] == 'Engines') {
            this.addPidEnginesPalette();
        } else if (pids[i] == 'Filters') {
            this.addPidFiltersPalette();
        } else if (pids[i] == 'Flow Sensors') {
            this.addPidFlowSensorsPalette();
        } else if (pids[i] == 'Piping') {
            this.addPidPipingPalette();
        } else {
            this.addStencilPalette('pid' + pids[i], 'Proc. Eng. / ' + pids[i],
                dir + '/pid/' + pids[i].toLowerCase().replace(' ', '_') + '.xml',
                ';html=1;pointerEvents=1;align=center;' + mxConstants.STYLE_VERTICAL_LABEL_POSITION + '=bottom;' + mxConstants.STYLE_VERTICAL_ALIGN + '=top;dashed=0;');
        }
    }

    this.addWebIconsPalette();
    this.addWebLogosPalette();

    for (var i = 0; i < signs.length; i++) {
        this.addStencilPalette('signs' + signs[i], 'Signs / ' + signs[i],
            dir + '/signs/' + signs[i].toLowerCase() + '.xml',
            ';html=1;pointerEvents=1;fillColor=#000000;strokeColor=none;verticalLabelPosition=bottom;verticalAlign=top;align=center;');
    }

    this.addImagePalette('images', mxResources.get('images'), '../stencils/clipart/', '_128x128.png', ['Earth_globe', 'Empty_Folder', 'Full_Folder', 'Gear', 'Lock', 'Software', 'Virus', 'Email',
        'Database', 'Router_Icon', 'iPad', 'iMac', 'Laptop', 'MacBook', 'Monitor_Tower', 'Printer',
        'Server_Tower', 'Workstation', 'Firewall_02', 'Wireless_Router_N', 'Credit_Card',
        'Piggy_Bank', 'Graph', 'Safe', 'Shopping_Cart', 'Suit1', 'Suit2', 'Suit3', 'Pilot1',
        'Worker1', 'Soldier1', 'Doctor1', 'Tech1', 'Security1', 'Telesales1'
    ], null, {
        'Wireless_Router_N': 'wireless router switch wap wifi access point wlan',
        'Router_Icon': 'router switch'
    });

    // LATER: Check if conflicts with restore libs after loading file
    this.showEntries();
};

/**
 * Library definitions 
 */
Primitives.prototype.signs = ['Animals', 'Food', 'Healthcare', 'Nature', 'People', 'Safety', 'Science', 'Sports', 'Tech', 'Transportation', 'Travel'];

Primitives.prototype.ibm = ['Analytics', 'Applications', 'Blockchain', 'Data', 'DevOps', 'Infrastructure', 'Management', 'Miscellaneous', 'Security', 'Social', 'Users', 'VPC', 'Boxes', 'Connectors'];

Primitives.prototype.allied_telesis = ['Buildings', 'Computer and Terminals', 'Media Converters', 'Security', 'Storage', 'Switch', 'Wireless'];

Primitives.prototype.gcp = ['Cards', 'Big Data', 'Compute', 'Developer Tools', 'Extras', 'Identity and Security', 'Machine Learning', 'Management Tools', 'Networking', 'Storage Databases'];

Primitives.prototype.gcp2 = ['Paths', 'Zones', 'Service Cards', 'Compute', 'API Management', 'Security', 'Data Analytics', 'Data Transfer', 'Cloud AI', 'Internet of Things', 'Databases', 'Storage', 'Management Tools', 'Networking', 'Developer Tools', 'Expanded Product Cards', 'User Device Cards', 'Product Cards', 'General Icons', 'Icons AI Machine Learning', 'Icons Compute', 'Icons Data Analytics', 'Icons Management Tools', 'Icons Networking', 'Icons Developer Tools', 'Icons API Management', 'Icons Internet of Things', 'Icons Databases', 'Icons Storage', 'Icons Security', 'Icons Migration', 'Icons Hybrid and Multi Cloud'];

Primitives.prototype.rack = ['General', 'APC', 'Cisco', 'Dell', 'F5', 'HP', 'IBM', 'Oracle'];

Primitives.prototype.pids = ['Agitators', 'Apparatus Elements', 'Centrifuges', 'Compressors', 'Compressors ISO', 'Crushers Grinding',
    'Driers', 'Engines', 'Feeders', 'Filters', 'Fittings', 'Flow Sensors', 'Heat Exchangers', 'Instruments', 'Misc',
    'Mixers', 'Piping', 'Pumps', 'Pumps DIN', 'Pumps ISO', 'Separators', 'Shaping Machines', 'Valves', 'Vessels'
];

Primitives.prototype.cisco = ['Buildings', 'Computers and Peripherals', 'Controllers and Modules', 'Directors', 'Hubs and Gateways', 'Misc',
    'Modems and Phones', 'People', 'Routers', 'Security', 'Servers', 'Storage', 'Switches', 'Wireless'
];

Primitives.prototype.cisco19 = ['LAN Switching', 'Routing WAN', 'Network Management', 'Data Center', 'Wireless LAN', 'Collaboration', 'Security Clouds Connectors', 'Endpoint Client Device Icons', 'DNA SD Access', 'SD WAN Viptela', 'ETA Stealthwatch', 'SAFE'];

Primitives.prototype.cisco_safe = ['Architecture', 'Capability', 'Design', 'Threat'];

Primitives.prototype.sysml = ['Model Elements', 'Blocks', 'Ports and Flows', 'Constraint Blocks', 'Activities', 'Interactions', 'State Machines',
    'Use Cases', 'Allocations', 'Requirements', 'Profiles', 'Stereotypes'
];

Primitives.prototype.eip = ['Message Construction', 'Message Routing', 'Message Transformation', 'Messaging Channels', 'Messaging Endpoints',
    'Messaging Systems', 'System Management'
];

Primitives.prototype.gmdl = ['Bottom Navigation', 'Bottom Sheets', 'Buttons', 'Cards', 'Chips', 'Dialogs', 'Dividers', 'Grid Lists', 'Icons', 'Lists', 'Menus', 'Misc', 'Pickers',
    'Selection Controls', 'Sliders', 'Steppers', 'Tabs', 'Text Fields'
];

Primitives.prototype.aws2 = ['Analytics', 'Application Services', 'Compute', 'Database', 'Developer Tools', 'Enterprise Applications', 'Game Development', 'General', 'Internet of Things',
    'Management Tools', 'Mobile Services', 'Networking', 'On-Demand Workforce', 'SDKs', 'Security and Identity', 'Storage and Content Delivery', 'Groups'
];

Primitives.prototype.aws3 = ['Analytics', 'Application Services', 'Artificial Intelligence', 'Business Productivity', 'Compute', 'Contact Center', 'Database', 'Desktop and App Streaming', 'Developer Tools',
    'Game Development', 'General', 'Groups', 'Internet of Things',
    'Management Tools', 'Messaging', 'Migration', 'Mobile Services', 'Networking and Content Delivery', 'On Demand Workforce', 'SDKs', 'Security Identity and Compliance', 'Storage'
];

Primitives.prototype.aws4b = ['Arrows', 'General Resources', 'Illustrations', 'Groups Light', 'Groups Dark', 'Analytics', 'Application Integration', 'AR VR', 'Cost Management', 'Business Productivity', 'Compute', 'Customer Engagement',
    'Database', 'Desktop App Streaming', 'Developer Tools', 'Game Development', 'Internet of Things', 'IoT Things', 'IoT Resources', 'Machine Learning', 'Management Tools',
    'Media Services', 'Migration', 'Mobile Services', 'Network Content Delivery', 'Security Identity Compliance', 'Storage'
];

Primitives.prototype.aws4 = ['Arrows', 'General Resources', 'Illustrations', 'Groups', 'Analytics', 'Application Integration', 'AR VR', 'Cost Management', 'Blockchain',
    'Business Applications', 'EC2 Instance Types', 'Compute', 'Customer Enablement', 'Customer Engagement',
    'Database', 'End User Computing', 'Developer Tools', 'Game Tech', 'Internet of Things', 'IoT Things', 'IoT Resources', 'Machine Learning', 'Management Governance',
    'Media Services', 'Migration Transfer', 'Mobile', 'Network Content Delivery', 'Robotics', 'Satellite', 'Security Identity Compliance', 'Storage'
];

Primitives.prototype.office = ['Clouds', 'Communications', 'Concepts', 'Databases', 'Devices', 'Security', 'Servers', 'Services', 'Sites', 'Users'];

Primitives.prototype.veeam = ['Data Center', 'Misc', 'Software', 'Storage', 'UsersStatus', 'VASComponents', 'Backup Replication', 'Products', 'VMs and Tape', '2D', '3D'];
Primitives.prototype.veeam2 = ['Auxiliary', 'Data Center', 'Features', 'General', 'Products and Components', 'Software', 'States', 'Storage', '3D'];

Primitives.prototype.archimate3 = ['Application', 'Business', 'Composite', 'Implementation and Migration', 'Motivation', 'Physical', 'Relationships', 'Strategy', 'Technology'];

Primitives.prototype.electrical = ['LogicGates', 'Resistors', 'Capacitors', 'Inductors', 'SwitchesRelays', 'Diodes', 'Sources', 'Transistors', 'Misc', 'Audio', 'PlcLadder', 'Abstract', 'Optical', 'VacuumTubes', 'Waveforms', 'Instruments', 'RotMech', 'Transmission'];


Primitives.prototype.configuration = mxUtils.bind(this, function() {
    return [{ id: 'general', libs: ['general', 'misc', 'advanced'] }, { id: 'uml' }, { id: 'images' }, { id: 'search' }, { id: 'er' },
        { id: 'ios', prefix: 'ios', libs: ['' /*prefix is library*/ , '7icons', '7ui'] },
        { id: 'android', prefix: 'android', libs: ['' /*prefix is library*/ ] }, { id: 'aws3d' },
        { id: 'flowchart' }, { id: 'basic' }, { id: 'infographic' }, { id: 'arrows' }, { id: 'lean_mapping' }, { id: 'citrix' }, { id: 'azure' }, { id: 'network' }, { id: 'vvd' },
        { id: 'sitemap' }, { id: 'c4' }, { id: 'dfd' }, { id: 'kubernetes' }, { id: 'cisco19', prefix: 'cisco19', libs: Primitives.prototype.cisco19 },
        { id: 'mscae', prefix: 'mscae', libs: ['Companies', 'EnterpriseFlat', 'IntuneFlat', 'OMSFlat', 'System CenterFlat', 'AI and ML Service', 'Analytics Service', 'Compute Service', 'Compute Service VM', 'Container Service', 'Databases Service', 'DevOps Service', 'General Service', 'Identity Service', 'Integration Service', 'Internet of Things Service', 'Intune Service', 'Management and Governance Service', 'Management and Governance Service Media', 'Migrate Service', 'Mixed Reality Service', 'Mobile Service', 'Networking Service', 'Other Category Service', 'Security Service', 'Storage Service', 'Web Service'] },
        { id: 'active_directory' },
        { id: 'bpmn', prefix: 'bpmn', libs: ['' /*prefix is library*/ , 'Gateways', 'Events'] },
        { id: 'clipart', prefix: null, libs: ['computer', 'finance', 'clipart', 'networking', 'people', 'telco'] },
        { id: 'ibm', prefix: 'ibm', libs: Primitives.prototype.ibm },
        { id: 'allied_telesis', prefix: 'allied_telesis', libs: Primitives.prototype.allied_telesis },
        { id: 'cumulus', libs: ['cumulus'] },
        { id: 'eip', prefix: 'eip', libs: Primitives.prototype.eip },
        { id: 'mockups', prefix: 'mockup', libs: ['Buttons', 'Containers', 'Forms', 'Graphics', 'Markup', 'Misc', 'Navigation', 'Text'] },
        {
            id: 'pid2',
            prefix: 'pid2',
            libs: ['Agitators', 'Apparatus Elements', 'Centrifuges', 'Compressors', 'Compressors ISO', 'Crushers Grinding',
                'Driers', 'Engines', 'Feeders', 'Filters', 'Fittings', 'Flow Sensors', 'Heat Exchangers', 'Instruments', 'Misc',
                'Mixers', 'Piping', 'Pumps', 'Pumps DIN', 'Pumps ISO', 'Separators', 'Shaping Machines', 'Valves', 'Vessels'
            ]
        },
        { id: 'signs', prefix: 'signs', libs: Primitives.prototype.signs },
        { id: 'gcp', prefix: 'gcp', libs: Primitives.prototype.gcp },
        { id: 'gcp2', prefix: 'gcp2', libs: Primitives.prototype.gcp2 },
        //           	                           {id: 'gcp19', prefix: 'gcp19', libs: Primitives.prototype.gcp2},
        { id: 'rack', prefix: 'rack', libs: Primitives.prototype.rack },
        { id: 'electrical', prefix: 'electrical', libs: Primitives.prototype.electrical },
        { id: 'aws2', prefix: 'aws2', libs: Primitives.prototype.aws2 },
        { id: 'aws3', prefix: 'aws3', libs: Primitives.prototype.aws3 },
        { id: 'aws4b', prefix: 'aws4b', libs: Primitives.prototype.aws4b },
        { id: 'aws4', prefix: 'aws4', libs: Primitives.prototype.aws4 },
        { id: 'pid', prefix: 'pid', libs: Primitives.prototype.pids },
        { id: 'cisco', prefix: 'cisco', libs: Primitives.prototype.cisco },
        { id: 'cisco_safe', prefix: 'cisco_safe', libs: Primitives.prototype.cisco_safe },
        { id: 'office', prefix: 'office', libs: Primitives.prototype.office },
        { id: 'veeam', prefix: 'veeam', libs: Primitives.prototype.veeam },
        { id: 'veeam2', prefix: 'veeam2', libs: Primitives.prototype.veeam2 },
        { id: 'cabinets', libs: ['cabinets'] },
        { id: 'floorplan', libs: ['floorplan'] },
        { id: 'bootstrap', libs: ['bootstrap'] },
        { id: 'atlassian', libs: ['atlassian'] },
        { id: 'gmdl', prefix: 'gmdl', libs: Primitives.prototype.gmdl },
        { id: 'archimate3', prefix: 'archimate3', libs: Primitives.prototype.archimate3 },
        { id: 'archimate', libs: ['archimate'] },
        { id: 'webicons', libs: ['webicons', 'weblogos'] },
        { id: 'sysml', prefix: 'sysml', libs: Primitives.prototype.sysml }
    ]
});

Primitives.prototype.entries = mxUtils.bind(this, function() {
    return [{
            title: mxResources.get('standard'),
            entries: [{ title: mxResources.get('general'), id: 'general', image: 'js/sidebar/images/sidebar-general.png' },
                { title: mxResources.get('basic'), id: 'basic', image: 'js/sidebar/images/sidebar-basic.png' },
                { title: mxResources.get('arrows'), id: 'arrows', image: 'js/sidebar/images/sidebar-arrows2.png' },
                { title: mxResources.get('clipart'), id: 'clipart', image: 'js/sidebar/images/sidebar-clipart.png' },
                { title: mxResources.get('flowchart'), id: 'flowchart', image: 'js/sidebar/images/sidebar-flowchart.png' },
                { title: mxResources.get('images'), id: 'images', image: 'js/sidebar/images/sidebar-images.png' }
            ]
        },
        {
            title: mxResources.get('software'),
            entries: [{ title: 'Active Directory', id: 'active_directory', image: 'js/sidebar/images/sidebar-active_directory.png' },
                { title: mxResources.get('android'), id: 'android', image: 'js/sidebar/images/sidebar-android.png' },
                { title: 'Atlassian', id: 'atlassian', image: 'js/sidebar/images/sidebar-atlassian.png' },
                { title: mxResources.get('bootstrap'), id: 'bootstrap', image: 'js/sidebar/images/sidebar-bootstrap.png' },
                { title: 'C4', id: 'c4', image: 'js/sidebar/images/sidebar-c4.png' },
                { title: 'Data Flow Diagram', id: 'dfd', image: 'js/sidebar/images/sidebar-dfd.png' },
                { title: mxResources.get('entityRelation'), id: 'er', image: 'js/sidebar/images/sidebar-er.png' },
                { title: mxResources.get('ios'), id: 'ios', image: 'js/sidebar/images/sidebar-ios.png' },
                { title: mxResources.get('mockups'), id: 'mockups', image: 'js/sidebar/images/sidebar-mockups.png' },
                { title: 'Sitemap', id: 'sitemap', image: 'js/sidebar/images/sidebar-sitemap.png' },
                { title: mxResources.get('uml'), id: 'uml', image: 'js/sidebar/images/sidebar-uml.png' }
            ]
        },
        {
            title: mxResources.get('networking'),
            entries: [{ title: 'Allied Telesis', id: 'allied_telesis', image: 'js/sidebar/images/sidebar-allied_telesis.png' },
                { title: 'AWS17', id: 'aws3', image: 'js/sidebar/images/sidebar-aws3.png' },
                { title: 'AWS18', id: 'aws4b', image: 'js/sidebar/images/sidebar-aws4b.png' },
                { title: 'AWS19', id: 'aws4', image: 'js/sidebar/images/sidebar-aws4.png' },
                // TODO: Add isometric containers  		                          
                { title: mxResources.get('aws3d'), id: 'aws3d', image: 'js/sidebar/images/sidebar-aws3d.png' },
                { title: mxResources.get('azure'), id: 'azure', image: 'js/sidebar/images/sidebar-azure.png' },
                { title: 'Cloud & Enterprise', id: 'mscae', image: 'js/sidebar/images/sidebar-mscae.png' },
                { title: mxResources.get('cisco'), id: 'cisco', image: 'js/sidebar/images/sidebar-cisco.png' },
                { title: 'Cisco19', id: 'cisco19', image: 'js/sidebar/images/sidebar-cisco19.png' },
                { title: 'Cisco Safe', id: 'cisco_safe', image: 'js/sidebar/images/sidebar-cisco_safe.png' },
                { title: 'Cumulus', id: 'cumulus', image: 'js/sidebar/images/sidebar-cumulus.png' },
                { title: 'Citrix', id: 'citrix', image: 'js/sidebar/images/sidebar-citrix.png' },
                //            			          {title: 'Google Cloud Platform', id: 'gcp2', image: 'js/sidebar/images/sidebar-gcp2.png'},
                { title: 'Google Cloud Platform', id: 'gcp2', image: 'js/sidebar/images/sidebar-gcp2.png' },
                { title: 'IBM', id: 'ibm', image: 'js/sidebar/images/sidebar-ibm.png' },
                { title: 'Kubernetes', id: 'kubernetes', image: 'js/sidebar/images/sidebar-kubernetes.png' },
                { title: 'Network', id: 'network', image: 'js/sidebar/images/sidebar-network.png' },
                { title: 'Office', id: 'office', image: 'js/sidebar/images/sidebar-office.png' },
                { title: mxResources.get('rack'), id: 'rack', image: 'js/sidebar/images/sidebar-rack.png' },
                { title: 'Veeam', id: 'veeam2', image: 'js/sidebar/images/sidebar-veeam.png' },
                { title: 'VMware', id: 'vvd', image: 'js/sidebar/images/sidebar-vvd.png' }
            ]
        },
        {
            title: mxResources.get('business'),
            entries: [{ title: 'ArchiMate 3.0', id: 'archimate3', image: 'js/sidebar/images/sidebar-archimate3.png' },
                { title: mxResources.get('archiMate21'), id: 'archimate', image: 'js/sidebar/images/sidebar-archimate.png' },
                { title: mxResources.get('bpmn'), id: 'bpmn', image: 'js/sidebar/images/sidebar-bpmn.png' },
                { title: mxResources.get('sysml'), id: 'sysml', image: 'js/sidebar/images/sidebar-sysml.png' },
                { title: 'Value Stream Mapping', id: 'lean_mapping', image: 'js/sidebar/images/sidebar-leanmapping.png' }
            ]
        },
        {
            title: mxResources.get('other'),
            entries: [{ title: mxResources.get('cabinets'), id: 'cabinets', image: 'js/sidebar/images/sidebar-cabinets.png' },
                { title: 'Infographic', id: 'infographic', image: 'js/sidebar/images/sidebar-infographic.png' },
                { title: mxResources.get('eip'), id: 'eip', image: 'js/sidebar/images/sidebar-eip.png' },
                { title: mxResources.get('electrical'), id: 'electrical', image: 'js/sidebar/images/sidebar-electrical.png' },
                { title: mxResources.get('floorplans'), id: 'floorplan', image: 'js/sidebar/images/sidebar-floorplans.png' },
                { title: mxResources.get('gmdl'), id: 'gmdl', image: 'js/sidebar/images/sidebar-gmdl.png' },
                { title: mxResources.get('procEng'), id: 'pid', image: 'js/sidebar/images/sidebar-pid.png' },
                // TODO add to mxResources
                { title: 'Web Icons', id: 'webicons', image: 'js/sidebar/images/sidebar-webIcons.png' },
                { title: mxResources.get('signs'), id: 'signs', image: 'js/sidebar/images/sidebar-signs.png' }
            ]
        }
    ]
});

Primitives.prototype.isEntryVisible = function(key) {
    for (var i = 0; i < this.configuration.length; i++) {
        if (this.configuration[i].id == key) {
            var id = (this.configuration[i].libs != null) ? ((this.configuration[i].prefix || '') + this.configuration[i].libs[0]) : key;
            var elts = this.palettes[id];

            if (elts != null) {
                return elts[0].style.display != 'none';
            }

            break;
        }
    }
}
var SHAPES_PATH = '../shapes';
var STENCIL_PATH = '../stencils';

mxStencilRegistry.libraries['mockup'] = [SHAPES_PATH + '/mockup/mxMockupButtons.js'];

mxStencilRegistry.libraries['arrows'] = [SHAPES_PATH + '/mxArrows.js'];
mxStencilRegistry.libraries['atlassian'] = [STENCIL_PATH + '/atlassian.xml', SHAPES_PATH + '/mxAtlassian.js'];
mxStencilRegistry.libraries['bpmn'] = [SHAPES_PATH + '/bpmn/mxBpmnShape2.js', STENCIL_PATH + '/bpmn.xml'];
mxStencilRegistry.libraries['c4'] = [SHAPES_PATH + '/mxC4.js'];
mxStencilRegistry.libraries['cisco19'] = [SHAPES_PATH + '/mxCisco19.js', STENCIL_PATH + '/cisco19.xml'];
mxStencilRegistry.libraries['dfd'] = [SHAPES_PATH + '/mxDFD.js'];
mxStencilRegistry.libraries['er'] = [SHAPES_PATH + '/er/mxER.js'];
mxStencilRegistry.libraries['kubernetes'] = [SHAPES_PATH + '/mxKubernetes.js', STENCIL_PATH + '/kubernetes.xml'];
mxStencilRegistry.libraries['flowchart'] = [SHAPES_PATH + '/mxFlowchart.js', STENCIL_PATH + '/flowchart.xml'];
mxStencilRegistry.libraries['ios'] = [SHAPES_PATH + '/mockup/mxMockupiOS.js'];
mxStencilRegistry.libraries['rackGeneral'] = [SHAPES_PATH + '/rack/mxRack.js', STENCIL_PATH + '/rack/general.xml'];
mxStencilRegistry.libraries['rackF5'] = [STENCIL_PATH + '/rack/f5.xml'];
mxStencilRegistry.libraries['lean_mapping'] = [SHAPES_PATH + '/mxLeanMap.js', STENCIL_PATH + '/lean_mapping.xml'];
mxStencilRegistry.libraries['basic'] = [SHAPES_PATH + '/mxBasic.js', STENCIL_PATH + '/basic.xml'];
mxStencilRegistry.libraries['ios7icons'] = [STENCIL_PATH + '/ios7/icons.xml'];
mxStencilRegistry.libraries['ios7ui'] = [SHAPES_PATH + '/ios7/mxIOS7Ui.js', STENCIL_PATH + '/ios7/misc.xml'];
mxStencilRegistry.libraries['android'] = [SHAPES_PATH + '/mxAndroid.js', STENCIL_PATH + '/android/android.xml'];
mxStencilRegistry.libraries['electrical/miscellaneous'] = [SHAPES_PATH + '/mxElectrical.js', STENCIL_PATH + '/electrical/miscellaneous.xml'];
mxStencilRegistry.libraries['electrical/transmission'] = [SHAPES_PATH + '/mxElectrical.js', STENCIL_PATH + '/electrical/transmission.xml'];
mxStencilRegistry.libraries['electrical/logic_gates'] = [SHAPES_PATH + '/mxElectrical.js', STENCIL_PATH + '/electrical/logic_gates.xml'];
mxStencilRegistry.libraries['electrical/abstract'] = [SHAPES_PATH + '/mxElectrical.js', STENCIL_PATH + '/electrical/abstract.xml'];
mxStencilRegistry.libraries['infographic'] = [SHAPES_PATH + '/mxInfographic.js'];
mxStencilRegistry.libraries['mockup/buttons'] = [SHAPES_PATH + '/mockup/mxMockupButtons.js'];
mxStencilRegistry.libraries['mockup/containers'] = [SHAPES_PATH + '/mockup/mxMockupContainers.js'];
mxStencilRegistry.libraries['mockup/forms'] = [SHAPES_PATH + '/mockup/mxMockupForms.js'];
mxStencilRegistry.libraries['mockup/graphics'] = [SHAPES_PATH + '/mockup/mxMockupGraphics.js', STENCIL_PATH + '/mockup/misc.xml'];
mxStencilRegistry.libraries['mockup/markup'] = [SHAPES_PATH + '/mockup/mxMockupMarkup.js'];
mxStencilRegistry.libraries['mockup/misc'] = [SHAPES_PATH + '/mockup/mxMockupMisc.js', STENCIL_PATH + '/mockup/misc.xml'];
mxStencilRegistry.libraries['mockup/navigation'] = [SHAPES_PATH + '/mockup/mxMockupNavigation.js', STENCIL_PATH + '/mockup/misc.xml'];
mxStencilRegistry.libraries['mockup/text'] = [SHAPES_PATH + '/mockup/mxMockupText.js'];
mxStencilRegistry.libraries['floorplan'] = [SHAPES_PATH + '/mxFloorplan.js', STENCIL_PATH + '/floorplan.xml'];
mxStencilRegistry.libraries['bootstrap'] = [SHAPES_PATH + '/mxBootstrap.js', STENCIL_PATH + '/bootstrap.xml'];
mxStencilRegistry.libraries['gmdl'] = [SHAPES_PATH + '/mxGmdl.js', STENCIL_PATH + '/gmdl.xml'];
mxStencilRegistry.libraries['gcp2'] = [SHAPES_PATH + '/mxGCP2.js', STENCIL_PATH + '/gcp2.xml'];
mxStencilRegistry.libraries['ibm'] = [SHAPES_PATH + '/mxIBM.js', STENCIL_PATH + '/ibm.xml'];
mxStencilRegistry.libraries['cabinets'] = [SHAPES_PATH + '/mxCabinets.js', STENCIL_PATH + '/cabinets.xml'];
mxStencilRegistry.libraries['archimate'] = [SHAPES_PATH + '/mxArchiMate.js'];
mxStencilRegistry.libraries['archimate3'] = [SHAPES_PATH + '/mxArchiMate3.js'];
mxStencilRegistry.libraries['sysml'] = [SHAPES_PATH + '/mxSysML.js'];
mxStencilRegistry.libraries['eip'] = [SHAPES_PATH + '/mxEip.js', STENCIL_PATH + '/eip.xml'];
mxStencilRegistry.libraries['networks'] = [SHAPES_PATH + '/mxNetworks.js', STENCIL_PATH + '/networks.xml'];
mxStencilRegistry.libraries['aws3d'] = [SHAPES_PATH + '/mxAWS3D.js', STENCIL_PATH + '/aws3d.xml'];
mxStencilRegistry.libraries['aws4'] = [SHAPES_PATH + '/mxAWS4.js', STENCIL_PATH + '/aws4.xml'];
mxStencilRegistry.libraries['aws4b'] = [SHAPES_PATH + '/mxAWS4.js', STENCIL_PATH + '/aws4.xml'];
mxStencilRegistry.libraries['veeam'] = [STENCIL_PATH + '/veeam/2d.xml', STENCIL_PATH + '/veeam/3d.xml', STENCIL_PATH + '/veeam/veeam.xml'];
mxStencilRegistry.libraries['veeam2'] = [STENCIL_PATH + '/veeam/2d.xml', STENCIL_PATH + '/veeam/3d.xml', STENCIL_PATH + '/veeam/veeam2.xml'];
mxStencilRegistry.libraries['pid2inst'] = [SHAPES_PATH + '/pid2/mxPidInstruments.js'];
mxStencilRegistry.libraries['pid2misc'] = [SHAPES_PATH + '/pid2/mxPidMisc.js', STENCIL_PATH + '/pid/misc.xml'];
mxStencilRegistry.libraries['pid2valves'] = [SHAPES_PATH + '/pid2/mxPidValves.js'];
mxStencilRegistry.libraries['pidFlowSensors'] = [STENCIL_PATH + '/pid/flow_sensors.xml'];

include("../js/sidebar/Sidebar-ActiveDirectory.js");
include("../js/sidebar/Sidebar-Advanced.js");
include("../js/sidebar/Sidebar-AlliedTelesis.js");
include("../js/sidebar/Sidebar-Android.js");
include("../js/sidebar/Sidebar-ArchiMate.js");
include("../js/sidebar/Sidebar-ArchiMate3.js");
include("../js/sidebar/Sidebar-Arrows2.js");
include("../js/sidebar/Sidebar-Atlassian.js");
include("../js/sidebar/Sidebar-AWS.js");
include("../js/sidebar/Sidebar-AWS3.js");
include("../js/sidebar/Sidebar-AWS3D.js");
include("../js/sidebar/Sidebar-AWS4.js");
include("../js/sidebar/Sidebar-AWS4b.js");
include("../js/sidebar/Sidebar-Azure.js");
include("../js/sidebar/Sidebar-Basic.js");
include("../js/sidebar/Sidebar-Bootstrap.js");
include("../js/sidebar/Sidebar-BPMN.js");
include("../js/sidebar/Sidebar-C4.js");
include("../js/sidebar/Sidebar-Cabinet.js");
include("../js/sidebar/Sidebar-Cisco19.js");
include("../js/sidebar/Sidebar-CiscoSafe.js");
include("../js/sidebar/Sidebar-Citrix.js");
include("../js/sidebar/Sidebar-Cumulus.js");
include("../js/sidebar/Sidebar-DFD.js");
include("../js/sidebar/Sidebar-EIP.js");
include("../js/sidebar/Sidebar-Electrical.js");
include("../js/sidebar/Sidebar-ER.js");
include("../js/sidebar/Sidebar-Floorplan.js");
include("../js/sidebar/Sidebar-Flowchart.js");
include("../js/sidebar/Sidebar-GCP.js");
include("../js/sidebar/Sidebar-GCP2.js");
include("../js/sidebar/Sidebar-Gmdl.js");
include("../js/sidebar/Sidebar-IBM.js");
include("../js/sidebar/Sidebar-Infographic.js");
include("../js/sidebar/Sidebar-Ios.js");
include("../js/sidebar/Sidebar-Ios7.js");
include("../js/sidebar/Sidebar-Kubernetes.js");
include("../js/sidebar/Sidebar-LeanMapping.js");
include("../js/sidebar/Sidebar-Mockup.js");
include("../js/sidebar/Sidebar-MSCAE.js");
include("../js/sidebar/Sidebar-Network.js");
include("../js/sidebar/Sidebar-Office.js");
include("../js/sidebar/Sidebar-PID.js");
include("../js/sidebar/Sidebar-Rack.js");
include("../js/sidebar/Sidebar-Sitemap.js");
include("../js/sidebar/Sidebar-Sysml.js");
include("../js/sidebar/Sidebar-Veeam.js");
include("../js/sidebar/Sidebar-Veeam2.js");
include("../js/sidebar/Sidebar-VVD.js");
include("../js/sidebar/Sidebar-WebIcons.js");