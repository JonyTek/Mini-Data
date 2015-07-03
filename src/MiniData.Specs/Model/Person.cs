﻿using MiniData.Core.Attributes;
using MiniData.Core.Model;

namespace MiniData.Core.Specs.Model
{
    public class Person : IDbTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}