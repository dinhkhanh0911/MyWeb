
function Validator(Option){

    function validate(inputElement,rule,errorElement){
        
        errorMessage = rule.test(inputElement.value);
        
        if(errorMessage){
            errorElement.innerText = errorMessage;
            inputElement.parentElement.classList.add('invalid'); 
        }
        else{
            errorElement.innerText='';
            inputElement.parentElement.classList.remove('invalid'); 
        }
    }
    var formElement = document.querySelector(Option.form);
    if(formElement){
        Option.rules.forEach(function(rule){
            var inputElement = formElement.querySelector(rule.selector);
            var errorElement = inputElement.parentElement.querySelector(Option.errorSelector);
            console.log(errorElement);
            if(inputElement){
                inputElement.onblur = function(){
                    validate(inputElement,rule,errorElement);
                }
                inputElement.oninput = function(){
                    errorElement.innerText='';
                    inputElement.parentElement.classList.remove('invalid'); 

                }
            }
        })

    }
}
Validator.isRequired = function (selector){
    return {
        selector: selector,
        test : function(value){
            return value.trim() ? undefined : "Vui lòng nhập trường này";
        }
    }
}
Validator.isEmail = function (selector){
    return {
        selector: selector,
        test : function(value){
            var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            return regex.test(value) ? undefined : "Trường này phải là email";
        }
    }
}