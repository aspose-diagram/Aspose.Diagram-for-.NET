
mxStencilRegistry.packages = [];
mxStencilRegistry.dynamicLoading = true;
mxStencilRegistry.allowEval = true;

mxStencilRegistry.getStencil = function (name) {
    if (typeof mxVertexHandler !== 'undefined') { }

    var result = mxStencilRegistry.stencils[name];

    return result;
};

// Parses the given stencil set
mxStencilRegistry.parseStencilSet = function (root, postStencilLoad, install) {
    if (root.nodeName == 'stencils') {
        var shapes = root.firstChild;

        while (shapes != null) {
            if (shapes.nodeName == 'shapes') {
                mxStencilRegistry.parseStencilSet(shapes, postStencilLoad, install);
            }

            shapes = shapes.nextSibling;
        }
    }
    else {
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

                        var value = shape.getAttribute('Text');

                        postStencilLoad(packageName, stencilName, name, w, h, value);
                    }
                }
            }

            shape = shape.nextSibling;
        }
    }
};
