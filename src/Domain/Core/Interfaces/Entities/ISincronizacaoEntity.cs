using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface ISincronizacaoEntity
    {
        int IdExterno { get; set; }

        // qual campo usar para controle? data ou timestamp????
    }
}
