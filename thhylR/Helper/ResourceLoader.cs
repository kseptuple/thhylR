using System.Dynamic;
using System.Text;
using YamlDotNet.Serialization;

namespace thhylR.Helper
{
    public static class ResourceLoader
    {
        private static dynamic resource = new ExpandoObject();
        private static Dictionary<string, string> textResources = new Dictionary<string, string>();

        private static Predicate<Dictionary<object, object>> resourceMatcher = dic => dic.ContainsKey(resource);

        public static void Init()
        {
            var deserializer = new DeserializerBuilder().Build();
            using (var input = new StreamReader(@"TextResources\text.yaml", Encoding.UTF8))
            {
                try
                {
                    resource = deserializer.Deserialize<Dictionary<object, object>>(input);
                }
                catch
                {

                }
            };
        }

        public static string GetText(string resourceName)
        {
            if (textResources.ContainsKey(resourceName))
            {
                return textResources[resourceName];
            }
            else
            {
                return string.Empty;
            }
        }

        public static void InitTextResource()
        {
            textResources.Clear();
            if (resource.ContainsKey("text"))
            {
                dynamic textStrings = resource["text"];
                textResources.Clear();
                foreach (var textItem in textStrings)
                {
                    foreach (var textItemName in textItem.Keys)
                    {
                        if (!textResources.ContainsKey(textItemName))
                        {
                            textResources.Add(textItemName, textItem[textItemName]);
                        }
                        else
                        {
                            textResources[textItemName] = textItem[textItemName];
                        }
                    }
                }
            }
        }

        public static void SetFormText(Form form)
        {
            if (resource.ContainsKey(form.Name))
            {
                dynamic currentFormStrings = resource[form.Name];
                form.Text = currentFormStrings[0];
                setControlText(form.Controls, currentFormStrings);
            }

            void setControlText(Control.ControlCollection controls, dynamic currentControlText)
            {
                foreach (Control control in controls)
                {
                    dynamic dynamicObject = null;
                    control.Text = string.Empty;
                    if (currentControlText != null && currentControlText is not string)
                    {
                        Predicate<dynamic> resourceMatcher = item => item is not string && item.ContainsKey(control.Name);
                        var dic = currentControlText.Find(resourceMatcher);

                        if (dic != null)
                        {
                            dynamicObject = dic[control.Name];
                            if (dynamicObject is string)
                            {
                                control.Text = dynamicObject;
                            }
                            else
                            {
                                if (dynamicObject[0] is string)
                                {
                                    control.Text = dynamicObject[0];
                                }
                            }
                        }
                    }
                    if (control is MenuStrip)
                    {
                        setMenuText(((MenuStrip)control).Items, dynamicObject);
                    }
                    if (control.HasChildren)
                    {
                        setControlText(control.Controls, dynamicObject);
                    }
                }
            }

            void setMenuText(ToolStripItemCollection menuItemList, dynamic menuItemText)
            {
                foreach (object item in menuItemList)
                {
                    var menuItem = item as ToolStripMenuItem;
                    if (menuItem == null)
                        continue;
                    dynamic dynamicObject = null;
                    menuItem.Text = string.Empty;
                    if (menuItemText != null && menuItemText is not string)
                    {
                        Predicate<dynamic> resourceMatcher = item => item is not string && item.ContainsKey(menuItem.Name);
                        var dic = menuItemText.Find(resourceMatcher);
                        if (dic != null)
                        {
                            dynamicObject = dic[menuItem.Name];
                            if (dynamicObject is string)
                            {
                                menuItem.Text = dynamicObject;
                            }
                            else
                            {
                                if (dynamicObject[0] is string)
                                {
                                    menuItem.Text = dynamicObject[0];
                                }
                            }
                        }
                    }
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        setMenuText(menuItem.DropDownItems, dynamicObject);
                    }
                }
            }
        }
    }

    public class ControlLanguageModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<ControlLanguageModel> ChildControl { get; set; }
    }
}
