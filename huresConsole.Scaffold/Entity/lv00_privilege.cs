using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_privilege
{
    public uint right_id { get; set; }

    public int main_id { get; set; }

    public int module_id { get; set; }

    public sbyte rights { get; set; }
}
