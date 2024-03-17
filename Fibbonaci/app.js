function getFibbonaci(n) {
    if(n < 1 || n > 10) {
        return "Invalid";
    }
    let a = 0;
    let b = 1;
    let arr = [];
    arr.push(b);
    for (let i = 0; i < n-1; i++) {
        let temp = a;
        a = b;
        b = temp + b;
        arr.push(b);
    }
    return arr;
}

function print(n) {
    document.getElementById("message").innerHTML = getFibbonaci(n).join(", ");
}

function testrun(){
    console.log("Test 1:", JSON.stringify(getFibbonaci(2)) === JSON.stringify([1, 1]) ? "Passed" : "Failed");
    console.log("Test 2:", JSON.stringify(getFibbonaci(5)) === JSON.stringify([1,1,2,3,5]) ? "Passed" : "Failed");
    console.log("Test 3:", getFibbonaci() === "not allowed" ? "Passed" : "Failed");
    console.log("Test 4:", getFibbonaci(0) === "not allowed" ? "Passed" : "Failed");
    console.log("Test 5:", getFibbonaci(11) === "not allowed" ? "Passed" : "Failed");
}

testrun();
