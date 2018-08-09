namespace cn.justwin.stockBLL.Domain
{
    using cn.justwin.DAL;
    using cn.justwin.stockBLL;
    using cn.justwin.stockModel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class OrganizationBudget
    {
        private OrganizationBudget()
        {
        }

        public void Add(OrganizationBudget organBudget)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Bud_OrganizationBudget budget = new Bud_OrganizationBudget {
                    Id = organBudget.Id,
                    BudgetAmount = new decimal?(organBudget.BudgetAmount),
                    AccountingAmount = new decimal?(organBudget.AccountAmount),
                    CBSCode = organBudget.CBSCode,
                    OrganizationBudgetId = organBudget.OrganizationBudgetId,
                    State = organBudget.State,
                    Note = organBudget.Note,
                    InputUser = organBudget.InputUser,
                    InputDate = this.InputDate
                };
                entities.AddToBud_OrganizationBudget(budget);
                entities.SaveChanges();
            }
        }

        public static void AddOrDelDesktopNotifications(string id, bool isEReport)
        {
            string zZJGName = GetZZJGName(id);
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT v_yhdm FROM PT_yhmc");
            builder.AppendLine();
            builder.AppendFormat("WHERE i_bmdm='{0}' AND State='1' AND c_sfyx='y'", id);
            SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, builder.ToString(), new SqlParameter[0]);
            PTDbsjBll bll = new PTDbsjBll();
            bll.DelPastDueData(id);
            while (reader.Read())
            {
                if (isEReport)
                {
                    string str2 = reader["v_yhdm"].ToString();
                    if (str2 != "")
                    {
                        StringBuilder builder2 = new StringBuilder();
                        builder2.Append("组织机构:" + zZJGName);
                        builder2.Append("的间接成本预算已经上报,请审核!");
                        PTDbsjModel model = new PTDbsjModel {
                            C_OpenFlag = "0",
                            DTM_DBSJ = DateTime.Now,
                            I_XGID = id,
                            V_Content = builder2.ToString(),
                            V_DBLJ = "BudgetManage/Cost/IndirectBudgetQuery.aspx?id=" + id,
                            V_LXBM = "021",
                            V_TPLJ = "new_Mail.gif",
                            V_YHDM = str2
                        };
                        bll.Add(model);
                    }
                }
            }
        }

        protected static void AddTotalIndirect(List<OrganizationBudget> indirectBudgets)
        {
            OrganizationBudget item = new OrganizationBudget {
                Id = Guid.NewGuid().ToString(),
                CBSCode = "001002",
                AccountAmount = 0M,
                BudgetAmount = 0M,
                State = "2"
            };
            indirectBudgets.Insert(0, item);
        }

        public static OrganizationBudget Create(string id, string organizationBudgetId, string code, decimal budgetAmount, decimal accountAmount, string inputUser, DateTime inputDate, string Note)
        {
            string paramName = "间接成本预算";
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(paramName, "id不能为空!");
            }
            if (string.IsNullOrEmpty(organizationBudgetId))
            {
                throw new ArgumentNullException(paramName, "组织机构编码不能为空!");
            }
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(paramName, "间接成本Id不能为空!");
            }
            return new OrganizationBudget { Id = id, OrganizationBudgetId = organizationBudgetId, CBSCode = code, AccountAmount = accountAmount, BudgetAmount = budgetAmount, InputDate = inputDate, InputUser = inputUser, State = "0", Note = Note };
        }

        public static List<OrganizationBudget> GetAll(string OrganizationBudgetId)
        {
            List<OrganizationBudget> list = new List<OrganizationBudget>();
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression3;
                list = (from m in entities.Bud_OrganizationBudget
                    where m.OrganizationBudgetId == OrganizationBudgetId
                    orderby m.CBSCode
                    select m).Select<Bud_OrganizationBudget, OrganizationBudget>(Expression.Lambda<System.Func<Bud_OrganizationBudget, OrganizationBudget>>(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(OrganizationBudget..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_Id), Expression.Property(expression3 = Expression.Parameter(typeof(Bud_OrganizationBudget), "m"), (MethodInfo) methodof(Bud_OrganizationBudget.get_Id))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_AccountAmount), Expression.Coalesce(Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_AccountingAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_BudgetAmount), Expression.Coalesce(Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_BudgetAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_CBSCode), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_CBSCode))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_State), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_State))) }), new ParameterExpression[] { expression3 })).ToList<OrganizationBudget>();
                List<OrganizationBudget> list2 = (from m in entities.Bud_CostAccounting
                    where m.Type == "I"
                    orderby m.CBSCode
                    select new OrganizationBudget { Id = m.CBSCode, BudgetAmount = 0M, AccountAmount = 0M, State = "0", CBSCode = m.CBSCode }).ToList<OrganizationBudget>();
                if (list.Count != 0)
                {
                    foreach (OrganizationBudget budget in list2)
                    {
                        foreach (OrganizationBudget budget2 in list)
                        {
                            if (budget.CBSCode == budget2.CBSCode)
                            {
                                budget.BudgetAmount = budget2.BudgetAmount;
                                budget.AccountAmount = budget2.AccountAmount;
                                budget.State = budget2.State;
                                list.Remove(budget2);
                                break;
                            }
                        }
                    }
                }
                return list2;
            }
        }

        public static List<OrganizationBudget> GetAllNotEReport(string organizationBudgetId)
        {
            List<OrganizationBudget> indirectBudgets = new List<OrganizationBudget>();
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression3;
                indirectBudgets = (from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organizationBudgetId) && (((m.State == "1") || (m.State == "2")) || (m.State == "4"))
                    orderby m.CBSCode
                    select m).Select<Bud_OrganizationBudget, OrganizationBudget>(Expression.Lambda<System.Func<Bud_OrganizationBudget, OrganizationBudget>>(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(OrganizationBudget..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_Id), Expression.Property(expression3 = Expression.Parameter(typeof(Bud_OrganizationBudget), "m"), (MethodInfo) methodof(Bud_OrganizationBudget.get_Id))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_AccountAmount), Expression.Coalesce(Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_AccountingAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_BudgetAmount), Expression.Coalesce(Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_BudgetAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_CBSCode), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_CBSCode))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_State), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_State))) }), new ParameterExpression[] { expression3 })).ToList<OrganizationBudget>();
                if (indirectBudgets.Count > 0)
                {
                    AddTotalIndirect(indirectBudgets);
                }
            }
            return indirectBudgets;
        }

        public static List<OrganizationBudget> GetAllPass(string organizationBudgetId)
        {
            List<OrganizationBudget> indirectBudgets = new List<OrganizationBudget>();
            using (pm2Entities entities = new pm2Entities())
            {
                indirectBudgets = (from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organizationBudgetId) && (m.State == "2")
                    orderby m.CBSCode
                    select new OrganizationBudget { Id = m.Id, AccountAmount = (decimal) m.AccountingAmount, BudgetAmount = (decimal) m.BudgetAmount, CBSCode = m.CBSCode }).ToList<OrganizationBudget>();
                if (indirectBudgets.Count > 0)
                {
                    AddTotalIndirect(indirectBudgets);
                }
            }
            return indirectBudgets;
        }

        public static List<OrganizationBudget> GetAllReport(string organizationBudgetId)
        {
            List<OrganizationBudget> list = new List<OrganizationBudget>();
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression3;
                return (from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organizationBudgetId) && ((m.State == "1") || (m.State == "4"))
                    orderby m.CBSCode
                    select m).Select<Bud_OrganizationBudget, OrganizationBudget>(Expression.Lambda<System.Func<Bud_OrganizationBudget, OrganizationBudget>>(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(OrganizationBudget..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_Id), Expression.Property(expression3 = Expression.Parameter(typeof(Bud_OrganizationBudget), "m"), (MethodInfo) methodof(Bud_OrganizationBudget.get_Id))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_BudgetAmount), Expression.Coalesce(Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_BudgetAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_CBSCode), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_CBSCode))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_State), Expression.Property(expression3, (MethodInfo) methodof(Bud_OrganizationBudget.get_State))) }), new ParameterExpression[] { expression3 })).ToList<OrganizationBudget>();
            }
        }

        public static OrganizationBudget GetById(string id)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression2;
                return (from m in entities.Bud_OrganizationBudget
                    where m.Id == id
                    select m).Select<Bud_OrganizationBudget, OrganizationBudget>(Expression.Lambda<System.Func<Bud_OrganizationBudget, OrganizationBudget>>(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(OrganizationBudget..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_Id), Expression.Property(expression2 = Expression.Parameter(typeof(Bud_OrganizationBudget), "m"), (MethodInfo) methodof(Bud_OrganizationBudget.get_Id))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_State), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_State))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_InputDate), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_InputDate))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_AccountAmount), Expression.Coalesce(Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_AccountingAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_CBSCode), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_CBSCode))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_OrganizationBudgetId), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_OrganizationBudgetId))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_BudgetAmount), Expression.Coalesce(Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_BudgetAmount)), Expression.Constant(0M, typeof(decimal)))) }), new ParameterExpression[] { expression2 })).FirstOrDefault<OrganizationBudget>();
            }
        }

        public static OrganizationBudget GetByOrganAndCBSCode(string organizationBudgetId, string cbsCode)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression2;
                return (from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organizationBudgetId) && (m.CBSCode == cbsCode)
                    select m).Select<Bud_OrganizationBudget, OrganizationBudget>(Expression.Lambda<System.Func<Bud_OrganizationBudget, OrganizationBudget>>(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(OrganizationBudget..ctor), new Expression[0]), new MemberBinding[] { Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_State), Expression.Property(expression2 = Expression.Parameter(typeof(Bud_OrganizationBudget), "m"), (MethodInfo) methodof(Bud_OrganizationBudget.get_State))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_AccountAmount), Expression.Coalesce(Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_AccountingAmount)), Expression.Constant(0M, typeof(decimal)))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_CBSCode), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_CBSCode))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_OrganizationBudgetId), Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_OrganizationBudgetId))), Expression.Bind((MethodInfo) methodof(OrganizationBudget.set_BudgetAmount), Expression.Coalesce(Expression.Property(expression2, (MethodInfo) methodof(Bud_OrganizationBudget.get_BudgetAmount)), Expression.Constant(0M, typeof(decimal)))) }), new ParameterExpression[] { expression2 })).FirstOrDefault<OrganizationBudget>();
            }
        }

        public static string GetZZJGName(string id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("SELECT V_BMMC FROM PT_d_bm WHERE i_bmdm='{0}'", id);
            return SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0]).ToString();
        }

        public static bool IsExistCBSCode(string cbsCode)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                if ((from m in entities.Bud_OrganizationBudget
                    where (m.CBSCode == cbsCode) && (((m.State == "1") || (m.State == "2")) || (m.State == "4"))
                    select m).FirstOrDefault<Bud_OrganizationBudget>() != null)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool IsExistOrgan(string organizationBudgetId)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                if ((from m in entities.Bud_OrganizationBudget
                    where m.OrganizationBudgetId == organizationBudgetId
                    select m).FirstOrDefault<Bud_OrganizationBudget>() != null)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool isHaveEReport(string organizationBudgetId)
        {
            bool flag = false;
            using (pm2Entities entities = new pm2Entities())
            {
                if ((from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organizationBudgetId) && ((m.State == "1") || (m.State == "4"))
                    select m).Count<Bud_OrganizationBudget>() > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void Update(OrganizationBudget organBudget)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Bud_OrganizationBudget budget = (from m in entities.Bud_OrganizationBudget
                    where (m.OrganizationBudgetId == organBudget.OrganizationBudgetId) && (m.CBSCode == organBudget.CBSCode)
                    select m).FirstOrDefault<Bud_OrganizationBudget>();
                if (budget == null)
                {
                    throw new Exception("此项目的间接成本预算不存在!");
                }
                budget.BudgetAmount = new decimal?(organBudget.BudgetAmount);
                budget.AccountingAmount = new decimal?(organBudget.AccountAmount);
                budget.State = organBudget.State;
                entities.SaveChanges();
            }
        }

        public static void UpdateState(string CBSCode, string organizationBudgetId, string state)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Bud_OrganizationBudget budget = (from m in entities.Bud_OrganizationBudget
                    where (m.CBSCode == CBSCode) && (m.OrganizationBudgetId == organizationBudgetId)
                    select m).FirstOrDefault<Bud_OrganizationBudget>();
                if (budget != null)
                {
                    budget.State = state;
                    entities.SaveChanges();
                }
            }
        }

        public decimal AccountAmount { get; set; }

        public decimal BudgetAmount { get; set; }

        public string CBSCode { get; set; }

        public CostAccounting CostAcc
        {
            get
            {
                return CostAccounting.GetByCode(this.CBSCode);
            }
        }

        public string Id { get; set; }

        public DateTime InputDate { get; set; }

        public string InputUser { get; set; }

        public string Note { get; set; }

        public string OrganizationBudgetId { get; set; }

        public string State { get; set; }
    }
}

