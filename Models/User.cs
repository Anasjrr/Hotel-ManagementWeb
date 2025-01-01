using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationWeb.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

  public string Gender { get; set; }= string.Empty;
   public string Address { get; set; }= string.Empty;
   public DateTime BirthDate { get; set; }
    public virtual Client? Client { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Manager? Manager { get; set; }

   
    public int? ClientId { get; set; }
}