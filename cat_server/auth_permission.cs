
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
    
public partial class auth_permission
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public auth_permission()
    {

        this.auth_group_permissions = new HashSet<auth_group_permissions>();

        this.auth_user_user_permissions = new HashSet<auth_user_user_permissions>();

    }


    public int id { get; set; }

    public string name { get; set; }

    public int content_type_id { get; set; }

    public string codename { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<auth_group_permissions> auth_group_permissions { get; set; }

    public virtual django_content_type django_content_type { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<auth_user_user_permissions> auth_user_user_permissions { get; set; }

}

}