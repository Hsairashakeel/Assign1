<?php
session_start();
if ($_SERVER["REQUEST_METHOD"] == "GET") {
    $parentId=$_GET['pId'];
    $id = $_SESSION['id'];
    if($parentId==null)
    {
        $parentId=$_SESSION['FileId'];
    }
    $con = new mysqli('localhost', 'root', 'zombieworld', "drive");
    if (!$con) {
        die('Could not connect: ' . mysqli_error($con));
    }

    $stmt = $con->prepare("INSERT INTO folder (FolderName, ParentFolderID, userID) VALUES (?, ?, ?)");
    $stmt->bind_param("ssi", $fName, $pFName, $uId);
    $fName = $_GET['fName'];
    $pFName = $parentId;
    $uId = $_SESSION['id'];
    $result=false;
    $result=$stmt->execute();
    $_SESSION['FileId']=$parentId;
   echo $_SESSION['FileId'];
}