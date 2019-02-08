﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ajaxStart(function () {
    Pace.restart();
})
function searchSymptom(name) {
    var url = '/api/Symptoms?Name=' + name;
    searchAjaxCall(url);
}
function addSymptom(name) {
    var url = '/api/Symptoms';
    var type = 'POST';
    var data = {
        Name: name
    };
    saveAjaxCall(url, type, data);
}
function updateSymptom(id, name) {
    var url = '/api/Symptoms/' + id;
    var type = 'PUT';
    var data = {
        ID: id,
        Name: name
    };
    saveAjaxCall(url, type, data);
}
function deleteSymptom(id, table) {
    var url = '/api/Symptoms/' + id;
    deleteAjaxCall(url, id, table);
}
function addSpecialty(name, details) {
    var url = '/api/Specialties';
    var type = 'POST';
    var data = {
        Name: name,
        Details: details
    };
    saveAjaxCall(url, type, data);
}
function updateSpecialty(id, name, details) {
    var url = '/api/Specialties/' + id;
    var type = 'PUT';
    var data = {
        ID: id,
        Name: name,
        Details: details
    };
    saveAjaxCall(url, type, data);
}
function deleteSpecialty(id, table) {
    var url = '/api/Specialties/' + id;
    deleteAjaxCall(url, id, table);
}
function searchSpecialty(name) {
    var url = '/api/Specialties?Name=' + name;
    searchAjaxCall(url);
}
function addPatient(name, email, password) {
    var url = '/api/Patients';
    var type = 'POST';
    var data = {
        Name: name,
        Email: email,
        Password: password
    };
    saveAjaxCall(url, type, data);
}
function updatePatient(id, name, email, password) {
    var url = '/api/Patients/' + id;
    var type = 'PUT';
    var data = {
        ID: id,
        Name: name,
        Email: email,
        Password: password
    };
    saveAjaxCall(url, type, data);
}
function deletePatient(id, table) {
    var url = '/api/Patients/' + id;
    deleteAjaxCall(url, id, table);
}
function addDoctor(specialty, name, email, password) {
    var url = '/api/Doctors';
    var type = 'POST';
    var doctor = {
        Name: name,
        Email: email,
        Password: password
    };
    var data = {
        Doctor: doctor,
        Specialty: specialty
    };
    saveAjaxCall(url, type, data);
}
function updateDoctor(id, specialty, name, email, password) {
    var url = '/api/Doctors/' + id;
    var type = 'PUT';
    var doctor = {
        ID: id,
        Name: name,
        Email: email,
        Password: password
    };
    var data = {
        Doctor: doctor,
        Specialty: specialty
    };
    saveAjaxCall(url, type, data);
}
function deleteDoctor(id, table) {
    var url = '/api/Doctors/' + id;
    deleteAjaxCall(url, id, table);
}
function searchDisease(name) {
    var url = '/api/Diseases?Name=' + name;
    searchAjaxCall(url);
}
function addDisease(symptoms, name, details, dtype) {
    var url = '/api/Diseases';
    var type = 'POST';
    var disease = {
        Name: name,
        Details: details
    };
    var data = {
        Disease: disease,
        Symptoms: symptoms,
        Type: dtype
    };
    saveAjaxCall(url, type, data);
}
function updateDisease(id, symptoms, name, details, dtype) {
    var url = '/api/Diseases/' + id;
    var type = 'PUT';
    var disease = {
        ID: id,
        Name: name,
        Details: details
    };
    var data = {
        Disease: disease,
        Symptoms: symptoms,
        Type: dtype
    };
    saveAjaxCall(url, type, data);
}
function deleteDisease(id,table) {
    var url = '/api/Diseases/' + id;
    deleteAjaxCall(url, id,table);
}
function addAdmin(name, email, password) {
    var url = '/api/Admins';
    var type = 'POST';
    var data = {
        Name: name,
        Email: email,
        Password: password
    };
    saveAjaxCall(url, type, data);
}
function updateAdmin(id, name, email, password) {
    var url = '/api/Admins/' + id;
    var type = 'PUT';
    var data = {
        ID: id,
        Name: name,
        Email: email,
        Password: password
    };
    saveAjaxCall(url, type, data);
}
function deleteAdmin(id, table) {
    var url = '/api/Admins/' + id;
    deleteAjaxCall(url, id, table);
}
function sendMail(reciever, subject, content) {
    var url = '/api/Feedbacks';
    var type = 'POST';
    var data = {
        Reciever: reciever,
        Subject: subject,
        Content: content
    };
    saveAjaxCall(url, type, data);
}
function deleteFeedback(id, table) {
    var url = '/api/Feedbacks/' + id;
    deleteAjaxCall(url, id, table);
}
function saveAjaxCall(url, type, data) {
    $.ajax({
        url: url,
        type: type,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        error: function () {
            $('#modal-danger').modal('show');
        },
        success: function () {
            $('#modal-success').modal('show');
        },
    });
}
function searchAjaxCall(url) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        error: function () {
            $('#modal-danger').modal('show');
        },
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#results").append("<option>" + data[i] + "</option>");
            }
        },
    });
}
function deleteAjaxCall(url, id, table) {
    $.ajax({
        url: url,
        type: 'DELETE',
        dataType: 'json',
        error: function () {
            $('#modal-danger').modal('show');
        },
        success: function () {
            table.row("#" + id).remove().draw();
        },
    });
}
function delay(callback, ms) {
    var timer = 0;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timer);
        timer = setTimeout(function () {
            callback.apply(context, args);
        }, ms || 0);
    };
}
