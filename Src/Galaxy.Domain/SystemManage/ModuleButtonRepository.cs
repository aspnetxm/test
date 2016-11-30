﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Repository.SystemManage
{
    public class ModuleButtonRepository : BaseRepository<ModuleButton>, IModuleButtonRepository
    {
        IDbContext _dbContext;
        public ModuleButtonRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void SubmitCloneButton(List<ModuleButton> entitys)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {

                foreach (var item in entitys)
                {
                    db.Insert(item);
                }
                db.Commit();
            }
        }
    }
}
