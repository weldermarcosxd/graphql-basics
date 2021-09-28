using CommanderGql.Domain.Interfaces;
using System;

namespace CommanderGql.Domain.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}