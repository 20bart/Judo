$(document).ready(function () {
    //Dropdownlist Selectedchange event
    function showHideLandNaam() {
        
        var waarde = $("#Landen").val();
        
        if (waarde === "-99") {
            $("#LandNaam").removeClass("hidden");
            $("#textBoxLandNaam").val("");
            $("#LabelLandId").addClass("invisible");
        }
        else {
            $("#LandNaam").addClass("hidden");
            var landnaam = $("#Landen option:selected").text();
            $("#textBoxLandNaam").val(landnaam);
            $("#LabelLandId").removeClass("invisible");
        }
    }

    if ($("#Landen").length) {
        showHideLandNaam();
        $("#Landen").change(showHideLandNaam);
    }
    //END Dropdownlist Selectedchange even

    //Hide message with delay
    if ($(".temp-msg").length) {
        $(".temp-msg").delay(3000).hide(1000);
    }

    if ($(".checkboxen").length) {
        //onclick
        $(".checkboxen").children(".checkbokske").click(function () {
            ShowHideTimeTable($(this));
        });
        //on doc ready
        $(".checkboxen").each(function() {
            $(this).children(".checkbokske").each(function() {
                ShowHideTimeTable($(this));
            });
        });
    }

    if ($(".timepicker").length) {
        var culture = $("#culture").text();
        $(".timepicker").datetimepicker({
            format: "LT",
            locale: culture
        });
    }
});

function ShowHideTimeTable(checkbox) {
    var parent = checkbox.parent();
    if (checkbox.is(":checked")) {
        parent.children(".table").removeClass("hidden");
    } else {
        parent.children(".table").addClass("hidden");
    }
}