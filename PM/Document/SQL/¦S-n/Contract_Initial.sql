
--------------------------------------------------------------------------
--�޸�Ԥ������ֶ����ͳ���
ALTER TABLE PT_DBSJ ALTER COLUMN V_DBLJ NVARCHAR(200)


--------------------------------------------------------------------------��ʼ����������
DELETE FROM Con_Config
GO
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsPayoutAlarm','0',N'�Ƿ񸶿����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'PayoutAlarmDays','30',N'������������')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsIncomeAlarm','0',N'�Ƿ�ؿ����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IncomeAlarmDays','30',N'�ؿ���������')

INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsPaymentAlarm','0',N'�Ƿ�֧�����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsHighPayAlarm','0',N'�Ƿ��֧�����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'HighPayAlarmLimit','30',N'��֧�������޶�')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsMidPayAlarm','0',N'�Ƿ���֧�����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'MidPayAlarmLowerLimit','30',N'��֧�����ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'MidPayAlarmUpperLimit','10',N'��֧�����ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsLowPayAlarm','0',N'�Ƿ��֧�����ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'LowPayAlarmUpperLimit','10',N'��֧�����ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'LowPayAlarmLowerLimit','0',N'��֧�����ѽ�����ޱ���')

INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsBalanceAlarm','0',N'�Ƿ�������ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsHighBalanceAlarm','0',N'�Ƿ�߽������ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'HighBalanceAlarmLimit','30',N'�߽��������޶�')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsMidBalanceAlarm','0',N'�Ƿ��н������ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'MidBalanceAlarmUpperLimit','30',N'�н������ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'MidBalanceAlarmLowerLimit','10',N'�н������ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'IsLowBalanceAlarm','0',N'�Ƿ�ͽ������ѣ�0��ʾ�����ѣ�1��ʾ����')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'LowBalanceAlarmUpperLimit','10',N'�ͽ������ѽ�����ޱ���')
INSERT INTO Con_Config(ID,ParaName,ParaValue,Notes) 
	VALUES(NEWID(),'LowBalanceAlarmLowerLimit','0',N'�ͽ������ѽ�����ޱ���')

	
	
---------------------------------------------------------------------------�������
--֧����ͬ�������  Bery 2010-8-25
insert dbo.WF_BusinessCode values('081','֧����ͬ','ContractID','Con_Payout_Contract','ContractID','FlowState','/ContractManage/PayoutContract/PayoutContractEdit.aspx',null,'05')
insert dbo.WF_Business_Class values('081','001','֧����ͬ���')

--֧����ͬ����������  Bery 2010-8-30
insert dbo.WF_BusinessCode values('082','֧����ͬ���','ModifyID','Con_Payout_Modify','ModifyID','FlowState','/ContractManage/PayoutModify/ModifyEdit.aspx',null,'05')
insert dbo.WF_Business_Class values('082','001','֧����ͬ������')

--֧����ͬ�����������  Bery 2010-8-30
insert dbo.WF_BusinessCode values('083','֧����ͬ����','BalanceID','Con_Payout_Balance','BalanceID','FlowState','/ContractManage/PayoutBalance/BalanceEdit.aspx',null,'05')
insert dbo.WF_Business_Class values('083','001','֧����ͬ�������')

--֧����ͬ�����������  Bery 2010-8-30
insert dbo.WF_BusinessCode values('084','֧����ͬ����','ID','Con_Payout_Payment','ID','FlowState','/ContractManage/PayoutPayment/PaymentQuery.aspx',null,'05')
insert dbo.WF_Business_Class values('084','001','֧����ͬ�������')

