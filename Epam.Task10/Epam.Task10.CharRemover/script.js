String.prototype.replaceAll = function(search, replace){
    return this.split(search).join(replace);
}

function removeRepeatableChars()
{
    var input_string = document.getElementById('input_string_input').value;
    var chars = [];
    var result_string = "";
    result_string = input_string;
    if(input_string.length > 0)
    {
        for(i = 0; i < input_string.length; i++)
        {
            if(input_string[i] === ' ')
            {
                continue;
            }
            if(chars.includes(input_string[i]))
            {
                result_string = result_string.replaceAll(input_string[i], "");
            }
            else
            {
                chars.push(input_string[i])
            }        
        }
    document.getElementById('input_string_text').innerHTML = input_string;
    document.getElementById('result_string_text').innerHTML = result_string;
    }
}
        