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
	public partial class MainMenu : Form
	{
		string usuario;
		string level;
		public MainMenu(string user, string nivel)
		{
			InitializeComponent();
			usuario = user;
			level = nivel;
			label1.Text = user;
		}


		private void MainMenu_Load(object sender, EventArgs e)
		{

		}

		private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Hide();
			LogIn nuevoLogin = new LogIn();
			nuevoLogin.Show();
		}

		private void button1_MouseHover(object sender, EventArgs e)
		{
			button1.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button1.Text = "VEHICULOS";
		}

		private void button1_MouseLeave(object sender, EventArgs e)
		{
			button1.BackgroundImage = global::RUSO.Properties.Resources.car;
			button1.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Vehiculo op1 = new Vehiculo(usuario, level);
			op1.Show();
			this.Hide();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Taller op1 = new Taller(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button2_MouseHover(object sender, EventArgs e)
		{
			button2.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button2.Text = "TALLERES";
		}

		private void button2_MouseLeave(object sender, EventArgs e)
		{
			button2.BackgroundImage = global::RUSO.Properties.Resources.taller;
			button2.Text = "";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label2.Text = DateTime.Now.ToLongTimeString();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Compras op1 = new Compras(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button8_Click(object sender, EventArgs e)
		{
            Correos op1 = new Correos(usuario, level);
            op1.Show();
            this.Hide();
        }

		private void button3_Click(object sender, EventArgs e)
		{
			Clientes op1 = new Clientes(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Empleados op1 = new Empleados(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Exportadores op1 = new Exportadores(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Reparaciones op1 = new Reparaciones(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Ventas op1 = new Ventas(usuario, level);
			op1.Show();
			this.Hide();
		}

		private void button6_MouseHover(object sender, EventArgs e)
		{

			button6.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button6.Text = "COMPRAS";
		}

		private void button6_MouseLeave(object sender, EventArgs e)
		{
			button6.BackgroundImage = global::RUSO.Properties.Resources.COMPRAS;
			button6.Text = "";
		}

		private void button3_MouseHover(object sender, EventArgs e)
		{
			button3.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button3.Text = "CLIENTES";
		}

		private void button3_MouseLeave(object sender, EventArgs e)
		{

			button3.BackgroundImage = global::RUSO.Properties.Resources.target;
			button3.Text = "";
		}

		private void button5_MouseHover(object sender, EventArgs e)
		{
			button5.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button5.Text = "EMPLEADOS";
		}

		private void button5_MouseLeave(object sender, EventArgs e)
		{
			button5.BackgroundImage = global::RUSO.Properties.Resources.mechanic;
			button5.Text = "";
		}

		private void button7_MouseHover(object sender, EventArgs e)
		{
			button7.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button7.Text = "EXPORTADORES";

		}

		private void button7_MouseLeave(object sender, EventArgs e)
		{

			button7.BackgroundImage = global::RUSO.Properties.Resources.cargo_ship;
			button7.Text = "";
		}

		private void button4_MouseHover(object sender, EventArgs e)
		{
			button4.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button4.Text = "REPARACIONES";
		}

		private void button4_MouseLeave(object sender, EventArgs e)
		{
			button4.BackgroundImage = global::RUSO.Properties.Resources.car_repair;
			button4.Text = "";
		}

		private void button9_MouseHover(object sender, EventArgs e)
		{
			button9.BackgroundImage = global::RUSO.Properties.Resources.FONDO;
			button9.Text = "VENTAS";
		}

		private void button9_MouseLeave(object sender, EventArgs e)
		{

			button9.BackgroundImage = global::RUSO.Properties.Resources.bank;
			button9.Text = "";
		}

        private void button8_Click_1(object sender, EventArgs e)
        {
            Marcas op1 = new Marcas(usuario, level);
            op1.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Documentos op1 = new Documentos(usuario, level);
            op1.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Correos op1 = new Correos(usuario, level);
            op1.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Puestos op1 = new Puestos(usuario, level);
            op1.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FormasPago op1 = new FormasPago(usuario, level);
            op1.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Telefonos op1 = new Telefonos(usuario, level);
            op1.Show();
            this.Hide();
        }
    }
}