<?PHP
 $user = $_POST["username"];
 
 $con = mysql_connect("localhost","pmgblgc_cronos","Powerword97") or ("Cannot connect!" . mysql_error());
 if(!$con)
	die('Could not connect: '.mysql_error());

 mysql_select_db("pmgblgc_accountinfo",$con) or die("could not load database".mysql_error());
 
 $check = mysql_query("SELECT * FROM accaunt_info WHERE `Username` = '".$user."'");
 $numrows = mysql_num_rows($check);
 if($numrows == 0)
 {
	 die("Username does not exist!");
 }
 else
 {
	 while($row = mysql_fetch_assoc($check))
	 {
		$highestScore = $row['HighScore'];
		die($highestScore);
	 
	 }
 }
?>