using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuApp
{
    public class Usuario
    {
		private string nomes;
		public string Nomes
		{
			get { return this.nomes; }
			set { this.nomes = value; }
		}

		private string email;
		public string Email
		{
			get { return this.email; }
			set { this.email = value; }
		}

        private string conta;
        public string Conta
        {
            get { return this.conta; }
            set { this.conta = value; }
        }

        private string senha;
        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }

        private int status;
        public int Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        private int nivel;
        public int Nivel
        {
            get { return this.nivel; }
            set { this.nivel = value; }
        }

        private DateTime datacad;
        public  DateTime Datacad
        {
            get { return this.datacad; }
            set { this.datacad = value; }
        }
	}
}
