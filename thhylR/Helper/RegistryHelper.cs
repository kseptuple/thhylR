using Microsoft.Win32;

namespace thhylR.Helper
{
    public static class RegistryHelper
    {
        private static string appPath = $"\"{Application.ExecutablePath}\"";
        private static string iconPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Icon\\IconFile.ico");
        public static bool IsCurrentUserAssociated()
        {
            var associationName = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Classes\\.rpy", "", "");

            if (!string.IsNullOrEmpty(associationName))
            {

                var exeCommand = (string)Registry.GetValue($"HKEY_CURRENT_USER\\Software\\Classes\\{associationName}\\Shell\\Open\\Command", "", "");
                if (exeCommand == $"{appPath} \"%1\"")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAllUserAssociated()
        {
            var associationName = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\.rpy", "", "");

            if (!string.IsNullOrEmpty(associationName))
            {

                var exeCommand = (string)Registry.GetValue($"HKEY_LOCAL_MACHINE\\Software\\Classes\\{associationName}\\Shell\\Open\\Command", "", "");
                if (exeCommand == $"{appPath} \"%1\"")
                {
                    return true;
                }
            }
            return false;
        }

        public static void SetCurrentUserAssociate()
        {
            var exeCommand = $"{appPath} \"%1\"";
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\.rpy", "", "TouhouReplay");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\TouhouReplay", "", ResourceLoader.GetText("RegistryExtensionName"));
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\TouhouReplay\\Shell\\Open\\Command", "", exeCommand);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\TouhouReplay\\DefaultIcon", "", iconPath);
        }

        public static void SetAllUserAssociate()
        {
            var exeCommand = $"{appPath} \"%1\"";
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\.rpy", "", "TouhouReplay");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\TouhouReplay", "", ResourceLoader.GetText("RegistryExtensionName"));
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\TouhouReplay\\Shell\\Open\\Command", "", exeCommand);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\TouhouReplay\\DefaultIcon", "", iconPath);
        }

        public static void RemoveCurrentUserAssociate()
        {
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\.rpy");
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\TouhouReplay");
        }

        public static void RemoveAllUserAssociate()
        {
            Registry.LocalMachine.DeleteSubKeyTree("Software\\Classes\\.rpy");
            Registry.LocalMachine.DeleteSubKeyTree("Software\\Classes\\TouhouReplay");
        }
    }
}
