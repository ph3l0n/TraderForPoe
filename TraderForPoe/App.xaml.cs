﻿using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;
using TraderForPoe.Classes;
using TraderForPoe.Properties;
using TraderForPoe.ViewModel;
using TraderForPoe.Windows;

namespace TraderForPoe
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;

        public App()
        {
            CheckForSettingsUpgrade();
            RegisterViewModel();
            CheckForLogFile();
        }

        private void CheckForLogFile()
        {
            //TODO Add option to turn off check
            LogFileCheck.CheckForClientTxt();
        }

        private void CheckForSettingsUpgrade()
        {
            // Check if settings upgrade is needed
            if (Settings.Default.UpgradeSettingsRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeSettingsRequired = false;
                Settings.Default.Save();
            }
        }

        private void RegisterViewModel()
        {
            WindowViewLoaderService.Register(typeof(LogMonitorViewModel), typeof(LogMonitor));
            WindowViewLoaderService.Register(typeof(MainWindowViewModel), typeof(MainWindow));
            WindowViewLoaderService.Register(typeof(TradeHistoryViewModel), typeof(TradeHistory));
            WindowViewLoaderService.Register(typeof(UserSettingsViewModel), typeof(UserSettings));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            FindResource("NotifyIcon");
        }
    }
}