<?php

class PressRealize{
	public $id;
	public $header;
	public $content;
	
	public function __construct() {}
}

class Model {
	
	private $hostname = "localhost"; 
	private $username = "root"; 
	private $password = ""; 
	private $dbName = "aqq14251_mybrandwire"; 
	private $userstable = "users"; 
	private $pressrealise = "news";
	
    public function __construct() {}
	
	public function Test()
	{
		return 1;	
	}
	
	public function AddUser($name){
		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$usertable_ = $this->userstable;
		$query = "INSERT INTO $usertable_ VALUES(NULL,'$name')"; 
		mysql_query($query) or die(mysql_error()); 
		echo "Информация о вас занесена в базу данных."; 
		
		mysql_close(); 
	}
	
	public function GetAllNewPressRealise(){

		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$table = $this->pressrealise;
		$query = "SELECT * FROM $table"; 
		$result = mysql_query($query);
						
		mysql_close(); 
		
		return $result;
	}
	
	public function GetAllCheckedPressRealise(){

		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$table = $this->pressrealise;
		$query = "SELECT * FROM $table WHERE status='2'"; 
		$result = mysql_query($query);
						
		mysql_close(); 
		
		return $result;
	}
	
	public function GetAllPressRealiseForAdapt()
	{
		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$table = $this->pressrealise;
		$query = "SELECT * FROM $table WHERE status='0' OR status='1'"; 
		$result = mysql_query($query);
						
		mysql_close(); 
		
		return $result;
	}
	
	public function GetPressRealizeById($id){
		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		
		$table = $this->pressrealise;
		$query = "SELECT * FROM $table WHERE id=$id"; 
		$result = mysql_query($query);
		
		$result1= new PressRealize();
		while ($row = mysql_fetch_assoc($result)) 
		{
			$result1->id = $row["id"];
			$result1->header = $row["header"];
			$result1->content = $row["content"];
		}
		
		mysql_free_result($result);				
		mysql_close();
		
		
		return $result1;
	}
	
	public function UpdatePressRealize($entity){
		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$table = $this->pressrealise;
		$query = "UPDATE $table SET header='$entity->header', content='$entity->content' WHERE id='$entity->id'";
		mysql_query($query);
						
		mysql_close();
	}
	
	public function SendEmail($idPressRealise){
	
		mysql_connect($this->hostname,$this->username,$this->password) OR DIE("Не могу создать соединение "); 
		mysql_select_db($this->dbName) or die(mysql_error());

		$table = $this->pressrealise;
		$query = "SELECT * FROM $table WHERE id='$idPressRealise'"; 
		$result = mysql_query($query);
						
		mysql_close(); 

		$htmlBody = "";
		while ($row = mysql_fetch_assoc($result)) {
			$htmlBody.=$row['header'];
		}
			
		mysql_free_result($result);
		
		$to  = "Dean &lt;deadean@yandex.ru>, " ; 
		//$to .= "Kelly &lt;kelly@example.com>"; 

		$subject = "Press Realise check"; 
		$message = ' 
		<html> 
			<head> 
				<title>Press Realise Check</title> 
			</head> 
			<body> 
				<p>Hello</p> 
			</body> 
		</html>'; 
		
		$headers  = "Content-type: text/html; charset=windows-1251 \r\n"; 
		$headers .= "From: BrandWire Company <deadean@yandex.ru>\r\n"; 
		//$headers .= "Bcc: birthday-archive@example.com\r\n"; 

		return mail($to, $subject, $message, $headers); 
			
	}

	
	};
	
?>