
--�����豸�������ݱ�
--ɾ����� 
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ParentId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_EquipmentType DROP CONSTRAINT FK_ParentId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_TypeId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Equipment DROP CONSTRAINT FK_TypeId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_BudOilWearId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Ship_RefuelApply DROP CONSTRAINT FK_BudOilWearId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_SRefule_EquipmentId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Ship_RefuelApply DROP CONSTRAINT FK_SRefule_EquipmentId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RepairPlan_EquipmentId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RepairPlan DROP CONSTRAINT FK_RepairPlan_EquipmentId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RepairPlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RepairApply DROP CONSTRAINT FK_RepairPlanId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Repair_EquipmentId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RepairApply DROP CONSTRAINT FK_Repair_EquipmentId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Repair_ApplyId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RepairReport DROP CONSTRAINT FK_Repair_ApplyId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Repair_ReportId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RepairStock DROP CONSTRAINT FK_Repair_ReportId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_EnterId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_OilOut DROP CONSTRAINT FK_EnterId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RequirePlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Progress DROP CONSTRAINT FK_RequirePlanId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ProgressId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ProgressDetail DROP CONSTRAINT FK_ProgressId
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Discard_EquipmentId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Discard DROP CONSTRAINT FK_Discard_EquipmentId
GO


--ɾ���� 
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_EquipmentType') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_EquipmentType
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Equipment') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Equipment
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Ship_BudOilWear') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Ship_BudOilWear
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Ship_RefuelApply') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Ship_RefuelApply
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RepairPlan') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RepairPlan
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RepairApply') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RepairApply
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RepairReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RepairReport
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RepairStock') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RepairStock
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_OilEnter') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_OilEnter
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_OilOut') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_OilOut
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RequirePlan') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RequirePlan
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Progress') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Progress
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ProgressDetail') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ProgressDetail
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Discard') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Discard
GO


--������ 
--�����豸���ͱ�
CREATE TABLE Equ_EquipmentType ( 
	Id nvarchar(500) NOT NULL,    --  �豸����ID 
	ParentId nvarchar(500),    --  ���ڵ� 
	Name nvarchar(1000) NOT NULL,    --  �豸���� 
	No int NOT NULL,    --  ��� 
	Code nvarchar(200) NOT NULL,    --  ���ݸ��ڵ����źͱ��������Զ����ɣ�3λһ�� 
	Flag nvarchar(50)		--�����ʶ
)
GO
--�����豸̨�˱�
CREATE TABLE Equ_Equipment ( 
	Id nvarchar(500) NOT NULL,    --  �豸ID 
	EquipmentCode nvarchar(500) NOT NULL,    --  �豸��� 
	ResourceId nvarchar(500) NOT NULL,    --  ��ԴId 
	TypeId nvarchar(500) NOT NULL,    --  �豸����ID 
	Accuracy nvarchar(1000),    --  ���� 
	FactoryNumber nvarchar(1000),    --  ������� 
	DepreciationRate decimal(18,3) NOT NULL,    --  �۾��� 
	FactoryDate datetime,    --  �������� 
	PurchaseDate datetime,    --  �������� 
	PeriodicVertification nvarchar(50),    --  �춨���� 
	DurableYear nvarchar(50),    --  �������� 
	PurchasePrice decimal(18,3) NOT NULL,    --  ԭֵ 
	SupplierId int,    --  ���쳧�� 
	State int NOT NULL,    --  �豸״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--�����ͺ�Ԥ���
CREATE TABLE Equ_Ship_BudOilWear ( 
	Id nvarchar(500) NOT NULL,    --  �ͺ�Ԥ��Id 
	Code nvarchar(500) NOT NULL,    --  Ԥ���� 
	PrjId nvarchar(500) NOT NULL,    --  ��ĿId 
	TaskId nvarchar(500) NOT NULL,    --  ����ڵ� 
	ConBudOilWear decimal(18,3) NOT NULL,    --  ��ͬԤ���ͺ� 
	Sump decimal(18,3),    --  ���� 
	SoilTexture nvarchar(500),    --  ���� 
	DemandShipType nvarchar(500),    --  ������ 
	IsOutLease bit NOT NULL,    --  �Ƿ������� 
	StartDate datetime,    --  Ԥ�ƿ���ʱ�� 
	EndDate datetime,    --  Ԥ���깤ʱ�� 
	QuotaOilWear decimal(18,3) NOT NULL,    --  �����ͺ� 
	ConstructionPlace nvarchar(500),    --  ʩ���ص� 
	BudQutity decimal(18,3) NOT NULL,    --  Ԥ�����෽�� 
	BudOilWear decimal(18,3) NOT NULL,    --  Ԥ���ͺ� 
	BudOilPrice decimal(18,3) NOT NULL,    --  Ԥ���͵��� 
	QuotaOilWearQuantiy decimal(18,3) NOT NULL,    --  �����ͺ����� 
	BudOilWearQuantity decimal(18,3) NOT NULL,    --  Ԥ���ͺ����� 
	Note nvarchar(max),    --  ��ע 
	FlowState int NOT NULL,    --  ����״̬ 
	InputDate datetime NOT NULL    --  ¼��ʱ�� 
)
GO
--�������������
CREATE TABLE Equ_Ship_RefuelApply ( 
	Id nvarchar(500) NOT NULL,    --  ����ID 
	PrjId nvarchar(500) NOT NULL,    --  ��ĿID 
	BudOilWearId nvarchar(500) NOT NULL,    --  �ͺ�Ԥ��Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �ͺ�Ԥ�� 
	ApplyQuantity decimal(18,3) NOT NULL,    --  ������������� 
	StockQuantity decimal(18,3) NOT NULL,    --  ���п���� 
	BudCompleteQuantity decimal(18,3) NOT NULL,    --  Ԥ����ɹ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TotalConstructionDates decimal(18,3) NOT NULL,    --  �ۼƼ���ʱ�� 
	Sump decimal(18,3) NOT NULL,    --  ���� 
	CompletedQuantity decimal(18,3) NOT NULL,    --  ��������ô��ۼ���ɸ���Ŀ�Ĺ����� 
	TotalRefuel decimal(18,3) NOT NULL,    --  �����������Ŀ�ô��ۼƼ������� 
	ApplyRefuelPlace nvarchar(500) NOT NULL,    --  ������͵ص� 
	ApplyRefuelDate datetime,    --  �������ʱ�� 
	Reason nvarchar(max),    --  ԭ����� 
	IsEntrustPurchase bit NOT NULL,    --  �Ƿ�ί�вɹ� 
	ApplyMaster nvarchar(50),    --  ���봬�� 
	OilsType nvarchar(500),    --  ��Ʒ���� 
	Fueler nvarchar(500),    --  ���ʹ� 
	FuelerOwner nvarchar(500),    --  ���� 
	LocaleLeader char(8),    --  �ֳ������� 
	LeaderPhone nvarchar(50),    --  �ֳ������˵绰 
	Note nvarchar(max),    --  ��ע 
	FlowState int NOT NULL,    --  ����״̬ 
	InputUser char(8) NOT NULL,    --  ¼���� 
	InputDate datetime NOT NULL,    --  ¼��ʱ�� 
	LastModifyUser char(8) NOT NULL,    --  ���ձ���� 
	LastModifyDate datetime NOT NULL    --  ���ձ��ʱ�� 
)
GO
--����ά�޼ƻ���
CREATE TABLE Equ_RepairPlan ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸Id 
	Code nvarchar(500) NOT NULL,    --  ά�޼ƻ����� 
	ApplyDepId int,    --  ���벿�� 
	RepairContent nvarchar(500),    --  �������� 
	RepairStartDate datetime,    --  ά�޿�ʼʱ�� 
	RepairEndDate datetime,    --  ά�޽���ʱ�� 
	Cost decimal(18,3),    --  Ԥ������ 
	RepairType char(1),    --  ά�޷�ʽ "0" ����ά�� "1" ί��ά�� 
	EquipmentType char(1),    --  �豸����: "0" �������豸   "1" ����½���豸 
	RmFlag char(1),    --  ά����ʶ��R��ʾά�ޣ�M��ʾ���� 
	FlowState int NOT NULL,    --  ����״̬ 
	InputUser varchar(8) NOT NULL,    --  ¼���� 
	InputDate datetime DEFAULT GETDATE() NOT NULL,    --  ¼��ʱ�� 
	Note nvarchar(max)    --  ��ע 
)
GO
--����ά�������
CREATE TABLE Equ_RepairApply ( 
	Id nvarchar(500) NOT NULL,    --  ά�����뵥Id 
	RepairPlanId nvarchar(500),    --  ά�޼ƻ�Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸Id 
	Code nvarchar(500) NOT NULL,    --  ��� 
	ConstructionPlace nvarchar(500),    --  ʩ������ 
	DepreciationAmount decimal(18,3) NOT NULL,    --  ���۾ɽ�� 
	LastRepairDate datetime,    --  �ϴ�ά������ 
	LastRepairContent nvarchar(500),    --  �ϴ�ά������ 
	LastRepairCost decimal(18,3) NOT NULL,    --  �ϴ�ά�޷��� 
	BudRepairCost decimal(18,3) NOT NULL,    --  ����Ԥ�Ʒ�ά���� 
	BudRepairStartDate datetime,    --  ����Ԥ�ƿ�ʼʱ�� 
	BudRepairEndDate datetime,    --  ����Ԥ�ƽ���ʱ�� 
	BudRepareContent nvarchar(500),    --  ����ά������ 
	ApplyDepId int,    --  ���벿�� 
	ApplyDate datetime,    --  �������� 
	TaskName nvarchar(500),    --  ��������� 
	RepairType char(1) NOT NULL,    --  ά�޷�ʽ "0" ����ά�� "1" ί��ά�� 
	EquipmentType char(1) NOT NULL,    --  �豸����: "0" �������豸   "1" ����½���豸 
	RmFlag char(1),    --  ά����ʶ��R��ʾά�ޣ�M��ʾ���� 
	RepairReason nvarchar(500),    --  ά��ԭ��˵�� 
	FlowState int NOT NULL,    --  ����״̬ 
	InputUser varchar(8) NOT NULL,    --  ¼���� 
	InputDate datetime DEFAULT GETDATE() NOT NULL,    --  ¼��ʱ�� 
	Note nvarchar(max)    --  ��ע 
)
GO
--����ά���ϱ���
CREATE TABLE Equ_RepairReport ( 
	Id nvarchar(500) NOT NULL,    --  �ϱ�ID 
	ApplyId nvarchar(500) NOT NULL,    --  ά������ID 
	ReportDate datetime NOT NULL,    --  �ϱ����� 
	FaultDescription nvarchar(500),    --  ���ϼ�� 
	RepairContent nvarchar(500),    --  ά������ 
	RepairStartDate datetime,    --  ά�޿�ʼʱ�� 
	RepairEndDate datetime,    --  ά�޽���ʱ�� 
	Reason nvarchar(max),    --  ԭ����� 
	OutCompany nvarchar(500),    --  ί��ά�޹�˾ 
	OutDepartment nvarchar(500),    --  ί��ά�޲��� 
	ContractId nvarchar(64),    --  ί��ά�޺�ͬ 
	OutSubContractor nvarchar(500),    --  ί��ְ��� 
	RepairPerson nvarchar(50),    --  ά����Ա 
	LaborCost decimal(18,3) NOT NULL,    --  �˹��� 
	StuffCost decimal(18,3) NOT NULL,    --  ���Ϸ� 
	RepairCost decimal(18,3) NOT NULL,    --  ά�޷��� 
	Acceptor char(8),    --  ������ 
	EquipmentType char(1) NOT NULL,    --  �豸����: "0" �������豸   "1" ����½���豸 
	FlowState int NOT NULL,    --  ����״̬ 
	InputUser char(8) NOT NULL,    --  ¼���� 
	InputDate datetime NOT NULL,    --  ¼��ʱ�� 
	Note nvarchar(max)    --  ��ע 
)
GO
--����ά������������
CREATE TABLE Equ_RepairStock ( 
	Id nvarchar(500) NOT NULL,    --  ά���㲿��ID 
	ReportId nvarchar(500) NOT NULL,    --  ά���ϱ�Id 
	ResourceId nvarchar(500) NOT NULL,    --  �㲿��ID 
	Quantity decimal(18,3) NOT NULL,    --  ���� 
	UnitPrice decimal(18,3) NOT NULL,    --  ���� 
	CorpId nvarchar(64),    --  ��Ӧ�� 
	ReceivePerson char(8) NOT NULL,    --  ������ 
	ReceiveDate datetime NOT NULL    --  ����ʱ�� 
)
GO
--����½���豸�ͺ�����
CREATE TABLE Equ_OilEnter ( 
	Id nvarchar(200) NOT NULL,    --  Id 
	Code nvarchar(200) NOT NULL,    --  ����� 
	PrjId nvarchar(200),    --  ��ĿId 
	ContractId nvarchar(200),    --  �ɹ���ͬID 
	PurchaseCode nvarchar(64),    --  �ɹ������ 
	UnitPrice decimal(18,3),    --  ���� 
	Quantity decimal(18,3),    --  ���� 
	StoreKeeper varchar(8),    --  ���Ա 
	SignInUser varchar(8),    --  ǩ���� 
	EnterDate datetime
)
GO
--����½���豸�ͺĳ����
CREATE TABLE Equ_OilOut ( 
	Id nvarchar(200) NOT NULL,    --  Id 
	EnterId nvarchar(200),    --  ���Id 
	PrjId nvarchar(200),    --  ��ĿId 
	Code nvarchar(200),    --  ������ 
	EquipmentId nvarchar(200),
	StoreKeeper varchar(8),    --  ���Ա 
	TaskId nvarchar(200),    --  �ֲ����� 
	HireType nvarchar(50),    --  �������ͣ�S��ʾ���ã�L��ʾ���� 
	HireContractId nvarchar(200),    --  �����ͬ 
	IsAsupply bit,    --  �Ƿ�׹� 
	BalanceMode nvarchar(50),    --  ���㷽ʽ 
	AsupplyContractId nvarchar(200),    --  �׹���ͬ��� 
	SignInUser varchar(8),    --  ǩ���� 
	Quantity decimal(18,3),    --  ���� 
	UnitPrice decimal(18,2),    --  ���� 
	OutDate datetime,    --  ����ʱ�� 
	FlowState int NOT NULL    --  ����״̬ 
)
GO
--�����豸����ƻ���
CREATE TABLE Equ_RequirePlan ( 
	Id nvarchar(500) NOT NULL,
	Code nvarchar(200) NOT NULL,    --  ��� 
	PrjId nvarchar(500),    --  ��ĿId 
	TaskId nvarchar(500),    --  �ֲ����� 
	FlowState int NOT NULL,    --  ����״̬ 
	InputDate datetime DEFAULT GETDATE() NOT NULL    --  ¼��ʱ�� 
)
GO
--�������̽��ȱ�
CREATE TABLE Equ_Progress ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	RequirePlanId nvarchar(500),    --  ����ƻ�Id 
	Year int NOT NULL,    --  ��� 
	Month int NOT NULL,    --  �·� 
	InputDate datetime DEFAULT GETDATE() NOT NULL    --  ¼��ʱ�� 
)
GO
--�������̽�����ϸ��
CREATE TABLE Equ_ProgressDetail ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	ProgressId nvarchar(500),    --  ���̽���Id 
	EquipmentTypeId nvarchar(500),    --  �豸���� 
	EnterDate datetime,    --  Ԥ�ƽ���ʱ�� 
	OutDate datetime,    --  Ԥ���˳�ʱ�� 
	EnterArea nvarchar(500),    --  Ԥ�ƽ����ص� 
	EquipmentSource nvarchar(500),    --  �豸��Դ 
	BudCost decimal(18,3),    --  Ԥ����� 
	Quantity decimal(18,3)    --  ���� 
)
GO
--�����豸���ϱ�
CREATE TABLE Equ_Discard ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸Id 
	AlreadyDepreciations  decimal(18,3) NOT NULL,    --  �����۾� 
	NetWorth decimal(18,3) NOT NULL,    --  �ʲ���ֵ 
	Reason nvarchar(max),    --  ����ԭ�� 
	Applicant varchar(8),    --  ������ 
	ApplyDate datetime,    --  �������� 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO

--�������� 
ALTER TABLE Equ_EquipmentType ADD CONSTRAINT PK_EquipmentType 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Equipment ADD CONSTRAINT PK_Equ_Equipment 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Ship_BudOilWear ADD CONSTRAINT PK_Equ_BudOilWear 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Ship_RefuelApply ADD CONSTRAINT PK_Equ_RefuelApply 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RepairPlan ADD CONSTRAINT PK_Equ_RepairPlan 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RepairApply ADD CONSTRAINT PK_Equ_RepairApply 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RepairReport ADD CONSTRAINT PK_Equ_RepairReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RepairStock ADD CONSTRAINT PK_Equ_RepairStock 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_OilEnter ADD CONSTRAINT PK_OilIn 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_OilOut ADD CONSTRAINT PK_OilOut 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RequirePlan ADD CONSTRAINT PK_Equ_RequirePlan 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Progress ADD CONSTRAINT PK_Equ_Progress 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ProgressDetail ADD CONSTRAINT PK_Equ_ProgressDetail 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Discard ADD CONSTRAINT PK_Equ_Discard 
	PRIMARY KEY CLUSTERED (Id)
GO

--  �������
ALTER TABLE Equ_EquipmentType ADD CONSTRAINT FK_ParentId 
	FOREIGN KEY (ParentId) REFERENCES Equ_EquipmentType (Id)
