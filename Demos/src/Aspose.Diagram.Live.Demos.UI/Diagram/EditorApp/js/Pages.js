var Pages = function() {
    this.createDefaultPage();
}
GUID_ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_";
VERSION = "@DRAWIO-VERSION@";

checkmarkImage = "data:image/gif;base64,R0lGODlhFQAVAMQfAGxsbHx8fIqKioaGhvb29nJycvr6+sDAwJqamltbW5OTk+np6YGBgeTk5Ly8vJiYmP39/fLy8qWlpa6ursjIyOLi4vj4+N/f3+3t7fT09LCwsHZ2dubm5r6+vmZmZv///yH/C1hNUCBEYXRhWE1QPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4wLWMwNjAgNjEuMTM0Nzc3LCAyMDEwLzAyLzEyLTE3OjMyOjAwICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M1IFdpbmRvd3MiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OEY4NTZERTQ5QUFBMTFFMUE5MTVDOTM5MUZGMTE3M0QiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6OEY4NTZERTU5QUFBMTFFMUE5MTVDOTM5MUZGMTE3M0QiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo4Rjg1NkRFMjlBQUExMUUxQTkxNUM5MzkxRkYxMTczRCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo4Rjg1NkRFMzlBQUExMUUxQTkxNUM5MzkxRkYxMTczRCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PgH//v38+/r5+Pf29fTz8vHw7+7t7Ovq6ejn5uXk4+Lh4N/e3dzb2tnY19bV1NPS0dDPzs3My8rJyMfGxcTDwsHAv769vLu6ubi3trW0s7KxsK+urayrqqmop6alpKOioaCfnp2cm5qZmJeWlZSTkpGQj46NjIuKiYiHhoWEg4KBgH9+fXx7enl4d3Z1dHNycXBvbm1sa2ppaGdmZWRjYmFgX15dXFtaWVhXVlVUU1JRUE9OTUxLSklIR0ZFRENCQUA/Pj08Ozo5ODc2NTQzMjEwLy4tLCsqKSgnJiUkIyIhIB8eHRwbGhkYFxYVFBMSERAPDg0MCwoJCAcGBQQDAgEAACH5BAEAAB8ALAAAAAAVABUAAAVI4CeOZGmeaKqubKtylktSgCOLRyLd3+QJEJnh4VHcMoOfYQXQLBcBD4PA6ngGlIInEHEhPOANRkaIFhq8SuHCE1Hb8Lh8LgsBADs=";
Pages.prototype.emptyDiagramXml = "<mxGraphModel><root><mxCell id=\"0\"/><mxCell id=\"1\" parent=\"0\"/></root></mxGraphModel>";
Pages.prototype.title = "Drawing.vsdx";
Pages.prototype.pageNum = 9;
Pages.prototype.pageArray = new Array();

Pages.prototype.createPageMenu = function(page) {
    return mxUtils.bind(this, function(menu, parent) {
        var model = graph.model;

        menu.addItem("Delete", null, mxUtils.bind(this, function() {
            this.removePage(page);
        }), parent);

        menu.addItem("ReName", null, mxUtils.bind(this, function() {
            this.renamePage(page, page.getName());
        }), parent);

        menu.addSeparator(parent);

        menu.addItem("Copy", null, mxUtils.bind(this, function() {
            this.CopyPage(page, 'Copy Of ' + page.getName());
        }), parent);

        menu.addSeparator(parent);

        menu.addItem("Page Set", null, mxUtils.bind(this, function() {
            this.PageSet(page);
        }), parent);
    });
}



Pages.prototype.createPageInsertTab = function() {
    var tab = this.createControlTab(4, '<div class="geSprite geSprite-plus" style="line-height: 35px;display:inline-block;width:21px;height:21px;"><i class="iconfont">&#xe608;</i></div>');
    tab.setAttribute('title', "InsertPage");

    mxEvent.addListener(tab, 'click', mxUtils.bind(this, function(evt) {
        this.insertPage();
        mxEvent.consume(evt);
    }));

    return tab;
};


