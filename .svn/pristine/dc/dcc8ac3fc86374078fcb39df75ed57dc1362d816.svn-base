namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    //Journal
    public class OAJournal
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
        /// 类型ID
        /// </summary>
        public virtual string type_id
        {
            get;
            set;
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public virtual string project_id
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string title
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public virtual string creater
        {
            get;
            set;
        }
        /// <summary>
        /// 日志状态
        /// </summary>
        public virtual int? status
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? start_time
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? end_time
        {
            get;
            set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string content
        {
            get;
            set;
        }
        /// <summary>
        /// 封面
        /// </summary>
        public virtual string cover
        {
            get;
            set;
        }
        /// <summary>
        /// 附件
        /// </summary>
        public virtual string attachs
        {
            get;
            set;
        }
        /// <summary>
        /// 视频
        /// </summary>
        public virtual string vidios
        {
            get;
            set;
        }
        /// <summary>
        /// 语音
        /// </summary>
        public virtual string voices
        {
            get;
            set;
        }
        /// <summary>
        /// 关联任务
        /// </summary>
        public virtual string task_id
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? create_date
        {
            get;
            set;
        }
    }
}


