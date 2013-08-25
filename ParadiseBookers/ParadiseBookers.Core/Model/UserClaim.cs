﻿#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParadiseBookers.Core.Model
{
    #region

    

    #endregion

    public class UserClaim
    {
        [Key]
        [Column(Order = 1)]
        public virtual int UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public virtual string Type { get; set; }
        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public virtual string Value { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