Pages.prototype.createTabForPage = function(page, tabWidth, hoverEnabled, pageNumber) {
    var tab = this.createTab(hoverEnabled);
    var name = page.getName() || "Page-1";
    var id = page.getId();
    tab.setAttribute('title', name + ((id != null) ? ' (' + id + ')' : '') + ' [' + pageNumber + ']');
    mxUtils.write(tab, name);
    tab.style.maxWidth = tabWidth + 'px';
    tab.style.width = tabWidth + 'px';

    mxEvent.addGestureListeners(tab, mxUtils.bind(this, function(evt) {
        if (!graph.isMouseDown && graph.currentPage != page) {
            this.selectPage(page);
        }
    }), null, mxUtils.bind(this, function(evt) {
        if (graph.isEnabled() && !graph.isMouseDown &&
            ((mxEvent.isTouchEvent(evt) && graph.currentPage == page) ||
                mxEvent.isPopupTrigger(evt))) {

            this.hideCurrentMenu();

            if (!mxEvent.isTouchEvent(evt) || this.currentMenu == null) {
                var menu = new mxPopupMenu(this.createPageMenu(page));


                menu.hideMenu = mxUtils.bind(this, function() {
                    mxPopupMenu.prototype.hideMenu.apply(menu, arguments);
                    menu.destroy();
                })

                mxEvent.addListener(graph.container.parentNode.parentNode, 'click', function() {
                    if (menu.showDisabled == true) {
                        menu.hideMenu()
                    }
                })

                mxEvent.addListener(tab, 'click', function(evt) {
                    if (menu.showDisabled == true) {
                        menu.hideMenu();
                    }
                })

                menu.smartSeparators = true;
                menu.showDisabled = true;
                menu.autoExpand = true;

                var x = mxEvent.getClientX(evt);
                var y = mxEvent.getClientY(evt) - 150;
                menu.popup(x, y, null, evt);
                this.setCurrentMenu(menu, tab);
            }
        }
        mxEvent.consume(evt);
    }))

    if (tabWidth > 42) {
        tab.style.textOverflow = 'ellipsis';
    }

    return tab;
};


Pages.prototype.createPageTab = function() {
    if (this.tabContainer != null && graph.pages != null) {
        var wrapper = document.createElement('div');
        wrapper.style.position = 'relative';
        wrapper.style.display = (mxClient.IS_QUIRKS) ? 'inline' : 'inline-block';
        wrapper.style.height = this.tabContainer.clientHeight + "px";
        wrapper.style.whiteSpace = 'nowrap';
        wrapper.style.overflow = 'hidden';
        wrapper.style.fontSize = '13px';

        wrapper.style.marginLeft = '30px';

        var btnWidth = 59;
        var tabWidth = Math.min(140, Math.max(20, (this.tabContainer.clientWidth - btnWidth) / this.pageNum) + 1);
        var startIndex = null;

        for (var i = 0; i < graph.pages.length; i++) {
            if (graph.pages[i].show) {

                (mxUtils.bind(this, function(index, tab) {
                    if (graph.pages[index] == graph.currentPage) {
                        tab.style.backgroundColor = 'rgb(241, 243, 244)';
                    } else {
                        tab.style.backgroundColor = 'rgb(255, 255, 255)';
                    }

                    tab.setAttribute('draggable', 'true');

                    wrapper.appendChild(tab);
                }))(i, this.createTabForPage(graph.pages[i], tabWidth, graph.pages[i] != graph.currentPage, i + 1));

                this.tabContainer.innerHTML = '';
                this.tabContainer.appendChild(wrapper);

                var menutab = this.createPageMenuTab();
                this.tabContainer.appendChild(menutab);
                var insertTab = null;

                var insertTab = this.createPageInsertTab();
                this.tabContainer.appendChild(insertTab);

                if (graph.pages.length > this.pageNum) {
                    var pageMoreTab = this.createMorePageTab();
                    this.tabContainer.appendChild(pageMoreTab);
                }
            }
        }
    }
}

Pages.prototype.createTab = function(hoverEnabled) {
    var tab = document.createElement('div');
    tab.style.display = (mxClient.IS_QUIRKS) ? 'inline' : 'inline-block';
    tab.style.whiteSpace = 'nowrap';
    tab.style.boxSizing = 'border-box';
    tab.style.position = 'relative';
    tab.style.overflow = 'hidden';
    tab.style.textAlign = 'center';
    tab.style.marginLeft = '-1px';
    tab.style.height = this.tabContainer.clientHeight + 'px';
    tab.style.padding = '12px 4px 8px 4px';
    tab.style.border = '1px solid #e8eaed';
    tab.style.borderTopStyle = 'none';
    tab.style.borderBottomStyle = 'none';
    tab.style.backgroundColor = this.tabContainer.style.backgroundColor;
    tab.style.cursor = 'pointer';
    tab.style.color = 'gray';

    return tab;
};

Pages.prototype.createControlTab = function(paddingTop, html) {
    var tab = this.createTab(true);
    tab.style.lineHeight = this.tabContainerHeight + 'px';
    tab.style.paddingTop = paddingTop + 'px';
    tab.style.cursor = 'pointer';
    tab.style.width = '30px';
    tab.innerHTML = html;
    tab.parent = graph.container;

    if (tab.firstChild != null && tab.firstChild.style != null) {
        mxUtils.setOpacity(tab.firstChild, 40);
    }

    return tab;
};


