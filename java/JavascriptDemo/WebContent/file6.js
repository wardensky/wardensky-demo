/*this file test apply & call & this */

$(function () {
    var myMother = new person("Steve", "Jobs", 56, "green");
    myMother.changeName("Ballmer");

    var zhan = new teacher("zhan", "math");
    zhan.teach("wang");
});

function teacher(name, subject1) {
    this.name = name;
    this.subject1 = subject1;


    function teach(newname) {
        this.name = newname;
        console.log(this.subject1);
    }
}

function person(firstname, lastname, age, eyecolor) {
    this.firstname = firstname;
    this.lastname = lastname;
    this.age = age;
    this.eyecolor = eyecolor;

    this.changeName = changeName;
    function changeName(name) {
        console.log(this.lastname);
        this.lastname = name;
    }
}
