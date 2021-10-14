using System;

namespace CRMGURU.Data.Util
{
    public interface IUniqueIdentifiedEntity
    {
        Guid Id { get; set; }
    }
}
