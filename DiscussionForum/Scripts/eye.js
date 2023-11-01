
function myfunction() {
    var x = document.getElementById("password");
    var y = document.getElementById("hide1");
    var z = document.getElementById("hide2");

    if (x.type === 'password') {
        x.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }

    else {
        x.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}
function myfunction1() {
    var x = document.getElementById("cpassword");
    var y = document.getElementById("hide3");
    var z = document.getElementById("hide4");

    if (x.type === 'password') {
        x.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }

    else {
        x.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}
function myfunction2() {
    var x = document.getElementById("passw");
    var y = document.getElementById("hide5");
    var z = document.getElementById("hide6");
    if (x.type === 'password') {
        x.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }

    else {
        x.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}
