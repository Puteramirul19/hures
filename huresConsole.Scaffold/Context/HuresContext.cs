using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using huresConsole.Scaffold.Entity;

namespace huresConsole.Scaffold.Context;

public partial class HuresContext : DbContext
{
    public HuresContext()
    {
    }

    public HuresContext(DbContextOptions<HuresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ACCOUNTSTATUS> ACCOUNTSTATUS { get; set; }

    public virtual DbSet<AGAMA> AGAMA { get; set; }

    public virtual DbSet<BAHAGIAN> BAHAGIAN { get; set; }

    public virtual DbSet<BAHASA> BAHASA { get; set; }

    public virtual DbSet<BDGAJI> BDGAJI { get; set; }

    public virtual DbSet<CUTI> CUTI { get; set; }

    public virtual DbSet<DATAASAS> DATAASAS { get; set; }

    public virtual DbSet<GAJI> GAJI { get; set; }

    public virtual DbSet<JANTINA> JANTINA { get; set; }

    public virtual DbSet<JAWATAN> JAWATAN { get; set; }

    public virtual DbSet<JAWATANSTESEN> JAWATANSTESEN { get; set; }

    public virtual DbSet<KECACATAN> KECACATAN { get; set; }

    public virtual DbSet<KELASKAKITANGAN> KELASKAKITANGAN { get; set; }

    public virtual DbSet<KETURUNAN> KETURUNAN { get; set; }

    public virtual DbSet<KODCUTI> KODCUTI { get; set; }

    public virtual DbSet<KOMPLIMEN> KOMPLIMEN { get; set; }

    public virtual DbSet<LEAVE> LEAVE { get; set; }

    public virtual DbSet<LEAVELIST83> LEAVELIST83 { get; set; }

    public virtual DbSet<LEAVELIST84> LEAVELIST84 { get; set; }

    public virtual DbSet<LEAVELIST85> LEAVELIST85 { get; set; }

    public virtual DbSet<LEAVELIST86> LEAVELIST86 { get; set; }

    public virtual DbSet<LEAVELIST87> LEAVELIST87 { get; set; }

    public virtual DbSet<LEAVELIST88> LEAVELIST88 { get; set; }

    public virtual DbSet<LEAVELIST89> LEAVELIST89 { get; set; }

    public virtual DbSet<LEAVELIST90> LEAVELIST90 { get; set; }

    public virtual DbSet<LEAVELIST91> LEAVELIST91 { get; set; }

    public virtual DbSet<LEAVELIST92> LEAVELIST92 { get; set; }

    public virtual DbSet<LEAVELIST93> LEAVELIST93 { get; set; }

    public virtual DbSet<LEAVELIST94> LEAVELIST94 { get; set; }

    public virtual DbSet<LEAVELIST95> LEAVELIST95 { get; set; }

    public virtual DbSet<LEAVELIST96> LEAVELIST96 { get; set; }

    public virtual DbSet<LEAVELIST97> LEAVELIST97 { get; set; }

    public virtual DbSet<LEAVELIST98> LEAVELIST98 { get; set; }

    public virtual DbSet<LEAVELIST99> LEAVELIST99 { get; set; }

    public virtual DbSet<LOGIN> LOGIN { get; set; }

    public virtual DbSet<MENYANDANG> MENYANDANG { get; set; }

    public virtual DbSet<NEGERI> NEGERI { get; set; }

    public virtual DbSet<PERSARAAN> PERSARAAN { get; set; }

    public virtual DbSet<PERUBAHANGAJI> PERUBAHANGAJI { get; set; }

    public virtual DbSet<REKODSEPI> REKODSEPI { get; set; }

    public virtual DbSet<SKILGAJI> SKILGAJI { get; set; }

    public virtual DbSet<STAFFDETAILS> STAFFDETAILS { get; set; }

    public virtual DbSet<STESEN> STESEN { get; set; }

    public virtual DbSet<TARAFKAHWIN> TARAFKAHWIN { get; set; }

    public virtual DbSet<WARGANEGARA> WARGANEGARA { get; set; }

    public virtual DbSet<category> category { get; set; }

    public virtual DbSet<lv00_division> lv00_division { get; set; }

    public virtual DbSet<lv00_group> lv00_group { get; set; }

    public virtual DbSet<lv00_log> lv00_log { get; set; }

    public virtual DbSet<lv00_main> lv00_main { get; set; }

    public virtual DbSet<lv00_module> lv00_module { get; set; }

    public virtual DbSet<lv00_office> lv00_office { get; set; }

    public virtual DbSet<lv00_privilege> lv00_privilege { get; set; }

    public virtual DbSet<lv00_state> lv00_state { get; set; }

    public virtual DbSet<lv00_user> lv00_user { get; set; }

    public virtual DbSet<main> main { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3309;user=root;password=root;database=hures_backup", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<ACCOUNTSTATUS>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.StaffNo)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.StatusBy)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.StatusDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<AGAMA>(entity =>
        {
            entity.HasKey(e => e.KodAgama).HasName("PRIMARY");

            entity.Property(e => e.KodAgama)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrAgama).HasMaxLength(100);
        });

