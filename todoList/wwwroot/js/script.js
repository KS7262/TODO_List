function addInput(event) {
    event.preventDefault();
    
    var container = document.getElementById('inputContainer');
    var newInputContainer = document.createElement('div');
    newInputContainer.classList.add('input-container');
    
    var newInput = document.createElement('input');
    newInput.type = 'text';
    newInput.placeholder = 'Завдання';
    newInputContainer.appendChild(newInput);
    container.appendChild(newInputContainer);
}