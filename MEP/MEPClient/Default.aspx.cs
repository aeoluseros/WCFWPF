using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MEPServiceReference;

public class MEPCallBack : IMEPCallback {
    public void SendEmailCallBack(string toAddress) {
        var con = new SqlConnection("Data Source=.;Initial Catalog=NETTest;Integrated Security=True");
        var cmd = new SqlCommand("UPDATE UserRegistration SET EmailSentFlag = 'Y' WHERE UserEmail = @userEmail", con);
        cmd.Parameters.AddWithValue("@userEmail", toAddress.ToString());
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {

    }

    protected void Button1_Click(object sender, EventArgs e) {
        try
        {
            //MEPClient c = new MEPClient();
            var context = new InstanceContext(new MEPCallBack());
            MEPClient c = new MEPClient(context);

            var con = new SqlConnection("Data Source=.;Initial Catalog=NETTest;Integrated Security=True");
            var cmd = new SqlCommand("INSERT INTO UserRegistration(UserEmail) VALUES(@userEmail)", con);
            cmd.Parameters.AddWithValue("@userEmail", txtUserEmail.Text.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            c.sendEmail(txtUserEmail.Text.ToString());
            GridView1.DataBind();
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }
    }
}