//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
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
