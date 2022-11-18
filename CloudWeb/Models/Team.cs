﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CloudWeb.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
