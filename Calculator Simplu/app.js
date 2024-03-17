$(document).ready(function(){
    
    $('#egal').click(function(){
        calculate();
    });
});

function calculate(){
    var firstNumberText = $('#firstNumber').val();
    var secondNumberText = $('#secondNumber').val();
    var operator = $('#operator').val();
    var firstNumber = parseInt(firstNumberText);
    var secondNumber = parseInt(secondNumberText);
    var result;

    switch(operator){
        case '+':
            result = firstNumber + secondNumber;
            break;
        case '-':
            result = firstNumber - secondNumber;
            break;
        case '*':
            result = firstNumber * secondNumber;
            break;
        case '/':
            if(secondNumber !== 0){
                result = firstNumber / secondNumber;
            } else {
                result = "Eroare: nu se poate împărți";
            }
            break;
        default:
            result = "Eroare: operator necunoscut";
            break;
    }

    $("#result").text(result);
}
