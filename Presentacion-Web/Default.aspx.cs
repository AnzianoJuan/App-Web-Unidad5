﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Presentacion_Web
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Disco> ListaDisco { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoData discoData = new DiscoData();
            ListaDisco = discoData.listarSP();
        }
    }
}