using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Signature
    {
        [Key] public int SignatureId { get; set; }

        [Required] public string ActualSignature { get; set; }

        [Required] public string SignatureName { get; set; }

        public List<Virus> Viruses { get; set; }   
    }
}