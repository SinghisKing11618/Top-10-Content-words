<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WcfService1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Type in either a string, text file, or URL and the service will return the top 10 frequent words </p>
            <p>For example: https://en.wikipedia.org/wiki/The_Dark_Knight put this in</p>
            <asp:TextBox ID="Input" runat="server"></asp:TextBox>
            <asp:Button ID="button1" runat="server" Text="MostFrequent" OnClick="button1_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>


            <p> </p>
            <p> Will return true or false if the string is a palindrome. Works only with alphabetical words. No numbers </p>
            <asp:TextBox ID="InputPalindrome" runat="server"></asp:TextBox>
            <asp:Button ID="button2" runat="server" Text="Palindrome" OnClick="button2_Click" />
             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

            <p> </p>
            <p>This is an implementation of quick sort...type in your numbers with format 1,2,3,4. You may also use - numbers  </p>
            <asp:TextBox ID="InputSort" runat="server"></asp:TextBox>
            <asp:Button ID="button3" runat="server" Text="quickSort" OnClick="button3_Click" />
             <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

            </p>
            <p>will return the stem of the word: running becomes run</p>
            <asp:TextBox ID="InputStem" runat="server"></asp:TextBox>
            <asp:Button ID="button4" runat="server" Text="find stem of word" OnClick="button4_Click" />
             <asp:Label ID="Label4" runat="server" Text=""></asp:Label>

        </div>


        <br />


        

    </form>
</body>
</html>
