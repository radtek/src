--�����������
DECLARE @disablefk AS nvarchar(max)
SET @disablefk = '';
SELECT @disablefk = @disablefk + 'ALTER TABLE ['  + TABLE_NAME + '] NOCHECK CONSTRAINT [' +  CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY';
EXEC sp_executesql @disablefk
GO

--ɾ����������
DECLARE @del AS nvarchar(max)
SET @del = '';
SELECT @del = @del + DeleteSql
FROM (
	SELECT 
		CASE TABLE_NAME 
			WHEN 'PT_YHMC_Privilege' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE V_YHDM <> ''00000000'';'
			WHEN 'F_FileInfo' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE FileName <> ''Ŀ¼'';'
			WHEN 'PT_LOGIN' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE V_YHDM <> ''00000000'';'
			WHEN 'PT_d_bm' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE i_bmdm <> 1;'
			WHEN 'PT_Manager_Privilege' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE V_YHDM <> ''00000000'';'
			WHEN 'PT_yhmc' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE V_YHDM <> ''00000000'';'
			WHEN 'frame_Desktop_UserModel' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE userCode <> ''00000000'' AND userCOde <> ''default'';'
			WHEN 'pt_dzyj_wbyj' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE v_yhdm <> ''00000000'';'
			WHEN 'Sm_Treasury' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE tcode <> ''0'';'
			WHEN 'PT_d_CorpCode' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE CorpCode <> ''00'';'
            WHEN 'WF_Business_Class' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE BusinessCode = 999;'
            WHEN 'XPM_Basic_CodeList' THEN 'DELETE FROM [' + TABLE_NAME + '] WHERE TypeId = 20;'        --��չ鵵���
			WHEN 'Bud_CostAccounting' THEN 'DELETE FROM [' + TABLE_NAME + 
				'] WHERE CBSCode NOT IN (''001'', ''001001'', ''001002'',''001001001'',''001001002'',''001001003'', ''001001000'', ''001001999'');'
			WHEN 'Res_ResourceType' THEN 'DELETE FROM [' + TABLE_NAME + 
				'] WHERE ResourceTypeCode NOT IN (''0001'', ''0002'', ''001002'',''0003'');'
			WHEN 'Res_Attribute' THEN 'DELETE FROM [' + TABLE_NAME + 
				'] WHERE AttributeId NOT IN (''FF747819-77DE-4670-A4F5-8FED9A509A70'', ''FF747819-77DE-4670-A4F5-8FED9A509A71'');'
			WHEN 'Res_PriceType' THEN 'DELETE FROM [' + TABLE_NAME + 
				'] WHERE PriceTypeId NOT IN (''192340F1-08E3-4B32-B65D-75E785062D05'', ''ABC233A8-6C1E-4200-91EC-9223DBCDE390'');'
			ELSE 'DELETE FROM [' + TABLE_NAME + '];'
		END AS DeleteSql
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE'
	AND TABLE_NAME NOT IN (
		'F_FileType',
		'PopupSetting',
		'PT_MK',
		'PT_HelpMK',
		'PT_SkinType',
		'PT_D_TXLX',
        'PT_D_CS',
		'frame_Desktop_ModelInfo',
		'frame_Desktop_UserSet',
		'Sm_Set',
		'Fund_Config',
		'SelfEventInfo',
		'XPM_Basic_NextID',
		'XPM_Basic_CodeType',
		'Basic_CodeType',
		'Basic_CodeList',
        'Basic_Config',
		'Con_Config',
		'XPM_Basic_AnnexSettings',
		'PT_D_MultiClass',
		'PT_MultiClasses',
		'PT_SingleClasses',
		'Prj_FilesClass',
		'PT_D_SingleClass',
		'WF_BusinessCode',
		'WF_supperDelete',
        'OA_Vehicle_TypeAndState',      --�������ͺ�״̬
        'PT_Prj_Completed',             --������������
        'Basic_Area',
        'Basic_Province',
        'Basic_City',
		'��˵��'
	)
) AS T
EXEC sp_executesql @del
GO

--ɾ��ͼֽ���� ͼֽ���ʹ洢�� XPM_Basic_CodeList ����
DELETE XPM_Basic_CodeList WHERE TypeId IN (SELECT TypeId FROM XPM_Basic_CodeType WHERE SignCode='img')
GO

--�����������
DECLARE @enablefk AS nvarchar(max)
SET @enablefk = '';
SELECT @enablefk = @enablefk + 'ALTER TABLE ['  + TABLE_NAME + '] CHECK CONSTRAINT [' +  CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY';
EXEC sp_executesql @enablefk
GO


