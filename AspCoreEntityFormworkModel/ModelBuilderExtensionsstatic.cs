using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspCoreEntityFormworkModel
{
    /// <summary>	
    /// 描述：EFcore 更新map文件
    /// 创建人： zhaoyongjie
    /// 创建时间：2019/7/29 16:11:45
    /// </summary>
    public static class ModelBuilderExtensionsstatic
    {
        public static void AddConfiguration<TEntity>(
          this ModelBuilder modelBuilder,
          DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.ConfigureMapping);
        }
    }
    public abstract class DbEntityConfiguration<TEntity> where TEntity: class
    {
        public void ConfigureMapping(EntityTypeBuilder<TEntity> entity)
        {
            Configure(entity);
           
        }
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
