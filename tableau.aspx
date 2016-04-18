<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="tableau.aspx.cs" Inherits="tableau" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <html xmlns="http://www.w3.org/1999/xhtml" >


    


<body>


    <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_donations">
<input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com">
<input type="hidden" name="lc" value="US">
<input type="hidden" name="item_name" value="Words Beats and Life, Inc">
<input type="hidden" name="item_number" value="WBL">
<input type="hidden" name="no_note" value="0">
<input type="hidden" name="currency_code" value="USD">
<input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest">
<input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>




    <%--TABLEAU STUFF BELOW--%>

    <%--<form id="form1" runat="server">
        <script type='text/javascript' src='http://myserver/javascripts/api/viz_v1.js'></script> 
        <div class='tableauPlaceholder' style='width:800; height:600;'> 
        <object class='tableauViz' width='800px' height='600px' style='display:none;'>
        <param name="host_url" value="http://localhost:61157"> 
        <param name='site_root' value='http://localhost:61157/Top484CS-master/tableau.aspx' /> 
        <param name='name' value='Users\lee2rm\Desktop\prototype' /> 
        <param name='tabs' value='yes' /> 
        <param name='toolbar' value='yes' /></object></div>
    --%></form>
</body>
</html>

</asp:Content>

