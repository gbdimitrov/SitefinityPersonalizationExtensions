<div>
    <label class="sfTxtLbl" for="demandbaseAttributeName">{$DemandbasePersonalizationResources, DemandbaseAttribute$}</label>
    <input type="text" id="demandbaseAttributeName" class="sfTxt" />
</div>
<div class="sfShortField100 sfMTop10">
    <label class="sfTxtLbl" for="demandbaseAttributeValue">{$DemandbasePersonalizationResources, Is$}</label>
    <input type="text" id="demandbaseAttributeValue" class="sfTxt" />
</div>
<script type="text/javascript">
    function DemandbaseAttributeCriterion() {
    }

    DemandbaseAttributeCriterion.prototype = {
        getTestParameters: function () {
            var demandbaseAttributeName = $("#demandbaseAttributeName").val();
            if (demandbaseAttributeName) {
                return [
                    { key: "demandbaseAttributeName", value: demandbaseAttributeName },
                    { key: "demandbaseAttributeValue", value: $("#demandbaseAttributeValue").val() }
                ];
            }
            return [];
        },

        clear: function () {
            $("#demandbaseAttributeName").val("")
            $("#demandbaseAttributeValue").val("")
        }
    };

    $(document).ready(function () {
        PersonalizationConsole.instance.criteria.push(new DemandbaseAttributeCriterion());
    });
</script>