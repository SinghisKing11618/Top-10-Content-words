using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void button1_Click(object sender, EventArgs e)
        {

           ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();
            string input = Input.Text;

            string[] topWords = prxy.Top10ContentWords(input);
           
            Label1.Text = string.Join(", ", topWords);


        }

        protected void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();
            if (prxy.isPalindrome(InputPalindrome.Text))
            {
                Label2.Text = "TRUE";
            }
            else
            {
                Label2.Text = "FALSE";
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();

            Label3.Text = prxy.sort(InputSort.Text);

        }

        protected void button4_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client prxy = new ServiceReference2.Service1Client();
            
            Label4.Text = prxy.stemming(InputStem.Text);
        }
    }
}