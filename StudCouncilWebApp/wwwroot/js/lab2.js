const uri = 'api/Faculties';
let faculties = [];

function getFaculties() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFaculties(data))
        .catch(error => console.error('Unable to get faculties.', error));
}

function addFaculty() {
    const addNameTextbox = document.getElementById('add-facultyName');

    const faculty = {
        facultyName: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(faculty)
    })
        .then(response => response.json())
        .then(() => {
            getFaculties();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add faculty.', error));
}

function deleteFaculty(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFaculties())
        .catch(error => console.error('Unable to delete faculty.', error));
}

function displayEditForm(id) {
    const faculty = faculties.find(faculty => faculty.id === id);

    document.getElementById('edit-id').value = faculty.id;
    document.getElementById('edit-facultyName').value = faculty.facultyName;
    document.getElementById('editForm').style.display = 'block';
}

function updateFaculty() {
    const facultyId = document.getElementById('edit-id').value;
    const faculty = {
        id: parseInt(facultyId, 10),
        facultyName: document.getElementById('edit-facultyName').value.trim(),
    };

    fetch(`${uri}/${facultyId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(faculty)
    })
        .then(() => getFaculties())
        .catch(error => console.error('Unable to update faculty.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayFaculties(data) {
    const tBody = document.getElementById('faculties');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(faculty => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${faculty.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFaculty(${faculty.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(faculty.facultyName);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    faculties = data;
}