Pages.prototype.createPageMenuTab = function() {
    var tab = this.createControlTab(3, '<div class="geSprite geSprite-dots" style="display:inline-block;margin-top:10px;width:21px;height:21px;"><i class="iconfont">&#xe607;</i></div>');
    tab.setAttribute('title', "Pages");
    tab.style.position = 'absolute';
    tab.style.marginLeft = '0px';
    tab.style.top = '0px';
    tab.style.left = '1px';

    mxEvent.addListener(tab, 'click', mxUtils.bind(this, function(evt) {
        var menu = new mxPopupMenu(mxUtils.bind(this, function(menu, parent) {
            this.hideCurrentMenu();
            for (var i = 0; i < graph.pages.length; i++) {
                (mxUtils.bind(this, function(index) {
                    var item = menu.addItem(graph.pages[index].getName(), null, mxUtils.bind(this, function() {
                        this.selectPage(graph.pages[index]);
                    }), parent);


                    if (graph.pages[index] == graph.currentPage) {
                        menu.addCheckmark(item, checkmarkImage);
                    }
                }))(i);
            }

            if (graph.isEnabled()) {
                menu.addSeparator(parent);

                var item = menu.addItem('InsertPage', null, mxUtils.bind(this, function() {
                    this.insertPage();
                }), parent);

                var page = graph.currentPage;

                if (page != null) {
                    menu.addSeparator(parent);

                    menu.addItem('Delete', null, mxUtils.bind(this, function() {
                        this.removePage(page);
                    }), parent);

                    menu.addItem('ReName', null, mxUtils.bind(this, function() {
                        this.renamePage(page, page.getName());
                    }), parent);

                    menu.addSeparator(parent);

                    menu.addItem('Copy', null, mxUtils.bind(this, function() {
                        this.CopyPage(page, 'Copy Of ', page.getName());
                    }), parent);
                }
            }
        }));

        menu.smartSeparators = true;
        menu.showDisabled = true;
        menu.autoExpand = true;

        menu.hideMenu = mxUtils.bind(this, function() {
            mxPopupMenu.prototype.hideMenu.apply(menu, arguments);
            menu.destroy();
        });

        mxEvent.addListener(graph.container.parentNode.parentNode, 'click', function() {
            if (menu.showDisabled == true) {
                menu.hideMenu()
            }
        })

        mxEvent.addListener(tab, 'click', function(evt) {
            if (menu.showDisabled == true) {
                menu.hideMenu();
            }
        })

        var x = mxEvent.getClientX(evt);
        var y = mxEvent.getClientY(evt) - 220;
        menu.popup(x, y, null, evt);

        this.setCurrentMenu(menu);

        mxEvent.consume(evt);
    }))

    return tab;
};

Pages.prototype.createMorePageTab = function() {
    var tab = this.createControlTab(3, '<div class="geSprite geSprite-more" style="display:inline-block;margin-top:10px;width:21px;height:21px;"><i class="iconfont">&#xe651;</i></div>');
    tab.setAttribute('title', "MorePages");
    tab.style.position = 'absolute';
    tab.style.marginLeft = '0px';
    tab.style.top = '0px';
    //tab.style.left = '1px';

    mxEvent.addListener(tab, 'click', mxUtils.bind(this, function(evt) {
        var menu = new mxPopupMenu(mxUtils.bind(this, function(menu, parent) {
            this.hideCurrentMenu();
            for (var i = 0; i < graph.pages.length; i++) {
                (mxUtils.bind(this, function(index) {
                    var item = menu.addItem(graph.pages[index].getName(), null, mxUtils.bind(this, function() {
                        this.selectPage(graph.pages[index]);
                    }), parent);

                    // 选中，打勾
                    if (graph.pages[index] == graph.currentPage) {
                        menu.addCheckmark(item, checkmarkImage);
                    }
                }))(i);
            }
        }));

        menu.smartSeparators = true;
        menu.showDisabled = true;
        menu.autoExpand = true;

        menu.hideMenu = mxUtils.bind(this, function() {
            mxPopupMenu.prototype.hideMenu.apply(menu, arguments);
            menu.destroy();
        });

        mxEvent.addListener(graph.container.parentNode.parentNode, 'click', function() {
            if (menu.showDisabled == true) {
                menu.hideMenu()
            }
        })

        mxEvent.addListener(tab, 'click', function(evt) {
            if (menu.showDisabled == true) {
                menu.hideMenu();
            }
        })

        var x = mxEvent.getClientX(evt);
        var y = mxEvent.getClientY(evt) - 220;
        menu.popup(x, y, null, evt);

        this.setCurrentMenu(menu);

        mxEvent.consume(evt);
    }))

    return tab;
}

Pages.prototype.setCurrentMenu = function(menu, elt) {
    this.currentMenuElt = elt;
    this.currentMenu = menu;
};

Pages.prototype.hideCurrentMenu = function() {
    if (this.currentMenu != null) {
        this.currentMenu.hideMenu();
        this.resetCurrentMenu();
    }
}

Pages.prototype.resetCurrentMenu = function() {
    this.currentMenuElt = null;
    this.currentMenu = null;
}

Pages.prototype.selectPage = function(page, quiet, viewState) {
    try {
        if (page != graph.currentPage) {
            this.hideCurrentMenu();
            if (graph.isEditing()) {
                graph.stopEditing(false);
            }

            quiet = (quiet != null) ? quiet : false;
            graph.isMouseDown = false;

            var edit = graph.model.createUndoableEdit();

            edit.ignoreEdit = true;

            var change = new SelectPage(this, page, viewState);
            change.execute();

            edit.add(change);
            edit.notify();
            graph.currentPage = page;

            graph.tooltipHandler.hide();
        }
    } catch (e) {
        mxUtils.alert(e);
    }
};

