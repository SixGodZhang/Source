//---------------------------------------------------------------------------
//
// File: ClipboardData.cs
//
// Description:
//      An abstract clipboard data class
//
// Features:
//
// History:
//  11/17/2004 waynezen:       Created 
//
// Copyright (C) 2001 by Microsoft Corporation.  All rights reserved.
// 
//---------------------------------------------------------------------------

using System;
using System.Windows;
using System.Security;

namespace MS.Internal.Ink
{
    internal abstract class ClipboardData
    {
        //-------------------------------------------------------------------------------
        //
        // Constructors
        //
        //-------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------
        //
        // Internal Methods
        //
        //-------------------------------------------------------------------------------

        #region Internal Methods

        /// <summary>
        /// Copy the data to the IDataObject
        /// </summary>
        /// <param name="dataObject">The IDataObject instance</param>
        /// <returns>Returns true if the data is copied. Otherwise, returns false</returns>
        /// <SecurityNote>
        ///     Critical: This code copies ink content to the clipboard and accepts a dataobject which is
        ///     created under an elevation
        /// </SecurityNote>
        [SecurityCritical]
        internal bool CopyToDataObject(IDataObject dataObject)
        {
            // Check if the data can be copied
            if ( CanCopy() )
            {
                // Do copy.
                DoCopy(dataObject);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Paste the data from the IDataObject
        /// </summary>
        /// <param name="dataObject">The IDataObject instance</param>
        internal void PasteFromDataObject(IDataObject dataObject) 
        {
            // Check if we can paste.
            if ( CanPaste(dataObject) )
            {
                // Do Paste.
                DoPaste(dataObject);
            }
        }

        internal abstract bool CanPaste(IDataObject dataObject);
        
        #endregion Internal Methods

        //-------------------------------------------------------------------------------
        //
        // Protected Methods
        //
        //-------------------------------------------------------------------------------

        #region Protected Methods

        // Those are the abstract methods which need to be implemented in the derived classes.
        protected abstract bool CanCopy();
        protected abstract void DoCopy(IDataObject dataObject);
        protected abstract void DoPaste(IDataObject dataObject);

        #endregion Protected Methods
    
    }
}
