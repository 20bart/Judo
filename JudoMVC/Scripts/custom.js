$(document).ready(function () {
    //Dropdownlist Selectedchange event
    
    $("#Landen").change(showHideLandNaam);

    function showHideLandNaam() {
        
        var waarde = $('#Landen').val();
        
        if (waarde == -99) {
            $("#LandNaam").removeClass("hidden");
            $("#textBoxLandNaam").val("")
            $("#LabelLandId").addClass("invisible")
        }
        else {
            $("#LandNaam").addClass("hidden");
            var landnaam = $("#Landen option:selected").text();
            $("#textBoxLandNaam").val(landnaam);
            $("#LabelLandId").removeClass("invisible");
        }
    }

    $('#reg_next').click(function () {
        $('#club').addClass("hidden");
        $('#verantwoordelijke').removeClass("hidden");
    });
    $('#reg_prev').click(function () {
        $('#club').removeClass("hidden");
        $('#verantwoordelijke').addClass("hidden");
    });

    //END Dropdownlist Selectedchange even



});