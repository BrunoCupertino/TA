﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Anunciante : IEntidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
