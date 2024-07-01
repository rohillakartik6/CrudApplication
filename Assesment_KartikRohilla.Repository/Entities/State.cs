﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assesment_KartikRohilla.Infrastructure.Entities;

[Table("State")]
public partial class State
{
    [Key]
    public int StateId { get; set; }

    [Required]
    [StringLength(100)]
    public string StateName { get; set; }

    public int? CountryId { get; set; }

    [InverseProperty("State")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    [ForeignKey("CountryId")]
    [InverseProperty("States")]
    public virtual Country Country { get; set; }

    [InverseProperty("State")]
    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();
}