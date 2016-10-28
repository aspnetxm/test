﻿/*******************************************************************************
 * 作者：星星    
 * 描述：   
 * 修改记录： 
*********************************************************************************/
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Galaxy.Data
{
    public class GalaxyDbContext : DbContext
    {
        public GalaxyDbContext() : base("Galaxy")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            base.Database.Log = (sql) =>
            {
                System.Diagnostics.Debug.Print(sql);
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Diagnostics.Debug.Print(base.Database.Connection.ConnectionString);
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("Galaxy.Data.DLL", "Galaxy.Mapping.DLL").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            //var typesToRegister = asm.GetTypes()
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("Galaxy.Mapping"));
            base.OnModelCreating(modelBuilder);
        }
    }
}