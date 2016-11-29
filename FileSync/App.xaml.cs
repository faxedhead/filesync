﻿namespace FileSync
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using FileSync.Model;
    using FileSync.View;
    using FileSync.ViewModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MainWindow _view;

        public App()
        {
            Exit += App_Exit;
            var settingsPath = Environment.GetCommandLineArgs().Skip(1).FirstOrDefault();
            if (settingsPath == null || !File.Exists(settingsPath))
            {
                settingsPath = "FileSync.settings.json";
            }

            _view = new MainWindow();
            _view.Present(settingsPath);
        }

        public static bool FirstRun { get; set; }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            _view?.Dispose();
        }
    }
}