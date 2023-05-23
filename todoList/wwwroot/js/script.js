var inputIndex = 1;

function addInput(event) {
    event.preventDefault();

    var container = document.getElementById('inputContainer');
    var newInputContainer = document.createElement('div');
    newInputContainer.classList.add('input-container');
    var newInput = document.createElement('input');
    newInput.type = 'text';
    newInput.placeholder = 'Task';
    newInput.name = 'tasks[' + inputIndex + ']';
    newInputContainer.appendChild(newInput);
    container.appendChild(newInputContainer);

    inputIndex++;
}

function handleSubmit() {
    var titleInput = document.querySelector('input[name="title"]');
    var title = titleInput.value;
    var taskInputs = document.querySelectorAll('input[name^="tasks"]');
    var tasks = [];

    taskInputs.forEach(function (input) {
        tasks.push(input.value);
    });

    var form = document.createElement('form');
    form.method = 'post';
    form.action = '/Home/SetNewTodo';

    var titleHiddenInput = document.createElement('input');
    titleHiddenInput.type = 'hidden';
    titleHiddenInput.name = 'title';
    titleHiddenInput.value = title;
    form.appendChild(titleHiddenInput);

    tasks.forEach(function (task) {
        var taskHiddenInput = document.createElement('input');
        taskHiddenInput.type = 'hidden';
        taskHiddenInput.name = 'tasks';
        taskHiddenInput.value = task;
        form.appendChild(taskHiddenInput);
    });

    document.body.appendChild(form);
    form.submit();
}

var form = document.getElementById('todoForm');
form.addEventListener('submit', function (event) {
    event.preventDefault();
    handleSubmit();
});
