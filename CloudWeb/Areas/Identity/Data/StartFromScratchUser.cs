
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace StartFromScratch.Areas.Identity.Data;

public class StartFromScratchUser : IdentityUser
{
    [PersonalData]
    public string? FullName { get; set; }
    [PersonalData]
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    public List<Customer> customer { get; set; } = new List<Customer>();
    public List<Order> Rented { get; set; } = new List<Order>();
}