using System;

namespace CommanderGql.Domain.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}