using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Permission
{
    public static class EnumExtensions
    {
        public static string GetPermissionKey(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            PermissionValueAttribute[] attrs =
                fieldInfo.GetCustomAttributes(typeof(PermissionValueAttribute), false) as PermissionValueAttribute[];

            return attrs.Length > 0 ? attrs[0].Key : string.Empty;
        }

        //public static string GetDisplayName(this Enum enumValue)
        //{
        //    FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        //    DisplayAttribute[] attrs =
        //        fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        //    return attrs.Length > 0 ? attrs[0].Name : enumValue.ToString();
        //}

        //public static string GetDisplayDescription(this Enum enumValue)
        //{
        //    FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        //    DisplayAttribute[] attrs =
        //        fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        //    return attrs.Length > 0 ? attrs[0].Description : enumValue.ToString();
        //}


        //public static string GetDescription(this Enum enumValue)
        //{
        //    FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        //    DescriptionAttribute[] attrs =
        //        fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        //    return attrs.Length > 0 ? attrs[0].Description : enumValue.ToString();
        //}


        public static T GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static IEnumerable<Type> EnumerateNestedTypes(this Type type)
        {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
            Queue<Type> toBeVisited = new Queue<Type>();
            toBeVisited.Enqueue(type);
            do
            {
                Type[] nestedTypes = toBeVisited.Dequeue().GetNestedTypes(flags);
                for (int i = 0, l = nestedTypes.Length; i < l; i++)
                {
                    Type t = nestedTypes[i];
                    yield return t;
                    toBeVisited.Enqueue(t);
                }
            } while (toBeVisited.Count != 0);
        }

        public static Type FindNestedType(this Type type, Predicate<Type> filter)
        {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
            Type[] nestedTypes = type.GetNestedTypes(flags);
            foreach (var nestedType in nestedTypes)
            {
                if (filter(nestedType))
                {
                    return nestedType;
                }
            }
            foreach (var nestedType in nestedTypes)
            {
                Type result = FindNestedType(nestedType, filter);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
