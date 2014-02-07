<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaDetHemligaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa Det Hemliga Talet</title>
    <link href ="~/Content/BJ.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <h1>Gissa det hemliga talet</h1>
   
    <!--Presenterar felmeddelanden i list-form-->    
    <div id ="summary">
    <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="field-validation-error" HeaderText="Fel inträffade. Åtgärda felen och försök igen."/>
    </div>
   
    <span id="secret">Ange ett tal mellan 1 och 100:</span>
    
    <!--Presenterar Textboxen-->        
    <div id="textbox">
    <asp:TextBox ID="TextBox1" runat="server" Enabled="true"></asp:TextBox>
    
    <!--Validering av TextBox-->  
    <asp:RangeValidator ID="RangeValidator1" runat="server" Text="*" CssClass="field-validation-error" ErrorMessage="Det hemliga talet måste ligga mellan 1 och 100." MaximumValue="100" MinimumValue="1" Display="Dynamic" Type="Integer" ControlToValidate="TextBox1"></asp:RangeValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="*" CssClass="field-validation-error" runat="server" ErrorMessage="Ett tal måste anges" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
        
    <!--Presenterar första knappen för gissning av hemligt tal-->  
    <div id="button1">   
    <asp:Button ID="Button1" runat="server" Text="Skicka gissning" OnClick="Button1_Click" Enabled="true"/>
    </div>
 
    <!--Presenterar andra knappen för nytt hemligt tal efter 7 fel försök-->  
    <div id="button2">
    <asp:Button ID="Button2" runat="server" Text="Slumpa nytt hemligt tal" OnClick="Button2_Click" Visible="false" CausesValidation="false"/>
    </div>

    <div id="place1">
    <!-- Presentation av användarens gissningar-->
	<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
	<p><asp:Label ID="guesses" runat="server" Text=""></asp:Label></p>
    </asp:PlaceHolder>
   </div>
    <div id="place2">
    <!-- Presentation av resultat-->
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
	<p><asp:Label ID="Result" runat="server" Text=""></asp:Label></p>
	</asp:PlaceHolder>
    </div>
</form>

    <!--Focus på textboxen med hjälp av javascript kod-->
      <script type="text/javascript">
          var textBox = document.getElementById("TextBox1");
          TextBox1.focus();
          TextBox1.select();
      </script>
</body>
</html>



			