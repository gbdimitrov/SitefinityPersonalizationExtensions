<div>
    <input id="isMobileDevice" type="checkbox">
    <label for="isMobileDevice">{$MobileDevicePersonalizationResources, IsMobileDevice$}</label>
</div>

<script type="text/javascript">

    function MobileDeviceCriterion() {
    }

    MobileDeviceCriterion.prototype = {
        getTestParameters: function () {
            return [
                { key: "isMobileDevice", value: $("#isMobileDevice").is(':checked') }
            ];
        },

        clear: function () {
            $("#isMobileDevice").prop("checked", false);
        }
    };

    $(document).ready(function () {
        PersonalizationConsole.instance.criteria.push(new MobileDeviceCriterion());
    });
</script>