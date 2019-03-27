$(document).ready(function () {
     /* Add new task to a user*/
    $("#add-task-user-button").on("click", function (e) {
        console.log('AHAHAHA')
        e.preventDefault()
        //get input data
        console.log("UserId: " + $("#task-user-add #userId").val())
        console.log("task: " + $("#task-user-add #taskId").val())
        console.log("begin Date: " + $("#task-user-add #beginDate").val())
        console.log("end Date: " + $("#endDate").val())
        console.log("state: " + $("#task-user-add #state").val())
        var userId = $("#userId").val()
        var taskId = $("#taskId").val()
        var beginDate = $("#beginDate").val()
        var endDate = $("#endDate").val()
        var state = $("#state").val()
        //send data to api to store new vaucher
        console.log('a')
        add(taskId, userId, beginDate, endDate, state)
    });
});

function add(taskId, userId, beginDate, endDate, state){
    // use tha api to store a new purchase for the current customer and return a partial view without reload the page
    console.log('b')
    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "POST",
        url: '/api/UserTasksApi',
        data: JSON.stringify({ TaskId: taskId, UserId: userId, BeginTask: beginDate, EndTask: endDate, State: state}),
    })
        .done(function (data) {
            console.log(data)
            getTask(data);
        })
        .fail(function () {
            alert("La tâche n'a pas été ajoutée");
        });
};

function update() {

}

function getTask(data) {
    let formatedBeginDate;
    console.log(data.beginTask);
    formatedBeginDate = data.beginTask.getFullYear() + "/" + (data.beginTask.getMonth() + 1) + "-" + data.beginTask.getDate() + " " + data.beginTask.getHours() + ":" + data.beginTask.getMinutes() + ":" + cdata.beginTask.getSeconds();
   // let formatted_beginDate =  + "-" + current_datetime.getDate() + " " + current_datetime.getHours() + ":" + current_datetime.getMinutes() + ":" + current_datetime.getSeconds()
    //let formatted_endDate = 
    console.log("--------- IN FUNCTION GETTASK ------------")
    console.log(data)
    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "GET",
        url: '/api/TasksApi/' + data.taskId,
    })
        .done(function (dataCallBack) {
            console.log(dataCallBack);
            $("#show-usertasks-todo").append(
                "<tr> \
                    <td> "+ dataCallBack.description + "</td ><td>" + data.beginTask + "</td><td>" + data.endTask + "</td><td>" + data.state + "</td>"
            );
        })
        .fail(function () {
            alert("La tâche n'existe pas")
        });
}