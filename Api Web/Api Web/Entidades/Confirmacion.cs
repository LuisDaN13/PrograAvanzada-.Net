﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Web.Entidades
{
    public class Confirmacion
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public long ConsecutivoGenerado { get; set; }
    }
}