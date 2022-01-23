using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Exercice.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IMapper Mapper { get; }
        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
        }
    }
}
