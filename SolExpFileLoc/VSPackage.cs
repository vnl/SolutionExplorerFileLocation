using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace SolExpFileLoc
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]       
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidFileLocCommandPackageString)]
    public sealed class VSPackage : Package
    {
        protected override void Initialize()
        {
            FileLocCommand.Initialize(this);
            base.Initialize();
        }

    }
}
