using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMArch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
         protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            #region Resouce merging

            string resourceDictURI = @"pack://application:,,,/ResourceDictionary/ResourceDict.xaml";

            MainWindow wd = new MVVMArch.MainWindow();

            ResourceDictionary rsDict = new ResourceDictionary();
            rsDict.Source = new Uri(resourceDictURI);

            wd.Resources.MergedDictionaries.Add(rsDict);
            wd.Show(); 
            #endregion

        }


    }
}
