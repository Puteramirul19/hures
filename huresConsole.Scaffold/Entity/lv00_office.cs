using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class lv00_office
{
    public uint office_id { get; set; }

    public string office { get; set; } = null!;

    public string address1 { get; set; } = null!;

    public string? address2 { get; set; }

    public string? city { get; set; }

    public byte state_id { get; set; }

    public ushort? country_id { get; set; }

    public string? postcode { get; set; }

    public string? phone { get; set; }

    public string? fax { get; set; }

    public uint? division_id { get; set; }

    public string? email { get; set; }
}
