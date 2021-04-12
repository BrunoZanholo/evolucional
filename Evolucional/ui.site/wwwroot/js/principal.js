$(function () {

    $("#btn-1").click(function () {
        
        $("#lbl-btn-1").html("");
        $("#lbl-btn-2").html("");

        $("#btn-2").prop("disabled", true);
        $("#a-download").hide();

        $.ajax({
            method: "POST",
            url: "/principal/botao/1",            
            })
            .fail(function () {

                console.log(".fail");
            })
            .done(function (data) {

                $("#lbl-btn-1").html(data.mensagem);
            })
            .always(function () {

                $("#btn-2").prop("disabled", false);
            });        
    });

    $("#btn-2").click(function () {

        $("#lbl-btn-2").html("");
        $("#a-download").hide();

        $.ajax({
            method: "POST",
            url: "/principal/botao/2",
        })
            .fail(function () {

                console.log(".fail");
            })
            .done(function (data) {

                $("#lbl-btn-2").html(data.mensagem);
                var href = $("#a-download").attr("href");
                $("#a-download").attr("href", "/principal/botao/2/dowload/" + data.relatorio);
                $("#a-download").show();
            })
            .always(function () {
                
            });
    });
});