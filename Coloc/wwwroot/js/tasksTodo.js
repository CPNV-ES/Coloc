$(document).ready(function () {
    /* Add new task to a user*/
    $("#add-task-todo-button").on("click", function (e) {
        e.preventDefault();
        //get input data
        var description = $("#task-todo-add #description").val();
        var title = $("#task-todo-add #title").val();
        var todoId = $("#task-todo-add #todoId").val();

        //send data to api
        add(title, description, todoId);
    });

    // On Add task to a todo : check form validation (/Todos/Details/TodoID)
    $("#task-todo-add").on("change paste keyup click", function(){
        // Activate/desactive submit button if form is valid or not
        if ($(this).valid()) {
            $("#add-task-todo-button").removeAttr("disabled").removeClass("disabled")
        }
        else {
            $("#add-task-todo-button").attr("disabled")
            $("#add-task-todo-button").addClass("disabled")
        }
    });

    // On create new todo : check form validation (Todos/Create)
    $("#todo-create-form").on("change paste keyup click", function () {
        // Activate/desactive submit button if form is valid or not
        if ($(this).valid()) {
            $("#todo-create-submit").removeAttr("disabled").removeClass("disabled")
        }
        else {
            $("#todo-create-submit").attr("disabled")
            $("#todo-create-submit").addClass("disabled")
        }
    });

    // On Edit new todo : check form validation (Todos/Edit/TodoId)
    $("#todo-edit-form").on("change paste keyup click", function () {
        // Activate/desactive submit button if form is valid or not
        if ($(this).valid()) {
            $("#todo-edit-submit").removeAttr("disabled").removeClass("disabled")
        }
        else {
            $("#todo-edit-submit").attr("disabled")
            $("#todo-edit-submit").addClass("disabled")
        }
    });

    // On Edit new todo : check form validation (Tasks/Edit/TaskId)
    $("#task-edit-form").on("change paste keyup click", function () {
        // Activate/desactive submit button if form is valid or not
        if ($(this).valid()) {
            $("#task-edit-submit").removeAttr("disabled").removeClass("disabled")
        }
        else {
            $("#task-edit-submit").attr("disabled")
            $("#task-edit-submit").addClass("disabled")
        }
    });

});

function add(title, description, todoId){ 
    // use the api to store a new todo for the current customer and return a partial view without reload the page
    $.ajax({
        accepts: "application/json",
        contentType: "application/json",
        type: "POST",
        url: '/api/TasksApi',
        data: JSON.stringify({ Title: title, Description: description, TodoId: todoId}),
    })
        .done(function (data) {
            console.log(data);
            $("#show-task-todo").append(
                "<tr> \
                    <td> "+ title + "</td ><td>" + description + "<td><a href=/Tasks/Edit/" + data.id + ">Modifier</a> | <a href=/Tasks/Delete/" +  data.id + ">Supprimer</a></td>\
                </tr > "
            );

        })
        .fail(function () {
  
            alert("La tâche n'a pas été créée. Veuillez contacter le support.");
        });
};
