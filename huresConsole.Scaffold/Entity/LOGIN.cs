using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class LOGIN
{
    public string StaffNo { get; set; } = null!;

    public string? StaffName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Status { get; set; }
}
