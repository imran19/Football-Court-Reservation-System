using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCRS
{
    public partial class ProceedToPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PayWithPayPal(string amount, string itemInfo, string name,
          string phone, string email, string currency)
        {
            string redirecturl = "";

            //Mention URL to redirect content to paypal site
            redirecturl += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" +
                           ConfigurationManager.AppSettings["paypalemail"].ToString();

            //First name i assign static based on login details assign this value
            redirecturl += "&first_name=" + name;

            //City i assign static based on login user detail you change this value
            redirecturl += "&city=bhubaneswar";

            //State i assign static based on login user detail you change this value
            redirecturl += "&state=Odisha";

            //Product Name
            redirecturl += "&item_name=" + itemInfo;

            //Product Name
            redirecturl += "&amount=" + amount;

            //Phone No
            redirecturl += "&night_phone_a=" + phone;

            //Product Name
            redirecturl += "&item_name=" + itemInfo;

            //Address 
            redirecturl += "&address1=" + email;

            //Business contact id
            // redirecturl += "&business=k.tapankumar@gmail.com";

            //Shipping charges if any
            redirecturl += "&shipping=0";

            //Handling charges if any
            redirecturl += "&handling=0";

            //Tax amount if any
            redirecturl += "&tax=0";

            //Add quatity i added one only statically 
            redirecturl += "&quantity=1";

            //Currency code 
            redirecturl += "&currency=" + currency;

            //Success return page url
            redirecturl += "&return=" +
              ConfigurationManager.AppSettings["SuccessURL"].ToString();

            //Failed return page url
            redirecturl += "&cancel_return=" +
              ConfigurationManager.AppSettings["FailedURL"].ToString();

            Response.Redirect(redirecturl);
        }







    }
}