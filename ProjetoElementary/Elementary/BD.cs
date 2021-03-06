﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class BD
    {
        // Instância de classe
        Dictionary<string, object> listaDeUsuarios = new Dictionary<string, object>();
        Dictionary<string, object> listaDeMedicos = new Dictionary<string, object>();
        Dictionary<string, object> grupos = new Dictionary<string, object>();

        public BD()
        {
            
        }

        // "Banco de dados" dos médicos
        public BD(Medico pMedico)
        {
            Dictionary<string, object> listaDeMedicos = new Dictionary<string, object>();
            listaDeMedicos.Add(pMedico.getEmail(), pMedico);
        }
        
        // "Banco de dados" dos usuários
        public BD(Usuario pUsuario)
        {
            Dictionary<string, object> listaDeUsuarios = new Dictionary<string, object>();
            listaDeUsuarios.Add(pUsuario.getEmail(), pUsuario);
        }

        public void setMedico(Medico pMedico)
        {            
            listaDeMedicos.Add(pMedico.getEmail(), pMedico);
        }

        public void setUsuario(Usuario pUsuario)
        {
            listaDeUsuarios.Add(pUsuario.getEmail(), pUsuario);
        }

        public void setGrupo(Grupo pGrupo)
        {
            grupos.Add(pGrupo.getNome(), pGrupo);
        }

        public object getGrupo(string pNomeGrupo)
        {
            if (grupos.ContainsKey(pNomeGrupo))
            {
                return grupos[pNomeGrupo];
            }
            return null;
        }

        public object getUsuario(string pUsuario)
        {
            if (listaDeUsuarios.ContainsKey(pUsuario))
            {
                return listaDeUsuarios[pUsuario];
            }
            return null;
        }

        public object getMedico(string pMedico)
        {
            if (listaDeMedicos.ContainsKey(pMedico))
            {
                return listaDeMedicos[pMedico];
            }
            return null;
        }
    }    
}
