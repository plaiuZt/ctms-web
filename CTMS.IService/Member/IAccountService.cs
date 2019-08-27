using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Member
{
    using CTMS.DbStoredProcedure;
    using CTMS.DbModels;

    /// <summary>
    /// 会员帐号业务逻辑服务类
    /// </summary>
    public partial interface IAccountService:IBaseService<Member_Account>
    {
        Member_Account GetAccount(int systemId, string companyId, string memberId);
        Member_Account GetAccountByUserName(int systemId, string companyId, string username);
        List<Member_Account> GetAccountPaging(int systemId, string companyId, int pageId, int pageSize);
        
        bool SaveAccount(Member_Account entity);
        bool UpdateAccount(Member_Account entity);
        bool UpdateAccountState(int systemId, string companyId, string memberId, bool state);
        bool UpdateAccountDelete(int systemId, string companyId, string memberId, bool del);
        bool DeleteAccount(int systemId, string companyId, string memberId);
        int DeleteAccountAll(int systemId, string companyId, string memberId);


        bool SaveAccountRegisterPro(int systemId, string companyId, string memberId, string password, string phone, string ipAddress);
        bool UpdateAccountStatePro(int systemId, string companyId, string memberId, bool state);
        bool UpdateAccountDeletePro(int systemId, string companyId, string memberId, bool delete);
        bool UpdateAccountPasswordPro(int systemId, string companyId, string memberId, string password);
        bool DeleteAccountPro(int systemId, string companyId, string memberId);

        Member_Account GetAccountByAccessTokenPro(int systemId, string accessToken);
        Member_Account GetAccountByRefreshTokenPro(int systemId, string refreshToken);
        Member_Account GetAccountPro(int systemId, string companyId, string memberId);
        List<Member_Account> GetAccountPagingPro(int systemId, string companyId, string delete, int pageId, int pageSize, out int rowCount);
        List<Member_Account> SearchAccountPro(int systemId, string companyId, string startTime, string endTime, string rankId, string delete, string keyword);
        bool VerifyAccountLoginPro(int systemId, string companyId, string account, string password);

    }
}
