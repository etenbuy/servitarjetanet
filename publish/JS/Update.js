Sys.Application.add_load(ApplicationLoadHandler);
function ApplicationLoadHandler() {
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
}

function beginRequest(sender, args) {

    //Recuperamos el identificador del updatePanel que ha lanzado la petición asincrona
    var id = sender._postBackSettings.panelID.split('|')[0];
    while (id.indexOf('$') != -1)
        id = id.replace('$', '_');
    if (!sender.get_isInAsyncPostBack()) {

        if ($("#" + id).length & $("#progress").length) {
            $("#" + id).fadeTo("slow", 0.7);
            //Calculamos la posición para centrar el progress
            var x = $("#" + id).position().left + ($("#" + id).children(0).width() / 2) - ($("#progress").children(0).width() / 2);
            var y = $("#" + id).position().top + ($("#" + id).children(0).height() / 2) - ($("#progress").children(0).height() / 2);

            Sys.UI.DomElement.setLocation($("#progress")[0], Math.round(x), Math.round(y));
            //Mostramos el progress
            $("#progress").show("slow");
        }
        //DesHabilita los botones
        $('input[@type=submit]').attr('disabled', true);
    }
}

function endRequest(sender, args) {

    if (!sender.get_isInAsyncPostBack()) {
        var id = sender._postBackSettings.panelID.split('|')[0];
        while (id.indexOf('$') != -1)
            id = id.replace('$', '_');
        if (!sender.get_isInAsyncPostBack()) {
            $("#" + id).fadeTo("fast", 100);
            $("#progress").hide("fast");
        }
        $('input[@type=submit]').attr('disabled', false);
    }
}