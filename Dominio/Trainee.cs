﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Trainee
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string ImgenPerfil { get; set; }

        public DateTime FechaNacimento { get; set; }

        public bool Admin { get; set; }

    }
}
