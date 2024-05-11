using Microsoft.Win32;

namespace thhylR.Helper
{
    public static class RegistryHelper
    {
        private static string appPath = $"\"{Application.ExecutablePath}\"";
        public static bool isCurrentUserAssociated()
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

        public static bool isAllUserAssociated()
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

        public static void setCurrentUserAssociate()
        {
            var exeCommand = $"{appPath} \"%1\"";
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\.rpy", "", "TouhouReplay");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\TouhouReplay", "", ResourceLoader.GetText("RegistryExtensionName"));
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\TouhouReplay\\Shell\\Open\\Command", "", exeCommand);
            //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\touhou_rpy\\DefaultIcon", "", "");
        }

        public static void setAllUserAssociate()
        {
            var exeCommand = $"{appPath} \"%1\"";
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\.rpy", "", "TouhouReplay");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\TouhouReplay", "", ResourceLoader.GetText("RegistryExtensionName"));
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\TouhouReplay\\Shell\\Open\\Command", "", exeCommand);
            //Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\touhou_rpy\\DefaultIcon", "", "");
        }

        public static void removeCurrentUserAssociate()
        {
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\.rpy");
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\TouhouReplay");
        }

        public static void removeAllUserAssociate()
        {
            Registry.LocalMachine.DeleteSubKeyTree("Software\\Classes\\.rpy");
            Registry.LocalMachine.DeleteSubKeyTree("Software\\Classes\\TouhouReplay");
        }
    }
}
