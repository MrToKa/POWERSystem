#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POWERSystem.Data.Common.Constants;

namespace POWERSystem.Data.Models;

public class Storage
{
    public Storage()
    {
        this.Parts = new HashSet<Part>();
        this.Cables = new HashSet<Cable>();
        this.PartOrders = new HashSet<PartOrder>();
        this.CableOrders = new HashSet<CableOrder>();
        this.Equipment = new HashSet<Equipment>();
    }

    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the storage.
    /// </summary>
    [Required]
    [MaxLength(StorageConstants.NameMaxLength)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the location of the storage.
    /// </summary>
    [Required]
    [MaxLength(StorageConstants.LocationMaxLength)]
    public string Location { get; set; }

    [ForeignKey(nameof(Project))]
    public string? ProjectId { get; set; }

    public Project Project { get; set; }

    public virtual IEnumerable<Part> Parts { get; set; }

    public virtual IEnumerable<Cable> Cables { get; set; }

    public virtual IEnumerable<PartOrder> PartOrders { get; set; }

    public virtual IEnumerable<CableOrder> CableOrders { get; set; }

    public virtual IEnumerable<Equipment> Equipment { get; set; }
}