GO
ALTER TABLE Equ_Equipment ADD CONSTRAINT FK_TypeId 
	FOREIGN KEY (TypeId) REFERENCES Equ_EquipmentType (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Ship_RefuelApply ADD CONSTRAINT FK_BudOilWearId 
	FOREIGN KEY (BudOilWearId) REFERENCES Equ_Ship_BudOilWear (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Ship_RefuelApply ADD CONSTRAINT FK_SRefule_EquipmentId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RepairPlan ADD CONSTRAINT FK_RepairPlan_EquipmentId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
ALTER TABLE Equ_RepairApply ADD CONSTRAINT FK_RepairPlanId 
	FOREIGN KEY (RepairPlanId) REFERENCES Equ_RepairPlan (Id)
GO
ALTER TABLE Equ_RepairApply ADD CONSTRAINT FK_Repair_EquipmentId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RepairReport ADD CONSTRAINT FK_Repair_ApplyId 
	FOREIGN KEY (ApplyId) REFERENCES Equ_RepairApply (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RepairStock ADD CONSTRAINT FK_Repair_ReportId 
	FOREIGN KEY (ReportId) REFERENCES Equ_RepairReport (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_OilOut ADD CONSTRAINT FK_EnterId 
	FOREIGN KEY (EnterId) REFERENCES Equ_OilEnter (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Progress ADD CONSTRAINT FK_RequirePlanId 
	FOREIGN KEY (RequirePlanId) REFERENCES Equ_RequirePlan (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ProgressDetail ADD CONSTRAINT FK_ProgressId 
	FOREIGN KEY (ProgressId) REFERENCES Equ_Progress (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Discard ADD CONSTRAINT FK_Discard_EquipmentId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO

EXEC sp_addextendedproperty 'MS_Description', '�豸����', 'Schema', dbo, 'table', Equ_EquipmentType
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����ID', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '���ڵ�', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', ParentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', Name
GO
EXEC sp_addextendedproperty 'MS_Description', '���', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', No
GO
EXEC sp_addextendedproperty 'MS_Description', '���ݸ��ڵ����źͱ��������Զ����ɣ�3λһ��', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ʶ', 'Schema', dbo, 'table', Equ_EquipmentType, 'column', Flag
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸', 'Schema', dbo, 'table', Equ_Equipment
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸ID', 'Schema', dbo, 'table', Equ_Equipment, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸���', 'Schema', dbo, 'table', Equ_Equipment, 'column', EquipmentCode
GO
EXEC sp_addextendedproperty 'MS_Description', '��ԴId', 'Schema', dbo, 'table', Equ_Equipment, 'column', ResourceId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����ID', 'Schema', dbo, 'table', Equ_Equipment, 'column', TypeId
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_Equipment, 'column', Accuracy
GO
EXEC sp_addextendedproperty 'MS_Description', '�������', 'Schema', dbo, 'table', Equ_Equipment, 'column', FactoryNumber
GO
EXEC sp_addextendedproperty 'MS_Description', '�۾���', 'Schema', dbo, 'table', Equ_Equipment, 'column', DepreciationRate
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Equipment, 'column', FactoryDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Equipment, 'column', PurchaseDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�춨����', 'Schema', dbo, 'table', Equ_Equipment, 'column', PeriodicVertification
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Equipment, 'column', DurableYear
GO
EXEC sp_addextendedproperty 'MS_Description', 'ԭֵ', 'Schema', dbo, 'table', Equ_Equipment, 'column', PurchasePrice
GO
EXEC sp_addextendedproperty 'MS_Description', '���쳧��', 'Schema', dbo, 'table', Equ_Equipment, 'column', SupplierId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸״̬', 'Schema', dbo, 'table', Equ_Equipment, 'column', State
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_Equipment, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '�ͺ�Ԥ��', 'Schema', dbo, 'table', Equ_Ship_BudOilWear
GO
EXEC sp_addextendedproperty 'MS_Description', '�ͺ�Ԥ��Id', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ����', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '����ڵ�', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ͬԤ���ͺ�', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', ConBudOilWear
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', Sump
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', SoilTexture
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', DemandShipType
GO
EXEC sp_addextendedproperty 'MS_Description', '�Ƿ�������', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', IsOutLease
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�ƿ���ʱ��', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���깤ʱ��', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ͺ�', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', QuotaOilWear
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ���ص�', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�����෽��', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', BudQutity
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���ͺ�', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', BudOilWear
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���͵���', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', BudOilPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ͺ�����', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', QuotaOilWearQuantiy
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���ͺ�����', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', BudOilWearQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_Ship_BudOilWear, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Ship_RefuelApply
GO
EXEC sp_addextendedproperty 'MS_Description', '����ID', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿID', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ͺ�Ԥ��Id', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', BudOilWearId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ͺ�Ԥ��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�������������', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', ApplyQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '���п����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', StockQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ����ɹ�����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', BudCompleteQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ۼƼ���ʱ��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', TotalConstructionDates
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', Sump
GO
EXEC sp_addextendedproperty 'MS_Description', '��������ô��ۼ���ɸ���Ŀ�Ĺ�����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', CompletedQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '�����������Ŀ�ô��ۼƼ�������', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', TotalRefuel
GO
EXEC sp_addextendedproperty 'MS_Description', '������͵ص�', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', ApplyRefuelPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '�������ʱ��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', ApplyRefuelDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ԭ�����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', Reason
GO
EXEC sp_addextendedproperty 'MS_Description', '�Ƿ�ί�вɹ�', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', IsEntrustPurchase
GO
EXEC sp_addextendedproperty 'MS_Description', '���봬��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', ApplyMaster
GO
EXEC sp_addextendedproperty 'MS_Description', '��Ʒ����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', OilsType
GO
EXEC sp_addextendedproperty 'MS_Description', '���ʹ�', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', Fueler
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', FuelerOwner
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ�������', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', LocaleLeader
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ������˵绰', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', LeaderPhone
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', InputUser
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', '���ձ����', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', LastModifyUser
GO
EXEC sp_addextendedproperty 'MS_Description', '���ձ��ʱ��', 'Schema', dbo, 'table', Equ_Ship_RefuelApply, 'column', LastModifyDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޼ƻ�����', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '���벿��', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', ApplyDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', RepairContent
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޿�ʼʱ��', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', RepairStartDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޽���ʱ��', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', RepairEndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ������', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', Cost
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޷�ʽ "0" ����ά�� "1" ί��ά��', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', RepairType
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����: "0" �������豸   "1" ����½���豸', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', EquipmentType
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά����ʶ��R��ʾά�ޣ�M��ʾ����', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', RmFlag
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼����', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', InputUser
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RepairPlan, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�����뵥Id', 'Schema', dbo, 'table', Equ_RepairApply, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޼ƻ�Id', 'Schema', dbo, 'table', Equ_RepairApply, 'column', RepairPlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RepairApply, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '���', 'Schema', dbo, 'table', Equ_RepairApply, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '���۾ɽ��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', DepreciationAmount
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϴ�ά������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', LastRepairDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϴ�ά������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', LastRepairContent
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϴ�ά�޷���', 'Schema', dbo, 'table', Equ_RepairApply, 'column', LastRepairCost
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ԥ�Ʒ�ά����', 'Schema', dbo, 'table', Equ_RepairApply, 'column', BudRepairCost
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ԥ�ƿ�ʼʱ��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', BudRepairStartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ԥ�ƽ���ʱ��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', BudRepairEndDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ά������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', BudRepareContent
GO
EXEC sp_addextendedproperty 'MS_Description', '���벿��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', ApplyDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', ApplyDate
GO
EXEC sp_addextendedproperty 'MS_Description', '���������', 'Schema', dbo, 'table', Equ_RepairApply, 'column', TaskName
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޷�ʽ "0" ����ά�� "1" ί��ά��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', RepairType
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����: "0" �������豸   "1" ����½���豸', 'Schema', dbo, 'table', Equ_RepairApply, 'column', EquipmentType
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά����ʶ��R��ʾά�ޣ�M��ʾ����', 'Schema', dbo, 'table', Equ_RepairApply, 'column', RmFlag
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά��ԭ��˵��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', RepairReason
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RepairApply, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼����', 'Schema', dbo, 'table', Equ_RepairApply, 'column', InputUser
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_RepairApply, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RepairApply, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά������ϱ�', 'Schema', dbo, 'table', Equ_RepairReport
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�ID', 'Schema', dbo, 'table', Equ_RepairReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά������ID', 'Schema', dbo, 'table', Equ_RepairReport, 'column', ApplyId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RepairReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', '���ϼ��', 'Schema', dbo, 'table', Equ_RepairReport, 'column', FaultDescription
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά������', 'Schema', dbo, 'table', Equ_RepairReport, 'column', RepairContent
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޿�ʼʱ��', 'Schema', dbo, 'table', Equ_RepairReport, 'column', RepairStartDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޽���ʱ��', 'Schema', dbo, 'table', Equ_RepairReport, 'column', RepairEndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ԭ�����', 'Schema', dbo, 'table', Equ_RepairReport, 'column', Reason
GO
EXEC sp_addextendedproperty 'MS_Description', 'ί��ά�޹�˾', 'Schema', dbo, 'table', Equ_RepairReport, 'column', OutCompany
GO
EXEC sp_addextendedproperty 'MS_Description', 'ί��ά�޲���', 'Schema', dbo, 'table', Equ_RepairReport, 'column', OutDepartment
GO
EXEC sp_addextendedproperty 'MS_Description', 'ί��ά�޺�ͬ', 'Schema', dbo, 'table', Equ_RepairReport, 'column', ContractId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ί��ְ���', 'Schema', dbo, 'table', Equ_RepairReport, 'column', OutSubContractor
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά����Ա', 'Schema', dbo, 'table', Equ_RepairReport, 'column', RepairPerson
GO
EXEC sp_addextendedproperty 'MS_Description', '�˹���', 'Schema', dbo, 'table', Equ_RepairReport, 'column', LaborCost
GO
EXEC sp_addextendedproperty 'MS_Description', '���Ϸ�', 'Schema', dbo, 'table', Equ_RepairReport, 'column', StuffCost
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά�޷���', 'Schema', dbo, 'table', Equ_RepairReport, 'column', RepairCost
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_RepairReport, 'column', Acceptor
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����: "0" �������豸   "1" ����½���豸', 'Schema', dbo, 'table', Equ_RepairReport, 'column', EquipmentType
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RepairReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼����', 'Schema', dbo, 'table', Equ_RepairReport, 'column', InputUser
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_RepairReport, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RepairReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά���㲿��', 'Schema', dbo, 'table', Equ_RepairStock
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά���㲿��ID', 'Schema', dbo, 'table', Equ_RepairStock, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', 'ά���ϱ�Id', 'Schema', dbo, 'table', Equ_RepairStock, 'column', ReportId
GO
EXEC sp_addextendedproperty 'MS_Description', '�㲿��ID', 'Schema', dbo, 'table', Equ_RepairStock, 'column', ResourceId
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RepairStock, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RepairStock, 'column', UnitPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '��Ӧ��', 'Schema', dbo, 'table', Equ_RepairStock, 'column', CorpId
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_RepairStock, 'column', ReceivePerson
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_RepairStock, 'column', ReceiveDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_OilEnter, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�����', 'Schema', dbo, 'table', Equ_OilEnter, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_OilEnter, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ɹ���ͬID', 'Schema', dbo, 'table', Equ_OilEnter, 'column', ContractId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ɹ������', 'Schema', dbo, 'table', Equ_OilEnter, 'column', PurchaseCode
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_OilEnter, 'column', UnitPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_OilEnter, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '���Ա', 'Schema', dbo, 'table', Equ_OilEnter, 'column', StoreKeeper
GO
EXEC sp_addextendedproperty 'MS_Description', 'ǩ����', 'Schema', dbo, 'table', Equ_OilEnter, 'column', SignInUser
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_OilOut, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '���Id', 'Schema', dbo, 'table', Equ_OilOut, 'column', EnterId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_OilOut, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_OilOut, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '���Ա', 'Schema', dbo, 'table', Equ_OilOut, 'column', StoreKeeper
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_OilOut, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�������ͣ�S��ʾ���ã�L��ʾ����', 'Schema', dbo, 'table', Equ_OilOut, 'column', HireType
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ͬ', 'Schema', dbo, 'table', Equ_OilOut, 'column', HireContractId
GO
EXEC sp_addextendedproperty 'MS_Description', '�Ƿ�׹�', 'Schema', dbo, 'table', Equ_OilOut, 'column', IsAsupply
GO
EXEC sp_addextendedproperty 'MS_Description', '���㷽ʽ', 'Schema', dbo, 'table', Equ_OilOut, 'column', BalanceMode
GO
EXEC sp_addextendedproperty 'MS_Description', '�׹���ͬ���', 'Schema', dbo, 'table', Equ_OilOut, 'column', AsupplyContractId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ǩ����', 'Schema', dbo, 'table', Equ_OilOut, 'column', SignInUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_OilOut, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_OilOut, 'column', UnitPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_OilOut, 'column', OutDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_OilOut, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '���', 'Schema', dbo, 'table', Equ_RequirePlan, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RequirePlan, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RequirePlan, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RequirePlan, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_RequirePlan, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_Progress, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '����ƻ�Id', 'Schema', dbo, 'table', Equ_Progress, 'column', RequirePlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '���', 'Schema', dbo, 'table', Equ_Progress, 'column', Year
GO
EXEC sp_addextendedproperty 'MS_Description', '�·�', 'Schema', dbo, 'table', Equ_Progress, 'column', Month
GO
EXEC sp_addextendedproperty 'MS_Description', '¼��ʱ��', 'Schema', dbo, 'table', Equ_Progress, 'column', InputDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '���̽���Id', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', ProgressId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', EquipmentTypeId
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�ƽ���ʱ��', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', EnterDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���˳�ʱ��', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', OutDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�ƽ����ص�', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', EnterArea
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸��Դ', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', EquipmentSource
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�����', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', BudCost
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ProgressDetail, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����', 'Schema', dbo, 'table', Equ_Discard
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_Discard, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_Discard, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�����۾�', 'Schema', dbo, 'table', Equ_Discard, 'column', AlreadyDepreciations 
GO
EXEC sp_addextendedproperty 'MS_Description', '�ʲ���ֵ', 'Schema', dbo, 'table', Equ_Discard, 'column', NetWorth
GO
EXEC sp_addextendedproperty 'MS_Description', '����ԭ��', 'Schema', dbo, 'table', Equ_Discard, 'column', Reason
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_Discard, 'column', Applicant
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Discard, 'column', ApplyDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Discard, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_Discard, 'column', Note
GO

--�����豸�����������SQL					lhy				2013-09-12 16:50
--ɾ�����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Deploy_RequirePlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_DeployPlan DROP CONSTRAINT FK_Deploy_RequirePlanId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_DeployPlan_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_DeployPlan DROP CONSTRAINT FK_DeployPlan_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_AcceptanceDetail_AcceptanceId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_AcceptanceDetail DROP CONSTRAINT FK_AcceptanceDetail_AcceptanceId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Alloc_DeployPlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Alloc DROP CONSTRAINT FK_Alloc_DeployPlanId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Lease_DeployPlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_Lease DROP CONSTRAINT FK_Lease_DeployPlanId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_DeployPlanId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_PurchaseApply DROP CONSTRAINT FK_DeployPlanId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_PurchaseApplyId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_PurchaseApplyDetail DROP CONSTRAINT FK_PurchaseApplyId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadDrain_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadDrainReport DROP CONSTRAINT FK_RoadDrain_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadDrillReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadDrillReport DROP CONSTRAINT FK_RoadDrillReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FKRoadDumpReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadDumpReport DROP CONSTRAINT FKRoadDumpReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadElseReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadElseReport DROP CONSTRAINT FK_RoadElseReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadInterlock_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadInterlockReport DROP CONSTRAINT FK_RoadInterlock_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadMixerReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadMixerReport DROP CONSTRAINT FK_RoadMixerReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_RoadTeamReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_RoadTeamReport DROP CONSTRAINT FK_RoadTeamReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ShipElseReport_EqutId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ShipElseReport DROP CONSTRAINT FK_ShipElseReport_EqutId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ShipFlatReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ShipFlatReport DROP CONSTRAINT FK_ShipFlatReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ShipGrapReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ShipGrapReport DROP CONSTRAINT FK_ShipGrapReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ShipMudReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ShipMudReport DROP CONSTRAINT FK_ShipMudReport_EquId
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ShipTeamReport_EquId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_ShipTeamReport DROP CONSTRAINT FK_ShipTeamReport_EquId
GO

--ɾ���� 
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_DeployPlan') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_DeployPlan
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Acceptance') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Acceptance
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_AcceptanceDetail') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_AcceptanceDetail
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Alloc') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Alloc
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_Lease') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_Lease
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_PurchaseApply') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_PurchaseApply
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_PurchaseApplyDetail') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_PurchaseApplyDetail
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadDrainReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadDrainReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadDrillReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadDrillReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadDumpReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadDumpReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadElseReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadElseReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadInterlockReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadInterlockReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadMixerReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadMixerReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_RoadTeamReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_RoadTeamReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ShipElseReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ShipElseReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ShipFlatReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ShipFlatReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ShipGrapReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ShipGrapReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ShipMudReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ShipMudReport
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_ShipTeamReport') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_ShipTeamReport
GO

--�����豸����ƻ��� 
CREATE TABLE Equ_DeployPlan ( 
	Id nvarchar(500) NOT NULL,
	RequirePlanId nvarchar(500) NOT NULL,    --  ����ƻ�Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸ID 
	Code nvarchar(500) NOT NULL,    --  �ƻ���� 
	PrjId nvarchar(500) NOT NULL,    --  ��ĿId 
	TaskId nvarchar(500),    --  ����� 
	EquipmentSource nvarchar(500),    --  �豸��Դ 
	Sump decimal(18,3) NOT NULL,    --  ���� 
	BudQuantity decimal(18,3) NOT NULL,    --  ����Ԥ�㹤���� 
	BudOilWear decimal(18,3) NOT NULL,    --  ����Ԥ���ͺ� 
	EnterDate datetime,    --  ����ʱ�� 
	EnterArea nvarchar(500),    --  �����ص� 
	OutDate datetime,    --  ����ʱ�� 
	OutArea nvarchar(500),    --  �����ص� 
	MachineTeam decimal(18,3),    --  ̨�� 
	OutDepId int,    --  �������� 
	InDepId int,    --  ���벿�� 
	ApplyDate datetime,    --  ����������� 
	ArriveDate datetime,    --  ��ٵ�λ���� 
	MaintenanceState nvarchar(50),    --  �豸����״̬ 
	FlowState int NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--�����豸���ձ�
CREATE TABLE Equ_Acceptance ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	PurchaseCode nvarchar(64),    --  �ɹ������ 
	Acceptor varchar(8),    --  ������ 
	AcceptDate datetime DEFAULT GETDATE() NOT NULL,    --  ����ʱ�� 
	FlowState int DEFAULT -1 NOT NULL    --  ����״̬ 
)
GO
--�����豸������ϸ��
CREATE TABLE Equ_AcceptanceDetail ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	AcceptanceId nvarchar(500),    --  ���յ�Id 
	ResId nvarchar(500),
	TypeId nvarchar(500) NOT NULL,
	Specification nvarchar(500),    --  ����ͺ� 
	ManufacturerId int,    --  �������� 
	SupplierId int,    --  ��Ӧ�� 
	Qty int DEFAULT 1 NOT NULL,    --  ���� 
	UnitPrice decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	TechnicalParameter nvarchar(500),    --  �������� 
	Info nvarchar(max),    --  ������� 
	Note nvarchar(max)    --  ��ע 
)
GO
--�����豸������
CREATE TABLE Equ_Alloc ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	DeployPlanId nvarchar(500),    --  ����ƻ�Id 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸Id 
	ShipEquChargeMan varchar(8),    --  �����豸�������� 
	EquState int NOT NULL,
	CalloutDepId int,    --  ������λ 
	CallouEquAdmin varchar(8),    --  ���������豸����Ա 
	CalloutEquChargeMan varchar(8),    --  �������Ÿ����� 
	CallinDepId int,    --  ���뵥λ 
	CallinEquAdmin varchar(8),    --  ���뵥λ�豸����Ա 
	CallinEquChargeMan varchar(8),    --  ���뵥λ������ 
	Receiver varchar(8),    --  ������ 
	AllocDate datetime,    --  �������� 
	FlowState int NOT NULL    --  ����״̬ 
)
GO
--�����豸���ޱ�
CREATE TABLE Equ_Lease ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	DeployPlanId nvarchar(500),    --  ����ƻ�Id 
	Code nvarchar(500) NOT NULL,    --  ���޵��� 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸Id 
	LeaseType char(1),    --  ���޷�ʽ��A��ʾ���⣬B��ʾ���� 
	ACorpId int,    --  ���õ�λ 
	BCorpId int,    --  ���ⵥλ 
	StartDate datetime,    --  ����ʱ�� 
	EndDate datetime,    --  ͣ��ʱ�� 
	Duration nvarchar(50),    --  ����ʱ�� 
	ContractId nvarchar(500),    --  ���ú�ͬId 
	Reason nvarchar(max),    --  ����ԭ�� 
	Cost decimal(18,3),    --  ���÷��� 
	ChargeMan varchar(8),    --  ������ 
	Note nvarchar(max),    --  ��ע 
	FlowState int NOT NULL    --  ����״̬ 
)
GO
--�����̶��ʲ��ɹ������
CREATE TABLE Equ_PurchaseApply ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	DeployPlanId nvarchar(500),    --  ����ƻ�Id 
	ApplyCode nvarchar(500),    --  ������ 
	Applicant varchar(8) NOT NULL,    --  ������ 
	ApplyDate datetime NOT NULL,    --  �������� 
	FlowState int NOT NULL    --  ����״̬ 
)
GO
--�����̶��ʲ��ɹ�������ϸ��
CREATE TABLE Equ_PurchaseApplyDetail ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	PurchaseApplyId nvarchar(500) NOT NULL,    --  �ɹ�����Id 
	ResId nvarchar(500) NOT NULL,    --  ��ԴId 
	Quantity int NOT NULL,    --  �������� 
	UnitPrice decimal(18,3) NOT NULL,    --  Ԥ�Ƶ��� 
	SuggestFactory nvarchar(500),    --  ���鳧�� 
	RequireReason nvarchar(max),    --  ����ԭ�� 
	ArriveDate datetime,    --  �ƻ��������� 
	ArrivePlace nvarchar(500)    --  �����ص� 
)
GO
--������ˮ���豸�ϱ���
CREATE TABLE Equ_RoadDrainReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ����� 
	SubcontractGroup nvarchar(500),    --  �ְ����� 
	ConstructionQty decimal(18,3),    --  ʩ������ 
	SubcontractChargeMan varchar(8),    --  �ְ��ֳ������� 
	OwnerOperator varchar(8),    --  �׷�ʩ��Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--������׻��ϱ���
CREATE TABLE Equ_RoadDrillReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ����� 
	Location nvarchar(500),    --  λ�� 
	Uom nvarchar(50),    --  ������λ 
	ConstructPlace nvarchar(500),    --  ʩ���ص� 
	DrillCount int DEFAULT 0 NOT NULL,    --  ���� 
	TotalLength decimal(18,3) DEFAULT 0.0 NOT NULL,    --  �ܳ� 
	EquipmentStatus nvarchar(500),    --  �豸״�� 
	MeasureUser varchar(8),    --  ����Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--������ж���ϱ���
CREATE TABLE Equ_RoadDumpReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ����� 
	WeighbridgeRoom nvarchar(500),    --  �ذ��� 
	Sn nvarchar(500),    --  ��ˮ�� 
	TruckNo nvarchar(500),    --  ���� 
	CargoNo nvarchar(500),    --  ���� 
	GrossWeigh decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ë�� 
	BareWeigh decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	NetWeigh decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	CubeQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	TruckQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	WeighbridgeUser varchar(8),    --  ����Ա 
	GrossWeighDate datetime,    --  ë������ 
	GrossWeighTime nvarchar(50),    --  ë��ʱ�� 
	DiscardPlace nvarchar(500),    --  �����ص� 
	StoneDumperId nvarchar(500),    --  ��ʯ��Id 
	Note nvarchar(max),    --  ��ע 
	FlowState int DEFAULT -1 NOT NULL    --  ����״̬ 
)
GO
--�����������豸�ϱ���
CREATE TABLE Equ_RoadElseReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ����� 
	SubcontractGroup nvarchar(500),    --  �ְ����� 
	Qty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	SubcontractChargeMan varchar(8),    --  �ְ��ֳ������� 
	OwnerOperator varchar(8),    --  �׷�ʩ��Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--����Ԥ���������ϱ���
CREATE TABLE Equ_RoadInterlockReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ�����Id 
	SubcontractGroup nvarchar(500),    --  �ְ����� 
	Qty decimal(18,3),    --  ���� 
	SubcontractChargeMan varchar(8),    --  �ְ��ֳ������� 
	OwnerOperator varchar(8),    --  �׷������� 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--�������賵�ϱ���
CREATE TABLE Equ_RoadMixerReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	TaskId nvarchar(500),    --  �ֲ����� 
	Driver varchar(8),    --  ˾�� 
	TruckQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	CubeQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���ⷽ�� 
	ExworksUser varchar(8),    --  ����ȷ���� 
	AffirmCubeQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  �ֳ�ȷ�Ϸ��� 
	Associater nvarchar(20),    --  �ֳ�������(ϵͳ��) 
	ChargeMan varchar(8),    --  �ֳ������� 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--����½���豸��̨���ϱ���
CREATE TABLE Equ_RoadTeamReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	ReportDate datetime NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	PrjId nvarchar(500),    --  ��ĿId 
	BudTask nvarchar(500),    --  �ֲ����� 
	Motorcade nvarchar(500),    --  ���� 
	Uom nvarchar(500),    --  ������λ 
	TeamTime decimal(18,3) NOT NULL,    --  ̨��ʱ�� 
	TeamQty decimal(18,3) NOT NULL,    --  ̨������ 
	ConstructionPlace nvarchar(500),    --  ʩ���ص� 
	ConstructionContent nvarchar(500),    --  ʩ������ 
	EquipmentStatus nvarchar(500),    --  �豸״�� 
	ConstructionUser varchar(8),    --  �ֳ�ʩ��Ա 
	Note nvarchar(max),    --  ��ע 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ����ʱ�� 
	SubcontractTeam nvarchar(500),    --  �ְ����� 
	SubconstractChargeMan nvarchar(50),    --  �ְ��ֳ������� 
	OwnerWorker nvarchar(50),    --  �׷�ʩ��Ա 
	Type char(1) NOT NULL,    --  ���ͣ�G-�ھ����L-װ�ػ�,E-�����豸 
	FlowState int NOT NULL    --  ����״̬ 
)
GO
--�����������ϱ���
CREATE TABLE Equ_ShipElseReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	ConstructionPlace nvarchar(500),    --  ʩ������ 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ����ʱ�� 
	ConstructionDuration decimal(10,2) DEFAULT 0.0 NOT NULL,    --  ʩ��ʱ�� 
	Qty decimal(10,2) DEFAULT 0.0 NOT NULL,    --  ���� 
	BillingUser varchar(8),    --  ����Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--����ƽ�崬�ϱ���
CREATE TABLE Equ_ShipFlatReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	PrjId nvarchar(500),    --  ��ĿId 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	ConstructionPlace nvarchar(500),    --  ʩ������ 
	CabinCapacity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ����ʱ�� 
	ConstructionDuration decimal(18,3) DEFAULT 0.0,    --  ʩ��ʱ�� 
	ShipCount int DEFAULT 1 NOT NULL,    --  ���� 
	Quantity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	DeductQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  �۷� 
	CompleteQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ������ɷ��� 
	BillingUser varchar(8),    --  ����Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--����ץ�����ϱ���
CREATE TABLE Equ_ShipGrapReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	PrjId nvarchar(500),    --  ��ĿId 
	ConstructionPlace nvarchar(500),    --  ��Ŀ���� 
	Qty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	ConstructionDuration decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ʩ��ʱ�� 
	MudShipId nvarchar(500),    --  ���ബId 
	CabinCapacity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ����ʱ�� 
	MudDuration decimal(18,3) DEFAULT 0.0,    --  װ��ʱ����Сʱ�� 
	DeductQuantity decimal(18,3),    --  �۷� 
	MudTotalQuantity decimal(18,3) DEFAULT 0.0,    --  �ವ�ܷ��� 
	BillingUser varchar(8),    --  ����Ա 
	FlowState int DEFAULT -1,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--�����ವ���ϱ���
