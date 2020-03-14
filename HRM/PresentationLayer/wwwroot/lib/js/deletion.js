$(document).ready(function(event){

  let accept = $('#accept-delete-btn');
  let startDeletion = $('.neibor-btn');
  let href;

  $(startDeletion).on('click', function(){
    href = $(this).next().attr('href');
    // console.log(href);
    $('.modal-footer > .btn-danger').attr('href', href);
  })

  $(accept).on('click', function(){
    // console.log(targetBtn);
    targetBtn.click();
  })

})