using System;
using POWERSystem.Data.Common.Models;

namespace POWERSystem.Data.Models.Contracts;

public interface IOrder : IDeletableEntity
{
    Project Project { get; set; }

    //Enclosure Enclosure { get; set; }

    DateTime OrderDate { get; set; }

    int Status { get; set; }

    string Comment { get; set; }
}
