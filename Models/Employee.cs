using System;
using System.Collections.Generic;

namespace HotelReservationWeb.Models;


public partial class Employee
{
    public int Id { get; set; }

    public bool IsEmployee { get; set; }

    // Foreign Key to User
    public int? UserId { get; set; }

    // Navigation properties
    public virtual User? User { get; set; }
}
