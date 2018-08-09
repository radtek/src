namespace cn.justwin.stockDAL
{
    using cn.justwin.DAL;
    using cn.justwin.stockModel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class FilePermitService
    {
        public static int AddFilePermit(FilePermit model)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(SqlHelper.ConnectionString);
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();
            StringBuilder builder = new StringBuilder();
            try
            {
                builder.Append("insert into OA_File_Permit(");
                builder.Append("tpid,tcode,ptype,pcode,pread,pwrite)");
                builder.Append(" values (");
                builder.Append("@tpid,@tcode,@ptype,@pcode,@pread,@pwrite)");
                SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tpid", SqlDbType.NVarChar, 50), new SqlParameter("@tcode", SqlDbType.NVarChar, 0x200), new SqlParameter("@ptype", SqlDbType.NVarChar, 0x40), new SqlParameter("@pcode", SqlDbType.NVarChar, 0x40), new SqlParameter("@pread", SqlDbType.NVarChar, 0x40), new SqlParameter("@pwrite", SqlDbType.NVarChar, 0x40) };
                commandParameters[0].Value = model.tpid;
                commandParameters[1].Value = model.tcode;
                commandParameters[2].Value = model.ptype;
                commandParameters[3].Value = model.pcode;
                commandParameters[4].Value = model.pread;
                commandParameters[5].Value = model.pwrite;
                num = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, builder.ToString(), commandParameters);
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                connection.Close();
            }
            connection.Close();
            return num;
        }

        public static int DelFilePermitById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from OA_File_Permit ");
            builder.Append(" where tpid=@tpid ");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tpid", SqlDbType.NVarChar, 50) };
            commandParameters[0].Value = id;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, builder.ToString(), commandParameters);
        }

        public static int DelFilePermitByTcode(string tcode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from OA_File_Permit ");
            builder.Append(" where tcode=@tcode");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tcode", SqlDbType.NVarChar, 0x200) };
            commandParameters[0].Value = tcode;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, builder.ToString(), commandParameters);
        }

        public static IList<FilePermit> GetAllFilePermitByWhere(string where)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select tpid,tcode,ptype,pcode,pread,pwrite from OA_File_Permit " + where);
            IList<FilePermit> list = new List<FilePermit>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, builder.ToString(), new SqlParameter[0]))
            {
                while (reader.Read())
                {
                    list.Add(GetFilePermitByReader(reader));
                }
            }
            return list;
        }

        public static FilePermit GetFilePermitById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  top 1 tpid,tcode,ptype,pcode,pread,pwrite from OA_File_Permit ");
            builder.Append(" where tpid=@tpid ");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tpid", SqlDbType.NVarChar, 50) };
            commandParameters[0].Value = id;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, builder.ToString(), commandParameters))
            {
                while (reader.Read())
                {
                    return GetFilePermitByReader(reader);
                }
            }
            return null;
        }

        private static FilePermit GetFilePermitByReader(SqlDataReader reader)
        {
            return new FilePermit { pcode = Convert.ToString(reader["pcode"]), ptype = Convert.ToString(reader["pType"]), tcode = Convert.ToString(reader["tcode"]), tpid = Convert.ToString(reader["tpid"]), pread = Convert.ToString(reader["pread"]), pwrite = Convert.ToString(reader["pwrite"]) };
        }

        public static bool IsPermitAccept(string allocCode, string userCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(1) FROM Sm_Allocation").AppendLine();
            builder.Append("WHERE acode = @AllocCode AND InAllocationPerson = @InPerson;").AppendLine();
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@AllocCode", allocCode), new SqlParameter("@InPerson", userCode) };
            return (DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), commandParameters)) > 0);
        }

        public static bool IsPermitBool(string tcode, string yhdm)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PT_yhmc as p1 ");
            builder.Append(" inner join dbo.OA_File_Permit as p2 ");
            builder.Append(" on (p2.ptype='Department' and p2.pcode=p1.i_bmdm)");
            builder.Append(" or (p2.ptype='post' and p2.pcode=p1.I_DUTYID)");
            builder.Append(" or (p2.ptype='person' and p2.pcode=p1.v_yhdm)");
            builder.Append(" where tcode='" + tcode + "' and p1.v_yhdm='" + yhdm + "'");
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0])) == 0)
            {
                return false;
            }
            return true;
        }

        public static int UpdateFilePermit(FilePermit model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update OA_File_Permit set ");
            builder.Append("tcode=@tcode,");
            builder.Append("ptype=@ptype,");
            builder.Append("pcode=@pcode");
            builder.Append("pread=@pread,");
            builder.Append("pwrite=@pwrite");
            builder.Append(" where tpid=@tpid ");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tpid", SqlDbType.NVarChar, 50), new SqlParameter("@tcode", SqlDbType.NVarChar, 0x200), new SqlParameter("@ptype", SqlDbType.NVarChar, 0x40), new SqlParameter("@pcode", SqlDbType.NVarChar, 0x40), new SqlParameter("@pread", SqlDbType.NVarChar, 0x40), new SqlParameter("@pwrite", SqlDbType.NVarChar, 0x40) };
            commandParameters[0].Value = model.tpid;
            commandParameters[1].Value = model.tcode;
            commandParameters[2].Value = model.ptype;
            commandParameters[3].Value = model.pcode;
            commandParameters[4].Value = model.pread;
            commandParameters[5].Value = model.pwrite;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, builder.ToString(), commandParameters);
        }
        //public static DataTable GetFile(string userCode, bool isLimitPermit)
        //{
        //    DataTable table = new DataTable();
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("\r\n                    SELECT tid,tcode,tname,ptcode,\r\n                    (\r\n                    SELECT COUNT(v_yhdm) FROM PT_yhmc AS p1 \r\n                    INNER JOIN dbo.Sm_Treasury_Permit AS p2 \r\n                    ON (p2.ptype='Department' AND p2.pcode=p1.i_bmdm)\r\n                    OR (p2.ptype='post' AND p2.pcode=p1.I_DUTYID)\r\n                    OR (p2.ptype='person' AND p2.pcode=p1.v_yhdm)\r\n                    WHERE p2.tcode=T1.tcode ");
        //    if (isLimitPermit)
        //    {
        //        builder.Append(" AND p1.v_yhdm=@userCode ");
        //    }
        //    builder.Append("\r\n                    ) AS permit\r\n                    FROM Sm_Treasury AS T1");
        //    SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userCode", userCode) };
        //    return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), commandParameters);
        //}
    }
}

