'use strict';

$(function () {

    test0();
}
);


function test0() {
    x = 10;
    x += 1;
    function test1() {
        console.log(x);
    }
    test1();
}

