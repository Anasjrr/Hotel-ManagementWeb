using System;
using System.Collections.Generic;

namespace HotelReservationWeb.Models;

public partial class Manager
{
    public int Id { get; set; }

    public bool IsManager { get; set; }

    // Foreign Key to User
    public int? UserId { get; set; } // Foreign key to User

    // Navigation property for User
    public virtual User? User { get; set; }
}
