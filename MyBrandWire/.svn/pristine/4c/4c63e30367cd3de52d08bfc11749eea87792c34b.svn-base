function SetPressRealizeContentVisible(a){
	//alert("t");
	document.getElementById("ifrContent").src = "mainController.php?type="+a;
	SetCurrentOperation(a);
}



function ChangeVisibleStatus(id){
	var status = document.getElementById(id).style.display;
	if(status=='block')
		status='none';
	else
		status='block';
	document.getElementById(id).style.display = status;
}

function ShowToolTip(a){
	var elems = document.getElementsByClassName('test');
	for (i in elems){
		var id = elems[i].getAttribute('id');
		if(id.indexOf("newsInfo")!=-1 && id.indexOf(a)!=-1){
			ChangeVisibleStatus(id);
		}
	}
}

function SetCurrentOperation(type){
	if(type==1)
		document.getElementById("hCenterIndexCurrentFunction").innerHTML = "Написание пресс-релиза";
	if(type==2)
		document.getElementById("hCenterIndexCurrentFunction").innerHTML = "Публикация пресс-релиза";
	if(type==3)
		document.getElementById("hCenterIndexCurrentFunction").innerHTML = "Распространение по базам СМИ";
	if(type==4)
		document.getElementById("hCenterIndexCurrentFunction").innerHTML = "Адаптация новости";
	if(type==5)
		document.getElementById("hCenterIndexCurrentFunction").innerHTML = "Test function";
}

function test(){
	alert("Hello");
}