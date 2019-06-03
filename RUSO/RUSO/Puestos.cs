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
	public partial class Puestos : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=importadora;");
		string usuario;
		string level;
		string operacion;
		public Puestos(string user, string nivel)
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
			codigo.CommandText = ("SELECT * FROM puestos");
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

		private void Puestos_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Puestos_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO puestos(puesto) VALUES ('" + txtPuesto.Text + "')";
			operacion = "INSERT INTO puestos(puesto) VALUES (" + txtPuesto.Text + ")";

            databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (txtPuesto.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					txtPuesto.Text = "";
					databaseConnection.Close();
					llenartabla();

				}
				else { MessageBox.Show("POR FAVOR LLENE EL CAMPO.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!!\nVerifique: Los datos.\n\tGRACIAS!!"+ ex.ToString());
				databaseConnection.Close();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string query = "DELETE FROM puestos WHERE cod_puesto =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM puestos WHERE cod_puesto =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                txtPuesto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string query = "UPDATE puestos SET puesto ='" + txtPuesto.Text + "' WHERE  cod_puesto =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE puestos SET puesto =" + txtPuesto.Text + " WHERE  cod_puesto =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (txtPuesto.Text != "" )
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);				
					txtPuesto.Text = "";
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

        private void txtPuesto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}