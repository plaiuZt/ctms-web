USE [LdCms_Db]
GO
/****** Object:  StoredProcedure [dbo].[AA_Get_Sys_Test]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AA_Get_Sys_Test]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS
set @errorCode=-1
set @errorMsg='初始化'


select * from A_Sys_Test
select @errorCode=0,@errorMsg='ok'


select * from Ld_Sys_Code
select * from Ld_Sys_Version
select * from Ld_Sys_AccessCorsHost

select * from Ld_Sys_Config
select * from Ld_Sys_InterfaceAccount
select * from Ld_Sys_InterfaceAccessWhiteList
select * from Ld_Sys_InterfaceAccessToken

select * from Ld_Sys_Role
select * from Ld_Sys_RoleFunction
select * from Ld_Sys_Operator
select * from Ld_Sys_OperatorRole

select * from Ld_Institution_Company
select * from Ld_Institution_Dealer
select * from Ld_Institution_Department
select * from Ld_Institution_Position
select * from Ld_Institution_Staff
select * from Ld_Institution_Store
select * from Ld_Institution_Supplier
select * from Ld_Institution_Warehouse
GO
/****** Object:  StoredProcedure [dbo].[AA_Initialize_Sys]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	初始化系统数据
-- =============================================
CREATE PROCEDURE [dbo].[AA_Initialize_Sys]


AS



declare @SystemId int
declare @ClassId int
declare @CompanyId varchar(20)
declare @CompanyPassword varchar(32)
declare @MemberId varchar(20)
declare @StaffId varchar(20)
declare @StaffPassword varchar(32)
declare @RoleId varchar(4)
declare @FunctionId varchar(6)
declare @DealerId varchar(20)
declare @Version varchar(3)

set @SystemId=100101
set @ClassId=1
set @CompanyId='300001'
set @CompanyPassword=dbo.fn_md5('300001')
set @MemberId='300001'
set @StaffId='admin'
set @StaffPassword=dbo.fn_md5('admin')
set @RoleId='2001'
set @FunctionId='000000'
set @DealerId='sys'
set @Version='004'



--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	SET @tranErrorCode=0
	SET @tranErrorMsg='ok'
	BEGIN TRY

		--清空数据
		--delete Ld_Sys_Function                 --系统功能编号

		truncate table Ld_Sys_Version                    --系统版本编号
		truncate table Ld_Sys_Code                       --系统编号
		truncate table Ld_Sys_Config                     --系统配置
		truncate table Ld_Sys_InterfaceAccount           --系统接口帐号
		truncate table Ld_Sys_AccessCorsHost             --系统跨域白名单
		truncate table Ld_Sys_InterfaceAccessWhiteList   --接口请求IP白名单
		truncate table Ld_Sys_InterfaceAccessToken       --接口验证Token

		truncate table Ld_Sys_Operator            --系统管理操作员
		truncate table Ld_Sys_OperatorRole        --系统管理操作员绑定角色
		truncate table Ld_Sys_Role                --系统管理角色
		truncate table Ld_Sys_RoleFunction        --系统管理角色功能

		--公司部分
		truncate table Ld_Institution_Company     --注册公司
		truncate table Ld_Institution_Dealer      --公司经销商
		truncate table Ld_Institution_Department  --公司部门
		truncate table Ld_Institution_Position    --公司职位
		truncate table Ld_Institution_Store       --公司网点
		truncate table Ld_Institution_Staff       --公司员工
		truncate table Ld_Institution_Supplier    --公司供应商
		truncate table Ld_Institution_Warehouse   --公司仓库
		
		--日志部分
		truncate table Ld_Log_Table               --数据字典表
		truncate table Ld_Log_TableDetails        --数据字典表字段
		truncate table Ld_Log_TableOperation      --表数据变更记录
		truncate table Ld_Log_ErrorRecord         --系统错误记录
		truncate table Ld_Log_VisitorRecord       --访问记录
		truncate table Ld_Log_LoginRecord         --系统登录记录
		truncate table Ld_Log_WebApiAccessRecord  --API访问记录
		
		--会员部分
		truncate table Ld_Member_Rank             --会员等级
		truncate table Ld_Member_Account          --会员帐号
		truncate table Ld_Member_AccessToken      --会员访问Token
		truncate table Ld_Member_RefreshToken     --会员刷新Token
		truncate table Ld_Member_Address          --会员常用地址
		truncate table Ld_Member_Invoice          --会员发票资料
		truncate table Ld_Member_PointRecord      --会员积分记录
		truncate table Ld_Member_AmountRecord     --会员冲值记录
		truncate table Ld_Member_LoginLogs        --会员登录记录

		--客服部分
		truncate table Ld_Service_MessageBoard    --留言记录


		--初始化系统功能编号
		if not exists(select * from Ld_Sys_Function where FunctionID='000000')
		begin
			insert into Ld_Sys_Function (FunctionID,FunctionName,ParentID,RankID,Selected,State,IsDel,CreateDate)
			values ('000000','所有者','0',1,0,1,0,getdate())
			SET @tranErrorCode=@tranErrorCode+@@ERROR
		end

		--初始化系统编号
		insert into Ld_Sys_Code(SystemId,SystemName,Description,State,CreateDate)
		values 
		(100101,'蓝点网站信息管理系统-开发版','开发版',1,getdate()),
		(100201,'蓝点网站信息管理系统-内测版','内测版',1,getdate()),
		(100301,'蓝点网站信息管理系统-公测版','公测版',1,getdate()),
		(100401,'蓝点网站信息管理系统-正式版','正式版',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化系统版本功能
		insert into Ld_Sys_Version (VersionId,VersionName,MarketPrice,DealerPrice,DepartmentTotalQuantity,StaffTotalQuantity,StoreTotalQuantity,WarehouseTotalQuantity,Description,State,CreateDate)
		values
		('001','免费版',0.00,0.00,5,10,1,1,'普通免费版',1,getdate()),
		('002','企业版',3999.00,1999.00,50,100,10,10,'企业收费版',1,getdate()),
		('003','高级版',7999.00,2999.00,500,1000,100,100,'高级收费版',1,getdate()),
		('004','旗舰版',16888.00,7999.00,5000,100000,10000,10000,'旗舰收费版',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化系统配置参数
		insert into Ld_Sys_Config(SystemId,CompanyId,CreateDate)
		values 
		(100101,'sys',getdate()),
		(100201,'sys',getdate()),
		(100301,'sys',getdate()),
		(100401,'sys',getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化系统接口用户
		insert into Ld_Sys_InterfaceAccount (SystemId,CompanyId,Account,Password,Uuid,AppId,AppSecret,AppKey,IsWcf,IsWeb,IsApi,IsCors,RequestTotalNumber,Description,State,IsDel,CreateDate)
		values
		(100101,'sys','LdCms',dbo.fn_md5('LdCms'),Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',1,0,getdate()),
		(100201,'sys','LdCms',dbo.fn_md5('LdCms'),Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',1,0,getdate()),
		(100301,'sys','LdCms',dbo.fn_md5('LdCms'),Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',1,0,getdate()),
		(100401,'sys','LdCms',dbo.fn_md5('LdCms'),Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化接口白名单
		insert into Ld_Sys_InterfaceAccessWhiteList (SystemId,CompanyId,Account,IpAddress,ClassID,ClassName,Remark,State,CreateDate)
		values
		(100101,'sys','LdCms','*',1,'WCF','系统初始化',1,getdate()),
		(100101,'sys','LdCms','*',2,'WEB','系统初始化',1,getdate()),
		(100101,'sys','LdCms','*',3,'API','系统初始化',1,getdate()),
		(100201,'sys','LdCms','*',1,'WCF','系统初始化',1,getdate()),
		(100201,'sys','LdCms','*',2,'WEB','系统初始化',1,getdate()),
		(100201,'sys','LdCms','*',3,'API','系统初始化',1,getdate()),
		(100301,'sys','LdCms','*',1,'WCF','系统初始化',1,getdate()),
		(100301,'sys','LdCms','*',2,'WEB','系统初始化',1,getdate()),
		(100301,'sys','LdCms','*',3,'API','系统初始化',1,getdate()),
		(100401,'sys','LdCms','*',1,'WCF','系统初始化',1,getdate()),
		(100401,'sys','LdCms','*',2,'WEB','系统初始化',1,getdate()),
		(100401,'sys','LdCms','*',3,'API','系统初始化',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		insert into Ld_Sys_AccessCorsHost (SystemID,WebHost,Remark,Account,NickName,State,CreateDate)
		values
		(100101,'http://*.*.*','系统初始化允许全部来源！','admin','超级管理员',1,getdate()),
		(100201,'http://*.*.*','系统初始化允许全部来源！','admin','超级管理员',1,getdate()),
		(100301,'http://*.*.*','系统初始化允许全部来源！','admin','超级管理员',1,getdate()),
		(100401,'http://*.*.*','系统初始化允许全部来源！','admin','超级管理员',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化系统公司帐号
		insert into Ld_Institution_Company(SystemId,CompanyId,DealerId,ClassId,UserName,Password,CompanyName,Version,StartTime,EndTime,State,IsDal,CreateDate)
		values
		(100101,'sys','sys',0,'sys',dbo.fn_md5('sys'),'系统初始化','sys','2018-01-01','2900-01-01',1,0,getdate()),
		(100201,'sys','sys',0,'sys',dbo.fn_md5('sys'),'系统初始化','sys','2018-01-01','2900-01-01',1,0,getdate()),
		(100301,'sys','sys',0,'sys',dbo.fn_md5('sys'),'系统初始化','sys','2018-01-01','2900-01-01',1,0,getdate()),
		(100401,'sys','sys',0,'sys',dbo.fn_md5('sys'),'系统初始化','sys','2018-01-01','2900-01-01',1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化系统管理员
		insert into Ld_Institution_Staff(SystemId,CompanyId,StaffId,StaffName,NickName,UserName,Password,Description,IsInit,State,IsDel,CreateDate)
		values 
		(100101,'sys','admin','超级管理员','超级管理员','admin',dbo.fn_md5('admin'),'拥有至高无上的权限',1,1,0,getdate()),
		(100201,'sys','admin','超级管理员','超级管理员','admin',dbo.fn_md5('admin'),'拥有至高无上的权限',1,1,0,getdate()),
		(100301,'sys','admin','超级管理员','超级管理员','admin',dbo.fn_md5('admin'),'拥有至高无上的权限',1,1,0,getdate()),
		(100401,'sys','admin','超级管理员','超级管理员','admin',dbo.fn_md5('admin'),'拥有至高无上的权限',1,1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化角色
		insert into Ld_Sys_Role(SystemId,CompanyId,RoleId,RoleName,Remark,State,IsDel,CreateDate)
		values 
		(100101,'sys','2001','所有者','拥有至高无上的权限',1,0,getdate()),
		(100201,'sys','2001','所有者','拥有至高无上的权限',1,0,getdate()),
		(100301,'sys','2001','所有者','拥有至高无上的权限',1,0,getdate()),
		(100401,'sys','2001','所有者','拥有至高无上的权限',1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化角色功能
		insert into Ld_Sys_RoleFunction(SystemId,CompanyId,RoleId,FunctionId)
		values 
		(100101,'sys','2001','000000'),
		(100201,'sys','2001','000000'),
		(100301,'sys','2001','000000'),
		(100401,'sys','2001','000000')
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化操作员
		insert into Ld_Sys_Operator(SystemId,CompanyId,StaffId,Remark,State,CreateDate)
		values 
		(100101,'sys','admin','拥有至高无上的权限',1,getdate()),
		(100201,'sys','admin','拥有至高无上的权限',1,getdate()),
		(100301,'sys','admin','拥有至高无上的权限',1,getdate()),
		(100401,'sys','admin','拥有至高无上的权限',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化操作员角色
		insert into Ld_Sys_OperatorRole(SystemId,CompanyId,StaffId,RoleId)
		values 
		(100101,'sys','admin','2001'),
		(100201,'sys','admin','2001'),
		(100301,'sys','admin','2001'),
		(100401,'sys','admin','2001')
        SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化会员等级数据
		insert into Ld_Member_Rank(SystemId,CompanyId,RankId,RankName,MinPoints,MaxPoints,Discount,ShowPrice,SpecialRank,State,CreateDate)
		values
		(100101,'sys','01','注册用户',0,10000,1,1,1,1,getdate()),
		(100201,'sys','01','注册用户',0,10000,1,1,1,1,getdate()),
		(100301,'sys','01','注册用户',0,10000,1,1,1,1,getdate()),
		(100401,'sys','01','注册用户',0,10000,1,1,1,1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR



		--初始化公司帐号
		insert into Ld_Institution_Company(SystemId,CompanyId,ClassId,DealerId,UserName,Password,CompanyName,Version,StartTime,EndTime,State,IsDal,CreateDate)
		values
		(100101,@CompanyId,@ClassId,@DealerId,@CompanyId,@CompanyPassword,'测试公司',@Version,'2018-01-01','2900-01-01',1,0,getdate()),
		(100201,@CompanyId,@ClassId,@DealerId,@CompanyId,@CompanyPassword,'测试公司',@Version,'2018-01-01','2900-01-01',1,0,getdate()),
		(100301,@CompanyId,@ClassId,@DealerId,@CompanyId,@CompanyPassword,'测试公司',@Version,'2018-01-01','2900-01-01',1,0,getdate()),
		(100401,@CompanyId,@ClassId,@DealerId,@CompanyId,@CompanyPassword,'测试公司',@Version,'2018-01-01','2900-01-01',1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司系统配置参数
		insert into Ld_Sys_Config(SystemId,CompanyId,CreateDate)
		values
		(100101,@CompanyId,getdate()),
		(100201,@CompanyId,getdate()),
		(100301,@CompanyId,getdate()),
		(100401,@CompanyId,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司接口用户
		insert into Ld_Sys_InterfaceAccount (SystemId,CompanyId,Account,Password,uuid,AppId,AppSecret,AppKey,IsWcf,IsWeb,IsApi,IsCors,RequestTotalNumber,Description,State,IsDel,CreateDate)
		values
		(100101,@CompanyId,@CompanyId,@CompanyPassword,Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',0,0,getdate()),
		(100201,@CompanyId,@CompanyId,@CompanyPassword,Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',0,0,getdate()),
		(100301,@CompanyId,@CompanyId,@CompanyPassword,Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',0,0,getdate()),
		(100401,@CompanyId,@CompanyId,@CompanyPassword,Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',0,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司接口白名单
		insert into Ld_Sys_InterfaceAccessWhiteList (SystemId,CompanyId,Account,IpAddress,ClassID,ClassName,Remark,State,CreateDate)
		values
		(100101,@CompanyId,@CompanyId,'*',1,'WCF','系统初始化',1,getdate()),
		(100101,@CompanyId,@CompanyId,'*',2,'WEB','系统初始化',1,getdate()),
		(100101,@CompanyId,@CompanyId,'*',3,'API','系统初始化',1,getdate()),
		(100201,@CompanyId,@CompanyId,'*',1,'WCF','系统初始化',1,getdate()),
		(100201,@CompanyId,@CompanyId,'*',2,'WEB','系统初始化',1,getdate()),
		(100201,@CompanyId,@CompanyId,'*',3,'API','系统初始化',1,getdate()),
		(100301,@CompanyId,@CompanyId,'*',1,'WCF','系统初始化',1,getdate()),
		(100301,@CompanyId,@CompanyId,'*',2,'WEB','系统初始化',1,getdate()),
		(100301,@CompanyId,@CompanyId,'*',3,'API','系统初始化',1,getdate()),
		(100401,@CompanyId,@CompanyId,'*',1,'WCF','系统初始化',1,getdate()),
		(100401,@CompanyId,@CompanyId,'*',2,'WEB','系统初始化',1,getdate()),
		(100401,@CompanyId,@CompanyId,'*',3,'API','系统初始化',1,getdate())


		--初始化公司员工
		insert into Ld_Institution_Staff(SystemId,CompanyId,StaffId,StaffName,UserName,NickName,Password,Description,IsInit,State,IsDel,CreateDate)
		values
		(100101,@CompanyId,@StaffId,'创始者',@StaffId,'创始者',@StaffPassword,'初始化超级管理员',1,1,0,getdate()),
		(100201,@CompanyId,@StaffId,'创始者',@StaffId,'创始者',@StaffPassword,'初始化超级管理员',1,1,0,getdate()),
		(100301,@CompanyId,@StaffId,'创始者',@StaffId,'创始者',@StaffPassword,'初始化超级管理员',1,1,0,getdate()),
		(100401,@CompanyId,@StaffId,'创始者',@StaffId,'创始者',@StaffPassword,'初始化超级管理员',1,1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	    --初始化公司角色
		insert into Ld_Sys_Role(SystemId,CompanyId,RoleId,RoleName,Remark,State,IsDel,CreateDate)
		values
		(100101,@CompanyId,@RoleId,'所有者','拥有至高无上的权限',1,0,getdate()),
		(100201,@CompanyId,@RoleId,'所有者','拥有至高无上的权限',1,0,getdate()),
		(100301,@CompanyId,@RoleId,'所有者','拥有至高无上的权限',1,0,getdate()),
		(100401,@CompanyId,@RoleId,'所有者','拥有至高无上的权限',1,0,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司角色功能
		insert into Ld_Sys_RoleFunction(SystemId,CompanyId,RoleId,FunctionId)
		values
		(100101,@CompanyId,@RoleId,@FunctionId),
		(100201,@CompanyId,@RoleId,@FunctionId),
		(100301,@CompanyId,@RoleId,@FunctionId),
		(100401,@CompanyId,@RoleId,@FunctionId)
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司操作员
		insert into Ld_Sys_Operator(SystemId,CompanyId,StaffId,Remark,State,CreateDate)
		values
		(100101,@CompanyId,@StaffId,'拥有至高无上的权限',1,getdate()),
		(100201,@CompanyId,@StaffId,'拥有至高无上的权限',1,getdate()),
		(100301,@CompanyId,@StaffId,'拥有至高无上的权限',1,getdate()),
		(100401,@CompanyId,@StaffId,'拥有至高无上的权限',1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司操作员角色
		insert into Ld_Sys_OperatorRole(SystemId,CompanyId,StaffId,RoleId)
		values
		(100101,@CompanyId,@StaffId,@RoleId),
		(100201,@CompanyId,@StaffId,@RoleId),
		(100301,@CompanyId,@StaffId,@RoleId),
		(100401,@CompanyId,@StaffId,@RoleId)
        SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化会员等级数据
		insert into Ld_Member_Rank(SystemId,CompanyId,RankId,RankName,MinPoints,MaxPoints,Discount,ShowPrice,SpecialRank,State,CreateDate)
		values
		(100101,@CompanyId,'01','注册用户',0,10000,1,1,1,1,getdate()),
		(100201,@CompanyId,'01','注册用户',0,10000,1,1,1,1,getdate()),
		(100301,@CompanyId,'01','注册用户',0,10000,1,1,1,1,getdate()),
		(100401,@CompanyId,'01','注册用户',0,10000,1,1,1,1,getdate())
		SET @tranErrorCode=@tranErrorCode+@@ERROR


	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	SELECT @tranErrorCode,@tranErrorMsg
	IF @tranErrorCode=0
			COMMIT TRAN
	ELSE
			ROLLBACK TRAN





GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Institution_CompanyRegister]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-28
-- Description:	公司注册
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Institution_CompanyRegister]

@systemId int,
@dealerId nvarchar(20),
@classId tinyint,
@companyName nvarchar(20),
@password nvarchar(50),
@nickName  nvarchar(50),
@phone nvarchar(20),
@email nvarchar(50),
@registerIpAddress nvarchar(50),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'
declare @TotalRow int=0




--验证输出参数
if (isnull(@SystemId,'')='')
begin
	select @ErrorCode=3010,@errorMsg='system id not empty'
	return
end

if (isnull(@password,'')='')
begin
	select @ErrorCode=3010,@errorMsg='password not empty'
	return
end

if (isnull(@Phone,'')='')
begin
	select @ErrorCode=3010,@errorMsg='phone not empty'
	return
end
--验证输出参数

if not exists(select * from Ld_Sys_Code with(nolock) where SystemId=@SystemId)
begin
	select @ErrorCode=4001,@errorMsg='系统编号错误'
	print 1
	return
end


IF EXISTS(SELECT * FROM Ld_Institution_Company with(nolock) WHERE Systemid=@systemid and Phone=@Phone)
BEGIN
	SELECT @ErrorCode=4002,@errorMsg='手机号码已经注册，如果忘记密码请找回密码'
	return
END


set @password=dbo.fn_md5(@password)

--经销商编号
if (ISNULL(@DealerId,'')='')
begin
	select @DealerId='sys'
end
--经销商编号
if (ISNULL(@classId,'')='')
begin
	select @classId=1
end


--公司编号	
--declare @Systemid int=100001
declare @CompanyId nvarchar(6)
declare @i int=0
WHILE @i<1
begin
	SET @CompanyId=cast(floor(rand()*1000000) as int)
	SET @CompanyId=right('000000'+@CompanyId,5)
	SET @CompanyId='3'+@CompanyId
	if not exists(select * from ld_Institution_company where systemid=@systemid and CompanyId=@CompanyId)
	begin
	    --print @CompanyId
		SET @I=1
		BREAK
	end
end
--SELECT @SystemId,@CompanyId

--初始化默认值
DECLARE @Version varchar(4)='001'

DECLARE @staffId nvarchar(10)='admin'
DECLARE @staffName nvarchar(10)='创始者'
DECLARE @staffPassword nvarchar(32)=dbo.fn_md5('admin')
DECLARE @roleId nvarchar(10)='2001'
DECLARE @roleName nvarchar(10)='所有者'
DECLARE @FunctionId nvarchar(10)='000000'

IF EXISTS(SELECT * FROM Ld_Institution_Company WITH(NOLOCK) WHERE [SystemId]=@SystemId And CompanyId=@CompanyId)
BEGIN
	SELECT @ErrorCode=4003,@errorMsg='公司编号重复'
	return
END

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	BEGIN TRY
		--初始化公司帐号
		insert into Ld_Institution_Company(SystemId,CompanyId,DealerId,ClassId,UserName,Password,CompanyName,nickName,phone,email,RegisterIpAddress,Version,StartTime,EndTime,State,IsDal,CreateDate)
		select @SystemId,@CompanyId,@DealerId,@ClassId,@CompanyId,@Password,@CompanyName,@nickName,@phone,@email,@RegisterIpAddress,@Version,getdate(),'2900-01-01',1,0,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司系统配置参数
		insert into Ld_Sys_Config(SystemId,CompanyId,CreateDate)
		select @SystemId,@CompanyId,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司接口用户
		insert into Ld_Sys_InterfaceAccount (SystemId,CompanyId,Account,Password,uuid,AppId,AppSecret,AppKey,IsWcf,IsWeb,IsApi,IsCors,RequestTotalNumber,Description,State,IsDel,CreateDate)
		select @SystemId,@CompanyId,@CompanyId,@Password,Lower(replace(newid(),'-','')),'Ld_'+dbo.fn_get_random_string(13),dbo.fn_get_random_string(32),dbo.fn_get_random_string(32),1,1,1,1,0,'系统初始化接口用户',0,0,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司接口白名单
		insert into Ld_Sys_InterfaceAccessWhiteList (SystemId,CompanyId,Account,IpAddress,ClassID,ClassName,Remark,State,CreateDate)
		values
		(@SystemId,@CompanyId,@CompanyId,'*',1,'WCF','系统初始化',1,getdate()),
		(@SystemId,@CompanyId,@CompanyId,'*',2,'WEB','系统初始化',1,getdate()),
		(@SystemId,@CompanyId,@CompanyId,'*',3,'API','系统初始化',1,getdate())

		--初始化公司员工
		insert into Ld_Institution_Staff(SystemId,CompanyId,StaffId,StaffName,UserName,NickName,Password,Description,State,IsInit,IsDel,CreateDate)
		select @SystemId,@CompanyId,@StaffId,@StaffName,@StaffId,@StaffName,@staffPassword,'初始化超级管理员',1,1,0,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	    --初始化公司角色
		insert into Ld_Sys_Role(SystemId,CompanyId,RoleId,RoleName,Remark,State,IsDel,CreateDate)
		select @SystemId,@CompanyId,@RoleId,@roleName,'拥有至高无上的权限',1,0,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司角色功能
		insert into Ld_Sys_RoleFunction(SystemId,CompanyId,RoleId,FunctionId)
		select @SystemId,@CompanyId,@RoleId,@FunctionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司操作员
		insert into Ld_Sys_Operator(SystemId,CompanyId,StaffId,Remark,State,CreateDate)
		select @SystemId,@CompanyId,@StaffId,'拥有至高无上的权限',1,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--初始化公司操作员角色
		insert into Ld_Sys_OperatorRole(SystemId,CompanyId,StaffId,RoleId)
		select @SystemId,@CompanyId,@StaffId,@RoleId
        SET @tranErrorCode=@tranErrorCode+@@ERROR

	    --初始化会员等级数据
		insert into Ld_Member_Rank(SystemId,CompanyId,RankId,RankName,MinPoints,MaxPoints,Discount,ShowPrice,SpecialRank,State,CreateDate)
		select @SystemId,@CompanyId,'01','注册用户',0,10000,1,1,1,1,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end








GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	分类、栏目添加
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Institution_Department] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@departmentId varchar(20),     --部门编号
@departmentName nvarchar(50),  --部门名称
@parentId varchar(20),         --上级ID
@description nvarchar(800),    --部门描述
@State bit,                    --部门状态
@errorCode int output,         --错误代码
@errorMsg nvarchar(180) output --错误信息


AS

select @errorCode=-1
select @errorMsg='FAIL'

if (isnull(@departmentId,'')='')
begin
	select @ErrorCode=40101,@errorMsg='department id not empty'
	return
end

if (@departmentId='0')
begin
	select @ErrorCode=40101,@errorMsg='部门编号不能为“0”！'
	return
end

--验证公司是否存在
if not exists(select * from Ld_Institution_Company with(nolock) where SystemId=@SystemId and CompanyId=@CompanyId)
begin
	select @ErrorCode=40101,@errorMsg='company id invalid'
	return
end

--验证部门编号是否存在
if exists(select * from Ld_Institution_Department with(nolock) where SystemId=@SystemId and CompanyId=@CompanyId and DepartmentId=@departmentId)
begin
	select @ErrorCode=40101,@errorMsg='department id exists'
	return
end


--验证上级分类是否存
if isnull(@ParentId,0)<>0 and not exists(select * from Ld_Institution_Department with(nolock) where systemid=@systemid and companyid=@companyid and DepartmentId=@ParentId)
begin
	select @errorcode=40103,@errorMsg='上级编号不已存在'
	print @ParentId
	return
end

if (isnull(@ParentId,'')='')
set @ParentId='0'

--验证名称重复
if exists(select * from Ld_Institution_Department with(nolock) where systemid=@systemid and companyid=@companyid and DepartmentName=@DepartmentName and ParentId=@ParentId)
begin
	select @errorcode=4003,@errorMsg='部门名称不能重复'
	return
end

DECLARE @MyNumber int=10                --排序号生成位数
DECLARE @MyNewId int=1                  --初始化ID
DECLARE @MyParentId nvarchar(10)        --上级ID
DECLARE @MyParentPath nvarchar(255)     --分类节点
DECLARE @MyOrderPath nvarchar(255)      --排序字符串
DECLARE @MyOrderId int                  --排序ID
DECLARE @MyRankId int                   --分类级别
--生成分类各参数
IF EXISTS(SELECT * FROM Ld_Institution_Department with(nolock))
	BEGIN
		set @MyNewId=@departmentId
	END
declare @MyOrderPathStr varchar(1000)=RIGHT(REPLICATE('0',@MyNumber)+CAST(@MyNewId as varchar(10)),@MyNumber)
IF (isnull(@ParentId,0)=0)
	BEGIN
		SET @MyParentId=0
		SET @MyParentPath=0
		SET @MyOrderPath=@MyOrderPathStr
		SET @MyOrderId=@MyNewId
		SET @MyRankId=1
	END
ELSE
	BEGIN
		SELECT @MyParentId=@ParentId
		SELECT @MyParentPath=NodePath+','+CAST(@ParentId as varchar(10)) FROM Ld_Institution_Department WHERE SystemId=@SystemId and CompanyId=@CompanyId And DepartmentId=@ParentId
		SELECT @MyOrderPath=SortPath+@MyOrderPathStr FROM Ld_Institution_Department WHERE SystemId=@SystemId and CompanyId=@CompanyId And DepartmentId=@ParentId
		SELECT @MyOrderId=@MyNewId
		SELECT @MyRankId=RankID+1 FROM Ld_Institution_Department WHERE SystemId=@SystemId and CompanyId=@CompanyId And DepartmentId=@ParentId
	END


--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入分类
		insert into Ld_Institution_Department (SystemId,CompanyId,DepartmentId,DepartmentName,ParentId,NodePath,RankID,SortId,SortPath,Description,State,IsDel,CreateDate)
		select @SystemId,@CompanyId,@DepartmentId,@DepartmentName,@MyParentId,@MyParentPath,@MyRankId,@MyOrderId,@MyOrderPath,@Description,@State,0,getdate()
		select @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END







GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Institution_Position]

@systemId int,
@companyId varchar(20),
@positionId varchar(20),
@positionName nvarchar(20),
@description nvarchar(200),
@sort int,
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'


if exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId)
begin
	select @errorCode=40123,@errorMsg='职位编号已存在！'
	return
end

if exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionName=@positionName)
begin
	select @errorCode=40123,@errorMsg='职位名称已存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	BEGIN TRY
		--初始化公司帐号
		insert into Ld_Institution_Position(SystemId,CompanyId,PositionID,PositionName,Description,Sort,State,IsDel,CreateDate)
		select @SystemId,@CompanyId,@positionId,@positionName,@description,@sort,@state,0,getdate()
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end


GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Institution_Staff] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@StaffID varchar(20),
@StaffName nvarchar(20),
@UserName nvarchar(20),
@Password varchar(32),
@NickName nvarchar(20),
@HeadImgUrl varchar(250),
@Name nvarchar(20),
@Sex int,
@BirthDate datetime,
@BirthPlace nvarchar(250),
@Identification varchar(20),
@Education nvarchar(20),
@Phone varchar(20),
@QQ varchar(20),
@Weixin varchar(32),
@Email varchar(50),
@Address varchar(250),
@Wages decimal(18,2),
@Probation int,
@StartWorkDate datetime,
@EndWorkDate datetime,
@SignContractDate datetime,
@ExpirationContractDate datetime,
@DepartmentID varchar(20),
@PositionID varchar(20),
@StoreID varchar(20),
@WarehouseID varchar(20),
@Description nvarchar(400),
@State bit,                 
@errorCode int output,         
@errorMsg nvarchar(200) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

if exists(select * from Ld_Institution_Staff where SystemID=@systemId and CompanyID=@companyId and StaffID=@StaffID)
begin
	select @errorCode=40123,@errorMsg='职位编号已存在！'
	return
end

declare @DepartmentName nvarchar(50)
declare @PositionName nvarchar(50)
declare @StoreName nvarchar(50)
declare @WarehouseName nvarchar(50)

select @DepartmentName=DepartmentName from Ld_Institution_Department where SystemID=@systemId and CompanyID=@companyId and DepartmentID=@DepartmentID
select @PositionName=PositionName from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@PositionID
select @StoreName=StoreName from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and StoreID=@StoreID
select @WarehouseName=WarehouseName from Ld_Institution_Warehouse where SystemID=@systemId and CompanyID=@companyId and WarehouseID=@WarehouseID

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入网点
		insert into Ld_Institution_Staff(SystemID,CompanyID,StaffID,StaffName,UserName,Password,NickName ,HeadImgUrl,Name,Sex,BirthDate,BirthPlace,Identification,Education,Phone,QQ,Weixin,Email,Address,Wages,Probation,StartWorkDate,EndWorkDate,SignContractDate,ExpirationContractDate,DepartmentID,DepartmentName,PositionID,PositionName,StoreID,StoreName,WarehouseID,WarehouseName,Description,IsInit,State,IsDel,CreateDate)
		select @SystemID,@CompanyID,@StaffID,@StaffName,@UserName,@Password,@NickName,@HeadImgUrl,@Name,@Sex,@BirthDate,@BirthPlace,@Identification,@Education,@Phone,@QQ,@Weixin,@Email,@Address,@Wages,@Probation,@StartWorkDate,@EndWorkDate,@SignContractDate,@ExpirationContractDate,@DepartmentID,@DepartmentName,@PositionID,@PositionName,@StoreID,@StoreName,@WarehouseID,@WarehouseName,@Description,0,@State,0,getdate()
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Institution_Store] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@storeId varchar(20),          --网点编号
@storeName nvarchar(100),
@Logo nvarchar(250),
@Contacts nvarchar(10),
@tel varchar(20),
@fax varchar(20),
@phone varchar(20),
@email nvarchar(100),
@ProvinceID int,
@CityID int,
@AreaID int,
@Address nvarchar(250),
@Keyword nvarchar(200),
@description nvarchar(800),
@StartTime datetime,
@EndTime datetime,
@Push bit,
@Sort int,
@State bit,                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

if exists(select * from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and storeID=@storeId)
begin
	select @errorCode=40123,@errorMsg='职位编号已存在！'
	return
end

if exists(select * from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and storeName=@storeName)
begin
	select @errorCode=40123,@errorMsg='职位名称已存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入网点
		insert into Ld_Institution_Store(SystemID,CompanyID,StoreID,StoreName,Logo,Contacts,Tel,Fax,Phone,Email,ProvinceID,CityID,AreaID,Address,Keyword,Description,StartTime,EndTime,Push,Sort,State,IsDel,CreateDate)
		select @SystemID,@CompanyID,@StoreID,@StoreName,@Logo,@Contacts,@Tel,@Fax,@Phone,@Email,@ProvinceID,@CityID,@AreaID,@Address,@Keyword,@Description,@StartTime,@EndTime,@Push,@Sort,@State,0,getdate()
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_AccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-28
-- Description:	系统token 写入  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_AccessToken]

@token varchar(64),                 --token字符串
@RefreshToken varchar(65),          --刷新token 凭证
@systemId int,                      --系统编号
@companyId varchar(20),             --公司编号
@memberId varchar(20),              --APPID
@uuid varchar(32),                  --UUID
@expiresIn int,                     --过期时间秒
@refreshTokenExpiresIn int,         --刷新码过期时间秒
@ipAddress varchar(20),             --IP地址
@createTimestamp int,               --当前时间
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=412012,@errorMsg='token不能为空！'
	return
end

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='系统编号不能为空！'
	return
end
if not exists(select * from Ld_Member_Account where SystemID=@systemId and CompanyID=@companyId and MemberID=@memberId)
begin
	select @errorCode=412012,@errorMsg='appid invalid！'
	return
end


begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try
	    --更新旧的token过期时间
		update Ld_Member_AccessToken set ExpiresIn=120,CreateTimestamp=@createTimestamp 
		where SystemID=@systemId and CompanyID=@companyId and MemberID=@memberId and ExpiresIn=@expiresIn and (@createTimestamp-CreateTimestamp)<=@expiresIn
		set @tranErrorCode=@tranErrorCode+@@ERROR

		--插入新的token
		insert into Ld_Member_AccessToken (Token,SystemId,CompanyId,MemberID,UUID,ExpiresIn,IpAddress,CreateTimestamp,State,CreateDate) 
		select @token,@systemId,@CompanyId,@MemberID,@uuid,@expiresIn,@ipAddress,@createTimestamp,1,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

		insert into Ld_Member_RefreshToken(RefreshToken,Token,ExpiresIn,IpAddress,CreateTimestamp,State,CreateDate)
		select @RefreshToken,@Token,@refreshTokenExpiresIn,@IpAddress,@createTimestamp,1,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_AccountRegister]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-31
-- Description:	新增会员
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_AccountRegister]

@systemId int,
@companyId varchar(20),
@memberId varchar(20),
@phone varchar(11),
@password varchar(32),
@ipAddress varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@memberId,'')='')
begin
	select @errorCode=412012,@errorMsg='member id invalid！'
	return
end

if exists(select * from Ld_Member_Account where systemid=@systemid and CompanyID=@companyId and MemberID=@companyId)
begin
	select @errorCode=412012,@errorMsg='会员ID已存在！'
	return
end

if exists(select * from Ld_Member_Account where systemid=@systemid and CompanyID=@companyId and phone=@phone)
begin
	select @errorCode=412012,@errorMsg='手机号码已注册！'
	return
end

if exists(select * from Ld_Member_Account where systemid=@systemid and CompanyID=@companyId and username=@phone)
begin
	select @errorCode=412012,@errorMsg='会员用户名已存在！'
	return
end

declare @rankId varchar(10)
declare @rankName varchar(10)
select @rankId=rankId,@rankName=rankName from Ld_Member_Rank where systemid=@systemid and CompanyID=@companyId and RankID='01'

begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try
	    --新增会员
		insert into Ld_Member_Account (systemid,companyid,memberid,username,password,phone,RankID,RankName,RegisterIpAddress,RegisterTime,State,IsDel,CreateDate)
		select @systemId,@companyId,@memberid,@phone,@password,@phone,@rankId,@rankName,@ipAddress,getdate(),1,0,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_LoginLogs]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-01
-- Description:	写入会员登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_LoginLogs]

@systemId int,
@companyId varchar(20),
@memberId varchar(20),
@clientId int,
@account varchar(20),
@nickname nvarchar(20),
@ipAddress varchar(20),
@isResult bit,
@description nvarchar(200),
@errorCode int output,
@errorMsg nvarchar(200) output


AS
set @errorCode=-1
set @errorMsg='初始化'


begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try
	    --新增
		insert into Ld_Member_LoginLogs(SystemID,CompanyID,MemberID,ClientID,Account,NickName,IpAddress,IsResult,Description,CreateDate)
		select @SystemID,@CompanyID,@MemberID,@ClientID,@Account,@NickName,@IpAddress,@IsResult,@Description,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_PointRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-01
-- Description:	写入会员登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_PointRecord]

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@memberId varchar(20),         --会员ID
@classId int,                  --获取积分分类
@className nvarchar(20),       --名称
@typeId int,                   --积分类型  1新增、2使用
@typeName nvarchar(20),        --名称
@points int,                    --积分 新增正数，使用负数
@body nvarchar(4000),
@account varchar(20),
@nickName nvarchar(20),
@ipAddress varchar(20),
@Remark nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output


AS
set @errorCode=-1
set @errorMsg='初始化'


begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try
	    --新增
		insert into Ld_Member_PointRecord(SystemID,CompanyID,MemberID,ClassID,ClassName,TypeID,TypeName,Points,Body,Account,NickName,IpAddress,Remark,State,CreateDate)
		select @SystemID,@CompanyID,@MemberID,@ClassID,@ClassName,@TypeID,@TypeName,@Points,@Body,@Account,@NickName,@ipAddress,@Remark,@State,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_Rank]

@systemId int,
@companyId varchar(20),
@RankName nvarchar(20),
@MaxPoints int,
@Discount int,
@ShowPrice int,
@Remark nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'



declare @rankId varchar(20)
declare @MinPoints int=0
declare @SpecialRank int=0

--计算等级
select @SpecialRank=count(*)+1 from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId
--生成编号
select @RankID= REPLICATE('0',2-len(cast(@SpecialRank as varchar(2))))+cast(@SpecialRank as varchar(2)) --左边补0， 如 00009


if exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID=@rankId)
begin
	select @errorCode=41021,@errorMsg='会员等级编号不能重复！'
	return
end

if exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankName=@RankName)
begin
	select @errorCode=41021,@errorMsg='会员等级名称不能重复！'
	return
end

--最小积分
select top 1 @MinPoints=MaxPoints from Ld_Member_Rank  where SystemID=@systemId and CompanyID=@companyId order by SpecialRank desc
set @MinPoints=isnull(@MinPoints,0)
--判断最大积分
if isnull(@MaxPoints,0)<=0
begin
	select @errorCode=41021,@errorMsg='最大积分必须大于0！'
	return
end
--判断最小积分
if (@MinPoints>=@MaxPoints)
begin
	select @errorCode=41021,@errorMsg='最小积分必须大于下级最大积分！'
	return
end


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    insert into Ld_Member_Rank (SystemID,CompanyID,RankID,RankName,MinPoints,MaxPoints,Discount,ShowPrice,SpecialRank,Remark,State,CreateDate)
		select @SystemID,@CompanyID,@RankID,@RankName,@MinPoints,@MaxPoints,@Discount,@ShowPrice,@SpecialRank,@Remark,@State,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Member_RefreshToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-28
-- Description:	系统token 写入  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Member_RefreshToken]

@verifyRefreshToken varchar(64),    --验证的刷新token 凭证
@token varchar(64),                 --token字符串
@RefreshToken varchar(65),          --刷新token 凭证
@expiresIn int,                     --token过期时间秒
@refreshTokenExpiresIn int,         --刷新token凭证过期时间秒
@ipAddress varchar(20),             --IP地址
@createTimestamp int,               --当前时间
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=412012,@errorMsg='token不能为空！'
	return
end

if(isnull(@refreshTokenExpiresIn,0)=0)
set @refreshTokenExpiresIn=2592000


--验证RefreshToken
declare @verifyRefreshTokenResult int
declare @verifyRefreshTokenErrCode int
declare @verifyRefreshTokenErrMsg nvarchar(200)
exec @verifyRefreshTokenResult = SP_Verify_Member_RefreshToken @verifyRefreshToken,@createTimestamp, @verifyRefreshTokenErrCode output,@verifyRefreshTokenErrMsg output
--select @verifyRefreshTokenResult,@verifyRefreshTokenErrCode,@verifyRefreshTokenErrMsg
if ((@verifyRefreshTokenResult+@verifyRefreshTokenErrCode)<>0)
begin
	select @errorCode=412012,@errorMsg=@verifyRefreshTokenErrMsg
	return
end


declare @systemId int                      --系统编号
declare @companyId varchar(20)             --公司编号
declare @memberId varchar(20)              --APPID
declare @uuid varchar(32)                  --UUID

select @systemId=SystemID,@companyId=CompanyID,@memberId=MemberID,@uuid=uuid from Ld_Member_RefreshToken as t1
left join Ld_Member_AccessToken as t2 on t1.Token=t2.token
where RefreshToken=@verifyRefreshToken


begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try
	    --更新旧的token过期时间
		update Ld_Member_AccessToken set ExpiresIn=120,CreateTimestamp=@createTimestamp 
		where SystemID=@systemId and CompanyID=@companyId and MemberID=@memberId and ExpiresIn=@expiresIn and (@createTimestamp-CreateTimestamp)<=@expiresIn
		set @tranErrorCode=@tranErrorCode+@@ERROR

		--插入新的token
		insert into Ld_Member_AccessToken(Token,SystemId,CompanyId,MemberID,UUID,ExpiresIn,IpAddress,CreateTimestamp,State,CreateDate) 
		select @token,@systemId,@CompanyId,@MemberID,@uuid,@expiresIn,@ipAddress,@createTimestamp,1,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

		--更新Ld_Member_RefreshToken使用状态
		update Ld_Member_RefreshToken set State=0 where RefreshToken=@verifyRefreshToken
		set @tranErrorCode=@tranErrorCode+@@ERROR

		insert into Ld_Member_RefreshToken(RefreshToken,Token,ExpiresIn,IpAddress,CreateTimestamp,State,CreateDate)
		select @RefreshToken,@Token,@refreshTokenExpiresIn,@IpAddress,@createTimestamp,1,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end








GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_AccessCorsHost]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_AccessCorsHost]

@systemId int,
@WebHost varchar(250),
@Remark nvarchar(400),
@Account varchar(20),
@NickName nvarchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'

if exists(select * from Ld_Sys_AccessCorsHost where SystemID=@systemId and WebHost=@WebHost)
begin
	select @errorCode=41254,@errorMsg='授权地址已存在！'
	return
end

declare @total int=0
select @total=count(*) from Ld_Sys_AccessCorsHost where SystemID=@systemId
if (@total>=10)
begin
	select @errorCode=41254,@errorMsg='跨域地址最多10个地址！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    insert into Ld_Sys_AccessCorsHost (systemid,WebHost,Remark,Account,NickName,State,CreateDate)
		select @systemid,@WebHost,@Remark,@Account,@NickName,@state,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_Code]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_Code]

@systemId int,
@systemName nvarchar(50),
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    insert into Ld_Sys_Code (systemid,SystemName,Description,State,CreateDate)
		select @systemid,@systemName,@description,@state,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_Function]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-23
-- Description: 新增权限组功能 XXXXXXXXXX
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_Function]

@functionId varchar(6),
@functionName nvarchar(50),
@parentId varchar(20),
@rankId int,
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output


AS

set @errorCode=-1
set @errorMsg='fail'



if (len(@functionId)<>6)
begin
	SELECT @errorCode=4001,@errorMsg='功能编号必须是6位数字组成'
	return
end

if (isnull(@functionName,'')='')
begin
	SELECT @errorCode=4001,@errorMsg='功能名称不能为空'
	return
end

if exists(select * from [ld_sys_function] with(nolock) where functionid=@functionid)
begin
	select @errorCode=4002,@errorMsg='功能编号已经存在！'
	return
end

if (isnull(@parentId,'')='')
set @parentId='000000'

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
		insert into Ld_Sys_Function(FunctionId,FunctionName,ParentId,RankID,Selected,State,IsDel,CreateDate)
		select @FunctionId,@FunctionName,@ParentId,@rankId,0,@state,0,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_InterfaceAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-28
-- Description:	系统token 写入  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_InterfaceAccessToken]

@token varchar(128),                --token字符串
@systemId int,                      --系统编号
@appId varchar(16),                 --APPID
@expiresIn int,                     --过期时间秒
@ipAddress varchar(20),             --IP地址
@createTimestamp int,               --当前时间
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=412012,@errorMsg='token不能为空！'
	return
end

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='系统编号不能为空！'
	return
end
if not exists(select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId)
begin
	select @errorCode=412012,@errorMsg='appid invalid！'
	return
end

declare @companyId varchar(20)
select @companyId=CompanyID from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='公司编号不能为空！'
	return
end

--统计当天请求总数
declare @sameDayTotalNum int=0
select @sameDayTotalNum=count(*) from Ld_Sys_InterfaceAccessToken with(nolock) 
where SystemId=@systemId and AppId=@appId and DateDiff(dd,CreateDate,getdate())=0
if (@sameDayTotalNum>1000)
begin
	select @errorCode=412012,@errorMsg='每天请求次数不能超过1000次！'
	return
end

begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	begin try

	    --select @createTimestamp-CreateTimestamp from Ld_Sys_Token where SystemId=@systemId and CompanyId=@CompanyId and MemberId=@MemberId and ClassId=@ClassId and ExpiresIn=@expiresIn 
	    --更新旧的token过期时间
		update Ld_Sys_InterfaceAccessToken set ExpiresIn=120,CreateTimestamp=@createTimestamp 
		where AppId=@appId and ExpiresIn=@expiresIn and (@createTimestamp-CreateTimestamp)<=@expiresIn
		set @tranErrorCode=@tranErrorCode+@@ERROR

		--插入新的token
		insert into Ld_Sys_InterfaceAccessToken (Token,SystemId,CompanyId,AppId,ExpiresIn,IpAddress,CreateTimestamp,State,CreateDate) 
		select @token,@systemId,@CompanyId,@AppId,@expiresIn,@ipAddress,@createTimestamp,1,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end






GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_InterfaceAccessTokenAuto]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-07-01
-- Description:	验证appid、写入token
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_InterfaceAccessTokenAuto]

@token varchar(128),                --token字符串
@systemId int,                      --系统编号
@appId varchar(16),                 --API接口APPID
@appSecret varchar(32),             --API接口AppSecret
@expiresIn int,                     --过期时间秒
@ipAddress varchar(20),             --IP地址
@createTimestamp int,               --当前时间
@errorCode int output,              --
@errorMsg nvarchar(200) output

AS

--SET NOCOUNT ON;

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=301210,@errorMsg='token not empty'
	return
end

if (isnull(@expiresIn,0)<=0)
begin
	select @errorCode=301210,@errorMsg='expires in not 0'
	return
end

declare @appIdTotalNum int
select @appIdTotalNum=count(*) from Ld_Sys_InterfaceAccount where systemid=@systemid and AppID=@appId
if (isnull(@appIdTotalNum,0)<>1)
begin
	select @errorCode=301210,@errorMsg='appid error！'
	return
end

begin tran tranAdd
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='tran initialize'
	begin try
		declare @isAppIdResult int
		declare @isAppIdErrCode int
		declare @isAppIdErrMsg nvarchar(200)
		exec @isAppIdResult = SP_Verify_Sys_InterfaceAccountByAppId @systemId,@appId,@appSecret, @isAppIdErrCode output,@isAppIdErrMsg output
		--select @tranErrorCode,@isAppIdErrCode,@isAppIdErrMsg
		set @tranErrorCode=@tranErrorCode+@isAppIdResult+@isAppIdErrCode+@@ERROR
		set @tranErrorMsg=@isAppIdErrMsg
		
		--验证AppID通过执行
		if (@isAppIdResult=0 and @isAppIdErrCode=0)
		begin
			declare @companyId varchar(20)
			select  @companyId=CompanyId from Ld_Sys_InterfaceAccount with(nolock) where systemId=@systemid and AppId=@AppId and AppSecret=@AppSecret
			
			declare @addSysTokenResult int
			declare @addSysTokenErrCode int
			declare @addSysTokenErrMsg nvarchar(200)
			exec @addSysTokenResult = SP_Add_Sys_InterfaceAccessToken @token,@systemid,@appId,@expiresIn,@ipAddress,@createTimestamp, @addSysTokenErrCode output,@addSysTokenErrMsg output
			--select @addSysTokenResult,@addSysTokenErrCode,@addSysTokenErrMsg
			set @tranErrorCode=@tranErrorCode+@addSysTokenResult+@addSysTokenErrCode+@@ERROR
			set @tranErrorMsg=@addSysTokenErrMsg
		end

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_InterfaceAccessWhiteList]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@ipAddress varchar(20),
@classId int,
@className nvarchar(20),
@remark nvarchar(400),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'


if exists(select * from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipaddress=@ipAddress and classid=@classId)
begin
   select @errorCode=41201,@errorMsg='授权的IP地址已存！'
   return
end

BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		insert into Ld_Sys_InterfaceAccessWhiteList (SystemId,CompanyId,Account,IpAddress,ClassID,ClassName,Remark,State,CreateDate)
		values (@systemId,@companyId,@account,@IpAddress,@ClassID,@ClassName,@Remark,@State,getdate())
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号 
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_InterfaceAccount]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@password varchar(32),
@isWcf bit,
@isWeb bit,
@isApi bit,
@isCors bit,
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

declare @accountTotalNumber int
select @accountTotalNumber=count(*) from Ld_Sys_InterfaceAccount where SystemID=@systemid and CompanyID=@companyId
if (@accountTotalNumber>=10)
begin
	select @errorcode=40121,@errorMsg='帐号上限为10个！'
	return
end



declare @appId varchar(16)
declare @AppSecret varchar(32)
declare @AppKey varchar(32)
declare @UuID varchar(32)
set @appId='Ld_'+dbo.fn_get_random_string(13)
set @AppSecret=dbo.fn_get_random_string(32)
set @AppKey=dbo.fn_get_random_string(32)
set @uuid=LOWER(REPLACE(LTRIM(NEWID()),'-',''))

if exists(select * from Ld_Sys_InterfaceAccount where SystemID=@systemid and AppID=@appId)
begin
	select @errorcode=40121,@errorMsg='AppID Exists！'
	return
end


BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统接口帐号录入
		insert into Ld_Sys_InterfaceAccount (SystemId,CompanyId,Account,Password,UuID,AppId,AppSecret,AppKey,IsWcf,IsWeb,IsApi,IsCors,RequestTotalNumber,Description,State,IsDel,CreateDate)
		values (@systemId,@companyId,@account,@password,@UuID,@appId,@AppSecret,@AppKey,@IsWcf,@IsWeb,@isApi,@IsCors,0,@Description,@State,0,getdate())
		set @tranErrorCode=@tranErrorCode+@@ERROR

	    --初始化公司接口白名单
		insert into Ld_Sys_InterfaceAccessWhiteList (SystemId,CompanyId,Account,IpAddress,ClassID,ClassName,Remark,State,CreateDate)
		values
		(@SystemId,@CompanyId,@account,'*',1,'WCF','系统初始化',1,getdate()),
		(@SystemId,@CompanyId,@account,'*',2,'WEB','系统初始化',1,getdate()),
		(@SystemId,@CompanyId,@account,'*',3,'API','系统初始化',1,getdate())

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	系统操作员添加
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_Operator] 

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@roleId varchar(4),
@remark nvarchar(400),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output


AS

--初始化参数
set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0
declare @isDal bit=1
declare @CreateDate datetime=getdate()

if (isnull(@companyId,'')='')
set @companyId='sys'


--验证公司是否存在
if not exists(select * from Ld_Sys_Code with(nolock) where systemid=@systemid)
begin
	select @errorcode=4001,@errorMsg='系统编号不存在'
	return
end
--验证角色号是否存在
if not exists(select * from Ld_Sys_Role with(nolock) where systemid=@systemid and companyid=@companyid and roleid=@roleid)
begin
	select @errorcode=4001,@errorMsg='角色号不存在'
	return
end
--验证员工工号是否存在
if not exists(select * from Ld_Institution_Staff with(nolock) where systemid=@systemid and companyid=@companyid and StaffId=@staffId)
begin
	select @errorcode=4004,@errorMsg='员工编号不存在'
	return
end
--验证员工是否是操作员
if exists(select * from Ld_Sys_Operator with(nolock) where systemid=@systemid and companyid=@companyid and StaffId=@staffId)
begin	
	select @errorcode=4003,@errorMsg='员工已经是系统操作员'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    insert into Ld_Sys_Operator (systemid,CompanyId,StaffId,Remark,State,CreateDate)
		select @systemid,@companyid,@staffId,@remark,@state,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

		insert into Ld_Sys_OperatorRole (systemid,CompanyId,StaffId,RoleId)
		select @systemid,@companyid,@staffId,@roleid
		set @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end





GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	角色添加   XXXXXXXXXXXXXXXX
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_Role]

@systemId int,                   --系统编号
@companyId varchar(20),          --公司编号
@roleId varchar(4),              --角色编号
@roleName nvarchar(10),          --角色名称
@functionId varchar(max),        --角色许可功能数组 000000,111111,222222
@remark nvarchar(200),           --备注
@state bit,                      --状态 
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @ErrorCode=-1
set @errorMsg='fail'
declare @totalRow int=0
declare @isDel bit=0
declare @createDate datetime=getdate()




--验证公司是否存在
if not exists(select SystemID from Ld_Sys_Code with(nolock) where SystemId=@systemId)
begin
	select @errorCode=100012,@errorMsg='system id invalid'
	return
end

--验证名称重复
if exists(select * from Ld_Sys_Role with(nolock) where systemid=@systemid and CompanyId=@companyId and RoleName=@RoleName)
begin
	select @errorCode=4003,@errorMsg='role name exists'
	return
end

--如果角色编号为空，自动生成编号
if (isnull(@roleid,'')='')
begin
	declare @rolenewid int
	select @rolenewid=count(*)+1 from Ld_Sys_Role with(nolock) where systemid=@systemid and CompanyId=@companyId
	select @roleid='2'+right('000'+cast(@rolenewid as nvarchar),3)
end
else
begin
	set @roleid='2'+right('000'+right(@roleid,3),3)
end

--验证编号重复
if exists(select * from Ld_Sys_Role with(nolock) where systemid=@systemid and CompanyId=@companyId and RoleId=@RoleId)
begin
	select @errorcode=4003,@errorMsg='role id exists'
	return
end
--判断功能号是否全部有效
declare @P int=dbo.fn_get_array_length(@FunctionId,',')
declare @arrFuncId varchar(max)=''
declare @arrTotal int = 0
while @arrTotal<@P
begin
    set @arrTotal=@arrTotal+1
	if (@arrFuncId='')
		set @arrFuncId=@arrFuncId+''''+dbo.fn_get_array_value(@functionId,',',@arrTotal)+''''
	else
		set @arrFuncId=@arrFuncId+','''+dbo.fn_get_array_value(@functionId,',',@arrTotal)+''''
end
declare @Y int=0
declare @CmdText nvarchar(max)='select count(*) from Ld_Sys_Function where FunctionId in ('+@arrFuncId+') and state=1 and IsDel=0'
declare @Tmp table(FunctionTotalRow int)
insert into @Tmp exec sp_executesql @CmdText 
select @Y=FunctionTotalRow from @Tmp
print @CmdText
print @Y
print @P
IF (@P<>@Y)
begin
	select @errorcode=4003,@errorMsg='select function id not exists'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
	    --写入角色
		INSERT INTO Ld_Sys_Role (SystemId,CompanyId,roleId,roleName,Remark,State,IsDel,CreateDate)
		SELECT @SystemId,@companyId,@roleId,@roleName,@Remark,@state,@isDel,@createDate
		SET @tranErrorCode=@tranErrorCode+@@ERROR
		    
		--declare @FunctionId nvarchar(1000) ='1,2,3,4,5,6,7,8,9'
		declare @i int=1
		declare @n int=dbo.fn_get_array_length(@FunctionId,',')
		WHILE @i<=@n
			BEGIN
			declare @MyFunctionId nvarchar(6)=dbo.fn_get_array_value(@FunctionId,',',@i)
			--print @MyFunctionId
			insert into Ld_Sys_RoleFunction (SystemId,CompanyId,RoleId,FunctionId)
			select @SystemId,@companyId,@RoleId,@MyFunctionId
			SET @i=@i+1
			END
        SET @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END







GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sys_Version]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Sys_Version]

@versionId varchar(10),
@versionName nvarchar(50),
@marketPrice decimal(18,2),
@dealerPrice decimal(18,2),
@departmentTotalQuantity int,
@staffTotalQuantity int,
@storeTotalQuantity int,
@warehouseTotalQuantity int,
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    insert into Ld_Sys_Version (VersionID,VersionName,MarketPrice,DealerPrice,DepartmentTotalQuantity,StaffTotalQuantity,StoreTotalQuantity,WarehouseTotalQuantity,Description,State,CreateDate)
		select @versionId,@versionName,@marketPrice,@dealerPrice,@departmentTotalQuantity,@staffTotalQuantity,@StoreTotalQuantity,@WarehouseTotalQuantity,@description,@state,getdate()
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	删除部门
-- =============================================
CREATE PROCEDURE  [dbo].[SP_Delete_Institution_Department]

@systemId int,
@companyId varchar(20),
@departmentId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

--判断是部门编号是否存在
if not exists(select SystemId from Ld_Institution_Department where SystemId=@SystemId and CompanyId=@companyId and DepartmentId=@departmentId)
begin
	select @errorcode=40121,@errorMsg='department id invalid！'
	return
end
--判断是否有下级部分
if exists(select SystemId from Ld_Institution_Department where SystemId=@SystemId and CompanyId=@companyId and ParentId=@departmentId)
begin
	select @errorcode=40121,@errorMsg='部门下级还有部门请先删除下级部门！'
	return
end
--判断是否有员工使用
if exists(select SystemId from Ld_Institution_Staff where SystemId=@SystemId and CompanyId=@companyId and DepartmentId=@departmentId)
begin
	select @errorcode=40121,@errorMsg='部门下还有员工，不能删除！'
	return
end

--开始事务
begin tran tranDelete    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除部门
		delete from Ld_Institution_Department where SystemId=@SystemId and CompanyId=@companyId and DepartmentId=@departmentId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Institution_Position]

@systemId int,
@companyId varchar(20),
@positionId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId)
begin
	select @errorCode=40123,@errorMsg='职位编号不存在！'
	return
end

if exists(select * from Ld_Institution_Staff where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId)
begin
	select @errorCode=40123,@errorMsg='职位已被使用不能删除！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	BEGIN TRY
		--初始化公司帐号
		delete Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end


GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	删除员工
-- =============================================
CREATE PROCEDURE  [dbo].[SP_Delete_Institution_Staff]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

--判断是网点编号是否存在
if not exists(select SystemId from Ld_Institution_Staff where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=40121,@errorMsg='staff id invalid！'
	return
end

declare @isInit bit
select @isInit=IsInit from Ld_Institution_Staff where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId
if (@isInit=1)
begin
	select @errorcode=40121,@errorMsg='初始化用户不能删除！'
	return
end

--判断是否为操作
if exists(select SystemId from Ld_Sys_Operator where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=40121,@errorMsg='员工是操作员，请选移除员工操作员身份再删除！'
	return
end


--开始事务
begin tran tranDelete    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除员工
		delete from Ld_Institution_Staff where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END










GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	删除网点
-- =============================================
CREATE PROCEDURE  [dbo].[SP_Delete_Institution_Store]

@systemId int,
@companyId varchar(20),
@storeId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

--判断是网点编号是否存在
if not exists(select SystemId from Ld_Institution_Store where SystemId=@SystemId and CompanyId=@companyId and StoreId=@storeId)
begin
	select @errorcode=40121,@errorMsg='store id invalid！'
	return
end

--判断是否有员工
if exists(select SystemId from Ld_Institution_Staff where SystemId=@SystemId and CompanyId=@companyId and StoreId=@storeId)
begin
	select @errorcode=40121,@errorMsg='网点下有员工，请选移除员工再删除！'
	return
end


--开始事务
begin tran tranDelete    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除网点
		delete from Ld_Institution_Store where SystemId=@SystemId and CompanyId=@companyId and StoreId=@storeId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Member_Account]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Member_Account]

@systemId int,
@companyId varchar(20),
@memberId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'




--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级状态
		DELETE Ld_Member_Account WHERE SystemID=@systemId and CompanyID=@companyId and MemberID=@memberId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end





GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Member_Rank]

@systemId int,
@companyId varchar(20),
@rankId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


if (len(@RankID)<>2)
begin
	select @errorCode=41021,@errorMsg='会员等级编号必须是2位0-9数字组成的字符串！'
	return
end

if (@rankId='01')
begin
	select @errorCode=41021,@errorMsg='初始化会员等级不可删除！'
	return
end

if not exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID=@rankId)
begin
	select @errorCode=41021,@errorMsg='会员等级编号不存在！'
	return
end

if exists(select * from Ld_Member_Account where SystemID=@systemId and CompanyID=@companyId and RankID=@RankId)
begin
	select @errorCode=41021,@errorMsg='会员等级已被使用不能操作删除！'
	return
end


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级状态
		DELETE Ld_Member_Rank WHERE SystemID=@systemId and CompanyID=@companyId and RankID=@rankId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_AccessCorsHost]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_AccessCorsHost]

@systemId int,
@WebHost varchar(250),
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		delete Ld_Sys_AccessCorsHost where SystemID=@systemId and WebHost=@WebHost
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_Code]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_Code]

@systemId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



--开始事务
begin tran tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除功能编号
		delete from Ld_Sys_Code where  SystemID=@systemId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch


IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END



GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_Function]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	删除系统功能
-- =============================================
CREATE PROCEDURE  [dbo].[SP_Delete_Sys_Function]


@functionId varchar(6),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0

if (@functionId='000000')
begin
	select @errorcode=40121,@errorMsg='初始化所有者功能不能删除！'
	return
end


if exists(select * from Ld_Sys_Function where ParentId=@functionId)
begin
	select @errorcode=40121,@errorMsg='先删除下级所有功能，再删除！'
	return
end

if exists(select * from Ld_Sys_RoleFunction where FunctionId=@functionId)
begin
	select @errorcode=40121,@errorMsg='功能编号已被使用不能删除！'
	return
end

--开始事务
begin tran tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除功能编号
		delete from Ld_Sys_Function where  FunctionId=@functionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch


IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_InterfaceAccessWhiteList]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@ipAddress varchar(20),
@classId int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		delete Ld_Sys_InterfaceAccessWhiteList 
		where SystemID=@systemId and CompanyID=@companyId and Account=@account and IpAddress=@ipAddress and ClassID=@classId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_InterfaceAccount]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

if (@companyId=@account)
begin
	select @errorCode=41251,@errorMsg='初始化帐号不可删除！'
	return
end


BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统接口帐号录入
		delete Ld_Sys_InterfaceAccount where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

		--删除接口帐号IP白名单
		delete Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	操作员审核操作
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_Operator]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output


AS

set @errorCode=-1
set @errorMsg='fail'
declare @CreateDate datetime=getdate()

if not exists(select * from Ld_Sys_Operator with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=400112,@errorMsg='操作员ID不存在！'
	return
end

declare @isInit bit
select @isInit=IsInit from Ld_Institution_Staff with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
if (isnull(@isInit,0)=1)
begin
	select @errorcode=400112,@errorMsg='系统初始化超级管理员不可删除！'
	return
end


--开始事务
begin tran tran_add    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除操作员关系
		delete Ld_Sys_OperatorRole where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
		set @tranErrorCode=@tranErrorCode+@@ERROR
		--删除操作员
		delete Ld_Sys_Operator where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
		set @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end






GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	删除角色
-- =============================================
CREATE PROCEDURE  [dbo].[SP_Delete_Sys_Role]

@systemId int,                   --系统编号
@companyId varchar(20),          --公司编号
@roleId nvarchar(4),             --角色编号
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0

if (@RoleId='2001')
begin
	select @errorcode=40121,@errorMsg='初始角色不能删除'
	return
end

if exists(select * from Ld_Sys_OperatorRole where SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId)
begin
	select @errorcode=40121,@errorMsg='角色已被使用不能删除'
	return
end

--开始事务
begin tran tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除角色功能
		delete from Ld_Sys_RoleFunction where SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
		--删除角色
		delete from Ld_Sys_Role where SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch


IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END






GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Sys_Version]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Sys_Version]

@versionId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



--开始事务
begin tran tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --删除功能编号
		delete from Ld_Sys_Version where  VersionID =@versionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch


IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_Company]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	获取公司明细
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_Company]

@systemId int,
@companyId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Institution_Company where SystemID=@systemId and CompanyID=@companyId

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END


GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_CompanyPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	获取公司明细
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_CompanyPaging]

@systemId int,
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'
set @RowCount=0
declare @TotalRow int=0
declare @QueryRow int=0

-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Institution_Company with(nolock) where SystemId=@Systemid
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Institution_Company with(nolock) where SystemId=@Systemid
order by CreateDate desc offset @startPage row fetch next @pageSize rows only

select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'


GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_CompanyTop]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	获取公司明细
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_CompanyTop]

@systemId int,
@count int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

--declare @count int=1
select top (@count) * from Ld_Institution_Company where SystemID=@systemId

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END


GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	栏目、分类查询列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_Department]

@systemId int,                 --系统号
@companyId varchar(20),        --公司编号
@departmentId varchar(20),     --部门ID
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Institution_Department where SystemId=@systemId and CompanyId=@companyId and departmentId=@departmentId

select @errorCode=@@error
if @errorCode=0
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=@@error,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_DepartmentByNodePath]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	栏目、分类查询列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_DepartmentByNodePath]

@systemId int,                 --系统号
@companyId varchar(20),        --公司编号
@departmentId varchar(20),     --部门ID
@state varchar(5),             --状态
@errorCode int output,
@errorMsg nvarchar(180) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

--@ParentPath
DECLARE @ParentPath nvarchar(400)
IF (ISNULL(@departmentId,0)=0)
	select @ParentPath='0'
ELSE
	select @ParentPath=NodePath+','+CAST(@DepartmentId AS varchar(20)) FROM Ld_Institution_Department with(nolock) WHERE systemid=@SystemId and CompanyId=@CompanyId and DepartmentId=@DepartmentId

	select * from ld_institution_department with(nolock)
	where systemid=@systemid 
	and companyid=@companyid 
	and nodepath like ''+@parentpath+'%' 
	and state=case when isnull(@state,'')='' then [state] else @state end
	order by [sortpath] asc, [sortid] asc


select @errorCode=@@error
if @errorCode=0
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=@@error,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_DepartmentByParentId]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	栏目、分类查询列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_DepartmentByParentId]

@systemId int,                 --系统号
@companyId varchar(20),        --公司编号
@parentId varchar(20),         --上级ID
@state varchar(1),
@errorCode int output,
@errorMsg nvarchar(180) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Institution_Department where SystemId=@systemId and CompanyId=@companyId and ParentID=@parentId
and state=case when isnull(@state,'')='' then [state] else @state end

select @errorCode=@@error
if @errorCode=0
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=@@error,@errorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_DepartmentPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统操作员列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_DepartmentPaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'
set @RowCount=0
declare @TotalRow int=0
declare @QueryRow int=0

-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Institution_Department with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Institution_Department  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_Position]

@systemId int,
@companyId varchar(20),
@positionId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId

set @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=@errorCode,@errorMsg='ok'
else
	select @errorCode=@errorCode,@errorMsg='fail'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_PositionByState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_PositionByState]

@systemId int,
@companyId varchar(20),
@state varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId
and [State]=case when isnull(@state,'')='' then [State] else @state end
order by CreateDate desc

set @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=@errorCode,@errorMsg='ok'
else
	select @errorCode=@errorCode,@errorMsg='fail'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_PositionPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_PositionPaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Institution_Position with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Institution_Position  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_Staff] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@staffId varchar(20),          --网点编号                 
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

set @ErrorCode=-1
set @errorMsg='FAIL'
declare @QueryRow int

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='system id not empty！'
	return
end
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='company id not empty！'
	return
end

select * from Ld_Institution_Staff with(nolock) where SystemId=@Systemid and CompanyId=@companyId and StaffID=@staffId

select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT

if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='fail'









GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_StaffPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_StaffPaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Institution_Staff with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Institution_Staff  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_Store] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@storeId varchar(20),          --网点编号                 
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

set @ErrorCode=-1
set @errorMsg='FAIL'
declare @QueryRow int

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='system id not empty！'
	return
end
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='company id not empty！'
	return
end

select * from Ld_Institution_Store with(nolock) where SystemId=@Systemid and CompanyId=@companyId and StoreID=@storeId

select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT

if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='fail'








GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_StoreByState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_StoreByState] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@State varchar(10),                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

set @ErrorCode=-1
set @errorMsg='FAIL'
declare @QueryRow int

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='system id not empty！'
	return
end
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='company id not empty！'
	return
end

select * from Ld_Institution_Store with(nolock) where SystemId=@Systemid and CompanyId=@companyId
and [State]=case when isnull(@state,'')='' then [State] else @state end

select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT

if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='fail'








GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Institution_StorePaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Institution_StorePaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Institution_Store with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Institution_Store  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_AccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_AccessToken]

@token varchar(64),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@token,'')='')
begin
	select @errorCode=40002,@errorMsg='token not empty'
	return
end

select * from Ld_Member_AccessToken with(nolock) where Token=@token
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_Account]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_Account]

@systemId int,
@companyId varchar(20),
@memberId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@memberId,'')='')
begin
	select @errorCode=40002,@errorMsg='member id empty'
	return
end

select * from Ld_Member_Account with(nolock) where SystemID=@systemId and CompanyID=@companyId and  MemberID=@MemberID
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_AccountByAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_AccountByAccessToken]

@systemId int,
@accessToken varchar(64),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@accessToken,'')='')
begin
	select @errorCode=40002,@errorMsg='access token not empty'
	return
end

declare @companyId varchar(20),@MemberID varchar(20)
select @companyId=CompanyID,@MemberID=MemberID from Ld_Member_AccessToken where token=@accessToken
select * from Ld_Member_Account with(nolock) where SystemID=@systemId and CompanyID=@companyId and  MemberID=@MemberID

select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_AccountByRefreshToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_AccountByRefreshToken]

@systemId int,
@refreshToken varchar(64),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@refreshToken,'')='')
begin
	select @errorCode=40002,@errorMsg='access token not empty'
	return
end


--select * from Ld_Member_RefreshToken as t1 left join Ld_Member_AccessToken as t2 on t1.token=t2.token where RefreshToken=@refreshToken

declare @companyId varchar(20),@MemberID varchar(20)
select @companyId=CompanyID,@MemberID=MemberID from Ld_Member_RefreshToken as t1 left join Ld_Member_AccessToken as t2 on t1.token=t2.token where RefreshToken=@refreshToken
select * from Ld_Member_Account with(nolock) where SystemID=@companyId and CompanyID=@companyId and  MemberID=@MemberID

select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_AccountPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	查询会员帐号分页显示
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_AccountPaging]

@systemId int,
@companyId varchar(20),
@delete varchar(8),
@pageId int,
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Member_Account with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
and IsDel=case when isnull(@delete,'')='' then IsDel else @delete end
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Member_Account  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
and IsDel=case when isnull(@delete,'')='' then IsDel else @delete end
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_Rank]

@systemId int,
@companyId varchar(20),
@RankID varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@RankID,'')='')
begin
	select @errorCode=40002,@errorMsg='member id empty'
	return
end

select * from Ld_Member_Rank with(nolock) where SystemID=@systemId and CompanyID=@companyId and  RankID=@RankID
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_RankPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	查询会员帐号分页显示
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_RankPaging]

@systemId int,
@companyId varchar(20),
@pageId int,
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Member_Rank with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Member_Rank  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Member_RankState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Member_RankState]

@systemId int,
@companyId varchar(20),
@state varchar(8),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'



select * from Ld_Member_Rank with(nolock) where SystemID=@systemId and CompanyID=@companyId
and state=case when isnull(@state,'')='' then state else @state end
order by rankid asc

select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_AccessCorsHost]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_AccessCorsHost]

@systemId int,
@webHost varchar(250),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Sys_AccessCorsHost where SystemID=@systemId and WebHost=@webHost

set @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=@errorCode,@errorMsg='ok'
else
	select @errorCode=@errorCode,@errorMsg='fail'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_AccessCorsHostAll]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_AccessCorsHostAll]

@systemId int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'

select * from Ld_Sys_AccessCorsHost where SystemID=@systemId order by CreateDate desc

set @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=@errorCode,@errorMsg='ok'
else
	select @errorCode=@errorCode,@errorMsg='fail'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Code]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Code]

@systemId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_Code 
where SystemID=case when isnull(@systemId,'')='' then SystemID else @systemId end
order by CreateDate asc

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Config]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Config]

@systemId varchar(10),
@companyId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_Config where systemid=@systemid and CompanyID=@companyId

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Function]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	查询系统功能列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Function]

@functionId varchar(10),
@errorCode int output,
@errorMsg nvarchar(180) output

AS

set @errorCode=-1
set @errorMsg='fail'


--ROW_NUMBER() OVER (ORDER BY FunctionId asc) AS RowId 生成行号
select * from Ld_Sys_Function where FunctionID=@functionId

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_FunctionByParentId]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	查询系统功能列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_FunctionByParentId]

@parentId varchar(10),
@errorCode int output,
@errorMsg nvarchar(180) output

AS

set @errorCode=-1
set @errorMsg='fail'


--ROW_NUMBER() OVER (ORDER BY FunctionId asc) AS RowId 生成行号
select * from Ld_Sys_Function 
where ParentId=case when isnull(@ParentId,'')='' then ParentId else @ParentId end
order by FunctionId asc

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccessToken]

@token varchar(128),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@token,'')='')
begin
	select @errorCode=40002,@errorMsg='token not empty'
	return
end

select * from Ld_Sys_InterfaceAccessToken with(nolock) where Token=@token
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccessTokenTotalNumber]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小
-- Create date: 2019-01-27
-- Description:	获取
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccessTokenTotalNumber]

@systemId int,
@appId varchar(16),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'

if not exists(select * from Ld_Sys_InterfaceAccount where systemid=@systemid and AppID=@appId)
begin
	select @errorCode=301210,@errorMsg='appid invalid！'
	return
end

select count(*) as TotalNumber from Ld_Sys_InterfaceAccessToken where systemid=@systemid and AppID=@appId and DateDiff(dd,CreateDate,getdate())=0 
select @errorcode=@@error
if @errorcode=0
	select @errorcode=0,@errormsg='ok'
else
	select @errorcode=-2,@errormsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccessWhiteList]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@ipAddress nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipaddress=@ipAddress

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccessWhiteListByAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccessWhiteListByAccount]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccount]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and CompanyID=@companyId and Account=@account 

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccountAll]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccountAll]

@systemId int,
@companyId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and CompanyID=@companyId

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccountByAppid]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccountByAppid]

@systemId int,
@appId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId 

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'



GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccountByToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccountByToken]

@systemId int,
@token varchar(128),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

declare @companyId varchar(20),@appid varchar(16)
select @companyId=CompanyID,@appid=AppID from Ld_Sys_InterfaceAccessToken where Token=@token
select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and CompanyID=@companyId and appid=@appid

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccountByUuid]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	查询系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccountByUuid]

@systemId int,
@uuid varchar(32),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and UuID=@uuid

set @errorCode=@@ERROR
if (@errorCode=0)
select  @errorCode=0,@errorMsg='ok'
else
select @errorCode=-2,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_InterfaceAccountPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_InterfaceAccountPaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

declare @TotalRow int
select @errorCode=-1
select @errorMsg='FAIL'
select @TotalRow=0


-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Sys_InterfaceAccount with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Sys_InterfaceAccount  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=-2,@errorMsg='error'




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统操作员明细
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Operator]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'
declare @QueryRow int

if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='system id not empty！'
	return
end
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='company id not empty！'
	return
end

select top 1 * from v_sys_operator with(nolock) where SystemId=@Systemid and CompanyId=@companyId and StaffId=@staffId
select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT
--if (isnull(@QueryRow,0)=0)
--begin
--	select @errorCode=412012,@errorMsg='not data！'
--	return
--end
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='fail'








GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_OperatorPaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统操作员列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_OperatorPaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'
set @RowCount=0
declare @TotalRow int=0
declare @QueryRow int=0


if (isnull(@systemId,0)=0)
begin
	select @errorCode=412012,@errorMsg='system id not empty！'
	return
end
if (isnull(@companyId,'')='')
begin
	select @errorCode=412012,@errorMsg='company id not empty！'
	return
end

-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from v_sys_operator with(nolock) where SystemId=@Systemid and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from v_sys_operator with(nolock) where SystemId=@Systemid and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only

select @errorCode=@@ERROR,@queryRow=@@ROWCOUNT
if (@errorCode=0 and @queryRow>0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='not data'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统角色明细
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Role]

@systemId int,
@companyId varchar(20),
@roleId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'

select * from Ld_Sys_Role  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId and RoleID=@roleId

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='error'








GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_RoleAll]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统角色全部列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_RoleAll]

@systemId int,
@companyId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'

select * from Ld_Sys_Role  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_RoleFunction]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询角色可用功能
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_RoleFunction]

@systemId int,
@companyId varchar(20),
@roleId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

--初始化参数
select @errorCode=-1
select @errorMsg='fail'

--查询角用全部功能列表
select SystemID,CompanyID,RoleID,RoleName,FunctionID,FunctionName,RankID from V_Sys_RoleFunction 
where systemid=@systemid and CompanyId=@companyId and roleid=@roleid

select @errorCode=@@error
if @errorCode=0
	select @errorcode=0,@errorMsg='ok'
else
	select @errorcode=-2,@errorMsg='not data'
	





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_RoleFunctionSelect]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询角色可用功能
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_RoleFunctionSelect]

@systemId int,
@companyId varchar(20),
@roleId nvarchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

--初始化参数
select @errorcode=-1
select @errorMsg='fail'

--查询角用全部功能列表
select * into #RoleSysFunction  from Ld_Sys_Function
if (isnull(@RoleId,'')='2001')
begin
	update #RoleSysFunction set Selected=1
end
else
begin
	update #RoleSysFunction set Selected=1 where FunctionId in (select FunctionId from V_Sys_RoleFunction 
	where systemid=@systemid and CompanyId=@companyId and roleid=@roleid)
end
select * from  #RoleSysFunction

--判断临时表是否存在
if OBJECT_ID('tempdb..#RoleSysFunction') is not null
drop table #RoleSysFunction

select @errorcode=@@error
--输出结果
if @errorcode=0
	select @errorcode=0,@errorMsg='ok'
else
	select @errorcode=401205,@errorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_RolePaging]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-20
-- Description:	查询系统操作员列表
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_RolePaging]

@systemId int,
@companyId varchar(20),
@pageId int,        
@pageSize int,
@errorCode int output,
@errorMsg nvarchar(200) output,
@rowCount int output

AS

set @ErrorCode=-1
set @errorMsg='FAIL'
set @RowCount=0
declare @TotalRow int=0
declare @QueryRow int=0

-- =================================
-- 初始化参数 
-- 默认第一页起查询，每页10条记录
-- =================================
if (isnull(@pageId,0)=0)
set @pageId=1
if (isnull(@pageSize,0)=0)
set @pageSize=10


--数据总数
select @TotalRow=count(*) from Ld_Sys_Role with(nolock) where SystemId=@Systemid  and CompanyId=@companyId
set @rowCount=@TotalRow
--分页查询
declare @startPage int
set @startPage=(isnull(@pageId,1)-1) * @pageSize
select * from Ld_Sys_Role  with(nolock) where SystemId=@Systemid  and CompanyId=@companyId 
order by CreateDate desc offset @startPage row fetch next @pageSize rows only 

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=100215,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Sys_Version]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_Sys_Version]

@versionId varchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

select * from Ld_Sys_Version 
where VersionID=case when isnull(@versionId,'')='' then VersionID else @versionId end
order by CreateDate asc

--输出
SELECT @errorCode=@@ERROR
IF @ErrorCode=0
	BEGIN
		SELECT @ErrorCode=0,@errorMsg='ok'
	END
ELSE
	BEGIN
		SELECT @ErrorCode=-2,@errorMsg='error'
	END




GO
/****** Object:  StoredProcedure [dbo].[SP_Get_VInstitution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_VInstitution_Staff]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@staffId,'')='')
begin
	select @errorCode=40002,@errorMsg='staff id not empty'
	return
end

select * from V_Institution_Staff with(nolock) where systemid=@systemid and companyid=@companyid and staffid=@staffid
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Get_VInstitution_StaffAll]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	查询token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Get_VInstitution_StaffAll]

@systemId int,
@companyId varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


select * from V_Institution_Staff with(nolock) where systemid=@systemid and companyid=@companyid
select @errorCode=@@error
if (@errorCode=0)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Institution_Company]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	查找公司
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Institution_Company]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),

@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Institution_Company with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Institution_Company with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId
and CompanyId=case when isnull(@companyId,'')='' then CompanyId else @companyId end
and (CompanyName like '%'+@keyword+'%' or Phone like '%'+@keyword+'%' or Email like '%'+@keyword+'%')
order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
select @errorCode=0,@ErrorMsg='成功'
else
select @errorCode=40125,@ErrorMsg='SQL查询错误'





GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Institution_Department]

@systemId int,
@companyId varchar(19),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),

@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Institution_Department with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Institution_Department with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (DepartmentId like '%'+@keyword+'%' or DepartmentName like '%'+@keyword+'%')

order by sortpath asc, sortid asc


select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='成功'
else
	select @errorCode=40125,@ErrorMsg='SQL查询错误'






GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Institution_Position]

@systemId int,
@companyId varchar(19),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Institution_Position with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Institution_Position with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (PositionId like '%'+@keyword+'%' or PositionName like '%'+@keyword+'%')

order by CreateDate asc


select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='成功'
else
	select @errorCode=40125,@ErrorMsg='SQL查询错误'







GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Institution_Staff]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@departmentId varchar(20),
@positionId varchar(20),
@storeId varchar(20),
@warehouseId varchar(20),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Institution_Staff with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''


select top 1000 * from Ld_Institution_Staff with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and isnull(DepartmentId,'') = case when isnull(@departmentId,'')='' then isnull(DepartmentId,'') else @departmentId end
and isnull(PositionId,'') = case when isnull(@positionId,'')='' then isnull(PositionId,'') else @positionId end
and isnull(StoreId,'') = case when isnull(@storeId,'')='' then isnull(StoreId,'') else @storeId end
and isnull(WarehouseId,'') = case when isnull(@warehouseId,'')='' then isnull(WarehouseId,'') else @warehouseId end
and (StaffId like '%'+@keyword+'%' or StaffName like '%'+@keyword+'%' or NickName like '%'+@keyword+'%' or Identification like '%'+@keyword+'%' or Phone like '%'+@keyword+'%')
order by CreateDate asc


select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='成功'
else
	select @errorCode=40125,@ErrorMsg='SQL查询错误'









GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Institution_Store]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Institution_Store with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Institution_Store with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (StoreId like '%'+@keyword+'%' or StoreName like '%'+@keyword+'%' or Tel like '%'+@keyword+'%' or Address like '%'+@keyword+'%')
order by CreateDate asc


select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='成功'
else
	select @errorCode=40125,@ErrorMsg='SQL查询错误'








GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Member_Account]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Member_Account]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@rankId varchar(20),
@delete varchar(8),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Member_Account with(nolock) 
where CreateDate is not null and IsDel=case when isnull(@delete,'')='' then IsDel else @delete end 
order by CreateDate asc

if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Member_Account with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and RankID=case when isnull(@rankId,'')='' then RankID else @rankId end
and IsDel=case when isnull(@delete,'')='' then IsDel else @delete end 
and (MemberId like '%'+@keyword+'%' or Phone like '%'+@keyword+'%'or Email like '%'+@keyword+'%')
order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='ok'
else
	select @errorCode=40125,@ErrorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Member_Rank]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@rankId varchar(20),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Member_Rank with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Member_Rank with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (RankID like '%'+@keyword+'%' or RankName like '%'+@keyword+'%')
order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='ok'
else
	select @errorCode=40125,@ErrorMsg='error'







GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Sys_InterfaceAccount]

@systemId int,
@companyId varchar(19),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'


if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Sys_InterfaceAccount with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 1000 * from Ld_Sys_InterfaceAccount with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (Account like '%'+@keyword+'%' or AppID like '%'+@keyword+'%')

order by CreateDate asc


select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='成功'
else
	select @errorCode=40125,@ErrorMsg='SQL查询错误'








GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Sys_Operator]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),

@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@companyId,'')='')
set @companyId='sys'

if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from v_sys_operator with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 200 * from v_sys_operator with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (staffid like '%'+@keyword+'%' or staffname like '%'+@keyword+'%' or roleid like '%'+@keyword+'%' or rolename like '%'+@keyword+'%' or phone like '%'+@keyword+'%')
order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
select @errorCode=0,@ErrorMsg='ok'
else
select @errorCode=40125,@ErrorMsg='error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-07-07
-- Description:	搜索系统登录日志
-- =============================================
CREATE PROCEDURE [dbo].[SP_Search_Sys_Role]

@systemId int,
@companyId varchar(20),
@startTime varchar(20),
@endTime varchar(20),
@keyword nvarchar(20),

@errorCode int output,
@errorMsg nvarchar(200) output

AS


set @errorCode=-1
set @errorMsg='fail'

if (isnull(@companyId,'')='')
set @companyId='sys'

if(isnull(@startTime,'')='')
select top 1 @startTime=CreateDate from Ld_Sys_Role with(nolock) where CreateDate is not null order by CreateDate asc
if (isnull(@endTime,'')='')
set @endTime=getdate()
if (isnull(@keyword,'')='')
set @keyword=''

select top 200 * from Ld_Sys_Role with(nolock) where convert(varchar(10),CreateDate,120) between convert(varchar(10),cast(@startTime as datetime),120) and convert(varchar(10),cast(@endTime as datetime),120)
and SystemId=@systemId and CompanyId=@companyId
and (RoleId like '%'+@keyword+'%' or RoleName like '%'+@keyword+'%' or Remark like '%'+@keyword+'%')
order by CreateDate desc

select @errorCode=@@ERROR
if (@errorCode=0)
	select @errorCode=0,@ErrorMsg='ok'
else
	select @errorCode=40125,@ErrorMsg='error'





GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_Company]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_Company]

@systemId int,
@companyId varchar(20),
@companyName nvarchar(100),
@nickName nvarchar(20),
@tel varchar(20),
@fax varchar(20),
@phone varchar(20),
@email varchar(50),
@address nvarchar(250),
@description nvarchar(200),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Institution_Company 
		set CompanyName=@companyName,
		    NickName=@nickName,
			Tel=@tel,
			Fax=@fax,
			Phone=@phone,
			Email=@email,
			Address=@address,
			Description=@description
		where SystemID=@systemId and CompanyID=@companyId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	编辑部门基本信息
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_Department]

@systemId int,
@companyId varchar(20),
@departmentId varchar(20),
@departmentName nvarchar(50),
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'


--验证部分编号是否存在
if not exists(select * from Ld_Institution_Department with(nolock) where SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId)
begin
	select @errorCode=100012,@errorMsg='department id invalid！'
	return
end
--验证部门名称是否存在
if exists(select * from Ld_Institution_Department with(nolock) where SystemId=@systemId and CompanyId=@companyId and DepartmentId<>@departmentId and DepartmentName=@departmentName)
begin
	select @errorCode=100012,@errorMsg='department name exists！'
	return
end
--验证部门状态
if (@state=0)
begin
	--判断是否有下级部分
	if exists(select SystemId from Ld_Institution_Department where SystemId=@SystemId and CompanyId=@companyId and ParentId=@departmentId)
	begin
		select @errorcode=40121,@errorMsg='部门下级还有部门请先开启使用状态！'
		return
	end
	--判断是否有员工使用
	if exists(select * from Ld_Institution_Staff where SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId)
	begin
		select @errorCode=100012,@errorMsg='部门已使用必须是启用状态！'
		return
	end
end





--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新角色状态
		UPDATE Ld_Institution_Department 
		SET DepartmentName=@departmentName,
		    Description=@description,
		    State=@state
		WHERE SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_DepartmentState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	变更部门状态
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_DepartmentState]

@systemId int,
@companyId varchar(20),
@departmentId varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'


--验证部分编号是否存在
if not exists(select * from Ld_Institution_Department with(nolock) where SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId)
begin
	select @errorCode=100012,@errorMsg='department id invalid！'
	return
end
--验证部门是否有员工使用
if (@state=0)
begin
	--判断是否有下级部分
	if exists(select SystemId from Ld_Institution_Department where SystemId=@SystemId and CompanyId=@companyId and ParentId=@departmentId)
	begin
		select @errorcode=40121,@errorMsg='部门下级还有部门请先开启使用状态！'
		return
	end
	--判断是否有员工使用
	if exists(select * from Ld_Institution_Staff where SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId)
	begin
		select @errorCode=100012,@errorMsg='部门已使用必须是启用状态！'
		return
	end
end

--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新角色状态
		UPDATE Ld_Institution_Department 
		SET State=@state
		WHERE SystemId=@systemId and CompanyId=@companyId and DepartmentId=@departmentId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END










GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_Position]

@systemId int,
@companyId varchar(20),
@positionId varchar(20),
@positionName nvarchar(20),
@description nvarchar(200),
@sort int,
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId)
begin
	select @errorCode=40123,@errorMsg='职位编号不存在！'
	return
end

if exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID<>@positionId and PositionName=@positionName)
begin
	select @errorCode=40123,@errorMsg='职位名称已存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	BEGIN TRY
		--初始化公司帐号
		update Ld_Institution_Position
		set PositionName=@PositionName,
		    Description=@Description,
			Sort=@Sort,
			State=@State
        where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end


GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_PositionState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-19
-- Description:	公司职位新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_PositionState]

@systemId int,
@companyId varchar(20),
@positionId varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId)
begin
	select @errorCode=40123,@errorMsg='职位编号不存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	BEGIN TRY
		--初始化公司帐号
		update Ld_Institution_Position
		set State=@State
        where SystemID=@systemId and CompanyID=@companyId and PositionID=@positionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=-2,@errorMsg=@tranErrorMsg
		end


GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_Staff] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@StaffID varchar(20),
@StaffName nvarchar(20),
@UserName nvarchar(20),
@Password varchar(32),
@NickName nvarchar(20),
@HeadImgUrl varchar(250),
@Name nvarchar(20),
@Sex int,
@BirthDate datetime,
@BirthPlace nvarchar(250),
@Identification varchar(20),
@Education nvarchar(20),
@Phone varchar(20),
@QQ varchar(20),
@Weixin varchar(32),
@Email varchar(50),
@Address varchar(250),
@Wages decimal(18,2),
@Probation int,
@StartWorkDate datetime,
@EndWorkDate datetime,
@SignContractDate datetime,
@ExpirationContractDate datetime,
@DepartmentID varchar(20),
@PositionID varchar(20),
@StoreID varchar(20),
@WarehouseID varchar(20),
@Description nvarchar(400),
@State bit,                 
@errorCode int output,         
@errorMsg nvarchar(200) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'

if not exists(select * from Ld_Institution_Staff where SystemID=@systemId and CompanyID=@companyId and StaffID=@StaffID)
begin
	select @errorCode=40123,@errorMsg='员工工号不存在！'
	return
end


declare @DepartmentName nvarchar(50)
declare @PositionName nvarchar(50)
declare @StoreName nvarchar(50)
declare @WarehouseName nvarchar(50)

select @DepartmentName=DepartmentName from Ld_Institution_Department where SystemID=@systemId and CompanyID=@companyId and DepartmentID=@DepartmentID
select @PositionName=PositionName from Ld_Institution_Position where SystemID=@systemId and CompanyID=@companyId and PositionID=@PositionID
select @StoreName=StoreName from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and StoreID=@StoreID
select @WarehouseName=WarehouseName from Ld_Institution_Warehouse where SystemID=@systemId and CompanyID=@companyId and WarehouseID=@WarehouseID

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入网点
		UPDATE [dbo].[Ld_Institution_Staff]
			SET [StaffName] = @StaffName
				,[UserName] = @UserName
				,[Password] = @Password
				,[NickName] = @NickName
				,[HeadImgUrl] = @HeadImgUrl
				,[Name] = @Name
				,[Sex] = @Sex
				,[BirthDate] = @BirthDate
				,[BirthPlace] = @BirthPlace
				,[Identification] = @Identification
				,[Education] = @Education
				,[Phone] = @Phone
				,[QQ] = @QQ
				,[Weixin] = @Weixin
				,[Email] = @Email
				,[Address] = @Address
				,[Wages] = @Wages
				,[Probation] = @Probation
				,[StartWorkDate] = @StartWorkDate
				,[EndWorkDate] = @EndWorkDate
				,[SignContractDate] = @SignContractDate
				,[ExpirationContractDate] = @ExpirationContractDate
				,[DepartmentID] = @DepartmentID
				,[DepartmentName] = @DepartmentName
				,[PositionID] = @PositionID
				,[PositionName] = @PositionName
				,[StoreID] = @StoreID
				,[StoreName] = @StoreName
				,[WarehouseID] = @WarehouseID
				,[WarehouseName] = @WarehouseName
				,[Description] = @Description
				,[State] = @State
			WHERE SystemID=@systemId and CompanyID=@companyId and StaffID=@StaffID
			select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_StaffPassword]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_StaffPassword] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@staffID varchar(20),          
@password varchar(32),                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Staff where SystemID=@systemId and CompanyID=@companyId and StaffID=@staffID)
begin
	select @errorCode=40123,@errorMsg='员工工号不存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --更新员工状态
		update Ld_Institution_Staff set Password=@Password where SystemID=@systemId and CompanyID=@companyId and StaffID=@staffID
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_StaffState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_StaffState] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@staffID varchar(20),          
@State bit,                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Staff where SystemID=@systemId and CompanyID=@companyId and StaffID=@staffID)
begin
	select @errorCode=40123,@errorMsg='员工工号不存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --更新员工状态
		update Ld_Institution_Staff set State=@State where SystemID=@systemId and CompanyID=@companyId and StaffID=@staffID
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_Store] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@storeId varchar(20),          --网点编号
@storeName nvarchar(100),
@Logo nvarchar(250),
@Contacts nvarchar(10),
@tel varchar(20),
@fax varchar(20),
@phone varchar(20),
@email nvarchar(100),
@ProvinceID int,
@CityID int,
@AreaID int,
@Address nvarchar(250),
@Keyword nvarchar(200),
@description nvarchar(800),
@StartTime datetime,
@EndTime datetime,
@Push bit,
@Sort bit,
@State bit,                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'


if exists(select * from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and storeID<>@storeId and storeName=@storeName)
begin
	select @errorCode=40123,@errorMsg='网点名称已存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入网点
		update Ld_Institution_Store
		set StoreName=@StoreName,
		    Logo=@Logo,
			Contacts=@Contacts,
			Tel=@tel,
			Fax=@fax,
			Phone=@phone,
			Email=@email,
			ProvinceID=@ProvinceID,
			CityID=@CityID,
			AreaID=@AreaID,
			Address=@Address,
			Keyword=@Keyword,
			Description=@description,
			StartTime=@StartTime,
			EndTime=@EndTime,
			Push=@Push,
			Sort=@Sort,
			State=@State
		where SystemID=@systemId and CompanyID=@companyId and storeID=@storeId
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Institution_StoreState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Institution_StoreState] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@storeId varchar(20),          --网点编号
@State bit,                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Institution_Store where SystemID=@systemId and CompanyID=@companyId and storeID=@storeId)
begin
	select @errorCode=40123,@errorMsg='网点名称不存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --写入网点
		update Ld_Institution_Store set State=@State where SystemID=@systemId and CompanyID=@companyId and StoreID=@storeId
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Member_AccountDelete]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Member_AccountDelete]

@systemId int,
@companyId varchar(20),
@memberId varchar(20),
@delete bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'



if not exists(select * from Ld_Member_Account where SystemID=@systemId and CompanyID=@companyId and MemberID=@MemberID)
begin
	select @errorCode=41021,@errorMsg='会员ID不存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级状态
		UPDATE Ld_Member_Account SET IsDel=@delete WHERE SystemID=@systemId and CompanyID=@companyId and MemberID=@MemberID
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end






GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Member_AccountPassword]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2016-08-29
-- Description:	新增网点
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Member_AccountPassword] 

@systemId int,                 --系统编号
@companyId varchar(20),        --公司编号
@memberId varchar(20),          
@password varchar(32),                    
@errorCode int output,         
@errorMsg nvarchar(180) output 


AS

select @errorCode=-1
select @errorMsg='FAIL'


if not exists(select * from Ld_Member_Account where SystemID=@systemId and CompanyID=@companyId and MemberId=@memberId)
begin
	select @errorCode=40123,@errorMsg='员工工号不存在！'
	return
end

--开始事务
BEGIN TRAN Tran_Add    
    declare @tranErrorCode int,@tranErrorMsg nvarchar(200)
	select @tranErrorCode=0,@tranErrorMsg='ok'
	BEGIN TRY
	    --更新员工状态
		update Ld_Member_Account set Password=@Password where SystemID=@systemId and CompanyID=@companyId and MemberId=@memberId
		select @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @errorCode=0,@errorMsg='OK'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
	END










GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Member_AccountState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Member_AccountState]

@systemId int,
@companyId varchar(20),
@MemberID varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'



if not exists(select * from Ld_Member_Account where SystemID=@systemId and CompanyID=@companyId and MemberID=@MemberID)
begin
	select @errorCode=41021,@errorMsg='会员ID不存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级状态
		UPDATE Ld_Member_Account SET State=@State WHERE SystemID=@systemId and CompanyID=@companyId and MemberID=@MemberID
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end





GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Member_Rank]

@systemId int,
@companyId varchar(20),
@rankId varchar(20),
@RankName nvarchar(20),
@MaxPoints int,
@Discount int,
@ShowPrice int,
@Remark nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


if (len(@RankID)<>2)
begin
	select @errorCode=41021,@errorMsg='会员等级编号必须是2位0-9数字组成的字符串！'
	return
end

if not exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID=@rankId)
begin
	select @errorCode=41021,@errorMsg='会员等级编号不存在！'
	return
end

if exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID<>@rankId and RankName=@RankName)
begin
	select @errorCode=41021,@errorMsg='会员等级名称不能重复！'
	return
end

declare @MinPoints int
declare @SpecialRank int
select @MinPoints=MinPoints,@SpecialRank=SpecialRank from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID=@rankId
if (@MinPoints>=@MaxPoints)
begin
	select @errorCode=41021,@errorMsg='最大积分必须大于最小积分！'
	return
end

declare @subordinateMaxPoints int
select @subordinateMaxPoints=MaxPoints from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and SpecialRank=@SpecialRank+1
if (isnull(@subordinateMaxPoints,0)>0 and @MaxPoints>=@subordinateMaxPoints)
begin
	select @errorCode=41021,@errorMsg='最大积分不能大于下级最大积分！'
	return
end


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级
		UPDATE Ld_Member_Rank
		SET RankName=@RankName,
			MaxPoints=@MaxPoints,
			Discount=@Discount,
			ShowPrice=@ShowPrice,
			Remark=@Remark,
			State=@State
		WHERE SystemID=@systemId and CompanyID=@companyId and RankID=@rankId
		set @tranErrorCode=@tranErrorCode+@@ERROR

		if (isnull(@subordinateMaxPoints,0)>0)
		begin
			UPDATE Ld_Member_Rank SET MinPoints=@MaxPoints where SystemID=@systemId and CompanyID=@companyId and SpecialRank=@SpecialRank+1
			set @tranErrorCode=@tranErrorCode+@@ERROR
		end

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Member_RankState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Member_RankState]

@systemId int,
@companyId varchar(20),
@rankId varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


if (len(@RankID)<>2)
begin
	select @errorCode=41021,@errorMsg='会员等级编号必须是2位0-9数字组成的字符串！'
	return
end

if not exists(select * from Ld_Member_Rank where SystemID=@systemId and CompanyID=@companyId and RankID=@rankId)
begin
	select @errorCode=41021,@errorMsg='会员等级编号不存在！'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新会员等级状态
		UPDATE Ld_Member_Rank SET State=@State WHERE SystemID=@systemId and CompanyID=@companyId and RankID=@rankId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_AccessCorsHost]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_AccessCorsHost]

@systemId int,
@WebHost varchar(250),
@Remark nvarchar(400),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
	    update Ld_Sys_AccessCorsHost
		set Remark=@Remark,
		    State=@state
		where SystemID=@systemId and WebHost=@WebHost
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Code]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Code]

@systemId int,
@systemName nvarchar(50),
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_Code set SystemName=@systemName,Description=@description,State=@state 
		where SystemID=@systemId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_CodeState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_CodeState]

@systemId int,
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_Code set State=@state where SystemID=@systemId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Config]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-02-03
-- Description:	查询系统配置
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Config]

@systemId int,
@companyId varchar(20),
@Title nvarchar(200),
@Keyword nvarchar(200),
@Description nvarchar(400),
@HomeUrl nvarchar(250),
@StyleSrc nvarchar(200),
@UploadRoot nvarchar(50),
@Copyright nvarchar(250),
@IcpNumber nvarchar(50),
@StatisticsCode nvarchar(800),
@IsLoginIpAddress bit,
@LoginIpAddressWhiteList nvarchar(1000),
@MaxLoginFail int,
@EmailSendPattern nvarchar(50),
@EmailHost nvarchar(50),
@EmailPort int,
@EmailName nvarchar(100),
@EmailPassword nvarchar(32),
@EmailAddress nvarchar(100),
@errorCode int output,
@errorMsg nvarchar(200) output

AS
set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		UPDATE Ld_Sys_Config
		  SET SystemID = @SystemID,
			  CompanyID = @CompanyID,
			  Title = @Title,
			  Keyword = @Keyword,
			  Description = @Description,
			  HomeUrl = @HomeUrl,
			  StyleSrc = @StyleSrc, 
			  UploadRoot = @UploadRoot, 
			  Copyright = @Copyright,
			  IcpNumber = @IcpNumber, 
			  StatisticsCode = @StatisticsCode, 
			  IsLoginIpAddress = @IsLoginIpAddress,
			  LoginIpAddressWhiteList = @LoginIpAddressWhiteList,
			  MaxLoginFail = @MaxLoginFail,
			  EmailSendPattern = @EmailSendPattern,
			  EmailHost = @EmailHost, 
			  EmailPort = @EmailPort,
			  EmailName = @EmailName, 
			  EmailPassword = @EmailPassword, 
			  EmailAddress = @EmailAddress
		 WHERE SystemID=@systemId and CompanyID=@companyId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end



GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_ConfigShielding]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-02-03
-- Description:	查询系统配置
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_ConfigShielding]

@systemId int,
@companyId varchar(20),
@shielding nvarchar(1000),
@errorCode int output,
@errorMsg nvarchar(200) output

AS
set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_Config set Shielding=@Shielding where SystemID=@systemId and CompanyID=@companyId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end


GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Function]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	角色状态变更
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Function]

@functionId varchar(19),
@FunctionName nvarchar(50),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0


if (isnull(@functionId,'')='')
begin
	select @errorCode=100012,@errorMsg='function id not empty'
	return
end


if (@functionId='000000')
begin
	select @errorCode=100012,@errorMsg='初始化所有者功能不可以编辑'
	return
end


--验证角色是否存在
if not exists(select * from Ld_Sys_Function with(nolock) where functionId=@functionId)
begin
	select @errorCode=100012,@errorMsg='function id invalid'
	return
end



--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新角色状态
		UPDATE Ld_Sys_Function 
		SET FunctionName=@FunctionName,
		    [State]=@state
		WHERE functionId=@functionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END








GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_FunctionState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	功能状态变更
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_FunctionState]

@functionId varchar(19),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0

if (isnull(@functionId,'')='')
begin
	select @errorCode=100012,@errorMsg='function id not empty'
	return
end


if (@functionId='000000')
begin
	select @errorCode=100012,@errorMsg='初始化所有者功能不可以停用'
	return
end

--验证角色是否存在
if not exists(select * from Ld_Sys_Function with(nolock) where functionId=@functionId)
begin
	select @errorCode=100012,@errorMsg='function id invalid'
	return
end



--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新功能状态
		UPDATE Ld_Sys_Function SET [State]=@state WHERE functionId=@functionId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccessWhiteList]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@ipAddress varchar(20),
@classId int,
@className nvarchar(20),
@remark nvarchar(400),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccessWhiteList
		set ClassID=@classId,
		    ClassName=@className,
			Remark=@remark,
			State=@state
        where SystemID=@systemId and CompanyID=@companyId and Account=@account and IpAddress=@ipAddress
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccount]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@password varchar(32),
@isWcf bit,
@isWeb bit,
@isApi bit,
@isCors bit,
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --新增系统接口帐号
		update Ld_Sys_InterfaceAccount
		set Password=@password,
		    IsWcf=@isWcf,
		    IsWeb=@isWeb,
			IsApi=@isApi,
			IsCors=@isCors,
			Description=@description,
			State=@state
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccountAppKey]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccountAppKey]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

declare @AppKey varchar(32)
set @AppKey=dbo.fn_get_random_string(32)

BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccount
		set AppKey=@AppKey
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccountAppSecret]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccountAppSecret]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

declare @AppSecret varchar(32)
set @AppSecret=dbo.fn_get_random_string(32)

BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccount
		set AppSecret=@AppSecret
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccountDel]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccountDel]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@isDel bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccount
		set IsDel=@isDel
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccountPassword]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccountPassword]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@password varchar(32),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccount
		set Password=@password
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_InterfaceAccountState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统接口帐号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_InterfaceAccountState]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'



BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_InterfaceAccount
		set State=@state
        where SystemID=@systemId and CompanyID=@companyId and Account=@account 
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	编辑操作员
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Operator]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@roleId nvarchar(10),
@remark nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output


AS

--初始化参数
select @errorcode=-1
select @errorMsg='fail'
declare @totalrow int=0

--验证角色是否正确
if not exists(select * from Ld_Sys_Role with(nolock) where systemid=@systemid and CompanyId=@companyId and roleid=@roleid)
begin
	select @errorcode=400004,@errorMsg='角色编号不存在'
	return
end

--验证员工工号是否存在
if not exists(select * from Ld_Institution_Staff with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=400154,@errorMsg='员工ID不存在'
	return
end

--验证员工工号是否存在
if not exists(select * from Ld_Sys_Operator with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=400154,@errorMsg='操作员ID不存在'
	return
end

declare @isInit bit
declare @isRoleId varchar(20)
select @isInit=IsInit from Ld_Institution_Staff with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
select @isRoleId=RoleId from Ld_Sys_OperatorRole with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
if (isnull(@isInit,0)=1 and isnull(@state,0)=0)
begin
	select @errorcode=400112,@errorMsg='系统初始化超级管理员不可停用！'
	return
end

if (isnull(@isInit,0)=1 and @isRoleId<>@roleId)
begin
	select @errorcode=400112,@errorMsg='系统初始化超级管理员不可变更角色！'
	return
end


--开始事务
begin tran tran_add    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
	    --更新员工资料
		update Ld_Sys_Operator set Remark=@remark,State=@state where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
        set @tranErrorCode=@tranErrorCode+@@ERROR
		--更新操作员角色关系
		update Ld_Sys_OperatorRole set roleid=@roleid where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
		set @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_OperatorPassword]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	编辑操作员
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_OperatorPassword]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@password nvarchar(32),
@errorCode int output,
@errorMsg nvarchar(200) output


AS

--初始化参数
select @errorcode=-1
select @errorMsg='fail'
declare @totalrow int=0


--开始事务
begin tran tran_add    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
	    --更新员工资料
		update Ld_Institution_Staff set Password=@password where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
        set @tranErrorCode=@tranErrorCode+@@ERROR
	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end










GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_OperatorRole]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	操作员变更角色权限
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_OperatorRole]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@roleId nvarchar(10),
@errorCode int output,
@errorMsg nvarchar(200) output


AS

--初始化参数
select @errorcode=-1
select @errorMsg='fail'
declare @totalrow int=0

--验证角色是否正确
if not exists(select * from Ld_Sys_Role with(nolock) where systemid=@systemid and CompanyId=@companyId and roleid=@roleid)
begin
	select @errorcode=400004,@errorMsg='角色编号不存在'
	return
end
--验证员工工号是否存在
if not exists(select * from Ld_Sys_Operator with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=400154,@errorMsg='操作员ID不存在'
	return
end


--开始事务
begin tran tran_add    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --更新操作员角色关系
		update Ld_Sys_OperatorRole set roleid=@roleid where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end








GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_OperatorState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	操作员变更状态
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_OperatorState]

@systemId int,
@companyId varchar(20),
@staffId varchar(20),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output


AS

--初始化参数
select @errorcode=-1
select @errorMsg='fail'
declare @totalrow int=0

--验证员工工号是否存在
if not exists(select * from Ld_Sys_Operator with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId)
begin
	select @errorcode=400154,@errorMsg='操作员ID不存在'
	return
end

declare @isInit bit
select @isInit=IsInit from Ld_Institution_Staff with(nolock) where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
if (isnull(@isInit,0)=1)
begin
	select @errorcode=400112,@errorMsg='系统初始化超级管理员不可停用！'
	return
end


--开始事务
begin tran tran_add    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	begin try
        --更新操作员角色关系
		update Ld_Sys_Operator set State=@State where systemid=@systemid and CompanyId=@companyId and StaffId=@staffId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	end try
	--事务异常
	begin catch
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	end catch

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end









GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	角色状态变更
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Role]

@systemId int,                 --系统号
@companyId varchar(20),
@roleId nvarchar(10),
@roleName nvarchar(20),
@functionId varchar(max),        --角色许可功能数组 000000,111111,222222
@remark nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0


--验证角色是否存在
if not exists(select * from Ld_Sys_Role with(nolock) where SystemId=@systemId and CompanyId=@companyId and RoleId=@RoleId)
begin
	select @errorCode=100012,@errorMsg='role id invalid'
	return
end

--验证角色是否存在
if exists(select * from Ld_Sys_Role with(nolock) where SystemId=@systemId and CompanyId=@companyId and RoleId<>@RoleId and RoleName=@roleName)
begin
	select @errorCode=100012,@errorMsg='role name exists'
	return
end

if (@roleId='2001')
begin
	select @errorCode=100012,@errorMsg='初始化角色不可编辑！'
	return
end



--判断功能号是否全部有效
declare @P int=dbo.fn_get_array_length(@FunctionId,',')
declare @arrFuncId varchar(max)=''
declare @arrTotal int = 0
while @arrTotal<@P
begin
    set @arrTotal=@arrTotal+1
	if (@arrFuncId='')
		set @arrFuncId=@arrFuncId+''''+dbo.fn_get_array_value(@functionId,',',@arrTotal)+''''
	else
		set @arrFuncId=@arrFuncId+','''+dbo.fn_get_array_value(@functionId,',',@arrTotal)+''''
end
declare @Y int=0
declare @CmdText nvarchar(max)='select count(*) from Ld_Sys_Function where FunctionId in ('+@arrFuncId+') and state=1 and IsDel=0'
declare @Tmp table(FunctionTotalRow int)
insert into @Tmp exec sp_executesql @CmdText 
select @Y=FunctionTotalRow from @Tmp
print @CmdText
print @Y
print @P
IF (@P<>@Y)
begin
	select @errorcode=4003,@errorMsg='select function id not exists'
	return
end

--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新角色状态
		UPDATE Ld_Sys_Role 
		SET RoleName=@roleName,
		    Remark=@Remark,
		    [State]=@state
		WHERE SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--清除角色功能
		delete Ld_Sys_RoleFunction where SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId
		SET @tranErrorCode=@tranErrorCode+@@ERROR

		--写入角色功能
		--declare @FunctionId nvarchar(1000) ='1,2,3,4,5,6,7,8,9'
		declare @i int=1
		declare @n int=dbo.fn_get_array_length(@FunctionId,',')
		WHILE @i<=@n
			BEGIN
			declare @MyFunctionId nvarchar(6)=dbo.fn_get_array_value(@FunctionId,',',@i)
			--print @MyFunctionId
			insert into Ld_Sys_RoleFunction (SystemId,CompanyId,RoleId,FunctionId)
			select @SystemId,@companyId,@RoleId,@MyFunctionId
			SET @i=@i+1
			END
        SET @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END







GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_RoleState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2016-12-20
-- Description:	角色状态变更
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_RoleState]

@systemId int,                 --系统号
@companyId varchar(20),
@roleId nvarchar(10),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'
declare @totalRow int=0

if (@RoleId='2001' and isnull(@state,0)=0)
begin
	select @errorcode=40121,@errorMsg='初始角色不能停用！'
	return
end

--验证公司是否存在
if not exists(select * from Ld_Sys_Role with(nolock) where SystemId=@systemId and CompanyId=@companyId and RoleId=@RoleId)
begin
	select @errorCode=100012,@errorMsg='role id invalid'
	return
end


--开始事务
BEGIN TRAN tranAdd    
    DECLARE @tranErrorCode INT    
    DECLARE @tranErrorMsg NVARCHAR(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --更新角色状态
		UPDATE Ld_Sys_Role SET [State]=@state WHERE SystemId=@SystemId and CompanyId=@companyId and RoleId=@RoleId
		SET @tranErrorCode=@tranErrorCode+@@ERROR
	END TRY
	--事务异常
	BEGIN CATCH
		SET @tranErrorCode=error_number()
		SET @tranErrorMsg= '错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

IF @tranErrorCode=0
	BEGIN
		COMMIT TRAN
		select @ErrorCode=0,@errorMsg='success'
	END
ELSE
	BEGIN
		ROLLBACK TRAN
		select @ErrorCode=-2,@errorMsg=@tranErrorMsg
	END






GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_Version]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_Version]

@versionId varchar(10),
@versionName nvarchar(50),
@marketPrice decimal(18,2),
@dealerPrice decimal(18,2),
@departmentTotalQuantity int,
@staffTotalQuantity int,
@storeTotalQuantity int,
@warehouseTotalQuantity int,
@description nvarchar(200),
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_Version 
		set VersionName=@VersionName,
		    MarketPrice=@MarketPrice,
			DealerPrice=@DealerPrice,
			DepartmentTotalQuantity=@DepartmentTotalQuantity,
			StaffTotalQuantity=@StaffTotalQuantity,
			StoreTotalQuantity=@StoreTotalQuantity,
			WarehouseTotalQuantity=@WarehouseTotalQuantity,
		    Description=@description,
			State=@state 
		where VersionID=@versionId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end




GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sys_VersionState]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	新增系统编号
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Sys_VersionState]

@versionId int,
@state bit,
@errorCode int output,
@errorMsg nvarchar(200) output
AS

set @errorCode=-1
set @errorMsg='fail'


--开始事务
BEGIN TRAN tranAdd    
    declare @tranErrorCode int    
    declare @tranErrorMsg nvarchar(200)
	set @tranErrorCode=0
	set @tranErrorMsg='ok'
	BEGIN TRY
        --系统操作员录入
		update Ld_Sys_Version set State=@state where VersionID=@VersionId
		set @tranErrorCode=@tranErrorCode+@@ERROR

	END TRY
	--事务异常
	BEGIN CATCH
		set @tranErrorCode=error_number()
		set @tranErrorMsg= '出现异常，错误编号：' + convert(varchar,error_number()) + ',错误消息：' + error_message()
	END CATCH

	if @tranErrorCode=0
		begin
			commit tran
			select @errorCode=0,@errorMsg='ok'
		end
	else
		begin
			rollback tran
			select @errorCode=@tranErrorCode,@errorMsg=@tranErrorMsg
		end





GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Institution_StaffLogin]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-27
-- Description:	公司登录、员工登录 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Institution_StaffLogin] 

@systemId int,                            --系统编号
@companyId varchar(19),                   --公司编号
@userName varchar(19),                    --员工编号
@password varchar(32),                    --登录密码
@errorCode int output,                    --错误代码
@errorMsg nvarchar(200) output            --错误信息


AS

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@companyId,'')='')
	set @companyId='sys'

--验证公司是否存在
if not exists(select * from Ld_Sys_Code with(nolock) where systemid=@systemid)
begin
	select @errorcode=4001,@errorMsg='系统编号不存在！'
	return
end

if not exists(select * from Ld_Institution_Staff with(nolock) where systemid=@systemid and companyid=@companyId and UserName=@userName)
begin
	select @errorcode=4001,@errorMsg='帐号不存在！'
	return
end

declare @staffPassword varchar(32)
declare @staffState bit
declare @staffIsDel bit

select @staffPassword=Password,@staffState=state,@staffIsDel=isdel from V_Sys_Operator with(nolock) 
where systemid=@systemid and companyid=@companyId  and UserName=@userName

if(isnull(@staffState,0)=0)
begin
	select @errorcode=4001,@errorMsg='操作员等审核！'
	return
end

if(isnull(@staffIsDel,0)=1)
begin
	select @errorcode=4001,@errorMsg='员工帐号已注销！'
	return
end

if (@staffPassword=@password)
	select @errorcode=0,@errorMsg='成功'
else
	select @errorcode=4001,@errorMsg='密码错误'





GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Member_AccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	验证系统token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Member_AccessToken]

@token varchar(64),
@timestamp int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=40002,@errorMsg='token not empty'
	return
end
if (isnull(@timestamp,0)<=0)
begin
	select @errorCode=40002,@errorMsg='timestamp invalid'
	return
end

if not exists(select SystemId from Ld_Member_AccessToken with(nolock) where Token=@token)
begin
	select @errorCode=40002,@errorMsg='token invalid'
	return
end

declare @expiresIn int
declare @createTimestamp int
declare @indexTimestamp int
set @indexTimestamp=@timestamp
select @expiresIn=ExpiresIn,@createTimestamp=CreateTimestamp from Ld_Member_AccessToken with(nolock) 
where Token=@token

--select @indexTimestamp,@createTimestamp,@expiresIn
if (isnull(@createTimestamp,0)=0)
begin
	select @errorCode=40002,@errorMsg='create timestamp error'
	return
end
if (isnull(@expiresIn,0)=0)
begin
	select @errorCode=40002,@errorMsg='expires in error'
	return
end

set @indexTimestamp=abs(isnull(@indexTimestamp,0))
set @createTimestamp=abs(isnull(@createTimestamp,0))
set @expiresIn=abs(isnull(@expiresIn,0))
--select @indexTimestamp-@createTimestamp
if ((@indexTimestamp-@createTimestamp)<@expiresIn)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='token expired'











GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Member_AccountLogin]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-27
-- Description:	会员登录
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Member_AccountLogin] 

@systemId int,                            --系统编号
@companyId varchar(20),                   --公司编号
@account varchar(20),                    --会员编号
@password varchar(32),                    --登录密码
@errorCode int output,                    --错误代码
@errorMsg nvarchar(200) output            --错误信息

AS

set @errorCode=-1
set @errorMsg='初始化'

--验证公司是否存在
if not exists(select * from Ld_Sys_Code with(nolock) where systemid=@systemid)
begin
	select @errorcode=4001,@errorMsg='系统编号'
	return
end

if not exists(select * from Ld_Member_Account with(nolock) where systemid=@systemid and CompanyId=@companyId and UserName=@account)
begin
	select @errorcode=4001,@errorMsg='会员帐号不存在'
	return
end

declare @companyState bit
declare @companyIsDel bit
declare @userPassword varchar(32)
declare @userState bit
declare @userIsDel bit

--查询公司状态
select @companyState=State,@companyIsDel=IsDal from Ld_Institution_Company with(nolock) where systemid=@systemid and CompanyId=@companyId
--查询会员状态
select @userPassword=Password,@userState=state,@userIsDel=IsDel from Ld_Member_Account with(nolock) where systemid=@systemid and CompanyId=@companyId and UserName=@account

if (isnull(@companyId,'')<>'sys')
begin
	if(isnull(@companyState,0)=0)
	begin
		select @errorcode=4001,@errorMsg='公司没审核'
		return
	end
	if(isnull(@companyIsDel,0)=1)
	begin
		select @errorcode=4001,@errorMsg='公司已注销'
		return
	end
end

if(isnull(@userState,0)=0)
begin
	select @errorcode=4001,@errorMsg='会员没审核'
	return
end

if(isnull(@userIsDel,0)=1)
begin
	select @errorcode=4001,@errorMsg='会员帐号已注销'
	return
end

if (@userPassword=@password)
	select @errorcode=0,@errorMsg='成功'
else
	select @errorcode=4001,@errorMsg='密码错误'





GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Member_RefreshToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	验证系统token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Member_RefreshToken]

@refreshToken varchar(64),
@timestamp int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@refreshToken,'')='')
begin
	select @errorCode=40002,@errorMsg='token not empty'
	return
end
if (isnull(@timestamp,0)<=0)
begin
	select @errorCode=40002,@errorMsg='timestamp invalid'
	return
end

if not exists(select * from Ld_Member_RefreshToken with(nolock) where RefreshToken=@refreshToken)
begin
	select @errorCode=40002,@errorMsg='token invalid'
	return
end

declare @state bit
declare @expiresIn int
declare @createTimestamp int
declare @indexTimestamp int
set @indexTimestamp=@timestamp
select @expiresIn=ExpiresIn,@createTimestamp=CreateTimestamp,@state=State from Ld_Member_RefreshToken with(nolock) where RefreshToken=@refreshToken

if (isnull(@state,0)=0)
begin
	select @errorCode=40002,@errorMsg='refresh token have been used'
	return
end

--select @indexTimestamp,@createTimestamp,@expiresIn
if (isnull(@createTimestamp,0)=0)
begin
	select @errorCode=40002,@errorMsg='create timestamp error'
	return
end
if (isnull(@expiresIn,0)=0)
begin
	select @errorCode=40002,@errorMsg='expires in error'
	return
end

set @indexTimestamp=abs(isnull(@indexTimestamp,0))
set @createTimestamp=abs(isnull(@createTimestamp,0))
set @expiresIn=abs(isnull(@expiresIn,0))
--select @indexTimestamp-@createTimestamp
if ((@indexTimestamp-@createTimestamp)<@expiresIn)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='token expired'












GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-29
-- Description:	验证系统token 已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccessToken]

@token varchar(128),
@timestamp int,
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@token,'')='')
begin
	select @errorCode=40002,@errorMsg='token not empty'
	return
end
if (isnull(@timestamp,0)<=0)
begin
	select @errorCode=40002,@errorMsg='timestamp invalid'
	return
end

if not exists(select SystemId from Ld_Sys_InterfaceAccessToken with(nolock) where Token=@token)
begin
	select @errorCode=40002,@errorMsg='token invalid'
	return
end

declare @expiresIn int
declare @createTimestamp int
declare @indexTimestamp int
set @indexTimestamp=@timestamp
select @expiresIn=ExpiresIn,@createTimestamp=CreateTimestamp from Ld_Sys_InterfaceAccessToken with(nolock) 
where Token=@token

--select @indexTimestamp,@createTimestamp,@expiresIn
if (isnull(@createTimestamp,0)=0)
begin
	select @errorCode=40002,@errorMsg='create timestamp error'
	return
end
if (isnull(@expiresIn,0)=0)
begin
	select @errorCode=40002,@errorMsg='expires in error'
	return
end

set @indexTimestamp=abs(isnull(@indexTimestamp,0))
set @createTimestamp=abs(isnull(@createTimestamp,0))
set @expiresIn=abs(isnull(@expiresIn,0))
--select @indexTimestamp-@createTimestamp
if ((@indexTimestamp-@createTimestamp)<@expiresIn)
	select @errorCode=0,@errorMsg='success'
else
	select @errorCode=40002,@errorMsg='token expired'










GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccessWhiteList]

@systemId int,
@companyId varchar(20),
@account varchar(20),
@ipAddress varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

declare @state bit
select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress='*'
if (isnull(@state,0)=1)
begin
	select @errorCode=0,@errorMsg='ok'
	return
end

select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress=@ipAddress
if (isnull(@state,0)=0)
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=0,@errorMsg='verify fail'



GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccessWhiteListByAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccessWhiteListByAccessToken]

@systemId int,
@accessToken varchar(128),
@ipAddress varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

if not exists(select * from Ld_Sys_InterfaceAccessToken where Token=@accessToken)
begin
	select @errorCode=40123,@errorMsg='token invalid！'
	return
end

declare @appId varchar(16)
select @appId=AppID from Ld_Sys_InterfaceAccessToken where Token=@accessToken

declare @companyId varchar(20)
declare @account varchar(20)
select @companyId=companyid,@account=Account from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId


declare @state bit
select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress='*'
if (isnull(@state,0)=1)
begin
	select @errorCode=0,@errorMsg='ok'
	return
end

select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress=@ipAddress
if (isnull(@state,0)=0)
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=0,@errorMsg='verify fail'



GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccessWhiteListByAppid]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		小草
-- Create date: 2019-01-27
-- Description:	系统接口帐号白名单新增
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccessWhiteListByAppid]

@systemId int,
@appId varchar(16),
@ipAddress varchar(20),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='fail'

if not exists(select * from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId)
begin
	select @errorCode=40123,@errorMsg='appid invalid！'
	return
end

declare @companyId varchar(20)
declare @account varchar(20)
select @companyId=companyid,@account=Account from Ld_Sys_InterfaceAccount where SystemID=@systemId and AppID=@appId

declare @state bit
select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress='*' and state=1
if (isnull(@state,0)=1)
begin
	select @errorCode=0,@errorMsg='ok'
	return
end
select @state=State from Ld_Sys_InterfaceAccessWhiteList where SystemID=@systemId and CompanyID=@companyId and Account=@account and ipAddress=@ipAddress and state=1
if (isnull(@state,0)=1)
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=511020,@errorMsg='verify ip white list fail'



GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-09
-- Description:	验证user name  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccount]

@systemId int,                     --系统编号
@companyId varchar(20),            --公司编号
@account varchar(20),              --接口帐号
@password varchar(32),             --接口密码
@classId int,                      --请求类型 1：WCF服务，2：WEB服务
@errorCode int output,             --返回结果代码 0：验证通过，无错误
@errorMsg nvarchar(200) output     --返回结果说明 

AS

set @errorCode=-1
set @errorMsg='初始化'

if (isnull(@systemId,'')='')
begin
	select @errorCode=40001,@errorMsg='system id not empty'
	return
end

if (isnull(@companyId,'')='')
begin
	select @errorCode=40001,@errorMsg='company id not empty'
	return
end

if (isnull(@account,'')='')
begin
	select @errorCode=40001,@errorMsg='user name not empty'
	return
end

if (isnull(@password,'')='')
begin
	select @errorCode=40002,@errorMsg='password not empty'
	return
end

declare @myAccount varchar(20)
declare @myPassword varchar(32)
declare @myState bit
declare @myIsWcf bit
declare @myIsWeb bit


select @myAccount=account,@myPassword=password,@myState=State,@myIsWcf=IsWcf,@myIsWeb=IsWeb from Ld_Sys_InterfaceAccount with(nolock) 
where systemid=@systemid and companyid=@companyId and Account=@account

if (isnull(@myAccount,'')='')
begin
	select @errorCode=40003,@errorMsg='account invalid'
	return
end

if (isnull(@myState,0)=0)
begin
	select @errorCode=40004,@errorMsg='account not audited'
	return
end

if (isnull(@classId,0)=1)
begin
	if (isnull(@myIsWcf,0)=0)
	begin
		select @errorCode=40004,@errorMsg='account not wcf permission'
		return
	end
end

if (isnull(@classId,0)=2)
begin
	if (isnull(@myIsWeb,0)=0)
	begin
		select @errorCode=40004,@errorMsg='account not web service permission'
		return
	end
end


if (isnull(@password,'')=@myPassword)
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=40003,@errorMsg='password error'






GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccountByAppid]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-09
-- Description:	验证appid  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccountByAppid]

@systemId int,
@appId varchar(20),
@appSecret varchar(32),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@appId,'')='')
begin
	select @errorCode=40001,@errorMsg='appid not empty'
	return
end

if (isnull(@appSecret,'')='')
begin
	select @errorCode=40002,@errorMsg='appsecret not empty'
	return
end


declare @myAppId varchar(16)
declare @myAppSecret varchar(32)
declare @myState bit
declare @myIsApi bit

select top 1 @myAppId=AppID,@myAppSecret=AppSecret,@myState=State,@myIsApi=IsApi from Ld_Sys_InterfaceAccount with(nolock) 
where systemid=@systemId and appid=@appId and isdel=0 order by createdate desc

--select * from Ld_Sys_InterfaceUser with(nolock)  where systemid=@systemid and companyid=@companyId and appid=@appId

if (isnull(@myAppId,'')='')
begin
	select @errorCode=40003,@errorMsg='appid invalid'
	return
end

if (isnull(@myState,0)=0)
begin
	select @errorCode=40004,@errorMsg='appid not audited'
	return
end

if (isnull(@myIsApi,0)=0)
begin
	select @errorCode=40004,@errorMsg='appid not permission'
	return
end

if (isnull(@appSecret,'')=@myAppSecret)
	select @errorCode=0,@errorMsg='ok'
else
	select @errorCode=40003,@errorMsg='appsecret invalid'





GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_InterfaceAccountByUuid]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-09
-- Description:	验证appid  已验证
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_InterfaceAccountByUuid]

@systemId int,
@uuid varchar(32),
@errorCode int output,
@errorMsg nvarchar(200) output

AS

set @errorCode=-1
set @errorMsg='初始化'


if (isnull(@uuid,'')='')
begin
	select @errorCode=40001,@errorMsg='appid not empty'
	return
end

declare @strUuid varchar(32)
declare @strState bit

select top 1 @strUuid=UuID,@strState=State from Ld_Sys_InterfaceAccount --with(nolock) 
where systemid=@systemId and UuID=@uuid and isdel=0 order by createdate desc


if (isnull(@strUuid,'')='')
begin
	select @errorCode=40003,@errorMsg='uuid invalid'
	return
end

if (isnull(@strState,0)=1)
	select @errorCode=0,@errorMsg='ok'
else
    select @errorCode=40004,@errorMsg='appid not audited'






GO
/****** Object:  StoredProcedure [dbo].[SP_Verify_Sys_OperatorPermission]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		小草
-- Create date: 2018-06-26
-- Description:	验证员工权限
-- =============================================
CREATE PROCEDURE [dbo].[SP_Verify_Sys_OperatorPermission]

@systemId int,                    --系统编号
@companyId varchar(20),           --公司编号
@staffId varchar(20),             --操作员ID
@functionId varchar(6),           --需要操作的功能编号
@errorCode int output,            --错误代码
@errorMsg nvarchar(200) output    --错误信息

AS

select @errorcode=-1
select @errorMsg='fail'

declare @myFunctionId nvarchar(6)='000000'

--判断帐号是否是超级管理员
if (LOWER(isnull(@companyId,''))='sys' and LOWER(isnull(@staffId,''))='sys')
begin
	select @errorCode=0,@errorMsg='ok'
	return
end

--判断帐号是否为操作员
if not exists(select * from Ld_Sys_Operator with(nolock) where SystemId=@SystemId and CompanyId=@companyId and staffId=@staffId)
begin
	select @errorCode=400125,@errorMsg='帐号不是系统操作员'
	return
end
else
begin
    declare @state bit=0
	declare @roleState bit=0
	declare @functionState bit=0

	if exists(select * from V_Sys_OperatorPermission where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId and FunctionId=@myFunctionId)
	begin
	    select @state=[state],@roleState=RoleState,@functionState=FunctionState from V_Sys_OperatorPermission with(nolock) 
		where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId and FunctionId=@myFunctionId
	end
	else
	begin
	    if not exists(select * from V_Sys_OperatorPermission with(nolock) where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId and FunctionId=@functionId)
		begin
			select @errorCode=400125,@errorMsg='操作员没有权限！'
			return
		end
	end

	select @state=[state],@roleState=RoleState,@functionState=FunctionState from V_Sys_OperatorPermission with(nolock) 
	where SystemId=@SystemId and CompanyId=@companyId and StaffId=@staffId and FunctionId=@functionId
	if (isnull(@state,0)=0)
	begin
		select @errorCode=400125,@errorMsg='操作员没审核'
		return
	end
	if (isnull(@roleState,0)=0)
	begin
		select @errorCode=400125,@errorMsg='角色已停用'
		return
	end
	if (isnull(@functionState,0)=0)
	begin
		select @errorCode=400125,@errorMsg='功能已停用'
		return
	end
	--验证通过
	if (@state=1 and @roleState=1 and @functionState=1)
	begin
		select @errorCode=0,@errorMsg='ok'
		return
	end
	else
	begin
		select @errorCode=400125,@errorMsg='fail'
		return
	end
end










GO
/****** Object:  UserDefinedFunction [dbo].[fn_get_array_length]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-05-21
-- Description:	计算出数组长度
-- =============================================

CREATE function [dbo].[fn_get_array_length]
(
  @str nvarchar(max),  --要分割的字符串
  @split varchar(10)   --分隔符号
)
returns int
as
begin
  declare @location int
  declare @start int
  declare @length int

  set @str=ltrim(rtrim(@str))
  set @location=charindex(@split,@str)
  set @length=1
  while @location<>0
  begin
    set @start=@location+1
    set @location=charindex(@split,@str,@start)
    set @length=@length+1
  end
  return @length
end






GO
/****** Object:  UserDefinedFunction [dbo].[fn_get_array_value]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-05-21
-- Description:	提取指定数组值
-- =============================================

CREATE function [dbo].[fn_get_array_value]
(
  @str nvarchar(max),  --要分割的字符串
  @split varchar(10),  --分隔符号
  @index int           --取第几个元素
)
returns varchar(5000)
as
begin
  declare @location int
  declare @start int
  declare @next int
  declare @seed int

  set @str=ltrim(rtrim(@str))
  set @start=1
  set @next=1
  set @seed=len(@split)
  
  set @location=charindex(@split,@str)
  while @location<>0 and @index>@next
  begin
    set @start=@location+@seed
    set @location=charindex(@split,@str,@start)
    set @next=@next+1
  end
  if @location =0 select @location =len(@str)+1 
  return substring(@str,@start,@location-@start)
end






GO
/****** Object:  UserDefinedFunction [dbo].[fn_get_random_int]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-09-15
-- Description:	随机生成数字字符串
-- =============================================
CREATE FUNCTION [dbo].[fn_get_random_int]
(
@length int
)
RETURNS varchar(19)
AS
BEGIN

    declare @str varchar(20)
    declare @randomStr bigint
	select @randomStr=floor(re*1000000000000000000) from V_Rand
    set @str= right('3000000000000000000'+cast(@randomStr as varchar(19)),19)


	RETURN left(@str,@length)

END



GO
/****** Object:  UserDefinedFunction [dbo].[fn_get_random_string]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-05-21
-- Description:	随机字符串（包括大小写字母、数字）
-- =============================================

CREATE function [dbo].[fn_get_random_string](@length int)
returns varchar(128)
begin
 DECLARE @RandomID varchar(256)
 DECLARE @counter smallint
 DECLARE @RandomNumber float
 DECLARE @RandomNumberInt tinyint
 DECLARE @CurrentCharacter varchar(1)
 DECLARE @ValidCharacters varchar(255)
 SET @ValidCharacters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'
 DECLARE @ValidCharactersLength int
 SET @ValidCharactersLength = len(@ValidCharacters)
 SET @CurrentCharacter = ''
 SET @RandomNumber = 0
 SET @RandomNumberInt = 0
 SET @RandomID = ''
 --SET NOCOUNT ON
 SET @counter = 1
 WHILE @counter < (@Length + 1)
 BEGIN
   select @RandomNumber = re from v_rand
   SET @RandomNumberInt = Convert(tinyint, ((@ValidCharactersLength -1) * @RandomNumber + 1))
   SELECT @CurrentCharacter = SUBSTRING(@ValidCharacters, @RandomNumberInt, 1)
   SET @counter = @counter + 1
   SET @RandomID = @RandomID + @CurrentCharacter
 END
 
 Return @RandomID
end








GO
/****** Object:  UserDefinedFunction [dbo].[fn_get_time_str]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_get_time_str]
(
@time datetime
)
RETURNS varchar(17)
AS
BEGIN

	declare @indexTime datetime
	if (isnull(@time,'')='')
	set @indexTime=getdate()
	else
	set @indexTime=@time
	declare @result varchar(17)
	set @result=replace(replace(replace(replace(CONVERT(varchar(100), @indexTime, 121),'-',''),' ',''),':',''),'.','')

	return @result

END



GO
/****** Object:  UserDefinedFunction [dbo].[fn_md5]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		小草
-- Create date: 2018-06-28
-- Description:	MD5加密
-- =============================================
CREATE FUNCTION [dbo].[fn_md5]
(
@str varchar(max)
)
RETURNS varchar(32)
AS
BEGIN

	RETURN substring(sys.fn_sqlvarbasetostr(HashBytes('MD5',@str)),3,32)

END



GO
/****** Object:  UserDefinedFunction [dbo].[fn_validate_temporary_table]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		小草
-- Create date: 2016-05-21
-- Description:	判断临时表是否在存在
-- =============================================
CREATE FUNCTION [dbo].[fn_validate_temporary_table]
(
@tableName nvarchar(100)
)
RETURNS bit
AS
BEGIN
    declare @result bit
    declare @MyCount int=0 
	select @MyCount=count(*) from tempdb..sysobjects where id=object_id('tempdb..#'+@TableName)
	if @MyCount=1
		select @result=1
	else
		select @result=0
	return @result
END





GO
/****** Object:  Table [dbo].[Ld_Basics_Media]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Basics_Media](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MediaID] [varchar](20) NOT NULL,
	[Title] [nvarchar](400) NULL,
	[Type] [varchar](100) NULL,
	[FileName] [nvarchar](250) NULL,
	[FileExtension] [varchar](20) NULL,
	[FileSize] [bigint] NULL,
	[Url] [nvarchar](250) NULL,
	[Src] [nvarchar](250) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Basics_Media] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Basics_MediaInterface]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Basics_MediaInterface](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MediaID] [varchar](20) NOT NULL,
	[AppID] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Ld_Basics_InterfaceMedia] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MediaID] ASC,
	[AppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Basics_MediaMember]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Basics_MediaMember](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MediaID] [varchar](20) NOT NULL,
	[MemberID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Ld_Basics_MemberMedia] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MemberID] ASC,
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Extend_Advertisement]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Extend_Advertisement](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[AdvertisementID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](400) NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Extend_Advertisement] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[AdvertisementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Extend_AdvertisementDetails]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Extend_AdvertisementDetails](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[DetailsID] [varchar](20) NOT NULL,
	[AdvertisementID] [varchar](20) NULL,
	[Title] [nvarchar](100) NULL,
	[Remark] [nvarchar](400) NULL,
	[MediaID] [varchar](20) NULL,
	[MediaType] [varchar](50) NULL,
	[MediaPath] [varchar](250) NULL,
	[Url] [varchar](250) NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Extend_AdvertisementDetails] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[DetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Extend_Link]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Extend_Link](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[LinkID] [varchar](20) NOT NULL,
	[GroupID] [varchar](20) NULL,
	[GroupName] [nvarchar](20) NULL,
	[TypeID] [tinyint] NULL,
	[TypeName] [nvarchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[Logo] [varchar](250) NULL,
	[Url] [nvarchar](250) NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Extend_Link] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[LinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Extend_LinkGroup]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Extend_LinkGroup](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[GroupID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](400) NULL,
	[Sort] [int] NULL,
	[IsExternal] [bit] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Extend_LinkGroup] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Extend_SearchKeyword]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Extend_SearchKeyword](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[MemberID] [varchar](20) NULL,
	[Keyword] [nvarchar](50) NULL,
	[ClientID] [tinyint] NULL,
	[ClientName] [nvarchar](20) NULL,
	[IpAddress] [varchar](20) NULL,
	[Hits] [int] NULL,
	[IsTop] [bit] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Extend_SearchKeyword] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_Artice]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_Artice](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[ArticeID] [varchar](20) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[TitleBrief] [nvarchar](100) NULL,
	[ClassID] [varchar](20) NULL,
	[ClassName] [nvarchar](50) NULL,
	[TypeID] [varchar](20) NULL,
	[TypeName] [nvarchar](50) NULL,
	[ImgSrc] [varchar](250) NULL,
	[ImgArray] [varchar](2000) NULL,
	[Author] [nvarchar](50) NULL,
	[Source] [nvarchar](50) NULL,
	[Tags] [nvarchar](50) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[Content] [ntext] NULL,
	[Url] [varchar](250) NULL,
	[Hits] [int] NULL,
	[Sort] [int] NULL,
	[UpNum] [int] NULL,
	[DownNum] [int] NULL,
	[AllowComment] [bit] NULL,
	[CommentStartTime] [datetime] NULL,
	[CommentEndTime] [datetime] NULL,
	[IsTop] [bit] NULL,
	[IsPush] [bit] NULL,
	[IsVip] [bit] NULL,
	[IsDraft] [bit] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[Account] [varchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_Artice] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[ArticeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_Block]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_Block](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[BlockID] [varchar](20) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Tags] [nvarchar](200) NULL,
	[Remark] [nvarchar](400) NULL,
	[Content] [ntext] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_Block] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[BlockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_Class]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_Class](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[ClassID] [varchar](20) NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[ClassType] [tinyint] NULL,
	[ClassTypeName] [nvarchar](20) NULL,
	[ClassRank] [tinyint] NULL,
	[ParentID] [varchar](20) NULL,
	[ParentPath] [varchar](400) NULL,
	[OrderID] [int] NULL,
	[OrderPath] [varchar](400) NULL,
	[ImgSrc] [varchar](250) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_Class] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_Notice]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_Notice](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[NoticeID] [varchar](20) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[ClassID] [varchar](20) NULL,
	[ClassName] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[ImgSrc] [varchar](250) NULL,
	[ImgArray] [varchar](2000) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[Content] [ntext] NULL,
	[StaffId] [varchar](20) NULL,
	[StaffName] [nvarchar](20) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_Notice] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[NoticeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_NoticeCategory]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_NoticeCategory](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[CategoryID] [varchar](20) NOT NULL,
	[CategoryName] [nvarchar](20) NULL,
	[Remark] [nvarchar](400) NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_NoticeCategory] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Info_Page]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Info_Page](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[PageID] [varchar](20) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[ClassID] [varchar](20) NULL,
	[ClassName] [nvarchar](20) NULL,
	[ImgSrc] [varchar](250) NULL,
	[ImgArray] [varchar](2000) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[Content] [ntext] NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Info_Page] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Company]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Company](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[DealerID] [varchar](20) NULL,
	[ClassID] [tinyint] NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [varchar](32) NULL,
	[CompanyName] [nvarchar](50) NULL,
	[LogoImages] [nvarchar](255) NULL,
	[NickName] [nvarchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[Description] [nvarchar](200) NULL,
	[RegisterIpAddress] [varchar](50) NULL,
	[RegisterTime] [datetime] NULL,
	[Version] [varchar](10) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[LoginTotalNumber] [int] NULL,
	[State] [bit] NULL,
	[IsDal] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Company] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Dealer]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Dealer](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[DealerID] [varchar](20) NOT NULL,
	[DealerName] [nvarchar](50) NULL,
	[UserID] [varchar](20) NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](32) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ClassID] [varchar](20) NULL,
	[ClassName] [nvarchar](20) NULL,
	[RankID] [varchar](20) NULL,
	[RankName] [nvarchar](20) NULL,
	[TotalCredit] [int] NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Contacts] [nvarchar](20) NULL,
	[Sex] [tinyint] NULL,
	[Tel] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[QQ] [varchar](20) NULL,
	[Weixin] [varchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[Logo] [varchar](250) NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Dealer] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[DealerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Department]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Department](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[DepartmentID] [varchar](20) NOT NULL,
	[DepartmentName] [nvarchar](20) NULL,
	[ParentID] [varchar](20) NULL,
	[NodePath] [varchar](200) NULL,
	[RankID] [int] NULL,
	[SortID] [int] NULL,
	[SortPath] [varchar](400) NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Department] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Position]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Position](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[PositionID] [varchar](20) NOT NULL,
	[PositionName] [nvarchar](20) NULL,
	[Description] [nvarchar](200) NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Position] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Staff](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[StaffID] [varchar](20) NOT NULL,
	[StaffName] [nvarchar](10) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [varchar](32) NULL,
	[NickName] [nvarchar](20) NULL,
	[HeadImgUrl] [nvarchar](200) NULL,
	[Name] [nvarchar](20) NULL,
	[Sex] [tinyint] NULL,
	[BirthDate] [date] NULL,
	[BirthPlace] [nvarchar](200) NULL,
	[Identification] [varchar](20) NULL,
	[Education] [nvarchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[QQ] [varchar](20) NULL,
	[Weixin] [varchar](32) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Wages] [decimal](18, 2) NULL,
	[Probation] [int] NULL,
	[StartWorkDate] [date] NULL,
	[EndWorkDate] [date] NULL,
	[SignContractDate] [date] NULL,
	[ExpirationContractDate] [date] NULL,
	[DepartmentID] [varchar](20) NULL,
	[DepartmentName] [nvarchar](50) NULL,
	[PositionID] [varchar](20) NULL,
	[PositionName] [nvarchar](50) NULL,
	[StoreID] [varchar](20) NULL,
	[StoreName] [nvarchar](50) NULL,
	[WarehouseID] [varchar](20) NULL,
	[WarehouseName] [nvarchar](50) NULL,
	[Description] [nvarchar](400) NULL,
	[IsInit] [bit] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Staff] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Store]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Store](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[StoreID] [varchar](20) NOT NULL,
	[StoreName] [nvarchar](100) NULL,
	[Logo] [varchar](250) NULL,
	[Contacts] [nvarchar](10) NULL,
	[Tel] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[ProvinceID] [int] NULL,
	[CityID] [int] NULL,
	[AreaID] [int] NULL,
	[Address] [nvarchar](250) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Push] [bit] NULL,
	[Sort] [int] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Store] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Supplier]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Supplier](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[SupplierID] [varchar](20) NOT NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Representative] [nvarchar](20) NULL,
	[CompanyNature] [nvarchar](50) NULL,
	[Business] [nvarchar](400) NULL,
	[LicenseNumber] [nvarchar](50) NULL,
	[LicenseImageUrl] [nvarchar](250) NULL,
	[CodeCertificateNumber] [nvarchar](50) NULL,
	[CodeCertificateImageUrl] [varchar](250) NULL,
	[Address] [varchar](250) NULL,
	[Contacts] [varchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Supplier] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Institution_Warehouse]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Institution_Warehouse](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[WarehouseID] [varchar](20) NOT NULL,
	[WarehouseName] [nvarchar](100) NULL,
	[Contacts] [nvarchar](10) NULL,
	[Tel] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Institution_Warehouse] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[WarehouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_ErrorRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ld_Log_ErrorRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[ClientID] [tinyint] NULL,
	[Url] [nvarchar](255) NULL,
	[Message] [nvarchar](4000) NULL,
	[IpAddress] [nvarchar](20) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_ErrorRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ld_Log_LoginRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_LoginRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[ClientID] [tinyint] NULL,
	[ClientName] [varchar](20) NULL,
	[TypeID] [tinyint] NULL,
	[TypeName] [nvarchar](20) NULL,
	[Account] [varchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[IpAddress] [varchar](20) NULL,
	[IsResult] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_LoginRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_Table]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_Table](
	[TableID] [varchar](20) NOT NULL,
	[TableName] [nvarchar](50) NULL,
	[BusinessName] [nvarchar](50) NULL,
	[PrimaryKey] [varchar](800) NULL,
	[UrlTemplate] [nvarchar](400) NULL,
	[Account] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[Remark] [nvarchar](400) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_Table] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_TableDetails]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_TableDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TableID] [varchar](20) NULL,
	[TableName] [varchar](50) NULL,
	[ColumnName] [nvarchar](50) NULL,
	[ColumnText] [nvarchar](50) NULL,
	[ColumnDataType] [nvarchar](50) NULL,
	[IsPrimaryKey] [bit] NULL,
	[Account] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[Remark] [nvarchar](400) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_TableDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_TableOperation]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_TableOperation](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TableID] [varchar](20) NULL,
	[TableName] [varchar](50) NULL,
	[ClientID] [tinyint] NULL,
	[ClientName] [nvarchar](20) NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[PrimaryKeyValue] [nvarchar](200) NULL,
	[OldContent] [text] NULL,
	[NewContent] [text] NULL,
	[Url] [nvarchar](400) NULL,
	[IpAdress] [varchar](20) NULL,
	[Account] [nvarchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_TableOperation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_VisitorRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_VisitorRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[ClientID] [tinyint] NULL,
	[IpAddress] [nvarchar](20) NULL,
	[Host] [nvarchar](50) NULL,
	[AbsoluteUri] [nvarchar](250) NULL,
	[QueryString] [nvarchar](4000) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Log_VisitorRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Log_WebApiAccessRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Log_WebApiAccessRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[AppID] [varchar](20) NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[Method] [varchar](50) NULL,
	[Url] [varchar](1000) NULL,
	[Parameter] [ntext] NULL,
	[Version] [varchar](50) NULL,
	[ControllerName] [varchar](50) NULL,
	[ActionName] [varchar](50) NULL,
	[ParameterName] [varchar](50) NULL,
	[Result] [ntext] NULL,
	[IpAddress] [varchar](20) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[TotalMillisecond]  AS (datediff(millisecond,[createdate],[updatedate])) PERSISTED,
 CONSTRAINT [PK_Ld_Log_WebApiAccessRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_AccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_AccessToken](
	[Token] [varchar](64) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[MemberID] [varchar](20) NULL,
	[Uuid] [varchar](32) NULL,
	[ExpiresIn] [int] NULL,
	[IpAddress] [varchar](20) NULL,
	[CreateTimestamp] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_AccessToken] PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_Account]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_Account](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MemberID] [varchar](20) NOT NULL,
	[RankID] [varchar](20) NULL,
	[RankName] [nvarchar](20) NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[UserName] [varchar](32) NULL,
	[Password] [varchar](32) NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Name] [nvarchar](10) NULL,
	[NickName] [nvarchar](20) NULL,
	[HeadImageUrl] [varchar](250) NULL,
	[Sex] [tinyint] NULL,
	[Phone] [varchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](64) NULL,
	[QQ] [varchar](64) NULL,
	[Weixin] [varchar](64) NULL,
	[Country] [nvarchar](20) NULL,
	[Province] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[Area] [nvarchar](20) NULL,
	[Address] [nvarchar](128) NULL,
	[Balance] [decimal](18, 2) NULL,
	[TotalPoints] [int] NULL,
	[TotalConsumption] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Remark] [nvarchar](200) NULL,
	[RegisterIpAddress] [varchar](20) NULL,
	[RegisterTime] [datetime] NULL,
	[LastLoginIpAddress] [varchar](20) NULL,
	[LastLoginTime] [datetime] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_Account] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_Address]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_Address](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MemberID] [varchar](20) NOT NULL,
	[AddressID] [varchar](20) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[Province] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[Area] [nvarchar](20) NULL,
	[Address] [nvarchar](150) NULL,
	[Tags] [nvarchar](200) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[IsDefault] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_Address_1] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MemberID] ASC,
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_AmountRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_AmountRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[MemberID] [varchar](20) NULL,
	[ClassID] [int] NULL,
	[ClassName] [nvarchar](20) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Body] [ntext] NULL,
	[Account] [varchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_PointExchange] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_Invoice]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_Invoice](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MemberID] [varchar](20) NOT NULL,
	[InvoiceID] [varchar](20) NOT NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[TaxpayerIdentificationNumber] [varchar](50) NULL,
	[BankName] [nvarchar](50) NULL,
	[BankAccount] [varchar](50) NULL,
	[Tel] [varchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[BusinessLicense] [nvarchar](400) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_Invoice] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MemberID] ASC,
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_LoginLogs]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_LoginLogs](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[MemberID] [varchar](20) NULL,
	[ClientID] [tinyint] NULL,
	[Account] [varchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[IpAddress] [varchar](20) NULL,
	[IsResult] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_LoginLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_PointRecord]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_PointRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[CompanyID] [varchar](20) NULL,
	[MemberID] [varchar](20) NULL,
	[ClassID] [tinyint] NULL,
	[ClassName] [nvarchar](20) NULL,
	[TypeID] [tinyint] NULL,
	[TypeName] [nvarchar](20) NULL,
	[Points] [int] NULL,
	[Body] [ntext] NULL,
	[Account] [nvarchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[ipAddress] [varchar](20) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_PointRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_Rank]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_Rank](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[RankID] [varchar](20) NOT NULL,
	[RankName] [nvarchar](20) NULL,
	[MinPoints] [int] NULL,
	[MaxPoints] [int] NULL,
	[Discount] [tinyint] NULL,
	[ShowPrice] [tinyint] NULL,
	[SpecialRank] [tinyint] NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_Rank] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[RankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Member_RefreshToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Member_RefreshToken](
	[RefreshToken] [varchar](64) NOT NULL,
	[Token] [varchar](64) NULL,
	[ExpiresIn] [int] NULL,
	[IpAddress] [varchar](20) NULL,
	[CreateTimestamp] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[RefreshToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Service_MessageBoard]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Service_MessageBoard](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[MessageID] [varchar](20) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Tel] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[ImgSrc] [varchar](250) NULL,
	[Content] [nvarchar](400) NULL,
	[IpAddress] [varchar](20) NULL,
	[Reply] [nvarchar](400) NULL,
	[ReplyStaffId] [varchar](20) NULL,
	[ReplyStaffName] [nvarchar](10) NULL,
	[ReplyTime] [datetime] NULL,
	[IsTop] [bit] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Service_MessageBoard] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_AccessCorsHost]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_AccessCorsHost](
	[SystemID] [int] NOT NULL,
	[WebHost] [varchar](250) NOT NULL,
	[Remark] [nvarchar](400) NULL,
	[Account] [varchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Member_AccessCorsHost] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[WebHost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_Code]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ld_Sys_Code](
	[SystemID] [int] NOT NULL,
	[SystemName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_LdCms_Sys_Code] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ld_Sys_Config]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_Config](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Keyword] [nvarchar](200) NULL,
	[Description] [nvarchar](400) NULL,
	[HomeUrl] [varchar](250) NULL,
	[StyleSrc] [varchar](50) NULL,
	[UploadRoot] [varchar](50) NULL,
	[Copyright] [nvarchar](250) NULL,
	[IcpNumber] [nvarchar](50) NULL,
	[StatisticsCode] [nvarchar](800) NULL,
	[IsLoginIpAddress] [bit] NULL,
	[LoginIpAddressWhiteList] [nvarchar](1000) NULL,
	[MaxLoginFail] [int] NULL,
	[Shielding] [nvarchar](2000) NULL,
	[EmailSendPattern] [nvarchar](50) NULL,
	[EmailHost] [nvarchar](50) NULL,
	[EmailPort] [int] NULL,
	[EmailName] [nvarchar](100) NULL,
	[EmailPassword] [nvarchar](32) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_Config_1] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_Function]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_Function](
	[FunctionID] [varchar](20) NOT NULL,
	[FunctionName] [nvarchar](50) NULL,
	[ParentID] [varchar](20) NULL,
	[RankID] [int] NULL,
	[Selected] [bit] NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_Function] PRIMARY KEY CLUSTERED 
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_InterfaceAccessToken]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_InterfaceAccessToken](
	[Token] [varchar](128) NOT NULL,
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[AppID] [varchar](20) NULL,
	[ExpiresIn] [int] NULL,
	[IpAddress] [varchar](20) NULL,
	[CreateTimestamp] [int] NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_InterfaceAccessToken] PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_InterfaceAccessWhiteList]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_InterfaceAccessWhiteList](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[ClassName] [varchar](20) NULL,
	[Remark] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_InterfaceAccessWhiteList] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[Account] ASC,
	[IpAddress] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_InterfaceAccount]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_InterfaceAccount](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Password] [varchar](32) NULL,
	[Uuid] [varchar](32) NULL,
	[AppID] [varchar](20) NULL,
	[AppSecret] [varchar](32) NULL,
	[AppKey] [varchar](32) NULL,
	[IsWcf] [bit] NULL,
	[IsWeb] [bit] NULL,
	[IsApi] [bit] NULL,
	[IsCors] [bit] NULL,
	[RequestTotalNumber] [int] NULL,
	[Description] [nvarchar](200) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_InterfaceAccount] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_Operator](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[StaffID] [varchar](20) NOT NULL,
	[Remark] [nvarchar](200) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_Operator] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_OperatorRole]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_OperatorRole](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[StaffID] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Ld_Sys_OperatorRole] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[StaffID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_Role]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_Role](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[State] [bit] NULL,
	[IsDel] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_RoleFunction]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_RoleFunction](
	[SystemID] [int] NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[RoleID] [varchar](20) NOT NULL,
	[FunctionID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Ld_Sys_RoleFunction] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[CompanyID] ASC,
	[RoleID] ASC,
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ld_Sys_Version]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ld_Sys_Version](
	[VersionID] [varchar](10) NOT NULL,
	[VersionName] [nvarchar](50) NULL,
	[MarketPrice] [decimal](18, 2) NULL,
	[DealerPrice] [decimal](18, 2) NULL,
	[DepartmentTotalQuantity] [int] NULL,
	[StaffTotalQuantity] [int] NULL,
	[StoreTotalQuantity] [int] NULL,
	[WarehouseTotalQuantity] [int] NULL,
	[Description] [nvarchar](400) NULL,
	[State] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ld_Sys_Version] PRIMARY KEY CLUSTERED 
(
	[VersionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[A_Sys_Test]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[A_Sys_Test]
AS
SELECT   SystemID, CompanyID, StaffID, StaffName, State, CreateDate
FROM      dbo.Ld_Institution_Staff


GO
/****** Object:  View [dbo].[V_Basics_Media]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_Basics_Media]
AS
SELECT   dbo.Ld_Basics_Media.SystemID, dbo.Ld_Basics_Media.CompanyID, dbo.Ld_Basics_Media.MediaID, 
                dbo.Ld_Basics_MediaInterface.AppID, dbo.Ld_Basics_MediaMember.MemberID, dbo.Ld_Basics_Media.Title, 
                dbo.Ld_Basics_Media.Type, dbo.Ld_Basics_Media.FileName, dbo.Ld_Basics_Media.FileExtension, 
                dbo.Ld_Basics_Media.FileSize, dbo.Ld_Basics_Media.Url, dbo.Ld_Basics_Media.Src, dbo.Ld_Basics_Media.Remark, 
                dbo.Ld_Basics_Media.State, dbo.Ld_Basics_Media.CreateDate
FROM      dbo.Ld_Basics_Media LEFT JOIN
                dbo.Ld_Basics_MediaInterface ON dbo.Ld_Basics_Media.SystemID = dbo.Ld_Basics_MediaInterface.SystemID AND 
                dbo.Ld_Basics_Media.CompanyID = dbo.Ld_Basics_MediaInterface.CompanyID AND 
                dbo.Ld_Basics_Media.MediaID = dbo.Ld_Basics_MediaInterface.MediaID LEFT JOIN
                dbo.Ld_Basics_MediaMember ON dbo.Ld_Basics_Media.SystemID = dbo.Ld_Basics_MediaMember.SystemID AND 
                dbo.Ld_Basics_Media.CompanyID = dbo.Ld_Basics_MediaMember.CompanyID AND 
                dbo.Ld_Basics_Media.MediaID = dbo.Ld_Basics_MediaMember.MediaID


GO
/****** Object:  View [dbo].[V_Institution_CompanyVersion]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Institution_CompanyVersion]
AS
SELECT   dbo.Ld_Institution_Company.SystemID, dbo.Ld_Institution_Company.CompanyID, dbo.Ld_Sys_Version.VersionID, 
                dbo.Ld_Sys_Version.VersionName, dbo.Ld_Sys_Version.DealerPrice, dbo.Ld_Sys_Version.MarketPrice, 
                dbo.Ld_Sys_Version.DepartmentTotalQuantity, dbo.Ld_Sys_Version.StaffTotalQuantity, 
                dbo.Ld_Sys_Version.StoreTotalQuantity, dbo.Ld_Sys_Version.WarehouseTotalQuantity, 
                dbo.Ld_Institution_Company.RegisterTime, dbo.Ld_Institution_Company.RegisterIpAddress, 
                dbo.Ld_Institution_Company.StartTime, dbo.Ld_Institution_Company.EndTime, dbo.Ld_Institution_Company.Description, 
                dbo.Ld_Institution_Company.State, dbo.Ld_Institution_Company.IsDal, dbo.Ld_Institution_Company.CreateDate
FROM      dbo.Ld_Institution_Company INNER JOIN
                dbo.Ld_Sys_Version ON dbo.Ld_Institution_Company.Version = dbo.Ld_Sys_Version.VersionID

GO
/****** Object:  View [dbo].[V_Institution_Staff]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Institution_Staff]
AS
SELECT   SystemID, CompanyID, StaffID, StaffName, UserName, Password, NickName, Sex, Phone, Address, State, IsDel, 
                CreateDate
FROM      dbo.Ld_Institution_Staff

GO
/****** Object:  View [dbo].[V_Rand]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create view [dbo].[V_Rand]
as
select Rand() as re





GO
/****** Object:  View [dbo].[V_Sys_Operator]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Sys_Operator]
AS
SELECT   t1.SystemID, t1.CompanyID, t1.StaffID, t3.StaffName, t4.RoleID, t4.RoleName, t3.UserName, t3.Password, t3.NickName, 
                t3.Sex, t3.Phone, t3.Address, t1.Remark, t1.State, t3.IsDel, t1.CreateDate
FROM      dbo.Ld_Sys_Operator AS t1 LEFT OUTER JOIN
                dbo.Ld_Sys_OperatorRole AS t2 ON t1.SystemID = t2.SystemID AND t1.CompanyID = t2.CompanyID AND 
                t1.StaffID = t2.StaffID LEFT OUTER JOIN
                dbo.Ld_Institution_Staff AS t3 ON t1.SystemID = t3.SystemID AND t1.CompanyID = t3.CompanyID AND 
                t1.StaffID = t3.StaffID LEFT OUTER JOIN
                dbo.Ld_Sys_Role AS t4 ON t2.SystemID = t4.SystemID AND t2.CompanyID = t4.CompanyID AND t2.RoleID = t4.RoleID

GO
/****** Object:  View [dbo].[V_Sys_OperatorPermission]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Sys_OperatorPermission]
AS
SELECT   dbo.Ld_Institution_Staff.SystemID, dbo.Ld_Sys_Operator.CompanyID, dbo.Ld_Institution_Staff.StaffID, 
                dbo.Ld_Institution_Staff.StaffName, dbo.Ld_Institution_Staff.UserName, dbo.Ld_Institution_Staff.NickName, 
                dbo.Ld_Sys_Role.RoleID, dbo.Ld_Sys_Role.RoleName, dbo.Ld_Sys_Role.State AS RoleState, 
                dbo.Ld_Sys_Function.FunctionID, dbo.Ld_Sys_Function.FunctionName, dbo.Ld_Sys_Function.State AS FunctionState, 
                dbo.Ld_Sys_Operator.State
FROM      dbo.Ld_Sys_Function INNER JOIN
                dbo.Ld_Sys_RoleFunction ON dbo.Ld_Sys_Function.FunctionID = dbo.Ld_Sys_RoleFunction.FunctionID INNER JOIN
                dbo.Ld_Sys_Role INNER JOIN
                dbo.Ld_Sys_OperatorRole ON dbo.Ld_Sys_Role.SystemID = dbo.Ld_Sys_OperatorRole.SystemID AND 
                dbo.Ld_Sys_Role.RoleID = dbo.Ld_Sys_OperatorRole.RoleID AND 
                dbo.Ld_Sys_Role.CompanyID = dbo.Ld_Sys_OperatorRole.CompanyID INNER JOIN
                dbo.Ld_Sys_Operator ON dbo.Ld_Sys_OperatorRole.SystemID = dbo.Ld_Sys_Operator.SystemID AND 
                dbo.Ld_Sys_OperatorRole.StaffID = dbo.Ld_Sys_Operator.StaffID AND 
                dbo.Ld_Sys_OperatorRole.CompanyID = dbo.Ld_Sys_Operator.CompanyID ON 
                dbo.Ld_Sys_RoleFunction.RoleID = dbo.Ld_Sys_Role.RoleID AND 
                dbo.Ld_Sys_RoleFunction.SystemID = dbo.Ld_Sys_Role.SystemID AND 
                dbo.Ld_Sys_RoleFunction.CompanyID = dbo.Ld_Sys_Role.CompanyID INNER JOIN
                dbo.Ld_Institution_Staff ON dbo.Ld_Sys_Operator.StaffID = dbo.Ld_Institution_Staff.StaffID AND 
                dbo.Ld_Sys_Operator.SystemID = dbo.Ld_Institution_Staff.SystemID AND 
                dbo.Ld_Sys_Operator.CompanyID = dbo.Ld_Institution_Staff.CompanyID


GO
/****** Object:  View [dbo].[V_Sys_RoleFunction]    Script Date: 2019/4/28 9:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Sys_RoleFunction]
AS
SELECT   dbo.Ld_Sys_Role.SystemID, dbo.Ld_Sys_Role.CompanyID, dbo.Ld_Sys_Role.RoleID, dbo.Ld_Sys_Role.RoleName, 
                dbo.Ld_Sys_Function.FunctionID, dbo.Ld_Sys_Function.FunctionName, dbo.Ld_Sys_Function.RankID, 
                dbo.Ld_Sys_Role.State, dbo.Ld_Sys_Role.IsDel, dbo.Ld_Sys_Role.CreateDate
FROM      dbo.Ld_Sys_Role INNER JOIN
                dbo.Ld_Sys_RoleFunction ON dbo.Ld_Sys_Role.SystemID = dbo.Ld_Sys_RoleFunction.SystemID AND 
                dbo.Ld_Sys_Role.RoleID = dbo.Ld_Sys_RoleFunction.RoleID AND 
                dbo.Ld_Sys_Role.CompanyID = dbo.Ld_Sys_RoleFunction.CompanyID INNER JOIN
                dbo.Ld_Sys_Function ON dbo.Ld_Sys_RoleFunction.FunctionID = dbo.Ld_Sys_Function.FunctionID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Institution_Staff"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 311
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 3360
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'A_Sys_Test'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'A_Sys_Test'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Basics_Media"
            Begin Extent = 
               Top = 10
               Left = 394
               Bottom = 333
               Right = 557
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Basics_MediaInterface"
            Begin Extent = 
               Top = 3
               Left = 95
               Bottom = 288
               Right = 252
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Basics_MediaMember"
            Begin Extent = 
               Top = 10
               Left = 697
               Bottom = 285
               Right = 854
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2070
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Basics_Media'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Basics_Media'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[31] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Institution_Company"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 297
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "Ld_Sys_Version"
            Begin Extent = 
               Top = 0
               Left = 550
               Bottom = 303
               Right = 785
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4845
         Alias = 2250
         Table = 4020
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Institution_CompanyVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Institution_CompanyVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Institution_Staff"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 302
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 22
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Institution_Staff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Institution_Staff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "t1"
            Begin Extent = 
               Top = 23
               Left = 274
               Bottom = 297
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t2"
            Begin Extent = 
               Top = 6
               Left = 495
               Bottom = 287
               Right = 652
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t3"
            Begin Extent = 
               Top = 56
               Left = 12
               Bottom = 295
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 25
         End
         Begin Table = "t4"
            Begin Extent = 
               Top = 35
               Left = 788
               Bottom = 286
               Right = 945
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_Operator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_Operator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Sys_Function"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_RoleFunction"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 146
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_Role"
            Begin Extent = 
               Top = 6
               Left = 443
               Bottom = 146
               Right = 600
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_OperatorRole"
            Begin Extent = 
               Top = 6
               Left = 638
               Bottom = 146
               Right = 795
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_Operator"
            Begin Extent = 
               Top = 6
               Left = 833
               Bottom = 146
               Right = 990
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Institution_Staff"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 290
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin Column' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_OperatorPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Widths = 11
         Column = 1440
         Alias = 2730
         Table = 4095
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_OperatorPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_OperatorPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ld_Sys_Role"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 291
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_RoleFunction"
            Begin Extent = 
               Top = 14
               Left = 375
               Bottom = 279
               Right = 532
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ld_Sys_Function"
            Begin Extent = 
               Top = 32
               Left = 711
               Bottom = 311
               Right = 883
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_RoleFunction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Sys_RoleFunction'
GO
