using System.Collections;
using System.Reflection;

namespace thhylR.Helper
{
    public static class GameDataCloner
    {
        private static readonly string overrideFieldName = "OverrideFields";

        public static T Clone<T>(T source)
        {
            object result = null;
            Clone(source, ref result, null, null);
            return (T)result;
        }

        public static void CloneTo<T>(T source, ref T target)
        {
            object targetObj = target;
            Clone(source, ref targetObj, null, null);
            target = (T)targetObj;
        }

        public static void Clone(object source, ref object target, Dictionary<Type, List<object>> cachedObjects, Dictionary<Type, List<object>> newObjects)
        {
            if (source == null)
            {
                //target = null;
                return;
            }
            Type type = source.GetType();

            if (type.IsValueType || type.Equals(typeof(string)))
            {
                target = source;
            }
            else if (type.IsArray)
            {
                Type newType = Type.GetType(type.FullName.Replace("[]", string.Empty));
                var array = source as Array;
                Array resultArray = Array.CreateInstance(newType, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    object newItem = null;
                    Clone(array.GetValue(i), ref newItem, cachedObjects, newObjects);
                    resultArray.SetValue(newItem, i);
                }
                target = Convert.ChangeType(resultArray, type);
            }
            else if (type.GetInterface("IList") != null)
            {
                IList itemList = source as IList;
                var result = Activator.CreateInstance(type) as IList;
                foreach (var item in itemList)
                {
                    object newItem = null;
                    Clone(item, ref newItem, cachedObjects, newObjects);
                    result.Add(newItem);
                }
                target = Convert.ChangeType(result, type);
            }
            else if (type.IsClass)
            {
                object result = Activator.CreateInstance(type);
                if (cachedObjects == null)
                {
                    cachedObjects = new Dictionary<Type, List<object>>();
                }
                if (newObjects == null)
                {
                    newObjects = new Dictionary<Type, List<object>>();
                }
                if (!cachedObjects.ContainsKey(type))
                {
                    cachedObjects.Add(type, new List<object>());
                }
                if (!newObjects.ContainsKey(type))
                {
                    newObjects.Add(type, new List<object>());
                }
                cachedObjects[type].Add(source);
                newObjects[type].Add(result);

                if (target != null && !type.Equals(target.GetType()))
                {
                    target = null;
                }
                List<string> overrideFields = null;
                if (target != null)
                {
                    var targetProperty = type.GetProperty(overrideFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (targetProperty != null && targetProperty.PropertyType.Equals(typeof(List<string>)))
                    {
                        object val = targetProperty.GetValue(target);
                        if (val != null)
                        {
                            overrideFields = val as List<string>;
                        }

                    }
                }
                bool hasOverrideFields = overrideFields != null && overrideFields.Count > 0;
                if (hasOverrideFields)
                {
                    overrideFields.Add(overrideFieldName);
                }

                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    if (hasOverrideFields && overrideFields.Contains(property.Name))
                    {
                        object targetValue = property.GetValue(target);
                        property.SetValue(result, targetValue);
                    }
                    else
                    {
                        bool hasFound = false;
                        object value = property.GetValue(source);
                        if (value != null)
                        {
                            Type fieldType = property.PropertyType;

                            if (fieldType.IsClass && !fieldType.Equals(typeof(string)))
                            {
                                if (cachedObjects.ContainsKey(fieldType))
                                {
                                    for (int i = 0; i < cachedObjects[fieldType].Count; i++)
                                    {
                                        if (object.ReferenceEquals(cachedObjects[fieldType][i], value))
                                        {
                                            hasFound = true;
                                            property.SetValue(result, newObjects[fieldType][i]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (!hasFound)
                        {
                            object newobj = null;
                            if (target != null)
                            {
                                newobj = property.GetValue(target);
                            }
                            Clone(value, ref newobj, cachedObjects, newObjects);
                            property.SetValue(result, newobj);
                        }
                    }
                }
                target = result;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
