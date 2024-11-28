using System;
using BmiApp.Domain.Shared;

namespace BmiApp.Domain.BmiCalculater.Repository {
    
    /// <summary>
    /// 
    /// </summary>
    public interface IBmiDTO {

        string Name { get; set; }
        int Age { get; set; }
        float Height { get; set; }
        float Weight { get; set; }
        Gender Gender { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
