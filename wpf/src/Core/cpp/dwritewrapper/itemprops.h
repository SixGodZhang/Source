#ifndef _ITEM_PROPS_H
#define _ITEM_PROPS_H

#include "Common.h"
#include "ItemizerHelper.h"
#include "NativePointerWrapper.h"

using namespace System::Security;
using namespace System::Security::Permissions;
using namespace MS::Internal::Text::TextInterface::Generics;

namespace MS { namespace Internal { namespace Text { namespace TextInterface
{
    private ref struct ItemProps sealed
    {
        private:
            CultureInfo^ _digitCulture;
            bool         _hasCombiningMark;
            bool         _needsCaretInfo;
            bool         _hasExtendedCharacter;
            bool         _isIndic;
            bool         _isLatin;
            NativeIUnknownWrapper<IDWriteNumberSubstitution>^ _numberSubstitution;
            NativePointerWrapper<DWRITE_SCRIPT_ANALYSIS>^     _scriptAnalysis;

        public:
            ///<remarks>
            /// returns void* because returning IDWriteNumberSubstitution* generates asmmeta generation errors.
            ///</remarks>
            property void* NumberSubstitutionNoAddRef
            {
                [SecurityCritical]
                void* get();
            }

            ///<remarks>
            /// returns void* because returning DWRITE_SCRIPT_ANALYSIS* generates asmmeta generation errors.
            ///</remarks>
            property void* ScriptAnalysis
            {
                [SecurityCritical]
                void* get();
            }

            property CultureInfo^ DigitCulture
            {
                CultureInfo^ get();
            }

            property bool HasExtendedCharacter
            {
                bool get();
            }

            property bool NeedsCaretInfo
            {
                bool get();
            }

            property bool IsIndic
            {
                bool get();
            }

            property bool IsLatin
            {
                bool get();
            }

            property bool HasCombiningMark
            {
                bool get();
            }

            bool CanShapeTogether(ItemProps^ other);

            ///<remarks>
            /// Applying custom attributes on the constructor implementation
            /// causes a compiler error (a custom attribute may not be used inside a function)
            ///</remarks>
            ///<SecurityNote>
            /// Critical    - Asserts to allocate and initialize unmanaged memory.
            /// TreatAsSafe - Initializes unmanaged memory to known safe state.
            ///</SecurityNote>
            [SecuritySafeCritical]
            [SecurityPermission(SecurityAction::Assert, UnmanagedCode = true)]
            ItemProps();

            ///<SecurityNote>
            /// Critical    - Asserts to initialize unmanaged memory.
            ///</SecurityNote>
            [SecurityCritical]
            static ItemProps^ Create(
                void* scriptAnalysis,
                void* numberSubstitution,
                CultureInfo^ digitCulture,
                bool hasCombiningMark,
                bool needsCaretInfo,
                bool hasExtendedCharacter,
                bool isIndic,
                bool isLatin
                );
    };
}}}}//MS::Internal::Text::TextInterface

#endif //_ITEM_PROPS_H
