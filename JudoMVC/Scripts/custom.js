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
        $("#Landen").change(showHideLandNaam);
    }
    //END Dropdownlist Selectedchange even

    //Hide message after 5 sec
    if ($(".temp-msg").length) {
        $(".temp-msg").hide(5000);
    }
});