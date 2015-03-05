function function1()
{
	
	var text1 = document.getElementById("text1").value;
	var result1 = parseInt(text1);
	var text3 = document.getElementById("text3").value;
	var result3 = parseInt(text3);
	
	var text2 = document.getElementById("text2").value;
	var final = 0;
	if(text2 == "+")
	{
		final = result1 + result3;
	}
	if(text2 == "-")
	{
		final = result1 - result3;
	}
	if(text2 == "*")
	{
		final = result1 * result3;
	}
		document.getElementById("text4").value = final;

}

function function2()
{
	
	var result = confirm("Вас зовут Петя?");
	console.log(result);
	if(result == true)
	{
		confirm("Молодец!");
	}
	else
	{
		result = confirm("Вы Вася??");
		if(result == true)
		{
			confirm("Круто!!");	
		}
		else
		{
			result = confirm("Ты уверен, хрен?");
			if(result == true)
			{
				confirm("Вовремя одумался, Васёк!");
			}
			else
			{
				result = confirm("Ну ты и лошара!!");	
			}
		}
	
	}
	
}


function function3()
{
	var ans = confirm("Задумайте число от 1 до 10...");
	console.log(ans);
	if(ans == true)
	{
		ans = confirm("Оно больше 5?");
		if(ans == true)
		{
			ans = confirm("Оно больше 7?");
			if(ans == true)
			{
				ans = confirm("Оно больше 9?");
					if(ans == true)
					{
						confirm("Это - 10!");
					}
					else
					{
						confirm("Это - 8!");
					}
			}
			else
			{
				confirm("Это - 6!");
			}
		}
		else
		{
			ans = confirm("Оно больше 3?");
			if(ans == true)
			{
				confirm("Это - 4!");
			}
			else
			{
				ans = confirm("Оно больше 1?");
				if (ans == true)
				{
					confirm("Это - 2!");
				}
				else
				{
					confirm("Это - 1!");	
				}
			}
		}
	}
}


function function4()
{
	var field1 = document.getElementById("field1").value;
	var field2 = document.getElementById("field2").value;
	var field3 = document.getElementById("field3").value;
	var field4 = document.getElementById("field4").value;
	var field5 = document.getElementById("field5").value;
	alert(field1 + " " + field2 + " " + field3 + " " + field4 + " " + field5);

}

function function5()
{
	var ans = document.getElementById("text").value;
	var result = parseInt(ans);
	console.log(result);
	if(result == 63)
	{
		alert("good job");
	}
	else
	{
		alert("fuck you fool!");
	}
}


function function6(button)
{
//	console.log(button.id);
	var idbutton = button.id;
	switch(idbutton)
	{
		case "Button1":
		alert("Вы нажали на кнопку 1");
		break;
		
		case "Button2":
		alert("Вы нажали на кнопку 2");
		break;
		
		case "Button3":
		alert("Вы нажали на кнопку 3");
		break;
		
		case "Button4":
		alert("Вы нажали на кнопку 4");
		break;
		
		default:
		alert("default");
		break;
	}
}


function function7(button)
{
	var idbutton = button.id;
	
	if(idbutton == "Button1")
	{
		alert("You pressed button 1");
	}
	
	if(idbutton == "Button2")
	{
		alert("You pressed button 2");
	}
	
	if(idbutton == "Button3")
	{
		alert("You pressed button 3");
	}
	
	if(idbutton == "Button4")
	{
		alert("You pressed button 4");
	}
	
	if(idbutton == "Button5")
	{
		alert("default");
	}
}

function function8()
{
	
	var text1 = document.getElementById("text1").value;
	var result1 = parseInt(text1);
	var text3 = document.getElementById("text3").value;
	var result3 = parseInt(text3);
	
	var text2 = document.getElementById("text2").value;
	var final = 0;
	switch(text2)
	{
		case "+":
		final = result1 + result3;
		break;
		
		case "-":
		final = result1 - result3;
		break;
		
		case "*":
		final = result1 * result3;
		break;
	}
	document.getElementById("text4").value = final;
}

