
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Cat_Client.cat_server
{

using System;
    using System.Collections.Generic;
    
public partial class UnknowLogTable
{

    public long ID { get; set; }

    public Nullable<System.DateTime> Update_Time { get; set; }

    public long LogTableID { get; set; }

    public string Source { get; set; }

    public string EventName { get; set; }

    public string LevelDisplayName { get; set; }

    public Nullable<int> LogID { get; set; }

    public Nullable<int> LogTask { get; set; }

    public string ProviderName { get; set; }

    public Nullable<long> Count { get; set; }

    public string Detail { get; set; }

    public Nullable<bool> Enable { get; set; }

}

}
