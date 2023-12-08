namespace sisetitulacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Usuario
    {
        [Key]
        public long id_usuario { get; set; }

        public byte? TipoUsuario { get; set; }

        [StringLength(50)]
        public string nombresuario { get; set; }

        [Required]
        [StringLength(15)]
        public string contrasenha { get; set; }

        public virtual TBL_tipoUsuario TBL_tipoUsuario { get; set; }
    }
}
