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
        console.log(taskId)
        var beginDate = $("#beginDate").val()
        var endDate = $("#endDate").val()
        var state = 0 // We set the state of a task to 0 per default.

        add(taskId, userId, beginDate, endDate, state)
    });

    // On form add task to a user (/AspNetUsers/Details/idUser)
    $("#task-user-add").on("change paste keyup click", function () {
        var dateBegin = $("#beginDate").val()
        var dateEnd = $("#endDate").val()

        // Check if the end date is greater than the begin date
        if (new Date(dateEnd).getTime() < new Date(dateBegin).getTime()) {
            $("#add-task-user-button").attr("disabled")
            $("#add-task-user-button").addClass("disabled")
            $("#errorMessage").text("La date de début doit être inférieure ou égale à la date de fin.")
        }
        else {
            $("#errorMessage").text("")
            // Activate/desactive submit button if form is valid or not
            if ($(this).valid()) {
                $("#add-task-user-button").removeAttr("disabled").removeClass("disabled")
            }
            else {
                $("#add-task-user-button").attr("disabled")
                $("#add-task-user-button").addClass("disabled")
            }
        }
    });

  
});

// Add a new user task
function add(taskId, userId, beginDate, endDate, state){
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
            alert("La tâche n'a pas été ajoutée. merci de contacter le support.");
        });
};

// Add in a Logbooks when a new task is created
function addLog() {
    /* Add new task to a user*/
    $("edit-user-task-submit").on("click", function (e) {
        console.log("hi")
        e.preventDefault()
        //get input data
        var userId = $("#userId").val()
       // var taskId = $("#taskId").val()
        console.log(taskId)
        var dateNow = new Date()
        var description = "test"

        // Add with api Logbookss controller
        $.ajax({
            accepts: "application/json",
            contentType: "application/json",
            type: "POST",
            url: '/api/LogbookssApi',
            data: JSON.stringify({ AspNetUserId: userId, Moment: dateNow, Description: description}),
        })
            .done(function (data) {
                //getTask(data);
                alert("Log ajouté");
            })
            .fail(function () {
                alert("Log non ajouté");
            });
    });
    
}
function update() {
 // CHECKHERE
}

// Return tasks data so we have the information on the new task added
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
                    <td> "+ dataCallBack.description + "</td ><td>" + data.beginTask + "</td><td>" + data.endTask + "</td><td><a href=/UserTasks/Edit/" + data.id +"  class='btn stateButton beginButton'>Pas commencé</a></td><td><a href=/UserTasks/Edit/" + data.id + ">Modifier</a> | <a href=/UserTasks/Delete/" + data.id + ">Supprimer</a></td></tr>"
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