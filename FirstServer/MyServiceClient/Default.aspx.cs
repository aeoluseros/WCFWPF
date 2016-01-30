using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyServiceReference;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e)
    {
        MyServiceClient c = new MyServiceClient();
        GridView1.DataSource = c.GetAllEmployees();
        GridView1.DataBind();
    }
}