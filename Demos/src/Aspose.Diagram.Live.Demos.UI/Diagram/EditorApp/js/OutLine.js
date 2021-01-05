var OutLine = function () {
}

OutLine.prototype.init = function (x, y, w, h) {
    var div = document.createElement('div');
    div.style.position = 'absolute';
    div.style.width = '100%';
    div.style.height = '100%';
    div.style.border = '1px solid whiteSmoke';
    div.style.overflow = 'hidden';

    this.form = new mxWindow('OutLine', div, x, y, w, h, true, true);
    this.form.minimumSize = new mxRectangle(0, 0, 120, 120);
    this.form.destroyOnClose = false;
    this.form.setMaximizable(false);
    this.form.setResizable(true);
    this.form.setClosable(true);
    this.form.setVisible(true);

    var outline = new mxOutline(graph);

    var outlineCreateGraph = outline.createGraph;
    outline.createGraph = function (container) {
        var g = outlineCreateGraph.apply(this, arguments);
        g.gridEnabled = false;
        g.pageScale = graph.pageScale;
        g.pageFormat = graph.pageFormat;
        g.background = graph.backgroundColor == null ? '#ffffff' : graph.backgroundColor;
        g.backgroundImage = graph.backgroundImage == null ? null : graph.backgroundImage;
        g.pageVisible = graph.pageVisible;

        var current = mxUtils.getCurrentStyle(graph.container);
        div.style.backgroundColor = current.backgroundColor;

        return g;
    };

    this.form.addListener(mxEvent.SHOW, mxUtils.bind(this, function () {
        outline.outline.refresh();
        outline.update();
    }));

    this.updateOutline = function () {
        outline.outline.pageScale = outline.source.pageScale;
        outline.outline.pageFormat = outline.source.pageFormat;
        outline.outline.background = outline.source.background;
        outline.outline.pageVisible = outline.source.pageVisible;
        outline.outline.background = outline.source.backgroundColor == null ? '#ffffff' : outline.source.backgroundColor;
        outline.outline.backgroundImage = outline.source.backgroundImage == null ? null : outline.source.backgroundImage;

        var current = mxUtils.getCurrentStyle(graph.container);
        outline.outline.container.style.backgroundColor = current.backgroundColor;
    }

    graph.model.addListener("PageSizeChange", mxUtils.bind(this, function () {
        outline.outline.refresh();
        outline.update();
    }))

    graph.model.addListener('pageChange', mxUtils.bind(this, function (sender, evt) {
        var change = evt.getProperty('change');

        this.updateOutline();

        outline.outline.view.clear(change.previousPage.root, true);
        outline.outline.view.validate();
    }));

    outline.init(div);
}