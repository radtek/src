namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    //Journal
    public class OAJournalType
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
        /// 类型名称
        /// </summary>
        public virtual string name
        {
            get;
            set;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual int? is_use
        {
            get;
            set;
        }
        /// <summary>
        /// 标题模板
        /// </summary>
        public virtual string title_temp
        {
            get;
            set;
        }
        /// <summary>
        /// 内容模板
        /// </summary>
        public virtual string content_temp
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark
        {
            get;
            set;
        }
        /// <summary>
        /// 序号
        /// </summary>
        public virtual int? sort
        {
            get;
            set;
        }
    }
}


