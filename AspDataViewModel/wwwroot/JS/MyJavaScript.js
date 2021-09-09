
function formReset() {
    /*document.getElementById("myForm").reset();*/
    document.getElementById("name").value = "";
    document.getElementById("phoneNumber").value = "";
    document.getElementById("city").value = "";

}

function ShowPerson() {

    $.ajax({
        type: "GET",
        url: "People",
        success: function (output) {
            console.log(output);
            document.getElementById("result").innerHTML = output;

        }
    })
}
function Delete() {
    var Id = document.getElementById("personId").value;
    $.ajax({
        type: "GET",
        url: `Delete/${Id}`,
        success: function (output) {
            document.getElementById("result").innerHTML = output;
        }
    })
}

function PerDetail() {
    var id = document.getElementById("personId").value
    $.ajax({
        type: "GET",
        url: `PerDetail/${id}`,
        success: function (output) {
            document.getElementById("result").innerHTML = output;
        }
    })


}





