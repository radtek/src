----------------------------sql���� ������-���� ����ʱ��-2010-7-30--------------------------------
--������غ��� ��Ҫ����:--��������ID���ݸò���ID
				        --����ò����µ������Ӳ�
				        --�Ű����ò��ŷ��ظò��ź������Ӳ��ŵ�ID
--��ѯ����:select i_bmdm from f_cid('42')
CREATE FUNCTION f_cid(@id int)
RETURNS @t TABLE(i_bmdm int,i_sjdm int,lev int)
as
begin
     declare @lev int
     set @lev=1
     --��@ID = 0 ʱ��Ϊ���㲿��

     --���ӽڵ��ȡ���ڵ�ʱ����where i_bmdm = @id��Ϊwhere i_sjdm = @id����

      if @id <> 0
       insert @t select i_bmdm,i_sjdm,@lev from  dbo.PT_d_bm where i_bmdm = @id
     else
       insert @t select i_bmdm,i_sjdm,@lev from  dbo.PT_d_bm where i_sjdm = 0
     while(@@rowcount>0)
     begin
          set @lev=@lev+1
          insert @t select a.i_bmdm,a.i_sjdm,@lev from dbo.PT_d_bm a,@t b
          where a.i_sjdm = b.i_bmdm and b.lev=@lev-1
     end
     return 
   end