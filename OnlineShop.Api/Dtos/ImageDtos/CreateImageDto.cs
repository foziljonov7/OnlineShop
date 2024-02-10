﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Api.Dtos.ImageDtos
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Guid ProductId { get; set; }
    }
}