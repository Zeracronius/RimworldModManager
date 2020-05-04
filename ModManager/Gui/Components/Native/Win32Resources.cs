/*
_____________________________________
© Pedro Miguel C. Cardoso 2007.
All rights reserved.
http://pmcchp.com/

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

1) Redistributions of source code must retain the above copyright notice, 
   this list of conditions and the following disclaimer. 
2) Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution. 
3) Neither the name of the ORGANIZATION nor the names of its contributors
   may be used to endorse or promote products derived from this software
   without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
THE POSSIBILITY OF SUCH DAMAGE.
*/
// Copyright (c) Sven Groot (Ookii.org) 2006

using System;
using System.Collections.Generic;
using System.Text;

namespace ModManager.Gui.Components.Native
{
    internal class Win32Resources : IDisposable
    {
        private SafeModuleHandle _moduleHandle;
        private const int _bufferSize = 500;

        public Win32Resources(string module)
        {
            _moduleHandle = Native.NativeMethods.LoadLibrary(module);
            if( _moduleHandle.IsInvalid )
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());
        }

        public string LoadString(uint id)
        {
            CheckDisposed();

            StringBuilder buffer = new StringBuilder(_bufferSize);
            if( Native.NativeMethods.LoadString(_moduleHandle, id, buffer, buffer.Capacity + 1) == 0 )
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());
            return buffer.ToString();
        }

        public string FormatString(uint id, params string[] args)
        {
            CheckDisposed();

            IntPtr buffer = IntPtr.Zero;
            string source = LoadString(id);

            // For some reason FORMAT_MESSAGE_FROM_HMODULE doesn't work so we use this way.
            Native.NativeMethods.FormatMessageFlags flags = Native.NativeMethods.FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | Native.NativeMethods.FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY | Native.NativeMethods.FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING;

            IntPtr sourcePtr = System.Runtime.InteropServices.Marshal.StringToHGlobalAuto(source);
            try
            {
                if( Native.NativeMethods.FormatMessage(flags, sourcePtr, id, 0, ref buffer, 0, args) == 0 )
                    throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(sourcePtr);
            }

            string result = System.Runtime.InteropServices.Marshal.PtrToStringAuto(buffer);
            // FreeHGlobal calls LocalFree
            System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if( disposing )
                _moduleHandle.Dispose();
        }

        private void CheckDisposed()
        {
            if( _moduleHandle.IsClosed )
            {
                throw new ObjectDisposedException("Win32Resources");
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion    
    }
}
