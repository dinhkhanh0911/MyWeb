function drop(str){
    var ok=true;
    var currentPane = document.getElementById(str);
    if(currentPane.style.display=='block')
         ok = false;
 var dropdownPane = document.getElementsByClassName('dropdown-pane');
 for(i =0;i<dropdownPane.length;++i){
     dropdownPane[i].style.display='none';
 }
 
 if(ok) currentPane.style.display='block';
}
