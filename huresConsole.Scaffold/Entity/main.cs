using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class main
{
    public uint msg_id { get; set; }

    public sbyte? submit_by { get; set; }

    public DateTime submit_date { get; set; }

    public string author { get; set; } = null!;

    public byte cat_id { get; set; }

    public DateTime date_in { get; set; }

    public DateTime date_out { get; set; }

    public string? title { get; set; }

    public byte[]? message { get; set; }

    public byte[]? longmessage { get; set; }

    public string links { get; set; } = null!;

    public string? image_loc { get; set; }

    public string? image { get; set; }

    public sbyte? hotnews { get; set; }
}
