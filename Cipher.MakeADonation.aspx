<%@ Page Title="" Language="C#" MasterPageFile="~/CipherMasterPage.master" AutoEventWireup="true" CodeFile="Cipher.MakeADonation.aspx.cs" Inherits="Cipher_MakeADonation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <html xmlns="http://www.w3.org/1999/xhtml" />

    <h3>Our Donors are the Difference</h3>
    <p id="donationPitch">&nbsp;&nbsp;&nbsp;Thank you so much for your interest in investing in our work and for your willingness to help change lives and communities as a next-generation philanthropist. We welcome you to become a Dream Team Member, influencing our work as a monthly donor. Members of the Dream Team help support WBL’s  general operations and sustain our day-to-day work in a broad way.

        <br /><br />&nbsp;&nbsp;&nbsp;Some people have a passion for a specific part of our work, like teaching or writing.  Your gift of $25-$250 can Support our Classrooms in the Words Beats & Life Academy, our free after school and summer program for youth 14-23. If you’re feeling even more generous, you can Create a Scholarship at $500-$1,000 to help send our program participants off to college. Where you choose to invest your time and money it’s an extension of who you are and what you value. Words Beats & Life encourages personal and community transformation through giving and wants to give you the choice to define your contribution.</p>

    <div id="vimeoDon">
        <iframe src="https://player.vimeo.com/video/121376268" width="500" height="275" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
    </div>

    <br />
        <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
            <%--<img src="<%=MakeImageSrcData("C:/Users/lee2rm/Desktop/Top484CS-master5/Top484CS-master/img/paypalprocess.png") %>" />
            --%><br /><br /><input type="hidden" name="cmd" value="_donations">
            <input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com">
            <input type="hidden" name="lc" value="US">
            <input type="hidden" name="item_name" value="Words Beats and Life, Inc">
            <input type="hidden" name="item_number" value="WBL">
            <input type="hidden" name="no_note" value="0">
            <input type="hidden" name="currency_code" value="USD">
            <input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest">
            <input id="payp" type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
            <img  alt="Responsive image" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1" >
        </form>


</asp:Content>

