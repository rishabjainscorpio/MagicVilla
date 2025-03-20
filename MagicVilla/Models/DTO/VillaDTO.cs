﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public int Occupancy { get; set; }

        public int Sqft { get; set; }

        [Required]
        public double Rate { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public string Amenity { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
