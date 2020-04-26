using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;    
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public partial class Form1 : Form
    {
        private OleDbDataAdapter booksDataAdapter;  // DataAdapter object
        private DataSet booksDS;                    // DataSet object
        private OleDbCommandBuilder cBuilder;       // CommandBuilder object
        private OleDbConnection dbConn;             // DB Connection object
        private OleDbCommand dbCmd;                 // DB Command object
        private string sConnection;                 // DB Connection string
        private string sql;                         // DB Query string

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantiate OLE DB Connection
            sConnection =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=Books.accdb";
            dbConn = new OleDbConnection(sConnection);
            booksDataAdapter = new OleDbDataAdapter();
            // TODO: This line of code loads data into the 'mMABooksDataSet.Invoices' table. You can move, or remove it, as needed.
            this.invoicesTableAdapter.Fill(this.mMABooksDataSet.Invoices);
            // TODO: This line of code loads data into the 'mMABooksDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);

        }
    }
}
