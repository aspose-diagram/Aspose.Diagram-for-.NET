
Items = function () {
    this.init();
};

Items.prototype.init = function () {

}

Items.prototype.createPopupMenu = function (menu, cell, evt) {
    if (graph.isSelectionEmpty()) {
        this.addMenuItems(menu, ['undo', 'redo', 'paste'], null, evt);
        if (undoManager.history.length > 0) {
            menu.addSeparator();
        }
        this.addMenuItems(menu, ['selectVertices', 'selectEdges',
            'selectAll', 'selectNone', '-', 'clearDefaultStyle'], null, evt);
    }
    else {
        this.addMenuItems(menu, ['delete', '-', 'cut', 'copy'], null, evt);
    }
    if (graph.getSelectionCount() == 1) {
        if (graph.getModel().isVertex(cell) && mxUtils.getValue(graph.view.getState(graph.getSelectionCell()).style, mxConstants.STYLE_IMAGE, null) != null) {
            menu.addSeparator();
            this.addMenuItems(menu, ['editImage'], null, evt);
        }

        menu.addSeparator();

        this.addMenuItems(menu, ['toFront', 'toBack', '-', 'getAsDefaultStyle'], null, evt);
        if (Actions.prototype.cellStyle()) {
            this.addMenuItems(menu, ['setAsDefaultStyle'], null, evt);
        }
    }
}

Items.prototype.addMenuItems = function (menu, keys, parent, trigger, sprites) {
    for (var i = 0; i < keys.length; i++) {
        if (keys[i] == '-') {
            menu.addSeparator(parent);
        }
        else {
            this.addMenuItem(menu, keys[i], parent, trigger, (sprites != null) ? sprites[i] : null);
        }
    }
}

Items.prototype.addMenuItem = function (menu, key, parent, trigger, sprite, label) {
    var action = graph.actions.get(key.toLowerCase());

    if (action != null && (menu.showDisabled || action.isEnabled()) && action.visible) {
        var item = menu.addItem(mxResources.get(key) == null ? key : mxResources.get(key), null, action.funct, parent, sprite, action.isEnabled());

        this.addShortcut(item, action);

        return item;
    }

    return null;
}

Items.prototype.addShortcut = function (item, action) {
    if (action.shortcut != null) {
        var td = item.firstChild.nextSibling.nextSibling;
        var span = document.createElement('span');
        span.style.color = 'gray';
        mxUtils.write(span, action.shortcut);
        td.appendChild(span);
    }
}