
--����ɱ�
IF OBJECT_ID('Bud_CostAccounting', 'U') IS NOT NULL
    DROP TABLE Bud_CostAccounting
GO
CREATE TABLE Bud_CostAccounting
(
    Id nvarchar(200) PRIMARY KEY,--Guid
    CBSCode nvarchar(200) NOT NULL, --CBS����
    Name nvarchar(200) NOT NULL, --����
    Type nvarchar(1) NOT NULL, --"D"��ʾֱ�ӳɱ���"I"��ʾ��ӳɱ�
    ResourceType nvarchar(200), -- ��Դ����Id
    Note nvarchar(200) --ժҪ
)
GO

--��ӳɱ�Ԥ��
IF OBJECT_ID('Bud_IndirectBudget', 'U') IS NOT NULL
    DROP TABLE Bud_IndirectBudget
GO
CREATE TABLE Bud_IndirectBudget
(
    Id nvarchar(200) PRIMARY KEY, --Guid
    ProjectId nvarchar(200) NOT NULL, --��ĿID
    CBSCode nvarchar(200) NOT NULL, --CBSCode
    BudgetAmount decimal(18,3) NOT NULL DEFAULT(0.0), --Ԥ����
    AccountAmount decimal(18,3) NOT NULL DEFAULT(0.0), --������
    State nvarchar(1) NOT NULL DEFAULT('0'), --״̬ 0(δ�ϱ�)��1(�ϱ���)��2(�����)�� 3(ȡ���ϱ�)�� 4(�ϱ���)
    InputUser nvarchar(200) NOT NULL, --¼����
    InputDate datetime NOT NULL DEFAULT(GETDATE()), --¼��ʱ��
    Note nvarchar(max) --ժҪ
)
GO

--��ӳɱ��¶�Ԥ��
IF OBJECT_ID('Bud_IndirectMonthBudget', 'U') IS NOT NULL
    DROP TABLE Bud_IndirectMonthBudget
GO
CREATE TABLE Bud_IndirectMonthBudget
(
    Id nvarchar(200) PRIMARY KEY, --Guid
    IndirectBudget nvarchar(200) REFERENCES Bud_IndirectBudget(Id) NOT NULL, --��ӳɱ�Ԥ��Id
    Year int NOT NULL, --���
    Month int NOT NULL, --�·�
    Amount decimal(18,3) --���
)
GO

--��ӳɱ��ռ���
IF OBJECT_ID('Bud_IndirectDiaryCost', 'U') IS NOT NULL
    DROP TABLE Bud_IndirectDiaryCost
GO
CREATE TABLE Bud_IndirectDiaryCost
(
    InDiaryId nvarchar(200) PRIMARY KEY, --Guid
    ProjectId nvarchar(200) NOT NULL, --��ĿId
    Name nvarchar(200) NOT NULL, --������Ŀ
    Department nvarchar(200), --������λ
    IssuedBy nvarchar(200) NOT NULL, --������
	FlowState int NOT NULL DEFAULT(-1), --����״̬
    InputUser nvarchar(200) NOT NULL, --¼����
    InputDate datetime NOT NULL --¼��ʱ��
)
GO

--��ӳɱ��ռ�����ϸ
IF OBJECT_ID('Bud_IndirectDiaryDetails', 'U') IS NOT NULL
    DROP TABLE Bud_IndirectDiaryDetails
GO
CREATE TABLE Bud_IndirectDiaryDetails
(
    InDiaryDetailsId nvarchar(200) PRIMARY KEY, --Guid
	InDiaryId nvarchar(200) REFERENCES Bud_IndirectDiaryCost(InDiaryId) ON DELETE CASCADE, --�ռ���Id
    Name nvarchar(200) NOT NULL, --����
    Amount decimal(18,3) NOT NULL DEFAULT(0.0), --���
    CBSCode nvarchar(200) NOT NULL, --CBS����
    Note nvarchar(max) --ժҪ
)
GO

--���
insert dbo.WF_BusinessCode values('087','��ӳɱ��ռ���','InDiaryId','Bud_IndirectDiaryCost','InDiaryId','FlowState','/BudgetManage/Cost/CostVerifyRecord.aspx',null,'29')
insert dbo.WF_Business_Class values('087','001','��ӳɱ��ռ������')

--��֯��������Ԥ��
IF OBJECT_ID('Bud_OrganizationBudget', 'U') IS NOT NULL
    DROP TABLE Bud_OrganizationBudget
