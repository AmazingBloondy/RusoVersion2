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
	public partial class Telefonos : Form
	{
		MySqlConnection databaseConnection = new MySqlConnection("datasource = sql3.freemysqlhosting.net; port = 3306; username =sql3292530; password =KLZjP7E8CZ; database =sql3292530");
		string usuario;
		string level;
		string operacion;
		public Telefonos(string user, string nivel)
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
			codigo.CommandText = ("SELECT * FROM telefonos");
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
            databaseConnection.Close();            
        }

        public void cargar_nombre(string propi)
        {
            try
            {
                txtNombre.Text = "Seleccione una opcion";
                txtNombre.Items.Clear();

                databaseConnection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + propi + "", databaseConnection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtNombre.Refresh();
                    txtNombre.Items.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString() + " - " + reader.GetValue(2).ToString());
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

		private void Telefonos_FormClosed(object sender, FormClosedEventArgs e)
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

		private void Telefonos_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            string query = "INSERT INTO telefonos (propietario, nombre, telefono)" +
            " VALUES ('" + txtProp.Text + "','" + txtNombre.Text + "'," + txtTel.Text + ")";
            operacion = "INSERT INTO telefonos (propietario, nombre, telefono)" +
            " VALUES (" + txtProp.Text + "," + txtNombre.Text + "," + txtTel.Text + ")";
            databaseConnection.Open();
            MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
            try
            {
                if (txtTel.Text != "")
                {
                    consulta.ExecuteNonQuery();
                    MessageBox.Show("INGRESO CORRECTO");
                    log(operacion);
                    txtTel.Text = "";
                    txtProp.SelectedIndex = -1;                    
                    txtNombre.SelectedIndex = -1;
                    databaseConnection.Close();
                    llenartabla();
                }
                else { MessageBox.Show("POR FAVOR LLENE TODOS LOS CAMPOS.\n\tGRACIAS!!"); databaseConnection.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\tERROR!!\nVerifique: Los datos.\n\tGRACIAS!!" + ex.ToString());
                databaseConnection.Close();
            }
        }

		private void button4_Click(object sender, EventArgs e)
		{
            string query = "DELETE FROM telefonos WHERE cod_telefono =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "DELETE FROM telefonos WHERE cod_telefono =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                txtProp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();                
            }
            else { MessageBox.Show("Porfavor Seleccione un registro de la tabla"); }
        }

		private void actualizarbtn_Click(object sender, EventArgs e)
		{
            string query = "UPDATE telefonos SET propietario= '" + txtProp.Text + "', nombre='" + txtNombre.Text +
                "', telefono=" + txtTel.Text + "" + " WHERE cod_telefono=" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            operacion = "UPDATE telefonos SET propietario= " + txtProp.Text + ", nombre=" + txtNombre.Text +
                ", telefono=" + txtTel.Text + "" + " WHERE cod_telefono=" + codaux; //+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            databaseConnection.Open();
            MySqlCommand consulta = new MySqlCommand(query, databaseConnection);
            try
            {
                if (txtTel.Text != "")
                {
                    consulta.ExecuteNonQuery();
                    MessageBox.Show("Actualizado");
                    databaseConnection.Close();
                    llenartabla();
                    databaseConnection.Open();
                    log(operacion);
                    txtTel.Text = "";
                    txtProp.SelectedIndex = -1;
                    txtNombre.SelectedIndex = -1;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProp.Text != "")
            {
                string aux = txtProp.Text;
                cargar_nombre(aux);
            }
        }
    }
}