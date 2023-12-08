namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Empleado()
        {
            TBL_GuiaEntrada = new HashSet<TBL_GuiaEntrada>();
            TBL_ReciboRecojo = new HashSet<TBL_ReciboRecojo>();
        }

        [Key]
        [StringLength(8)]
        public string dni { get; set; }

        [StringLength(50)]
        public string apellidoPaterno { get; set; }

        [StringLength(50)]
        public string apellidoMaterno { get; set; }

        [StringLength(50)]
        public string nombres { get; set; }

        public byte? Distrito { get; set; }

        public string Direccion { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        public byte? estado { get; set; }

        public virtual TBL_Distrito TBL_Distrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GuiaEntrada> TBL_GuiaEntrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ReciboRecojo> TBL_ReciboRecojo { get; set; }
    }
}
