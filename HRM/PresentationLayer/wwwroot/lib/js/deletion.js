$(document).ready(function(event){

  let startDeletion = $('.neibor-btn');
  let href;

  $(startDeletion).on('click', function(){
    href = $(this).next().attr('href');
    $('.modal-footer > .btn-danger').attr('href', href);
  })
})