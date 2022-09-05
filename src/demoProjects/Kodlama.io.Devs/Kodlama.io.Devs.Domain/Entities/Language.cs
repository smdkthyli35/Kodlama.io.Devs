﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }

        public Language()
        {
        }

        public Language(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
