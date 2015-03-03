function SetCompany(idCompany){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	
	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("companyTabId").innerHTML=xmlhttp.responseText;
    	}
  	}
	
	xmlhttp.open("POST","companyTab.php?idCompany="+idCompany,true);
	xmlhttp.send();
}

function SetCompanyNews(idCompany){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("companyNewsContainer").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","newslist.php?idCompany="+idCompany,true);
	xmlhttp.send();
}

function SetNULL(){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("companyNewsContainer").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","test.php",true);
	xmlhttp.send();
}

function SetNULLAdmin1(){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("centerAdmin").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","menuContent/menuContent1/content1.php",true);
	xmlhttp.send();
}
function SetNULLAdmin2(){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("centerAdmin").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","menuContent/menuContent2/content2.php",true);
	xmlhttp.send();
}
function SetNULLAdmin3(){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("centerAdmin").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","menuContent/menuContent3/content3.php",true);
	xmlhttp.send();
}
function SetNULLAdmin4(){
	if (window.XMLHttpRequest)
	{
	  xmlhttp=new XMLHttpRequest();
	}
	else
  	{
  		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  	}
  	xmlhttp.onreadystatechange=function()
  	{
  		if (xmlhttp.readyState==4 && xmlhttp.status==200)
    	{
    		
    		document.getElementById("centerAdmin").innerHTML=xmlhttp.responseText;
    	}
  	}
	xmlhttp.open("POST","menuContent/menuContent4/content4.php",true);
	xmlhttp.send();
}

function SetAjaxRequest(action, param){
	
/*	if(action=='showCompany'){
		SetCompany(param);
	}
	if(action=='showCompanyNews'){
		SetCompanyNews(param);
	}
	if(action=='setNULL'){
			
		SetNULL();
	}
*/	
	if(action=='setNULLAdmin1'){
		SetNULLAdmin1();
	}
	if(action=='setNULLAdmin2'){
		SetNULLAdmin2();
	}
	if(action=='setNULLAdmin3'){
		SetNULLAdmin3();
	}
	if(action=='setNULLAdmin4'){
		SetNULLAdmin4();
	}
	
}