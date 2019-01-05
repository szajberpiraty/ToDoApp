﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public bool Done { get; internal set; }
        public string Name { get; internal set; }
    }
}