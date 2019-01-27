var elementsCount = 0;

function moveById(id)
{
    var values = id.split('_');
    selectedToAnotherSelect((values[0] == 1) || (values[0] == 2)?false : true, 
    (values[0] == 1) || (values[0] == 4)?true: false, values[2]);
}

function selectedToAnotherSelect(toLeft, allOptions, id)
{
    var leftSelectName = "left_select_" + id;
    var rightSelectName = "right_select_" + id;
    if(toLeft)
    {
        var temp = leftSelectName;
        leftSelectName = rightSelectName;
        rightSelectName = temp;
    }
    var selectOne = document.getElementById(leftSelectName);
    var selectTwo = document.getElementById(rightSelectName);
    if(selectOne.selectedIndex == -1 && !allOptions)
    {
        return;
    }

    if(allOptions)
    {
        for(i = 0; i < selectOne.length; i++)
        {
            var optional = document.createElement('option');
            optional.innerHTML = selectOne[i].text;
            selectTwo.appendChild(optional);
        }
        for(i = 0; i < selectTwo.length; i++)
        {
            selectOne.remove(selectOne.options[i]);
        }
    }
    else
    {
        var selected = selectOne.options[selectOne.selectedIndex].text;
        var optional = document.createElement('option');
        optional.innerHTML = selected;
        selectTwo.appendChild(optional);
        selectOne.remove(selectOne.selectedIndex);
    }
}

function generateBlock()
{
    var div = document.createElement('div');
    div.className = 'element';
    div.innerHTML = 
        '<div id="'+ elementsCount +'"> \
        <table style="display: inline-block;">\
            <tr>\
                <td>Available</td>\
            </tr>\
            <tr>\
                <td>\
                    <select name="select" size="7" id="left_select_'+ elementsCount +'">\
                        <option selected value="s1">Option 1</option>\
                        <option value="s2">Option 2</option>\
                        <option value="s3">Option 3</option>\
                    </select>\
                </td>\
            </tr>\
        </table>\
        <table style="display: inline-block;">\
            <tr>\
                <td>\
                    <input type="button" value=">>" id="1_button_'+ elementsCount +'" onclick="moveById(this.id);";>\
                </td>\
            </tr>\
            <tr>\
                <td>\
                    <input type="button" value=">" id="2_button_'+ elementsCount +'" onclick="moveById(this.id);">\
                </td>\
            </tr>\
            <tr>\
                <td>\
                    <input type="button" value="<" id="3_button_'+ elementsCount +'" onclick="moveById(this.id);">\
                </td>\
            </tr>\
            <tr>\
                <td>\
                    <input type="button" value="<<" id="4_button_'+ elementsCount +'" onclick="moveById(this.id);";>\
                </td>\
            </tr>\
        </table>\
        <table style="display: inline-block;">\
            <tr>\
                <td>Selected</td>\
            </tr>\
            <tr>\
                <td>\
                    <select name="select" size="7" id="right_select_'+ elementsCount +'">\
                            <option selected value="s1">Option 4</option>\
                            <option value="s2">Option 5</option>\
                    </select>\
                </td>\
            </tr>\
        </table>\
    </div>';
    elementsCount += 1;
    document.getElementById('main_form').appendChild(div)
}
        