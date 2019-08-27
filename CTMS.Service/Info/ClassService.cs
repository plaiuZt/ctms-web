﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Info
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Info;
    using CTMS.IDAL.Info;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;

    /// <summary>
    /// 
    /// </summary>
    public partial class ClassService:BaseService<Info_Class>,IClassService
    {
        private readonly IClassDAL ClassDAL;
        private readonly CTMSContext CTMSContext;
        public ClassService(CTMSContext CTMSContext, IClassDAL ClassDAL)
        {
            this.CTMSContext = CTMSContext;
            this.ClassDAL = ClassDAL;
            this.Dal = ClassDAL;
        }
        public override void SetDal()
        {
            Dal = ClassDAL;
        }

        public bool SaveClass(Info_Class entity)
        {
            try
            {
                var infoClass = PrimaryKeyHelper.PrimaryKeyType.InfoClass;
                var primaryKeyLen = PrimaryKeyHelper.PrimaryKeyLen.V1;
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string classId = PrimaryKeyHelper.MakePrimaryKey(infoClass, primaryKeyLen);
                string className = entity.ClassName;
                int classType = entity.ClassType.ToInt();
                string parentId = string.IsNullOrEmpty(entity.ParentID) ? "0" : entity.ParentID;
                bool state = entity.State.ToBool();

                if (parentId != "0")
                {
                    bool verifyParentId = IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == parentId);
                    if (!verifyParentId)
                        throw new Exception("上级分类ID不存在！");
                }
                bool verifyClassName = IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.ParentID == parentId && m.ClassName == className);
                if (verifyClassName)
                    throw new Exception("分类名称已存在！");
                if (parentId == "0")
                {
                    entity.ParentID = "0";
                    entity.ParentPath = "0";
                    entity.ClassRank = 1;
                    entity.OrderID = 0;
                    entity.OrderPath = classId;
                }
                else
                {
                    var entityClass = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == parentId);
                    int classRank = entityClass.ClassRank.ToInt();
                    string parentPath = entityClass.ParentPath;
                    string orderPath = entityClass.OrderPath;
                    entity.ParentID = parentId;
                    entity.ParentPath = string.Format("{0},{1}", parentPath, parentId);
                    entity.ClassRank = (classRank + 1).ToByte();
                    entity.OrderID = 0;
                    entity.OrderPath = string.Format("{0}{1}", orderPath, classId);
                }
                entity.ClassID = classId;
                entity.State = state;
                entity.CreateDate = DateTime.Now;


                var infoPage = PrimaryKeyHelper.PrimaryKeyType.InfoPage;
                var infoPageVersion = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string pageId = PrimaryKeyHelper.MakePrimaryKey(infoPage, infoPageVersion);
                var entityPage = new Info_Page()
                {
                    SystemID = systemId,
                    CompanyID = companyId,
                    PageID = pageId,
                    Title = entity.ClassName,
                    ClassID = entity.ClassID,
                    ClassName = entity.ClassName,
                    Sort = 0,
                    State = true,
                    CreateDate = DateTime.Now
                };

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Add(entity);
                    //        if (classType == 1)
                    //            dbContext.Add(entityPage);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum > 0;
                    //}
                    db.Orm.Transaction(()=>
                    {
                        dbContext.Add(entity);
                        if (classType == 1)
                            dbContext.Add(entityPage);
                        intnum = db.SaveChanges();
                    });
                    return intnum > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateClass(int systemId, string companyId, string classId, string className, string imgSrc, string keyword, string description, bool state)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                if (entity == null)
                    throw new Exception("class id invalid！");
                string parentId = entity.ParentID;
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ParentID == parentId && m.ClassID != classId && m.ClassName == className);
                if (IsExists(expression))
                    throw new Exception("分类名称已存在！");
                entity.ClassName = className;
                entity.ImgSrc = imgSrc;
                entity.Keyword = keyword;
                entity.Description = description;
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateClassState(int systemId, string companyId, string classId, bool state)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateClassOrderId(int systemId, string companyId, string classId, int sort)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                entity.OrderID = sort;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int DeleteClass(int systemId, string companyId, string classId)
        {
            try
            {
                var expressionPage = ExtLinq.True<Info_Page>();
                var expressionClass = ExtLinq.True<Info_Class>();

                var expressionPageFindByClassId = expressionPage.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                var expressionClassFind = expressionClass.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                var expressionClassFindByParentId = expressionClass.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ParentID == classId);

                if (IsExists(expressionClassFindByParentId))
                    throw new Exception("分类、栏目还有下级栏目不能删除！");
                var entity = Find(expressionClassFind);
                int classType = entity.ClassType.ToInt();

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        if (classType == 1)
                    //            dbContext.Delete(expressionPageFindByClassId);
                    //        dbContext.Delete(expressionClassFind);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum;
                    //}
                    db.Orm.Transaction(()=>
                    {
                        if (classType == 1)
                            dbContext.Delete(expressionPageFindByClassId);
                        dbContext.Delete(expressionClassFind);
                        intnum = db.SaveChanges();
                    });
                    return intnum;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Class GetClass(int systemId, string companyId, string classId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Class> GetClassAll(int systemId, string companyId)
        {
            try
            {
                string parentPath = "0";
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ParentPath.Contains(parentPath));
                return FindList(expression, m => m.OrderPath, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Class> GetClassState(int systemId, string companyId, bool state)
        {
            try
            {
                string parentPath = "0";
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.State.Value == state && m.ParentPath.Contains(parentPath));
                return FindList(expression, m => m.OrderPath, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Class> GetClassByParentPath(int systemId, string companyId, string classId, string state)
        {
            try
            {
                string parentPath = "0";
                if (!string.IsNullOrWhiteSpace(classId) && classId != "0")
                {
                    var entity = GetClass(systemId, companyId, classId);
                    if (entity == null)
                        throw new Exception("class id invalid！");
                    parentPath = string.Format("{0},{1}", entity.ParentPath, classId);
                }
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId 
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState)
                && (m.ParentPath.Contains(parentPath)));
                return FindList(expression, m => m.OrderPath, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Class> GetClassByParentPath(int systemId, string companyId, string classId, string typeId, string state)
        {
            try
            {
                string parentPath = "0";
                if (!string.IsNullOrWhiteSpace(classId) && classId != "0")
                {
                    var entity = GetClass(systemId, companyId, classId);
                    if (entity == null)
                        throw new Exception("class id invalid！");
                    parentPath = string.Format("{0},{1}", entity.ParentPath, classId);
                }
                bool verifyState = state.ToBool();
                int verifyTypeId = typeId.ToInt();
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState)
                && (string.IsNullOrWhiteSpace(typeId) ? true : m.ClassType.Value == verifyTypeId)
                && (m.ParentPath.Contains(parentPath)));
                return FindList(expression, m => m.OrderPath, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Class> GetClassByParentId(int systemId, string companyId, string parentId, string state)
        {
            try
            {
                string verifyParentId = parentId.IIF("0");
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ParentID == verifyParentId
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState));
                return FindList(expression, m => m.OrderID, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountClass(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Class>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}