using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Application.Juridico.Models.Common
{
    public class DefaultVM<TKey> : DefaultVM
    {
        public new TKey Id { get; set; }
    }

    public class DefaultVM
    {
        public object Id { get; set; }
    }
}
