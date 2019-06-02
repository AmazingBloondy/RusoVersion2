using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RUSO
{
	public partial class LOG : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		public LOG(string user, string nivel)
		{
			InitializeComponent();
            llenartabla();
            userbita.Text = user;
		}

        void llenartabla()
        {
            MySqlCommand codigo = new MySqlCommand();
            codigo.Connection = databaseConnection;
            codigo.CommandText = ("SELECT * FROM log");
            try
            {
                MySqlDataAdapter ejecutar = new MySqlDataAdapter();
                ejecutar.SelectCommand = codigo;
                DataTable datostabla = new DataTable();
                ejecutar.Fill(datostabla);
                dataGridView1.DataSource = datostabla;
                ejecutar.Update(datostabla);
                databaseConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR" + e.ToString());
                databaseConnection.Close();
            }         
        }

        private void LOG_Load(object sender, EventArgs e)
		{

		}

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn nuevo = new LogIn();
            nuevo.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}