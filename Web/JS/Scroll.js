

function scroll(textv) {

    var texto = textv;
    var longitud = texto.length;
    
    texto = texto.substring(1, longitud - 1) + texto.charAt(0);
    window.status = texto;
    setTimeout("scroll()", 150);
}