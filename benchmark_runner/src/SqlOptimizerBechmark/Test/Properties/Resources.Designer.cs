﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Test.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;query_block&quot;: {
        ///    &quot;select_id&quot;: 1,
        ///    &quot;cost_info&quot;: {
        ///      &quot;query_cost&quot;: &quot;1.60&quot;
        ///    },
        ///    &quot;table&quot;: {
        ///      &quot;table_name&quot;: &quot;t3&quot;,
        ///      &quot;access_type&quot;: &quot;ALL&quot;,
        ///      &quot;rows_examined_per_scan&quot;: 3,
        ///      &quot;rows_produced_per_join&quot;: 3,
        ///      &quot;filtered&quot;: &quot;100.00&quot;,
        ///      &quot;cost_info&quot;: {
        ///        &quot;read_cost&quot;: &quot;1.00&quot;,
        ///        &quot;eval_cost&quot;: &quot;0.60&quot;,
        ///        &quot;prefix_cost&quot;: &quot;1.60&quot;,
        ///        &quot;data_read_per_join&quot;: &quot;48&quot;
        ///      },
        ///      &quot;used_columns&quot;: [
        ///        &quot;b&quot;
        ///      ]
        ///    },
        ///    &quot;select_list_subquer [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TestMySQLQueryPlan {
            get {
                return ResourceManager.GetString("TestMySQLQueryPlan", resourceCulture);
            }
        }
    }
}
