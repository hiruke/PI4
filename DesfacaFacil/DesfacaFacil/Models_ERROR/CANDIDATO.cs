
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DesfacaFacil.Models
{

    using System;
    using System.Collections.Generic;

    public partial class CANDIDATO
    {

        public string CANID { get; set; }

        public Nullable<decimal> USID { get; set; }

        public Nullable<decimal> AID { get; set; }



        public virtual ANUNCIO ANUNCIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

    }
}