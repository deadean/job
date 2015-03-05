// JavaScript Document

var empty = {};
var point = { x:0, y:0 };
var circle = { x:point.x, y:point.y+1, radius:2 };
var homer =
{
	"name": "Homer Simpson",
	"age": 34,
	"married": true,
	"occupation": "plant operator",
	"email": "homer@example.com"
}



var a = new Array( );
var d = new Date( );
var r = new RegExp("javascript", "i");



var book = new Object();
book.title = "JavaScript: полное руководство";
book.chapter1 = new Object();
book.chapter1.title = "Введение в JavaScript";
book.chapter1.pages = 11;
book.chapter2 = { title: "Лексическая структура", pages: 6 };
alert("Заголовок: " + book.title + "\n\t" + 
"Глава 1 " + book.chapter1.title + "\n\t" +
"Глава 2 " + book.chapter2.title);



function DisplayPropertyNames(obj)
{
	var names = "";
	for(var name in obj) names += name + "\n";
	alert(names);	
}



var addr = "";
for(i=0; i<4; i++)
{
	addr += customer["address" + i]	+ '\n';
}



