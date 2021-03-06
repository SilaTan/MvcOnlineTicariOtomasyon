using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage="En fazla 30 karakterlik giriş yapabilirsiniz!")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")] //AllowNull tiki kalkar,Boş geçilemez.
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool CariDurum { get; set; }

        //İlişkiler
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}