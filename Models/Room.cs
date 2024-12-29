using System;
using System.Collections.Generic;

namespace HotelReservationWeb.Models;

public partial class Room
{
    public int Id { get; set; }

    public string NumR { get; set; } = null!;

    public decimal Nprice { get; set; }

    public int TypeR { get; set; }

    public int Status { get; set; }

    public string PicturePath { get; set; } = null!;
}