---------------------------------------------------------------------------��Ӹ���
--֧����ͬ��Ӹ��� Bery 2010-8-25
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1901','PayoutContract','֧����ͬ',8388608,'*','/UploadFiles/ContractManage/PayoutContract/',8)
--֧����ͬ�����Ӹ��� Bery 2010-8-30
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1902','PayoutContractModify','֧����ͬ���',8388608,'*','/UploadFiles/ContractManage/PayoutContractModify/',8)
--֧����ͬ������Ӹ��� Bery 2010-8-30
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1903','PayoutContractBalance','֧����ͬ����',8388608,'*','/UploadFiles/ContractManage/PayoutContractBalance/',8)
--֧����ͬ������Ӹ��� Bery 2010-8-30
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1904','PayoutContractPayment','֧����ͬ����',8388608,'*','/UploadFiles/ContractManage/PayoutContractPayment/',8)
--'�����ͬ��Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1905','IncometContract','�����ͬ',8388608,'*','/UploadFiles/ContractManage/IncometContract/',8)
--'�����ͬ������Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1906','IncometBalance','�����ͬ����',8388608,'*','/UploadFiles/ContractManage/IncometBalance/',8)
--'�����ͬ�����Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1907','IncometModify','�����ͬ���',8388608,'*','/UploadFiles/ContractManage/IncometModify/',8)
--'�����ͬ�տ���Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1908','IncometPayment','�����ͬ�տ�',8388608,'*','/UploadFiles/ContractManage/IncometPayment/',8)
--'�����ͬ������Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1909','ContractPayend','�����ͬ����',8388608,'*','/UploadFiles/ContractManage/ContractPayend/',8)
--'�����ͬ���׷�����Ӹ��� 2010-8-27 author:li
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1910','PayendFeedback','�����ͬ���׷���',8388608,'*','/UploadFiles/ContractManage/PayendFeedback/',8)
--֧����ͬ��Ʊ��Ӹ��� Bery 2010-8-30
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1911','PayoutContractInvoice','֧����ͬ��Ʊ',8388608,'*','/UploadFiles/ContractManage/PayoutContractInvoice/',8)
--�����ͬ��Ʊ��Ӹ��� Bery 2010-8-30
insert into XPM_Basic_AnnexSettings(ModuleID,ModuleCode,ModuleName,FileSize,ExtName,FilePath,FileNumber)
values('1912','PayoutContractInvoice','�����ͬ��Ʊ',8388608,'*','/UploadFiles/ContractManage/IncometContractInvoice/',8)



--��Ʊ����
INSERT INTO XPM_Basic_CodeType(TypeName,IsVisible,IsValid,Remark,SignCode,Owner,VersionTime,ContractCropType) VALUES('��Ʊ����',1,1,'��Ʊ����','InvoiceType','000000','2010-09-17 15:25:50.470','E2689CA3-AA0D-420A-BEBA-FEBF81A63E52')
INSERT INTO XPM_Basic_CodeList(CodeID,TypeID,ParentCodeID,ParentCodeList,CodeName,ChildNumber,IsFixed,IsDefault,IsValid,IsVisible,Owner,VersionTime) VALUES(1,30,0,',1,','��ͨ��Ʊ',0,0,0,1,1,'000000','2010-09-17 15:30:46.777')
INSERT INTO XPM_Basic_CodeList(CodeID,TypeID,ParentCodeID,ParentCodeList,CodeName,ChildNumber,IsFixed,IsDefault,IsValid,IsVisible,Owner,VersionTime) VALUES(2,30,0,',2,','��ֵ��Ʊ',0,0,0,1,1,'000000','2010-09-17 15:31:26.093')



--������
--֧����ͬ������ͨ�����޸ĺ�ͬ���ս��
IF OBJECT_ID ('Approval', 'TR') IS NOT NULL
   DROP TRIGGER Approval;
GO
CREATE TRIGGER Approval
	ON Con_Payout_Modify 
	AFTER UPDATE
AS
DECLARE @state int
SELECT @state = FlowState FROM INSERTED
IF @state = 1
BEGIN
	UPDATE Con_Payout_Contract SET ModifiedMoney = ModifiedMoney + i.ModifyMoney
	FROM Con_Payout_Contract AS c
	JOIN INSERTED AS i ON c.ContractID = i.ContractID
END

--Bery 2010-10-29 
--֧����ͬ��������Ƿ������������
ALTER TABLE Con_Payout_Payment 
ADD ContainPending BIT DEFAULT(0);
UPDATE Con_Payout_Payment SET ContainPending = 0
