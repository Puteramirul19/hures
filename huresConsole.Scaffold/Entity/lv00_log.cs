using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_log
{
    public string nid { get; set; } = null!;

    public uint main_id { get; set; }

    public string name { get; set; } = null!;

    public string staff_id { get; set; } = null!;

    public string page { get; set; } = null!;

    public DateTime latest_time { get; set; }

    public DateTime start_time { get; set; }

    public DateTime logout_time { get; set; }

    public string ip_address { get; set; } = null!;
}
