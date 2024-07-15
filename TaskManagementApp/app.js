const apiUrl = 'https://localhost:7053/swagger/index.html';

// Function to fetch tasks from the API
async function fetchTasks() {
    const response = await fetch(`${apiUrl}/tasks`);
    const tasks = await response.json();
    return tasks;
}

// Function to add a new task
async function addTask(task) {
    const response = await fetch(`${apiUrl}/tasks`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    });
    return response.json();
}

// Function to mark a task as completed
async function completeTask(taskId) {
    const response = await fetch(`${apiUrl}/tasks/${taskId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ completed: true })
    });
    return response.json();
}



// Function to render tasks
function renderTasks(tasks) {
    const taskList = document.getElementById('task-list');
    taskList.innerHTML = '<h2>Task List</h2>';
    tasks.forEach(task => {
        const taskItem = document.createElement('div');
        taskItem.classList.add('task-item');
        if (task.completed) {
            taskItem.classList.add('completed');
        }
        taskItem.innerHTML = `
            <h3>${task.title}</h3>
            <p>${task.description}</p>
            <p>Due: ${new Date(task.dueDate).toLocaleDateString()}</p>
            <button onclick="markAsCompleted(${task.taskId})">Complete</button>
        `;
        taskList.appendChild(taskItem);
    });
}

// Function to load tasks
async function loadTasks() {
    const tasks = await fetchTasks();
    renderTasks(tasks);
}

// Load tasks when the page loads
window.onload = loadTasks;

//Handle marking tasks as completed
async function markAsCompleted(taskId) {
    await completeTask(taskId);
    await loadTasks(); // Reload tasks to show the updated status
}



//Attach Documents and Add Notes
taskItem.innerHTML = `
    <h3>${task.title}</h3>
    <p>${task.description}</p>
    <p>Due: ${new Date(task.dueDate).toLocaleDateString()}</p>
    <button onclick="markAsCompleted(${task.taskId})">Complete</button>
    <form id="attach-document-form-${task.taskId}" onsubmit="attachDocument(${task.taskId}); return false;">
        <label for="document">Attach Document:</label>
        <input type="file" id="document-${task.taskId}" name="document">
        <button type="submit">Attach</button>
    </form>
    <form id="add-note-form-${task.taskId}" onsubmit="addNote(${task.taskId}); return false;">
        <label for="note">Add Note:</label>
        <input type="text" id="note-${task.taskId}" name="note">
        <button type="submit">Add</button>
    </form>
`;

// Function to attach document
async function attachDocument(taskId) {
    const formData = new FormData();
    const documentInput = document.getElementById(`document-${taskId}`);
    formData.append('document', documentInput.files[0]);

    await fetch(`${apiUrl}/tasks/${taskId}/documents`, {
        method: 'POST',
        body: formData
    });

    await loadTasks(); // Reload tasks to show the attached document
}

// Function to add note
async function addNote(taskId) {
    const noteContent = document.getElementById(`note-${taskId}`).value;

    await fetch(`${apiUrl}/tasks/${taskId}/notes`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ content: noteContent })
    });

    await loadTasks(); // Reload tasks to show the added note
}
