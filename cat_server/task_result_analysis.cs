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
    
    public partial class task_result_analysis
    {
        public int ID { get; set; }
        public int task_ID { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string device { get; set; }
        public Nullable<int> count { get; set; }
    }
}
