#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Model
{
    #region

    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion

    [DisplayColumn("Log")]
    public class Log 
    {
        [Key]
        public virtual int LogId { get; set; }

        public virtual DateTime? Date { get; set; }

        [StringLength(255)]
        public virtual string Thread { get; set; }

        [StringLength(50)]
        public virtual string Level { get; set; }

        [StringLength(255)]
        public virtual string Logger { get; set; }

        [StringLength(4000)]
        public virtual string Message { get; set; }

        [StringLength(2000)]
        public virtual string Exception { get; set; }
    }
}
