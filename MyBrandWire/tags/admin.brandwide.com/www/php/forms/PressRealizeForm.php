<?php
	include_once "controller.php"
?>
<head>
		<meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
		<script type="text/JavaScript" src="test.js"></script> 
		<style type="text/css">
			input[type="text"] { 
									width:100%;
								}
			span {
				color: blue;
				font-weight: bold; 
			}
		</style>
</head>

<body>
<form action="#" method="post" action="controller.php">
	<span>Содержимое новости :</span>	
	<table>
		<?php
			$controller = new Controller();
			$pressRealize = $controller->GetPressRealizeById($_GET['pressID']);
			$val = serialize($pressRealize);
			
			echo "<tr><td width='20%'>Название : </td><td width='80%'><input type='text' name='header' value='$pressRealize->header'></td>
			</tr><tr width='90%'><td>Содержание : </td><td><input type='text' name='content' value='$pressRealize->content'/></td></tr>
			<tr><input type='hidden' name='entity' value='$val'/></tr>";
			
		?>
		
		<tr>
			<td colspan="2" align="right"><input type="submit" value="Сохранить"/></td>
		</tr>
		<tr><input type="hidden" name="action" value="save"/></tr>
		
	</table>
	
 </form>
 
 </body>
 
