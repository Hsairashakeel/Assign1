<?php
session_start();
$connection= mysqli_connect("localhost","root","","users");
if(!$connection){
    die("Connection failed :" .mysqli_connect_error());
}
$error="";
$username=$_REQUEST["user"];
$password=$_REQUEST["pass"];
 $email=$_REQUEST["email"];
 $sql= "SELECT username , email FROM users
WHERE username='$username' AND email='$email'";
$result=mysqli_query($connection,$sql);
$resultset=mysqli_num_rows($result);
if($resultset<=0)
{    
$sql = "INSERT INTO  users(username, email, password)
VALUES ('$username', '$email', '$password')";
 mysqli_query($connection,$sql);
 echo "1";
}
else{
    echo "0";
}
?>