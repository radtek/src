
----------------------------------------------------------���ӿ��������ü�¼20100610 zxd 
delete from Sm_Set
insert into Sm_Set values(newid(),'DepotType','TotalMode','ParallelMode��ʾƽ��ģʽ��TotalMode��ʾ�ܷ�ģʽ')
insert into Sm_Set values(newid(),'DepotBindType','UnBind','')
insert into Sm_Set values(newid(),'ProjectAlarm','Alarm','Alarm��ʾԤ����UnAlarm��ʾ�ܾ�')
insert into Sm_Set values(newid(),'ProjectTransparentSet','UnTransparent','')
insert into Sm_Set values(newid(),'IsLowAlarm','0','0��ʾ��Ԥ����1��ʾԤ��')
insert into Sm_Set values(newid(),'IsHighPlanAlarm','1','0��ʾ����������ƻ���Ԥ����1��ʾ����������ƻ�Ԥ��')
insert into Sm_Set values(newid(),'HighPlanAlarmLimit','30','�߼ƻ�Ԥ���޶�')
insert into Sm_Set values(newid(),'IsMidPlanAlarm','1','�Ƿ�����������ƻ�Ԥ��')
insert into Sm_Set values(newid(),'MidPlanAlarmUpperLimit','20','�мƻ�Ԥ������')
insert into Sm_Set values(newid(),'MidPlanAlarmLowerLimit','10','�мƻ�Ԥ������')
insert into Sm_Set values(newid(),'IsLowPlanAlarm','1','�Ƿ����������ƻ�Ԥ��')
insert into Sm_Set values(newid(),'LowPlanAlarmUpperLimit','10','�ͼƻ�Ԥ������')
insert into Sm_Set values(newid(),'LowPlanAlarmLowerLimit','0','�ͼƻ�Ԥ������')
insert into Sm_Set values(newid(),'IsContainPending','0','�Ƿ������������')
go

----------------------------------------------------------����ģ��������� 

--���òɹ��ƻ�������� 2010-7-19 ����
insert dbo.WF_BusinessCode values('072','�ɹ��ƻ�','ppid','dbo.Sm_Purchaseplan','ppid','flowstate','/StockManage/SmPurchaseplan/ViewSmPurchaseplan.aspx',null,'03')
insert dbo.WF_Business_Class values('072','001','�ɹ��ƻ����')

--�������������� 2010-7-19 ����
insert dbo.WF_BusinessCode values('076','�������','orid','dbo.Sm_OutReserve','orid','flowstate','/StockManage/SmOutReserve/ViewReserve.aspx',null,'03')
insert dbo.WF_Business_Class values('076','001','����������')

--�˿����������� 2010-7-19 ����
insert dbo.WF_BusinessCode values('077','�˿����','rid','dbo.Sm_Refunding','rid','flowstate','/StockManage/Refunding/ViewRefunding.aspx',null,'03')
insert dbo.WF_Business_Class values('077','001','�˿�������')

--��������ƻ�������� 2010-7-19  �����
insert dbo.WF_BusinessCode values('071','��������ƻ�','swid','Sm_Wantplan','swid','flowstate','/StockManage/basicset/WantplanView.aspx',null,'03')
insert dbo.WF_Business_Class values('071','001','��������ƻ����')

--�ɹ���������� 2010-7-19  �����
insert dbo.WF_BusinessCode values('073','�ɹ�����','pid','Sm_Purchase','pid','flowstate','/StockManage/Purchase/PurchaseView.aspx',null,'03')
insert dbo.WF_Business_Class values('073','001','�ɹ��������')

--��ⵥ������� 2010-7-19  �����
insert dbo.WF_BusinessCode values('074','������','sid','Sm_Storage','sid','flowstate','/StockManage/Storage/StorageView.aspx',null,'03')
insert dbo.WF_Business_Class values('074','001','���������')

--����������������� 2010-7-21  ������
insert dbo.WF_BusinessCode values('075','����������','aid','Sm_Allocation','aid','flowstate','/StockManage/Allocation/AuditPage.aspx',null,'03')
insert dbo.WF_Business_Class values('075','001','���������')
go


----------------------------------------------------------����ģ����Ӹ���


--�ɹ�����Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1801','Purchase','�ɹ���',8388608,'*','/UploadFiles/StockManage/Purchase/',8)

--�ɹ��ƻ���Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1756','SmPurchaseplan','�ɹ��ƻ�',8388608,'*','/UploadFiles/StockManage/SmPurchaseplan/',8)

--��ⵥ��Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1802','Storage','��ⵥ',8388608,'*','/UploadFiles/StockManage/Storage/',8)

--��������ƻ���Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1803','WantPlan','��������ƻ�',8388608,'*','/UploadFiles/StockManage/WantPlan/',8)

--���ⵥ��Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1804','OutReserve','���ⵥ',8388608,'*','/UploadFiles/StockManage/OutReserve/',8)

--�˿ⵥ��Ӹ���
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1805','Refunding','�˿ⵥ',8388608,'*','/UploadFiles/StockManage/Refunding/',8)
----����������
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('89','Allocation','������',8388608,'*','/UploadFiles/StockManage/Allocation/',8)
go


----------------------------------------------------------Ԥ����ʾ�����Ӧ������ 2010-7-19 ����
insert into dbo.PT_D_TXLX(V_LXBM,V_LXMC,V_TPLJ,V_DBLJ,C_OPENFLAG,FilterField)
values('021','Ԥ������','new_Mail.gif','StockManage/basicset/ShowView.aspx',1,'StockManage')
go

----------------------------------------------------------���Sm_Resource_PriceType�������� ��������Ĭ�ϵ����ݣ����⴦��
INSERT INTO	Sm_Resource_PriceType(rptid,rptcode,rptname,rptIsShow,isdefault)
values('24898687-9BE9-4E0B-AE8D-3BB54492BC9C','00000000','Ԥ��',1,1)
go