/*
 * Description : Save or get data via Ajax request through this UserTasksApiController
 * 
 * Author : Julien Richoz / SI-T2a / CPNV-ES
 * Date : 31.03.2019
 * */

$(document).ready(function () {
     /* Add new task to a user*/
    $("#add-task-user-button").on("click", function (e) {
        e.preventDefault()
        //get input data
        var userId = $("#userId").val()
        var taskId = $("#taskId").val()
        var beginDate = $("#beginDate").val()
        var endDate = $("#endDate").val()
        var state = 0 // We set the state of a task to 0 per default.

        add(taskId, userId, beginDate, endDate, state, role)
    });
});

// Add a new user task
function add(taskId, userId, beginDate, endDate, state, role){
    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "POST",
        url: '/api/UserTasksApi',
        data: JSON.stringify({ TaskId: taskId, UserId: userId, BeginTask: beginDate, EndTask: endDate, State: state}),
    })
        .done(function (data) {
            getTask(data);
        })
        .fail(function () {
            alert("La tâche n'a pas été ajoutée");
        });
};

function update() {
 // CHECKHERE
}

// Return tasks data so we can comeback to the last page
function getTask(data) {
    data.beginTask = formatDate(data.beginTask)
    data.endTask = formatDate(data.endTask)

    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "GET",
        url: '/api/TasksApi/' + data.taskId,
    })
        .done(function (dataCallBack) {
            $("#show-usertasks-todo").append(
                "<tr> \
                    <td> "+ dataCallBack.description + "</td ><td>" + data.beginTask + "</td><td>" + data.endTask + "</td><td><a class='btn beginButton' href==/Tasks/Edit/" + data.id+"</a>Pas commencé</td><td><a href=/Tasks/Edit/" + data.id + ">Modifier</a> | <a href=/UserTasks/Delete/" + data.id + ">Supprimer</a></td></tr>"
            );
        })
        .fail(function () {
            alert("La tâche n'existe pas")
        });
}


// Format date to 'YYYY.MM.DD'
function formatDate(date) {
    // https://stackoverflow.com/questions/3605214/javascript-add-leading-zeroes-to-date
    let myDate = new Date(date) //Convert the date(often string type) to a datetype

    // Convert to the correct format
    let myDateString = ('0' + myDate.getDate()).slice(-2) + '.'
        + ('0' + (myDate.getMonth() + 1)).slice(-2) + '.'
        + myDate.getFullYear();

    return myDateString
}