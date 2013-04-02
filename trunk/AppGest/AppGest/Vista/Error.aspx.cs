using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppGest.Vista
{
    public partial class Error : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
         
//#if DEBUG
//            Exception ex = Server.GetLastError().GetBaseException();

//            this.TextBox1.Text = ex.Message;
//#else
//            this.TextBox1.Visible = false;
//#endif

        }
    }
}