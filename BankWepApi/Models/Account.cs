﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWepApi.Models
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string IBAN { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public virtual Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Account")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}