//------------------------------------------------------------------------------
// <copyright file="PropertyTabChangedEvent.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.Windows.Forms {

    using System.Diagnostics;
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using Microsoft.Win32;
    using System.Windows.Forms.Design;

    /// <include file='doc\PropertyTabChangedEvent.uex' path='docs/doc[@for="PropertyTabChangedEventArgs"]/*' />
    /// <devdoc>
    ///    <para>[To be supplied.]</para>
    /// </devdoc>
    [System.Runtime.InteropServices.ComVisible(true)]
    public class PropertyTabChangedEventArgs : EventArgs{
        
        private PropertyTab oldTab;
        private PropertyTab newTab;

        /// <include file='doc\PropertyTabChangedEvent.uex' path='docs/doc[@for="PropertyTabChangedEventArgs.PropertyTabChangedEventArgs"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public PropertyTabChangedEventArgs(PropertyTab oldTab, PropertyTab newTab) {
            this.oldTab = oldTab;
            this.newTab = newTab;
        }
        
        /// <include file='doc\PropertyTabChangedEvent.uex' path='docs/doc[@for="PropertyTabChangedEventArgs.OldTab"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public PropertyTab OldTab {
            get {
                return oldTab;
            }
        }
        
        /// <include file='doc\PropertyTabChangedEvent.uex' path='docs/doc[@for="PropertyTabChangedEventArgs.NewTab"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public PropertyTab NewTab {
            get {
                return newTab;
            }
        }
    }
}
