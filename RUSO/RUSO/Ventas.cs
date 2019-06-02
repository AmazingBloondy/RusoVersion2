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
	public partial class Ventas : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		string usuario;
		string level;
		string operacion;
		public Ventas(string user, string nivel)
		{
			InitializeComponent();
			label27.Text = user;
			llenartabla();
			usuario = user;
			level = nivel;
			actualizarbtn.Enabled = false;
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "yyyy-MM-dd";
		}

		void llenartabla()
		{

			MySqlCommand codigo = new MySqlCommand();
			codigo.Connection = databaseConnection;
			codigo.CommandText = ("SELECT * FROM ventas");
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
				empleado.Text = "EMPLEADO";
				empleado.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM empleados", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					empleado.Refresh();
					empleado.Items.Add(reader.GetValue(0).ToString()+" - "+reader.GetValue(1).ToString()+" "+reader.GetValue(3).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				vehiculo.Text = "VEHICULO";
				vehiculo.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM vehiculos", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					vehiculo.Refresh();
					vehiculo.Items.Add(reader.GetValue(0).ToString()+" "+reader.GetValue(1).ToString() + " " + reader.GetValue(8).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				cliente.Text = "CLIENTE";
				cliente.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM clientes", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					cliente.Refresh();
					cliente.Items.Add(reader.GetValue(0).ToString()+" "+ reader.GetValue(1).ToString()+" "+ reader.GetValue(2).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();
			try
			{
				pago.Text = "PAGO";
				pago.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM formas_pago", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					pago.Refresh();
					pago.Items.Add(reader.GetValue(1).ToString());
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

		private void Ventas_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Ventas_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO ventas(cod_empleado, cod_vehiculo, cod_cliente, fecha_venta , forma_pago,  precio_total)" +
			" VALUES (" + empleado.Text[0] + "," +vehiculo.Text[0] + "," + cliente.Text[0] + ",'" + dateTimePicker1.Text + "','" + pago.Text + "'," + precio.Text + ")";
			operacion = "INSERT INTO ventas(cod_empleado, cod_vehiculo, cod_cliente, fecha_venta , forma_pago,  precio_total)" +
			" VALUES (" + empleado.Text[0] + "," + vehiculo.Text[0] + "," + cliente.Text[0] + "," + dateTimePicker1.Text + "," + pago.Text + "," + precio.Text + ")";
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (vehiculo.Text != "VEHICULO" && cliente.Text != "CLIENTE" && precio.Text != "" )
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					precio.Text = "";
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
			string query = "DELETE FROM ventas WHERE cod_venta =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM ventas WHERE cod_venta =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                empleado.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				vehiculo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				cliente.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
				pago.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
				dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
				precio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();				
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string auxem = empleado.Text;
            string[] separarem;
            separarem = auxem.Split(' ');

            string auxve = vehiculo.Text;
            string[] separarve;
            separarve = auxve.Split(' ');

            string auxcl = cliente.Text;
            string[] separarcl;
            separarcl = auxcl.Split(' ');

            string query = "UPDATE ventas SET cod_empleado= " + separarem[0] + ", cod_vehiculo=" + separarve[0] +
                ", cod_cliente=" + separarcl[0] + ",fecha_venta='" + dateTimePicker1.Text + "',forma_pago='" + pago.Text + "',precio_total=" + precio.Text + "" +
                " WHERE cod_venta=" + codaux; //+dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE ventas SET cod_empleado= " + separarem[0] + ", cod_vehiculo=" + separarve[0] +
                ", cod_cliente=" + separarcl[0] + ",fecha_venta=" + dateTimePicker1.Text + ",forma_pago=" + pago.Text + ",precio_total=" + precio.Text + "" +
                " WHERE cod_venta=" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (vehiculo.Text != "VEHICULO" && cliente.Text != "CLIENTE" && precio.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					precio.Text = "";
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