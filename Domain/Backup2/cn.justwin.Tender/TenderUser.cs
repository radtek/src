namespace cn.justwin.Tender
{
    using cn.justwin.DAL;
    using cn.justwin.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class TenderUser
    {
        private TenderUser()
        {
        }

        public static void Add(string prjGuid, string userCode)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB_User user = new PT_PrjInfo_ZTB_User {
                    Id = Guid.NewGuid().ToString(),
                    PrjGuid = new Guid(prjGuid),
                    UserCode = userCode
                };
                entities.AddToPT_PrjInfo_ZTB_User(user);
                entities.SaveChanges();
            }
        }

        public static void AddUser(string prjGuid, List<string> userCodes)
        {
            Guid guid = new Guid(prjGuid);
            using (pm2Entities entities = new pm2Entities())
            {
                new PTPrjInfoZTBUserService().Delete(prjGuid);
                if (userCodes != null)
                {
                    using (List<string>.Enumerator enumerator = userCodes.GetEnumerator())
                    {
                        string code;
                        while (enumerator.MoveNext())
                        {
                            code = enumerator.Current;
                            if ((from m in entities.PT_yhmc
                                where m.v_yhdm == code
                                select m).FirstOrDefault<PT_yhmc>() != null)
                            {
                                PT_PrjInfo_ZTB_User user = new PT_PrjInfo_ZTB_User {
                                    Id = Guid.NewGuid().ToString(),
                                    PrjGuid = new Guid?(guid),
                                    UserCode = code
                                };
                                entities.AddToPT_PrjInfo_ZTB_User(user);
                            }
                        }
                    }
                }
                entities.SaveChanges();
            }
        }

        public static void AddUser(List<string> prjGuids, List<string> userCodes)
        {
            using (new pm2Entities())
            {
                foreach (string str in prjGuids)
                {
                    Guid guid = new Guid(str);
                    List<string> list = GetUserCodes(guid);
                    foreach (string str2 in userCodes)
                    {
                        if (!list.Contains(str2))
                        {
                            Add(str, str2);
                        }
                    }
                }
            }
        }

        public static void Del(Guid prjGuid, string userCode)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB_User entity = (from m in entities.PT_PrjInfo_ZTB_User
                    where (m.PrjGuid == prjGuid) && (m.UserCode == userCode)
                    select m).FirstOrDefault<PT_PrjInfo_ZTB_User>();
                if (entity != null)
                {
                    entities.DeleteObject(entity);
                    entities.SaveChanges();
                }
            }
        }

        public static List<TenderUser> GetById(string prjGuid)
        {
            List<TenderUser> list = new List<TenderUser>();
            Guid guid = new Guid(prjGuid);
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression6;
                return (from m in entities.PT_PrjInfo_ZTB_User
                    join yh in entities.PT_yhmc on m.UserCode equals yh.v_yhdm into yh
                    where m.PrjGuid == guid
                    select <>h__TransparentIdentifier0).Select(Expression.Lambda(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(TenderUser..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(TenderUser.set_Id), Expression.Property(Expression.Property(expression6 = Expression.Parameter(typeof(<>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>), "<>h__TransparentIdentifier0"), (MethodInfo) methodof(<>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>.get_m, <>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_User.get_Id))), Expression.Bind((MethodInfo) methodof(TenderUser.set_PrjGuid), Expression.Coalesce(Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>.get_m, <>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_User.get_PrjGuid)), Expression.New(typeof(Guid)))), Expression.Bind((MethodInfo) methodof(TenderUser.set_UserCode), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>.get_m, <>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_User.get_UserCode))), Expression.Bind((MethodInfo) methodof(TenderUser.set_UserName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>.get_yh, <>f__AnonymousType29<PT_PrjInfo_ZTB_User, PT_yhmc>)), (MethodInfo) methodof(PT_yhmc.get_v_xm))) }), new ParameterExpression[] { expression6 })).ToList<TenderUser>();
            }
        }

        public static List<string> GetUserCodes(Guid guid)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                return (from m in entities.PT_PrjInfo_ZTB_User
                    where m.PrjGuid == guid
                    select m.UserCode).ToList<string>();
            }
        }

        public static bool isExist(Guid guid, string code)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                if ((from m in entities.PT_PrjInfo_ZTB_User
                    where (m.PrjGuid == guid) && (m.UserCode == code)
                    select m.UserCode).Count<string>() > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool isQuote(string code)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                int num = (from m in entities.PT_PrjInfo_ZTB_Detail
                    where ((m.PrjDutyPerson == code) || (m.BusinessManager == code)) || (m.ProgAgent == code)
                    select m).ToList<PT_PrjInfo_ZTB_Detail>().Count<PT_PrjInfo_ZTB_Detail>();
                int num2 = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjManager == code
                    select m).ToList<PT_PrjInfo_ZTB>().Count<PT_PrjInfo_ZTB>();
                if ((num + num2) > 1)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool isQuote(string code, Guid prjGuid)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                int num = (from m in entities.PT_PrjInfo_ZTB_Detail
                    where (((m.PrjDutyPerson == code) || (m.BusinessManager == code)) || (m.ProgAgent == code)) && (m.PrjGuid == prjGuid)
                    select m).ToList<PT_PrjInfo_ZTB_Detail>().Count<PT_PrjInfo_ZTB_Detail>();
                int num2 = (from m in entities.PT_PrjInfo_ZTB
                    where (m.PrjManager == code) && (m.PrjGuid == prjGuid)
                    select m).ToList<PT_PrjInfo_ZTB>().Count<PT_PrjInfo_ZTB>();
                if ((num + num2) > 1)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public string Id { get; set; }

        public Guid PrjGuid { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }
    }
}

