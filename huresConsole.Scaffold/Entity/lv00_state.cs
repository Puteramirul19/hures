using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_state
{
    public byte state_id { get; set; }

    public string state_abbr { get; set; } = null!;

    public string state { get; set; } = null!;
}
