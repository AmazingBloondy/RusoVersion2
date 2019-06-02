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
	public partial class Vehiculo : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		string usuario;
		string level;
		string operacion;
		public Vehiculo(string user, string nivel)
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
			codigo.CommandText = ("SELECT * FROM vehiculos");
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

			try
			{
				comboBox1.Text = "MARCAS";
				comboBox1.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM marcas", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					comboBox1.Refresh();
					comboBox1.Items.Add(reader.GetValue(1).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				comboBox2.Text = "TRANSMISION";
				comboBox2.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM transmisiones", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					comboBox2.Refresh();
					comboBox2.Items.Add(reader.GetValue(1).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();
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

		private void Vehiculo_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Vehiculo_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO vehiculos(marca, modelo, transmision, millas, vin, anio, cc, color)" +
			" VALUES ('" + comboBox1.Text + "','" + modelo.Text + "','" + comboBox2.Text + "'," + millas.Text + ",'" + vin.Text + "'," + anio.Text + ",'" + cc.Text + "','" + color.Text +"')";
			operacion = "INSERT INTO vehiculos(marca, modelo, transmision, millas, vin, anio, cc, color)" +
			" VALUES (" + comboBox1.Text + "," + modelo.Text + "," + comboBox2.Text + "," + millas.Text + "," + vin.Text + "," + anio.Text + "," + cc.Text + "," + color.Text + ")";
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (millas.Text != "" && modelo.Text != "" && vin.Text != "" )
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					millas.Text = "";
					vin.Text = "";
					modelo.Text = "";
					anio.Text = "";
					color.Text = "";
					cc.Text = "";
					databaseConnection.Close();
					llenartabla();
				}
				else { MessageBox.Show("POR FAVOR LLENE TODOS LOS CAMPOS.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!!\nVerifique: Los datos.\n\tGRACIAS!!"+ ex.ToString());
				databaseConnection.Close();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string query = "DELETE FROM vehiculos WHERE cod_vehiculo =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM vehiculos WHERE cod_vehiculo =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				modelo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
				millas.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
				vin.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
				anio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
				cc.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
				color.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                //MessageBox.Show("El codigo tiene: " + codaux);
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

        private void actualizarbtn_Click(object sender, EventArgs e)
        {
            string query = "UPDATE vehiculos SET marca= '" + comboBox1.Text + "', modelo='" + modelo.Text +
                "',transmision='" + comboBox2.Text + "',millas=" + millas.Text + ",vin='" + vin.Text + "',anio=" + anio.Text + ",cc='" + cc.Text + "',color='" + color.Text +
                "' WHERE cod_vehiculo=" + codaux;   //dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE vehiculos SET marca= " + comboBox1.Text + ", modelo=" + modelo.Text +
                ",transmision=" + comboBox2.Text + ",millas=" + millas.Text + ",vin=" + vin.Text + ",anio=" + anio.Text + ",cc=" + cc.Text +
                ",color=" + color.Text + " WHERE cod_vehiculo=" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString(); ;

            databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (millas.Text != "" && modelo.Text != "" && vin.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					millas.Text = "";
					modelo.Text = "";
					vin.Text = "";
					anio.Text = "";
					color.Text = "";
					cc.Text = "";
					actualizarbtn.Enabled = false;
					ingresarbtn.Enabled = true;
					eliminarbtn.Enabled = true;

				}
				else { MessageBox.Show("POR FAVOR LLENE TODOS LOS CAMPOS.\n\tGRACIAS!!"); databaseConnection.Close(); }
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
	}
}