--��ʼ��н��
-- ��ʼ��������
--DELETE FROM SA_SalaryItem
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4170', 1, '��������', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4171', 2, '��λ����', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4172', 3, '����', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4173', 4, '�ۿ�', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel, Code) VALUES('F397D994-993E-40BE-B0C3-B10156AF4174', 5, 'Ӧ��˰���ö�', 0, 'Taxable')
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel, Code) VALUES('F397D994-993E-40BE-B0C3-B10156AF4175', 6, '������', 0, 'TaxExemption')
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel, Code) VALUES('F397D994-993E-40BE-B0C3-B10156AF4176', 7, '����˰��', 0, 'TaxRate')
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel, Code) VALUES('F397D994-993E-40BE-B0C3-B10156AF4177', 8, '�ٿ���', 0, 'Deduct')
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel, Code) VALUES('F397D994-993E-40BE-B0C3-B10156AF4178', 9, '��������˰', 0, 'PersonalTax')
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4179', 10, '�绰����', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4180', 11, '�չ���', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4181', 12, '����', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4183', 13, 'Ӧ������', 0)
INSERT INTO SA_SalaryItem (Id, No, Name, IsAllowDel) VALUES('F397D994-993E-40BE-B0C3-B10156AF4182', 14, 'ʵ������', 0)
--��ʼ������
--DELETE FROM SA_SalaryBooks 
INSERT INTO SA_SalaryBooks(Id, Name, IsValid, InputUser, InputDate)
VALUES('EB62BE9A-5F51-4B10-8739-5CADCFA51540', '������н����', 1, '00000000', GETDATE())
INSERT INTO SA_SalaryBooks(Id, Name, IsValid, InputUser, InputDate)
VALUES('EB62BE9A-5F51-4B10-8739-5CADCFA51541', '��н����', 1, '00000000', GETDATE())
--��ʼ����������˰
--DELETE FROM SA_PersonalTax
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F980', 0, 1500, 0.03, 0)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F981', 1500, 4500, 0.1, 105)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F982', 4500, 9000, 0.2, 555)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F983', 9000, 35000, 0.25, 1005)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F984', 35000, 55000, 0.3, 2755)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F985', 55000, 80000, 0.35, 5505)
INSERT INTO SA_PersonalTax(Id, FloorLevel, TopLevel, TaxRate, Deduct)
VALUES('875A8208-0828-4F63-8F79-C3CECED3F986', 80000, 99999999999999, 0.45, 13505)
--��������ϸ
--DELETE FROM SA_SalaryBooksItem
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650421',1,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4170',2500.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650422',2,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4171',0.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650426',3,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4172',0.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650424',4,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4173',0.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650427',5,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4175',3500.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650423',6,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4176',0.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650420',7,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4177',0.000,0,NULL,1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650425',8,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4178',0.000,1,N'[371048b2-99db-4210-948c-f14c2f4b4b80]*[1afa4822-ecb3-4771-8e38-0ea644650423]-[1afa4822-ecb3-4771-8e38-0ea644650420]',1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'371048b2-99db-4210-948c-f14c2f4b4b80',9,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4174',0.000,1,N'[1afa4822-ecb3-4771-8e38-0ea644650428]-[1afa4822-ecb3-4771-8e38-0ea644650427]',1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650428',10,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4183',0.000,1,N'[1afa4822-ecb3-4771-8e38-0ea644650421]+[1afa4822-ecb3-4771-8e38-0ea644650422]+[1afa4822-ecb3-4771-8e38-0ea644650426]-[1afa4822-ecb3-4771-8e38-0ea644650424]',1)
INSERT INTO SA_SalaryBooksItem(Id,No,BooksId,ItemId,DefaultValue,IsFormula,Formula,IsShow) VALUES(N'1afa4822-ecb3-4771-8e38-0ea644650429',11,N'EB62BE9A-5F51-4B10-8739-5CADCFA51540',N'F397D994-993E-40BE-B0C3-B10156AF4182',0.000,1,N'[1afa4822-ecb3-4771-8e38-0ea644650428]-[1afa4822-ecb3-4771-8e38-0ea644650425]',1)
GO

--�ҵ��ճ��޸����
ALTER TABLE OA_Calendar_Info NOCHECK CONSTRAINT [�ճ���Ϣ-��������]


--��ʼ����¼����
UPDATE PT_D_CS SET ptcs=1 WHERE id=1

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
