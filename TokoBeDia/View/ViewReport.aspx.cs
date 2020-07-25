using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;
using TokoBeDia.Reporting;
using TokoBeDia.Dataset;

namespace TokoBeDia.View
{
    public partial class ViewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionReport newTR = new TransactionReport();
            CrystalReportViewer1.ReportSource = newTR;
            newTR.SetDataSource(GenerateData(HeaderTransactionController.gettAllHeaderTransaction()));
        }

        private DataSet1 GenerateData(List<HeaderTransaction> transactionList)
        {
            DataSet1 newDataSet = new DataSet1();
            var headerTransactionTable = newDataSet.HeaderTransaction;
            var detailTransactionTable = newDataSet.DetailTransaction;

            foreach(var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();
                headerTransactionRow["TransactionId"] = ht.ID;
                headerTransactionRow["Username"] = ht.User.Name;
                headerTransactionRow["PaymentType"] = ht.PaymentType.Type;
                headerTransactionRow["Date"] = ht.Date;
                headerTransactionTable.Rows.Add(headerTransactionRow);

                foreach(var dt in ht.DetailTransactions)
                {
                    int Subtotal = dt.Product.Price * dt.Quantity;

                    var detailTransactionRow = detailTransactionTable.NewRow();
                    detailTransactionRow["TransactionId"] = dt.TransactionID;
                    detailTransactionRow["ProductName"] = dt.Product.Name;
                    detailTransactionRow["Quantity"] = dt.Quantity;
                    detailTransactionRow["Price"] = dt.Product.Price;
                    detailTransactionRow["Subtotal"] = Subtotal;

                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
            }
            return newDataSet;
        }
    }
}