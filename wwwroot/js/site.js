// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
    var url = '/api/Symptoms?Name=' + name;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updateSymptom(id, name) {
    var url = '/api/Symptoms/' + id + '?Name=' + name;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deleteSymptom(id) {
    var url = '/api/Symptoms/' + id;
    deleteAjaxCall(url, id);
}
function addSpecialty(name, details) {
    var url = '/api/Specialties?Name=' + name + '&Details=' + details;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updateSpecialty(id, name, details) {
    var url = '/api/Specialties/' + id + '?Name=' + name + '&Details=' + details;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deleteSpecialty(id) {
    var url = '/api/Specialties/' + id;
    deleteAjaxCall(url, id);
}
function searchSpecialty(name) {
    var url = '/api/Specialties?Name=' + name;
    searchAjaxCall(url);
}
function addPatient(name, email, password) {
    var url = '/api/Patients?Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updatePatient(id, name, email, password) {
    var url = '/api/Patients/' + id + '?Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deletePatient(id) {
    var url = '/api/Patients/' + id;
    deleteAjaxCall(url, id);
}
function addDoctor(send, name, email, password) {
    var url = '/api/Doctors?' + send + 'Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updateDoctor(id, send, name, email, password) {
    var url = '/api/Doctors/' + id + '?' + send + 'Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deleteDoctor(id) {
    var url = '/api/Doctors/' + id;
    deleteAjaxCall(url, id);
}
function searchDisease(name) {
    var url = '/api/Diseases?Name=' + name;
    searchAjaxCall(url);
}
function addDisease(send, name, details, type) {
    var url = '/api/Diseases?' + send + 'Name=' + name + '&Details=' + details + '&Type=' + type;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updateDisease(id, send, name, details, type) {
    var url = '/api/Diseases/' + id + '?' + send + 'Name=' + name + '&Details=' + details + '&Type=' + type;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deleteDisease(id) {
    var url = '/api/Diseases/' + id;
    deleteAjaxCall(url, id);
}
function addAdmin(name, email, password) {
    var url = '/api/Admins?Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'POST';
    saveAjaxCall(url, type);
}
function updateAdmin(id, name, email, password) {
    var url = '/api/Admins/' + id + '?Name=' + name + '&Email=' + email + '&Password=' + password;
    var type = 'PUT';
    saveAjaxCall(url, type);
}
function deleteAdmin(id) {
    var url = '/api/Admins/' + id;
    deleteAjaxCall(url, id);
}
function saveAjaxCall(url, type) {
    $.ajax({
        url: url,
        type: type,
        dataType: 'json',
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
function deleteAjaxCall(url, id) {
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
