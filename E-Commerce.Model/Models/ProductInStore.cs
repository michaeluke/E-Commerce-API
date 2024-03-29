﻿using E_Commerce.Data.Entities;
using E_Commerce.Model.Models;
using Newtonsoft.Json;

namespace E_Commerce_CORE_MVC.Models
{
	public class ProductInStore
	{
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }

		public Decimal Price { get; set; }

		public bool InStock { get; set; }

		public string ImageUrl { get; set; }

		[JsonIgnore]
		public Wishlist? Wishlist { get; set; }

	
		public CategoryModel Category { get; set; }





    }
}
