using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace SolExpFileLoc
{
    internal sealed class FileLocCommand
    {
        public const int CommandId = 0x0100;

        public static readonly Guid CommandSet = new Guid("f1a36b80-a278-40b8-bbb3-25257ddce6f4");

        private readonly Package package;

        private FileLocCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static FileLocCommand Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        public static void Initialize(Package package)
        {
            Instance = new FileLocCommand(package);
        }

        private void MenuItemCallback(object sender, EventArgs e)
        {
            //DTE dte = (DTE)GetService(typeof(DTE));
            //string document = dte.ActiveDocument.FullName;
            var dte = (DTE2) ServiceProvider.GetService(typeof(DTE));
            string curFile = GetSelectedFile(dte);
        }

        public string GetSelectedFile(DTE2 dte)
        {
            string document = dte.ActiveDocument.Name;
            return document;
        }

    }
}
