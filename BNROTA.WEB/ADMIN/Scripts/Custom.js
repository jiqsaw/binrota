function row_over(src) {
    document.getElementById(src).style.backgroundColor = 'E0E0E0';
  }

function row_out(src) {
    document.getElementById(src).style.backgroundColor = 'F0F0F0';
  }
  
function CheckAll(Check, chID) {
    for (var i = theForm.elements.length; --i>=0;) {
        if (theForm.elements[i].id == chID) {
            theForm.elements[i].checked = Check;   
        }
    }
}