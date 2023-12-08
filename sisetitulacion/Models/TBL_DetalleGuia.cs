namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DetalleGuia
    {
        [Key]
        public long iddetalleguia { get; set; }

        public long? numguia { get; set; }

        public int? trabajo { get; set; }

        [StringLength(50)]
        public string Descripciontrabajo { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? precio { get; set; }

        public virtual TBL_GuiaEntrada TBL_GuiaEntrada { get; set; }

        public virtual TBL_Trabajo TBL_Trabajo { get; set; }
    }
}