Pages.prototype.createDefaultPage = function() {
    var data = document.getElementsByClassName('geTabContainer');
    this.tabContainer = data[0];

    this.createFile();
    this.createPageTab();
    this.showOrNotPage();

    graph.model.addListener('change', mxUtils.bind(this, function() {
        window.setTimeout(mxUtils.bind(this, function() {
            this.updataCurrentFile();
        }), 3000);
        this.showOrNotPage();
        this.createPageTab();
    }));

    graph.model.addListener("backgroundChange", mxUtils.bind(this, function() {
        window.setTimeout(mxUtils.bind(this, function() {
            this.updataCurrentFile();
        }), 3000);
    }))

}

Pages.prototype.createFile = function(title, data, libs, mode, done, replace, folderId, tempFile, clibs) {
    title = title == null ? this.title : title;
    mode = (tempFile) ? null : ((mode != null) ? mode : this.mode);
    data = (data != null) ? data : this.emptyDiagramXml;

    try {
        this.fileCreated(new LocalFile(this, data, title, mode == null), libs, replace, done, clibs);
    } catch (e) {
        console.log(e);
    }
}


Pages.prototype.fileCreated = function(file, libs, replace, done, clibs) {
    var url = window.location.pathname;

    var data = file.getData();

    var dataNode = (data.length > 0) ? this.extractGraphModel(
        mxUtils.parseXml(data).documentElement, true) : null;

    var redirect = window.location.protocol + '//' + window.location.hostname + url;

    file.setData(this.createFileData(dataNode, file, redirect));

    if (file.constructor == LocalFile) {
        var currentFile = this.getCurrentFile();

        if (replace || currentFile == null || !currentFile.isModified()) {
            this.fileLoaded(file);
        }
    }
}


Pages.prototype.fileLoaded = function(file) {
    this.fileLoadedError = null;
    this.setCurrentFile(null);

    graph.model.clear();
    undoManager.clear();

    if (file != null) {
        this.openingFile = true;
        this.setCurrentFile(file);

        file.open();

        this.setMode(file.getMode());
        graph.model.prefix = guid() + '-';
        undoManager.clear();
    }
}

Pages.prototype.extractGraphModel = function(node, allowMxFile) {
    if (node != null) {
        var tmp = node.ownerDocument.getElementsByTagName('div');
        if (!allowMxFile) {
            var diagramNode = null;
            if (node.nodeName == 'diagram') {
                diagramNode = node;
            } else if (node.nodeName == 'mxfile') {
                var diagrams = node.getElementsByTagName('diagram');
                if (diagrams.length > 0) {
                    diagramNode = diagrams[Math.max(0, Math.min(diagrams.length - 1, urlParams['page'] || 0))];
                }
            }
            if (diagramNode != null) {
                node = this.parseDiagramNode(diagramNode);
            }
        }

        return node;
    } else {
        return null;
    }
}


Pages.prototype.getCurrentFile = function() {
    return this.currentFile;
}


Pages.prototype.setCurrentFile = function(file) {
    if (file != null) {
        file.opened = new Date();
    }

    this.currentFile = file;
}

Pages.prototype.insertPage = function(page, index) {
    this.hideCurrentMenu();
    if (graph.isEnabled()) {
        if (graph.isEditing()) {
            graph.stopEditing(false);
        }

        page = (page != null) ? page : this.createPage(null, this.createPageId());
        index = (index != null) ? index : graph.pages.length;

        var change = new ChangePage(this, page, page, index);
        graph.model.execute(change);
    }

    return page;
};


Pages.prototype.removePage = function(page) {
    try {
        var pageIndex = mxUtils.indexOf(graph.pages, page);
        if (graph.isEnabled() && graph.pages.length > 1) {
            graph.model.beginUpdate();
            try {
                var getPage = graph.currentPage;
                if (getPage = page && graph.pages.length > 1) {
                    if (pageIndex == graph.pages.length - 1) {
                        pageIndex--;
                    } else {
                        pageIndex++;
                    }

                    getPage = graph.pages[pageIndex];
                }
                graph.model.execute(new ChangePage(this, page, getPage));
            } finally {
                graph.model.endUpdate();
            }
        }
    } catch (e) {

    }

    return page;
}


Pages.prototype.CopyPage = function(page, name) {
    var newPage = null;
    try {
        if (graph.isEnabled() && page != null) {
            var node = page.node.cloneNode(false);
            node.removeAttribute('id');

            var newPage = new DiagramPage(node);
            newPage.root = graph.cloneCell(graph.model.root);

            newPage.setName(name);

            newPage = this.insertPage(newPage, mxUtils.indexOf(graph.pages, page) + 1);
        }
    } catch (e) {

    }
    return newPage;
}


