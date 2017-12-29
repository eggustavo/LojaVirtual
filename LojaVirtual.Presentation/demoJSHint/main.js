//Com Erro
//function () {
//    return 'OK';
//}

//Sem Erro
function firstTest() {
    return 'OK';
}


//curly

//Com Erro
//if (true)
//   return true;

//Sem Erro
if (true)
{
   return true;
}


//newcap
var Plugin = function () {};

//Com Erro
//new plugin();

//Sem Erro
new Plugin();


//eqeqeq

//Com Erro
//var teste = 5 == '5';

//Sem Erro
var teste = 5 === '5';


//undef

//Com Erro
//myVar = 'Olá';

//Sem Erro
var myVar = 'Olá';


//devel = true permite usar
alert(myVar);
console.log(myVar);


//debug = true permite usar
debugger;


//globals
$('#element').addClass('nice');
jQuery('#element').addClass('good');
jQuery('#element').addClass('good');