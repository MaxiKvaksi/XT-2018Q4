String.prototype.replaceAll = function(search, replace){
    return this.split(search).join(replace);
}

function Calculate()
{
    var input_string = document.getElementById('input_string_input').value;
    document.getElementById('input_string_text').innerHTML = input_string;
    if(input_string.length > 0)
    {
        var regExpSequence = /((\d+).(\d+)\+|-|\*|\/)*((\d+).(\d+))/g;
        if(!input_string.match(regExpSequence))
        {
            alert("Invalid expression!");
            return;
        }
        var regExpRealNumbers = /(\d+).(\d+)/g;
        var realNumbers = input_string.match(regExpRealNumbers);
        var regExpOperators = /\+|-|\*|\//g;
        var operators = input_string.match(regExpOperators);
        if(operators.length + 1 != realNumbers.length)
        {
            alert("Invalid expression!");
            return;
        }
        operators = operators.reverse();
        realNumbers = realNumbers.reverse();
        var operator = operators.pop();
        var result = realNumbers.pop();
        var bNum = realNumbers.pop();
        while(operator)
        {
            switch(operator)
            {
                case '+': result = +result + +bNum; break;
                case '-': result -= bNum; break;
                case '*': result *= bNum; break;
                case '/': result /= bNum; break;
            }
            operator = operators.pop();
            bNum = realNumbers.pop();
        }
        document.getElementById('result_string_text').innerHTML = result;
    }
    else
    {
        alert("Empty string!");
    }
}
        