namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DetalleRecibo
    {
        [Key]
        public long iddetallerecibo { get; set; }

        public long? recibo { get; set; }

        [StringLength(50)]
        public string trabajo { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? precio { get; set; }

        public virtual TBL_ReciboRecojo TBL_ReciboRecojo { get; set; }
    }
}
