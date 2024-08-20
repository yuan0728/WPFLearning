using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XH.DbModels.Models;

namespace XH.DbModels.Contexts;

// 用于操作数据库的核心上下文
public partial class XiaoHaiStudyDbContext : DbContext
{
    public XiaoHaiStudyDbContext()
    {

    }

    /// <summary>
    /// 传递参数给父类来创建当前Context的实例配置
    /// </summary>
    /// <param name="options"></param>
    public XiaoHaiStudyDbContext(DbContextOptions<XiaoHaiStudyDbContext> options)
        : base(options)
    {
    }

    #region 需要操作的数据库表一一对应都需要在这个里配置 必须和数据库完全高度匹配

    public virtual DbSet<ScoreInfo> ScoreInfos { get; set; }

    #endregion

    /// <summary>
    /// 补充配置操作数据库上下文DbContext的信息
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // 警告信息 可以删除
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
    {
        // 配置一个数据库连接字符串
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
    }

    /// <summary>
    /// 配置实体对象的映射关系
    /// 
    /// 这里需要配置的：
    /// 1.主键的关联关系
    /// 2.表名称的映射
    /// 3.属性名称的映射关系
    /// 4.主外键的关系
    /// 5.默认值
    /// 6.初始值。。。。
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScoreInfo>(entity =>
        {
            entity
                .ToTable("ScoreInfo") // 表名称
                .HasKey(x => x.Id); // 配置主键
            // 字段配置
            entity.Property(e => e.Course)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("course");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Score).HasColumnName("score");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
