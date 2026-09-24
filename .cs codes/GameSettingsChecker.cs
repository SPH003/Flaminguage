using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class GameSettingsChecker : Form
    {
        private string fontsKey, fontName, fontPath;

        [DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpFileName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SendMessageTimeout(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, out UIntPtr lpdwResult);

        private const uint WM_FONTCHANGE = 0x001D;
        private const int HWND_BROADCAST = 0xffff;

        public static int s;

        public GameSettingsChecker()
        {
            InitializeComponent();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = 200;
            this.Height = 200;
            this.CenterToScreen();
            label1.Location = new Point(this.ClientSize.Width / 2 - label1.ClientSize.Width / 2, this.ClientSize.Height / 2 - label1.ClientSize.Height / 2);

            //First Run Checking

            if (Flaminguage.Properties.Settings.Default.FirstRun == true)
            {
                // Check if the current user has administrator rights
                if (!IsAdministrator())
                {
                    // Relaunch the application as administrator
                    RelaunchAsAdmin();
                }
                else
                {
                    // Proceed with the normal process
                    MessageBox.Show("Running with administrator privileges: Checked");

                    //Coping BebasNeue_Regular.ttf from Resources to BaseDirectory

                    string resourceName3 = "Flaminguage.Resources.BebasNeue-Regular.ttf";
                    string outputFilePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BebasNeue-Regular.ttf");

                    //Coping Fredoka-VariableFont_wdth,wght.ttf from Resources to BaseDirectory

                    string resourceName4 = "Flaminguage.Resources.Fredoka-VariableFont_wdth,wght.ttf";
                    string outputFilePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fredoka-VariableFont_wdth,wght.ttf");

                    //Coping Nunito-VariableFont_wght.ttf from Resources to BaseDirectory

                    string resourceName5 = "Flaminguage.Resources.Nunito-VariableFont_wght.ttf"; // Adjust with your namespace and file name
                    string outputFilePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Nunito-VariableFont_wght.ttf");

                    // Get the executing assembly
                    Assembly assembly = Assembly.GetExecutingAssembly();

                    // Open the resource stream

                    using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName3))
                    {
                        if (resourceStream == null)
                        {
                            MessageBox.Show("Font file not found", "Error");
                            return;
                        }

                        // Create the output file
                        using (FileStream outputStream = new FileStream(outputFilePath3, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(outputStream);
                        }
                    }

                    using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName4))
                    {
                        if (resourceStream == null)
                        {
                            MessageBox.Show("Font file not found", "Error");
                            return;
                        }

                        // Create the output file
                        using (FileStream outputStream = new FileStream(outputFilePath4, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(outputStream);
                        }
                    }

                    using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName5))
                    {
                        if (resourceStream == null)
                        {
                            MessageBox.Show("Font file not found", "Error");
                            return;
                        }

                        // Create the output file
                        using (FileStream outputStream = new FileStream(outputFilePath5, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(outputStream);
                        }
                    }

                    // Call the method to install the font
                    InstallFont(AppDomain.CurrentDomain.BaseDirectory + "BebasNeue-Regular.ttf");

                    RegisterFontInRegistry("BebasNeue-Regular.ttf");
                    if (s == 0)
                    {
                    }
                    else
                    {
                        //MessageBox.Show("Your system will be restart for optimizing operation...");
                        //RestartSystem();
                        //Application.Exit();
                        //Only restart once in the end of font installation and registereation
                    }

                    // Call the method to install the font
                    InstallFont(AppDomain.CurrentDomain.BaseDirectory + "Fredoka-VariableFont_wdth,wght.ttf");

                    RegisterFontInRegistry("Fredoka-VariableFont_wdth,wght.ttf");
                    if (s == 0)
                    {
                    }
                    else
                    {
                        //MessageBox.Show("Your system will be restart for optimizing operation...");
                        //RestartSystem();
                        //Application.Exit();
                    }

                    // Call the method to install the font
                    InstallFont(AppDomain.CurrentDomain.BaseDirectory + "Nunito-VariableFont_wght.ttf");

                    RegisterFontInRegistry("Nunito-VariableFont_wght.ttf");
                    if (s == 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Your system will be restart for optimizing operation...");
                        RestartSystem();
                        Application.Exit();
                    }

                    Logo lg = new Logo();

                    this.WindowState = FormWindowState.Minimized;
                    //   this.ShowInTaskbar = false;
                    lg.Show();
                }
            }
            else
            {
                Logo lg = new Logo();

                this.WindowState = FormWindowState.Minimized;
                //      this.ShowInTaskbar = false;
                lg.Show();
            }
        } //End of Load Method

        // Check if the current process is running with administrator privileges
        private static bool IsAdministrator()
        {
            var currentUser = WindowsIdentity.GetCurrent();
            var currentPrincipal = new WindowsPrincipal(currentUser);
            return currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Relaunch the application as administrator
        private static void RelaunchAsAdmin()
        {
            var exeName = Application.ExecutablePath;
            var startInfo = new ProcessStartInfo
            {
                FileName = exeName,
                UseShellExecute = true,
                Verb = "runas"  // This ensures the application is run as an administrator
            };

            try
            {
                Process.Start(startInfo);
                Application.Exit(); // Exit the non-elevated process
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to relaunch the application as administrator: " + ex.Message);
            }
        }

        // Method to install the font
        public static void InstallFont(string fontFilePath)
        {
            try
            {
                // Ensure the font file exists
                if (!File.Exists(fontFilePath))
                {
                    throw new FileNotFoundException("Font file not found: " + fontFilePath);
                }

                // Get the font file name (e.g., Arial.ttf)
                string fontFileName = Path.GetFileName(fontFilePath);

                // Target Fonts directory
                string fontsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

                // Destination path in the Fonts directory
                string destFontPath = Path.Combine(fontsDirectory, fontFileName);

                // Copy the font file to the Fonts directory if it doesn't already exist
                if (!File.Exists(destFontPath))
                {
                    File.Copy(fontFilePath, destFontPath, true); // Overwrites if it exists
                    MessageBox.Show("Fonts copied to: " + " :\\Windows\\Fonts");

                    // Register the font with Windows
                    int fontsAdded = AddFontResource(destFontPath);
                    if (fontsAdded == 0)
                    {
                        MessageBox.Show("Failed to add the font resource.");
                        s = 0;
                    }
                    else
                    {
                        MessageBox.Show("Font resource added successfully.");
                        s = 1;
                    }

                    // Notify all applications about the font installation
                    UIntPtr result;
                    SendMessageTimeout((IntPtr)HWND_BROADCAST, WM_FONTCHANGE, UIntPtr.Zero, IntPtr.Zero, 0, 1000, out result);

                    MessageBox.Show("Font installed and broadcast message sent.");
                }
                else
                {
                    MessageBox.Show("Fonts already exists in:" + "System:\\Windows\\Fonts");
                    GameSettingsChecker.s = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error installing font: " + ex.Message);
                s = 0;
            }
        }

        private void RegisterFontInRegistry(string fontFileName)
        {
            switch (fontFileName)
            {
                case "BebasNeue-Regular.ttf":
                    fontsKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
                    fontName = "Bebas Neue";
                    fontPath = fontFileName; // Full path to the font file

                    break;

                case "Fredoka-VariableFont_wdth,wght.ttf":
                    fontsKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
                    fontName = "Fredoka Light";
                    fontPath = fontFileName;

                    break;

                case "Nunito-VariableFont_wght.ttf":
                    fontsKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
                    fontName = "Nunito ExtraLight";
                    fontPath = fontFileName;

                    break;
            }

            // Write to the Fonts registry key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(fontsKey, writable: true))
            {
                if (key != null)
                {
                    key.SetValue(fontName, Path.GetFileName(fontPath), RegistryValueKind.String);
                }
            }
        }

        public static void RestartSystem()
        {
            ProcessStartInfo psi = new ProcessStartInfo("shutdown", "/r /t 0")
            {
                CreateNoWindow = true, // No command window
                UseShellExecute = false // Run without shell execution
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restarting the system: " + ex.Message);
            }
        }
    }
}