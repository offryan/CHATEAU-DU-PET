using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DTO;
using ChateauDuPet.BLL;


namespace ChateauDuPet.BLL
{
    public static class Sessao
    {
        private static string _UserAdm;
        public static string UserAdm
        {
            get { return Sessao._UserAdm; }
            set { Sessao._UserAdm = value; }
        }

        private static int _IdProfissional;
        public static int IdProfissional
        {
            get { return Sessao._IdProfissional; }
            set { Sessao._IdProfissional = value; }
        }
        private static int _IdEmpresa;
        public static int IdEmpresa
        {
            get { return Sessao._IdEmpresa; }
            set { Sessao._IdEmpresa = value; }
        }

        private static string _EmailUser;
        public static  string EmailUser
        {
            get { return Sessao._EmailUser; }
            set { Sessao._EmailUser = value; }
        }

        private static int _IdAdministrativo;
        public static int IdAdministrativo
        {
            get { return Sessao._IdAdministrativo; }
            set { Sessao._IdAdministrativo = value; }
        }
    }
}
