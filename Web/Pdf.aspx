<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdf.aspx.cs" Inherits="Web.Pdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type= "text/javascript">

Close();
// close the window without any prompt
function Close()
{
  
  var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
  if (ie)
  {
  
   
      window.close();
  }
}
 
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
