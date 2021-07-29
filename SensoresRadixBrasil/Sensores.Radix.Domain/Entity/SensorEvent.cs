using FluentValidation;
using Sensores.Radix.Domain.Core;
using System;

namespace Sensores.Radix.Domain.Entity
{
    public class SensorEvent : Entity<SensorEvent>
    {
        public long Timestamp { get; private set; }
        public string Tag => $"{Country}.{Region}.{SensorName}";
        public string Valor { get; private set; }
        public string SensorName { get; private set; }
        public string Country { get; private set; }
        public string Region { get; private set; }

        public SensorEvent() { }

        public SensorEvent(Guid id, long timestamp, string valor, string sensorName, string country, string region)
        {
            Timestamp = timestamp;
            Valor = valor;
            SensorName = sensorName;
            Country = country;
            Region = region;
        }

        public override bool IsValid()
        {
            MapRules();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        void MapRules()
        {
            RuleFor(s => s.SensorName).NotEmpty().WithMessage("Nome do sensor inválido!");
            RuleFor(s => s.Country).NotEmpty().WithMessage("País do sensor inválido!");
            RuleFor(s => s.Region).NotEmpty().WithMessage("Região do sensor inválida!");
        }
    }
}
