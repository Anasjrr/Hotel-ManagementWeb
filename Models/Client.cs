using System;
using System.Collections.Generic;

namespace HotelReservationWeb.Models;

public partial class Client
{
    public int Id { get; set; }
    public bool IsClient { get; set; }

    // Navigation property for User
    public virtual User? User { get; set; } // Corrected to 'User'
}

