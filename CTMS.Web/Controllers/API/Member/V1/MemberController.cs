﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTMS.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.API.Member.V1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]

    public class MemberController : BaseApiController
    {
        private readonly IBaseApiManager BaseApiManager;
        public MemberController(IBaseApiManager BaseApiManager) : base(BaseApiManager)
        {
            this.BaseApiManager = BaseApiManager;
        }

    }
}