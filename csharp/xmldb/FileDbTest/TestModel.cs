﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDbTest
{
    [Serializable]
    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
