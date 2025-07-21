using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class JAWATAN
{
    public string KodJawatan { get; set; } = null!;

    public string KodTugas { get; set; } = null!;

    public string? Jawatan1 { get; set; }

    public string? Tugas { get; set; }

    public string? KodGajiTugas { get; set; }
}
