namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class AsTest
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
            return (this.Id == ((PCCautionMoney)obj).Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }

        [DataMember]
        public virtual string Id { get; set; }
       
         [DataMember]
        public virtual string ApplicantId { get; set; }
        public virtual DateTime ApplicationDate { get; set; }
        public virtual decimal Cash { get; set; }
        public virtual string ApplicationReason { get; set; }
        public virtual int FlowState { get; set; }
    }
}


