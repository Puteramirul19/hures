using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class GAJI
{
    public string NoPekerja { get; set; } = null!;

    public string? NamaPekerja { get; set; }

    public string? KodStesen { get; set; }

    public string? NoKadPengenalan { get; set; }

    public string? TarikhGajiMula { get; set; }

    public string? KodGaji { get; set; }

    public string? GajiPokok { get; set; }

    public string? KodPerubahanGaji { get; set; }

    public string? TarikhGajiNaik { get; set; }

    public string? JumlahPerubahanGaji { get; set; }

    public string? NoRujukanPerubahanGaji { get; set; }

    public string? KodUlangkaji { get; set; }

    public string? JumlahPrestasi { get; set; }
}
