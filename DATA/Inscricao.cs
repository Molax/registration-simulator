//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inscricao
    {
        public Inscricao()
        {
            this.Insc_Evento = new HashSet<Insc_Evento>();
        }
    
        public int PK_INSCRICAO { get; set; }
        public string CPF { get; set; }
        public System.DateTime DATE { get; set; }
    
        public virtual ICollection<Insc_Evento> Insc_Evento { get; set; }
        public virtual Participante Participante { get; set; }
    }
}