CREATE TABLE Equ_ShipMudReport ( 
	Id nvarchar(500) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	ReportDate datetime DEFAULT GETDATE() NOT NULL,    --  �ϱ����� 
	ConstructionDate datetime,    --  ʩ������ 
	PrjId nvarchar(500),    --  ��ĿId 
	ConstructionPlace nvarchar(500),    --  ʩ������ 
	CabinCapacity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ����ʱ�� 
	ConstructionDuration decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ʩ��ʱ�� 
	DeductQuantity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  �۷� 
	MudTotalQty decimal(18,3) DEFAULT 0.0 NOT NULL,    --  �ವ�ܷ��� 
	BillingUser varchar(8),    --  ����Ա 
	FlowState int DEFAULT -1 NOT NULL,    --  ����״̬ 
	Note nvarchar(max)    --  ��ע 
)
GO
--����������̨���ϱ���
CREATE TABLE Equ_ShipTeamReport ( 
	Id nvarchar(50) NOT NULL,    --  Id 
	EquipmentId nvarchar(500),    --  �豸Id 
	ConstructionDate datetime,    --  ʩ������ 
	ReportDate datetime NOT NULL,    --  �ϱ����� 
	PrjId nvarchar(500),    --  ��ĿId 
	ConstructionPlace nvarchar(500),    --  ʩ������ 
	HoldCapacity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	StartDate datetime,    --  ��ʼʱ�� 
	EndDate datetime,    --  ���ʱ�� 
	MachineTeamCount decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ̨���� 
	MachineTeamDuration decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ̨��ʱ�� 
	Quantity decimal(18,3) DEFAULT 0.0 NOT NULL,    --  ���� 
	BillingUser varchar(8),    --  ����Ա 
	Type char(1) NOT NULL,    --  ���ͣ�D-��������E-������ 
	Note nvarchar(max),    --  ��ע 
	FlowState int DEFAULT -1 NOT NULL    --  ����״̬ 
)
GO

--�������� 
ALTER TABLE Equ_DeployPlan ADD CONSTRAINT PK_Equ_DeploymentPlan 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Acceptance ADD CONSTRAINT PK_Equ_Acceptance 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_AcceptanceDetail ADD CONSTRAINT PK_Equ_AcceptanceDetail 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Alloc ADD CONSTRAINT PK_Equ_Alloc 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_Lease ADD CONSTRAINT PK_Equ_Lease 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_PurchaseApply ADD CONSTRAINT PK_Equ_FixedPurchaseApply 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_PurchaseApplyDetail ADD CONSTRAINT PK_Equ_PurchaseApplyDetail 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadDrainReport ADD CONSTRAINT PK_Equ_RoadDrainRpt 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadDrillReport ADD CONSTRAINT PK_Equ_RoadDrillReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadDumpReport ADD CONSTRAINT PK_Equ_RoadDumpReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadElseReport ADD CONSTRAINT PK_Equ_RoadElseReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadInterlockReport ADD CONSTRAINT PK_Equ_RoadInterlockReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadMixerReport ADD CONSTRAINT PK_Equ_RoadMixerReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_RoadTeamReport ADD CONSTRAINT PK_Equ_RoadTeamReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ShipElseReport ADD CONSTRAINT PK_Equ_ShipElseReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ShipFlatReport ADD CONSTRAINT PK_Equ_ShipFlatReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ShipGrapReport ADD CONSTRAINT PK_Equ_ShipGrapReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ShipMudReport ADD CONSTRAINT PK_Equ_ShipMudReport 
	PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE Equ_ShipTeamReport ADD CONSTRAINT PK_Equ_ShipQuantitiesReport 
	PRIMARY KEY CLUSTERED (Id)
GO

