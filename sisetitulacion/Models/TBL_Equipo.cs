namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Equipo()
        {
            TBL_GuiaEntrada = new HashSet<TBL_GuiaEntrada>();
        }

        [Key]
        public long idequipo { get; set; }

        public long? Cliente { get; set; }

        public byte? tipoequipo { get; set; }

        public byte? marca { get; set; }

        [StringLength(50)]
        public string modelo { get; set; }

        [StringLength(100)]
        public string numersoserie { get; set; }

        public string observaciones { get; set; }

        public virtual TBL_Cliente TBL_Cliente { get; set; }

        public virtual TBL_Marca TBL_Marca { get; set; }

        public virtual TBL_TipoEquipo TBL_TipoEquipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GuiaEntrada> TBL_GuiaEntrada { get; set; }
    }
}
