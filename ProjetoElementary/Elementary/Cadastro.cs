﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementary
{
    public partial class Cadastro : Form
    {
        // Instância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();
        Criptografia MD5 = new Criptografia();

        // Atributos
        string vSenhaMD5;

        public Cadastro(BD pBD)
        {
            InitializeComponent();

            ActiveControl = label1;

            bd = (BD)pBD;

            textBox5.Visible = false;
            panel5.Visible = false;
            pictureBox6.Visible = false;
        }

        // Botão cadastrar
        private void button1_Click(object sender, EventArgs e)
        {
            // Checkbox marcado ?
            if (checkBox1.Checked == true)
            {
                // TODOS os campos preenchidos ? 
                if (textBox1.Text != "Nome completo" && textBox2.Text != "Email" && textBox3.Text != "Senha" && textBox4.Text != "Confirmar senha" && textBox5.Text != "CRM" && maskedTextBox1.Text != "  /  /")
                {
                    // Data válida ?
                    try
                    {
                        DateTime data = Convert.ToDateTime(maskedTextBox1.Text);

                        // Médico já está cadastrado ?
                        if (bd.getMedico(textBox2.Text) == null)
                        {
                            // Senhas correspondem ?
                            if (textBox3.Text == textBox4.Text)
                            {
                                // Email correto ?
                                if (textBox2.Text.IndexOf("@") != -1 && textBox2.Text.IndexOf(".com") != -1)
                                {
                                    // Criptografia da senha
                                    vSenhaMD5 = MD5.criptografar(textBox3.Text);

                                    // Cadastro do médico no "BD" de médicos
                                    medico.cadastrarMedico(textBox1.Text, textBox2.Text, vSenhaMD5, textBox5.Text, data, true);
                                    bd.setMedico(medico);

                                    MessageBox.Show("Cadastro realizado com sucesso");

                                    this.Dispose();
                                    Login login = new Login(bd);
                                    login.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Email inválido");
                                }
                            }
                            else
                            {
                                MessageBox.Show("As senhas não são iguais");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuário já está cadastrado");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Data inválida");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
            else
            {
                // TODOS os campos preenchidos ?
                if (textBox1.Text != "Nome completo" && textBox2.Text != "Email" && textBox3.Text != "Senha" && textBox4.Text != "Confirmar senha" && maskedTextBox1.Text != "  /  /")
                {
                    // Data válida ?
                    try
                    {
                        DateTime data = Convert.ToDateTime(maskedTextBox1.Text);

                        // Usuário cadastrado ?
                        if (bd.getUsuario(textBox2.Text) == null)
                        {
                            // Senhas correspondem ?
                            if (textBox3.Text == textBox4.Text)
                            {
                                // Email correto ?
                                if (textBox2.Text.IndexOf("@") != -1 && textBox2.Text.IndexOf(".com") != -1)
                                {
                                    // Criptografia da senha
                                    vSenhaMD5 = MD5.criptografar(textBox3.Text);

                                    // Cadastro do usuário no "BD" de usuários
                                    usuario.cadastrarUsuario(textBox1.Text, textBox2.Text, vSenhaMD5, data, true);
                                    bd.setUsuario(usuario);

                                    MessageBox.Show("Cadastro realizado com sucesso");

                                    this.Dispose();
                                    Login login = new Login(bd);
                                    login.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Email inválido");
                                }
                            }
                            else
                            {
                                MessageBox.Show("As senhas não são iguais");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuário já está cadastrado");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Data inválida");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nome completo")
            {
                textBox1.Clear();
            }

            textBox1.ForeColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_white;
            panel4.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nome completo";
            }

            textBox1.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_black;
            panel4.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Email")
            {
                textBox2.Clear();
            }

            textBox2.ForeColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel3.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Email";
            }

            textBox2.ForeColor = Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel3.BackColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Senha")
            {
                textBox3.Clear();
            }

            textBox3.PasswordChar = '*';
            textBox3.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel2.BackColor = Color.White;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.PasswordChar = '\u0000';
                textBox3.Text = "Senha";
            }

            textBox3.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel2.BackColor = Color.Black;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Confirmar senha")
            {
                textBox4.Clear();
            }

            textBox4.PasswordChar = '*';
            textBox4.ForeColor = Color.White;
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.PasswordChar = '\u0000';
                textBox4.Text = "Confirmar senha";
            }

            textBox4.ForeColor = Color.Black;
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "CRM")
            {
                textBox5.Clear();
            }

            textBox5.ForeColor = Color.White;
            panel5.BackColor = Color.White;
            pictureBox6.BackgroundImage = Properties.Resources.icon_CRM_white;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "CRM";
            }

            textBox5.ForeColor = Color.Black;
            panel5.BackColor = Color.Black;
            pictureBox6.BackgroundImage = Properties.Resources.icon_CRM_black;
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.White;
            panel6.BackColor = Color.White;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_white;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.Black;
            panel6.BackColor = Color.Black;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_black;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                textBox5.Visible = true;
                textBox5.Text = "CRM";
                panel5.Visible = true;
                pictureBox6.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
                panel5.Visible = false;
                pictureBox6.Visible = false;
            }
        }

        // Botão sair 'X'
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = new Login(bd);
            login.ShowDialog();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }   
}

