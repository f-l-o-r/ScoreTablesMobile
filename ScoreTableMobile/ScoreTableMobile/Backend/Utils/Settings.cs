using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ScoreTableMobile.Utils
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public class Settings : INotifyPropertyChanged
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        static Settings settings;

        /// <summary>
        /// Gets or sets the current settings. This should always be used
        /// </summary>
        /// <value>The current.</value>
        public static Settings Current
        {
            get { return settings ?? (settings = new Settings()); }
        }


        #region Setting Constants

        const string PushNotificationsEnabledKey = "push_enabled";
        static readonly bool PushNotificationsEnabledDefault = false;

        const string LeaguesKey = "email_key";
        readonly string LeaguesDefault = string.Empty;

        #endregion

        public string Email
        {
            get { return AppSettings.GetValueOrDefault(LeaguesKey, LeaguesDefault); }
            set
            {
                if (AppSettings.AddOrUpdateValue(LeaguesKey, value))
                {
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(LeaguesDefault));
                }
            }
        }

        public bool PushNotificationsEnabled
        {
            get { return AppSettings.GetValueOrDefault(PushNotificationsEnabledKey, PushNotificationsEnabledDefault); }
            set
            {
                if (AppSettings.AddOrUpdateValue(PushNotificationsEnabledKey, value))
                    OnPropertyChanged();
            }
        }

        bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                if (isConnected == value)
                    return;
                isConnected = value;
                OnPropertyChanged();
            }
        }

        #region Helpers

        public bool IsLoggedIn => !string.IsNullOrWhiteSpace(Email);

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "") =>
                                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}
