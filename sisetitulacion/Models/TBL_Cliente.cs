namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Cliente()
        {
            TBL_Equipo = new HashSet<TBL_Equipo>();
            TBL_GuiaEntrada = new HashSet<TBL_GuiaEntrada>();
            TBL_ReciboRecojo = new HashSet<TBL_ReciboRecojo>();
        }

        [Key]
        public long id_cliente { get; set; }

        [StringLength(3)]
        public string Tipo_documento { get; set; }

        [StringLength(15)]
        public string Numero_Documento { get; set; }

        public string Nombre_Cliente { get; set; }

        public byte? Distrito { get; set; }

        public string Direccion { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        public virtual TBL_Distrito TBL_Distrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Equipo> TBL_Equipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GuiaEntrada> TBL_GuiaEntrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ReciboRecojo> TBL_ReciboRecojo { get; set; }
    }
}
