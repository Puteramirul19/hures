using System;
using System.Collections.Generic;

namespace huresConsole.Scaffold.Entity;

public partial class LEAVE
{
    public string NoPekerja { get; set; } = null!;

    public string NamaPekerja { get; set; } = null!;

    public string? KodStesen { get; set; }

    public string? NoKadPengenalan { get; set; }

    public string? KodRekodSepi { get; set; }

    public string? KodGaji { get; set; }

    public string? TahunCuti { get; set; }

    public string? KelayakanCuti { get; set; }

    public string? PerubahanLayak { get; set; }

    public string? TarikhKuatkuasa { get; set; }

    public string? CutiLamaDibawa { get; set; }

    public string? JumlahCutiBagiTahun { get; set; }

    public string? CutiDiambil { get; set; }

    public string? CutiDibawaKeDepan { get; set; }

    public string? CutiDihapuskan { get; set; }

    public string? CutiSeberangLautDiambil { get; set; }

    public string? CutiTukarKeWangTunai { get; set; }

    public string? CutiDibekukan { get; set; }

    public string? CutiSakit { get; set; }

    public string? CutiTanpaGaji { get; set; }

    public string? CutiSeparuhGaji { get; set; }

    public string? TidakHadir { get; set; }

    public string? CutiSeberangLaut { get; set; }

    public string? CutiSeberangLautLama { get; set; }

    public string? CutiTanpaGajiDikumpul { get; set; }

    public string? CutiSeparuhGajiDikumpul { get; set; }

    public string? CutiTukarWangTunaiDikumpul { get; set; }

    public string? NoRujukanCutiSakit90 { get; set; }

    public string? JumlahTerlebihAmbil { get; set; }

    public string? OpsTukarWangTunaiThn { get; set; }

    public string? TahunMulaCutiDikumpul { get; set; }

    public string? CutiRehatTahunKumpul { get; set; }

    public string? CutiRehatTahunKumpulDiguna { get; set; }

    public string? JumlahCutiRehatTahunKumpul { get; set; }

    public string? BezaanCutiKumpul { get; set; }

    public string? PetunjukCuti { get; set; }
}
