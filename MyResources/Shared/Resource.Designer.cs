﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MyResources.Shared {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCode()]
    [CompilerGenerated()]
    public class Resource {
        
        private static ResourceManager resourceMan;
        
        private static CultureInfo resourceCulture;
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("MyResources.Shared.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fout.
        /// </summary>
        public static string Error {
            get {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Er is een fout opgetreden bij het verwerken van uw verzoek..
        /// </summary>
        public static string ErrorOccuredText {
            get {
                return ResourceManager.GetString("ErrorOccuredText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hallo.
        /// </summary>
        public static string Hello {
            get {
                return ResourceManager.GetString("Hello", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vergrendeld.
        /// </summary>
        public static string LockedOut {
            get {
                return ResourceManager.GetString("LockedOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dit account is vergrendeld, probeer het later opnieuw..
        /// </summary>
        public static string LockedOutText {
            get {
                return ResourceManager.GetString("LockedOutText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Aanmelden.
        /// </summary>
        public static string LogIn {
            get {
                return ResourceManager.GetString("LogIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Afmelden.
        /// </summary>
        public static string LogOff {
            get {
                return ResourceManager.GetString("LogOff", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Beheer.
        /// </summary>
        public static string Manage {
            get {
                return ResourceManager.GetString("Manage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Er is niets veranderd!.
        /// </summary>
        public static string NothingChanged {
            get {
                return ResourceManager.GetString("NothingChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registreer.
        /// </summary>
        public static string Register {
            get {
                return ResourceManager.GetString("Register", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Er is iets fout gegaan! Probeer opnieuw..
        /// </summary>
        public static string SomethingWentWrong {
            get {
                return ResourceManager.GetString("SomethingWentWrong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uw wijzigingen zijn opgeslagen!.
        /// </summary>
        public static string YourChangesHaveBeenSaved {
            get {
                return ResourceManager.GetString("YourChangesHaveBeenSaved", resourceCulture);
            }
        }
    }
}
