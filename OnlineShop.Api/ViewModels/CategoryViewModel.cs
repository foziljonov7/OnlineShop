﻿using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
