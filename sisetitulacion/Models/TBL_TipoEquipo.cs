namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TipoEquipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_TipoEquipo()
        {
            TBL_Equipo = new HashSet<TBL_Equipo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id_TipoEquipo { get; set; }

        [StringLength(50)]
        public string nombreTipoEquipo { get; set; }

        [StringLength(5)]
        public string abreviatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Equipo> TBL_Equipo { get; set; }
    }
}
