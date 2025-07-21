using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_main
{
    public uint main_id { get; set; }

    public string name { get; set; } = null!;

    public string staff_id { get; set; } = null!;

    public string? email { get; set; }

    public string? mobile { get; set; }

    public string? sms { get; set; }

    public string? phone_ext { get; set; }

    public string? direct_line { get; set; }

    public string? direct_fax { get; set; }

    public ushort office_id { get; set; }

    public string? house_phone { get; set; }
}
