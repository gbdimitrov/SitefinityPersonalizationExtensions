<div>
    <input id="isMobileDevice" type="checkbox">
    <label for="isMobileDevice">{$MobileDevicePersonalizationResources, IsMobileDevice$}</label>
</div>

<script type="text/javascript">

    function CriterionEditor() {
    }

    CriterionEditor.prototype = {
        getCriterionTitle: function () {
            return "{$MobileDevicePersonalizationResources, MobileDevice$}";
        },

        getCriterionDisplayValue: function () {
            return $("#isMobileDevice").is(':checked') ?
                "{$MobileDevicePersonalizationResources, IsMobileDevice$}" :
                "{$MobileDevicePersonalizationResources, IsNotMobileDevice$}";

        },

        getCriterionValue: function () {
            return $("#isMobileDevice").is(':checked');
        },

        setCriterionValue: function (val) {
            $("#isMobileDevice").prop("checked", val);
        },

        isValid: function () {
            return true;
        }
    };
</script>