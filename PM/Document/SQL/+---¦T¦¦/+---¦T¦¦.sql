
--EPM_Datum_Affair 2011��9��27�� lpw
ALTER TABLE EPM_Datum_Affair ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE EPM_Datum_Affair ADD filesType INT --�鵵��������
UPDATE EPM_Datum_Affair SET mark =0; 
--EPM_Datum_Criterion 2011��9��27�� lpw
ALTER TABLE EPM_Datum_Criterion ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE EPM_Datum_Criterion ADD filesType INT --�鵵��������                                               
UPDATE EPM_Datum_Criterion SET mark =0;    
 --�������ӹ鵵, �鵵��Ϣ��    2011��9��28��    lpw
if exists (select * from sysobjects where id = OBJECT_ID('[Files]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Files]
CREATE TABLE [Files] (
[ID] [uniqueidentifier]  NOT NULL,--���
[file_sid] [varchar]  (64) NULL,--���ID(���鵵�����ID)
[file_name] [varchar]  (100) NULL,--�鵵��������
[file_info] [varchar]  (MAX) NULL,--�鵵������
[file_mark] [int]  NULL,--�鵵��״̬
[Original_table] [varchar]  (50) NULL)--������(Դ��)
ALTER TABLE [Files] WITH NOCHECK ADD  CONSTRAINT [PK_Files] PRIMARY KEY  NONCLUSTERED ( [ID] )

------ʩ����֯�����ӹ鵵����  slm 20110929
ALTER TABLE Prj_TechnologyConstructOrganize ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Prj_TechnologyConstructOrganize ADD filesType INT --�鵵��������                                               
UPDATE Prj_TechnologyConstructOrganize SET mark =2;  

-----ר�������Զ��鵵

ALTER TABLE Prj_ExpertSchemeManage ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Prj_ExpertSchemeManage ADD filesType INT --�鵵��������                                               
UPDATE Prj_ExpertSchemeManage SET mark =2;  

-- 2011��9��29�� lpw
ALTER TABLE Ent_Quality_Goal ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Ent_Quality_Goal ADD filesType INT --�鵵��������
UPDATE Ent_Quality_Goal SET mark =0;




--2011��10��8�� lpw �鵵
ALTER TABLE Prj_TechnologyManage ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Prj_TechnologyManage ADD filesType INT --�鵵��������
UPDATE Prj_TechnologyManage SET mark =0;
ALTER TABLE EPM_Datum_Affair ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE EPM_Datum_Affair ADD filesType INT --�鵵��������
UPDATE EPM_Datum_Affair SET mark =0;
ALTER TABLE Files ADD sid_ColumnName VARCHAR(50)
ALTER TABLE Files ADD sid_ColumnType INT
ALTER TABLE Files ADD prjcode varchar(64)


----�����ܽ�鵵  slm  2011-10-9
ALTER TABLE Prj_Summary ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Prj_Summary ADD filesType INT --�鵵��������                                               
UPDATE Prj_Summary SET mark =2;  



--2011-10-11 lpw
--INSERT [PT_MK] ([C_MKDM],[V_MKMC],[C_BS],[I_XH],[I_ID],[i_ChildNum],[IsBasic],[IsMaintainable],[Isdisplay]) VALUES ( N'900305',N'�����鵵',N'y',5,1042,2,N'0',N'0',N'1')
INSERT [PT_MK] ([C_MKDM],[V_MKMC],[V_CDLJ],[C_BS],[I_XH],[I_ID],[i_ChildNum],[IsBasic],[IsMaintainable],[Isdisplay]) VALUES ( N'90030501',N'���ӹ鵵',N'EPC/Frame.aspx?Url=../../EPC/ProjectOver/ProjectElectronFiles.aspx&Type=Edit',N'y',2,2253,0,N'0',N'0',N'1')
UPDATE PT_MK SET V_MKMC = '�����鵵',V_CDLJ = '/EPC/ProjectOver/ProjectDocument.aspx',C_BS = 'y',I_XH = 5,I_ID = 1042,i_ChildNum = 2,IsBasic = '0',IsMaintainable = '0',	Isdisplay = '1' WHERE C_MKDM='900305'
UPDATE PT_MK SET V_MKMC = '�ı��鵵',V_CDLJ = '/EPC/ProjectOver/ProjectDocument.aspx',C_BS = 'y',I_XH = 2,I_ID = 2254,i_ChildNum = 0,IsBasic = '0',IsMaintainable = '0',	Isdisplay = '1' WHERE C_MKDM='90030502';
--INSERT [PT_MK] ([C_MKDM],[V_MKMC],[V_CDLJ],[C_BS],[I_XH],[I_ID],[i_ChildNum],[IsBasic],[IsMaintainable],[Isdisplay]) VALUES ( N'90030502',N'�ı��鵵',N'/EPC/ProjectOver/ProjectDocument.aspx',N'y',2,2254,0,N'0',N'0',N'1')



ALTER TABLE Prj_ProgressPlan ADD filesType int
ALTER TABLE Prj_ProgressPlan ADD mark INT --��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
UPDATE Prj_ProgressPlan SET mark =0; 
ALTER TABLE Prj_ItemInspect ADD filesType int
ALTER TABLE Prj_ItemInspect ADD mark INT
UPDATE Prj_ItemInspect SET mark =0;

--2011-10-12 lpw ��Ŀ����
ALTER TABLE Prj_ItemProg ADD filesType int
ALTER TABLE Prj_ItemProg ADD mark INT --��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
UPDATE Prj_ItemProg SET mark =2;
-- 2011-10-13 lpw ���� ���ӱ�ʶID ���ڸ���������
ALTER TABLE Prj_ItemInspect ADD rectifyMarkID uniqueidentifier


--2011-10-18 lpw ��������
ALTER TABLE Prj_TechnologyTell ADD filesType int
ALTER TABLE Prj_TechnologyTell ADD mark INT --��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
UPDATE Prj_TechnologyTell SET mark =2;



--2011��10��21�� lpw
INSERT [PT_MK] ([C_MKDM],[V_MKMC],[V_CDLJ],[C_BS],[I_XH],[I_ID],[i_ChildNum],[IsBasic],[IsMaintainable],[Isdisplay]) VALUES ( N'900306',N'���ӵ�������',N'EPC/Frame.aspx?Url=../../EPC/ProjectOver/ProjectElectronFilesSearch.aspx&Type=List',N'y',7,2269,0,N'0',N'0',N'1')


--2011��11��8�� ���²��� ��Ŀ��� ��ͼSQL��� lpw
ALTER VIEW [dbo].[Prj_v_ItemInspect]
AS
SELECT     dbo.Prj_ItemInspectSort.ItemInspectSortName, dbo.Prj_ItemInspect.*
FROM         dbo.Prj_ItemInspect INNER JOIN
                      dbo.Prj_ItemInspectSort ON dbo.Prj_ItemInspect.AcceptCheckSort = dbo.Prj_ItemInspectSort.SortID
  



--2011��11��10�� ���²��� �������� ��ͼSQL��� lpw
ALTER VIEW [dbo].[Prj_V_TechnologyJD]
AS
SELECT     MainID AS Expr1, PrjCode AS Expr2, SerialNumber AS Expr3, FillDate AS Expr4, FillPeople AS Expr5, PrejectName AS Expr6, ConstructionUnit AS Expr7, 
                      ByTellUnit AS Expr8, TellPeople AS Expr9, ByTellPeople AS Expr10, TellLocus AS Expr11, TellDate AS Expr12, TellContentAbstract AS Expr13, Remark AS Expr14,
                          (SELECT     v_xm
                            FROM          dbo.PT_yhmc
                            WHERE      (v_yhdm = dbo.Prj_TechnologyTell.FillPeople)) AS FillName,
                          (SELECT     v_xm
                            FROM          dbo.PT_yhmc AS PT_yhmc_2
                            WHERE      (v_yhdm = dbo.Prj_TechnologyTell.TellPeople)) AS TellName,
                          (SELECT     v_xm
                            FROM          dbo.PT_yhmc AS PT_yhmc_1
                            WHERE      (v_yhdm = dbo.Prj_TechnologyTell.ByTellPeople)) AS ByTellName, dbo.Prj_TechnologyTell.*, mark AS Expr15, filesType AS Expr16
FROM         dbo.Prj_TechnologyTell
--2011��11��10�� ���²��� ��Ŀ���� ��ͼSQL��� lpw
ALTER VIEW [dbo].[Prj_V_ItemProg]
AS
SELECT     dbo.Prj_ProgSort.ProgSortName, dbo.Prj_ItemProg.ID AS Expr1, dbo.Prj_ItemProg.PrjCode AS Expr2, dbo.Prj_ItemProg.ProgUnit AS Expr3, 
                      dbo.Prj_ItemProg.ByProgObject AS Expr4, dbo.Prj_ItemProg.ProgGist AS Expr5, dbo.Prj_ItemProg.ProgCause AS Expr6, dbo.Prj_ItemProg.ProgMoney AS Expr7, 
                      dbo.Prj_ItemProg.ProgSortCode AS Expr8, dbo.Prj_ItemProg.ProgDate AS Expr9, dbo.Prj_ItemProg.Remark AS Expr10, dbo.Prj_ItemProg.ApprovePerson AS Expr11, 
                      dbo.Prj_ItemProg.ApproveResult AS Expr12, dbo.Prj_ItemProg.ApproveDate AS Expr13, dbo.Prj_ItemProg.ApproveIdea AS Expr14, 
                      dbo.Prj_ItemProg.ProgSign AS Expr15, dbo.Prj_ItemProg.Principal AS Expr16, dbo.Prj_ItemProg.ProgBurstunit AS Expr17, dbo.Prj_ItemProg.IsAction AS Expr18, 
                      dbo.Prj_ItemProg.filesType AS Expr19, dbo.Prj_ItemProg.mark AS Expr20, dbo.Prj_ItemProg.*
FROM         dbo.Prj_ProgSort INNER JOIN
                      dbo.Prj_ItemProg ON dbo.Prj_ProgSort.ProgSortCode = dbo.Prj_ItemProg.ProgSortCode
--2011��11��10�� ���²��� ��ȫ��ʩ ��ͼSQL��� lpw
ALTER VIEW [dbo].[v_Safty_Measure]
AS
SELECT     TOP (100) PERCENT dbo.Ent_Safty_Measure.i_id, dbo.Ent_Safty_Measure.PrjCode, dbo.PT_PrjInfo.PrjName, dbo.Ent_Safty_Measure.ScheduleCode, 
                      dbo.Ent_Safty_Measure.SaftyMeasure, dbo.Ent_Safty_Measure.Remark, dbo.EPM_Task_TaskList.TaskName, dbo.Ent_Safty_Measure.mark, 
                      dbo.Ent_Safty_Measure.filesType
FROM         dbo.Ent_Safty_Measure INNER JOIN
                      dbo.EPM_Task_TaskList ON dbo.Ent_Safty_Measure.PrjCode = dbo.EPM_Task_TaskList.ProjectCode AND 
                      dbo.Ent_Safty_Measure.ScheduleCode = dbo.EPM_Task_TaskList.TaskCode INNER JOIN
                      dbo.PT_PrjInfo ON dbo.Ent_Safty_Measure.PrjCode = dbo.PT_PrjInfo.PrjGuid
ORDER BY dbo.Ent_Safty_Measure.ScheduleCode

ALTER TABLE Ent_Safty_Measure ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Ent_Safty_Measure ADD filesType INT --�鵵��������                                               
UPDATE Ent_Safty_Measure SET mark =0;    

--2011��11��10�� ���²��� ����Ŀ�� ��ͼSQL��� lpw
ALTER VIEW [dbo].[v_Quality_Goal]
AS
SELECT     TOP (100) PERCENT dbo.Ent_Quality_Goal.i_id, dbo.Ent_Quality_Goal.PrjCode, dbo.Ent_Quality_Goal.ScheduleCode, dbo.Ent_Quality_Goal.QualityGoal, 
                      dbo.Ent_Quality_Goal.Remark, dbo.EPM_Task_TaskList.TaskName, dbo.PT_PrjInfo.PrjName, dbo.Ent_Quality_Goal.mark, dbo.Ent_Quality_Goal.filesType
FROM         dbo.Ent_Quality_Goal INNER JOIN
                      dbo.EPM_Task_TaskList ON dbo.Ent_Quality_Goal.PrjCode = dbo.EPM_Task_TaskList.ProjectCode AND 
                      dbo.Ent_Quality_Goal.ScheduleCode = dbo.EPM_Task_TaskList.TaskCode INNER JOIN
                      dbo.PT_PrjInfo ON dbo.Ent_Quality_Goal.PrjCode = dbo.PT_PrjInfo.PrjGuid
ORDER BY dbo.Ent_Quality_Goal.ScheduleCode



------�Ƽ�����������ʩ����֯��ר���������   slm  20110920

-- ר���������
alter table Prj_ExpertSchemeManage add FlowGuid uniqueidentifier default newid()
alter table Prj_ExpertSchemeManage add AuditState  int default -1
update Prj_ExpertSchemeManage set AuditState=-1
update Prj_ExpertSchemeManage set FlowGuid=newid()

insert into WF_Business_Class (BusinessCode,BusinessClass,BusinessClassName)
values('050','001','ר������')

insert into WF_BusinessCode ( Businesscode,BusinessName,KeyWord,LinkTable,PrimaryField,StateField,DoWithUrl,LookUrl,C_MKDM )
values('050','ר�������','FlowGuid','Prj_ExpertSchemeManage','FlowGuid','AuditState','/EPC/17/ppm/ScienceInnovate/expertprojectview.aspx',Null,'91')

---���ִ�У��м�����ִ�й�֮����ִ�иô���
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[Prj_V_ExpertProject]
AS
SELECT dbo.Prj_ExpertSchemeManage.*, dbo.PT_D_BM.V_BMMC, 
      dbo.Prj_ProjectInfo.PrjName,
          (SELECT dbo.pt_yhmc.v_xm
         FROM dbo.pt_yhmc
         WHERE dbo.pt_yhmc.v_yhdm = dbo.Prj_ExpertSchemeManage.WeavePeople) 
      AS Weavemc,
          (SELECT dbo.pt_yhmc.v_xm
         FROM dbo.pt_yhmc
         WHERE dbo.pt_yhmc.v_yhdm = dbo.Prj_ExpertSchemeManage.FillPeople) 
      AS fillmc
FROM dbo.Prj_ExpertSchemeManage INNER JOIN
      dbo.Prj_ProjectInfo ON 
      dbo.Prj_ExpertSchemeManage.PrejectName = dbo.Prj_ProjectInfo.PrjCode INNER JOIN
      dbo.PT_D_BM ON dbo.Prj_ExpertSchemeManage.PrjCode = dbo.PT_D_BM.i_bmdm
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

--- ʩ����֯������  

alter table Prj_TechnologyConstructOrganize add FlowGuid uniqueidentifier default newid()
alter table Prj_TechnologyConstructOrganize add AuditState  int default -1

update Prj_TechnologyConstructOrganize set AuditState=-1
update Prj_TechnologyConstructOrganize set FlowGuid=newid()


insert into WF_Business_Class (BusinessCode,BusinessClass,BusinessClassName)
values('023','001','ʩ����֯���')

insert into WF_BusinessCode ( Businesscode,BusinessName,KeyWord,LinkTable,PrimaryField,StateField,DoWithUrl,LookUrl,C_MKDM )
values('023','ʩ����֯����','FlowGuid','Prj_TechnologyConstructOrganize','FlowGuid','AuditState','/EPC/17/ppm/ScienceInnovate/ConstructOrganizeView.aspx',Null,'91')


---���ִ�У��м�����ִ�й�֮����ִ�иô���

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[Prj_V_ScienceInnovate]  
AS
SELECT dbo.Prj_TechnologyConstructOrganize.* 
FROM dbo.Prj_TechnologyConstructOrganize
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


-------������׼̨��  slm   2011-10-11
ALTER TABLE Prj_TechnologyCriterion ADD mark INT -- ��ʾ״̬,1:�ѹ鵵 2:δѡ����Ϊ�鵵���� 3:ѡ��Ϊ�鵵����
ALTER TABLE Prj_TechnologyCriterion ADD filesType INT --�鵵��������                                               
UPDATE Prj_TechnologyCriterion SET mark =2;  

