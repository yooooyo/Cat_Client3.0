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
    
    public partial class taskTable
    {
        public int ID { get; set; }
        public string SN { get; set; }
        public string task { get; set; }
        public string state { get; set; }
        public string result { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public Nullable<System.DateTime> finishTime { get; set; }
        public string series { get; set; }
        public Nullable<int> local_id { get; set; }
        public string result_id { get; set; }
    }
}