function function9()
{	
	/*for(a=0; a<=100; a++)
	{
		console.log(a);
	}*/	
	for(i=0; i<5; i=i+1)
	{
		if(i==1)
		{
			break;	
		}
		if(i==2)
		{
			for(a=1; a<=3; a++)
			{
				console.log("hello");	
			}
			continue;
		}
		if(i==3)
		{
			continue;
		}
		
		if(i==4)
		{
			console.log("hello world");
			continue;
		}
		
		console.log("этап цикла:"+i);
	}
}

function function10()
{
	var a = "*";
	for(i=0; i<=3; i++)
	{
		console.log(a);
		a = a + "*";	
	}
	for(i=4; i<=6; i++)
	{
		a = a + "*";
		if((i==4)||(i==5))
		{
			continue;	
		}
		if(i==6)
		{
			console.log(a);
		}
	}
	var c = "****"
	for(i=3; i>=0; i--)
	{
		console.log(c);
		c = c.slice(0,-1);
			
	}
	
}

function function15()
{
	var a = "*";
	var b = "^";
	for(i=0; i<=6; i++)
	{
		a = a + "*";
		if(i==2)
		{
			a = a + b;
			continue;
		}
	}
	console.log(a);
	var c = "*";
	for(i=0; i<=6; i++)
	{
		c = c + "*";
		if(i==4)
		{
			c = c + b;
			continue;
		}
	}
	console.log(c);
	var d = "*";
	for(i=0; i<=6; i++)
	{
		d = d + "*";
		if(i==0)
		{
			d = d + b;
			continue;
		}
	}
	console.log(d);
	var e = "*";
	for(i=0; i<=6; i++)
	{
		e = e + "*";
		if(i==4)
		{
			e = e + b;
			continue;
		}
	}
	console.log(e);
	var f = "*";
	var g = "#";
	for(i=0; i<=6; i++)
	{
		f = f + "*";
		if(i==0)
		{
			f = f + g;
			continue;
		}
	}
	console.log(f);
	
}


function function11(button)
{
	var idbutton = button.id;
	var ans = "";
	
		for(a=0, i=1; a<=4, i<=5; a++, i++)
		{
			if(a == 2)
			{
				ans = ans + "hello_";
				continue;
			}
			ans = ans + a+ "hello" +i + "_";
			
		}
	if(idbutton == "Button11")
	{
		document.getElementById("text11").value = ans;
	}

	
}

function function12(button)
{
	var text12 = document.getElementById("text12read").value;
	var numb = parseInt(text12);
	var button = button.id;
	var amount = "";
	for(i=1; i<=numb; i++)
	{
		amount = amount + "hi ";
	}
	if(button == "Button12")
	{
		document.getElementById("text12write").value = amount;
	}
}

function function13()
{
	var sum = 1;
	for(i=2; i<=10; i++)
	{
		sum = sum - i;
	}	
	console.log(sum);
}

function function14()
{
	var a = 0;
	while(a<1)
	{
		a++;
		console.log(a);
	}	
	var b = 2;
	for(i=0; i<1; i++)
	{
		b = b + "2";
		console.log(b);
	}
	var c = 3;
	for(i=0; i<2; i++)
	{
		c = c + "3";
		if(i==1)
		{
			console.log(c);	
		}
	}
	var d = 4;
	for(i=0; i<3; i++)
	{
		d = d +"4";	
		if(i==2)
		{
			console.log(d);
		}
	}
	var e = 5;
	for(i=0; i<4; i++)
	{
		e = e + "5";
		if(i==3)
		{
			console.log(e);
		}
	}
	var f = "%";
	for(i=0; i<2; i++)
	{
		f = f + "%";
		if(i==1)
		{
			console.log(f);
		}
	}
	var g = 7;
	for(i=0; i<9; i++)
	{
		g = g + "7";
		if(i==8)
		{
			console.log(g);
		}
	}
}


function function16(x,y)
{
	var result = 2 * x + y;
	return result;
}


