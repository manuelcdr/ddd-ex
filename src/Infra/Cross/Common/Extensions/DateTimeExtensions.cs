using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Cross.Common.Utils;
using System;

namespace PGLaw.Infra.Cross.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DiasDaSemana ConverterParaDiasDaSemana(this DayOfWeek obj)
        {
            return Conversor.Converter(obj);
        }
    }
}
