//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AML.Infrastructure.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIAGNOSI
    {
        public int id { get; set; }
        public Nullable<System.DateTime> ISSUE_DATE { get; set; }
        public string TREATMENT { get; set; }
        public string REMARKS { get; set; }
        public Nullable<int> NURSE_ID { get; set; }
        public Nullable<int> DOC_ID { get; set; }
    }
}
