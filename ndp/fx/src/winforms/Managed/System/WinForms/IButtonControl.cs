//------------------------------------------------------------------------------
// <copyright file="IButtonControl.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.Windows.Forms {

    using System.Diagnostics;

    /*
     * Copyright (c) 1997, Microsoft Corporation. All Rights Reserved.
     * Information Contained Herein is Proprietary and Confidential.
     *
     * @security(checkClassLinking=on)
     */

    using System;

    /// <include file='doc\IButtonControl.uex' path='docs/doc[@for="IButtonControl"]/*' />
    /// <devdoc>
    ///    <para>
    ///       Allows a control to act like a button
    ///       on a form.
    ///       
    ///    </para>
    /// </devdoc>
    public interface IButtonControl {

        /// <include file='doc\IButtonControl.uex' path='docs/doc[@for="IButtonControl.DialogResult"]/*' />
        /// <devdoc>
        ///    <para>Gets and sets the dialog result of the Button control. This is 
        ///       used as the result for the dialog on which the button is set to 
        ///       be an "accept" or "cancel" button.
        ///       </para>
        /// </devdoc>
        DialogResult DialogResult {get; set;}
        
        /// <include file='doc\IButtonControl.uex' path='docs/doc[@for="IButtonControl.NotifyDefault"]/*' />
        /// <devdoc>
        ///    <para>Notifies a control that it is the default button so that its appearance and behavior
        ///       is adjusted accordingly.
        ///       </para>
        /// </devdoc>
        void NotifyDefault(bool value);

        /// <include file='doc\IButtonControl.uex' path='docs/doc[@for="IButtonControl.PerformClick"]/*' />
        /// <devdoc>
        /// <para>Generates a <see cref='System.Windows.Forms.Control.Click'/>
        /// event for the control.</para>
        /// </devdoc>
        void PerformClick();
    }
}
