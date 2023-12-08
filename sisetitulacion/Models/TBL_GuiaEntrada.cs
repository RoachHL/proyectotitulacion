namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_GuiaEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_GuiaEntrada()
        {
            TBL_DetalleGuia = new HashSet<TBL_DetalleGuia>();
        }

        [Key]
        public long numero { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fecha { get; set; }

        [StringLength(8)]
        public string empleado { get; set; }

        public long? Cliente { get; set; }

        public long? equipocl { get; set; }

        public string motivoingreso { get; set; }

        public virtual TBL_Cliente TBL_Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DetalleGuia> TBL_DetalleGuia { get; set; }

        public virtual TBL_Empleado TBL_Empleado { get; set; }

        public virtual TBL_Equipo TBL_Equipo { get; set; }
    }
}