Pages.prototype.renamePage = function(page, name) {
    if (graph.isEnabled() && page != null) {
        var lab = graph.dialog.ReName(this, name, "ReName", mxUtils.bind(this, function(name) {
            if (name != null && name.length > 0) {
                graph.model.beginUpdate()
                try {
                    page.setName(name);
                    this.createPageTab();
                } finally {
                    graph.model.endUpdate();
                }
            }
        }));

        graph.dialog.ShowDialog(lab, 300, 80);
    }
}


Pages.prototype.PageSet = function(page) {

    var size = graph.pageFormat;

    graph.dialog.ShowDialog(graph.dialog.PageSetUp(size.width, size.height), 350, 160);
}

Pages.prototype.createPageId = function() {
    return guid();
}


Pages.prototype.createPage = function(name, id) {
    var page = new DiagramPage(this.fileNode.ownerDocument.createElement('diagram'), id);
    page.setName((name != null) ? name : this.createPageName());

    return page;
};


Pages.prototype.createPageName = function() {
    var index;
    var num = 0;
    for (var page in graph.pages) {
        index = graph.pages[page].getName().split("-")[1];
        if (parseInt(index) > parseInt(num)) {
            num = index;
        }
    }
    if (num < graph.pages.length) {
        num = graph.pages.length;
    }
    ++num;
    return "Page-" + num;
}


Pages.prototype.createFileData = function(node, file, url, forceXml, forceSvg, forceHtml, embeddedCallback, ignoreSelection, compact, uncompressed) {
    graph = (graph != null) ? graph : graph;

    if (node == null) {
        return "";
    } else {
        var fileNode = node;

        if (fileNode.nodeName.toLowerCase() != 'mxfile') {
            if (uncompressed) {
                var diagramNode = node.ownerDocument.createElement('diagram');
                diagramNode.setAttribute('id', guid());
                diagramNode.appendChild(node);

                fileNode = node.ownerDocument.createElement('mxfile');
                fileNode.appendChild(diagramNode);
            } else {
                var text = this.zapGremlins(mxUtils.getXml(node));
                var data = this.zapGremlins(mxUtils.getXml(node));


                var diagramNode = node.ownerDocument.createElement('diagram');
                diagramNode.setAttribute('id', guid());
                diagramNode.appendChild(node);

                fileNode = node.ownerDocument.createElement('mxfile');
                fileNode.appendChild(diagramNode);

            }
        }

        if (!compact) {
            fileNode.removeAttribute('userAgent');
            fileNode.removeAttribute('version');
            fileNode.removeAttribute('editor');
            fileNode.removeAttribute('graph.pages');
            fileNode.removeAttribute('type');

            if (mxClient.IS_CHROMEAPP) {
                fileNode.setAttribute('host', 'Chrome');
            } else {
                fileNode.setAttribute('host', window.location.hostname);
            }

            fileNode.setAttribute('modified', new Date().toISOString());
            fileNode.setAttribute('agent', navigator.userAgent);
            fileNode.setAttribute('version', VERSION);
            fileNode.setAttribute('etag', guid());

            var md = (file != null) ? file.getMode() : this.mode;

            if (md != null) {
                fileNode.setAttribute('type', md);
            }

            if (fileNode.getElementsByTagName('diagram').length > 1 && graph.pages != null) {
                fileNode.setAttribute('graph.pages', graph.pages.length);
            }
        } else {
            fileNode = fileNode.cloneNode(true);
            fileNode.removeAttribute('modified');
            fileNode.removeAttribute('host');
            fileNode.removeAttribute('agent');
            fileNode.removeAttribute('etag');
            fileNode.removeAttribute('userAgent');
            fileNode.removeAttribute('version');
            fileNode.removeAttribute('editor');
            fileNode.removeAttribute('type');
        }

        var xml = mxUtils.getXml(fileNode);

        return xml;
    }
}


Pages.prototype.zapGremlins = function(text) {
    var checked = [];

    for (var i = 0; i < text.length; i++) {
        var code = text.charCodeAt(i);

        if ((code >= 32 || code == 9 || code == 10 || code == 13) &&
            code != 0xFFFF && code != 0xFFFE) {
            checked.push(text.charAt(i));
        }
    }
    return checked.join('');
};

Pages.prototype.setMode = function(mode, remember) {
    this.mode = mode;
};

