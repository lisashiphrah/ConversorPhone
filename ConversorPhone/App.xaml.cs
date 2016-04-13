using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media; 
using System.Windows.Media.Animation;
using System.Windows.Navigation; 
using System.Windows.Shapes; 
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.IO;
using System.IO.IsolatedStorage;


namespace ConversorPhone
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                //PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        #region Application data management


        #region Program Data

        public string ConvertFrom;
        public string ConvertTo;
        public string InputValue = "";
        public string OutputValue = "";

        public string TypeConvertion;

        private void SaveToIsolatedStorage()
        {
            saveTextToIsolatedStorage("ConvertFrom", ConvertFrom);
            saveTextToIsolatedStorage("ConvertTo", ConvertTo);
            saveTextToIsolatedStorage("InputValue", InputValue);
            saveTextToIsolatedStorage("OutputValue", OutputValue);
            saveTextToIsolatedStorage("TypeConvertion", TypeConvertion);
        }

        private void LoadFromIsolatedStorage()
        {
            string temp;
           
            if (loadText("ConvertFrom", out temp))
            {
                ConvertFrom = temp;
            }

            if (loadText("ConvertTo", out temp))
            {
                ConvertTo = temp;
            }

            if (loadText("InputValue", out temp))
            {
                InputValue = temp;
            }

            if (loadText("OutputValue", out temp))
            {
                OutputValue = temp;
            }

            if (loadText("TypeConvertion", out temp))
            {
                TypeConvertion = temp;
            } 
        }


        private void SaveToStateObject()
        {
            SaveTextToStateObject("ConvertFrom", ConvertFrom);
            SaveTextToStateObject("ConvertTo", ConvertTo);
            SaveTextToStateObject("InputValue", InputValue);
            SaveTextToStateObject("OutputValue", OutputValue);
            SaveTextToStateObject("TypeConvertion", TypeConvertion); 
        }

        private void LoadFromStateObject()
        {
            string temp;

            if (LoadTextFromStateObject("ConvertFrom", out temp))
            {
                ConvertFrom = temp;
            }

            if (LoadTextFromStateObject("ConvertTo", out temp))
            {
                ConvertTo = temp;
            }

            if (LoadTextFromStateObject("InputValue", out temp))
            {
                InputValue = temp;
            }

            if (LoadTextFromStateObject("OutputValue", out temp))
            {
                OutputValue = temp;
            }

            if (LoadTextFromStateObject("TypeConvertion", out temp))
            {
                TypeConvertion = temp;
            }
        }

        #endregion

        #region Isolated Storage - using the settings store

        private void saveTextToIsolatedStorage(string filename, string text)
        {
            IsolatedStorageSettings isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            isolatedStore.Remove(filename);
            isolatedStore.Add(filename, text);
            isolatedStore.Save();
        }

        private bool loadText(string filename, out string result)
        {
            IsolatedStorageSettings isolatedStore = IsolatedStorageSettings.ApplicationSettings;

            result = "";
            try
            {
                result = (string)isolatedStore[filename];
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region State Object - stored in memory

        private void SaveTextToStateObject(string filename, string text)
        {
            IDictionary<string, object> stateStore = PhoneApplicationService.Current.State;

            stateStore.Remove(filename);

            stateStore.Add(filename, text);
        }

        private bool LoadTextFromStateObject(string filename, out string result)
        {
            IDictionary<string, object> stateStore = PhoneApplicationService.Current.State;

            result = "";

            if (!stateStore.ContainsKey(filename)) return false;

            result = (string)stateStore[filename];

            return true;
        }

        #endregion

        #endregion

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            // Note: This is not advisable. For larger amounts of data
            // the application should either start up a thread to perform the load
            // or set a flag to trigger the load later on
            // The Launching method should complete as quickly as possible
            LoadFromIsolatedStorage();
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
                LoadFromStateObject();
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            SaveToIsolatedStorage();
            SaveToStateObject();
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            // No need to store to the state object - we are not coming back
            SaveToIsolatedStorage();
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}
