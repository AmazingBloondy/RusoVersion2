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
	public partial class Empleados : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=importadora;");
		string usuario;
		string level;
		string operacion;
		public Empleados(string user, string nivel)
		{
			InitializeComponent();
			label27.Text = user;
			llenartabla();
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
			codigo.CommandText = ("SELECT * FROM empleados");
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
				comboBox1.Text = "SEXO";
				comboBox1.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM sexos", databaseConnection);
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
				comboBox2.Text = "PUESTO";
				comboBox2.Items.Clear();

				databaseConnection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM puestos", databaseConnection);
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

		private void Empleados_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Empleados_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO empleados(primer_nombre, segundo_nombre, primer_apellido,"+
			" segundo_apellido, dpi, sexo, fecha_nacimiento, puesto) VALUES ('"+nom1.Text+"','"+nom2.Text+"','"+apel1.Text+"','"+apel2.Text+"',"
			+"'"+dpi.Text+"','"+comboBox1.Text+"','"+dateTimePicker1.Text+"','"+comboBox2.Text+"')";
			operacion = "INSERT INTO empleados(primer_nombre, segundo_nombre, primer_apellido," +
			" segundo_apellido, dpi, sexo, fecha_nacimiento, puesto) VALUES (" + nom1.Text + "," + nom2.Text + "," + apel1.Text + "," + apel2.Text + ","
			+ "" + dpi.Text + "," + comboBox1.Text + "," + dateTimePicker1.Text + "," + comboBox2.Text + ")";

			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (nom1.Text != "" && nom2.Text != "" && apel1.Text != "" && comboBox1.Text != "SEXO")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("INGRESO CORRECTO");
					log(operacion);
					nom1.Text = "";
					apel1.Text = "";
					nom2.Text = "";
					apel2.Text = "";
					dpi.Text = "";
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
			string query = "DELETE FROM empleados  WHERE  cod_empleado=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			operacion = "DELETE FROM empleados  WHERE  cod_empleado =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                nom1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				nom2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				apel1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
				apel2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
				dpi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
				comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
				dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
				comboBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
			}
			else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
		}

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string query = "UPDATE empleados SET primer_nombre= '" + nom1.Text + "'," +
            "segundo_nombre='" + nom2.Text + "',primer_apellido='" + apel1.Text + "',segundo_apellido='" + apel2.Text + "'," +
            "dpi='" + dpi.Text + "',sexo='" + comboBox1.Text + "',fecha_nacimiento='" + dateTimePicker1.Text + "',puesto='" + comboBox2.Text + "'" +
   "		 WHERE cod_empleado =" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();

            operacion = "UPDATE empleados SET primer_nombre= " + nom1.Text + "," +
            "segundo_nombre=" + nom2.Text + ",primer_apellido=" + apel1.Text + ",segundo_apellido=" + apel2.Text + "," +
            "dpi=" + dpi.Text + ",sexo=" + comboBox1.Text + ",fecha_nacimiento=" + dateTimePicker1.Text + ",puesto=" + comboBox2.Text + "" +
   "		 WHERE cod_empleado = " + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();

			databaseConnection.Open();
			MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
			try
			{
				if (nom1.Text != "" && nom2.Text != "" && apel1.Text != "" && comboBox1.Text != "SEXO")
				{
					consulta.ExecuteNonQuery();
					MessageBox.Show("Actualizado");
					databaseConnection.Close();
					llenartabla();
					databaseConnection.Open();
					log(operacion);
					nom1.Text = "";
					apel1.Text = "";
					nom2.Text = "";
					apel2.Text = "";
					dpi.Text = "";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
