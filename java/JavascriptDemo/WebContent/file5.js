/*this file test apply & call & this */
'use strict';


$(function () {
    normalTest();
    callTest();
    applyTest();
    // this.errorTest();

});




function getAge() {
    return new Date().getFullYear() - this.birthyear;
}

var keke = {
    name: 'zhaokeke',
    birthyear: 2015,
    age: getAge
};

function normalTest() {
    var kekeage = keke.age();
    console.log(kekeage);
}

function errorTest() {
    var kekeage = getAge();
    console.log(kekeage);
}


function callTest() {
    var kekeage = getAge.call(keke);
    console.log(kekeage);
}

function applyTest() {
    var kekeage = getAge.apply(keke);
    console.log(kekeage);
}