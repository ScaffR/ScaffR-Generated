#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
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
        [Key, Required, DataMember]
        public virtual int RoleId { get; set; }

        [Required, DataMember]
        public virtual string RoleName { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember, JsonIgnore, XmlIgnore]
        public virtual ICollection<UserRole> Users { get; set; }
    }
}