/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/

/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EnvDTE;

using System.Runtime.InteropServices;

namespace Microsoft.Samples.VisualStudio.CodeDomCodeModel {
    [ComVisible(true)]
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable")]
    [SuppressMessage("Microsoft.Interoperability", "CA1405:ComVisibleTypeBaseTypesShouldBeComVisible")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public class CodeDomCodeElements : List<CodeElement>, CodeElements {
        DTE dte;
        object parent;

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "0#dte")]
        public CodeDomCodeElements(DTE dte, object parent) {
            this.dte = dte;
            this.parent = parent;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void AddElement(CodeElement element) {
            Add(element);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void InsertElement(int index, CodeElement element) {
            Insert(index, element);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void RemoveElement(CodeElement element) {
            Remove(element);
        }

        #region CodeElements Members

        public new int Count {
            get { return base.Count; }
        }

        public bool CreateUniqueID(string Prefix, ref string NewName) {
            NewName = Guid.NewGuid().ToString();
            return true;
        }

        public DTE DTE {
            get { return dte; }
        }

        public object Parent {
            get { return parent; }
        }

        public new System.Collections.IEnumerator GetEnumerator() {
            return base.GetEnumerator();
        }

        public CodeElement Item(object index) {            
            return this[PositionToIndex(index)];
        }

        public void Reserved1(object Element) {
            throw new NotImplementedException();
        }

        #endregion

        private int PositionToIndex(object element) {
            CodeElement cde = element as CodeElement;
            if (cde != null) {
                return this.IndexOf(cde);
            }

            int pos = (int)element;
            if (pos == -1) {                
                return this.Count;
            } 
            
            return pos - 1;
        }

    }

}
