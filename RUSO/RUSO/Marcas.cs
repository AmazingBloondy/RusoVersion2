using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RUSO
{
	public partial class Marcas : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=importadora;");
		string usuario;
		string level;
		string operacion;
		public Marcas(string user, string nivel)
		{
			InitializeComponent();
			label27.Text = user;
			llenartabla();
			usuario = user;
			level = nivel;
			actualizarbtn.Enabled = false;
		}

		void llenartabla()
		{

			MySqlCommand codigo = new MySqlCommand();
			codigo.Connection = databaseConnection;
			codigo.CommandText = ("SELECT * FROM marcas");
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
		void log(string queryin)
		{
			string query = "INSERT INTO log (Usuario,operacion,fecha) VALUES ('" + usuario + "','" + queryin + "','" + DateTime.Now.ToString("G") + "')";
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{

				consulta.ExecuteNonQuery();
				databaseConnection.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR" + ex.ToString());
				databaseConnection.Close();
			}
		}

		private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Marcas_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}


		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainMenu nuevo = new MainMenu(usuario, level);
			nuevo.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			LogIn nuevo = new LogIn();
			nuevo.Show();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label28.Text = DateTime.Now.ToLongTimeString();
		}

		private void Marcas_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO marcas(marca) VALUES ('" + textBox2.Text + "')";
			operacion = "INSERT INTO marcas(marca) VALUES (" + textBox2.Text + ")";

			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (textBox2.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					textBox2.Text = "";
					databaseConnection.Close();
					llenartabla();

				}
				else { MessageBox.Show("POR FAVOR LLENE EL CAMPO.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!!\nVerifique: El dato.\n\tGRACIAS!!"+ ex.ToString());
				databaseConnection.Close();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string query = "DELETE FROM marcas WHERE cod_marca =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM marcas WHERE cod_marca =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (dataGridView1.SelectedRows.Count == 1)
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Eliminado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);

				}
				else { MessageBox.Show("Por favor Seleccione un registro"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR" + ex.ToString());
				databaseConnection.Close();
			}
		}
        string codaux;
		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				actualizarbtn.Enabled = true;
				ingresarbtn.Enabled = false;
				eliminarbtn.Enabled = false;
                codaux = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string query = "UPDATE marcas SET marca ='" + textBox2.Text + "' WHERE  cod_marca =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE marcas SET marca =" + textBox2.Text + " WHERE  cod_marca =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (textBox2.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					textBox2.Text = "";
					actualizarbtn.Enabled = false;
					ingresarbtn.Enabled = true;
					eliminarbtn.Enabled = true;

				}
				else { MessageBox.Show("POR FAVOR LLENE EL CAMPO.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!!\nVerifique:\n-Codigo no repetido.\n-Dpi No repetido.\n\tGRACIAS!!" + ex.ToString());
				databaseConnection.Close();
			}
		}

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}