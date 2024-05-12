using System.Collections.Specialized;
using System.Reflection;

namespace MyOrangeCMS_RazorVersion.Service
{
    public class MyClassConvert
    {

        //public static object CheckUpdateObject(object originalObj, object updateObj)
        //{
        //    foreach (var property in updateObj.GetType().GetProperties())
        //    {
        //        if (property.GetValue(updateObj, null) == null)
        //        {
        //            property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
        //            .GetValue(originalObj, null));
        //        }
        //    }
        //    return updateObj;
        //}
        /// <summary>
        /// 把同名属性值如果不为null和空的复制到目标对象去
        /// </summary>
        /// <param name="assamblyname"></param>
        /// <param name="source"></param>
        /// <param name="sourceClassName"></param>
        /// <param name="dest"></param>
        /// <param name="destClassName"></param>
        public static void setClassPropertyValueFromSourceToDest(
            object source,object dest
            )
        {
            try
            {
         
                PropertyInfo[] aryDest      = dest.GetType().GetProperties();
                //PropertyInfo[] arySource    = source.GetType().GetProperties();
                foreach (PropertyInfo p in aryDest)
                {
                    //01 获取目标对象的属性名称
                    string fieldname   = p.Name;
                    //02 获取同属性名称在源对象的值
                    object sourceValue = source.GetType().GetProperty(fieldname).GetValue(source,null); //getClassPropertyValue(arySource, fieldname, source);
                    //02 获取同属性名称在目标对象的值
                    object destValue   = p.GetValue(dest);

                    //03如果源值不为空，目标值为空或者两个不相等，则使用源值复制给目标对象
                    if (sourceValue != null && sourceValue.ToString() != ""
                         && (destValue == null || destValue.ToString() != sourceValue.ToString())
                        )
                    {
                        p.SetValue(dest, sourceValue);
                    }



                }
            }
            catch(Exception ex)
            {

            }

        }

        //public static object getClassPropertyValue(
        //         PropertyInfo[] arySource,
        //         string destFieldName, object source)
        //     {
           
        //    foreach (PropertyInfo p in arySource)
        //    {
        //        string fieldname = p.Name;
        //        if (fieldname == destFieldName)
        //        {
        //            object objValue = p.GetValue(source);
        //            return objValue;
        //        }


        //    }

        //    return null;

        //}

        ///// <summary>
        ///// 取得类的属性集合
        ///// </summary>
        ///// <param name="assamblyname">程序集合的名称</param>
        ///// <param name="className">类的名称</param>
        ///// <returns></returns>
        //public static PropertyInfo[] getPropertyInfo(string assamblyname, string className)
        //{
        //    string key = assamblyname + "." + className;
        //    Assembly a = Assembly.Load(assamblyname);
        //    NameValueCollection nvc = new NameValueCollection();
        //    Type[] t = a.GetTypes();
        //    foreach (Type t1 in t)
        //    {
        //        string classname = t1.FullName;

        //        int npos = classname.LastIndexOf(".") + 1;
        //        classname = classname.Substring(npos, classname.Length - npos);
        //        if (classname == className)
        //        {
        //            PropertyInfo[] aryP = t1.GetProperties();
        //            return aryP;
        //        }
        //    }
        //    return null;

        //}
    }
}
