namespace cn.justwin.Domain.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class PCCautionMoney
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
       
        public virtual string Number { get; set; }
         [DataMember]
        public virtual string ApplicantId { get; set; }
        public virtual string DepartmentId { get; set; }
        public virtual PTPrjInfo ProjectId { get; set; }
        public virtual DateTime ApplicationDate { get; set; }
        public virtual string TypeId { get; set; }
        public virtual string ProjectAttribute { get; set; }
        public virtual string Beneficiary { get; set; }
        public virtual string ProjectManager { get; set; }
        public virtual string CollectionUnit { get; set; }
        public virtual string Account { get; set; }
        public virtual string Bank { get; set; }
        public virtual decimal Cash { get; set; }
        public virtual DateTime CashStartDate { get; set; }
        public virtual DateTime CashEndDate { get; set; }
        public virtual int IfFeesPoundage { get; set; }
        public virtual string Poundage { get; set; }
        public virtual int IfFeesCautionMoney { get; set; }
        public virtual decimal CautionMoney { get; set; }
        public virtual string ApplicationReason { get; set; }
        public virtual string EnclosureId { get; set; }
        public virtual int FlowState { get; set; }
        public virtual string InputUserId { get; set; }
        public virtual DateTime InputDate { get; set; }
        public virtual string ModifyUserId { get; set; }
        public virtual DateTime ModifyDate { get; set; }
        public virtual decimal RepayCash { get; set; }
        public virtual int RepayFlowState { get; set; }
    }
}


