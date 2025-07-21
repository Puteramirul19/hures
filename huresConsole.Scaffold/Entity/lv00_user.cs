using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_user
{
    public string username { get; set; } = null!;

    public string password { get; set; } = null!;

    public uint main_id { get; set; }

    public int group_id { get; set; }

    public bool? status { get; set; }
}
