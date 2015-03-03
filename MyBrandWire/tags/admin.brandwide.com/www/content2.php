<?php
	include_once 'controller.php';  
?>
<head>
		<meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
		<link rel="stylesheet" href="styleContents.css" type="text/css" />
		<script type="text/JavaScript" src="test.js"></script> 
</head>

<body>

	<table id="tbContent" cellpadding="0" cellspacing="0">
	
		<tr>
			<td width="5%">Номер</td>
			<td width="75%">Название</td>
			<td width="20%">Функции</td>
		</tr>
		
		<?php 
			$controller = new Controller();
			$controller->PrintAllCheckedPressRealise();
		?>
		
	</table>
</body>

