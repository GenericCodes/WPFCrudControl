using System;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Northwind.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();

            var appData = Directory.GetParent(
                Directory.GetParent(
                    Directory.GetParent(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "")).FullName).FullName)
                .FullName + "\\App_Data";

            AppDomain.CurrentDomain.SetData("DataDirectory", appData);
        }
    }
}
