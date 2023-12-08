namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ReciboRecojo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ReciboRecojo()
        {
            TBL_DetalleRecibo = new HashSet<TBL_DetalleRecibo>();
        }

        [Key]
        public long numerorecibo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fecha { get; set; }

        [StringLength(8)]
        public string empleado { get; set; }

        public long? cliente { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? total { get; set; }

        public virtual TBL_Cliente TBL_Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DetalleRecibo> TBL_DetalleRecibo { get; set; }

        public virtual TBL_Empleado TBL_Empleado { get; set; }
    }
}
