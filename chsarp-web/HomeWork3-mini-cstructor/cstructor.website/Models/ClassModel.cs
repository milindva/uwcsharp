﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cstructor.Repository;
using cstructor.Business;

namespace cstructor.website.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int GetClassId { get; set; }

        public ClassModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public ClassModel()
        {

        }

    }
}