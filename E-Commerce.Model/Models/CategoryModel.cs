using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace E_Commerce.Model.Models
{
	public class CategoryModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public List<Product>? Products { get; set; }
	}
}
