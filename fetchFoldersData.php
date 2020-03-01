<?php
session_start();

if ($_SERVER["REQUEST_METHOD"] == "GET") {

    $con = new mysqli('localhost', 'root', 'zombieworld', "drive");
    if (!$con) {
        die('Could not connect: ' . mysqli_error($con));
    }


    if ($_GET['id'] == null) {
        $sql = "SELECT * FROM folder WHERE userID=? And ParentFolderID IS NULL ";
        $stmt = $con->prepare($sql);
        $stmt->bind_param('i', $uID);
        $uID = $_SESSION['id'];
        $stmt->execute();
        $result = $stmt->get_result();
        $outp = $result->fetch_all(MYSQLI_ASSOC);
        echo json_encode($outp);

    } else {
        $sql = "SELECT * FROM folder WHERE userID=? And ParentFolderID=?"; // SQL with parameters
        $stmt = $con->prepare($sql);

        $stmt->bind_param('ii', $uID, $folderID);
        $uID = $_SESSION['id'];
        $_SESSION['FileId'] = $_GET['id'];
        $folderID = $_GET['id'];
        $stmt->execute();
        $result = $stmt->get_result();
        $outp = $result->fetch_all(MYSQLI_ASSOC);
        echo json_encode($outp);
    }
}
?>
