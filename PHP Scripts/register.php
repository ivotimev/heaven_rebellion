<?PHP
 $user = $_POST["username"];
 $name = $_POST["name"];
 $pass = $_POST["password"];
 
 $con = mysql_connect("localhost","pmgblgc_cronos","Powerword97") or ("Cannot connect!" . mysql_error());
 if(!$con)
 die('Could not connect: '.mysql_error());

 mysql_select_db("pmgblgc_accountinfo",$con) or die("could not load database".mysql_error());
 
 $check = mysql_query("SELECT * FROM accaunt_info WHERE `Username` = '".$user."'");
 $numrows = mysql_num_rows($check);
 if($numrows == 0)
 {
	 $ins = mysql_query("INSERT INTO `accaunt_info`(`ID`, `Name`, `Username`, `Password`,`Valor`, `HighScore`, `qStage`, `wStage`, `eStage`,`rStage`) VALUES ('','".$name."','".$user."','".$pass."','0','0','0','0','0','0')");
	 if($ins)
		 die("Sucessfully created user!");
	 else
		 die("Error:".mysql_error());
 }
 else
 {
	 die("User already exists!");
 }
?>