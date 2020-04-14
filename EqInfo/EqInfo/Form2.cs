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


namespace EqInfo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            string stringconexao = "Server=localhost;Database=eqinfo;Uid=root;Pwd=keila";

            MySqlConnection conn = new MySqlConnection(stringconexao);

            try
            {
                conn.Open();

                string scomando = "INSERT INTO equipamentos (Nome_do_equipamento, Modelo_do_equipamento, Descricao, Marca_do_equipamento, Numero_de_serie) VALUES " + "('" + txtNome.Text + "','" + txtModelo.Text + "', '" + txtDesc.Text + "', '" + TxtMarca.Text + "', '" + TxtSerie.Text + "')";

                MySqlCommand comando = new MySqlCommand(scomando, conn);

                MessageBox.Show("Cadastro realizado com sucesso");
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            string stringconexao = "Server=localhost;Database=eqinfo;Uid=root;Pwd=keila";

            MySqlConnection conn = new MySqlConnection(stringconexao);

            try
            {
                conn.Open();

                string scomando = "update equipamentos set Nome_do_equipamento = '" + txtNome.Text + "', Modelo_do_equipamento = '" + txtModelo.Text + "', Descricao = '" + txtDesc.Text + "', Marca_do_equipamento = '" + TxtMarca.Text + "', Numero_de_serie = '" + TxtSerie.Text + "' where Id = '" + txtAlt.Text + "'";


                MySqlCommand comando = new MySqlCommand(scomando, conn);

                MessageBox.Show("Cadastro alterado com sucesso");
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            string stringconexao = "Server=localhost;Database=eqinfo;Uid=root;Pwd=keila";

            MySqlConnection conn = new MySqlConnection(stringconexao);

            try
            {
                conn.Open();

                string scomando = "delete from equipamentos where Id = " + " ('" + txtEx.Text + "')";

                MySqlCommand comando = new MySqlCommand(scomando, conn);

                MessageBox.Show("Cadastro excluido com sucesso");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            string stringconexao = "Server=localhost;Database=eqinfo;Uid=root;Pwd=keila";

            MySqlConnection conn = new MySqlConnection(stringconexao);

            try
            {
                conn.Open();

                string scomando = "select * from equipamentos where Id = '" + txtSelect.Text + "'";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(scomando, conn);

                DataTable table = new DataTable();
                adaptador.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stringconexao = "Server=localhost;Database=eqinfo;Uid=root;Pwd=keila";

            MySqlConnection conn = new MySqlConnection(stringconexao);

            try
            {
                conn.Open();

                string scomando = "select * from equipamentos";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(scomando, conn);

                DataTable table = new DataTable();
                adaptador.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtAlt.Text = txtDesc.Text = txtEx.Text = TxtMarca.Text = txtModelo.Text = txtNome.Text = txtSelect.Text = TxtSerie.Text ="";
            }
            catch (Exception)
            {
                MessageBox.Show("Erro");
            }
        }
    }
}
