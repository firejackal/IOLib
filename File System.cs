using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace IOLib
{
    public static class FileSystem
    {
        private const long   ONE_KB = 1024;          //One Kilobyte in Bytes
        private const long   ONE_MB = 1048576;       //One Megabyte in Bytes
        private const long   ONE_GB = 1074521547;    //One Gigabyte in Bytes
        private const long   ONE_TB = 1000000000000; //One Terabyte in Bytes

        private const string BYTES_SHORT = "B";
        private const string BYTES_LONG  = " bytes";
        private const string KB_SHORT    = "K";
        private const string KB_LONG     = "KB";
        private const string MB_SHORT    = "M";
        private const string MB_LONG     = "MB";
        private const string GB_SHORT    = "G";
        private const string GB_LONG     = "GB";
        private const string TB_SHORT    = "T";
        private const string TB_LONG     = "TB";

        //public static string GetAppRootPath() { return GetAppRootPath(System.Windows.Forms.Application.UserAppDataPath, "_srcdir"); }

        public static string GetAppRootPath() { return GetAppRootPath(AppDomain.CurrentDomain.BaseDirectory, "_srcdir"); }

        public static string GetAppRootPath(string startPath) { return GetAppRootPath(startPath, "_srcdir"); }

        public static string GetAppRootPath(string startPath, string checkFile)
        {
            string outPath = startPath;
            string oldPath = "";

            while (true) {
                if(System.IO.File.Exists(System.IO.Path.Combine(outPath, checkFile))) {
                    oldPath = outPath;
                    outPath = System.IO.Path.GetDirectoryName(RemoveDirSep(outPath));
                    if(outPath.Length == 0 || string.Equals(outPath, oldPath, System.StringComparison.CurrentCultureIgnoreCase)) return oldPath;
                } else {
                    break;
                }
            };

            return outPath;
        } //GetAppRootPath function

        public static string AddDirSep(string pathName)
        {
            string results = (string.IsNullOrEmpty(pathName) ? "" : pathName.Trim());
            if(string.IsNullOrEmpty(results)) return "";

            char seperator = System.IO.Path.DirectorySeparatorChar;
            if(results.IndexOf(System.IO.Path.AltDirectorySeparatorChar) < 0) seperator = System.IO.Path.AltDirectorySeparatorChar;

            return (!results.EndsWith(seperator.ToString()) ? results + seperator : results);
        } //AddDirSep function

        public static string RemoveDirSep(string pathName)
        {
            if(pathName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) || pathName.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()))
                return pathName.Substring(0, pathName.Length - 1);
            else
                return pathName;
        } //RemoveDirSep function

        public static List<string> GetDirectoryFiles(string pathName, string searchPattern, bool searchAllDirectories)
        {
            return GetDirectoryFiles(pathName, searchPattern, searchAllDirectories, "_skipdir");
        } //GetDirectoryFiles

        /// <summary>Returns all the files in a specified directory (and sub directories.)</summary>
        /// <param name="pathName">The directory to search for files from.</param>
        /// <param name="searchPattern">The search pattern to find files. (e.g: *.bmp)</param>
        /// <param name="searchAllDirectories">Set to true to search all the sub directories in the chosen directory.</param>
        /// <returns>Returns a list of file names.</returns>
        /// <remarks>Coded this function due to compact .net didn't support the recursive version of System.IO.Directory.GetFiles().</remarks>
        public static List<string> GetDirectoryFiles(string pathName, string searchPattern, bool searchAllDirectories, string skipDirectoryKeyFile)
        {
            if(!System.IO.Directory.Exists(pathName)) return null;
            List<string> items = new List<string>();

            // To keep this function recursive in it's own function, we will be doing a stack of directories to check.
            List<string> dirsToCheck = new List<string>();
            dirsToCheck.Add(pathName);

            string theDir;
            string[] subDirs, foundFiles;
            do {
                // pop the item.
                theDir = dirsToCheck[0];
                dirsToCheck.RemoveAt(0);

                // Get all the directories in this path and add them.
                if(searchAllDirectories) {
                    subDirs = System.IO.Directory.GetDirectories(theDir);
                    if(subDirs != null && subDirs.Length > 0) {
                        foreach(string subDir in subDirs) {
                            if(!System.IO.File.Exists(System.IO.Path.Combine(subDir, skipDirectoryKeyFile)))
                                dirsToCheck.Add(subDir);
                        } //for subDir
                    }
                }

                // Get all the files in this page.
                foundFiles = System.IO.Directory.GetFiles(theDir, "*.*");
                if(foundFiles != null && foundFiles.Length > 0) {
                    string ext = "";
                    foreach(string fileName in foundFiles) {
                        ext = System.IO.Path.GetExtension(fileName);
                        if(searchPattern.Equals("*.*") || (!string.IsNullOrEmpty(ext) && searchPattern.ToLower().Contains("*" + ext.ToLower())))
                            items.Add(fileName);
                    } //for fileName
                }
            } while(dirsToCheck.Count > 0);

            return (items.Count == 0 ? null : items);
        } //GetDirectoryFiles

        public static string GetNextAvailableFile(string fileNameFilter, int startsAt = 1)
        {
            return GetNextAvailableFile(fileNameFilter, "", startsAt);
        } // GetNextAvailableFile

        /// <summary>Returns the next avaiable (non-existing) file that matches the the file name filter string.</summary>
        /// <param name="fileNameFilter">A file name filter string to use to find the next available file, ex: C:\Screen Shots\Screen Shot ?i.bmp"</param>
        /// <returns>The file name of the found existing file.</returns>
        /// <remarks>Filter tokens: ?i (Increased index)</remarks>
        public static string GetNextAvailableFile(string fileNameFilter, string Default, int startsAt = 1)
        {
            if(string.IsNullOrEmpty(fileNameFilter)) return Default;
            const string filterChar = "?";

            // First check to see if(any tokens are saved.
            bool indexToken = (fileNameFilter.IndexOf(filterChar + "i") != -1);
            if(!indexToken) return Default;

            string newFileName = "";
            int    offsetIndex = startsAt;
            do {
                newFileName = fileNameFilter.Replace(filterChar + "i", offsetIndex.ToString());

                if(!System.IO.File.Exists(newFileName)) return newFileName;

                offsetIndex += 1;
            } while (true);
        } // GetNextAvailableFile

        public static string CalculatePath(string pathName, string startPath)
        {
            if(string.IsNullOrEmpty(pathName)) return "";

            if(pathName.StartsWith(".\\")) //current path
                return System.IO.Path.Combine(startPath, pathName.Replace(".\\", ""));
            else if(pathName.StartsWith("\\")) //root path
                // ... Using the start path, return it's root ...
                return System.IO.Path.Combine(System.IO.Path.GetPathRoot(startPath), pathName.Substring(1));
            else {
                if(!pathName.Contains(":\\")) {
                    int pos = 1;
                    do {
                        if(string.Equals(pathName.Substring(pos - 1, 3), "..\\")) {
                            startPath = AddDirSep(System.IO.Path.GetDirectoryName(startPath));
                            pos += "..\\".Length;
                        } else {
                            pos += 1;
                        }

                        if(pos >= pathName.Length) break;
                    } while(true);

                    return System.IO.Path.Combine(startPath, pathName.Replace("..\\", ""));
                } else {
                    return pathName;
                }
            }
        } //CalculatePath function

        public static bool IsRootPath(string pathName)
        {
            return string.Equals(Path.GetPathRoot(pathName), pathName, StringComparison.CurrentCultureIgnoreCase);
        } //IsRootPath Function

        public static string GetFileSizeString(long fileSize, bool shortAbbr = false, int roundPlaces = 2)
        {
            //Bytes
            if(fileSize < ONE_KB)
                return fileSize + (shortAbbr ? BYTES_SHORT : BYTES_LONG).ToString();
                //KB
            else if(fileSize < ONE_MB)
                return System.Math.Round((decimal)(fileSize / ONE_KB), roundPlaces).ToString() + (shortAbbr ? KB_SHORT : KB_LONG).ToString();
                //MB
            else if(fileSize < ONE_GB)
                return System.Math.Round((decimal)(fileSize / ONE_MB), roundPlaces).ToString() + (shortAbbr ? MB_SHORT : MB_LONG).ToString();
                //GB
            else if(fileSize < ONE_TB)
                return System.Math.Round((decimal)(fileSize / ONE_GB), roundPlaces).ToString() + (shortAbbr ? GB_SHORT : GB_LONG).ToString();
                //TB
            else
                return System.Math.Round((decimal)(fileSize / ONE_TB), roundPlaces).ToString() + (shortAbbr ? TB_SHORT : TB_LONG).ToString();
        } //GetFileSizeString Function

        //public static bool HasRightsToListFolderContents(string pathName)
        //{
        //    //return Directory.GetAccessControl(pathName).AreAccessRulesProtected;

        //    try {
        //        string[] files = Directory.GetFiles(pathName);
        //        return true;
        //    } catch { //(Exception ex) {
        //        return false; //if an error happens then boo
        //    }
        //} //HasRightsToListFolderContents Function

        public static bool HasPermissionOnFile(string fileName, FileSystemRights permission)
        {
            FileSecurity accessControlList = File.GetAccessControl(fileName);
            if(accessControlList == null) return false;

            AuthorizationRuleCollection accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            if(accessRules == null) return false;

            bool hasAllow = false;
            foreach(FileSystemAccessRule rule in accessRules) {
                if((permission & rule.FileSystemRights) != permission) continue;

                if(rule.AccessControlType == AccessControlType.Allow) hasAllow = true;
                else if(rule.AccessControlType == AccessControlType.Deny) return false;
            }
            return hasAllow;
        } //HasPermissionOnFile Function

        public static bool HasPermissionOnDirectory(string path, FileSystemRights permission)
        {
            try {
                DirectorySecurity accessControlList = Directory.GetAccessControl(path);
                if(accessControlList == null) return false;

                AuthorizationRuleCollection accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                if(accessRules == null) return false;

                bool hasAllow = false;
                foreach(FileSystemAccessRule rule in accessRules) {
                    if((permission & rule.FileSystemRights) != permission) continue;

                    if(rule.AccessControlType == AccessControlType.Allow)     hasAllow = true;
                    else if(rule.AccessControlType == AccessControlType.Deny) return false;
                }
                return hasAllow;
            } catch {
                // something went wrong...
                return false;
            }
        } //HasWritePermissionOnDirectory Function
    } //FileSystem class
} // IOLib namespace
