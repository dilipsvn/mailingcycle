// JScript File

       function ClientValidate(source, arguments)
       {
        arguments.IsValid = true;
        if (arguments.Value.length < 8)
        {
            arguments.IsValid = false;
            return; 
        }
        if (arguments.Value.indexOf(" ") >= 0)
        {
            arguments.IsValid = false;
            return; 
        }
       }

    function openHelp(path)
    {
        var iWidth = 300;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }

    function newQuestion(list)
    {
        if (list.options[list.selectedIndex].value == 13)
        {
            var vTextData = window.prompt("Please enter your own secret question:", "");
            
            if (vTextData != null)
            {
                if (vTextData != "")
                {
                    //var index = list.length - 1;
                    
                    //var oOption = document.createElement("OPTION");
                    //list.options.add(oOption, index);
                    //oOption.innerText = vTextData;
                    //oOption.value = "100";
                    //list.selectedIndex = index;
                    eleList = document.getElementsByTagName("input");
                    for(i=0;i<eleList.length-1;i++)
                        if(eleList[i].type=="hidden")
                            if(eleList[i].id.indexOf("SecQuestionHiddenField")>=0)
                                eleList[i].value = vTextData;        
                    
                    list.options[list.length-1].innerText = vTextData;
                    list.selectedIndex = list.length-1;
                }
            }
        }
    }
