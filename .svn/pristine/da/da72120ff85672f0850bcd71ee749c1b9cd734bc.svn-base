namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    //Journal
    public class OAJournalComment
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
        /// 评论时间
        /// </summary>
        public virtual DateTime? time
        {
            get;
            set;
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        public virtual string content
        {
            get;
            set;
        }
    }
}


