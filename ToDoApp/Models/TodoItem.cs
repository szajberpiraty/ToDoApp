﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class TodoItem
    {
        public bool Done { get; internal set; }
        public string Name { get; internal set; }
    }
}