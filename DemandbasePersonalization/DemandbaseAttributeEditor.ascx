
<div class="sfHorizontalAlign sfShortField100">
    <label class="sfTxtLbl" for="fieldName">{$DemandbasePersonalizationResources, DemandbaseAttribute$}</label>
    <input type="text" id="fieldName" class="sfTxt" />
</div>
<div class="sfHorizontalAlign sfNoLbl">
    <select id="comparisonRule">
        <option value="equals">{$DemandbasePersonalizationResources, Equals$}</option>
        <option value="contains">{$DemandbasePersonalizationResources, Contains$}</option>
        <option value="startswith">{$DemandbasePersonalizationResources, EndsWith$}</option>
        <option value="endswith">{$DemandbasePersonalizationResources, StartsWith$}</option>
    </select>
</div>
<div class="sfHorizontalAlign sfNoLbl sfShortField100">
    <input type="text" id="fieldValue" class="sfTxt" />
</div>
<script type="text/javascript">
    function CriterionEditor() {
        this.comparisonRule = document.getElementById("comparisonRule");
    }

    CriterionEditor.prototype = {

        getCriterionTitle: function () {
            return "{$DemandbasePersonalizationResources, DemandbaseAttribute$}"
        },

        getCriterionDisplayValue: function () {
            var fieldName = $("#fieldName").val();
            var fieldValue = $("#fieldValue").val();
            var rule = $("#comparisonRule option:selected").text();

            return fieldName + " " + rule + " " + fieldValue;
        },

        getCriterionValue: function () {
            var fieldName = $("#fieldName").val();
            var fieldValue = $("#fieldValue").val();
            var rule = $("#comparisonRule").val();

            return { "FieldName": fieldName, "FieldValue": fieldValue, "ComparisonRule": rule };
        },

        setCriterionValue: function (val) {
            $("#comparisonRule").val(val.ComparisonRule);
            $("#fieldName").val(val.FieldName);
            $("#fieldValue").val(val.FieldValue);
        },

        errorMessage: "",

        isValid: function () {
            return true;
        }
    };
</script>