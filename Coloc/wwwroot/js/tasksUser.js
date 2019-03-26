$(document).ready(function () {
     /* Add new task to a user*/
    $("#add-task-user-button").on("click", function (e) {
        console.log('AHAHAHA');
        e.preventDefault();
        //get input data
        console.log("UserId: "+$("#task-user-add #userId").val());
        var task = $("#task-user-add #task").val();
        var beginDate = $("#task-user-add #beginDate").val();
        var endDate = $("#task-todo-add #endDate").val();
        var state = $("#task-todo-add #state").val();
        //send data to api to store new vaucher
       // add(task, beginDate, endDate, state);
    });
});

function add(task, beginDate, endDate, state){
    let current_datetime = new Date()
    let formatted_date = current_datetime.getFullYear() + "/" + (current_datetime.getMonth() + 1) + "-" + current_datetime.getDate() + " " + current_datetime.getHours() + ":" + current_datetime.getMinutes() + ":" + current_datetime.getSeconds()

    // use tha api to store a new purchase for the current customer and return a partial view without reload the page
    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "POST",
        url: '/api/UserTasksApi',
        data: JSON.stringify({ Title: title, Description: description, TodoId: todoId}),
    })
        .done(function (data) {
            console.log(data);
            $("#show-task-todo").append(
                "<tr> \
                    <td> "+ title + "</td ><td>" + description + "<td><a href=/Tasks/Edit/" + data.id + ">Modifier</a> | <a href=/Tasks/Details/" + data.id +">Détails</a> | <a href=/Tasks/Delete/ " + data.id + ">Supprimer</a></td>\
                </tr > "
            );

        })
        .fail(function () {
  
            alert("Le bon d'achat n'a été pas crée");
        });
};

function update() {

}