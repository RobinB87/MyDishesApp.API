﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyDishesApp.API.Database.Entities
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double PricePerUnit { get; set; }

        [Required]
        public double Quantity { get; set; }


        [ForeignKey("DishId")]
        public Dish Dish { get; set; }
        public int DishId { get; set; }
    }
}
