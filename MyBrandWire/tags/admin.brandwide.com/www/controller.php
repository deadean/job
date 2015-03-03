<?php
	include "model.php";
		
	class Controller
	{
		public function __construct() {
			
		}
		
		public function PrintAllNewPressRealise(){
			$_GET['team1'] = "2";
			$model = new Model();
			$result =  $model->GetAllNewPressRealise();
			 
			 while ($row = mysql_fetch_assoc($result)) {
				$val = $row["id"];
				if($row["status"]==0)
					$status="lavender";
				else
					$status="LightBlue";
				echo "<tr bgcolor=$status>";
				echo "<td>$val</td>";
				$val = $row["header"];
				echo "<td>$val</td>";
				$val="ShowToolTip(".$row["id"].")";
				echo "<td><a href='javascript:;' id='showToolTip' onclick='$val'>Показать новость</a></td>";
				$val="content.php?action=send&id=".$row["id"];
				echo "<td><a href='$val' id='sendToOrder' >Отправить заказчику</a></td>";
				echo "<td><a href='javascript:;' id='sendToCompany' onclick=''>Отправить компании</a></td>";
				echo "</tr>";
				$val="newsInfo".$row["id"];
				echo "<tr class='contentNews'><td class='test' id='$val' style='display:none'>".$row["header"]."</td></tr>";
			 }
			
			mysql_free_result($result);
		}
		
		public function PrintAllCheckedPressRealise(){
			$model = new Model();
			$result =  $model->GetAllCheckedPressRealise();
			 
			 while ($row = mysql_fetch_assoc($result)) {
				$val = $row["id"];
				echo "<tr bgcolor='lavender'>";
					echo "<td>$val</td>";
						$val = $row["header"];
					echo "<td>$val</td>";
						$val="ShowToolTip(".$row["id"].")";
					echo "<td><a href='javascript:;' id='showToolTip' onclick='$val'>Показать новость</a></td>";
						$val="newsInfo".$row["id"];
					echo "<tr class='contentNews'><td class='test' id='$val' colspan='3' style='display:none'>";
					$_GET["pressID"]=$row["id"];
					include ('php/forms/PressRealizeForm.php');
					echo "</td></tr>";
				echo "</tr>";
			 }
			
			mysql_free_result($result);
		}
		
		function SendEmail($id){
			$model = new Model();
			return $model->SendEmail($id);
		}
		
		function SavePressRealize($pressRealize){
			$model = new Model();
			$pressRealize->header=$_POST['header'];
			$pressRealize->content=$_POST['content'];
			$model->UpdatePressRealize($pressRealize);
			
		}
		
		function GetPressRealizeById($id){
			$model = new Model();
			return $model->GetPressRealizeById($id);
		}
	
		function PrintAllPressRealiseForAdapt()
		{
			$model = new Model();
			$result =  $model->GetAllPressRealiseForAdapt();
			 
			 while ($row = mysql_fetch_assoc($result)) {
				$val = $row["id"];
				echo "<tr bgcolor='lavender'>";
					echo "<td>$val</td>";
						$val = $row["header"];
					echo "<td>$val</td>";
						$val="ShowToolTip(".$row["id"].")";
					echo "<td><a href='javascript:;' id='showToolTip' onclick='$val'>Показать новость</a></td>";
						$val="newsInfo".$row["id"];
					echo "<tr class='contentNews'><td class='test' id='$val' colspan='3' style='display:none'>";
					$_GET["pressID"]=$row["id"];
					include ('php/forms/PressRealizeForm.php');
					echo "</td></tr>";
				echo "</tr>";
			 }
			
			mysql_free_result($result);
		}
}
	
	
	$controller = new Controller();
	
	$actionGet = $_GET['action'];
	$actionPost = $_POST['action'];
		
	if($actionGet=="send"){
		$res = $controller->SendEmail($_GET['id']);
		if($res==1)
			echo "<script>alert('Письмо отправлено успешно.');</script>"; 
	}
	
	if($actionPost=="save"){
		$res = $controller->SavePressRealize(unserialize($_POST['entity']));
	}
	
?>