--�������
ALTER TABLE Equ_DeployPlan ADD CONSTRAINT FK_Deploy_RequirePlanId 
	FOREIGN KEY (RequirePlanId) REFERENCES Equ_RequirePlan (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_DeployPlan ADD CONSTRAINT FK_DeployPlan_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_AcceptanceDetail ADD CONSTRAINT FK_AcceptanceDetail_AcceptanceId 
	FOREIGN KEY (AcceptanceId) REFERENCES Equ_Acceptance (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Alloc ADD CONSTRAINT FK_Alloc_DeployPlanId 
	FOREIGN KEY (DeployPlanId) REFERENCES Equ_DeployPlan (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_Lease ADD CONSTRAINT FK_Lease_DeployPlanId 
	FOREIGN KEY (DeployPlanId) REFERENCES Equ_DeployPlan (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_PurchaseApply ADD CONSTRAINT FK_DeployPlanId 
	FOREIGN KEY (DeployPlanId) REFERENCES Equ_DeployPlan (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_PurchaseApplyDetail ADD CONSTRAINT FK_PurchaseApplyId 
	FOREIGN KEY (PurchaseApplyId) REFERENCES Equ_PurchaseApply (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadDrainReport ADD CONSTRAINT FK_RoadDrain_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadDrillReport ADD CONSTRAINT FK_RoadDrillReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadDumpReport ADD CONSTRAINT FKRoadDumpReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadElseReport ADD CONSTRAINT FK_RoadElseReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadInterlockReport ADD CONSTRAINT FK_RoadInterlock_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadMixerReport ADD CONSTRAINT FK_RoadMixerReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_RoadTeamReport ADD CONSTRAINT FK_RoadTeamReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ShipElseReport ADD CONSTRAINT FK_ShipElseReport_EqutId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ShipFlatReport ADD CONSTRAINT FK_ShipFlatReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ShipGrapReport ADD CONSTRAINT FK_ShipGrapReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ShipMudReport ADD CONSTRAINT FK_ShipMudReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
ALTER TABLE Equ_ShipTeamReport ADD CONSTRAINT FK_ShipTeamReport_EquId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO

--����ע��
EXEC sp_addextendedproperty 'MS_Description', '�豸����ƻ�', 'Schema', dbo, 'table', Equ_DeployPlan
GO
EXEC sp_addextendedproperty 'MS_Description', '����ƻ�Id', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', RequirePlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸ID', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ƻ����', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�����', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸��Դ', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', EquipmentSource
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', Sump
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ԥ�㹤����', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', BudQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ԥ���ͺ�', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', BudOilWear
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', EnterDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ص�', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', EnterArea
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', OutDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ص�', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', OutArea
GO
EXEC sp_addextendedproperty 'MS_Description', '̨��', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', MachineTeam
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', OutDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '���벿��', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', InDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '�����������', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', ApplyDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ٵ�λ����', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', ArriveDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸����״̬', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', MaintenanceState
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_DeployPlan, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_Acceptance, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�ɹ������', 'Schema', dbo, 'table', Equ_Acceptance, 'column', PurchaseCode
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_Acceptance, 'column', Acceptor
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_Acceptance, 'column', AcceptDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Acceptance, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '���յ�Id', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', AcceptanceId
GO

EXEC sp_addextendedproperty 'MS_Description', '����ͺ�', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', Specification
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', ManufacturerId
GO
EXEC sp_addextendedproperty 'MS_Description', '��Ӧ��', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', SupplierId
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', Qty
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', UnitPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', TechnicalParameter
GO
EXEC sp_addextendedproperty 'MS_Description', '�������', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', Info
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_AcceptanceDetail, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_Alloc, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '����ƻ�Id', 'Schema', dbo, 'table', Equ_Alloc, 'column', DeployPlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_Alloc, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�����豸��������', 'Schema', dbo, 'table', Equ_Alloc, 'column', ShipEquChargeMan
GO

EXEC sp_addextendedproperty 'MS_Description', '������λ', 'Schema', dbo, 'table', Equ_Alloc, 'column', CalloutDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '���������豸����Ա', 'Schema', dbo, 'table', Equ_Alloc, 'column', CallouEquAdmin
GO
EXEC sp_addextendedproperty 'MS_Description', '�������Ÿ�����', 'Schema', dbo, 'table', Equ_Alloc, 'column', CalloutEquChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '���뵥λ', 'Schema', dbo, 'table', Equ_Alloc, 'column', CallinDepId
GO
EXEC sp_addextendedproperty 'MS_Description', '���뵥λ�豸����Ա', 'Schema', dbo, 'table', Equ_Alloc, 'column', CallinEquAdmin
GO
EXEC sp_addextendedproperty 'MS_Description', '���뵥λ������', 'Schema', dbo, 'table', Equ_Alloc, 'column', CallinEquChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_Alloc, 'column', Receiver
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_Alloc, 'column', AllocDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Alloc, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_Lease, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '����ƻ�Id', 'Schema', dbo, 'table', Equ_Lease, 'column', DeployPlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '���޵���', 'Schema', dbo, 'table', Equ_Lease, 'column', Code
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_Lease, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '���޷�ʽ��A��ʾ���⣬B��ʾ����', 'Schema', dbo, 'table', Equ_Lease, 'column', LeaseType
GO
EXEC sp_addextendedproperty 'MS_Description', '���õ�λ', 'Schema', dbo, 'table', Equ_Lease, 'column', ACorpId
GO
EXEC sp_addextendedproperty 'MS_Description', '���ⵥλ', 'Schema', dbo, 'table', Equ_Lease, 'column', BCorpId
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_Lease, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ͣ��ʱ��', 'Schema', dbo, 'table', Equ_Lease, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_Lease, 'column', Duration
GO
EXEC sp_addextendedproperty 'MS_Description', '���ú�ͬId', 'Schema', dbo, 'table', Equ_Lease, 'column', ContractId
GO
EXEC sp_addextendedproperty 'MS_Description', '����ԭ��', 'Schema', dbo, 'table', Equ_Lease, 'column', Reason
GO
EXEC sp_addextendedproperty 'MS_Description', '���÷���', 'Schema', dbo, 'table', Equ_Lease, 'column', Cost
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_Lease, 'column', ChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_Lease, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_Lease, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '����ƻ�Id', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', DeployPlanId
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', ApplyCode
GO
EXEC sp_addextendedproperty 'MS_Description', '������', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', Applicant
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', ApplyDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_PurchaseApply, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�ɹ�����Id', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', PurchaseApplyId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ԴId', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', ResId
GO
EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�Ƶ���', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', UnitPrice
GO
EXEC sp_addextendedproperty 'MS_Description', '���鳧��', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', SuggestFactory
GO
EXEC sp_addextendedproperty 'MS_Description', '����ԭ��', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', RequireReason
GO
EXEC sp_addextendedproperty 'MS_Description', '�ƻ���������', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', ArriveDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ص�', 'Schema', dbo, 'table', Equ_PurchaseApplyDetail, 'column', ArrivePlace
GO
EXEC sp_addextendedproperty 'MS_Description', '��ˮ���豸�ϱ�', 'Schema', dbo, 'table', Equ_RoadDrainReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ�����', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', SubcontractGroup
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', ConstructionQty
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ��ֳ�������', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', SubcontractChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '�׷�ʩ��Ա', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', OwnerOperator
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadDrainReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '��׻��ϱ�', 'Schema', dbo, 'table', Equ_RoadDrillReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', 'λ��', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', Location
GO
EXEC sp_addextendedproperty 'MS_Description', '������λ', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', Uom
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ���ص�', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', ConstructPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', DrillCount
GO
EXEC sp_addextendedproperty 'MS_Description', '�ܳ�', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', TotalLength
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸״��', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', EquipmentStatus
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', MeasureUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadDrillReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '��ж���ϱ�', 'Schema', dbo, 'table', Equ_RoadDumpReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ذ���', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', WeighbridgeRoom
GO
EXEC sp_addextendedproperty 'MS_Description', '��ˮ��', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', Sn
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', TruckNo
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', CargoNo
GO
EXEC sp_addextendedproperty 'MS_Description', 'ë��', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', GrossWeigh
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', BareWeigh
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', NetWeigh
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', CubeQty
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', TruckQty
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', WeighbridgeUser
GO
EXEC sp_addextendedproperty 'MS_Description', 'ë������', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', GrossWeighDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ë��ʱ��', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', GrossWeighTime
GO
EXEC sp_addextendedproperty 'MS_Description', '�����ص�', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', DiscardPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʯ��Id', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', StoneDumperId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadDumpReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '�����豸�ϱ�', 'Schema', dbo, 'table', Equ_RoadElseReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ�����', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', SubcontractGroup
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', Qty
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ��ֳ�������', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', SubcontractChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '�׷�ʩ��Ա', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', OwnerOperator
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadElseReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���������ϱ�', 'Schema', dbo, 'table', Equ_RoadInterlockReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����Id', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ�����', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', SubcontractGroup
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', Qty
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ��ֳ�������', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', SubcontractChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '�׷�������', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', OwnerOperator
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadInterlockReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '���賵�ϱ�', 'Schema', dbo, 'table', Equ_RoadMixerReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', TaskId
GO
EXEC sp_addextendedproperty 'MS_Description', '˾��', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', Driver
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', TruckQty
GO
EXEC sp_addextendedproperty 'MS_Description', '���ⷽ��', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', CubeQty
GO
EXEC sp_addextendedproperty 'MS_Description', '����ȷ����', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', ExworksUser
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ�ȷ�Ϸ���', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', AffirmCubeQty
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ�������(ϵͳ��)', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', Associater
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ�������', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', ChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadMixerReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '½���豸��̨���ϱ�', 'Schema', dbo, 'table', Equ_RoadTeamReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֲ�����', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', BudTask
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', Motorcade
GO
EXEC sp_addextendedproperty 'MS_Description', '������λ', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', Uom
GO
EXEC sp_addextendedproperty 'MS_Description', '̨��ʱ��', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', TeamTime
GO
EXEC sp_addextendedproperty 'MS_Description', '̨������', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', TeamQty
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ���ص�', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', ConstructionContent
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸״��', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', EquipmentStatus
GO
EXEC sp_addextendedproperty 'MS_Description', '�ֳ�ʩ��Ա', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', ConstructionUser
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ�����', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', SubcontractTeam
GO
EXEC sp_addextendedproperty 'MS_Description', '�ְ��ֳ�������', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', SubconstractChargeMan
GO
EXEC sp_addextendedproperty 'MS_Description', '�׷�ʩ��Ա', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', OwnerWorker
GO
EXEC sp_addextendedproperty 'MS_Description', '���ͣ�G-�ھ����L-װ�ػ�,E-�����豸', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', Type
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_RoadTeamReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '���������ϱ�', 'Schema', dbo, 'table', Equ_ShipElseReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ��ʱ��', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', ConstructionDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', Qty
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', BillingUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_ShipElseReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', CabinCapacity
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ��ʱ��', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', ConstructionDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', ShipCount
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '�۷�', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', DeductQty
GO
EXEC sp_addextendedproperty 'MS_Description', '������ɷ���', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', CompleteQty
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', BillingUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_ShipFlatReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', 'ץ�����ϱ�', 'Schema', dbo, 'table', Equ_ShipGrapReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', '��Ŀ����', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', Qty
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ��ʱ��', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', ConstructionDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '���ബId', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', MudShipId
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', CabinCapacity
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'װ��ʱ����Сʱ��', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', MudDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '�۷�', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', DeductQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '�ವ�ܷ���', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', MudTotalQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', BillingUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_ShipGrapReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '�ವ���ϱ�', 'Schema', dbo, 'table', Equ_ShipMudReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', CabinCapacity
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ��ʱ��', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', ConstructionDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '�۷�', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', DeductQuantity
GO
EXEC sp_addextendedproperty 'MS_Description', '�ವ�ܷ���', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', MudTotalQty
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', BillingUser
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', FlowState
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_ShipMudReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '������̨���ϱ�', 'Schema', dbo, 'table', Equ_ShipTeamReport
GO
EXEC sp_addextendedproperty 'MS_Description', 'Id', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸Id', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', ConstructionDate
GO
EXEC sp_addextendedproperty 'MS_Description', '�ϱ�����', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', ReportDate
GO
EXEC sp_addextendedproperty 'MS_Description', '��ĿId', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', PrjId
GO
EXEC sp_addextendedproperty 'MS_Description', 'ʩ������', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', ConstructionPlace
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', HoldCapacity
GO
EXEC sp_addextendedproperty 'MS_Description', '��ʼʱ��', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', StartDate
GO
EXEC sp_addextendedproperty 'MS_Description', '���ʱ��', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', EndDate
GO
EXEC sp_addextendedproperty 'MS_Description', '̨����', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', MachineTeamCount
GO
EXEC sp_addextendedproperty 'MS_Description', '̨��ʱ��', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', MachineTeamDuration
GO
EXEC sp_addextendedproperty 'MS_Description', '����', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', Quantity
GO
EXEC sp_addextendedproperty 'MS_Description', '����Ա', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', BillingUser
GO
EXEC sp_addextendedproperty 'MS_Description', '���ͣ�D-��������E-������', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', Type
GO
EXEC sp_addextendedproperty 'MS_Description', '��ע', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', Note
GO
EXEC sp_addextendedproperty 'MS_Description', '����״̬', 'Schema', dbo, 'table', Equ_ShipTeamReport, 'column', FlowState
GO

--�����豸��Ա��			lhy			2013-09-17		17:00
--ɾ�����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_EquipmentUserId') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Equ_EquipmentUser DROP CONSTRAINT FK_EquipmentUserId
GO
--ɾ����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Equ_EquipmentUser') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Equ_EquipmentUser
GO
--�����豸��Ա��
CREATE TABLE Equ_EquipmentUser ( 
	Id nvarchar(500) NOT NULL,    --  �豸��ԱId 
	EquipmentId nvarchar(500) NOT NULL,    --  �豸ID 
	UserCode varchar(8) NOT NULL    --  ��Ա��� 
)
GO
--�������� 
ALTER TABLE Equ_EquipmentUser ADD CONSTRAINT PK_Equ_EquipmentUser 
	PRIMARY KEY CLUSTERED (Id)
GO
--�������
ALTER TABLE Equ_EquipmentUser ADD CONSTRAINT FK_EquipmentUserId 
	FOREIGN KEY (EquipmentId) REFERENCES Equ_Equipment (Id)
	ON DELETE CASCADE
GO
--����ֶ�ע��
EXEC sp_addextendedproperty 'MS_Description', '�豸��Ա', 'Schema', dbo, 'table', Equ_EquipmentUser
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸��ԱId', 'Schema', dbo, 'table', Equ_EquipmentUser, 'column', Id
GO
EXEC sp_addextendedproperty 'MS_Description', '�豸ID', 'Schema', dbo, 'table', Equ_EquipmentUser, 'column', EquipmentId
GO
EXEC sp_addextendedproperty 'MS_Description', '��Ա���', 'Schema', dbo, 'table', Equ_EquipmentUser, 'column', UserCode
GO

--��ģ����������豸����˵�
INSERT INTO PT_MK VALUES
('26','�豸����','','y',19,'MenuIco/13.gif',24913,6,'0','0','','1')
INSERT INTO PT_MK VALUES
('2601','�豸���','/Equ/Type/EquipmentTypeList.aspx','y',1,'',24914,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('2602','�豸̨��','','y',2,'',24915,2,'0','0','','1')
INSERT INTO PT_MK VALUES
('260201','̨��ά��','/Equ/Equipment/EquipmentList.aspx?action=edit','y',1,'',24916,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('260202','̨�˲�ѯ','/Equ/Equipment/EquipmentList.aspx?action=Query','y',2,'',24920,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('2603','�����豸','','y',3,'',24921,4,'0','0','','1')
INSERT INTO PT_MK VALUES
('260301','�����ͺĹ���','','y',1,'',24922,2,'0','0','','1')
INSERT INTO PT_MK VALUES
('26030101','�ͺ�Ԥ�����','/Equ/ShipOilWear/BudOilWearList.aspx','y',1,'',24923,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26030102','��������','/Equ/ShipOilWear/RefuelApplyList.aspx','y',1,'',24926,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('260305','����ά�޹���','','y',5,'',24933,3,'0','0','','1')
INSERT INTO PT_MK VALUES
('26030501','ά������','/Equ/Repair/RepairApplyList.aspx?equipmentType=0','y',2,'',24934,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26030502','ά���ϱ�','/Equ/Repair/RepairReportList.aspx?equipmentType=0','y',3,'',24939,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26030503','ά�޼ƻ�','/Equ/Repair/RepairPlanList.aspx?equipmentType=0','y',1,'',24940,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('2604','½���豸','','y',4,'',24935,2,'0','0','','1')
INSERT INTO PT_MK VALUES
('260401','�ͺĹ���','','y',0,'',24936,2,'0','0','','1')
INSERT INTO PT_MK VALUES
('26040101','���Ǽ�','/Equ/OilWearManage/EquOilEnter.aspx','y',1,'',24937,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26040102','����Ǽ�','/Equ/OilWearManage/EquOilOut.aspx','y',2,'',24938,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('260402','�豸ά�޹���','','y',2,'',24949,3,'0','0','','1')
INSERT INTO PT_MK VALUES
('26040201','ά�޼ƻ�','/Equ/Repair/RepairPlanList.aspx?equipmentType=1','y',1,'',24950,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26040202','ά������','/Equ/Repair/RepairApplyList.aspx?equipmentType=1','y',2,'',24951,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('26040203','ά���ϱ�','/Equ/Repair/RepairReportList.aspx?equipmentType=1','y',3,'',24952,0,'0','0','','1')
GO
INSERT INTO PT_MK VALUES
('2605','�豸����������','','y',5,'',24941,2,'0','0','','1')
INSERT INTO PT_MK VALUES
('260501','�豸����ƻ�','/Equ/RequirePlan/RequirePlanList.aspx','y',1,'',24942,0,'0','0','','1')
INSERT INTO PT_MK VALUES
('2606','�豸����','/Equ/EquipmentDiscard/EquDiscardList.aspx','y',6,'',24946,0,'0','0','','1')
--ģ����������豸����˵�
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260302','��������','','y','2','','24924','5','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26030201','ץ�����ϱ�','/Equ/ShipGrapReport/ShipGrapReportList.aspx','y','1','','24925','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26030202','��̨���ϱ�','/Equ/ShipTeamReport/ShipTeamReportList.aspx','y','5','','24947','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26030203','�ವ���ϱ�','/Equ/ShipMudReport/ShipMudReportList.aspx','y','2','','24957','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26030204','ƽ�崬�ϱ�','/Equ/ShipFlatReport/ShipFlatReportList.aspx','y','3','','24959','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26030205','�������ϱ�','/Equ/ShipElseReport/ShipElseReportList.aspx','y','4','','24960','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260403','��������','','y','3','','24955','7','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040301','��̨���ϱ�','/Equ/RoadTeamReport/RoadTeamReportList.aspx','y','7','','24956','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040302','��ж���ϱ�','/Equ/RoadDumpReport/RoadDumpReportList.aspx','y','1','','24961','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040303','��׻��ϱ�','/Equ/RoadDrillReport/RoadDrillReportList.aspx','y','2','','24962','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040304','���賵�ϱ�','/Equ/RoadMixerReport/RoadMixerReportList.aspx','y','3','','24964','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040305','��ˮ���豸�ϱ�','/Equ/RoadDrainReport/RoadDrainReportList.aspx','y','4','','24965','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040306','Ԥ���������ϱ�','/Equ/RoadInterlockReport/RoadInterlockReportList.aspx','y','5','','24966','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('26040307','�����豸�ϱ�','/Equ/RoadElseReport/RoadElseReportList.aspx','y','6','','24967','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260502','�豸����ƻ�','/Equ/EquDeployPlan/EquDeployPlanList.aspx','y','2','','24953','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260503','�豸����','/Equ/EquLease/EquLeaseList.aspx','y','3','','24954','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260504','�̶��ʲ��ɹ�����','/Equ/PurchaseApply/PurchaseApplyList.aspx','y','4','','24958','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260505','�豸����','/Equ/EquAlloc/EquAllocList.aspx','y','5','','24963','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260506','�豸����','/Equ/EquAcceptance/EquAcceptanceList.aspx','y','6','','24995','0','0','0','','1'); 
GO
--ģ����������豸��Ա��˵�
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('260203','�豸��Ա','/Equ/Equipment/EquipmentUser.aspx','y','3','','24998','0','0','0','','1'); 
GO
--ģ����б������������豸������˵�
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('8809','�豸ͳ�Ʊ���','','y','10','','24943','8','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880901','�����豸����','','y','1','','24944','11','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090101','�����ͺķ���','/Equ/Report/Ship/ShipOilWearAnalysis.aspx','y','1','','24968','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090102','�������뵥','/Equ/Report/Ship/RefuelApply.aspx','y','2','','24969','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090103','������������¼��','/Equ/Report/Ship/RefuelRecord.aspx','y','3','','24970','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090104','ά�ޱ����ƻ���ɱ�','/Equ/Report/Ship/RepairPlanComplete.aspx','y','4','','24971','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090105','ά�ޱ�����һ����','/Equ/Report/Ship/RepairCost.aspx?equipmentType=0','y','5','','24972','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090106','��������������(��̨���ϱ�)','/Equ/Report/Ship/ShipTeamReport.aspx?type=D','y','6','','24973','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090107','��������������(��̨���ϱ�)','/Equ/Report/Ship/ShipTeamReport.aspx?type=E','y','7','','24974','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090108','ץ�����ವ��������','/Equ/Report/Ship/GrabMudReport.aspx','y','8','','24975','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090109','�ವ��������','/Equ/Report/Ship/MudShipReport.aspx','y','9','','24976','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090110','ƽ�崬������','/Equ/Report/Ship/ShipFlatReport.aspx','y','10','','24977','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090111','������������','/Equ/Report/Ship/ShipElseReport.aspx','y','11','','24978','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880902','½���豸����','','y','2','','24945','13','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090201','�����ͺı���','/Equ/Report/Land/OilWearSummary.aspx','y','1','','24948','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090202','ά�ޱ�����һ����','/Equ/Report/Ship/RepairCost.aspx?equipmentType=1','y','2','','24981','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090203','�豸ί��ά�ޱ���','/Equ/Report/Land/OutRepairCost.aspx','y','3','','24982','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090204','ά�ޱ����ƻ���ɱ�','/Equ/Report/Land/RepairPlanComplete.aspx','y','4','','24983','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090205','�ھ���ջ�е��������̨���ϱ���','/Equ/Report/Land/RoadTeamReport.aspx?type=G','y','5','','24984','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090206','װ�ػ��ջ�е��������̨���ϱ���','/Equ/Report/Land/RoadTeamReport.aspx?type=L','y','6','','24985','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090207','�����豸�ջ�е����������̨���ϱ���','/Equ/Report/Land/RoadTeamReport.aspx?type=E','y','7','','24986','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090208','���賵�ջ�е������','/Equ/Report/Land/RoadMixerReport.aspx','y','8','','24987','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090209','Ԥ���������ջ�е��������','/Equ/Report/Land/RoadInterlockReport.aspx','y','9','','24988','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090210','��ˮ���ջ�е��������','/Equ/Report/Land/RoadDrainReport.aspx','y','10','','24989','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090211','�����豸�ջ�е���������������ϱ���','/Equ/Report/Land/RoadElseReport.aspx','y','11','','24990','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090212','��ж���ջ�е������','/Equ/Report/Land/DumpReport.aspx','y','12','','24993','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090213','��׻��»��ܱ�','/Equ/Report/Land/DrillMonthReport.aspx','y','13','','24996','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880903','���ʱ���','/Salary2/DepartmentFrame.aspx?path=SaMonthReport','y','3','','24979','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880904','��Աһ����','/HR/StaffList.aspx','y','4','','24980','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880905','�����豸����ƻ�����','/Equ/Report/RequirePlanReport.aspx','y','5','','24991','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880906','�豸����ƻ�����','/Equ/Report/DeployPlanReport.aspx','y','6','','24992','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880907','�豸����̨����ϸ����','/Equ/Report/EquLeaseReport.aspx','y','7','','24994','0','0','0','','1');
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090112','�¶Ⱦ�Ӫ�������','/Equ/Report/Ship/MonthSituationReport.aspx','y','12','','24999','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('88090214','�¶Ⱦ�Ӫ�������','/Equ/Report/Land/MonthSituationReport.aspx','y','14','','25000','0','0','0','','1'); 
INSERT INTO PT_MK (C_MKDM,V_MKMC,V_CDLJ,C_BS,I_XH,V_IMG,I_ID,i_ChildNum,IsBasic,
IsMaintainable,helppath,Isdisplay) VALUES 
('880908','��Ա���ͳ�Ʊ�','/Equ/Report/Ship/SailorsAttendance.aspx','y','8','','24997','0','0','0','','1'); 

GO
--�豸�������
--�����ͺ�Ԥ��
INSERT INTO WF_BusinessCode 
VALUES('142','�����ͺ�Ԥ��','id','Equ_Ship_BudOilWear','id','FlowState',
'/Equ/ShipOilWear/BudOilWearView.aspx',NULL,'26','PrjId','Code')
INSERT INTO WF_Business_Class
VALUES('142','001','�����ͺ�Ԥ��',NEWID())
--������������
INSERT INTO WF_BusinessCode 
VALUES('143','������������','id','Equ_Ship_RefuelApply','id','FlowState',
'/Equ/ShipOilWear/RefuelApplyView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('143','001','������������',NEWID())
--ά�ޱ����ƻ����
INSERT INTO WF_BusinessCode 
VALUES('145','ά�ޱ����ƻ����','Id','Equ_RepairPlan','Id','FlowState',
'/Equ/Repair/RepairPlanView.aspx',NULL,'26',NULL,'Code')
INSERT INTO WF_Business_Class
VALUES('145','001','ά�ޱ����ƻ����',NEWID())
--ά������
INSERT INTO WF_BusinessCode 
VALUES('147','ά���������','Id','Equ_RepairApply','Id','FlowState',
'/Equ/Repair/RepairApplyView.aspx',NULL,'26',NULL,'Code')
INSERT INTO WF_Business_Class
VALUES('147','001','ά���������',NEWID())
--ά���ϱ�
INSERT INTO WF_BusinessCode 
VALUES('148','ά���ϱ����','Id','Equ_RepairReport','Id','FlowState',
'/Equ/Repair/RepairReportView.aspx',NULL,'26',NULL,'(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('148','001','ά���ϱ����',NEWID())
--�ͺĳ������
INSERT INTO WF_BusinessCode 
VALUES('149','�ͺĳ������','Id','Equ_OilOut','Id','FlowState',
'/Equ/OilWearManage/EquOilOutView.aspx',NULL,'26','PrjId','Code')
INSERT INTO WF_Business_Class
VALUES('149','001','�ͺĳ������',NEWID())
--�豸����ƻ����
INSERT INTO WF_BusinessCode 
VALUES('150','�豸����ƻ����','Id','Equ_RequirePlan','Id','FlowState',
'/Equ/RequirePlan/RequirePlanView.aspx',NULL,'26','PrjId','Code')
INSERT INTO WF_Business_Class
VALUES('150','001','�豸����ƻ����',NEWID())
--�豸�������
INSERT INTO WF_BusinessCode 
VALUES('151','�豸�������','Id','Equ_Discard','Id','FlowState',
'/Equ/EquipmentDiscard/EquDiscardView.aspx',NULL,'26','NULL','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('151','001','�豸�������',NEWID())
GO
--�����豸�������
--ץ�����ϱ����
INSERT INTO WF_BusinessCode 
VALUES('144','ץ�����ϱ����','Id','Equ_ShipGrapReport','Id','FlowState',
'/Equ/ShipGrapReport/ShipGrapReportView.aspx',NULL,'26','NULL','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('144','001','ץ�����ϱ����',NEWID())
--��������ƻ����
INSERT INTO WF_BusinessCode 
VALUES('146','�豸����ƻ�','Id','Equ_DeployPlan','Id','FlowState',
'/Equ/EquDeployPlan/EquDeployPlanView.aspx',NULL,'26','PrjId','Code')
INSERT INTO WF_Business_Class
VALUES('146','001','�豸����ƻ�',NEWID())
--����̨���ϱ����
INSERT INTO WF_BusinessCode 
VALUES('152','����̨���ϱ����','Id','Equ_ShipTeamReport','Id','FlowState',
'/Equ/ShipTeamReport/ShipTeamReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('152','001','����̨���ϱ����',NEWID())
--½���豸̨���ϱ����
INSERT INTO WF_BusinessCode 
VALUES('153','½���豸̨���ϱ����','Id','Equ_RoadTeamReport','Id','FlowState',
'/Equ/RoadTeamReport/RoadTeamReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('153','001','½���豸̨���ϱ����',NEWID())
--�豸�������
INSERT INTO WF_BusinessCode 
VALUES('154','�豸�������','Id','Equ_Lease','Id','FlowState',
'/Equ/EquLease/EquLeaseView.aspx',NULL,'26',NULL,'Code')
INSERT INTO WF_Business_Class
VALUES('154','001','�豸�������',NEWID())
--�̶��ʲ��ɹ����
INSERT INTO WF_BusinessCode 
VALUES('155','�̶��ʲ��ɹ����','Id','Equ_PurchaseApply','Id','FlowState',
'/Equ/PurchaseApply/PurchaseApplyView.aspx',NULL,'26',NULL,'ApplyCode')
INSERT INTO WF_Business_Class
VALUES('155','001','�̶��ʲ��ɹ����',NEWID())
--�豸�������
INSERT INTO WF_BusinessCode 
VALUES('156','�豸�������','Id','Equ_Alloc','Id','FlowState',
'/Equ/EquAlloc/EquAllocView.aspx',NULL,'26',NULL,'(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('156','001','�豸�������',NEWID())
--�ವ���ϱ����
INSERT INTO WF_BusinessCode 
VALUES('157','�ವ���ϱ����','Id','Equ_ShipMudReport','Id','FlowState',
'/Equ/ShipMudReport/ShipMudReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('157','001','�ವ���ϱ����',NEWID())
--ƽ�崬�ϱ����
INSERT INTO WF_BusinessCode 
VALUES('158','ƽ�崬�ϱ����','Id','Equ_ShipFlatReport','Id','FlowState',
'/Equ/ShipFlatReport/ShipFlatReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('158','001','ƽ�崬�ϱ����',NEWID())
--�������ϱ����
INSERT INTO WF_BusinessCode 
VALUES('159','�������ϱ����','Id','Equ_ShipElseReport','Id','FlowState',
'/Equ/ShipElseReport/ShipElseReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('159','001','�������ϱ����',NEWID())
--��ж���ϱ����
INSERT INTO WF_BusinessCode 
VALUES('160','��ж���ϱ����','Id','Equ_RoadDumpReport','Id','FlowState',
'/Equ/RoadDumpReport/RoadDumpReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('160','001','��ж���ϱ����',NEWID())
--��׻��ϱ����
INSERT INTO WF_BusinessCode 
VALUES('161','��׻��ϱ����','Id','Equ_RoadDrillReport','Id','FlowState',
'/Equ/RoadDrillReport/RoadDrillReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('161','001','��׻��ϱ����',NEWID())
--���賵�ϱ����
INSERT INTO WF_BusinessCode 
VALUES('162','���賵�ϱ����','Id','Equ_RoadMixerReport','Id','FlowState',
'/Equ/RoadMixerReport/RoadMixerReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('162','001','���賵�ϱ����',NEWID())
--��ˮ���豸�ϱ����
INSERT INTO WF_BusinessCode 
VALUES('163','��ˮ���豸�ϱ����','Id','Equ_RoadDrainReport','Id','FlowState',
'/Equ/RoadDrainReport/RoadDrainReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('163','001','��ˮ���豸�ϱ����',NEWID())
--Ԥ���������ϱ����
INSERT INTO WF_BusinessCode 
VALUES('164','Ԥ���������ϱ����','Id','Equ_RoadInterlockReport','Id','FlowState',
'/Equ/RoadInterlockReport/RoadInterlockReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('164','001','Ԥ���������ϱ����',NEWID())
--�����豸�ϱ����
INSERT INTO WF_BusinessCode 
VALUES('165','�����豸�ϱ����','Id','Equ_RoadElseReport','Id','FlowState',
'/Equ/RoadElseReport/RoadElseReportView.aspx',NULL,'26','PrjId','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('165','001','�����豸�ϱ����',NEWID())
--�豸�������
INSERT INTO WF_BusinessCode 
VALUES('166','�豸�������','Id','Equ_Acceptance','Id','FlowState',
'/Equ/EquAcceptance/EquAcceptanceView.aspx',NULL,'26','NULL','(SELECT''�鿴'')')
INSERT INTO WF_Business_Class
VALUES('166','001','�豸�������',NEWID())
GO

--��ʼ���豸����
--DELETE FROM Equ_EquipmentType
INSERT INTO Equ_EquipmentType
VALUES('4d837219-ced7-4983-b00e-6f6aa8395b95',NULL,'����',1,'001','Ship')
INSERT INTO Equ_EquipmentType
VALUES('63e3da8c-a2cc-4adf-b295-806bc8316966','4d837219-ced7-4983-b00e-6f6aa8395b95','ץ����',11,'001011','Grap')
INSERT INTO Equ_EquipmentType
VALUES('a8e4fcab-d125-43ad-9143-8baabbe02b80','4d837219-ced7-4983-b00e-6f6aa8395b95','�ವ��',12,'001012','MudBarge')
INSERT INTO Equ_EquipmentType
VALUES('9e0c17f3-8f5e-499a-ba2d-dd5c22bee54f','4d837219-ced7-4983-b00e-6f6aa8395b95','������',13,'001013','Dredger')
INSERT INTO Equ_EquipmentType
VALUES('c0cf9157-ac7b-4bc9-b00f-cf5373f3e028','4d837219-ced7-4983-b00e-6f6aa8395b95','ƽ�崬',14,'001014','Flat')
INSERT INTO Equ_EquipmentType
VALUES('091e9af3-4330-4539-be55-d7f5f0c5387c',NULL,'½���豸',2,'002','Land')
INSERT INTO Equ_EquipmentType
VALUES('b38d59b0-41d8-4b74-9596-15d342d0b7bf','091e9af3-4330-4539-be55-d7f5f0c5387c','װ�ػ�',21,'002021','Loader')
INSERT INTO Equ_EquipmentType
VALUES('1099eafd-33c7-4fa6-88e0-034040083577','091e9af3-4330-4539-be55-d7f5f0c5387c','�ھ��',22,'002022','Grab')
INSERT INTO Equ_EquipmentType
VALUES('2b809b5a-bbec-453f-a16e-65995281cbbf','091e9af3-4330-4539-be55-d7f5f0c5387c','��ж��',23,'002023','Dump')
INSERT INTO Equ_EquipmentType
VALUES('7d535951-6256-4ed7-be7c-b4f2a70fbc22','091e9af3-4330-4539-be55-d7f5f0c5387c','��׻�',24,'002024','Drill')
INSERT INTO Equ_EquipmentType
VALUES('00aed949-8b9e-4a0a-9e59-98ea62116c95','091e9af3-4330-4539-be55-d7f5f0c5387c','��ˮ��',25,'002025','Drain')
INSERT INTO Equ_EquipmentType
VALUES('240a65e1-f33e-4201-8f60-ca4edffde0ff','091e9af3-4330-4539-be55-d7f5f0c5387c','Ԥ��������',26,'002026','Interlock')
INSERT INTO Equ_EquipmentType
VALUES('5d0849c7-1701-48bb-a03c-582458d89f28','091e9af3-4330-4539-be55-d7f5f0c5387c','���賵',27,'002027','Mixer')
GO