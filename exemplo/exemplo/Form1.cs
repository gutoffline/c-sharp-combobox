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

namespace exemplo
{
    public partial class frmExemplo : Form
    {
        public frmExemplo()
        {
            InitializeComponent();
        }

        private void frmExemplo_Load(object sender, EventArgs e)
        {
            string sqlBuscar = "SELECT * FROM marca_carros";
            string bancoDeDados = "server=localhost;user id=root;password=;database=locadora;";

            MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sqlBuscar, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMarca.DataSource = dt;
                cmbMarca.ValueMember = "id_marca";
                cmbMarca.DisplayMember = "nome";
                cmbMarca.Refresh();

                conexao.Close();
            }
            catch (MySqlException erro)
            {
                
            }
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlBuscar = $"SELECT id_auto, modelo , fk_marca_carros  FROM automoveis where fk_marca_carros = {cmbMarca.SelectedValue.ToString()}";

            string bancoDeDados = "server=localhost;user id=root;password=;database=locadora;";

            MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sqlBuscar, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbModelo.DataSource = dt;
                cmbModelo.ValueMember = "id_auto";
                cmbModelo.DisplayMember = "modelo";
                cmbModelo.Refresh();

                conexao.Close();
            }
            catch (MySqlException erro)
            {
                
            }
        }

        private void cmbMarca_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbMarca_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