function function17(numberSymbols)
{
	var a = "";
	for(i=0; i<numberSymbols; i++)
	{
		 a = a + "*";
	}
	return a;
}

function function18(num,value)
{
	var a = "";
	var b = value;
	for(i=0; i<num; i++)
	{
		 a = a + b;
	}
	return a;
}

function function19(numb1, numb2, operat)
{
	var a = "";
	if(operat == "+")
	{
		a = numb1 + numb2;
		return a;
	}
	if(operat == "-")
	{
		a = numb1 - numb2;
		return a;
	}
	if(operat == "*")
	{
		a = numb1 * numb2;
		return a;
	}
	if(operat == "/")
	{
		a = numb1 / numb2;
		return a;
	}
}

function function20()
{
	var a = new Array(1, 2, 3, 4, 5, 6);
/*	for(i=0; i<=a.length; i++)
	{
		if(i==1)
		{
			continue;	
		}
		console.log(a[i]);
	}*/
	for(i=0; i<=a.length; i++)
	{
		if(a[i]%2==0)
		{
			continue;
		}
		console.log(a[i]);
	}
}

function function21()
{
	var a = new Array("hello", "hi", "music", "world", "people");
	for(i=0; i<=a.length; i++)
	{
		if(a[i].indexOf("l")==-1)
		{
			continue;
		}
		else
		{
			console.log(a[i]);
		}
	}
}

function function22(text)
{
	var a = new Array("a", "e", "i", "o", "u", "y");
	var result = 0;
	for(i=0; i<text.length; i++)
	{
		for(j=0; j<a.length; j++)
		{
			if(text[i].indexOf(a[j])==-1)
			{
				continue;
			}
			else
			{
				result = result + 1;
			}
		}
	}
	console.log("Всего найдено: " + result + " гласных.");
}


function function23(numbers)
{
	var result = "";
	for(i=0; i<numbers.length; i++)
	{
		if(numbers[i]=="1")
		{
			continue;
		}
		else
		{
			result = result + numbers[i];
		}
	}
	console.log(result);
}

function function24(secondSymbol)
{
	var result = "";
	for(i=0; i<secondSymbol.length; i++)
	{
		if(i%2!=0)
		{
			continue;
		}
		else
		{
			result = result + secondSymbol[i];	
		}
	}
	console.log(result);
}

function function25(input, del)
{
	var result = "";
	for(i=0; i<input.length; i++)
	{
			if(input[i]==del)
			{
				continue;
			}
			else
			{
				result = result + input[i];
			}
	}
	console.log(result);
}

function function26(button)
{
	var prevvalue = document.getElementById("26_text").value;
	var newvalue = button.innerText;
	newvalue = prevvalue + newvalue;
	document.getElementById("26_text").value = newvalue;
}

function function27(symb, numb)
{
	var result = "";
	for(i=0; i<numb; i++)
	{
		result = result + symb;
	}
	return result;
	
}

function function28()
{
	var symb = "*";
	var numb = 14;
	var symb1 = "|";
	var word = "hello";
	console.log(function27(symb, numb));
	console.log(function29(symb1, numb,""));
	console.log(function29(symb1, numb, word));
	console.log(function29(symb1, numb,""));
	console.log(function27(symb, numb));
}

function function29(symb, numb, word)
{
	var result = "";
	result = result + symb;
	if(word=="")
	{
		for(i=0; i<numb-2; i++)
		{
			result = result + " ";
		}
	}
	else
	{
		var len = word.length;
		var availableSpacesCount = numb - 2 - len;
		var rightPartSpacesCount = Math.ceil(availableSpacesCount / 2);
		var leftPartSpacesCount = availableSpacesCount - rightPartSpacesCount;
		for(i=0; i<leftPartSpacesCount; i++)
		{
			result = result + " ";
		}
		result = result + word;
		for(i=0; i<rightPartSpacesCount; i++)
		{
			result = result + " ";
		}
	
	}
	
	result = result + symb;
	return result;
}