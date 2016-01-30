using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MulServiceReference;
//using ServiceReference1;

public partial class MulForm : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiServiceClient MSC = new MultiServiceClient("BasicHttpBinding_IMultiService");
        Response.Write(MSC.GetData(5, 10));

    }
}