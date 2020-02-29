

<html>
    <head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="bootstrap.min.css" type="text/css">
  <script src="jquery-3.4.1.min.js"></script>
          
<script>
     	$ (document).ready(function(){
     		$("#btn").click(function(){
     			var username=$("#username").val();
                 var password=$("#password").val();
                 var email=$("#email").val();
                 if(username=="" || password=="")
                {
                      alert("please check your input");
                }
                else{
     			$.ajax({
                     type:"POST",
                      datatype:"json",
     				url:"signupTest.php",
                    data:{ 
                            "user":username,
                            "pass":password,
                            "email":email
                    },
                   
     				success:function(result)
     				{
                         console.log(result);
                         if(result == "1")
                         {
                          window.location.replace('login.php');
                         }
                         else{
                             alert('this username already exists');
                         }
     				},
                    error:function(result)
     				{
                        alert("error");
                         
                     }

                 });
                }
     		});

     	});
    </script>
    
    </head>
    <style>
   *{
     margin:0;
     padding:0;
     font-family: sans-serif;
   }
  .hero{
    height:100%;
    width:100%;
    background-image: linear-gradient(rgba(0,0,0,0.4),rgba(0,0,0,0.4)),url('nature.jpg');
    background-position: center;
    background-size: cover;
    position: absolute;
  }
  .form-box{
    width:380px;
    height:380px;
    position: relative;
    margin: 6% auto;
    background: #fff;
    padding: 5px;
    overflow: hidden;
  }
  .button-box{
    width: 220px;
    margin: 35px auto;
    position: relative;
    box-shadow: 0 0 20px  #ff61241f;
    border-radius: 30px;
  }
    #sign{
    top: 0;
    bottom: 0;
    position: absolute;
    width: 210px;
    height: 50px;
    background: linear-gradient(to right,#ff105f,#ffad06);
    border-radius: 30px;
    transition: .5s;
    text-align: center;
    padding-top: 10px;

  }
  .input-group{
    top: 100px;
    position: absolute;
    width: 280px;
    transition: .5s;
  }
  .inout-field{
    width: 100%
    padding: 10px 0;
    margin: 5px 0;
    border-left: 0;
    border-right: 0;
    border-top: 0;
    border-bottom: 1px solid #999;
    outline: none;
    background: transparent;
  }
  .submit-btn{
    width: 85%;
    padding: 10px 20px;
    cursor:pointer;
    display: block;
    margin: 25px 0px 30px 0px ;
    background: linear-gradient(to right,#ff105f,#ffad06);
    border: 0;
    outline: none;
    border-radius: 30px;
  }

</style>
<body>
    <div class="hero">
      <div class="form-box">
        <div class="button-box">
            <h3 id="sign">
            sign in page
          </h3>
            <div  class="input-group">
              <label>
                <input type="text" class="inout-field" name="username" id="username" placeholder="Name" required>
              </label>
              <label>
                <input type="text"  class="inout-field" name="email" id="email"  placeholder="login" required>
              </label>
              <label>
                <input type="password"  class="inout-field" name="password" id="password"  placeholder="password" required>
              </label>
              <button class="submit-btn" id="btn" name="btn">Sign in</button>
            </div>
        </div>
      </div>
    </div>

</body>
</html>
<!-- <body>


        <input type="text" name="username" id="username">
        <input type="text" name="email" id="email">
		<input type="password" name="password" id="password">
		<button id="btn" name="btn" type="submit">submit</button>
    </body> -->
</html>