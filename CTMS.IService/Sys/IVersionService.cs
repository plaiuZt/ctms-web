﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    /// <summary>
    /// 
    /// </summary>
    public partial interface IVersionService:IBaseService<Sys_Version>
    {
        bool SaveVersionPro(string versionId, string versionName, decimal marketPrice, decimal dealerPrice, int departmentTotalQuantity, int staffTotalQuantity, int storeTotalQuantity, int warehouseTotalQuantity, string description, bool state);
        bool DeleteVersionPro(string versionId);
        bool UpdateVersionPro(string versionId, string versionName, decimal marketPrice, decimal dealerPrice, int departmentTotalQuantity, int staffTotalQuantity, int storeTotalQuantity, int warehouseTotalQuantity, string description, bool state);
        bool UpdateVersionStatePro(string versionId, bool state);
        List<SP_Get_Sys_Version> GetVersionPro(string versionId);
        List<SP_Get_Sys_Version> GetVersionAllPro();


    }
}
