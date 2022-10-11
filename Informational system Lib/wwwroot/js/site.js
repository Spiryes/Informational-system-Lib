// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Code that uses other library's $ can follow here.
$ = jQuery.noConflict();

// в Index.cshtml  декларираме  ид на класовете за да можем да ги използваме в този файл.
//В този файл се извършва проверка дали името и паролата които са въведени в кутиите за логин са правилните данни.
$(document).ready(function () {

    $('#submit').on('click', function (e) {
        e.preventDefault();
        let name = $("#name").val();
        let password = $("#password").val();

        if (name === "Admin" && password === "admin") {
            window.location.href = "/Home/HomePage2";
        } else {
            $("#message").text('Невалидни данни за вход!');
        }
    });
    
});