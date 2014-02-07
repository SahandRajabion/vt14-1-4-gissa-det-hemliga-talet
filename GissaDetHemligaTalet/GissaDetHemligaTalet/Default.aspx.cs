using GissaDetHemligaTalet.Model.SecretNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GissaDetHemligaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        //Egenskap
        private SecretNumber SecretNumber
        {
            get
            {   /*Gör så att det ej skapas ett nytt objekt för användaren , så länge "SecretNumber retunerar "null".
                 * Och användaren är på samma "runda" av spelet fortfarande. Annars behålls samma objekt och samma 
                 * omgång fram till dess att session variabeln fått ett annat värde*/
                if (Session["SecretNumber"] == null)
                {
                    Session["SecretNumber"] = new SecretNumber();
                }
                return Session["SecretNumber"] as SecretNumber;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (IsValid) {
               //Tolkar om inmatningen till en int
                int input = int.Parse(TextBox1.Text);
                Outcome val = SecretNumber.MakeGuess(input);
                guesses.Text = string.Join(" ,   ", SecretNumber.PreviousGuesses);
                PlaceHolder1.Visible = true;
                
                //Om gissningen var för hög.
                if (val == Outcome.High)
                {
                    guesses.Text += String.Format("   Är för högt, ange ett mindre tal!");
                }
                //Om gissningen var för låg. 
                else if (val == Outcome.Low)
                {
                    guesses.Text += String.Format("   Är för lågt, ange ett högre tal!");
                }
                //Om gissningen var rätt.
                else if (val == Outcome.Correct)
                {
                    guesses.Text += String.Format("<img src=Pictures/check.png />   Grattis du klarade det på {0} försök!", SecretNumber.Count);
                    TextBox1.Enabled = false;
                    Button1.Enabled = false;
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = true;
                    Button2.Visible = true;
                }

                //Validerar om talet gissats tidigare och visar "felmeddelande".
                else if (val == Outcome.PreviousGuess)
                {
                    guesses.Text += String.Format("   Du har redan gissat på talet!");
                }

                //Inga fler gissningar kan göras och det hemliga talet presenteras.
                else if (val == Outcome.NoMoreGuesses)
                {
                    guesses.Text = String.Format("<img src=Pictures/close.png />   Du har inga gissningar kvar. Det hemliga talet var {0}", SecretNumber.Number);
                    TextBox1.Enabled = false;
                    Button1.Enabled = false;
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = true;
                    Button2.Visible = true;

                }

            }

        }
        //Rensar allt och skickar tillbaka användaren till förstasidan.
        protected void Button2_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }

    }
}