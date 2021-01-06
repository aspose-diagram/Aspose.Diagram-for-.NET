$(document).ready(function () {
    $('#tool_zoom').find("a").each(function () {
        $(this).click(function () {
            $("#zoom_val").text($(this).text());
            graph.actions.get('scale').funct(parseFloat($(this).text()))
        })
    })

    $('#tool_font_family').find("a").each(function () {
        $(this).click(function () {
            $("#font_family_val").text($(this).text());
            graph.actions.get('font').funct($(this).text());
        })
    })

    $('#tool_font_size').find("a").each(function () {
        $(this).click(function () {
            $("#font_size_val").text($(this).text());
            graph.actions.get('fontsize').funct($(this).text().substring(0, $(this).text().length - 2));
        })
    })

    $("#text_color_picker").bigColorpicker(function (target, val) {
        $("#text_color_picker_val").css("background-color", val);
        graph.actions.get('fontColor').funct(val);
    }, "l");

    $("#fill_color_picker").bigColorpicker(function (target, val) {
        $("#fill_color_picker_val").css("background-color", val);
        graph.actions.get('fillColor').funct(val);
    }, "l");

    $("#pen_color_picker").bigColorpicker(function (target, val) {
        $("#pen_color_picker_val").css("background-color", val);
        graph.actions.get('strokeColor').funct(val);
    }, "l");

    $(".text-style").click(function () {
        var target = this;
        if ($(target).hasClass("text-style-selected")) {
            $(target).removeClass("text-style-selected");
        } else {
            $(target).addClass("text-style-selected");
        }
    })

    $(".text-x-position").click(function () {
        var target = this;
        $(".text-x-position").removeClass("text-style-selected");
        $(target).addClass("text-style-selected");
    })

    $(".text-y-position").click(function () {
        var target = this;
        $(".text-y-position").removeClass("text-style-selected");
        $(target).addClass("text-style-selected");
    })

    $(".shape-z-index").click(function () {
        var target = this;
        // if ($(target).hasClass("text-style-selected")) {
        //     $(target).removeClass("text-style-selected");
        // } else {
        //     $(target).addClass("text-style-selected");
        // }
    })
    $(".back-left").click(function () {
        graph.actions.get('undo').funct();
    })
    $(".back-right").click(function () {
        graph.actions.get('redo').funct();
    })
    $('#toFront').click(function () {
        graph.actions.get('tofront').funct();
    })
    $('#toBack').click(function () {
        graph.actions.get('toback').funct();
    })
    $('#delete').click(function () {
        graph.actions.get('delete').funct();
    })
    $('#align_Left').click(function () {
        graph.actions.get('alignleft').funct();
    })
    $('#align_center').click(function () {
        graph.actions.get('aligncenter').funct();
    })
    $('#align_right').click(function () {
        graph.actions.get('alignright').funct();
    })
    $('#align_top').click(function () {
        graph.actions.get('aligntop').funct();
    })
    $('#align_middle').click(function () {
        graph.actions.get('alignmiddle').funct();
    })
    $('#align_bottom').click(function () {
        graph.actions.get('alignbottom').funct();
    })
    $('#text_bold').click(function () {
        graph.actions.get('bold').funct();
    })
    $('#text_italic').click(function () {
        graph.actions.get('italic').funct();
    })
    $('#text_underline').click(function () {
        graph.actions.get('underline').funct();
    })
    $("#brush").click(function () {
        if (graph.actions.CellStyle != null) {
            graph.actions.get('setAsDefaultStyle').funct();
        } else {
            graph.actions.get('getAsDefaultStyle').funct();
        }
    })
    $("#Open_file").click(function () {
        graph.actions.get('importVsdx').funct();
    })
    $(".download_file").click(function () {
        graph.actions.get('exportVsdx').funct($(this).attr("data-format"));
    })
    $(".nav-left span").click(function () {
        graph.actions.get('OutLine').funct();
    })

    $('#Solid').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_DASHED, mxConstants.STYLE_DASH_PATTERN], [null, null])
    })
    $('#Dashed1').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_DASHED, mxConstants.STYLE_DASH_PATTERN], ['1', null])
    })
    $('#Dashed2').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_DASHED, mxConstants.STYLE_DASH_PATTERN], ['1', '1 2'])
    })
    $('#Dashed3').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_DASHED, mxConstants.STYLE_DASH_PATTERN], ['1', '1 4'])
    })

    $('#Thick1').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_STROKEWIDTH], ['1'])
    })
    $('#Thick2').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_STROKEWIDTH], ['2'])
    })
    $('#Thick3').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_STROKEWIDTH], ['3'])
    })
    $('#Thick4').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_STROKEWIDTH], ['4'])
    })
    $('#Thick5').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_STROKEWIDTH], ['5'])
    })

    $('#Straight').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], [null, null, null])
    })
    $('#Orthogonal').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], ['orthogonalEdgeStyle', null, null])
    })
    $('#Simple').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_ELBOW, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], ['elbowEdgeStyle', null, null, null])
    })
    $('#Simple1').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_ELBOW, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], ['elbowEdgeStyle', 'vertical', null, null])
    })
    $('#Curved').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], ['orthogonalEdgeStyle', '1', null])
    })
    $('#EntityRelation').click(function () {
        graph.actions.get('EdgeStyleChange').funct([mxConstants.STYLE_EDGE, mxConstants.STYLE_CURVED, mxConstants.STYLE_NOEDGESTYLE], ['entityRelationEdgeStyle', null, null])
    })

    $('#Link').click(function () {
        graph.actions.get('InsertLink').funct();
    })
    $('#Image').click(function () {
        graph.actions.get('InsertImage').funct();
    })
})