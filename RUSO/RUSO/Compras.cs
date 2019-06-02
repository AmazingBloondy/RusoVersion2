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
	public partial class Compras : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		string usuario;
		string level;
		string operacion;
		public Compras(string user, string nivel)
		{
			InitializeComponent();
			label27.Text = user;
			llenartabla(); // funcion para el llenado de tabla y combobox
			usuario = user;
			level = nivel;
			actualizarbtn.Enabled = false; 
			//fecha con format aceptado por Msql
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "yyyy-MM-dd";
		}

		void llenartabla()
		{

			MySqlCommand codigo = new MySqlCommand();
			codigo.Connection = databaseConnection;
			codigo.CommandText = ("SELECT * FROM compras");
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
				comboBox1.Text = "EMPLEADOS";
				comboBox1.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM empleados", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					comboBox1.Refresh();
					comboBox1.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString()+ " "+ reader.GetValue(3).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				comboBox2.Text = "VEHICULOS";
				comboBox2.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM vehiculos", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					comboBox2.Refresh();
					comboBox2.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString() + " " + reader.GetValue(6).ToString() + " " + reader.GetValue(8).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				comboBox3.Text = "EXPORTADOR";
				comboBox3.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM exportadores", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					comboBox3.Refresh();
					comboBox3.Items.Add(reader.GetValue(1).ToString());
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

		private void Compras_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Compras_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			string query = "INSERT INTO compras(cod_empleado, cod_vehiculo, exportador, fecha_compra, precio_vehiculo_quetzales, precio_total_quetzales, precio_dolar) VALUES (" 
			+ comboBox1.Text[0] + "," + comboBox2.Text[0] + ",'" + comboBox3.Text +"','"+ dateTimePicker1.Text+"',"+ textBox1.Text+","+ textBox2.Text+",'"+textBox3.Text+"')";
			operacion = "INSERT INTO compras(cod_empleado, cod_vehiculo, exportador, fecha_compra, precio_vehiculo_quetzales, precio_total_quetzales, precio_dolar) VALUES ("
			+ comboBox1.Text[0] + "," + comboBox2.Text[0] + "," + comboBox3.Text + "," + dateTimePicker1.Text + "," + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + ")";

			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "EMPLEADOS" && comboBox2.Text != "VEHICULOS" && comboBox3.Text != "EXPORTADOR")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					textBox1.Text = "";
					textBox3.Text = "";
					textBox2.Text = "";
					databaseConnection.Close();
					llenartabla();

				}
				else { MessageBox.Show("POR FAVOR LLENE TODOS LOS CAMPOS.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!! \n\n " + ex.ToString());
				databaseConnection.Close();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string query = "DELETE FROM compras WHERE cod_compra =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM compras WHERE cod_compra =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
				comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
				dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
				textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
				textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
				textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string auxem = comboBox1.Text;
            string[] separarem;
            separarem = auxem.Split(' ');

            string auxve = comboBox2.Text;
            string[] separarve;
            separarve = auxve.Split(' ');            

            string query = "UPDATE compras SET cod_empleado =" + separarem[0] + ", cod_vehiculo = " + separarve[0] + ", exportador='" + comboBox3.Text + "'," +
            " fecha_compra= '" + dateTimePicker1.Text + "', precio_vehiculo_quetzales=" + textBox1.Text + ", precio_total_quetzales=" + textBox2.Text + ", precio_dolar='" + textBox3.Text + "' WHERE  cod_compra =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE compras SET cod_empleado =" + separarem[0] + ", cod_vehiculo = " + separarve[0] + ", exportador=" + comboBox3.Text + "," +
            " fecha_compra= " + dateTimePicker1.Text + ", precio_vehiculo_quetzales=" + textBox1.Text + ", precio_total_quetzales=" + textBox2.Text + ", precio_dolar=" + textBox3.Text + " WHERE  cod_compra =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					textBox1.Text = "";
					textBox2.Text = "";
					textBox3.Text = "";
					actualizarbtn.Enabled = false;
					ingresarbtn.Enabled = true;
					eliminarbtn.Enabled = true;

				}
				else { MessageBox.Show("POR FAVOR LLENE TODOS LOS CAMPOS.\n\tGRACIAS!!"); databaseConnection.Close(); }
			}
			catch (Exception ex)
			{
				MessageBox.Show("\tERROR!!\n\n " + ex.ToString());
				databaseConnection.Close();
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click_1(object sender, EventArgs e)
		{

		}
	}
}
