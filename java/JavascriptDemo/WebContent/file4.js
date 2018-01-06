'use strict';
var keke0 = {
    name: 'zhaokeke',
    birthyear: 2015
};

var keke1 = {
    name: 'zhaokeke',
    birthyear: 2015,
    age: function () {
        return new Date().getFullYear() - this.birthyear;
    }
};


$(function () {
    console.log(keke1.age);
    console.log(keke1.age());
});