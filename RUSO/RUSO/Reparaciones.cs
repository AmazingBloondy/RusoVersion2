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
	public partial class Reparaciones : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		string usuario;
		string level;
		string operacion;
		public Reparaciones(string user, string nivel)
		{
			InitializeComponent();
			label27.Text = user;
			llenartabla();
			usuario = user;
			level = nivel;
			actualizarbtn.Enabled = false;
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "yyyy-MM-dd";
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.CustomFormat = "yyyy-MM-dd";
		}

		void llenartabla()
		{

			MySqlCommand codigo = new MySqlCommand();
			codigo.Connection = databaseConnection;
			codigo.CommandText = ("SELECT * FROM reparaciones");
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
				vehiculo.Text = "VEHICULO";
				vehiculo.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM vehiculos", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					vehiculo.Refresh();
					vehiculo.Items.Add(reader.GetValue(0).ToString()+" - "+reader.GetValue(1).ToString()+" "+reader.GetValue(8).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				taller.Text = "TALLER";
				taller.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM talleres", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					taller.Refresh();
					taller.Items.Add(reader.GetValue(0).ToString()+" "+reader.GetValue(1).ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			databaseConnection.Close();

			try
			{
				estado.Text = "ESTADO";
				estado.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM estados_vehiculos", databaseConnection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					estado.Refresh();
					estado.Items.Add(reader.GetValue(1).ToString());
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

		private void Reparaciones_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Reparaciones_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO reparaciones(cod_vehiculo, cod_taller, fecha_entrega , fecha_devolucion, estado, detalles, precio_total)" +
			" VALUES (" + vehiculo.Text[0] + "," +taller.Text[0] + ",'" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + estado.Text + "','" + detalles.Text + "'," + precio.Text + ")";
			operacion = "INSERT INTO reparaciones(cod_vehiculo, cod_taller, fecha_entrega , fecha_devolucion, estado, detalles, precio_total)" +
			" VALUES (" + vehiculo.Text + "," + taller.Text[0] + "," + dateTimePicker1.Text + "," + dateTimePicker2.Text + "," + estado.Text + "," + detalles.Text + "," + precio.Text + ")";
			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (detalles.Text != "" && estado.Text != "ESTADO" && precio.Text != "" )
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					detalles.Text = "";
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
			string query = "DELETE FROM reparaciones  WHERE  cod_reparacion =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM reparaciones  WHERE  cod_reparacion =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                vehiculo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				taller.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
				dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
				estado.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
				detalles.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
				precio.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();				
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string auxve = vehiculo.Text;
            string[] separarve;
            separarve = auxve.Split(' ');

            string auxta = taller.Text;
            string[] separarta;
            separarta = auxta.Split(' ');

            string query = "UPDATE reparaciones SET cod_vehiculo= " + separarve[0] + ", cod_taller= " + separarta[0] +
                ", fecha_entrega='" + dateTimePicker1.Text + "',fecha_devolucion='" + dateTimePicker2.Text + "',estado='"
                + estado.Text + "',detalles='" + detalles.Text + "',precio_total=" + precio.Text + "" +
                " WHERE cod_reparacion=" + codaux; //+dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE reparaciones SET cod_vehiculo= " + separarve[0] + ", cod_taller= " + separarta[0] +
                ", fecha_entrega=" + dateTimePicker1.Text + ",fecha_devolucion=" + dateTimePicker2.Text + ",estado="
                + estado.Text + ",detalles=" + detalles.Text + ",precio_total=" + precio.Text + "" +
                " WHERE cod_reparacion=" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (detalles.Text != "" && estado.Text != "ESTADO" && precio.Text != "")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					detalles.Text = "";
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

        private void vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}