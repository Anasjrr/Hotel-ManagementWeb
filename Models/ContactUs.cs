using System;
using System.Collections.Generic;

namespace HotelReservationWeb.Models;


public partial class ContactUs
{
    public int Id { get; set; }

    public String FirstName { get; set; }= null!;
    public String LastName { get; set; }= null!;
    public String Email { get; set; }= null!;
    public String Message { get; set; }= null!;

  
}
