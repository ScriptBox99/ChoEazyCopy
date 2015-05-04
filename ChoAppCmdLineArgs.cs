﻿using Cinchoo.Core;
using Cinchoo.Core.Diagnostics;
using Cinchoo.Core.IO;
using Cinchoo.Core.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChoEazyCopy
{
    [ChoCommandLineArgObject(DisplayDefaultValue = true, UsageSwitch = "_")]
    public class ChoShellExtCmdLineArgs : ChoCommandLineArgObject
    {
        [ChoCommandLineArg("d", Description = "Source directory.", Order = -2)]
        public string Directory
        {
            get;
            set;
        }
    }

    [ChoCommandLineArgObject(DisplayDefaultValue = true, UsageSwitch = "_")]
    public class ChoFileAssociationCmdLineArgs : ChoCommandLineArgObject
    {
        [ChoPositionalCommandLineArg(1, "SettingsFilePath", Description = "Settings file path.")]
        public string SettingsFilePath
        {
            get;
            set;
        }

        public bool IsAppFile;

        protected override void OnAfterCommandLineArgObjectLoaded(string[] commandLineArgs)
        {
            if (!SettingsFilePath.IsNullOrWhiteSpace())
            {
                IsAppFile = Path.GetExtension(SettingsFilePath) == AppHost.AppFileExt;
            }
        }
    }

    [ChoCommandLineArgObject(DisplayDefaultValue=true)]
    public class ChoAppCmdLineArgs : ChoCommandLineArgObject
    {
        [ChoPositionalCommandLineArg(1, "SettingsFilePath", Description = "Settings file path.", IsRequired = true)]
        public string SettingsFilePath
        {
            get;
            set;
        }

        [ChoCommandLineArg("s", Description = "Source directory.", Order = 2, NoOfTabsSwitchDescFormatSeparator=3)]
        public string SourceDirectory
        {
            get;
            set;
        }

        [ChoCommandLineArg("d", Description = "Destination directory.", Order = 3, NoOfTabsSwitchDescFormatSeparator = 3)]
        public string DestDirectory
        {
            get;
            set;
        }

        protected override void OnAfterCommandLineArgObjectLoaded(string[] commandLineArgs)
        {
            if (!SettingsFilePath.IsNullOrWhiteSpace())
            {
                SettingsFilePath = ChoPath.GetFullPath(SettingsFilePath);
            }
        }

        public void StartFileCopy()
        {
            try
            {
                //ChoAppSettings appSettings = new ChoAppSettings();
                //if (!SettingsFilePath.IsNullOrWhiteSpace())
                //{
                //    if (!File.Exists(SettingsFilePath))
                //        throw new ArgumentException("Can't find '{0}' settings file.".FormatString(SettingsFilePath));

                //    appSettings.LoadXml(File.ReadAllText(SettingsFilePath));
                //}

                //ChoConsole.WriteLine("PREVIEW: {0}".FormatString(appSettings.PreviewMode ? "ON" : "OFF"), ConsoleColor.Magenta);
                //if (!appSettings.MoveOrCopyToDirectory.IsNullOrWhiteSpace())
                //    ChoConsole.WriteLine("{0} files to {1}".FormatString(appSettings.DoCopy ? "Coping" : "Moving", appSettings.MoveOrCopyToDirectory), ConsoleColor.Magenta);
                //ChoConsole.WriteLine();

                //ChoFileFolderProcessor _fileFolderNameReplacer = new ChoFileFolderProcessor(SettingsFilePath);
                //_fileFolderNameReplacer.Status += (sender, e) =>
                //{
                //    ChoTrace.Debug(e.Message);
                //    ChoConsole.WriteLine(e.Message, ConsoleColor.Yellow);
                //};
                //_fileFolderNameReplacer.AppStatus += (sender, e) =>
                //{
                //    ChoTrace.Debug(e.Message);
                //    ChoConsole.WriteLine(e.Message, ConsoleColor.Yellow);
                //};

                //if (!Directory.IsNullOrWhiteSpace())
                //{
                //    foreach (string folder in Directory.SplitNTrim())
                //        _fileFolderNameReplacer.Process(folder);
                //}
                //else if (!appSettings.Directories.IsNullOrWhiteSpace())
                //{
                //    foreach (string folder in appSettings.Directories.SplitNTrim())
                //        _fileFolderNameReplacer.Process(folder);
                //}
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ChoApplicationException.ToString(ex));
            }
        }
    }
}