GO
CREATE TABLE Bud_OrganizationBudget
(
    Id nvarchar(200) PRIMARY KEY, --Guid
    OrganizationBudgetId nvarchar(200) NOT NULL, --��֯��������
    CBSCode nvarchar(200) NOT NULL, --CBS����
    BudgetAmount decimal(18,3), --Ԥ����
    AccountingAmount decimal(18,3), --������
    State nvarchar(1) NOT NULL DEFAULT('0'), --״̬ 0(δ�ϱ�)��1(�ϱ���)��2(�����)�� 3(ȡ���ϱ�)�� 4(�ϱ���)
    InputUser nvarchar(200) NOT NULL, --¼����
    InputDate datetime NOT NULL DEFAULT(GETDATE()), --¼��ʱ��
    Note nvarchar(max) --ժҪ
)

--ʩ������ 
IF OBJECT_ID('Bud_ConsReport', 'U') IS NOT NULL
    DROP TABLE Bud_ConsReport
CREATE TABLE Bud_ConsReport
(
    ConsReportId nvarchar(500) primary key, --Guid
    PrjId nvarchar(500) NOT NULL, --������ĿId
    State nvarchar(1) NOT NULL DEFAULT('0'), --״̬ 0(δ�ϱ�)��1(�ϱ���)��2(�����)�� 3(ȡ���ϱ�)�� 4(�ϱ���)��add 2011-06-17��
    InputUser nvarchar(500) NOT NULL, --¼����
    InputDate datetime NOT NULL, --¼��ʱ��
    WorkCard nvarchar(max), --������¼
    IsValid bit DEFAULT(0) --�Ƿ���Ч
)

--ʩ�����������
IF OBJECT_ID('Bud_ConsTask', 'U') IS NOT NULL
    DROP TABLE Bud_ConsTask
CREATE TABLE Bud_ConsTask 
(
    ConsTaskId nvarchar(500) primary key, --Guid
    ConsReportId nvarchar(500) REFERENCES Bud_ConsReport(ConsReportId) ON DELETE CASCADE, --����ConsReport
    TaskId nvarchar(500) REFERENCES Bud_Task(TaskId) NOT NULL, --�����ڵ�
    CompleteQuantity decimal(18,3) NOT NULL,--�����
    AccountingQuantity decimal(18,3), --��������add 2011-06-17��
    WorkContent nvarchar(max), --��������
    Note nvarchar(max), --ժҪ
)

IF OBJECT_ID('Bud_ConsTaskRes') IS NOT NULL
    DROP TABLE Bud_ConsTaskRes
CREATE TABLE Bud_ConsTaskRes
(
    ConsTaskResId nvarchar(500) PRIMARY KEY, --Guid
    ConsTaskId nvarchar(500) NOT NULL REFERENCES Bud_ConsTask(ConsTaskId) ON DELETE CASCADE, --����ConsTask
    ResourceId nvarchar(500) REFERENCES Res_Resource(ResourceId) NOT NULL,--ResourceId
    Quantity decimal(18,3) NOT NULL, --�����
    AccountingQuantity decimal(18,3), --������ (add 2011-06-17)
    UnitPrice decimal(18,3) NOT NULL,--����
    CBSCode nvarchar(200), --CBS���� (add 2011-06-17)
)

--�Ө
create function [dbo].[GetResourceType](@ResourceId nvarchar(500)) 
returns nvarchar(500) 
as 
begin 
declare @ResourceType nvarchar(500)
declare @TopResType nvarchar(500)
select @ResourceType= ResourceType from Res_Resource where ResourceId=@ResourceId
if(@ResourceType is not null)
 begin
  set @TopResType=dbo.GetTopResourceType(@ResourceType)
 end 
 return @TopResType
end 
GO

CREATE function [dbo].[GetTopResourceType](@ResourceType nvarchar(500)) 
returns nvarchar(500) 
as 
begin 
declare @TempResType nvarchar(500)
declare @ReturnResType nvarchar(500)
declare @ResCount int
set @ResCount=0
select @TempResType= ParentId from Res_ResourceType where ResourceTypeId=@ResourceType
select @ResCount=count(*) from Res_ResourceType where ParentId=@TempResType
if (@ResCount > 0)
begin
 set @ReturnResType=dbo.GetTopResourceType(@TempResType)
end 
else
begin
select @ReturnResType= ResourceTypeId from Res_ResourceType where ResourceTypeId=@ResourceType
end
return @ReturnResType
end



