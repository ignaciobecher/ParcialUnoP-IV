﻿namespace ParcialUnoP_IV.Models
{
    public class Productos
    {
        public int id { get; set; }
        public required string name { get; set; }    
        public string? description { get; set; }

        public int price {  get; set; }
        public int quantity { get; set; }

    }
}
