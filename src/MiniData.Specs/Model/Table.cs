﻿using MiniData.Core.Attributes;
using MiniData.Core.Model;

namespace MiniData.Specs.Model
{
    public class Table : IDbTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Nullable]
        public string Name { get; set; }
    }
}