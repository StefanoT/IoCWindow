/*
Project: IoC Window demo
Author: Stefano Tommesani
Website: http://www.tommesani.com
Microsoft Public License (MS-PL) [OSI Approved License]
This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
1. Definitions
The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
A "contribution" is the original software, or any additions or changes to the software.
A "contributor" is any person that distributes its contribution under this license.
"Licensed patents" are a contributor's patent claims that read directly on its contribution.
2. Grant of Rights
(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
3. Conditions and Limitations
(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IoCResolve.Log;
using IoCResolve.Container;

namespace IoCResolve
{
    public partial class MainForm : Form
    {
        private ILogger Logger;
        public MainForm(ILogger _Logger)
        {
            InitializeComponent();

            Logger = _Logger;

            CastleContainer.Instance.Kernel.ComponentCreated += Kernel_ComponentCreated;
            CastleContainer.Instance.Kernel.ComponentDestroyed += Kernel_ComponentDestroyed;
        }

        /// <summary>
        /// log when a new component is create in the container
        /// </summary>
        /// <param name="model"></param>
        /// <param name="instance"></param>
        void Kernel_ComponentCreated(Castle.Core.ComponentModel model, object instance)
        {
            Logger.Debug("Component created: " + model.Name);
        }

        /// <summary>
        /// log when a component resolved by the contained is destroyed
        /// </summary>
        /// <param name="model"></param>
        /// <param name="instance"></param>
        void Kernel_ComponentDestroyed(Castle.Core.ComponentModel model, object instance)
        {
            Logger.Debug("Component destroyed: " + model.Name);
        }

        /// <summary>
        /// open a child window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>the code that disposes the child window is included in the handler for the Closed event</remarks>
        private void openButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Creating new child window");
            ChildForm newChildForm = CastleContainer.Instance.Resolve<ChildForm>();
            newChildForm.Closed += delegate
            {
                Logger.Info("Closed child window");
                CastleContainer.Instance.Release(newChildForm);
            };
            newChildForm.Show();
            Logger.Info("Returned from child window");                    
        }

        /// <summary>
        /// open a child dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>as the ShowDialog returns when the child window is closed, the child window is disposed just after the call</remarks>
        private void openDialogButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Creating new child dialog window");
            ChildForm newChildForm = CastleContainer.Instance.Resolve<ChildForm>();
            newChildForm.ShowDialog();
            Logger.Info("Returned from child dialog window");
            CastleContainer.Instance.Release(newChildForm);
        }
    }
}
