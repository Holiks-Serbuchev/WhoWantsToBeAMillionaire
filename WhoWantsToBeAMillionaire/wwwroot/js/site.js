﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Clicked() {
        document.getElementById('FiftyButton').style.visibility = 'hidden';
        var correctAnswer = document.getElementById('FiftyButton').value;
        var newArrayList = [];
        for (var i = 0; i < arrayList.length; i++) {
            if (document.getElementById(arrayList[i]).innerText != correctAnswer) {
                document.getElementById(arrayList[i]).style.visibility = "hidden";
                newArrayList.push(arrayList[i]);
            }
        }
    var sa = newArrayList[Math.floor(Math.random() * 2)];
    document.getElementById(sa).style.visibility = "visible";
    var check = sessionStorage.getItem("check");
    if (check == "true")
        sessionStorage.setItem("check", "false");
    else
        sessionStorage.setItem("check", "true");
}
var arrayList = ['FirstAnswer', 'SecondAnswer', 'ThirdAnswer', 'FourthAnswer'];
var check = sessionStorage.getItem("check");
if (document.getElementById("true")) {
    if (check != "true")
        document.getElementById('FiftyButton').style.visibility = 'visible';
    document.getElementById('Selector').style.visibility = "hidden";
    document.getElementById('true').value = "Стоп";
    arrayList.forEach(i => document.getElementById(i).style.visibility = "visible");
}
else {
    sessionStorage.setItem("check", "false");
    document.getElementById('FiftyButton').style.visibility = 'hidden';
    document.getElementById('Selector').style.visibility = "visible";
    document.getElementById('false').value = "Старт";
    arrayList.forEach(i => document.getElementById(i).style.visibility = "hidden");
}