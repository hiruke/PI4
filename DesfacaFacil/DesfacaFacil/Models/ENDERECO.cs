//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesfacaFacil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENDERECO
    {
        public string EID { get; set; }
        public decimal USID { get; set; }
        public string PAIS { get; set; }
        public string ESTADO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public string RUA { get; set; }
        public Nullable<decimal> NUMERO { get; set; }
        public string CEP { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
