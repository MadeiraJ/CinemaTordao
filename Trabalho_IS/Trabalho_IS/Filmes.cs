//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trabalho_IS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Filmes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filmes()
        {
            this.Filmes_Sala = new HashSet<Filmes_Sala>();
        }
    
        public int id_filme { get; set; }
        public string nome_filme { get; set; }
        public System.TimeSpan duracao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Filmes_Sala> Filmes_Sala { get; set; }
    }
}
