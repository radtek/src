namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    //Journal
    public class OAJournalAppend
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (base.GetType() != obj.GetType())
            {
                return false;
            }
            return (this.Id == ((OAJournal)obj).Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return this.Id.ToString();
        }
        /// <summary>
        /// Id
        /// </summary>
        //[DataMember]
        public virtual string Id
        {
            get;
            set;
        }
        /// <summary>
        /// 日志ID
        /// </summary>
        public virtual string journal_id
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public virtual string user_id
        {
            get;
            set;
        }
        /// <summary>
        /// 用户类型（0 审阅人、1相关人、2审阅相关人）
        /// </summary>
        public virtual int? user_type
        {
            get;
            set;
        }
        /// <summary>
        /// 查看时间
        /// </summary>
        public virtual DateTime? look_time
        {
            get;
            set;
        }
        /// <summary>
        /// 评价(评分)
        /// </summary>
        public virtual string score
        {
            get;
            set;
        }
    }
}


