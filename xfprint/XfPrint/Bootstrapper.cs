using Microsoft.Practices.Unity;
using Prism.Unity;

using System.Windows;
using Prism.Modularity;
using System.Reflection;

namespace XfPrint
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Plugins" };
        //}


        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            Prism.Mvvm.ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
                return System.Type.GetType(viewModelName);
            });
        }

    }
}
