﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementary
{
    public partial class Login : Form
    {
        // Instância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();
        Criptografia MD5 = new Criptografia();

        // Atributos
        string vSenhaMD5;

        public Login()
        {
            InitializeComponent();
          
        }

        public Login(BD pBD)
        {
            InitializeComponent();

            // Manter os dados
            bd = (BD)pBD;
        }

        // Botão cadastrar 
        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro cadastrar = new Cadastro(bd);
            this.Hide();
            cadastrar.ShowDialog();
        }

        // Botão entrar
        private void button1_Click(object sender, EventArgs e)
        {
            // Campos vazios ?
            if (textBox1.Text != "Email" && textBox2.Text != "Senha")
            {
                // Já existe usuário ?
                if (bd.getUsuario(textBox1.Text) != null)
                {
                    usuario = (Usuario)bd.getUsuario(textBox1.Text);

                    // Conta excluída ?
                    if (usuario.getStatusConta() == true)
                    {
                        // Criptografa a senha para comparar com a que está no "BD"
                        vSenhaMD5 = MD5.criptografar(textBox2.Text);

                        if (usuario.getSenha() == vSenhaMD5 && usuario.getEmail() == textBox1.Text)
                        {
                            // Chama o formulário do menu
                            Feed menu = new Feed(bd, usuario);
                            this.Hide();
                            menu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha inválido");
                        }
                    }
                    else
                    {
                        // Reativar conta ?
                        DialogResult ativarConta = MessageBox.Show("Sua conta foi desativada desejá ativa-lá novamente?", "AVISO", MessageBoxButtons.YesNo);

                        if(ativarConta == DialogResult.Yes)
                        {
                            usuario.setStatusConta(true);

                            Feed menu = new Feed(bd, usuario);
                            this.Hide();
                            menu.ShowDialog();
                        }
                    }
                }
                else if (bd.getMedico(textBox1.Text) != null)
                {
                    medico = (Medico)bd.getMedico(textBox1.Text);

                    if (medico.getStatusConta() == true)
                    {
                        // Criptografa a senha para comparar com a que está no "BD"
                        vSenhaMD5 = MD5.criptografar(textBox2.Text);

                        if (medico.getSenha() == vSenhaMD5 && medico.getEmail() == textBox1.Text)
                        {
                            // Chama o formulário do menu
                            Feed menu = new Feed(bd, medico);
                            this.Hide();
                            menu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha inválido");
                        }
                    }
                    else
                    {
                        // Reativar conta ?
                        DialogResult ativarConta = MessageBox.Show("Sua conta foi desativada desejá ativa-lá novamente?", "AVISO", MessageBoxButtons.YesNo);

                        if (ativarConta == DialogResult.Yes)
                        {
                            medico.setStatusConta(true);

                            Feed menu = new Feed(bd, medico);
                            this.Hide();
                            menu.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
        }

        // Restaurar senha de usuário
        private void button3_Click(object sender, EventArgs e)
        {
            RestaurarSenha restaurarSenha = new RestaurarSenha(bd);
            this.Hide();
            restaurarSenha.ShowDialog();
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Email")
            {
                textBox1.Clear();
            }

            textBox1.ForeColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel2.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Email";
            }

            textBox1.ForeColor = Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel2.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Clear();
            }

            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\u0000';
                textBox2.Text = "Senha";
            }

            textBox2.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
