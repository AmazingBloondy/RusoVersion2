using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RUSO
{
	public partial class LogIn : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=importadora;");     
        //Conexion con BD online
        // "datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530"
		int log;
		public LogIn()
		{
			InitializeComponent();
			databaseConnection.Open();
		}

		void logl(string queryin)
		{
			string query = "INSERT INTO log (Usuario,operacion,fecha) VALUES ('" + usrtxt.Text + "','" + queryin + "','" + DateTime.Now.ToString("G") + "')";
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{

				consulta.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
                MessageBox.Show("Error! \n\n " + ex.ToString());
			}
		}
		string nivel()
		{
			string nivel = "";
			MySqlConnection databaseConnection2 = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username =root; password =; database =importadora");
			string query = "SELECT * FROM `usuarios` WHERE Usuario = MD5('" + usrtxt.Text + "') AND Password = MD5('" + pastxt.Text + "')";
			MySqlCommand consultanivel = new MySqlCommand(query, databaseConnection2);
			consultanivel.CommandTimeout = 60;
			try
			{
				databaseConnection2.Open();
				MySqlDataReader Reader = consultanivel.ExecuteReader();
				if (Reader.HasRows)
				{
					while (Reader.Read())
					{
						nivel = Reader.GetString(2);
					}
				}
				else { MessageBox.Show("ERROR"); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR" + ex.ToString());

			}
			databaseConnection.Close();
			return nivel;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		
		private void button1_Click(object sender, EventArgs e)
		{
			log = 0;
			string query = "SELECT * FROM `usuarios` WHERE Usuario = MD5('" + usrtxt.Text + "') AND Password = MD5('" + pastxt.Text + "')";
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				consulta.ExecuteNonQuery();
				DataTable respuesta = new DataTable();
				MySqlDataAdapter datos = new MySqlDataAdapter(consulta);
				datos.Fill(respuesta);
				log = Convert.ToInt32(respuesta.Rows.Count.ToString());
				if (log == 1)
				{
					logl("LOG IN");
					if (nivel() == "SysAdmin") { LOG bitacora = new LOG(usrtxt.Text, nivel()); bitacora.Show(); }
					else
					{ MainMenu menu = new MainMenu(usrtxt.Text, nivel()); menu.Show(); }
					this.Hide();
					databaseConnection.Close();
				}
				else
				{
					MessageBox.Show("Datos Incorrectos, Intente de nuevo! "); 
                }

			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR" + ex.ToString());
				databaseConnection.Close();
			}
		}

		private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}