using System;
using FluentValidation;
using FluentValidation.Results;

namespace Sensores.Radix.Domain.Core
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
