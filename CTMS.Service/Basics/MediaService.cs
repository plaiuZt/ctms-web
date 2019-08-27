using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Basics;
    using CTMS.IDAL.Basics;
    using CTMS.Common.Json;
    /// <summary>
    /// 
    /// </summary>
    public partial class MediaService:BaseService<Basics_Media>,IMediaService
    {
        private readonly IMediaDAL MediaDAL;
        private readonly CTMSContext CTMSContext;
        public MediaService(CTMSContext CTMSContext, IMediaDAL MediaDAL)
        {
            this.CTMSContext = CTMSContext;
            this.MediaDAL = MediaDAL;
            this.Dal = MediaDAL;
        }
        public override void SetDal()
        {
            Dal = MediaDAL;
        }

        public bool SaveMedia(Basics_Media entity)
        {
            try
            {
                entity.State = true;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int MediaInterface(string appId, Basics_Media entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string mediaId = entity.MediaID;
                entity.State = true;
                entity.CreateDate = DateTime.Now;

                var mediaInterface = new Basics_MediaInterface()
                {
                    SystemID = systemId,
                    CompanyID = companyId,
                    MediaID = mediaId,
                    AppID = appId
                };

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        db.Add(entity);
                    //        db.Add(mediaInterface);
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
                        db.Add(entity);
                        db.Add(mediaInterface);
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
        public int MediaInterface(string appId, List<Basics_Media> lists)
        {
            try
            {
                if (lists == null)
                    throw new Exception("写入列表不能为空！");
                lists.ForEach(m => { m.State = true; m.CreateDate = DateTime.Now; });
                List<Basics_MediaInterface> listMediaInterface = new List<Basics_MediaInterface>();
                foreach (var m in lists)
                {
                    listMediaInterface.Add(new Basics_MediaInterface()
                    {
                        SystemID = m.SystemID,
                        CompanyID = m.CompanyID,
                        MediaID = m.MediaID,
                        AppID = appId
                    });
                }

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Add(lists);
                    //        dbContext.Add(listMediaInterface);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum;
                    //}

                    db.Orm.Transaction(() =>
                    {
                        dbContext.Add(lists);
                        dbContext.Add(listMediaInterface);
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
        public int SaveMediaMember(string memberId, Basics_Media entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string mediaId = entity.MediaID;
                entity.State = true;
                entity.CreateDate = DateTime.Now;
                var mediaMember = new Basics_MediaMember()
                {
                    SystemID = systemId,
                    CompanyID = companyId,
                    MediaID = mediaId,
                    MemberID = memberId
                };
                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        db.Add(entity);
                    //        db.Add(mediaMember);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum;
                    //}

                    db.Orm.Transaction(() =>
                    {
                        db.Add(entity);
                        db.Add(mediaMember);
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
        public int SaveMediaMember(string memberId, List<Basics_Media> lists)
        {
            try
            {
                if (lists == null)
                    throw new Exception("写入列表不能为空！");
                lists.ForEach(m => { m.State = true; m.CreateDate = DateTime.Now; });
                List<Basics_MediaMember> listMediaMember = new List<Basics_MediaMember>();
                foreach (var m in lists)
                {
                    listMediaMember.Add(new Basics_MediaMember()
                    {
                        SystemID = m.SystemID,
                        CompanyID = m.CompanyID,
                        MediaID = m.MediaID,
                        MemberID = memberId
                    });
                }
                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Add(lists);
                    //        dbContext.Add(listMediaMember);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum;
                    //}

                    db.Orm.Transaction(() =>
                    {
                        dbContext.Add(lists);
                        dbContext.Add(listMediaMember);
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
        public Basics_Media GetMedia(int systemId, string companyId, string mediaId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.MediaID == mediaId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
