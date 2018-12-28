namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vklad")]
    public partial class Vklad
    {
        [Key]
        public int VkladId { get; set; }


        [Required]
        public int Balance { get; set; }

        [ForeignKey("Prog")]
        public int Prog_FK { get; set; }

        [ForeignKey("Client")]
        public int Client_FK { get; set; }


        public DateTime DateOpen { get; set; }

        public Prog Prog { get; set; }

        public Client Client { get; set; }

    }
}