Pages.prototype.setFileData = function(data) {
    data = this.validateFileData(data);
    graph.currentPage = null;
    this.fileNode = null;
    graph.pages = null;

    var node = (data != null && data.length > 0) ? mxUtils.parseXml(data).documentElement : null;

    var tmp = (node != null) ? Pages.prototype.extractGraphModel(node, true) : null;

    if (tmp != null) {
        node = tmp;
    }
    if (node != null && node.nodeName == 'mxfile') {
        var nodes = node.getElementsByTagName('diagram');
        if (urlParams['graph.pages'] != '0' || nodes.length > 1 ||
            (nodes.length == 1 && nodes[0].hasAttribute('name'))) {
            var selectedPage = null;
            this.fileNode = node;
            graph.pages = [];

            for (var i = 0; i < nodes.length; i++) {
                if (nodes[i].getAttribute('id') == null) {
                    nodes[i].setAttribute('id', i);
                }

                var page = new DiagramPage(nodes[i]);

                if (page.getName() == null) {
                    page.setName("Page-" + (i + 1));
                }

                graph.pages.push(page);

                if (urlParams['page-id'] != null && page.getId() == urlParams['page-id']) {
                    selectedPage = page;
                }
            }

            graph.currentPage = (selectedPage != null) ? selectedPage : graph.pages[0];
            node = graph.currentPage.node;
        }
    }

    if (graph.currentPage != null) {
        graph.currentPage.root = graph.model.root;
    }
}

Pages.prototype.validateFileData = function(data) {
    if (data != null && data.length > 0) {
        var index = data.indexOf('<meta charset="utf-8">');

        if (index >= 0) {
            var replaceString = '<meta charset="utf-8"/>';
            var replaceStrLen = replaceString.length;
            data = data.slice(0, index) + replaceString + data.slice(index + replaceStrLen - 1, data.length);
        }

        data = this.zapGremlins(data);
    }

    return data;
}

Pages.prototype.importXml = function(xml, dx, dy, bool) {
    graph.model.beginUpdate();
    try {
        for (var i = graph.pages.length; i >= 0; i--) {
            graph.pages.pop(graph.pages[i]);
        }
        dx = dx != null ? dx : 0;
        dy = dy != null ? dy : 0;

        var pages = [];
        var cells = [];

        if (xml != null && xml.length > 0) {
            var doc = mxUtils.parseXml(xml);
            var node = this.extractGraphModel(doc.documentElement, graph.pages != null);
            if (node != null && node.nodeName == 'mxfile' && graph.pages != null) {
                var diagrams = node.getElementsByTagName('diagram');

                for (var i = 0; i < diagrams.length; i++) {

                    // node = this.parseDiagramNode(diagrams[i]);

                    var oldId = diagrams[i].getAttribute('id')
                    diagrams[i].removeAttribute('id');

                    var page = ChangePage.prototype.updatePageRoot(new DiagramPage(diagrams[i]));

                    if (page.getName() == null) {
                        page.setName(oldId);
                    }

                    graph.model.execute(new ChangePage(this, page, page, i, true));
                    pages.push(page);
                    this.selectPage(page);
                }
            }
        }
    } finally {
        graph.model.endUpdate();
    }
}


var mxCellRendererCreateShape = mxCellRenderer.prototype.createShape;
mxCellRenderer.prototype.createShape = function(state) {
    if (state.style != null && typeof(pako) !== 'undefined') {
        var shape = mxUtils.getValue(state.style, mxConstants.STYLE_SHAPE, null);

        if (shape != null && typeof shape === 'string' && shape.substring(0, 8) == 'stencil(') {
            try {
                var stencil = shape.substring(8, shape.length - 1);
                var doc = mxUtils.parseXml(graph.page.parseNodeXml(stencil));

                return new mxShape(new mxStencil(doc.documentElement));
            } catch (e) {

            }
        }
    }

    return mxCellRendererCreateShape.apply(this, arguments);
};


Pages.prototype.parseDiagramNode = function(diagramNode) {
    var text = mxUtils.trim(mxUtils.getTextContent(diagramNode));
    var node = null;
    if (text.length > 0) {
        var tmp = this.parseNodeXml(text);

        if (tmp != null && tmp.length > 0) {
            node = mxUtils.parseXml(tmp).documentElement;
        }
    } else {
        var temp = mxUtils.getChildNodes(diagramNode);

        if (temp.length > 0) {
            var doc = mxUtils.createXmlDocument();
            doc.appendChild(doc.importNode(temp[0], true));
            node = doc.documentElement;
        }
    }

    return node;
}

Pages.prototype.parseNodeXml = function(text) {
    var tmp = (window.atob) ? atob(text) : Base64.decode(text, true);

    var inflated = pako.inflateRaw(tmp, { to: 'string' })

    try {
        tmp = this.zapGremlins(decodeURIComponent(inflated));
    } catch (e) {
        tmp = this.zapGremlins(inflated);
    }

    return tmp;
}

var DrawioFile = function(ui, data) {
    this.ui = ui;
    this.data = data || '';
    this.shadowData = this.data;
    this.shadowPages = null;
    this.created = new Date().getTime();


    this.stats = {
        opened: 0,
        merged: 0,
        fileMerged: 0,
        fileReloaded: 0,
        conflicts: 0,
        timeouts: 0,
        saved: 0,
        closed: 0,
        destroyed: 0,
        joined: 0,
        checksumErrors: 0,
        bytesSent: 0,
        bytesReceived: 0,
        msgSent: 0,
        msgReceived: 0,
        cacheHits: 0,
        cacheMiss: 0,
        cacheFail: 0
    };
}

DrawioFile.prototype.getData = function() {
    return this.data;
};

