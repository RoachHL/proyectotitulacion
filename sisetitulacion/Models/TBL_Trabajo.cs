namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Trabajo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Trabajo()
        {
            TBL_DetalleGuia = new HashSet<TBL_DetalleGuia>();
        }

        [Key]
        public int idTrabajo { get; set; }

        [StringLength(50)]
        public string nombretrabajo { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? precio { get; set; }

        public string descriocion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DetalleGuia> TBL_DetalleGuia { get; set; }
    }
}