        modelBuilder.Entity<BAHAGIAN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KodBahagian)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.KtrBahagian).HasMaxLength(20);
        });

        modelBuilder.Entity<BAHASA>(entity =>
        {
            entity.HasKey(e => e.KodBahasa).HasName("PRIMARY");

            entity.Property(e => e.KodBahasa)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrBahasa).HasMaxLength(100);
        });

        modelBuilder.Entity<BDGAJI>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KeteranganNegeri).HasMaxLength(15);
            entity.Property(e => e.KodBhgDaftarGaji).HasMaxLength(4);
            entity.Property(e => e.KogNegeri)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KtrBDGaji).HasMaxLength(25);
        });

        modelBuilder.Entity<CUTI>(entity =>
        {
            entity.HasKey(e => e.KodCuti).HasName("PRIMARY");

            entity.Property(e => e.KodCuti)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrCuti).HasMaxLength(100);
        });

        modelBuilder.Entity<DATAASAS>(entity =>
        {
            entity.HasKey(e => e.NoPekerja).HasName("PRIMARY");

            entity.HasIndex(e => e.GajiPokok, "GajiPokok").HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.AlamatBaris1).HasMaxLength(24);
            entity.Property(e => e.AlamatBaris2).HasMaxLength(24);
            entity.Property(e => e.AlamatBaris3).HasMaxLength(24);
            entity.Property(e => e.AlamatBaris4).HasMaxLength(24);
            entity.Property(e => e.AlamatBaris5).HasMaxLength(24);
            entity.Property(e => e.Bahagian)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.BahasaLisan1)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaLisan2)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaLisan3)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaLisan4)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaLisan5)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaTulisan1)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaTulisan2)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaTulisan3)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaTulisan4)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BahasaTulisan5)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Bintang1)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Bintang2)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Bintang3)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Bintang4)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Bintang5)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.GajiPokok).HasMaxLength(7);
            entity.Property(e => e.Gelaran1)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Gelaran2)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Gelaran3)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Gelaran4)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Gelaran5)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Jantina)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Keturunan)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.KodBahagian)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.KodBahgDaftarGaji).HasMaxLength(4);
            entity.Property(e => e.KodGaji).HasMaxLength(7);
            entity.Property(e => e.KodJwtStesen).HasMaxLength(4);
            entity.Property(e => e.KodKecacatan)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.KodKelasJawatan).HasMaxLength(10);
            entity.Property(e => e.KodKelasKakitangan).HasMaxLength(7);
            entity.Property(e => e.KodKelayakanMasuk).HasMaxLength(4);
            entity.Property(e => e.KodKpDikeluarkan)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodLokasi)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.KodNegeriLahir)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodPenyatuan)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.KodPerubahanGaji)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodPetunjukDisplin)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodStesen).HasMaxLength(4);
            entity.Property(e => e.KodUlangkaji).HasMaxLength(4);
            entity.Property(e => e.Kumpulan)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.NamaBelumKahwin).HasMaxLength(40);
            entity.Property(e => e.NamaLain).HasMaxLength(40);
            entity.Property(e => e.NamaPekerja).HasMaxLength(40);
            entity.Property(e => e.NoAhliKwkk).HasMaxLength(7);
            entity.Property(e => e.NoAhliPerkeso).HasMaxLength(13);
            entity.Property(e => e.NoCukaiPendapatan).HasMaxLength(15);
            entity.Property(e => e.NoEpf).HasMaxLength(10);
            entity.Property(e => e.NoKadPengenalan).HasMaxLength(8);
            entity.Property(e => e.NoRujukanKuasa).HasMaxLength(8);
            entity.Property(e => e.NoRujukanKuasaSahJwt).HasMaxLength(8);
            entity.Property(e => e.NoTelepon).HasMaxLength(8);
            entity.Property(e => e.Opsyen)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.OpsyenCashIndicator)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PetunjukKerjaGilir)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PetunjukPelajarLembaga)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PetunjukPinjamRumah)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PilihanEpfPencen)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.RujukanSepi).HasMaxLength(8);
            entity.Property(e => e.TahunOpsyen).HasMaxLength(4);
            entity.Property(e => e.TarafKahwin)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.TarafMenyandang)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.TarafPerkhidamatan)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.TarikhGajiMula).HasMaxLength(8);
            entity.Property(e => e.TarikhLahir).HasMaxLength(8);
            entity.Property(e => e.TarikhMasukJabatan).HasMaxLength(8);
            entity.Property(e => e.TarikhMulaKhidmat).HasMaxLength(8);
            entity.Property(e => e.TarikhSahJawatan).HasMaxLength(8);
            entity.Property(e => e.TarikhSepi).HasMaxLength(8);
            entity.Property(e => e.TarikhTukarNaikPangkat).HasMaxLength(8);
            entity.Property(e => e.TempatLahir).HasMaxLength(20);
            entity.Property(e => e.Ugama)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Warganegara)
                .HasMaxLength(2)
                .IsFixedLength();
        });

        modelBuilder.Entity<GAJI>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.GajiPokok).HasMaxLength(7);
            entity.Property(e => e.JumlahPerubahanGaji).HasMaxLength(6);
            entity.Property(e => e.JumlahPrestasi).HasMaxLength(6);
            entity.Property(e => e.KodGaji).HasMaxLength(7);
            entity.Property(e => e.KodPerubahanGaji)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodStesen).HasMaxLength(4);
            entity.Property(e => e.KodUlangkaji).HasMaxLength(4);
            entity.Property(e => e.NamaPekerja).HasMaxLength(40);
            entity.Property(e => e.NoKadPengenalan).HasMaxLength(8);
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanPerubahanGaji).HasMaxLength(6);
            entity.Property(e => e.TarikhGajiMula).HasMaxLength(8);
            entity.Property(e => e.TarikhGajiNaik).HasMaxLength(4);
        });

        modelBuilder.Entity<JANTINA>(entity =>
        {
            entity.HasKey(e => e.KodJantina).HasName("PRIMARY");

            entity.Property(e => e.KodJantina)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrJantina).HasMaxLength(100);
        });

        modelBuilder.Entity<JAWATAN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Jawatan1)
                .HasMaxLength(20)
                .HasColumnName("Jawatan");
            entity.Property(e => e.KodGajiTugas).HasMaxLength(6);
            entity.Property(e => e.KodJawatan)
                .HasMaxLength(6)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodTugas)
                .HasMaxLength(6)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Tugas).HasMaxLength(20);
        });

        modelBuilder.Entity<JAWATANSTESEN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KodJwtStn).HasMaxLength(4);
            entity.Property(e => e.KtrJwtStn).HasMaxLength(25);
        });

        modelBuilder.Entity<KECACATAN>(entity =>
        {
            entity.HasKey(e => e.KodKecacatan).HasName("PRIMARY");

            entity.Property(e => e.KodKecacatan)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrKecacatan).HasMaxLength(100);
        });

        modelBuilder.Entity<KELASKAKITANGAN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KodKelasKakitangan).HasMaxLength(7);
            entity.Property(e => e.KtrKelas).HasMaxLength(20);
        });

        modelBuilder.Entity<KETURUNAN>(entity =>
        {
            entity.HasKey(e => e.KodKeturunan).HasName("PRIMARY");

            entity.Property(e => e.KodKeturunan)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrKeturunan).HasMaxLength(100);
        });

        modelBuilder.Entity<KODCUTI>(entity =>
        {
            entity.HasKey(e => e.KodLeave).HasName("PRIMARY");

            entity.Property(e => e.KodLeave)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KtrLeave)
                .HasMaxLength(2)
                .IsFixedLength();
        });

        modelBuilder.Entity<KOMPLIMEN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilBaru)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilHenti)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilJwtKhas)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BilJwtLulus).HasMaxLength(4);
            entity.Property(e => e.BilJwtPtg)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BilKtBawa)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilMeninggal)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BilSara)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentBaru)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentBawa)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentHenti)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentMeninggal)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BilSentSara)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentTukarKeluar)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilSentTukarmasuk)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilTukarKeluar)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.BilTukarMasuk)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Jawatan).HasMaxLength(20);
            entity.Property(e => e.KodGajiJwt).HasMaxLength(6);
            entity.Property(e => e.KodJwt).HasMaxLength(6);
            entity.Property(e => e.KodTugas).HasMaxLength(4);
            entity.Property(e => e.Seksyen)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Stesen).HasMaxLength(4);
            entity.Property(e => e.Tahun).HasMaxLength(4);
            entity.Property(e => e.Tugas).HasMaxLength(20);
        });

        modelBuilder.Entity<LEAVE>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BezaanCutiKumpul).HasMaxLength(5);
            entity.Property(e => e.CutiDiambil).HasMaxLength(5);
            entity.Property(e => e.CutiDibawaKeDepan).HasMaxLength(5);
            entity.Property(e => e.CutiDibekukan).HasMaxLength(5);
            entity.Property(e => e.CutiDihapuskan).HasMaxLength(5);
            entity.Property(e => e.CutiLamaDibawa).HasMaxLength(5);
            entity.Property(e => e.CutiRehatTahunKumpul).HasMaxLength(5);
            entity.Property(e => e.CutiRehatTahunKumpulDiguna).HasMaxLength(5);
            entity.Property(e => e.CutiSakit).HasMaxLength(5);
            entity.Property(e => e.CutiSeberangLaut).HasMaxLength(5);
            entity.Property(e => e.CutiSeberangLautDiambil).HasMaxLength(5);
            entity.Property(e => e.CutiSeberangLautLama).HasMaxLength(5);
            entity.Property(e => e.CutiSeparuhGaji).HasMaxLength(5);
            entity.Property(e => e.CutiSeparuhGajiDikumpul).HasMaxLength(7);
            entity.Property(e => e.CutiTanpaGaji).HasMaxLength(5);
            entity.Property(e => e.CutiTanpaGajiDikumpul).HasMaxLength(7);
            entity.Property(e => e.CutiTukarKeWangTunai).HasMaxLength(5);
            entity.Property(e => e.CutiTukarWangTunaiDikumpul).HasMaxLength(7);
            entity.Property(e => e.JumlahCutiBagiTahun).HasMaxLength(5);
            entity.Property(e => e.JumlahCutiRehatTahunKumpul).HasMaxLength(5);
            entity.Property(e => e.JumlahTerlebihAmbil)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.KelayakanCuti).HasMaxLength(5);
            entity.Property(e => e.KodGaji).HasMaxLength(7);
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.KodStesen).HasMaxLength(4);
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan).HasMaxLength(8);
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCutiSakit90).HasMaxLength(10);
            entity.Property(e => e.OpsTukarWangTunaiThn).HasMaxLength(5);
            entity.Property(e => e.PerubahanLayak)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.TahunCuti).HasMaxLength(4);
            entity.Property(e => e.TahunMulaCutiDikumpul).HasMaxLength(4);
            entity.Property(e => e.TarikhKuatkuasa).HasMaxLength(8);
            entity.Property(e => e.TidakHadir).HasMaxLength(5);
        });

        modelBuilder.Entity<LEAVELIST83>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST84>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST85>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST86>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST87>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST88>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST89>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST90>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST91>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST92>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST93>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST94>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST95>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST96>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST97>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST98>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LEAVELIST99>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BilHariAmRehat)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.BilHariCuti)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.JenisCuti)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodGaji)
                .HasMaxLength(7)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.KodStesen)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NamaPekerja)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoKadPengenalan)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoPekerja)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NoRujukanCuti)
                .HasMaxLength(23)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PetunjukCuti)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.TahunCuti)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiMula)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TarikhCutiTamat)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LOGIN>(entity =>
        {
            entity.HasKey(e => e.StaffNo).HasName("PRIMARY");

            entity.Property(e => e.StaffNo)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.StaffName).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        modelBuilder.Entity<MENYANDANG>(entity =>
        {
            entity.HasKey(e => e.KodMenyandang).HasName("PRIMARY");

            entity.Property(e => e.KodMenyandang)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrMenyandang).HasMaxLength(100);
        });

        modelBuilder.Entity<NEGERI>(entity =>
        {
            entity.HasKey(e => e.KodNegeri).HasName("PRIMARY");

            entity.Property(e => e.KodNegeri)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrNegeri).HasMaxLength(100);
        });

        modelBuilder.Entity<PERSARAAN>(entity =>
        {
            entity.HasKey(e => e.KodPersaraan).HasName("PRIMARY");

            entity.Property(e => e.KodPersaraan)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrPersaraan).HasMaxLength(100);
        });

        modelBuilder.Entity<PERUBAHANGAJI>(entity =>
        {
            entity.HasKey(e => e.KodPerubahanGaji).HasName("PRIMARY");

            entity.Property(e => e.KodPerubahanGaji)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrPerubahanGaji).HasMaxLength(100);
        });

        modelBuilder.Entity<REKODSEPI>(entity =>
        {
            entity.HasKey(e => e.KodRekodSepi).HasName("PRIMARY");

            entity.Property(e => e.KodRekodSepi)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrRekodSepi).HasMaxLength(100);
        });

        modelBuilder.Entity<SKILGAJI>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KodSkilGaji).HasMaxLength(7);
            entity.Property(e => e.KtrSkilGaji).HasMaxLength(54);
        });

        modelBuilder.Entity<STAFFDETAILS>(entity =>
        {
            entity.HasKey(e => e.StaffNo).HasName("PRIMARY");

            entity.Property(e => e.StaffNo)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.StaffName).HasMaxLength(100);
            entity.Property(e => e.UserLevelID).HasMaxLength(10);
        });

        modelBuilder.Entity<STESEN>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Keterangan).HasMaxLength(15);
            entity.Property(e => e.KodNegeri)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.KodStesen).HasMaxLength(4);
        });

        modelBuilder.Entity<TARAFKAHWIN>(entity =>
        {
            entity.HasKey(e => e.KodTarafKahwin).HasName("PRIMARY");

            entity.Property(e => e.KodTarafKahwin)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrTarafKahwin).HasMaxLength(100);
        });

        modelBuilder.Entity<WARGANEGARA>(entity =>
        {
            entity.HasKey(e => e.KodWarganegara).HasName("PRIMARY");

            entity.Property(e => e.KodWarganegara)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
            entity.Property(e => e.KtrWarganegara).HasMaxLength(100);
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.cat_id).HasName("PRIMARY");

            entity.Property(e => e.cat_id)
                .ValueGeneratedOnAdd()
                .HasColumnType("tinyint(3) unsigned");
            entity.Property(e => e.category1)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("category");
        });

        modelBuilder.Entity<lv00_division>(entity =>
        {
            entity.HasKey(e => e.division_id).HasName("PRIMARY");

            entity.Property(e => e.division_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.division)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<lv00_group>(entity =>
        {
            entity.HasKey(e => e.group_id).HasName("PRIMARY");

            entity.Property(e => e.group_id).HasColumnType("smallint(5) unsigned");
            entity.Property(e => e.group_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<lv00_log>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ip_address)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.latest_time)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.logout_time)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp");
            entity.Property(e => e.main_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.name)
                .HasMaxLength(150)
                .HasDefaultValueSql("''");
            entity.Property(e => e.nid)
                .HasMaxLength(32)
                .HasDefaultValueSql("''");
            entity.Property(e => e.page)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.staff_id)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.start_time)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<lv00_main>(entity =>
        {
            entity.HasKey(e => e.main_id).HasName("PRIMARY");

            entity.HasIndex(e => e.staff_id, "staff_id").IsUnique();

            entity.Property(e => e.main_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.direct_fax)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.direct_line)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.house_phone)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.mobile)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.name)
                .HasMaxLength(150)
                .HasDefaultValueSql("''");
            entity.Property(e => e.office_id).HasColumnType("smallint(5) unsigned");
            entity.Property(e => e.phone_ext)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.sms)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.staff_id)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<lv00_module>(entity =>
        {
            entity.HasKey(e => e.module_id).HasName("PRIMARY");

            entity.Property(e => e.module_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<lv00_office>(entity =>
        {
            entity.HasKey(e => e.office_id).HasName("PRIMARY");

            entity.Property(e => e.office_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.address1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.address2)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.city)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.country_id)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(5) unsigned");
            entity.Property(e => e.division_id)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned");
            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.fax).HasMaxLength(100);
            entity.Property(e => e.office)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.phone).HasMaxLength(100);
            entity.Property(e => e.postcode).HasMaxLength(15);
            entity.Property(e => e.state_id).HasColumnType("tinyint(3) unsigned");
        });

        modelBuilder.Entity<lv00_privilege>(entity =>
        {
            entity.HasKey(e => e.right_id).HasName("PRIMARY");

            entity.Property(e => e.right_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.main_id).HasColumnType("int(11)");
            entity.Property(e => e.module_id).HasColumnType("int(11)");
            entity.Property(e => e.rights).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<lv00_state>(entity =>
        {
            entity.HasKey(e => e.state_id).HasName("PRIMARY");

            entity.Property(e => e.state_id)
                .ValueGeneratedOnAdd()
                .HasColumnType("tinyint(3) unsigned");
            entity.Property(e => e.state)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.state_abbr)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<lv00_user>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.group_id).HasColumnType("int(11)");
            entity.Property(e => e.main_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.password)
                .HasMaxLength(32)
                .HasDefaultValueSql("''");
            entity.Property(e => e.status)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.username)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<main>(entity =>
        {
            entity.HasKey(e => e.msg_id).HasName("PRIMARY");

            entity.Property(e => e.msg_id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.author)
                .HasMaxLength(150)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.cat_id).HasColumnType("tinyint(3) unsigned");
            entity.Property(e => e.date_in)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp");
            entity.Property(e => e.date_out)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp");
            entity.Property(e => e.hotnews)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)");
            entity.Property(e => e.image).HasMaxLength(255);
            entity.Property(e => e.image_loc).HasMaxLength(5);
            entity.Property(e => e.links)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.longmessage).HasColumnType("blob");
            entity.Property(e => e.message).HasColumnType("blob");
            entity.Property(e => e.submit_by).HasColumnType("tinyint(4)");
            entity.Property(e => e.submit_date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