DrawioFile.prototype.setData = function(data) {
    this.data = data;
};

var DiagramPage = function(node, id) {
    this.node = node;
    this.show = true;

    if (id != null) {
        this.node.setAttribute('id', id);
    } else if (this.getId() == null) {
        this.node.setAttribute('id', guid());
    }
};

DiagramPage.prototype.getName = function() {
    return this.node.getAttribute('name');
};

DiagramPage.prototype.setName = function(value) {
    if (value == null) {
        this.node.removeAttribute('name');
    } else {
        this.node.setAttribute('name', value);
    }
};

DiagramPage.prototype.getId = function() {
    return this.node.getAttribute('id');
};

var LocalFile = function(ui, data, title, temp) {
    DrawioFile.call(this, ui, data);

    this.title = title;
    this.mode = (temp) ? null : 'divice';
};

mxUtils.extend(LocalFile, DrawioFile);

LocalFile.prototype.open = function() {
    this.ui.setFileData(this.getData());
};

LocalFile.prototype.getMode = function() {
    return this.mode;
};

LocalFile.prototype.isEditable = function() {
    return !isChromelessView() || this.editable;
};

var ChangePage = function(ui, page, select, index, noSelect) {
    SelectPage.call(this, ui, select);
    this.relatedPage = page;
    this.index = index;
    this.previousIndex = null;
    this.noSelect = noSelect;
};

var SelectPage = function(ui, page, viewState) {
    this.ui = ui;
    this.page = page;
    this.previousPage = page;
    this.neverShown = true;

    if (this.page != null) {
        this.neverShown = this.page.viewState == null;
        this.updatePageRoot(this.page);

        if (this.viewState != null) {
            this.page.viewState = this.viewState;
            this.neverShown = false;
        }
    }
};

mxUtils.extend(SelectPage, ChangePage);

SelectPage.prototype.execute = function() {
    var prevIndex = mxUtils.indexOf(graph.pages, this.previousPage);

    if (this.page != null && prevIndex >= 0) {
        var page = graph.currentPage;

        var data = getGraphXml(true);
        if (page.node.firstChild != null) {
            page.node.removeChild(page.node.firstChild)
            page.node.appendChild(data);
        }
        page.root = graph.model.root;

        if (page.model != null) {
            page.model.rootChanged(page.root);
        }

        graph.view.clear(page.root, true);
        graph.clearSelection();

        graph.currentPage = this.previousPage;
        this.previousPage = page;
        page = graph.currentPage;

        graph.model.prefix = guid() + '-';
        graph.model.rootChanged(page.root);

        graph.gridEnabled = graph.gridEnabled;

        graph.view.validate();
        graph.blockMathRender = true;
        graph.sizeDidChange();
        graph.blockMathRender = false;

        if (this.neverShown) {
            this.neverShown = false;
        }

        graph.model.fireEvent(new mxEventObject('pageChange', 'change', this));
    }
};

ChangePage.prototype.updatePageRoot = function(page) {
    if (page.root == null) {
        var node = Pages.prototype.extractGraphModel(page.node);

        if (node != null) {
            page.graphModelNode = node;

            var codec = new mxCodec(node.ownerDocument);
            page.root = codec.decode(node).root;
        } else {
            page.root = graph.model.createRoot();
        }
    } else if (page.viewState == null) {
        if (page.graphModelNode == null) {

            if (node != null) {
                page.graphModelNode = node;
            }
        }
    }

    return page;
};

ChangePage.prototype.execute = function() {
    this.previousIndex = this.index;

    if (this.index == null) {
        var tmp = mxUtils.indexOf(graph.pages, this.relatedPage);
        graph.pages.splice(tmp, 1);
        this.index = tmp;
    } else {
        graph.pages.splice(this.index, 0, this.relatedPage);
        this.index = null;
    }

    if (!this.noSelect) {
        SelectPage.prototype.execute.apply(this, arguments);
    }
};


function guid(length) {
    var len = (length != null) ? length : 20;
    var rtn = [];

    for (var i = 0; i < len; i++) {
        rtn.push(GUID_ALPHABET.charAt(Math.floor(Math.random() * GUID_ALPHABET.length)));
    }

    return rtn.join('');
};

