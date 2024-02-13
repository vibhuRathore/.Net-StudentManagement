
function UpdateStudent(Id, Name, Age, Subject)
{
        debugger   
        $("#StdName").val(Name);
        $("#StdAge").val(Age);
        $("#StudentSubject").val(Subject);
        $("#StdId").val(Id);
    const textXChange = document.querySelector("#addHeading");
    textXChange.textContent = "Update Student";
    const btnChange = document.querySelector("#AddButton");
    btnChange.textContent = "Update";
}
    function refreshList(Id)
    {    
        debugger
        $.ajax({
            url: '/Student/Remove',
            data: { Id: Id },
            type: "get",
            datatype: "html",
            success: function (data) {
                debugger
                $(".listpartial").html(data);
            },  
        });
}

function resetForm() {
    $('#AddForm')[0].reset();
}
function refreshAdd()
{
    debugger
        var recievedstudentData = {
            StudentName: $("#StdName").val(),
            StudentAge: $("#StdAge").val(),
            StudentSubject: $("#StudentSubject").val(),
            StudentId: $("#StdId").val()
        };
        debugger
        $.ajax({
            url:  '/Student/AddStudent',
            type: "post",
            datatype:"html",
            data:({ recievedstudentData: recievedstudentData }),
            success: function(data) {
                debugger
                if (!$.fn.DataTable.isDataTable('#displayTable')) {
                    debugger
                    bindDatatable();
                } else {
                    debugger
                    clearTable();
                    bindDatatable();
                }
                resetForm();
            },
            error: function(data) {
                debugger
                console.log(data)
            }
        });
}


$(document).ready(function () {
    debugger
    bindDatatable();
});

function clearTable() {
    debugger
    var rTable = $("#displayTable").dataTable();
    rTable.fnClearTable();
    rTable.fnDestroy();
}

function bindDatatable() {
    debugger;
    jQuery.noConflict()
    $('#displayTable').DataTable({
        "ajax":
        {
            "url": "/Student/ListOfStudents",
            "type": "get",
            "datatype": "JSON",
            "dataSrc": function (data) {
                return data;
            },
        },
        "aoColumns": [
            { "data": "StudentName" },
            { "data": "StudentAge" },
            { "data": "StudentSubject" },
            {
                "mRender": function (data, type, row) {
                    return '<button class="btn btn-dark Update-btn" id="actionBtns" onclick="UpdateStudent(' + row.StudentId + ', \'' + row.StudentName + '\' , \'' + row.StudentAge + ' \', \'' + row.StudentSubject + '\');">' + "Update" + '</button>' + ' ' + '<button class="btn btn-dark Remove-btn" id="actionBtns" onclick="refreshList(' + row.StudentId + ');">' + "Remove" + '</button>'
                }
            }
        ]
    });
}
