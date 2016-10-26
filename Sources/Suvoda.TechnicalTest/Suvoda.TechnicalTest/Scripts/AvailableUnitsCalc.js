(function ($) {
    if (!$.Suvoda) {
        $.Suvoda = {};
    };
    $.Suvoda.availableUnitsCalc = function () {
        var base = this;

        var $depotsList = $(".js-depots-list");

        base.ajaxSuccess = function () {
            $(".js-calc").click(function () {
                var $this = $(this);
                var $row = $this[0].parentElement.parentElement;
                var url = $(this).data("url");
                var unitsNeeded = $(".js-units-needed", $row)[0].value;
                var drugType = $(".js-type-id", $row)[0].value;
                var depotId = $depotsList[0].value;
                var validationMsgField = $(".js-invalid-units-count", $row)[0];

                if (parseInt(unitsNeeded)) {
                    validationMsgField.innerHTML = "";
                    $.post(url, { count: unitsNeeded, type: drugType, depot: depotId }, function (data) {
                        var result = data;
                        var label = $(".js-units-available", $row)[0];
                        label.textContent = result !== 0 ? result : "No Drug Unit was found";
                    });
                } else {
                    validationMsgField.innerHTML = "Invalid number";
                }
            });
        }

        var submitForm = function(form) {
            $(form).submit();
        }

        base.init = function () {
            submitForm("form");
            $depotsList.change(function () {
                submitForm("form");
            });
        };

    };

    $.extend($.Suvoda, {
        AvailableUnitsCalc: $.Suvoda.availableUnitsCalc()
    });
})(jQuery);