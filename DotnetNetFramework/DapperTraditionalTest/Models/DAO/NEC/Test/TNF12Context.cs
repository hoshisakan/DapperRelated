using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.DAO.NEC.Test;

public partial class TNF12Context : DbContext
{
    public TNF12Context()
    {
    }

    public TNF12Context(DbContextOptions<TNF12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<APLog> APLogs { get; set; }

    public virtual DbSet<ClientLog> ClientLogs { get; set; }

    public virtual DbSet<Company_> Company_s { get; set; }

    public virtual DbSet<Company_M> Company_Ms { get; set; }

    public virtual DbSet<ConsentTable> ConsentTables { get; set; }

    public virtual DbSet<Del_Company_M> Del_Company_Ms { get; set; }

    public virtual DbSet<FactoryArea> FactoryAreas { get; set; }

    public virtual DbSet<FileTable> FileTables { get; set; }

    public virtual DbSet<GroupAct> GroupActs { get; set; }

    public virtual DbSet<Kiosk_CardPrintLog> Kiosk_CardPrintLogs { get; set; }

    public virtual DbSet<Kiosk_Company_> Kiosk_Company_s { get; set; }

    public virtual DbSet<Kiosk_Company_M> Kiosk_Company_Ms { get; set; }

    public virtual DbSet<Kiosk_ConsentTable> Kiosk_ConsentTables { get; set; }

    public virtual DbSet<Kiosk_ConsentTableVersionLog> Kiosk_ConsentTableVersionLogs { get; set; }

    public virtual DbSet<Kiosk_Del_Company_M> Kiosk_Del_Company_Ms { get; set; }

    public virtual DbSet<Kiosk_DeviceInformation> Kiosk_DeviceInformations { get; set; }

    public virtual DbSet<Kiosk_FactoryArea> Kiosk_FactoryAreas { get; set; }

    public virtual DbSet<Kiosk_FileTable> Kiosk_FileTables { get; set; }

    public virtual DbSet<Kiosk_GroupAct> Kiosk_GroupActs { get; set; }

    public virtual DbSet<Kiosk_OperateLog> Kiosk_OperateLogs { get; set; }

    public virtual DbSet<Kiosk_Parameter> Kiosk_Parameters { get; set; }

    public virtual DbSet<Kiosk_Parameter1> Kiosk_Parameter1s { get; set; }

    public virtual DbSet<Kiosk_SystemCodeInfo> Kiosk_SystemCodeInfos { get; set; }

    public virtual DbSet<Kiosk_TNF_APAUDITLOG> Kiosk_TNF_APAUDITLOGs { get; set; }

    public virtual DbSet<Kiosk_TempList> Kiosk_TempLists { get; set; }

    public virtual DbSet<Kiosk_UserAct> Kiosk_UserActs { get; set; }

    public virtual DbSet<Kiosk_WhiteList> Kiosk_WhiteLists { get; set; }

    public virtual DbSet<Kiosk_WhiteList_Log> Kiosk_WhiteList_Logs { get; set; }

    public virtual DbSet<Kiosk_passlog> Kiosk_passlogs { get; set; }

    public virtual DbSet<Kiosk_passlog_backup> Kiosk_passlog_backups { get; set; }

    public virtual DbSet<Kiosk_tblMember> Kiosk_tblMembers { get; set; }

    public virtual DbSet<OperateLog> OperateLogs { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<Parameter1> Parameter1s { get; set; }

    public virtual DbSet<Parameter2> Parameter2s { get; set; }

    public virtual DbSet<TNF_APAUDITLOG> TNF_APAUDITLOGs { get; set; }

    public virtual DbSet<TempList> TempLists { get; set; }

    public virtual DbSet<UserAct> UserActs { get; set; }

    public virtual DbSet<WhiteList> WhiteLists { get; set; }

    public virtual DbSet<WhiteList_Log> WhiteList_Logs { get; set; }

    public virtual DbSet<passlog> passlogs { get; set; }

    public virtual DbSet<passlogByJayTest> passlogByJayTests { get; set; }

    public virtual DbSet<passlog_backup> passlog_backups { get; set; }

    public virtual DbSet<passlog_photo> passlog_photos { get; set; }

    public virtual DbSet<tblMember> tblMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;User ID=sa;Password=2wsx1qaz`;Database=TNF12;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<APLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APLog");

            entity.Property(e => e.AlertCheck).HasMaxLength(10);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");
            entity.Property(e => e.ServerIP).HasMaxLength(50);
            entity.Property(e => e.ServerPort)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<ClientLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ClientLog");

            entity.Property(e => e.AlertCheck).HasMaxLength(10);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.FactoryArea).HasMaxLength(10);
            entity.Property(e => e.GateNo).HasMaxLength(50);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");
            entity.Property(e => e.ServerIP).HasMaxLength(50);
            entity.Property(e => e.ServerPort).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Company_>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Company_S");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Co_Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CreateSite).HasMaxLength(10);
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TrackMod)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Company_M>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Company_M");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.FetData_1).HasColumnType("image");
            entity.Property(e => e.FetData_2).HasColumnType("image");
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ImgData_1).HasColumnType("image");
            entity.Property(e => e.ImgData_2).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.P_Name).HasMaxLength(12);
            entity.Property(e => e.P_Sex)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<ConsentTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConsentTable");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EmpID).HasMaxLength(8);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Del_Company_M>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Del_Company_M");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DelDate)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.FetData_1).HasColumnType("image");
            entity.Property(e => e.FetData_2).HasColumnType("image");
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ImgData_1).HasColumnType("image");
            entity.Property(e => e.ImgData_2).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.P_Name).HasMaxLength(12);
            entity.Property(e => e.P_Sex)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<FactoryArea>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FactoryArea");

            entity.Property(e => e.FactoryArea1)
                .HasMaxLength(10)
                .HasColumnName("FactoryArea");
        });

        modelBuilder.Entity<FileTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FileTable");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.File1).HasMaxLength(10);
            entity.Property(e => e.File2).HasMaxLength(10);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<GroupAct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GroupAct");

            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DeviceMonitoring)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.EmpPms).HasMaxLength(10);
            entity.Property(e => e.FunComp)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunCompAdd)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunCompFile)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunDiagram)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunGate).HasMaxLength(10);
            entity.Property(e => e.FunGroup)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunPass)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunUser)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.OperateLog)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Parameter)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
            entity.Property(e => e.WhiteList)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Kiosk_CardPrintLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_CardPrintLog");

            entity.Property(e => e.CNAME).HasMaxLength(30);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ENAME).HasMaxLength(50);
            entity.Property(e => e.GateNo).HasMaxLength(50);
            entity.Property(e => e.IPAddress).HasMaxLength(30);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");
            entity.Property(e => e.Mode).HasMaxLength(10);
            entity.Property(e => e.ORG_ID).HasMaxLength(20);
            entity.Property(e => e.PERSON_CODE).HasMaxLength(10);
            entity.Property(e => e.PrinterName).HasMaxLength(50);
            entity.Property(e => e.ReaderName).HasMaxLength(50);
            entity.Property(e => e.Result).HasMaxLength(1);
        });

        modelBuilder.Entity<Kiosk_Company_>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_Company_S");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Co_Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CreateSite).HasMaxLength(10);
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TrackMod)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Kiosk_Company_M>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_Company_M");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.FetData_1).HasColumnType("image");
            entity.Property(e => e.FetData_2).HasColumnType("image");
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ImgData_1).HasColumnType("image");
            entity.Property(e => e.ImgData_2).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.P_Name).HasMaxLength(12);
            entity.Property(e => e.P_Sex)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<Kiosk_ConsentTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_ConsentTable");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EmpID).HasMaxLength(8);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Kiosk_ConsentTableVersionLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_ConsentTableVersionLog");

            entity.Property(e => e.Agree).HasMaxLength(1);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EmpID).HasMaxLength(8);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.Version).HasMaxLength(100);
        });

        modelBuilder.Entity<Kiosk_Del_Company_M>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_Del_Company_M");

            entity.Property(e => e.CancelID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.CancelReason).HasMaxLength(50);
            entity.Property(e => e.CancelTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DelDate)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.FetData_1).HasColumnType("image");
            entity.Property(e => e.FetData_2).HasColumnType("image");
            entity.Property(e => e.ID)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ImgData_1).HasColumnType("image");
            entity.Property(e => e.ImgData_2).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.P_Name).HasMaxLength(12);
            entity.Property(e => e.P_Sex)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<Kiosk_DeviceInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_DeviceInformation");

            entity.Property(e => e.DeviceNo).HasMaxLength(20);
            entity.Property(e => e.FuncGroup).HasMaxLength(50);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<Kiosk_FactoryArea>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_FactoryArea");

            entity.Property(e => e.FactoryArea).HasMaxLength(10);
        });

        modelBuilder.Entity<Kiosk_FileTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_FileTable");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.File1).HasMaxLength(10);
            entity.Property(e => e.File2).HasMaxLength(10);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Kiosk_GroupAct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_GroupAct");

            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DeviceMonitoring)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.EmpPms).HasMaxLength(10);
            entity.Property(e => e.FunComp)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunCompAdd)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunCompFile)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunDiagram)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunGate).HasMaxLength(10);
            entity.Property(e => e.FunGroup)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunPass)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.FunUser)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.OperateLog)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Parameter)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<Kiosk_OperateLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_OperateLog");

            entity.Property(e => e.Action)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ActionContent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ActionTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.IP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.Syscode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_Parameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_Parameter");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Group)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_Parameter1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_Parameter1");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Group)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_SystemCodeInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_SystemCodeInfo");

            entity.Property(e => e.CodeGroup).HasMaxLength(50);
            entity.Property(e => e.CodeID).HasMaxLength(50);
            entity.Property(e => e.CodeValue).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Kiosk_TNF_APAUDITLOG>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_TNF_APAUDITLOG");

            entity.Property(e => e.CLIENT_IP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FN_KEYVALUE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FN_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FN_PROC)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FN_STTS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FN_TYPE)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PROC_DATETIME)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.PROJ_CODE)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.USER_ID)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_TempList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_TempList");

            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<Kiosk_UserAct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_UserAct");

            entity.Property(e => e.Area).HasMaxLength(5);
            entity.Property(e => e.ChangePwdDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.EmpID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.EmpName).HasMaxLength(12);
            entity.Property(e => e.EmpPms).HasMaxLength(10);
            entity.Property(e => e.EmpPwd).HasMaxLength(12);
            entity.Property(e => e.LockTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Place).HasMaxLength(5);
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<Kiosk_WhiteList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_WhiteList");

            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.ID).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<Kiosk_WhiteList_Log>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_WhiteList_Log");

            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.ID).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<Kiosk_passlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_passlog");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fail).IsUnicode(false);
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GatePass).HasMaxLength(5);
            entity.Property(e => e.HTTPEMS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HitOrNonhit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PHOTO_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Score)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasMaxLength(50);
            entity.Property(e => e.Threshold)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_passlog_backup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_passlog_backup");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fail).IsUnicode(false);
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GatePass).HasMaxLength(5);
            entity.Property(e => e.HTTPEMS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HitOrNonhit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PHOTO_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Score)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasMaxLength(50);
            entity.Property(e => e.Threshold)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kiosk_tblMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk_tblMember");

            entity.Property(e => e.Birthday)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.CardNo).IsUnicode(false);
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.EnrollFeature)
                .HasMaxLength(6732)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EnrollImage).IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ICardNo)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsPwd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoblieBarcode)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.TWAT)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.refA).HasMaxLength(50);
            entity.Property(e => e.refB).HasMaxLength(50);
            entity.Property(e => e.refC).HasMaxLength(50);
        });

        modelBuilder.Entity<OperateLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OperateLog");

            entity.Property(e => e.Action)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ActionContent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ActionTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.IP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.Syscode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Parameter");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Group)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parameter1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Parameter1");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Group)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parameter2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Parameter2");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Group).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(100);
        });

        modelBuilder.Entity<TNF_APAUDITLOG>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TNF_APAUDITLOG");

            entity.Property(e => e.CLIENT_IP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FN_KEYVALUE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FN_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FN_PROC)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FN_STTS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FN_TYPE)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PROC_DATETIME)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.PROJ_CODE)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.USER_ID)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TempList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TempList");

            entity.Property(e => e.Door).HasMaxLength(10);
            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.GateType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<UserAct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserAct");

            entity.Property(e => e.Area).HasMaxLength(5);
            entity.Property(e => e.ChangePwdDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.CreateDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.DataDate)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.EmpID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.EmpName).HasMaxLength(12);
            entity.Property(e => e.EmpPms).HasMaxLength(10);
            entity.Property(e => e.EmpPwd).HasMaxLength(12);
            entity.Property(e => e.LockTime)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Place).HasMaxLength(5);
            entity.Property(e => e.UserID).HasMaxLength(20);
        });

        modelBuilder.Entity<WhiteList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WhiteList");

            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.ID).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<WhiteList_Log>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WhiteList_Log");

            entity.Property(e => e.GateNo).HasMaxLength(20);
            entity.Property(e => e.ID).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserID).HasMaxLength(30);
        });

        modelBuilder.Entity<passlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passlog");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fail).IsUnicode(false);
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GatePass).HasMaxLength(5);
            entity.Property(e => e.HTTPEMS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HitOrNonhit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PHOTO_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Score)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasMaxLength(50);
            entity.Property(e => e.Threshold)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<passlogByJayTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passlogByJayTest");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fail).IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GatePass).HasMaxLength(5);
            entity.Property(e => e.HTTPEMS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HitOrNonhit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PHOTO_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Score)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasMaxLength(50);
            entity.Property(e => e.Threshold)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<passlog_backup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passlog_backup");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMSStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fail).IsUnicode(false);
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GatePass).HasMaxLength(5);
            entity.Property(e => e.HTTPEMS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HitOrNonhit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchEdTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatchStTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PHOTO_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Result2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Score)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasMaxLength(50);
            entity.Property(e => e.Threshold)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<passlog_photo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passlog_photo");

            entity.Property(e => e.AnalyzeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.GateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblMember");

            entity.Property(e => e.Birthday)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.CardNo).IsUnicode(false);
            entity.Property(e => e.EmployeeID)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.EnrollFeature)
                .HasMaxLength(6732)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EnrollImage).IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ICardNo)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsPwd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoblieBarcode)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.TWAT)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.refA).HasMaxLength(50);
            entity.Property(e => e.refB).HasMaxLength(50);
            entity.Property(e => e.refC).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
