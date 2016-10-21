<?PHP
 $user = $_POST["username"];
 $score = $_POST["Score"];
 
 $con = mysql_connect("localhost","pmgblgc_cronos","Powerword97") or ("Cannot connect!" . mysql_error());
 if(!$con)
 die('Could not connect: '.mysql_error());

 mysql_select_db("pmgblgc_accountinfo",$con) or die("could not load database".mysql_error());
 
 $sql = "UPDATE accaunt_info SET `HighScore`='".$score."' WHERE `Username` = '".$user."'";
 mysql_select_db('pmbgblgc_accountinfo');
 $retval = mysql_query( $sql, $con );
	if(! $retval )
	{
	  die('Could not update data: ' . mysql_error());
	}
	echo "Updated data successfully\n";
	mysql_close($conn);
?>