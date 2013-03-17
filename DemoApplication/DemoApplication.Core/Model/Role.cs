namespace DemoApplication.Core.Model
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    #endregion

    [DataContract]
    [DisplayColumn("RoleName")]
    public partial class Role : DomainObject
    {
        [Required, DataMember]
        public virtual string RoleName { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember, JsonIgnore, XmlIgnore]
        public virtual ICollection<UserRole> Users { get; set; }
    }
}