//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NLog.Vision
{
    using System;
    using System.Collections.Generic;
    
    public partial class GLOBAL_AUDIT_DATA
    {
        public string ENTITY { get; set; }
        public string ACTION { get; set; }
        public string COLUMN_CHANGED { get; set; }
        public string OLD_VALUE { get; set; }
        public string NEW_VALUE { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public string WINDOWS_CREATED_BY { get; set; }
        public string WINDOWS_UPDATED_BY { get; set; }
        public string MACHINE_NAME { get; set; }
        public int GLOBAL_AUDIT_ID { get; set; }
    
        public virtual GLOBAL_AUDIT GLOBAL_AUDIT { get; set; }
    }
}
