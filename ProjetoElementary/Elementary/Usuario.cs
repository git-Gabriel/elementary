﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class Usuario
    {
        // Atributos
        private string vNome;
        private string vEmail;
        private string vSenha;
        private string vConfirmarSenha;
        private DateTime vDataNascimento;
        private bool vStatusConta;
        private ArrayList Posts = new ArrayList();
        private ArrayList Amigos = new ArrayList();

        // Métodos
        public Usuario()
        {

        }
        
        public Usuario(string pNome, string pEmail, string pSenha, string pConfirmarSenha, DateTime pDataNascimento, bool pStatusConta)
        {
            vNome = pNome;
            vEmail = pEmail;
            vSenha = pSenha;
            vConfirmarSenha = pConfirmarSenha;
            vDataNascimento = pDataNascimento;
            vStatusConta = pStatusConta;
        }

        public void setNome(string pNome)
        {
            vNome = pNome;
        }

        public void setEmail(string pEmail)
        {
            vEmail = pEmail;
        }

        public void setSenha(string pSenha)
        {
            vSenha = pSenha;
        }

        public void setConfirmarSenha(string pConfirmarSenha)
        {
            vConfirmarSenha = pConfirmarSenha;
        }

        public void setDataNascimento(DateTime pDataNascimento)
        {
            vDataNascimento = pDataNascimento;
        }

        public void setStatusConta(bool pStatusConta)
        {
            vStatusConta = pStatusConta;
        }

        public string getNome()
        {
            return vNome;
        }

        public string getEmail()
        {
            return vEmail;
        }

        public string getSenha()
        {
            return vSenha;
        }

        public string getConfirmarSenha()
        {
            return vConfirmarSenha;
        }

        public DateTime getDataNascimento()
        {
            return vDataNascimento;
        }

        public bool getStatusConta()
        {
            return vStatusConta;
        }

        public void cadastrarUsuario(string pNome, string pEmail, string pSenha, string pConfirmarSenha, DateTime pDataNascimento, bool pStatusConta)
        {
            setNome(pNome);
            setEmail(pEmail);
            setSenha(pSenha);
            setConfirmarSenha(pConfirmarSenha);
            setDataNascimento(pDataNascimento);
            setStatusConta(pStatusConta);
        }

        public void addPost(object pPost)
        {
            Posts.Add((Post)pPost);
        }

        public int numeroPost()
        {
            if (Posts.Count != 0)
            {
                return Posts.Count;
            }

            return -1;
        }

        public ArrayList getPost()
        {
            return Posts;
        }

        public void addAmigo(string pEmailAmigo)
        {
            Amigos.Add(pEmailAmigo);
        }

        public void removeAmigo(string pEmailAmigo)
        {
            Amigos.Remove(pEmailAmigo);
        }
    }
}
