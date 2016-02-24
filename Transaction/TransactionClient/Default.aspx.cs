using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using TransactionServiceReference;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnCreate_Click(object sender, EventArgs e) {
        try {
            using (TransactionScope ts = new TransactionScope()) {
                var transClient = new TransactionServiceClient();
                int id =
                    transClient.CreateEmployee(new Employee() {
                        EName = txtEmployeeName.Text,
                        ESalary = double.Parse(txtEmployeeSalary.Text)
                    });
                //if (id != 0) {
                    transClient.CreateSalaryHistory(new SalaryHistory() {
                //        Eid = id,
                        ESalary = double.Parse(txtEmployeeSalary.Text),
                        StDate = DateTime.Now,
                        EndDate = null
                    });
                //}
                ts.Complete();
            }
        } catch (Exception Ex) {

        }
    }

    protected void txtEmployeeSalary_TextChanged(object sender, EventArgs e) {

    }
}