'use strict';

$(function () {

    test0();
    //  test1();
}
);
function abc() {
    'use strict';
    var arr = ['小明', '小红', '大军', '阿黄'];
    var newArr = arr.sort();
    var last = newArr.pop();
    var msg = "欢迎" + newArr.join(",") + "和" + last + "同学!";
    alert(msg);
}

function objf() {
    var keke = {
        name: 'zhaokeke',
        "age": 2,
        gender: 'girl'
    };
    console.log(keke);
    console.log(keke.name);
    console.log(keke["age"]);
    keke.birth = 20150411;
    console.log(keke.birth);
}

function test0() {
    x = 10;
    x += 1;
    function test1() {
        console.log(x);
    }
    test1();
}