function getGraphXml(ignoreSelection) {
    ignoreSelection = (ignoreSelection != null) ? ignoreSelection : true;
    var node = null;

    if (ignoreSelection) {
        var enc = new mxCodec(mxUtils.createXmlDocument());
        node = enc.encode(graph.getModel());
    } else {
        node = graph.encodeCells(mxUtils.sortCells(graph.model.getTopmostCells(
            graph.getSelectionCells())));
    }

    if (graph.view.translate.x != 0 || graph.view.translate.y != 0) {
        node.setAttribute('dx', Math.round(graph.view.translate.x * 100) / 100);
        node.setAttribute('dy', Math.round(graph.view.translate.y * 100) / 100);
    }

    node.setAttribute('grid', (graph.isGridEnabled()) ? '1' : '0');
    node.setAttribute('gridSize', graph.gridSize);
    node.setAttribute('guides', (graph.graphHandler.guidesEnabled) ? '1' : '0');
    node.setAttribute('tooltips', (graph.tooltipHandler.isEnabled()) ? '1' : '0');
    node.setAttribute('connect', (graph.connectionHandler.isEnabled()) ? '1' : '0');
    node.setAttribute('arrows', (graph.connectionArrowsEnabled) ? '1' : '0');
    node.setAttribute('fold', (graph.foldingEnabled) ? '1' : '0');
    node.setAttribute('page', (graph.pageVisible) ? '1' : '0');
    node.setAttribute('pageScale', graph.pageScale);
    node.setAttribute('pageWidth', graph.pageFormat.width);
    node.setAttribute('pageHeight', graph.pageFormat.height);

    if (graph.background != null) {
        node.setAttribute('background', graph.background);
    }

    if (graph.backgroundColor != null) {
        node.setAttribute('backgroundColor', graph.backgroundColor);
    }

    if (graph.backgroundImage != null) {
        node.setAttribute('backgroundImage', graph.backgroundImage);
    }

    return node;
};


Pages.prototype.showOrNotPage = function() {
    if (this.pageArray.indexOf(graph.currentPage) == -1) {
        this.pageArray.unshift(graph.currentPage);
    }
    if (this.pageArray.length > this.pageNum) {
        this.pageArray.pop();
    }

    for (var i = 0; i < graph.pages.length; i++) {
        graph.pages[i].show = false;
    }

    for (var j = 0; j < this.pageArray.length; j++) {
        if (graph.pages.indexOf(this.pageArray[j]) > -1) {
            graph.pages[graph.pages.indexOf(this.pageArray[j])].show = true;
        }
    }
}

Pages.prototype.updataCurrentFile = function() {
    try {
        for (var i = 0; i < graph.pages.length; i++) {
            if (graph.currentPage == graph.pages[i]) {
                var enc = new mxCodec(mxUtils.createXmlDocument());
                node = enc.encode(graph.getModel());

                if (graph.view.translate.x != 0 || graph.view.translate.y != 0) {
                    node.setAttribute('dx', Math.round(graph.view.translate.x * 100) / 100);
                    node.setAttribute('dy', Math.round(graph.view.translate.y * 100) / 100);
                }

                node.setAttribute('grid', (graph.isGridEnabled()) ? '1' : '0');
                node.setAttribute('gridSize', graph.gridSize);
                node.setAttribute('guides', (graph.graphHandler.guidesEnabled) ? '1' : '0');
                node.setAttribute('tooltips', (graph.tooltipHandler.isEnabled()) ? '1' : '0');
                node.setAttribute('connect', (graph.connectionHandler.isEnabled()) ? '1' : '0');
                node.setAttribute('arrows', (graph.connectionArrowsEnabled) ? '1' : '0');
                node.setAttribute('fold', (graph.foldingEnabled) ? '1' : '0');
                node.setAttribute('page', (graph.pageVisible) ? '1' : '0');
                node.setAttribute('pageScale', graph.pageScale);
                node.setAttribute('pageWidth', graph.view.getBackgroundPageBounds().width);
                node.setAttribute('pageHeight', graph.view.getBackgroundPageBounds().height);

                if (graph.background != null) {
                    node.setAttribute('background', graph.background);
                }

                if (graph.currentStyle != null && graph.currentStyle != 'default-style2') {
                    node.setAttribute('style', graph.currentStyle);
                }

                if (graph.backgroundColor != null) {
                    node.setAttribute('backgroundColor', graph.backgroundColor);
                }

                if (graph.backgroundImage != null) {
                    node.setAttribute('backgroundImage', graph.backgroundImage.src);
                }

                if (graph.pages[i].node.firstChild) {
                    graph.pages[i].node.removeChild(graph.pages[i].node.firstChild);
                }
                graph.pages[i].node.appendChild(node);
            }
        }

        if (this.getCurrentFile() != null) {
            var ele = mxUtils.parseXml(this.getCurrentFile().data).documentElement;
            ele.innerHTML = '';

            var appendPage = function(pageNode) {
                ele.appendChild(pageNode);
            }

            for (var i = 0; i < graph.pages.length; i++) {
                appendPage(graph.pages[i].node);
            }

            var data = this.createFileData(ele);
            data = data.replace(/&amp;/g, '&');

            var file = this.getCurrentFile();
            file.data = data;
            this.setCurrentFile(file);
        }
    } catch (e) {
        console.log(e);
    }
}


Pages.prototype.compress = function(data, deflate) {
    if (data == null || data.length == 0 || typeof(pako) === 'undefined') {
        return data;
    } else {
        var tmp = (deflate) ? pako.deflate(encodeURIComponent(data), { to: 'string' }) :
            pako.deflateRaw(encodeURIComponent(data), { to: 'string' });

        return (window.btoa) ? btoa(tmp) : Base64.encode(tmp, true);
    }
};