using System;
using System.Collections.Generic;

namespace HotelReservationWeb;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string GuestName { get; set; } = null!;

    public string GuestEmail { get; set; } = null!;

    public string Guestadresse { get; set; } = null!;
}
