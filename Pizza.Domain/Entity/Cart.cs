﻿using System.ComponentModel.DataAnnotations.Schema;
using Pizza.Domain.Users;
namespace Pizza.Domain.Entity
{
    public class Cart : EntityBase
    {
        public int ItemId { get; set; }
        public ICollection<Item>? Items { get; set; }
        public User? User { get; set; }
    }
}
