$(document).ready(function(){

  

  let okBtn = $('#ok-btn');
  let submitBtn = $('#submit-btn');
  let warningAlert = $('#warning-alert');
  let closeWarningBtn = $('#close-warning');

  $(okBtn).on('click', function(){

    let selectors = $('.select-form');

    let isFill = true;

    for (let i = 0; i < selectors.length; i++) {
        if(selectors[i].value == 'default' || selectors[i].value == ''){
          isFill = false;
          break;
        }
    }

    if (isFill) {
      submitBtn.click();
    }
    else{
      warningAlert.fadeIn();
    }

  })

  $(closeWarningBtn).on('click', function(){
    warningAlert.fadeOut();
  })

})