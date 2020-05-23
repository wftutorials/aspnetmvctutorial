using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JetBrains.Annotations;

namespace AspnetMvcTutorial
{
    public partial class MyMigrations
    {
        public uint Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }

    }
}
