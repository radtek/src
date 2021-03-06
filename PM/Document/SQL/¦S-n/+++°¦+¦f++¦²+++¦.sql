
/****************************
 * 旧的进度管理的表删除恢复 *
 ****************************/
IF OBJECT_ID('EPM_Task_TaskList','U') IS NULL
CREATE TABLE [dbo].[EPM_Task_TaskList](
	[NoteID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectCode] [uniqueidentifier] NULL CONSTRAINT [DF_EPM_Prj_TaskList_ProjectCode]  DEFAULT ('73447941-D2FB-4EFD-B73B-4733E693FB6D'),
	[TaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ParentTaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[TaskName] [varchar](3000) COLLATE Chinese_PRC_CI_AS NULL,
	[Quantity] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Prj_TaskList_Quantity]  DEFAULT ((0)),
	[QuantityUnit] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_EPM_Prj_TaskList_QuantityUnit]  DEFAULT (''),
	[WorkLayer] [int] NULL,
	[ChildNum] [int] NULL,
	[IsValid] [bit] NULL,
	[Cost] [decimal](18, 2) NOT NULL CONSTRAINT [DF_EPM_Prj_TaskList_Cost]  DEFAULT ((0)),
	[SynthPrice] [decimal](18, 3) NULL CONSTRAINT [DF_EPM_Prj_TaskList_SynthPrice]  DEFAULT ((0)),
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Remark] [varchar](3000) COLLATE Chinese_PRC_CI_AS NULL,
	[ContractPrice] [decimal](18, 2) NOT NULL CONSTRAINT [DF_EPM_Task_TaskList_ContractPrice]  DEFAULT ((0.0)),
	[Safety] [varchar](3000) COLLATE Chinese_PRC_CI_AS NULL,
	[Quality] [varchar](3000) COLLATE Chinese_PRC_CI_AS NULL,
	[TaskState] [tinyint] NULL,
	[Pivotal] [bit] NULL,
	[WorkDay] [int] NULL CONSTRAINT [DF_EPM_Task_TaskList_WorkDay]  DEFAULT ((0)),
	[CompleteCount] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_CompleteCount]  DEFAULT ((0)),
	[ManFee] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_ManFee]  DEFAULT ((0)),
	[MaterialFee] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_MaterialFee]  DEFAULT ((0)),
	[MachineFee] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_MachineFee]  DEFAULT ((0)),
	[JianJFee] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_JianJFee]  DEFAULT ((0)),
	[GSTotalFee] [decimal](18, 2) NULL CONSTRAINT [DF_EPM_Task_TaskList_GSTotalFee]  DEFAULT ((0)),
	[budgetCost] [decimal](18, 3) NULL CONSTRAINT [DF_EPM_Task_TaskList_budgetCost]  DEFAULT ((0)),
	[budgetPrice] [decimal](18, 3) NULL CONSTRAINT [DF_EPM_Task_TaskList_budgetPrice]  DEFAULT ((0)),
	[budgetQuantity] [decimal](18, 3) NULL CONSTRAINT [DF_EPM_Task_TaskList_budgetQuantity]  DEFAULT ((0)),
	[OrigCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[SumPrice] [decimal](18, 3) NULL CONSTRAINT [DF_EPM_Task_TaskList_SumPrice]  DEFAULT ((0)),
	[WbsType] [int] NULL,
	[IsAlter] [bit] NULL CONSTRAINT [DF_EPM_Task_TaskList_IsAlter]  DEFAULT ((0)),
	[Content] [decimal](18, 4) NULL,
	[IsContractAlter] [bit] NULL CONSTRAINT [DF_EPM_Task_TaskList_IsContractAlter]  DEFAULT ((0)),
 CONSTRAINT [PK_EPM_Prj_TaskList] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--IF OBJECT_ID('EPM_Task_Resource','U') IS NULL
--CREATE TABLE [dbo].[EPM_Task_Resource](
--	[NoteID] [int] IDENTITY(1,1) NOT NULL,
--	[ProjectCode] [uniqueidentifier] NOT NULL,
--	[TaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--	[VersionCode] [uniqueidentifier] NOT NULL,
--	[RationItem] [varchar](100) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[ResourceCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[Wastage] [decimal](18, 4) NOT NULL,
--	[UnitPrice] [decimal](18, 4) NOT NULL,
--	[Fee] [decimal](18, 3) NULL,
--	[Fee1] [decimal](18, 3) NULL,
--	[ResourceStyle] [int] NOT NULL,
--	[StepCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--	[Quantity] [decimal](18, 4) NULL,
--	[WbsType] [int] NULL,
--	[ResourceName] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
--	[ResourceUnit] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--	[Content] [decimal](18, 4) NULL
--) ON [PRIMARY]
--GO
--IF OBJECT_ID('EPM_Book_ConstructTask','U') IS NULL
--CREATE TABLE [dbo].[EPM_Book_ConstructTask](
--	[NoteID] [int] IDENTITY(1,1) NOT NULL,
--	[TaskBookCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--	[ProjectCode] [uniqueidentifier] NOT NULL,
--	[TaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[ConstructUnit] [int] NOT NULL,
--	[ConstructDate] [datetime] NOT NULL,
--	[RecordPerson] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[QualityAndSafety] [varchar](4000) COLLATE Chinese_PRC_CI_AS NULL,
--	[TodayComplete] [decimal](18, 2) NULL,
--	[WorkContent] [varchar](2000) COLLATE Chinese_PRC_CI_AS NULL,
--	[TodayWorkRemark] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
-- CONSTRAINT [PK_EPM_Book_ConstructTask] PRIMARY KEY CLUSTERED 
--(
--	[NoteID] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--IF OBJECT_ID('EPM_Book_Resource','U') IS NULL
--CREATE TABLE [dbo].[EPM_Book_Resource](
--	[NoteID] [int] IDENTITY(1,1) NOT NULL,
--	[Projectcode] [uniqueidentifier] NULL,
--	[Taskcode] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--	[TaskBookCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[ResourceCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[Quantity] [decimal](18, 2) NOT NULL,
--	[UnitPrice] [decimal](18, 2) NOT NULL,
--	[ResourceStyle] [int] NOT NULL,
--	[FactQuantity] [decimal](18, 2) NOT NULL,
--	[CostType] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_EPM_Book_Resource_CostType]  DEFAULT ((0))
--) ON [PRIMARY]
--GO
--IF OBJECT_ID('EPM_Task_TaskRelation','U') IS NULL
--CREATE TABLE [dbo].[EPM_Task_TaskRelation](
--	[NoteID] [int] IDENTITY(1,1) NOT NULL,
--	[ProjectCode] [uniqueidentifier] NOT NULL,
--	[BeginTaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[EndTaskCode] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
--	[Relationship] [int] NOT NULL,
--	[WaitDay] [int] NOT NULL
--) ON [PRIMARY]
--GO
