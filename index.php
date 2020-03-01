<?php
session_start();
if(!isset($_SESSION['id']))
{
    header('Location:login.php');
}
$fId=null;
$_SESSION['FileId']=null;
echo $fId;
?>
<!DOCTYPE html>
<html>
<head>
    <META NAME="viewport" Content="width=device-width initial-scale=1">
    <link rel="stylesheet" href="bootstrap.min.css">
    <script src="jquery-3.4.1.min.js"></script>
    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>
<!--    <style>-->
<!--        p {-->
<!--            width: 50px;-->
<!--            padding: 0 20px;-->
<!--            margin: 0;-->
<!--            word-break: keep-all;-->
<!--            text-align: center;-->
<!--        }-->
<!--    </style>-->
</head>
<body>
<div class="modal" id="customModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">FOLDER</h4>
            </div>
            <form id="form" method="post">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="folder">Folder Name</label>
                        <input type="text" class="form-control" onkeyup="checkInput()"  name="folder" id="folder" required>
                        <p><span  id="error" style="color:red;"></span></p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary btn-md " id="close" onclick="close()" data-dismiss="modal">DISMISS</button>
                    <button class="btn btn-info btn-md " id="btn" onclick="Ajax()">CREATE</button>
                </div>
        </div>
        </form>
    </div>
</div>
<div class="container">
    <div class="text-center mt-3 mb-3">
        <a href="logout.php"><button type="button" class="btn btn-info">LogOut</button></a>
        <input type="hidden" id='user_id' value="<?php echo $_SESSION['id']?>">
        <button  onclick="show()" class="btn btn-dark">CREATE FOLDER</button>
    </div>
</div>
<div id="Maindiv" class="text-center">
    <div style='font-size: 35px'>Your Folders.....</div>
</div>

</body>
</html>
<script>
    let result;
    let SelectedId=null;
    $('document').ready(fetchFiles(null));
    function close()
    {
        document.getElementById('folder').value='';
        $('#customModal').modal('hide');
    }
    function show()
    {
        document.getElementById('error').innerText="";
        $('#customModal').modal('show');
    }
    function Ajax()
    {
        var str1= $('#folder').val();
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function() {
            //alert("heloo");
            if (this.readyState == 4 && this.status == 200) {
                alert(this.responseText);
                if(this.responseText)
                {
                    //alert('hi');
                    close();
                    window.stop();
                    fetchFiles(this.responseText);
                }
                else
                {
                    //alert('bye');
                    //fetchFiles(null);
                    //close();
                }
            }
        };
        if(SelectedId==null)
        {
            xmlhttp.open("GET","insertFolder.php?fName="+str1+"&pId",true);
            xmlhttp.send();
        }
        else
        {
            xmlhttp.open("GET","insertFolder.php?fName="+str1+"&pId="+SelectedId,true);
            xmlhttp.send();
        }
    }
    function fetchFiles(i)
    {

        var txt='';
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200){
                $("#Maindiv").empty();
                myObj = JSON.parse(this.responseText);
                var mainDiv=document.getElementById('Maindiv');
                for (x in myObj) {
                    var div1 = document.createElement('div');
                    div1.setAttribute('id', myObj[x].FolderID);
                    div1.style='word-wrap: break-word';
                    div1.style.minWidth='70px';
                    div1.className="btn btn-primary mt-1"
                    div1.innerHTML = myObj[x].FolderName;
                    mainDiv.append(div1);
                    mainDiv.append(document.createElement("br"));
                    div1.onclick=  function(event)
                    {
                        var ele=document.getElementById(event.target.id);
                        ele.style.backgroundColor='salmon';
                    }
                    div1.ondblclick=function(event)
                    {
                        //alert('dbl');
                        fetchFiles(event.target.id);
                    }
                }
            }
        };
        if(i==null)
        {
            xhttp.open("GET","fetchFoldersData.php?id=",true);
            xhttp.send();
        }
        else
        {
            xhttp.open("GET","fetchFoldersData.php?id="+i,true);
            xhttp.send();
        }
    }
    function checkInput()
    {
        var input=document.getElementById('folder').value;
        var letters = /^[0-9a-zA-Z]+$/;
        if (letters.test(input))
        {
            document.getElementById('error').innerText="";
            document.getElementById('btn').disabled=false;
            return true;
        }
        else
        {
            document.getElementById('error').innerText="Not a valid username"
            document.getElementById('btn').disabled=true;
            return false;
        }
    }
</script>