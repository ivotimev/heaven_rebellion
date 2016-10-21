<?PHP 
 $con = mysql_connect("localhost","pmgblgc_cronos","Powerword97") or ("Cannot connect!" . mysql_error());
 if(!$con)
	die('Could not connect: '.mysql_error());

 mysql_select_db("pmgblgc_accountinfo",$con) or die("could not load database".mysql_error());
 
 $highScoresArray = Array();
 
 $querry1 = mysql_query("SELECT Username, HighScore FROM accaunt_info ORDER BY HighScore DESC",$con);
 
 $resultstring="";
 
 $i = 1;
 while ($row = mysql_fetch_assoc($querry1)) {
	$resultstring = $resultstring."\n".$i.".".$row['Username']." - ".$row['HighScore'];
	$i = $i+1;
 }

die($resultstring);
 
?>