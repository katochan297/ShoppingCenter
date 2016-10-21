<?php
	$to = "katochan.developer@gmail.com"; /*Your Email*/
	$subject = "Messsage from ShoppingCenter"; /*Issue*/
	$date = date ("l, F jS, Y"); 
	$time = date ("h:i A"); 	
	$Email=$_GET['email'];
	$Name=$_GET['name'];
	$Message=$_GET['message'];

	$msg="Message sent\n
	Email : $Email\n
	Name : $Name\n
	Message : $Message\n";

	
	mail($to, $subject, $msg, "From: $_GET[email]");
	echo "<div class='alert alert-success'>Thank you for your message :D</div>";		
	
?>
