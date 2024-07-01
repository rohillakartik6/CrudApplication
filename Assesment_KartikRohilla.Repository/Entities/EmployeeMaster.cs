﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assesment_KartikRohilla.Infrastructure.Entities;

[Table("EmployeeMaster")]
[Index("MobileNumber", Name = "UQ__Employee__250375B13C280B73", IsUnique = true)]
[Index("PassportNumber", Name = "UQ__Employee__45809E7152555731", IsUnique = true)]
[Index("EmailAddress", Name = "UQ__Employee__49A14740C36F62AC", IsUnique = true)]
[Index("PanNumber", Name = "UQ__Employee__7C38BFC87EE913F1", IsUnique = true)]
[Index("EmailAddress", Name = "uq_mail", IsUnique = true)]
[Index("MobileNumber", Name = "uq_mobile", IsUnique = true)]
[Index("PanNumber", Name = "uq_pan", IsUnique = true)]
[Index("PassportNumber", Name = "uq_pas", IsUnique = true)]
public partial class EmployeeMaster
{
    [Key]
    [Column("Row_Id")]
    public int RowId { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string EmployeeCode { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string EmailAddress { get; set; }

    [Required]
    [StringLength(15)]
    [Unicode(false)]
    public string MobileNumber { get; set; }

    [Required]
    [StringLength(12)]
    [Unicode(false)]
    public string PanNumber { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string PassportNumber { get; set; }

    [StringLength(100)]
    public string ProfileImage { get; set; }

    public byte? Gender { get; set; }

    public bool IsActive { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfJoinee { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("EmployeeMasters")]
    public virtual City City { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("EmployeeMasters")]
    public virtual Country Country { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("EmployeeMasters")]
    public virtual State State { get; set; }
}