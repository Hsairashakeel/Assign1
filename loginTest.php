<?php
session_start();

$connection= mysqli_connect("localhost","root","","users");
if(!$connection){
    die("Connection failed :" .mysqli_connect_error());
}
?>
<?php
$error="";
$username=$_REQUEST["usernamePHP"];
$password=$_REQUEST["passwordPHP"];
$sql= "SELECT username , password FROM users
WHERE username='$username' AND password='$password'";
$result=mysqli_query($connection,$sql);
$resultset=mysqli_num_rows($result);
if($resultset<=0){
    $_SESSION["user"]="";
    $error="invalid";
    echo "0";
}
else{
    $_SESSION["user"]=$username;
    echo "1";
}
?>