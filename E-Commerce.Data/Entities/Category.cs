﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Data.Entities
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Product>? Products { get; set; }


    }
}
