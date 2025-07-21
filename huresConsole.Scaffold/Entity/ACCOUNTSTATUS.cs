using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class ACCOUNTSTATUS
{
    public string StaffNo { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StatusDate { get; set; }

    public string StatusBy { get; set; } = null!;
}
